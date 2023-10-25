using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.UseCases;
using Explorer.Tours.API.Public.Administration;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Explorer.API.Controllers.Tourist
{

    [Authorize(Policy = "touristPolicy")]
    [Microsoft.AspNetCore.Mvc.Route("api/tourist/clubInvitation")]
    public class ClubInvitationController : BaseApiController 
    {
        private readonly IClubInvitationService _clubInvitationService;

        public ClubInvitationController(IClubInvitationService clubInvitationService)
        {
            _clubInvitationService = clubInvitationService;
        }

        [HttpPost]
        public ActionResult SendInvite(ClubInvitationDto invitation)
        {
            _clubInvitationService.SendInvite(invitation);
            return NoContent(); 
        }
        [HttpGet("{clubId}")]
        public ActionResult<PagedResult<UserDto>> GetTourists()
        {
            var clubIdString = HttpContext.Request.RouteValues["clubId"].ToString();

            long.TryParse(clubIdString, out long clubId);
            var serviceResult = _clubInvitationService.GetTourists(clubId);


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
