using AutoMapper;
using LocalGoods.API.Resources;
using LocalGoods.Core.Models;
using LocalGoods.Resources;

namespace LocalGoods.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResource>();
            CreateMap<Category, CategoryResource>();

            CreateMap<ProductResource, Product>();
            CreateMap<CategoryResource, Category>();

            CreateMap<RefreshTokenVM, AuthToken>();

            CreateMap<RegisterVM, User>()
                .ForMember(des => des.Email, opt => opt.MapFrom(src => src.EmailAddress))
                .ForMember(des => des.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(des => des.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(des => des.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(des => des.IsFarmer, opt => opt.MapFrom(src => src.IsFarmer))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();


            CreateMap<User, RegisterVM>()
                .ForMember(des => des.EmailAddress, opt => opt.MapFrom(src => src.Email))
                .ForMember(des => des.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(des => des.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(des => des.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(des => des.IsFarmer, opt => opt.MapFrom(src => src.IsFarmer));
            ;
        }
    }
}
