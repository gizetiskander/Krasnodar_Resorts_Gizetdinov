using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krasnodar_Resorts_Gizetdinov.Classes
{
    public class Users
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        protected string Name;
        protected string Email;
        protected string Password;
        protected string Phone;
        protected string Role;
        protected byte[] Image;

        public Users(string v1, string v2, string v3, string v4, string v5, byte[] v6)
        {
            this.Name = v1;
            this.Email = v2;
            this.Password = v3;
            this.Phone = v4;
            this.Role = v5;
            this.Image = v6;
        }

        public Users()
        {
        }

        public string _name { get => Name; set => Name = value; }
        [BsonElement]
        public string _email { get => Email; set => Email = value; }
        [BsonElement]
        public string _password { get => Password; set => Password = value; }
        [BsonElement]
        public string _phone { get => Phone; set => Phone = value; }
        [BsonElement]
        public string _role { get => Role; set => Role = value; }
        [BsonElement]
        public byte[] _image { get => Image; set => Image = value; }



        public void Add(Users us)
        {
            MongoClient client = new MongoClient();
            var abase = client.GetDatabase("Krasnodar_resorts");
            var b = abase.GetCollection<Users>("Users");
            b.InsertOne(us);
            
        }
    }
}
