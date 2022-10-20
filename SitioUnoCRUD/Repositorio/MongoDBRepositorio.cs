using MongoDB.Driver;
using SitioUnoCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitioUnoCRUD.Repositorio
{
    public class MongoDBRepositorio
    {
        public MongoClient client;

        public IMongoDatabase db { get; set; }

        public MongoDBRepositorio()
        {
            client = new MongoClient("mongodb://localhost:27017");

            db = client.GetDatabase("SitioUno");

        }


    }

}
