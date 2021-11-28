

namespace OOP_GB.Inheritance
{
    public struct Position
    {
        public float X { get; set; }
        public float Y { get; set; }


        public Position(float x, float y)
        {
            X = x;
            Y = y;
        }


        public static Position operator ++(Position pos) => new Position(++pos.X, ++pos.Y);

        public static Position operator --(Position pos)
        {
            float pos_X = pos.X, pos_Y = pos.Y;
            return --pos_X < 0 || --pos_Y < 0 ? pos : new Position(pos_X, pos_Y);
        }
    }
}
