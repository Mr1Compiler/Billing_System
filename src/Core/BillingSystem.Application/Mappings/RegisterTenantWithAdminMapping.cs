using AutoMapper;
using BillingSystem.Application.DTOs.V1.SuperAdmin;
using BillingSystem.Domain.Entities;

namespace BillingSystem.Application.Mappings;

public class RegisterTenantWithAdminMapping : Profile
{
    public RegisterTenantWithAdminMapping()
    {
        // RegisterTenantWithAdminDtoValidator -> ApplicationUser
        CreateMap<(RegisterTenantWithSuperAdminDto dto, Guid tenantId), ApplicationUser>()
            .ForMember(dest => dest.UserName,
                opt => opt.MapFrom(src => src.dto.UserName))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.dto.Email))
            .ForMember(dest => dest.TenantId,
                opt => opt.MapFrom(src => src.tenantId))
            .ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.dto.FirstName))
            .ForMember(dest => dest.LastName,
                opt => opt.MapFrom(src => src.dto.LastName))
            .ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.dto.Address))
            .ForMember(dest => dest.DateOfBirth,
                opt => opt.MapFrom(src => src.dto.DateOfBirth));

        // RegisterTenantWithSuperAdminDto -> Tenant
        CreateMap<RegisterTenantWithSuperAdminDto, Tenant>()
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.TenantName))
            .ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Domain,
                opt => opt.MapFrom(src => src.TenantDomain))
            .ReverseMap();

        // TenantWithAdminDto 
        CreateMap<(ApplicationUser admin, Tenant tenant), TenantWithAdminDto>()
            .ConstructUsing(src => new TenantWithAdminDto(
                Guid.Parse(src.admin.Id),       // AdminId
                src.admin.UserName!,             // UserName
                src.admin.Email!,                // Email
                src.admin.FirstName,            // FirstName
                src.admin.LastName,             // LastName
                src.admin.Address,              // Address
                src.admin.DateOfBirth,          // DateOfBirth
                src.tenant.Id,                  // TenantId
                src.tenant.Name,                // TenantName
                src.tenant.Address,             // TenantAddress
                src.tenant.Domain               // TenantDomain
            ));

    }
}