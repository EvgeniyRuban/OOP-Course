using System;

namespace OOP_GB.Inheritance
{
    public class Figure
    {
        private Position _position;

        private ConsoleColor _color;

        private bool _isVisible;


        public Figure() : this(new Position())
        {
        }

        public Figure(Position pos) : this(pos, ConsoleColor.White)
        {
        }

        public Figure(Position pos, ConsoleColor color) : this(pos, color, true)
        {
        }

        public Figure(Position pos, ConsoleColor color, bool isVisible)
        {
            _position = pos;
            _color = color;
            _isVisible = isVisible;
        }

        protected Figure(Figure figure) => Copy(figure);


        public Position Position
        {
            get => _position;
            set
            {
                if(value.X < 0 && value.Y < 0)
                {
                    throw new ArgumentException($"< 0");
                }
                _position = value;
            }
        }

        public ConsoleColor Color
        {
            get => _color;
            set => _color = value;
        }

        public bool IsVisible 
        {
            get => _isVisible;
            set => _isVisible = value;
        }


        public void MoveHorizontal(float amendment)
        {
            _position.X += amendment;
            if(_position.X < 0)
            {
                _position.X = 0;
            }
        }

        public void MoveVertical(float amendment)
        {
            _position.Y += amendment;
            if (_position.Y < 0)
            {
                _position.Y = 0;
            }
        }

        public void Print() => Console.WriteLine(this);

        public override string ToString()
        {
            return $"Position: X {_position.X}, Y {_position.Y}\n" +
                $"Color: {_color}\n" +
                $"IsVisible: {_isVisible}";
        }


        private void Copy(Figure figure)
        {
            if (figure == null)
            {
                _position = new Position();
                _color = ConsoleColor.White;
                _isVisible = true;
            }
            else
            {
                _position = figure._position;
                _color = figure._color;
                _isVisible = figure._isVisible;
            }
        }
    }
}
