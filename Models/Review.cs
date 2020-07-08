using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Livemodo_db.Models
{
    [BsonIgnoreExtraElements]
    public class Review
    {
        //private string id;

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("username")]
        public string Username { get; set; }
        [BsonElement("performer")]
        public string Performer { get; set; }
        [BsonElement("tagline")]
        public string Tagline { get; set; }
        [BsonElement("venue")]
        public string Venue { get; set; }
        [BsonElement("content")]
        public string Content { get; set; }
        [BsonElement("showDate")]
        public string ShowDate { get; set; }
        [BsonElement("rating")]
        public int Rating { get; set; }

    }
}

	//"Performer":"The rock",
	//"Venue":"Venue",
	//"Rating":1,
	//"Tagline":"they suck",
	//"ShowDate":"1/2/3",
	//"Content":"Content",
	//"Username":"Creed"

