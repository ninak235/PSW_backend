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
    private readonly IClubService _clubService;
    public ClubRequestService(ICrudRepository<ClubRequest> repository, IMapper mapper,IClubService clubService) : base(repository, mapper) 
    {
        _clubService = clubService;
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

    public Result<PagedResult<ClubRequestDto>> GetOwnersClubRequests(long userId)
    {
        var result = GetPaged(0, 0);//dobijem sve clubrequestove
        var clubRequestList = new List<ClubRequestDto>();//napravim praznu listu clubrequestova

        if (result.IsSuccess)
        {
            PagedResult<ClubRequestDto> clubRequests = result.Value;//svi klubrequestovi su smesteni ovde
            PagedResult<ClubDto> clubs = _clubService.GetPaged(0, 0).Value;//svi klubovi su ovde


            foreach (var clubRequest in clubRequests.Results)//za svaki klub request proveravam
            {
                bool shouldAdd = false;
                foreach (ClubDto club in clubs.Results)//za svaki klub proveravam
                {

                    if (club.OwnerId == userId && club.Id == clubRequest.ClubId)//ako vlasnik kluba i prosledjeni user su isti
                    {                                                //i ako je id kluba jednak idiju kluba u requestu
                        shouldAdd = true;
                        break;
                    }
                }
                if (shouldAdd)
                {
                    clubRequestList.Add(clubRequest);
                }
            }
        }

        var clubRequestsResult = new PagedResult<ClubRequestDto>(clubRequestList, clubRequestList.Count);


        return clubRequestsResult;
    }
}
