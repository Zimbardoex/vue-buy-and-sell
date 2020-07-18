using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AuctionApi.Models
{
    public class Token
    {
        [Required]
        public string value { get; set; }
    }
}