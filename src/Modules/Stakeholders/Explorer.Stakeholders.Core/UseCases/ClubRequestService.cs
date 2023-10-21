using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using FluentResults;

namespace Explorer.Stakeholders.Core.UseCases;

public class ClubRequestService: CrudService<ClubRequestDto,ClubRequest>,IClubRequestService
{
    public ClubRequestService(ICrudRepository<ClubRequest> repository, IMapper mapper) : base(repository, mapper) 
    {
    }



    Result<ClubRequestDto> IClubRequestService.SendRequest(ClubRequestDto clubRequest)
    {

        Create(clubRequest);
        return null;
    }

    

    Result<ClubRequestDto> IClubRequestService.RemoveRequest(ClubRequestDto clubRequest)
    {
        Delete((int)clubRequest.ClubRequestId);
        return null;
    }
}
