using AuctionApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace AuctionApi.Services
{
    public class ListingService
    {
        private readonly IMongoCollection<Listing> _listings;

        public ListingService(IAuctionDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _listings = database.GetCollection<Listing>(settings.AuctionsCollectionName);
        }

        public List<Listing> Get() =>
            _listings.Find(listing => true).ToList();

        public Listing Get(string id) =>
            _listings.Find<Listing>(listing => listing.Id == id).FirstOrDefault();

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