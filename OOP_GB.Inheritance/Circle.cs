using System;

namespace OOP_GB.Inheritance
{
    public class Circle : Point
    {
        private float _radius;


        public Circle() : this(0, null)
        {
        }

        public Circle(float radius) : this(radius, null)
        {
        }

        public Circle(float radius, Figure figure) :base(figure)
        {
            _radius = radius;
        }


        public float Radius
        {
            get => _radius;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"< 0");
                }
                _radius = value;
            }
        }

        public float Area => (float)Algorithms.CircleArea(_radius);


        public override string ToString()
        {
            return $"Radius: {_radius}\n" + base.ToString();
        }
    }
}
