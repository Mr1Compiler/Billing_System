using AutoMapper;
using BillingSystem.Application.DTOs.V1.SubscriptionPlans;
using BillingSystem.Domain.Entities;
using BillingSystem.Domain.Enums;

namespace BillingSystem.Application.Mappings;

public class SubscriptionPlanMapping : Profile
{
    public SubscriptionPlanMapping()
    {
        CreateMap<SubscriptionPlan, SubscriptionPlanDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.SubscriptionPlanStatus, opt => opt.MapFrom(src => src.SubscriptionPlanStatus))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
            .ReverseMap();

        CreateMap<SubscriptionPlan, SubscriptionPlanListDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ReverseMap();

        CreateMap<SubscriptionPlanCreateDto, SubscriptionPlan>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.SubscriptionPlanStatus, opt => opt.MapFrom(src => src.SubscriptionPlanStatus))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ReverseMap();

        CreateMap<SubscriptionPlanUpdateDto, SubscriptionPlan>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name ?? string.Empty))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price ?? 0))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description ?? string.Empty))
            .ForMember(dest => dest.SubscriptionPlanStatus, opt => opt.MapFrom(src => src.SubscriptionPlanStatus ?? SubscriptionPlanStatus.Draft))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ReverseMap();
    }
}
