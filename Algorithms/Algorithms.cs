using System;

namespace OOP_GB
{
    public class Algorithms
    {
        public const double Pi = 3.141592653589793;

        /// <summary>
        /// Calcualte lowest common multiple
        /// </summary>
        public static int Lcm(int num1, int num2) => Math.Abs(num1 * num2) / Gcd(num1, num2);

        /// <summary>
        /// Calculate greatest common divisor.
        /// </summary>
        public static int Gcd(int num1, int num2)
        {
            if (num2 < 0)
            {
                num2 = -num2;
            }
            if (num1 < 0)
            {
                num1 = -num1;
            }
            while (num2 > 0)
            {
                int temp = num2;
                num2 = num1 % num2;
                num1 = temp;
            }
            return num1;
        }

        /// <summary>
        /// Calculate the area of a circle.
        /// </summary>
        public static double CircleArea(double radius) => Pi * Math.Pow(radius, 2);

        /// <summary>
        /// Calculate the area of a rectangle.
        /// </summary>
        public static double RectangleArea(double height, double width) => height * width;
    }
}
