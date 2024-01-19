using DotNetMinimalAPIDemo.EntityClasses;
using minimalAPIDemo.Helpers;
using minimalAPIDemo.Services.AuthRedis;
using minimalAPIDemo.Services.Mongo;
using minimalAPIDemo.Services.Sql;
using MongoDB.Driver;
using System.Data;
using System.IdentityModel.Tokens.Jwt;

namespace minimalAPIDemo.Controllers
{
    public class AuthController
    {
        public static IResult NoAuth()
        {
            try
            {
                DataTable datas = AuthSql.Connect("select * from customers");
                List<Customer> ListDatas = new List<Customer>();
                ListDatas = EncryptHelper.ConvertDataTableToList<Customer>(datas);
                return Results.Ok(ListDatas);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Results.BadRequest("Error");
            }
        }

        public static IResult YesAuth(HttpRequest req)
        {
            var header = GetHeaderHelper.ConvertHeader(req);
            return Results.Ok(header["id"].ToString());
        }

        public static IResult Get(HttpRequest req)
        {
            var header = req.Headers["Authorization"];
            string[] token = header.ToString().Split(' ');
            var jwt = new JwtSecurityToken(token[1]);
            return Results.Ok(jwt.Payload["id"]);
        }

        public static IResult GetRedis(string key)
        {
            return Results.Ok(AuthRedis.get(key));
        }

        public static IResult GetMongo()
        {
            var _mongo = new AuthMongo();
            var product = _mongo.product().Find(x => x.name == "pawat").ToList();
            return Results.Ok(product);
        }
    }
}
