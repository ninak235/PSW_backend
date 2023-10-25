using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.UseCases;
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
        private readonly IUserService _userService;
        public ClubMemberController(IClubMemberService clubMemberService, IUserService userService)
        {
            _clubMemberService = clubMemberService;
            _userService = userService;
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

        [HttpGet("{clubId}")]
        public ActionResult<PagedResult<UserDto>> GetMembers()
        {
            var clubIdString = HttpContext.Request.RouteValues["clubId"].ToString();

            long.TryParse(clubIdString, out long clubId);
            var serviceResult = _clubMemberService.GetMembers(clubId);

            var users = _userService.GetAll().Value;
            var clubMembers = new List<UserDto>();

            foreach(var member in serviceResult.Value.Results)
            {
                foreach(var user in users.Results)
                {
                    if(member.UserId == user.id)
                    {
                        clubMembers.Add(user);
                    }
                }
            }



            if (serviceResult.IsSuccess)
            {
                var membersResult = new PagedResult<UserDto>(clubMembers, clubMembers.Count);

                return Ok(membersResult);
            }
            else
            {
                // Handle the error condition appropriately and return a corresponding ActionResult
                return BadRequest(); // Example: Return a 400 Bad Request with error details
            }
        }

        [HttpDelete("{userId}/{clubId}")]
        public ActionResult RemoveMember(long userId, long clubId)
        {
            var members = _clubMemberService.GetPaged(0, 0).Value;

            foreach (var member in members.Results)
            {
                if (member.UserId == userId && member.ClubId == clubId)
                {
                    _clubMemberService.Delete((int)member.Id);
                    return Ok();
                }
            }

            return NoContent(); 
        }
    }
}