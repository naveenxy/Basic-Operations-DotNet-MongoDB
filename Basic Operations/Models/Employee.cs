﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Basic_Operations.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; } = null!;

        [BsonElement("Phone Number")]
        [JsonPropertyName("Phone Number")]
        public string MobileNumber { get; set; } = null!;
    }
}
