using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace cp.Models
{
    public class Livro
    {
         [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }   

    [BsonElement("Titulo")]
    public string Titulo { get; set; } = null!;

    [BsonElement("AnoPublicacao")]
    public int AnoPublicacao { get; set; }

    [BsonElement("Autor")]
    public Autor Autor { get; set; } = null!;
    }
}
