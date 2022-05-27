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
    public class Sale
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        protected string Name;
        protected string Price;
        protected string Description;
        protected byte[] Image;

        public Sale(string v1, string v2, string v3, byte[] v4)
        {
            this.Name = v1;
            this.Price = v2;
            this.Description = v3;
            this.Image = v4;
        }

        public Sale()
        {
        }

        public string _name { get => Name; set => Name = value; }
        [BsonElement]
        public string _price { get => Price; set => Price = value; }
        [BsonElement]
        public string _description { get => Description; set => Description = value; }
        [BsonElement]
        public byte[] _image { get => Image; set => Image = value; }




        public void Add(Sale sale)
        {
            MongoClient client = new MongoClient();
            var abase = client.GetDatabase("Krasnodar_resorts");
            var b = abase.GetCollection<Sale>("Sale");
            b.InsertOne(sale);
        }
    }
}
