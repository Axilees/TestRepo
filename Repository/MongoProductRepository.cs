using System;
using System.Collections.Generic;
using Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Repository
{
    public class MongoProductRepository : IProductRepository
    {
        // this is test for git
        private readonly MongoDatabase db;

        public MongoProductRepository()
        {
            MongoServer server = MongoServer.Create("mongodb://127.0.0.1");
            db = server.GetDatabase("shop");
        }

        public IList<Model.Product> FindAll()
        {
            //var docs = db.GetCollection<Model.Product>("docs").FindAll();
            var prods =
                db.GetCollection<BsonDocument>("products")
                  .FindAll()
                  .SetFields("ProductId", "ProductName", "RRP", "SellingPrice");

            var ld = new List<Model.Product>();
            foreach (BsonDocument docse in prods)
            {
                Model.Product prod = new Model.Product();

                prod.Id = docse.GetValue("ProductId").ToInt32();
                prod.Name = docse.GetValue("ProductName").ToString();
                prod.Price = new Model.Price( Convert.ToDecimal(docse.GetValue("RRP")),Convert.ToDecimal(docse.GetValue("SellingPrice")));
                ld.Add(prod);
            }


            return ld;
        }
    }
}