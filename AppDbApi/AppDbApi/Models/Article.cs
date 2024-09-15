using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace AppDb.Models
{
    public class Article
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TimePublished { get; set; }
    }
}
