using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using FluentResults;

namespace Explorer.Stakeholders.API.Public;
public interface IClubInvitationService
{
    Result<ClubInvitationDto> SendInvite(ClubInvitationDto invitation);

    Result<PagedResult<UserDto>> GetTourists(long clubId);
}

