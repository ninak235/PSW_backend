using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Tours.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/request")]//check this
    public class ClubRequestController : BaseApiController
    {
        private readonly IClubRequestService _clubRequestService;

        public ClubRequestController(IClubRequestService clubRequestService)
        {
            _clubRequestService = clubRequestService;
        }

        [HttpGet]
        public ActionResult<PagedResult<ClubRequestDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _clubRequestService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult SendRequest(ClubRequestDto clubRequest) 
        {
            _clubRequestService.SendRequest(clubRequest);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(ClubRequestDto clubRequest)
        {
            _clubRequestService.RemoveRequest(clubRequest);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public ActionResult<ClubRequestDto> Update([FromBody] ClubRequestDto clubRequest)
        {
            var result = _clubRequestService.Update(clubRequest);
            return CreateResponse(result);
        }

        [HttpGet("{userId}")]
        public ActionResult<PagedResult<ClubRequestDto>> GetOwnersClubRequest()
        {
            var userIdString = HttpContext.Request.RouteValues["userId"].ToString();

            long.TryParse(userIdString, out long userId);
            var serviceResult = _clubRequestService.GetOwnersClubRequests(userId);


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

