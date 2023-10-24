using AutoMapper;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.Core.Domain;

namespace Explorer.Stakeholders.Core.Mappers;

public class StakeholderProfile : Profile
{
    public StakeholderProfile()
    {
        CreateMap<ClubInvitationDto, ClubInvitation>()
             .ForMember(dest => dest.ClubInvitationId, opt => opt.MapFrom(src => src.ClubInvitationId))
             .ForMember(dest => dest.ClubId, opt => opt.MapFrom(src => src.ClubId))
             .ForMember(dest => dest.TouristId, opt => opt.MapFrom(src => src.TouristId))
             .ForMember(dest => dest.InvitationMessage, opt => opt.MapFrom(src => src.InvitationMessage))
             .ForMember(dest => dest.InvitationStatus, opt => opt.MapFrom(src => Enum.Parse(typeof(ClubInvitationStatus), src.InvitationStatus)));

        CreateMap<ClubInvitation, ClubInvitationDto>()
             .ForMember(dest => dest.ClubInvitationId, opt => opt.MapFrom(src => src.ClubInvitationId))
             .ForMember(dest => dest.ClubId, opt => opt.MapFrom(src => src.ClubId))
             .ForMember(dest => dest.TouristId, opt => opt.MapFrom(src => src.TouristId))
             .ForMember(dest => dest.InvitationMessage, opt => opt.MapFrom(src => src.InvitationMessage))
             .ForMember(dest => dest.InvitationStatus, opt => opt.MapFrom(src => src.InvitationStatus.ToString()));

        CreateMap<UserDto, User>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
             .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Enum.Parse(typeof(UserRole), src.Role)));

        CreateMap<User, UserDto>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));





    }
}