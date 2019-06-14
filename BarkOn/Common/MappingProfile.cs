using AutoMapper;
using BarkOn.Data.Entities;
using BarkOn.Services;

namespace BarkOn.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Booking
            CreateMap<BookingCreateModel, Booking>().ReverseMap();
            CreateMap<BookingUpdateModel, Booking>().ReverseMap();
            CreateMap<BookingModel, Booking>().ReverseMap();

            //Customer
            CreateMap<CustomerCreateModel, Customer>().ReverseMap();
            CreateMap<CustomerUpdateModel, Customer>().ReverseMap();
            CreateMap<CustomerModel, Customer>().ReverseMap();

            //Package
            CreateMap<PackageCreateModel, Package>().ReverseMap();
            CreateMap<PackageUpdateModel, Package>().ReverseMap();
            CreateMap<PackageModel, Package>().ReverseMap();

            //Pet
            CreateMap<PetCreateModel, Pet>().ReverseMap();
            CreateMap<PetUpdateModel, Pet>().ReverseMap();
            CreateMap<PetModel, Pet>().ReverseMap();

            //Service
            CreateMap<ServiceCreateModel, Service>().ReverseMap();
            CreateMap<ServiceUpdateModel, Service>().ReverseMap();
            CreateMap<ServiceModel, Service>().ReverseMap();
        }
    }
}
