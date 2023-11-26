using MongoDB.Bson.Serialization.Attributes;

namespace api.Models
{
    public class testQ
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("firstName")]
        public string firstname { get; set; }

        [BsonElement("lastName")]
        public string lastname { get; set; }

        [BsonElement("username")]
        public string username { get; set; }

        [BsonElement("email")]
        public string email { get; set; }

        [BsonElement("password")]
        public string password { get; set; }

        [BsonElement("singupDate")]
        public string singupDate {  get; set; }
    }
}
