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
    public class PaymentType
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        protected string Name;

        public PaymentType(string v1)
        {
            this.Name = v1;
         
        }

        public PaymentType()
        {
        }

        public string _name { get => Name; set => Name = value; }
        
       




        public void Add(PaymentType type)
        {
            MongoClient client = new MongoClient();
            var abase = client.GetDatabase("Eco_Oil");
            var b = abase.GetCollection<PaymentType>("PaymentType");
            b.InsertOne(type);
        }
    }
}
