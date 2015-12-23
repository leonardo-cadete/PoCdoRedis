using System;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Newtonsoft;

namespace PoCdoRedis
{
    class Program
    {
        static void Main(string[] args)
        {
            var serializer = new NewtonsoftSerializer();
            var cacheClient = new StackExchangeRedisCacheClient(serializer);

            var eu = new ClasseTeste
            {
                Handle = 1,
                Nome = "Ze do milho"
            };

            cacheClient.Add("key1", "value1");
            cacheClient.Add("classe", eu);

            var x = cacheClient.Get<string>("key1");


            var classe = cacheClient.Get<ClasseTeste>("classe");

            Console.WriteLine("Value: {0}", x);
            Console.WriteLine("Value: {0}", classe.Nome);

            Console.ReadLine();
        }
    }
}
