using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using FluentResults;



namespace Explorer.Stakeholders.Core.UseCases
{
    public class ClubMemberService : CrudService<ClubMemberDto, ClubMember>, IClubMemberService
    {
        public ClubMemberService(ICrudRepository<ClubMember> crudRepository, IMapper mapper) : base(crudRepository, mapper){}

        public Result<PagedResult<ClubMemberDto>> GetMembers(long clubId)
        {
            var members = GetPaged(0, 0).Value;

            List<ClubMemberDto> clubMembers = new List<ClubMemberDto>();


            foreach(var member in members.Results)
            {
                if(member.ClubId == clubId)
                {
                    clubMembers.Add(member);
                }
            }

            var membersResult = new PagedResult<ClubMemberDto>(clubMembers, clubMembers.Count);



            return membersResult;
        }
    }


}
