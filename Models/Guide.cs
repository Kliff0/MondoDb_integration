using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DLG.Models;

public class Guide
{

    [BsonId]
    [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonElement("name"), BsonRepresentation(BsonType.String)]
    public string? Name { get; set; }
    [BsonElement("date_of_birth"), BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public DateTime? DateOfBirth { get; set; }
    [BsonElement("guide_name"), BsonRepresentation(BsonType.String)]
    public string? GuideName { get; set; }
}
