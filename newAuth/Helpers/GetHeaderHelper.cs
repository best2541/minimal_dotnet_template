using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace minimalAPIDemo.Helpers
{
    public class GetHeaderHelper
    {
        public static JToken ConvertHeader(HttpRequest req)
        {
            var header = req.Headers["Authorization"];
            string[] token = header.ToString().Split(' ');
            var jwt = new JwtSecurityToken(token[1]);

            string[] tokenParts = token[1].Split('.');
            string encodedPayload = tokenParts[1];


            var base64EncodedBytes = Convert.FromBase64String(encodedPayload.ToString().Replace('-', '+').Replace('_', '/'));
            string decodedPayload = Encoding.UTF8.GetString(base64EncodedBytes);
            Console.WriteLine(base64EncodedBytes);
            JToken resultToken = JToken.Parse(decodedPayload);
            return resultToken;
        }
    }
}
