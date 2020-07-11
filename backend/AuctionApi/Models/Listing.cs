using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AuctionApi.Models
{
    public class Listing
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [Required]
        [StringLength(64, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 64 characters in length")]
        public string Name { get; set; }

        [Required]
        [Range(0.01, 10000000.00)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 3, ErrorMessage = "Category must be between 3 and 64 characters in length")]
        public string Category { get; set; }

        [Required]
        [StringLength(2048, MinimumLength = 16, ErrorMessage = "Description must be between 16 and 2048 characters in length")]
        public string Description { get; set; }
    }
}