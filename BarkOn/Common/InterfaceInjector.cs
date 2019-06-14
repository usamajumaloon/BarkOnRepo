using BarkOn.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BarkOn.Common
{
    public static class InterfaceInjector
    {
        public static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IPackageService, PackageService>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IServiceService, ServiceService>();
        }
    }
}
