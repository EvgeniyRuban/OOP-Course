using OOP_GB.Coder;
using System;


namespace OOP_GB
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "ABCDE";
            BCoder bCoder = new BCoder();
            ACoder aCoder = new ACoder();
            Console.WriteLine($"Start value: {s}\n");
            while(Console.ReadKey().Key != ConsoleKey.Escape)
            {
                s = bCoder.Encode(s);
                Console.WriteLine($"BCoder.Encode(): {s}");

                Console.ReadKey();


                s = aCoder.Encode(s);
                Console.WriteLine($"ACoder.Encode(): {s}");

                Console.ReadKey();
            }
            
            Console.ReadKey();
        }
    }
}
