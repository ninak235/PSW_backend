﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author.Authoring
{
    [Route("api/author/tourBundle")]
    public class TourBundleController : BaseApiController
    {
        private readonly ITourBundleService _tourBundleService;
        public TourBundleController(ITourBundleService tourBundleService) {

            _tourBundleService = tourBundleService;
        }

        [HttpPost]
        public ActionResult<TourBundleDto> Create([FromBody] TourBundleDto tourBundleDto)
        {

            var result = _tourBundleService.Create(tourBundleDto);
            return CreateResponse(result);
        }

        [HttpGet]
        public ActionResult<PagedResult<TourBundleDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _tourBundleService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpGet("toursByBundle")]
        public ActionResult<PagedResult<TourDTO>> GetToursByBundle(List<int> tourIds)
        {
            var result = _tourBundleService.GetToursByBundle(tourIds);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<TourBundleDto> Update([FromBody] TourBundleDto tourBundleDto)
        {
            var result = _tourBundleService.Update(tourBundleDto);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _tourBundleService.Delete(id);
            return CreateResponse(result);
        }

    }
}
