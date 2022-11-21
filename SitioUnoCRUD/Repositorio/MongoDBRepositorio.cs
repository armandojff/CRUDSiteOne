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
            client = new MongoClient("mongodb+srv://admin:admindatabasemmg@cluster0.pmav2qm.mongodb.net/?retryWrites=true&w=majority");

            db = client.GetDatabase("SitioUno");

        }


    }

}
