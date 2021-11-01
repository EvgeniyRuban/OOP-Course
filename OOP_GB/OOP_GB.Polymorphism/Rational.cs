using System;

namespace OOP_GB.Polymorphism
{
    public sealed class Rational : IEquatable<Rational>
    {
        private int _numerator;

        private int _denominator;


        public Rational() : this(0, 1) { }

        public Rational(int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
        }


        public int Numerator => _numerator;

        public int Denominator => _denominator;


        public static Rational operator ++(Rational number)
        {
            return new Rational(
                number._numerator + number._denominator,
                number._denominator);
        }

        public static Rational operator --(Rational number)
        {
            return new Rational(
                number._numerator - number._denominator,
                number._denominator);
        }

        public static Rational operator +(Rational num1, Rational num2)
        {
            int lcm = 0;
            if (num1._denominator != num2._denominator)
            {
                lcm = Algorithms.Lcm(num1._denominator, num2._denominator);
            }

            Rational result = new Rational(
                num1._numerator * (lcm / num1._denominator) + num2._numerator * (lcm / num2._denominator),
                lcm);

            TrySimplify(result);

            return result;
        }

        public static Rational operator -(Rational num1, Rational num2)
        {
            int lcm = 0;
            if (num1._denominator != num2._denominator)
            {
                lcm = Algorithms.Lcm(num1._denominator, num2._denominator);
            }

            Rational result = new Rational(
                num1._numerator * (lcm / num1._denominator) - num2._numerator * (lcm / num2._denominator),
                lcm);

            TrySimplify(result);

            return result;
        }

        public static Rational operator *(Rational num1, Rational num2)
        {
            Rational result = new Rational(
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

        public static Rational operator /(Rational num1, Rational num2)
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

        public static bool operator ==(Rational num1, Rational num2)
        {
            if (num1._denominator != num2._denominator)
            {
                int lcm = Algorithms.Lcm(num1._denominator, num2._denominator);
                num1._numerator *= (lcm / num1._denominator);
                num2._numerator *= (lcm / num2._denominator);
            }
            return num1._numerator == num2._numerator;
        }

        public static bool operator !=(Rational num1, Rational num2)
        {
            if (num1._denominator != num2._denominator)
            {
                int lcm = Algorithms.Lcm(num1._denominator, num2._denominator);
                num1._numerator *= (lcm / num1._denominator);
                num2._numerator *= (lcm / num2._denominator);
            }
            return num1._numerator != num2._numerator;
        }

        public static bool operator <(Rational num1, Rational num2)
        {
            if (num1._denominator != num2._denominator)
            {
                int lcm = Algorithms.Lcm(num1._denominator, num2._denominator);
                num1._numerator *= (lcm / num1._denominator);
                num2._numerator *= (lcm / num2._denominator);
            }
            return num1._numerator < num2._numerator;
        }

        public static bool operator >(Rational num1, Rational num2)
        {
            if (num1._denominator != num2._denominator)
            {
                int lcm = Algorithms.Lcm(num1._denominator, num2._denominator);
                num1._numerator *= (lcm / num1._denominator);
                num2._numerator *= (lcm / num2._denominator);
            }
            return num1._numerator > num2._numerator;
        }

        public static bool operator <=(Rational num1, Rational num2)
        {
            if (num1._denominator != num2._denominator)
            {
                int lcm = Algorithms.Lcm(num1._denominator, num2._denominator);
                num1._numerator *= (lcm / num1._denominator);
                num2._numerator *= (lcm / num2._denominator);
            }
            return num1._numerator <= num2._numerator;
        }

        public static bool operator >=(Rational num1, Rational num2)
        {
            if (num1._denominator != num2._denominator)
            {
                int lcm = Algorithms.Lcm(num1._denominator, num2._denominator);
                num1._numerator *= (lcm / num1._denominator);
                num2._numerator *= (lcm / num2._denominator);
            }
            return num1._numerator >= num2._numerator;
        }

        public static implicit operator int(Rational number)=> number._numerator / number._denominator;

        public static implicit operator float(Rational number) => (float) number._numerator / number._denominator;

        public static implicit operator double(Rational number) => (double)number._numerator / number._denominator;

        public static implicit operator decimal(Rational number) => (decimal)number._numerator / number._denominator;

        public static Rational ConvertFrom(decimal value)
        {
            string[] temp = value.ToString().Split(',');
            if (temp.Length == 1)
            {
                return new Rational((int)value, 1);
            }
            int scale = (int)Math.Pow(10, temp[1].Length);
            Rational result = new Rational((int)(value * scale), scale);
            TrySimplify(result);

            return result;
        }

        public bool Equals(Rational number) => this == number;

        public override string ToString()
        {
            float result = this;
            return result.ToString();
        }

        public override bool Equals(object obj) => Equals(obj as Rational);

        public override int GetHashCode() => base.GetHashCode();

        private static void TrySimplify(Rational number)
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
