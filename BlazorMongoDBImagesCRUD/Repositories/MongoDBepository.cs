using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMongoDBImagesCRUD.Repositories
{
    public class MongoDBepository
    {

        public MongoClient client;
        public IMongoDatabase db;
   
      public MongoDBepository() 
        {


            this.client = new MongoClient("mongodb://localhost:27017");

            this.db = this.client.GetDatabase("BlazorMongoDBImagesCRUD");

        }
    
    
    }
}
