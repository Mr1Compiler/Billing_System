using BillingSystem.Application.DTOs.V1.CustomerSubscriptions;
using BillingSystem.Domain.Entities;
using AutoMapper;

namespace BillingSystem.Application.Mappings;

public class CustomerSubscriptionMapping : Profile
{
    public CustomerSubscriptionMapping()
    {
        // CustomerSubscription -> CustomerSubscriptionDto
        CreateMap<CustomerSubscription, CustomerSubscriptionDto>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.StartDate,
                opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate,
                opt => opt.MapFrom(src => src.EndDate))
            .ForMember(dest => dest.SubscriptionStatus,
                opt => opt.MapFrom(src => src.SubscriptionStatus))
            .ForMember(dest => dest.IsRenewable,
                opt => opt.MapFrom(src => src.IsRenewable))
            .ForMember(dest => dest.CreatedAt,
                opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.UpdatedAt,
                opt => opt.MapFrom(src => src.UpdatedAt))
            .ReverseMap();

        // CustomerSubscription -> CustomerSubscriptionListDto
        CreateMap<CustomerSubscription, CustomerSubscriptionListDto>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.StartDate,
                opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate,
                opt => opt.MapFrom(src => src.EndDate))
            .ForMember(dest => dest.SubscriptionStatus,
                opt => opt.MapFrom(src => src.SubscriptionStatus))
            .ForMember(dest => dest.IsRenewable,
                opt => opt.MapFrom(src => src.IsRenewable))
            .ReverseMap();

        // CustomerSubscriptionCreateDto -> CustomerSubscription
        CreateMap<CustomerSubscriptionCreateDto, CustomerSubscription>()
            .ForMember(dest => dest.StartDate,
                opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate,
                opt => opt.MapFrom(src => src.EndDate))
            .ForMember(dest => dest.SubscriptionStatus,
                opt => opt.MapFrom(src => src.SubscriptionStatus))
            .ForMember(dest => dest.IsRenewable,
                opt => opt.MapFrom(src => src.IsRenewable))
            .ForMember(dest => dest.CreatedAt,
                opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt,
                opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ReverseMap();

        // CustomerSubscriptionUpdateDto -> CustomerSubscription
        CreateMap<CustomerSubscriptionUpdateDto, CustomerSubscription>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.StartDate,
                opt => opt.MapFrom(src => src.StartDate.HasValue ? src.StartDate.Value : default))
            .ForMember(dest => dest.EndDate,
                opt => opt.MapFrom(src => src.EndDate.HasValue ? src.EndDate.Value : default))
            .ForMember(dest => dest.SubscriptionStatus,
                opt => opt.MapFrom(src => src.SubscriptionStatus.HasValue ? src.SubscriptionStatus.Value : default))
            .ForMember(dest => dest.IsRenewable,
                opt => opt.MapFrom(src => src.IsRenewable.HasValue ? src.IsRenewable.Value : default))
            .ForMember(dest => dest.UpdatedAt,
                opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ReverseMap();
    }
}
