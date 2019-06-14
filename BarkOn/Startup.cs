using AutoMapper;
using BarkOn.Common;
using BarkOn.Data;
using BarkOn.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace BarkOn
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Cors Origin
            services.AddCors();

            //Identity Related
            services.AddIdentity<User, IdentityRole>(cfg =>
            {

            }).AddEntityFrameworkStores<BarkOnDbContext>();

            services.AddAuthentication()
                .AddCookie()
                .AddJwtBearer();

            //Adding Connection String
            var conn = Configuration.GetConnectionString("Default");
            services.AddDbContext<BarkOnDbContext>(options => options.UseSqlServer(conn));

            InterfaceInjector.InjectServices(services);

            //Seed
            services.AddTransient<BarkOnSeeder>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Bark On API",
                    Description = "Bark On Pet Boarding",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Talking Dotnet", Email = "contact@talkingdotnet.com", Url = "www.talkingdotnet.com" }
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            Mapper.Initialize(c => {
                c.AddProfile<MappingProfile>();
            });

            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();


            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetService<BarkOnSeeder>();
                    seeder.Seed().Wait();
                }
            }
        }
    }
}
