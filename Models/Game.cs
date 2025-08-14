using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDB_Minmal_API_Example.Models
{
    [BsonIgnoreExtraElements]
    public class Game
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

    }
}
