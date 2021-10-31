using System.Text;

namespace OOP_GB.Polymorphism
{
    public sealed class RationalNumber
    {
        private int _numerator;

        private int _denominator;


        public RationalNumber() : this(1, 1) { }

        public RationalNumber(int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
        }


        public int Numerator => _numerator;

        public int Denominator => _denominator;


        public static RationalNumber operator ++(RationalNumber number) //Тест
        {
            return new RationalNumber(
                number._numerator + number._denominator,
                number._denominator);
        }

        public static RationalNumber operator --(RationalNumber number) //Тест
        {
            return new RationalNumber(
                number._numerator - number._denominator,
                number._denominator);
        }

        public static RationalNumber operator +(RationalNumber num1, RationalNumber num2) //Дописать
        {
            int lcm = Algorithms.Lcm(num1.Denominator, num2.Denominator);
            return new RationalNumber(
                num1.Numerator * (lcm / num1.Denominator) + num2.Numerator * (lcm / num2.Denominator),
                lcm);
        }

        public static RationalNumber operator -(RationalNumber num1, RationalNumber num2) //Дописать
        {
            return null;
        }

        public static RationalNumber operator *(RationalNumber num1, RationalNumber num2) //Дописать
        {
            return null;
        }

        public static RationalNumber operator /(RationalNumber num1, RationalNumber num2) //Дописать
        {
            return null;
        }

        public static RationalNumber operator %(RationalNumber num1, RationalNumber num2) //Дописать
        {
            return null;
        }

        public static bool operator ==(RationalNumber num1, RationalNumber num2) //Дописать
        {
            return false;
        }

        public static bool operator !=(RationalNumber num1, RationalNumber num2) //Дописать
        {
            return false;
        }

        public static bool operator <(RationalNumber num1, RationalNumber num2) //Дописать
        {
            return false;
        }

        public static bool operator >(RationalNumber num1, RationalNumber num2) //Дописать
        {
            return false;
        }

        public static bool operator <=(RationalNumber num1, RationalNumber num2) //Дописать
        {
            return false;
        }

        public static bool operator >=(RationalNumber num1, RationalNumber num2) //Дописать
        {
            return false;
        }

        public static implicit operator int(RationalNumber number) //Дописать
        {
            return number._numerator / number._denominator;
        }

        public static implicit operator float(RationalNumber number) //Дописать
        {
            return 0;
        }

        public static implicit operator decimal(RationalNumber number) //Дописать
        {
            return 0;
        }

        public override string ToString()
        {
            if (_denominator == 0) return "(incorrect)";
            StringBuilder result = new StringBuilder();

            // Убираем знак
            var sa = _numerator < 0 ? -1 : 1;
            var sb = _denominator < 0 ? -1 : 1;
            if (sa * sb == -1) result.Append('-');
            _numerator *= sa; _denominator *= sb;

            // Выделяем целую часть
            result.Append(_numerator / _denominator);
            _numerator = _numerator % _denominator;

            // Выделяем дробную часть
            if (_numerator == 0) return result.ToString();
            var rems = new int[_denominator];
            result.Append('.');
            while (_numerator > 0)
            {
                rems[_numerator] = result.Length;
                _numerator = _numerator * 10;
                result.Append(_numerator / _denominator);
                _numerator = _numerator % _denominator;
                if (rems[_numerator] > 0)
                {
                    result.Insert(rems[_numerator], '(');
                    result.Append(')');
                    break;
                }
                rems[_numerator] = result.Length;
            }
            return result.ToString();
        }

        public override bool Equals(object obj) //Дописать
        {
            return base.Equals(obj);
        }
    }
}
