

namespace OOP_GB.Inheritance
{
    public class Point : Figure
    {
        public Point() : this(null)
        {
        }

        public Point(Figure figure) : base(figure)
        {
        }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}
