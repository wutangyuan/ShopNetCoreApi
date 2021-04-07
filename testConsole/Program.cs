using System;
using StackExchange.Redis;

namespace testConsole
{
    class Program
    {
        static  void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int m = 1, n = 0;
            n = (m--) + (++m);//这N为什么等于4？
            Console.WriteLine(n);


            //测试redis

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1");
            var db = redis.GetDatabase(0);

            var result = db.StringGet("name");
            Console.WriteLine(result);

           var isSet= db.StringSet("name1", "tangyuanname1");

            Console.WriteLine(isSet);
        }
    }
}
