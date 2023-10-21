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


    }
}

