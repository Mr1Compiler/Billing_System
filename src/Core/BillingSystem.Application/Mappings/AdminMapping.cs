using AutoMapper;
using BillingSystem.Application.DTOs.V1.Admins;
using BillingSystem.Domain.Entities;

namespace BillingSystem.Application.Mappings;

public class AdminMapping : Profile
{
    public AdminMapping()
    {
        // ApplicationUser -> AdminDto
        CreateMap<ApplicationUser, AdminDto>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => Guid.Parse(src.Id)))
            .ForMember(dest => dest.UserName,
                opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName,
                opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.DateOfBirth,
                opt => opt.MapFrom(src => src.DateOfBirth))
            .ReverseMap();

        // ApplicationUser -> AdminListDto
        CreateMap<ApplicationUser, AdminListDto>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => Guid.Parse(src.Id)))
            .ForMember(dest => dest.Username,
                opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.Address))
            .ReverseMap();

        // AdminCreateDto -> ApplicationUser
        CreateMap<AdminCreateDto, ApplicationUser>()
            .ForMember(dest => dest.UserName,
                opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName,
                opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.DateOfBirth,
                opt => opt.MapFrom(src => src.DateOfBirth))
            .ForMember(dest => dest.CreatedAt,
                opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt,
                opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.Id,
                opt => opt.Ignore()) // Identity generates the Id
            .ReverseMap();

        // AdminUpdateDto -> ApplicationUser
        CreateMap<AdminUpdateDto, ApplicationUser>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.UserName,
                opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName,
                opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.DateOfBirth,
                opt => opt.MapFrom(src => src.DateOfBirth))
            .ForMember(dest => dest.UpdatedAt,
                opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ReverseMap();
    }
}