using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.UseCases
{

    public class ClubService : CrudService<ClubDto, Club>, IClubService
    {
        public ClubService(ICrudRepository<Club> repository, IMapper mapper, IClubMemberService clubMemberService) : base(repository, mapper)
        {
            _clubMemberService = clubMemberService;
        }
        private readonly IClubMemberService _clubMemberService;
        public Result<PagedResult<ClubDto>> GetNotJoinedClubs(long userId)
        {
            var result = GetPaged(0, 0);
            var clubsList = new List<ClubDto>();

            if (result.IsSuccess)
            {
                PagedResult<ClubDto> clubs = result.Value;
                PagedResult<ClubMemberDto> members = _clubMemberService.GetPaged(0, 0).Value;


                foreach (var club in clubs.Results)
                {
                    bool shouldAdd = true;
                    foreach (ClubMemberDto i in members.Results)
                    {

                        if (i.ClubId == club.Id && i.UserId == userId)
                        {
                            shouldAdd = false;
                            break;
                        }
                    }
                    if (shouldAdd)
                    {
                        clubsList.Add(club);
                    }
                }
            }

            var clubsResult = new PagedResult<ClubDto>(clubsList, clubsList.Count);


            return clubsResult;
        }
    } 
}



