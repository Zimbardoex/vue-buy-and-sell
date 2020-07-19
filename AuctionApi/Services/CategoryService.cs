
using AuctionApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace AuctionApi.Services
{
  public class CategoryService
  {
    private readonly IMongoCollection<Category> _categories;

    public CategoryService(IAuctionDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);
      _categories = database.GetCollection<Category>(settings.CategoriesCollectionName);
      seed(_categories);
    }

    private void seed(IMongoCollection<Category> categoriesCollection)
    {
      categoriesCollection.DeleteMany(each => true);
      var categories = new[]
      {
          new BsonDocument {{ "Name", "books" }},
          new BsonDocument {{ "Name", "clothing" }},
          new BsonDocument {{ "Name", "computers" }},
          new BsonDocument {{ "Name", "gaming" }},
          new BsonDocument {{ "Name", "mobile phones" }},
          new BsonDocument {{ "Name", "motors" }},
          new BsonDocument {{ "Name", "instruments" }},
          new BsonDocument {{ "Name", "pets" }},
          new BsonDocument {{ "Name", "sports" }},
      }.ToList();

      foreach (var category in categories)
      {
        var modelCategory = BsonSerializer.Deserialize<Category>(category);
        categoriesCollection.InsertOne(modelCategory);
      }
    }

    public List<Category> Get() =>
        _categories.Find(category => true).ToList();

    public Category Get(string id) =>
        _categories.Find<Category>(category => category.Id == id).FirstOrDefault();

    public Category Create(Category category)
    {
      _categories.InsertOne(category);
      return category;
    }

    public void Update(string id, Category categoryIn) =>
        _categories.ReplaceOne(category => category.Id == id, categoryIn);

    public void Remove(Category categoryIn) =>
        _categories.DeleteOne(category => category.Id == categoryIn.Id);

    public void Remove(string id) =>
        _categories.DeleteOne(category => category.Id == id);
  }
}