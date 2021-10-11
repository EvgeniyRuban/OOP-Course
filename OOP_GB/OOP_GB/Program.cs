using System;
using System.Text;
using OOP_GB.Enums;

namespace OOP_GB
{
    class Program
    {
        public static void Main(string[] args)
        {
            string example1 = "новая_строка";
            string example2 = Reverse(example1);
            Console.WriteLine(example1);
            Console.WriteLine(example2);

            Console.ReadKey();
        }


        public static string Reverse(string word)
        {
            StringBuilder result = new StringBuilder(word.Length);
            for(int i = word.Length - 1; i >= 0; i--)
            {
                result.Append(word[i]);
            }

            return result.ToString();
        }
    }
}
