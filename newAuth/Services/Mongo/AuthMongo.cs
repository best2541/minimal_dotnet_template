using DotNetMinimalAPIDemo.EntityClasses;
using MongoDB.Driver;

namespace minimalAPIDemo.Services.Mongo
{
    public class AuthMongo
    {
        private static string[] args;
        private MongoClient mongoClient;
        private IMongoDatabase mongoDatabase;
        private IMongoCollection<ProductDetails> _product;

        public AuthMongo() {
            var builder = WebApplication.CreateBuilder(args);

            mongoClient = new MongoClient(builder.Configuration["MongoDB:ConnectionURI"]);
            mongoDatabase = mongoClient.GetDatabase(builder.Configuration["MongoDB:DatabaseName"]); //Config.GetSection("Mongo:DatabaseName").Value

        }
        public IMongoCollection<ProductDetails> product() {
            var collection = mongoDatabase.GetCollection<ProductDetails>("Product"); //Collection Transaction
            return collection;
        }
        //public IMongoCollection<ProductDetails> Test_ProductMongo()
        public List<ProductDetails> Test_ProductMongo()
        {
            try {
                return _product.Find(_ => true).ToList();
            }
            catch (Exception ex) {
                var aa = ex;
                throw ex;
            }
        }
    }
}
