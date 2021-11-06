using System.Collections;

namespace OOP_GB.FactoryMethod
{
    internal sealed class Creator
    {
        private static Creator _creator;


        private Creator() 
        {
            Buildings = new Hashtable();
        }


        public static Hashtable Buildings { get; set; }


        internal static Building CreateBuilding(
            double height,
            uint floorCount,
            uint flatsCount,
            uint entrancesCount)
        {
            if (_creator == null) _creator = new Creator();

            Building building = new Building(height, floorCount, flatsCount, entrancesCount);
            Buildings.Add(building.Number, building);

            return building;
        }
    }
}
