using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KrabbelService.Models
{
    public class User
    {
        [BsonElement("_id")]
        [JsonProperty("_id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [Required]
        public int ExternalId { get; set; }

        [Required]
        public bool IsPrivate { get; set; }

        [Required]
        public string KeyCloakIdentifier { get; set; }

        [Required]
        public string FirstName { get; set; }   

        [Required]
        public string LastName { get; set; }
    }
}