using AutoMapper;
using Repository.Application.Extension;
using Repository.Domain.Models;
using System.Net;

namespace Repository.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<ProductDTO, Product>()
                .ReverseMap()
                .ForMember(dest => dest.PriceStr, opt => opt.MapFrom(src => src.Price.ToStringWithoutTrailingZero()));
            CreateMap<OrderDTO, Order>()
                .ReverseMap()
                .ForMember(dest => dest.TotalPriceStr, opt => opt.MapFrom(src => src.TotalPrice.ToStringWithoutTrailingZero()));

            CreateMap<CustomerDTO, Customer>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LastName + " " + src.FirstName))
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders));

            CreateMap<Customer, CustomerDTO>()
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src =>
                    src.Name != null ? src.Name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault() : string.Empty))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src =>
                    src.Name != null && src.Name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length > 1
                        ? src.Name.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries)[1]
                        : string.Empty))
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders));
            CreateMap<OrderItemDTO, OrderItem>()
                .ReverseMap()
                .ForMember(dest => dest.PriceString, opt => opt.MapFrom(src => src.Price.ToStringWithoutTrailingZero()));


        }


    }
}
