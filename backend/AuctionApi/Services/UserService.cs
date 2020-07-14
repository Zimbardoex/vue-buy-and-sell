
using AuctionApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Security.Claims;
using System.Text;


namespace AuctionApi.Services
{
  public class UserService
  {
    private readonly IMongoCollection<User> _users;

    public UserService(IAuctionDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _users = database.GetCollection<User>(settings.UsersCollectionName);
    }

    public List<User> Get() =>
        _users.Find(user => true).ToList();

    public User Get(string id) =>
        _users.Find<User>(user => user.Id == id).FirstOrDefault();

    public User Create(User user)
    {
      _users.InsertOne(user);
      return user;
    }

    public void Update(string id, User userIn) =>
        _users.ReplaceOne(user => user.Id == id, userIn);

    public void Remove(User userIn) =>
        _users.DeleteOne(user => user.Id == userIn.Id);

    public void Remove(string id) =>
        _users.DeleteOne(user => user.Id == id);

    public string generateJwt(User user)
    {
      // generate token that is valid for 1 day
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(System.Environment.GetEnvironmentVariable("TOKEN_KEY"));
      var issuer = Environment.GetEnvironmentVariable("TOKEN_ISSUER");
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
          {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
          }),
        Expires = DateTime.UtcNow.AddDays(1),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        Issuer = issuer
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }

    public User getUserWithEmail(String email)
    {
      List<User> users = Get();
      User user = users.Find(user => user.Email == email);
      return user;
    }
  }
}