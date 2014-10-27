using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using ServiceStack.Redis;

namespace Study.Redis.Tutorials
{
    [TestFixture]
    public sealed class RedisStringStudy
    {
        [Test]
        public void Set_Study()
        {
            using (var client = RedisClientFactory.New())
            {
                var success = client
                                .Set("study:username", "dgw", DateTime.Now.AddMinutes(5));


                Assert.True(success);
            }
        }
    }
}
