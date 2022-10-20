using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitioUnoCRUD.Models
{
    public class Worker
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public ObjectId _id { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string año_de_nacimiento { get; set; }

        public string cargo { get; set; }

    }
}