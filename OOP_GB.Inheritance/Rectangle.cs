using System;

namespace OOP_GB.Inheritance
{
    public class Rectangle : Point
    {
        private Size _size;


        public Rectangle() : this(new Size(), null)
        {
        }

        public Rectangle(Size size) : this(size, null)
        {
            _size = size;
        }

        public Rectangle(Size size, Figure figure) :base(figure)
        {
            _size = size;
        }


        public Size Size
        {
            get => _size;
            set
            {
                if (value.Height < 0 && value.Width < 0)
                {
                    throw new ArgumentException($"< 0");
                }
                _size = value;
            }
        }

        public float Area => (float)Algorithms.RectangleArea(_size.Height, _size.Width);


        public override string ToString()
        {
            return $"Size: Height {_size.Height} Width {_size.Width}\n" + base.ToString();
        }

    }
}
