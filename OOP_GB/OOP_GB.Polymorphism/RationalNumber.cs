using System;

namespace OOP_GB.Polymorphism
{
    public sealed class RationalNumber : IEquatable<RationalNumber>
    {
        private int _numerator;

        private int _denominator;


        public RationalNumber() : this(0, 1) { }

        public RationalNumber(int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
        }


        public int Numerator => _numerator;

        public int Denominator => _denominator;


        public static RationalNumber ConvertFrom(decimal value)
        {
            string[] temp = value.ToString().Split(',');
            if(temp.Length == 1)
            {
                return new RationalNumber((int)value, 1);
            }
            int scale = (int)Math.Pow(10, temp[1].Length);
            RationalNumber result = new RationalNumber((int)(value * scale), scale);
            TrySimplify(result);

            return result;
        }

        public static RationalNumber operator ++(RationalNumber number)
        {
            return new RationalNumber(
                number._numerator + number._denominator,
                number._denominator);
        }

        public static RationalNumber operator --(RationalNumber number)
        {
            return new RationalNumber(
                number._numerator - number._denominator,
                number._denominator);
        }

        public static RationalNumber operator +(RationalNumber num1, RationalNumber num2)
        {
            int lcm = 0;
            if (num1._denominator != num2._denominator)
            {
                lcm = Algorithms.Lcm(num1._denominator, num2._denominator);
            }

            RationalNumber result = new RationalNumber(
                num1._numerator * (lcm / num1._denominator) + num2._numerator * (lcm / num2._denominator),
                lcm);

            TrySimplify(result);

            return result;
        }

        public static RationalNumber operator -(RationalNumber num1, RationalNumber num2)
        {
            int lcm = 0;
            if (num1._denominator != num2._denominator)
            {
                lcm = Algorithms.Lcm(num1._denominator, num2._denominator);
            }

            RationalNumber result = new RationalNumber(
                num1._numerator * (lcm / num1._denominator) - num2._numerator * (lcm / num2._denominator),
                lcm);

            TrySimplify(result);

            return result;
        }

        public static RationalNumber operator *(RationalNumber num1, RationalNumber num2)
        {
            RationalNumber result = new RationalNumber(
                num1._numerator * num2._numerator,
                num1._denominator * num2._denominator);

            int gcd = Algorithms.Gcd(result._numerator, result._denominator);
            while (gcd > 1)
            {
                result._numerator /= gcd;
                result._denominator /= gcd;
                gcd = Algorithms.Gcd(result._numerator, result._denominator);
            }
            return result;
        }

        public static RationalNumber operator /(RationalNumber num1, RationalNumber num2)
        {
            int temp = num2._denominator;
            num2._denominator = num2._numerator;
            num2._numerator = temp;
            if (num2._denominator < 0)
            {
                num2._denominator *= -1;
                num2._numerator *= -1;
            }
            return num1 * num2;
        }

        public static bool operator ==(RationalNumber num1, RationalNumber num2)
        {
            if (num1._denominator != num2._denominator)
            {
                int lcm = Algorithms.Lcm(num1._denominator, num2._denominator);
                num1._numerator *= (lcm / num1._denominator);
                num2._numerator *= (lcm / num2._denominator);
            }
            return num1._numerator == num2._numerator;
        }

        public static bool operator !=(RationalNumber num1, RationalNumber num2)
        {
            if (num1._denominator != num2._denominator)
            {
                int lcm = Algorithms.Lcm(num1._denominator, num2._denominator);
                num1._numerator *= (lcm / num1._denominator);
                num2._numerator *= (lcm / num2._denominator);
            }
            return num1._numerator != num2._numerator;
        }

        public static bool operator <(RationalNumber num1, RationalNumber num2)
        {
            if (num1._denominator != num2._denominator)
            {
                int lcm = Algorithms.Lcm(num1._denominator, num2._denominator);
                num1._numerator *= (lcm / num1._denominator);
                num2._numerator *= (lcm / num2._denominator);
            }
            return num1._numerator < num2._numerator;
        }

        public static bool operator >(RationalNumber num1, RationalNumber num2)
        {
            if (num1._denominator != num2._denominator)
            {
                int lcm = Algorithms.Lcm(num1._denominator, num2._denominator);
                num1._numerator *= (lcm / num1._denominator);
                num2._numerator *= (lcm / num2._denominator);
            }
            return num1._numerator > num2._numerator;
        }

        public static bool operator <=(RationalNumber num1, RationalNumber num2)
        {
            if (num1._denominator != num2._denominator)
            {
                int lcm = Algorithms.Lcm(num1._denominator, num2._denominator);
                num1._numerator *= (lcm / num1._denominator);
                num2._numerator *= (lcm / num2._denominator);
            }
            return num1._numerator <= num2._numerator;
        }

        public static bool operator >=(RationalNumber num1, RationalNumber num2)
        {
            if (num1._denominator != num2._denominator)
            {
                int lcm = Algorithms.Lcm(num1._denominator, num2._denominator);
                num1._numerator *= (lcm / num1._denominator);
                num2._numerator *= (lcm / num2._denominator);
            }
            return num1._numerator >= num2._numerator;
        }

        public static implicit operator int(RationalNumber number)=> number._numerator / number._denominator;

        public static implicit operator float(RationalNumber number) => (float) number._numerator / number._denominator;

        public static implicit operator double(RationalNumber number) => (double)number._numerator / number._denominator;

        public static implicit operator decimal(RationalNumber number) => (decimal)number._numerator / number._denominator;

        public bool Equals(RationalNumber number) => this == number;

        public override string ToString()
        {
            float result = this;
            return result.ToString();
        }

        public override bool Equals(object obj) => Equals(obj as RationalNumber);

        public override int GetHashCode() => base.GetHashCode();

        private static void TrySimplify(RationalNumber number)
        {
            int gcd = Algorithms.Gcd(number._numerator, number._denominator);
            while (gcd > 1)
            {
                number._numerator /= gcd;
                number._denominator /= gcd;
                gcd = Algorithms.Gcd(number._numerator, number._denominator);
            }
        }
    }
}
