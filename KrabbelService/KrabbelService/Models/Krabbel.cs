using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace KrabbelService.Models
{
    public class Krabbel
    {
        [BsonElement("_id")]
        [JsonProperty("_id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } 

        public virtual User Sender { get; set; }

        public virtual User Receiver { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }
    }
}