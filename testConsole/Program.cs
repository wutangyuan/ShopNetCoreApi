using System;

namespace testConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int m = 1, n = 0;
            n = (m--) + (++m);//这N为什么等于4？
            Console.WriteLine(n);

        }
    }
}
