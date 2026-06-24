using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Tarefa
{
    [BsonId] // Diz que este é o ID principal do documento
    [BsonRepresentation(BsonType.ObjectId)] // Converte automaticamente o ObjectId do MongoDB em string no C#
    public string Id { get; set; } = string.Empty;
    
    public string Nome { get; set; } = string.Empty;
}