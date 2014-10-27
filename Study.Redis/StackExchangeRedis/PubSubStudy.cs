using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using StackExchange.Redis;

namespace Study.Redis.StackExchangeRedis
{
    [TestFixture]
    public sealed class PubSubStudy
    {
        [Test]
        public void Pub_Sbu_Study()
        {
            {
                var redis = ConnectionMultiplexer.Connect("192.168.128.133:6379");
                var sub = redis.GetSubscriber();
                sub.SubscribeAsync("messages", (channel, message) =>
                {
                    Console.WriteLine(string.Format("响应：{0}", message));
                });
            }

            {
                Task.Run(() =>
                {
                    using (var redis = ConnectionMultiplexer.Connect("192.168.128.133:6379"))
                    {
                        var sub = redis.GetSubscriber();

                        Console.WriteLine("输入：");
                        var message = Console.ReadLine();
                        while (!string.IsNullOrWhiteSpace(message))
                        {
                            sub.PublishAsync("messages", message);

                            Console.WriteLine("继续：");
                            message = Console.ReadLine();
                        }
                    }
                })
                .Wait();
            }
        }
    }
}
