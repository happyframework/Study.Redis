using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceStack.Redis;

namespace Study.Redis
{
    internal static class RedisClientFactory
    {
        public static RedisClient New()
        {
            return new RedisClient("192.168.128.133");
        }
    }
}
