using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitioUnoCRUD.Models
{
    public class Department
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public ObjectId _id { get; set; }

        public string nombre { get; set; }

        public string area { get; set; }

        public List<Worker> trabajadores { get; set; }


    }
}