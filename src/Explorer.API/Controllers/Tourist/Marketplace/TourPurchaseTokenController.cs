using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos.ShoppingCartDtos;
using Explorer.Payments.API.Public.ShoppingCart;
using Explorer.Tours.API.Dtos;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist.Marketplace
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tokens")]
    public class TourPurchaseTokenController : BaseApiController
    {
        private readonly ITourPurchaseTokenService _tourTokenService;
        public TourPurchaseTokenController(ITourPurchaseTokenService tourTokenService)
        {
            _tourTokenService = tourTokenService;
        }

        [HttpGet]
        public ActionResult<PagedResult<TourPurchaseTokenDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _tourTokenService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpGet("{touristId:int}")]
        public ActionResult<List<TourPurchaseTokenDto>> GetAllByTourist(int touristId)
        {
            var result = _tourTokenService.GetPaged(1, int.MaxValue).Value.Results.Where(t => t.TouristId == touristId).ToList().ToResult();
            return CreateResponse(result);
        }


    }
    
}
