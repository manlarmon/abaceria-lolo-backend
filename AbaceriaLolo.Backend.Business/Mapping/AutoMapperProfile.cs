﻿using AutoMapper;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;

namespace AbaceriaLolo.Backend.Business.Mapping;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Allergen Mapping
        CreateMap<AllergenModel, AllergenDTO>().ReverseMap();

        // MenuProduct Mapping
        CreateMap<MenuProductModel, MenuProductDTO>()
            .ForMember(dest => dest.MenuProductPrices, opt => opt.MapFrom(src => src.MenuProductPrice))
            .ForMember(dest => dest.AllergenMenuProducts, opt => opt.MapFrom(src => src.AllergenMenuProduct))
            .ReverseMap();

        // MenuSection Mapping
        CreateMap<MenuSectionModel, MenuSectionDTO>()
            .ForMember(dest => dest.MenuProducts, opt => opt.MapFrom(src => src.MenuProducts))
            .ReverseMap();

        // MenuProductPrice Mapping
        CreateMap<MenuProductPriceModel, MenuProductPriceDTO>()
            .ForMember(dest => dest.TypeOfServing, opt => opt.MapFrom(src => src.TypeOfServing))
            .ReverseMap();

        // AllergenMenuProduct Mapping
        CreateMap<AllergenMenuProductModel, AllergenMenuProductDTO>()
            .ForMember(dest => dest.Allergen, opt => opt.MapFrom(src => src.Allergen))
            .ReverseMap();

        // TypeOfServing Mapping
        CreateMap<TypeOfServingModel, TypeOfServingDTO>().ReverseMap();
    }
}
