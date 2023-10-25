using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;


namespace Explorer.Stakeholders.Core.UseCases
{
    public class ClubMemberService : CrudService<ClubMemberDto, ClubMember>, IClubMemberService
    {
        public ClubMemberService(ICrudRepository<ClubMember> crudRepository, IMapper mapper) : base(crudRepository, mapper) { }
    }
}
