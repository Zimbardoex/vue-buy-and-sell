using AuctionApi.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;

namespace AuctionApi.Services
{
  public class ListingService
  {
    private readonly IMongoCollection<Listing> _listings;

    public ListingService(IAuctionDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _listings = database.GetCollection<Listing>(settings.ListingsCollectionName);
    }

    public List<Listing> Get() =>
        _listings.Find(listing => true).ToList();

    public List<Listing> GetRandom(int number) =>
        _listings.AsQueryable().Sample(number).ToList();
    public List<Listing> GetListingsByCategory(string category) =>
        _listings.Find(listing => listing.Category.ToLower() == category.ToLower()).ToList();

    public List<Listing> SearchListings(string query) =>
        _listings.Find(listing => listing.Name.ToLower().Contains(query.ToLower())).ToList();

    public Listing Get(string id) =>
        _listings.Find<Listing>(listing => listing.Id == id).FirstOrDefault();

    public List<Listing> GetListingsFor(string userId) =>
        _listings.Find<Listing>(listing => listing.UserId == userId).ToList();

    public Listing Create(Listing listing)
    {
      _listings.InsertOne(listing);
      return listing;
    }

    public void Update(string id, Listing listingIn) =>
        _listings.ReplaceOne(listing => listing.Id == id, listingIn);

    public void Remove(Listing listingIn) =>
        _listings.DeleteOne(listing => listing.Id == listingIn.Id);

    public void Remove(string id) =>
        _listings.DeleteOne(listing => listing.Id == id);
  }
}