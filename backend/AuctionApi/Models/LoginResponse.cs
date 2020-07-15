using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AuctionApi.Models
{
    public class LoginResponse: User
    {
        [Required]
        public string Token { get; set; }
    }
}