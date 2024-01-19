using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DotNetMinimalAPIDemo.EntityClasses
{
    public class ProductDetails
    {
        public int Id { get; set; }
        public string name { get; set; }
    }
}
