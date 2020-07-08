using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Livemodo_db.Models
{
    public class RegisteredUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Username")]
        public string Username { get; set; }
        [BsonElement("Password")]
        public string Password { get; set; }
        [BsonElement("Email")]
        public string Email { get; set; }
        [BsonElement("FirstName")]
        public string FirstName { get; set; }
        [BsonElement("LastName")]
        public string LastName { get; set; }
        
    }
}
