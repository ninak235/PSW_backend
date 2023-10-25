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
    [Route("api/club/club")]
    public class ClubController : BaseApiController
    {
        private readonly IClubService _clubManagementService;
        public ClubController(IClubService clubManagementService)
        {
            _clubManagementService = clubManagementService;
        }
        [HttpGet]
        public ActionResult<PagedResult<ClubDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _clubManagementService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<ClubDto> Create([FromBody] ClubDto clubManagement)
        {
            var result = _clubManagementService.Create(clubManagement);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<ClubDto> Update([FromBody] ClubDto clubManagement)
        {
            var result = _clubManagementService.Update(clubManagement);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _clubManagementService.Delete(id);
            return CreateResponse(result);
        }

        [HttpGet("{userId}")]
        public ActionResult<PagedResult<ClubDto>> GetNotJoinedClubs()
        {
            var userIdString = HttpContext.Request.RouteValues["userId"].ToString();

            long.TryParse(userIdString, out long clubId);
            var serviceResult = _clubManagementService.GetNotJoinedClubs(clubId);


            if (serviceResult.IsSuccess)
            {
                var pagedResult = serviceResult.Value;
                return Ok(pagedResult);
            }
            else
            {
                // Handle the error condition appropriately and return a corresponding ActionResult
                return BadRequest(); // Example: Return a 400 Bad Request with error details
            }
        }


    }
}