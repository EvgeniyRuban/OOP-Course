

namespace OOP_GB.Inheritance
{
    public abstract class Point : Figure
    {
        public Point() : this(null)
        {
        }

        public Point(Figure figure) : base(figure)
        {
        }


        public override string ToString() => base.ToString();
    }
}
