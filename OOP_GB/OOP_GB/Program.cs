using System;
using System.Text;

namespace OOP_GB
{
    class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int buildingCount = 10;
            int maxHeightCount = 1000;
            int maxFloorsCount = 100;
            int maxFlatsCount = 1000;
            int maxEntrancesCount = 10;
            int attemptsToDestroyTheBuilding = 5;

            for (int i=0; i < buildingCount; i++)
            {
                Creator.CreateBuilding(
                    random.Next(maxHeightCount),
                    (uint)random.Next(maxFloorsCount),
                    (uint)random.Next(maxFlatsCount),
                    (uint)random.Next(maxEntrancesCount));
            }

            Console.WriteLine($"Generated buildings count: {Creator.Buildings.Count}\n");

            foreach(var key in Creator.Buildings.Keys)
            {
                Building building = (Building)Creator.Buildings[key];
                Console.WriteLine($"{building.GetInfo()}\n");
            }

            for(int i=0; i < attemptsToDestroyTheBuilding; i++)
            {
                int key = random.Next(buildingCount);
                Creator.Buildings.Remove(key);
                if(!Creator.Buildings.Contains(key) && Creator.Buildings.Count < buildingCount)
                {
                    buildingCount = Creator.Buildings.Count;
                    Console.WriteLine($"Building number {key} was destroyed.");
                }
            }
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

        public static void SearchMail(ref string s)
        {
            char mailSymbol = '@';
            char splitter = ' ';
            StringBuilder temp = new StringBuilder(s.Length);
            string[] content = s.Split(splitter, StringSplitOptions.RemoveEmptyEntries);

            s = s.Remove(0);
            foreach(string item in content)
            {
                if(item.Contains(mailSymbol))
                {
                    temp.AppendLine(item);
                }
            }
            s = temp.ToString();
        }
    }
}
