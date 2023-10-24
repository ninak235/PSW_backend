using AutoMapper;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.Core.Domain;

namespace Explorer.Stakeholders.Core.Mappers;

public class StakeholderProfile : Profile
{
    public StakeholderProfile()
    {
        CreateMap<ClubRequestDto, ClubRequest>()
            .ForMember(dest => dest.ClubRequestId, opt => opt.MapFrom(src => src.ClubRequestId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.ClubId, opt => opt.MapFrom(src => src.ClubId))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse(typeof(RequestStatus), src.Status)));

        CreateMap<ClubRequest, ClubRequestDto>()
            .ForMember(dest => dest.ClubRequestId, opt => opt.MapFrom(src => src.ClubRequestId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.ClubId, opt => opt.MapFrom(src => src.ClubId))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

    }
}