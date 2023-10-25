using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using FluentResults;

namespace Explorer.Stakeholders.API.Public;

public interface IClubRequestService
{
    Result<PagedResult<ClubRequestDto>> GetPaged(int page, int pageSize);
    Result<ClubRequestDto> SendRequest(ClubRequestDto clubRequest);
    Result<ClubRequestDto> RemoveRequest(ClubRequestDto clubRequest);

    Result<ClubRequestDto> Update(ClubRequestDto clubRequest);
    Result<PagedResult<ClubRequestDto>> GetOwnersClubRequests(long userId);
}
