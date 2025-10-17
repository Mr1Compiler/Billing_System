using AutoMapper;
using BillingSystem.Application.DTOs.V1.Admins;
using BillingSystem.Application.DTOs.V1.Tenants;
using BillingSystem.Domain.Entities;

namespace BillingSystem.Application.Mappings;

public class TenantMapping : Profile
{
    public TenantMapping()
    {
        // Tenant -> TenantDto
        CreateMap<Tenant, TenantDto>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.TenantStatus,
                opt => opt.MapFrom(src => src.TenantStatus))
            .ForMember(dest => dest.CreatedAt,
                opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.UpdatedAt,
                opt => opt.MapFrom(src => src.UpdatedAt))
            .ReverseMap();

        // Tenant -> TenantListDto
        CreateMap<Tenant, TenantListDto>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.Address))
            .ReverseMap();

        // TenantCreateDto -> Tenant
        CreateMap<TenantCreateDto, Tenant>()
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.CreatedAt,
                opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt,
                opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ReverseMap();

        // TenantUpdateDto -> Tenant
        CreateMap<TenantUpdateDto, Tenant>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name ?? string.Empty))
            .ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.Address ?? string.Empty))
            .ForMember(dest => dest.UpdatedAt,
                opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ReverseMap();
    }
}