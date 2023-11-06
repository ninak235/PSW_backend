using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{

    [Authorize(Policy = "touristPolicy")]
    [Route("api/administration/problem")]

    public class ProblemController : BaseApiController
    {
        private readonly IProblemService _problemService;

       public ProblemController(IProblemService problemService)
        {
            _problemService = problemService;
        }

        [HttpGet("{userId:int}")]
        public ActionResult<List<ProblemDto>> GetByTouristId(int userId, [FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _problemService.GetByTouristId(userId, page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<ProblemDto> Report([FromBody] ProblemDto problem)
        {


            var result = _problemService.Create(problem);
            return CreateResponse(result);
        }

    }
}
