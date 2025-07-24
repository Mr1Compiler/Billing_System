using AutoMapper;
using BillingSystem.Application.DTOs.V1.Customers;
using BillingSystem.Domain.Entities;

namespace BillingSystem.Application.Mappings;

public class CustomerMapping : Profile
{
    public CustomerMapping()
    {
        CreateMap<Customer, CustomerDto>()
            .ForMember(dest => dest.Id,
                src => src.MapFrom(u => u.Id))
            .ForMember(dest => dest.FirstName,
                src => src.MapFrom(u => u.FirstName))
            .ForMember(dest => dest.LastName,
                src => src.MapFrom(u => u.LastName))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(u => u.Email))
            .ForMember(dest => dest.PhoneNumber,
                opt => opt.MapFrom(u => u.PhoneNumber))
            .ForMember(dest => dest.DateOfBirth,
                opt => opt.MapFrom(u => u.DateOfBirth))
            .ForMember(dest => dest.Address,
                opt => opt.MapFrom(u => u.Address))
            .ForMember(dest => dest.CreatedAt,
                opt => opt.MapFrom(u => u.CreatedAt))
            .ForMember(dest => dest.UpdatedAt,
                opt => opt.MapFrom(u => u.UpdatedAt))
            .ReverseMap();

        CreateMap<Customer, CustomerListDto>()
            .ForMember(dest => dest.Id,
                src => src.MapFrom((u => u.Id)))
            .ForMember(dest => dest.FullName,
                src => src.MapFrom((u => $"{u.FirstName} {u.LastName}")))
            .ForMember(dest => dest.Email,
                src => src.MapFrom((u => u.Email)))
            .ForMember(dest => dest.Address,
                src => src.MapFrom((u => u.Address)))
            .ReverseMap();

        CreateMap<CustomerCreateDto, Customer>()
            .ForMember(dest => dest.FirstName,
                src => src.MapFrom((u => u.FirstName)))
            .ForMember(dest => dest.LastName,
                src => src.MapFrom((u => u.LastName)))
            .ForMember(dest => dest.Email,
                src => src.MapFrom((u => u.Email)))
            .ForMember(dest => dest.Address,
                src => src.MapFrom((u => u.Address)))
            .ForMember(dest => dest.PhoneNumber,
                src => src.MapFrom((u => u.PhoneNumber)))
            .ForMember(dest => dest.DateOfBirth,
                src => src.MapFrom((u => u.DateOfBirth)))
            .AfterMap((src, dest) =>
                dest.CreatedAt = DateTime.UtcNow
            )
            .ReverseMap();
        
        CreateMap<CustomerUpdateDto, Customer>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName,
                opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.PhoneNumber,
                opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.DateOfBirth,
                opt => opt.MapFrom(src => src.DateOfBirth))
            .ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.UpdatedAt,
                opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ReverseMap();
    }
}