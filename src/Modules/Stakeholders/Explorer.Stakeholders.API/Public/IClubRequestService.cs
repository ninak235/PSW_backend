using Explorer.Stakeholders.API.Dtos;
using FluentResults;

namespace Explorer.Stakeholders.API.Public;

public interface IClubRequestService
{
    Result<ClubRequestDto> SendRequest(ClubRequestDto clubRequest);
    Result<ClubRequestDto> RemoveRequest(ClubRequestDto clubRequest);

    Result<ClubRequestDto> Update(ClubRequestDto clubRequest);
}
