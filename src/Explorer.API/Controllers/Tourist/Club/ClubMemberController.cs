using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Tours.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist.Club
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/club/clubMember")]
    public class ClubMemberController : BaseApiController
    {
        private readonly IClubMemberService _clubMemberService;
        public ClubMemberController(IClubMemberService clubMemberService)
        {
            _clubMemberService = clubMemberService;
        }
        [HttpGet]
        public ActionResult<PagedResult<ClubMemberDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _clubMemberService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<ClubMemberDto> Create([FromBody] ClubMemberDto clubMember)
        {
            var result = _clubMemberService.Create(clubMember);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<ClubMemberDto> Update([FromBody] ClubMemberDto clubMember)
        {
            var result = _clubMemberService.Update(clubMember);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _clubMemberService.Delete(id);
            return CreateResponse(result);
        }
    }
}