using AuctionApi.Models;
using AuctionApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
    public ActionResult<List<Listing>> Get() =>
        _listingService.Get();

    [HttpGet]
    [Route("random")]
    public ActionResult<List<Listing>> Get(int number) =>
        _listingService.GetRandom(number);

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

    [HttpGet("{category}", Name = "GetListingsByCategory")]
    public ActionResult<List<Listing>> GetListingsByCategory(string category)
    {
      var listings = _listingService.GetListingsByCategory(category);

      if (listings== null)
      {
        return NotFound();
      }

      return listings;
    }

    public string getTokenPayload(string token)
    {
      string userId = null;
      var newtoken = new JwtSecurityToken(jwtEncodedString: token);
      foreach(Claim claim in newtoken.Claims){
          if (claim.Type == "Id"){
              userId = claim.Value;
          }
      }
      return userId;
    }

    [HttpPost]
    [Authorize]
    [Route("my-listings")]
    public ActionResult<List<Listing>> GetMyListings(Token token)
    {
      var userId = getTokenPayload(token.value);
      var listings = _listingService.GetListingsFor(userId);

      if (listings == null || userId == null)
      {
        return NotFound();
      }

      return listings;
    }

    [HttpPost]
    [Authorize]
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