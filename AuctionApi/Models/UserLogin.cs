using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AuctionApi.Models
{
    public class UserLogin
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 3, ErrorMessage = "Email must be between 3 and 64 characters in length")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 3, ErrorMessage = "Password must be between 3 and 64 characters in length")]
        public string Password { get; set; }
    }
}