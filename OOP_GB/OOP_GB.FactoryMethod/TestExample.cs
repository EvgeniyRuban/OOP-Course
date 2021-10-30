using System;

namespace OOP_GB.FactoryMethod
{
    public static class TestExample
    {
        public static void Execute()
        {
            Random random = new Random();
            int buildingCount = 10;
            int maxHeightCount = 1000;
            int maxFloorsCount = 100;
            int maxFlatsCount = 1000;
            int maxEntrancesCount = 10;
            int attemptsToDestroyTheBuilding = 5;

            for (int i = 0; i < buildingCount; i++)
            {
                Creator.CreateBuilding(
                    random.Next(maxHeightCount),
                    (uint)random.Next(maxFloorsCount),
                    (uint)random.Next(maxFlatsCount),
                    (uint)random.Next(maxEntrancesCount));
            }

            Console.WriteLine($"Generated buildings count: {Creator.Buildings.Count}\n");

            foreach (var key in Creator.Buildings.Keys)
            {
                Building building = (Building)Creator.Buildings[key];
                Console.WriteLine($"{building.GetInfo()}\n");
            }

            for (int i = 0; i < attemptsToDestroyTheBuilding; i++)
            {
                int key = random.Next(buildingCount);
                Creator.Buildings.Remove(key);
                if (!Creator.Buildings.Contains(key) && Creator.Buildings.Count < buildingCount)
                {
                    buildingCount = Creator.Buildings.Count;
                    Console.WriteLine($"Building number {key} was destroyed.");
                }
            }
        }
    }
}
