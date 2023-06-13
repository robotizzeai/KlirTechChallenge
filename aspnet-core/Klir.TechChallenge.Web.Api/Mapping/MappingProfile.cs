using AutoMapper;
using Klir.TechChallenge.Web.Api.DTO;
using Klir.TechChallenge.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<CartItem, CartItemDTO>().ForMember(dest => dest.Promotion, opt => opt.MapFrom(src => src.Product.Promotion.Name));
            CreateMap<Product, CartItem>().ForMember(dest => dest.Product, opt => opt.MapFrom(src => src));

        }            
    }
}
