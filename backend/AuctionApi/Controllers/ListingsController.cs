using AuctionApi.Models;
using AuctionApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace ListingsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private readonly ListingService _listingService;

        public ListingsController(ListingService listingService)
        {
            _listingService = listingService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<Listing>> Get() =>
            _listingService.Get();

        [HttpGet("{id:length(24)}", Name = "GetListing")]
        public ActionResult<Listing> Get(string id)
        {
            var listing = _listingService.Get(id);

            if (listing == null)
            {
                return NotFound();
            }

            return listing;
        }

        [HttpPost]
        public ActionResult<Listing> Create(Listing listing)
        {
            _listingService.Create(listing);

            return CreatedAtRoute("GetListing", new { id = listing.Id.ToString() }, listing);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Listing listingIn)
        {
            var listing = _listingService.Get(id);

            if (listing == null)
            {
                return NotFound();
            }

            _listingService.Update(id, listingIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var listing = _listingService.Get(id);

            if (listing == null)
            {
                return NotFound();
            }

            _listingService.Remove(listing.Id);

            return NoContent();
        }
    }
}