

namespace OOP_GB.FactoryMethod
{
    internal class Building
    {
        private int _number;

        private double _height;

        private uint _floorsCount;

        private uint _flatsCount;

        private uint _entrancesCount;


        private static int _lastNumber;


        public Building() : this(0, 0, 0, 0) { }

        public Building(
            double height,
            uint floorsCount,
            uint flatsCount,
            uint entrancesCount)
        {
            _height = height;
            _floorsCount = floorsCount;
            _flatsCount = flatsCount;
            _entrancesCount = entrancesCount;
            _number = GenerateNumber();   
        }


        public int Number => _number;

        public double Height => _height;

        public uint FloorsCount => _floorsCount;

        public uint FlatsCount => _flatsCount;

        public uint EntrancesCount => _entrancesCount;


        public double GetFloorHeight(int floorNumber)
        {
            if (_floorsCount > 0)
            {
                return _height / _floorsCount * floorNumber;
            }
            return 0;
        }

        public uint GetFlatsCountPerEntrance()
        {
            if(_entrancesCount > 0)
            {
                return _flatsCount / _entrancesCount;
            }
            return 0;
        }

        public uint GetFlatsCountPerFloor()
        {
            if(_floorsCount > 0)
            {
                return _flatsCount / _floorsCount;
            }
            return 0;
        }

        public string GetInfo()
        {
            return $"Number: {_number}\n" +
                $"Height: {_height}\n" +
                $"FloorsCount: {_floorsCount}\n" +
                $"FlatsCounr: {_flatsCount}\n" +
                $"EntracesCount: {_entrancesCount}";
        }


        private static int GenerateNumber() => ++_lastNumber;
    }
}
