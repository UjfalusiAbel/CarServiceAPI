using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain
{
    public class Service
    {
        [BsonId]
        public Guid Id {get; set;}
        public string Name {get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public List<Offer> Offers { get; set; }
        public float Score { get; set; }
        public List<Review> Reviews { get; set; }
    }
}