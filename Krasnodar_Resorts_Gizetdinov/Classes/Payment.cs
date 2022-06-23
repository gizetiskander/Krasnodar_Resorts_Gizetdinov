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
    public class Payment
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        protected string UserName;
        protected string Service;
        protected string PaymentType;
        protected string Number;
        protected string Price;
        protected bool Done;
        protected DateTime Date;

        public Payment(string v1, string v2, string v3, string v4, string v5, bool v6, DateTime v7)
        {
            this.UserName = v1;
            this.Service = v2;
            this.PaymentType = v3;
            this.Number = v4;
            this.Price = v5;
            this.Done = v6;
            this.Date = v7;
        }

        public Payment()
        {
        }

        public string _username { get => UserName; set => UserName = value; }
        [BsonElement]
        public string _service { get => Service; set => Service = value; }
        [BsonElement]
        public string _paymentype { get => PaymentType; set => PaymentType = value; }
        [BsonElement]
        public string _number { get => Number; set => Number = value; }
        [BsonElement]
        public string _price { get => Price; set => Price = value; }
        [BsonElement]
        public bool _done { get => Done; set => Done = value; }
        [BsonElement]
        public DateTime _date { get => Date; set => Date = value; }




        public void Add(Payment payment)
        {
            MongoClient client = new MongoClient();
            var abase = client.GetDatabase("Eco_Oil");
            var b = abase.GetCollection<Payment>("Payment");
            b.InsertOne(payment);
        }
    }
}
