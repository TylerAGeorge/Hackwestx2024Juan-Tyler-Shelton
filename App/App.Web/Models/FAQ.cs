using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace App.Web.Models;

public class FAQ
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? _id { get; set; }

    public string Question { get; set; } = null!;

    public string Answer { get; set; } = null!;

    public int ID { get; set; }

}