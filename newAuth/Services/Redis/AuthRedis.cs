using StackExchange.Redis;
using System.Data;

namespace minimalAPIDemo.Services.AuthRedis
{
    public class AuthRedis
    {
        static readonly ConnectionMultiplexer _authRedis = ConnectionMultiplexer.Connect($"192.168.10.27:6381");

        public static string get(string key)
        {
            var redis = _authRedis.GetDatabase();
            return redis.StringGet(key);
        }
    }
}
