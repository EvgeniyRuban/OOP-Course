using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OOP_GB.Polymorphism.Tests
{
    [TestClass]
    public class RationalTests
    {
        [TestMethod]
        public void OperatorIncrement()
        {
            Rational actual = new Rational(1, 1);
            Rational expected = new Rational(2, 1);

            actual++;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OperatorDecrement()
        {
            Rational actual = new Rational(1, 1);
            Rational expected = new Rational(0, 1);

            actual--;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OperatorPlus()
        {
            Rational actual = new Rational(1, 1);
            Rational expected = new Rational(2, 1);

            actual += actual;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OperatorMinus()
        {
            Rational actual = new Rational(2, 1);
            Rational expected = new Rational(0, 1);

            actual -= actual;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OperatorMultiplication()
        {
            Rational actual = new Rational(3, 1);
            Rational expected = new Rational(9, 1);

            actual *= actual;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OperatorDivision()
        {
            Rational number1 = new Rational(9, 1);
            Rational number2 = new Rational(1, 9);
            Rational actual = null;
            Rational expected = new Rational(81, 1);

            actual = number1 / number2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OperatorEqual()
        {
            Rational rationalNumber1 = new Rational(2, 1);
            Rational rationalNumber2 = new Rational(2, 1);

            bool actual = rationalNumber1 == rationalNumber2;

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void OperatorUnequal()
        {
            Rational rationalNumber1 = new Rational(2, 1);
            Rational rationalNumber2 = new Rational(2, 1);

            bool actual = rationalNumber1 != rationalNumber2;

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void OperatorMore()
        {
            Rational rationalNumber1 = new Rational(3, 1);
            Rational rationalNumber2 = new Rational(2, 1);

            bool actual = rationalNumber1 > rationalNumber2;

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void OperatorLess()
        {
            Rational rationalNumber1 = new Rational(1, 1);
            Rational rationalNumber2 = new Rational(2, 1);

            bool actual = rationalNumber1 < rationalNumber2;

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void OperatorMoreEqual()
        {
            Rational rationalNumber1 = new Rational(3, 1);
            Rational rationalNumber2 = new Rational(2, 1);

            bool actual = rationalNumber1 >= rationalNumber2;

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void OperatorLessEqual()
        {
            Rational rationalNumber1 = new Rational(1, 1);
            Rational rationalNumber2 = new Rational(2, 1);

            bool actual = rationalNumber1 <= rationalNumber2;

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void OperatorExplicit_returnedIntType()
        {
            object actual;
            Rational temp = new Rational(1, 1);
            Type expected = typeof(int);

            actual = (int)temp;

            Assert.IsInstanceOfType(actual, expected);
        }

        [TestMethod]
        public void OperatorExplicit_returnedFloatType()
        {
            object actual;
            Rational temp = new Rational(1, 1);
            Type expected = typeof(float);

            actual = (float)temp;

            Assert.IsInstanceOfType(actual, expected);
        }

        [TestMethod]
        public void OperatorExplicit_returnedDoubleType()
        {
            object actual;
            Rational temp = new Rational(1, 1);
            Type expected = typeof(double);

            actual = (double)temp;

            Assert.IsInstanceOfType(actual, expected);
        }

        [TestMethod]
        public void OperatorExplicit_returnedDecimalType()
        {
            object actual;
            Rational temp = new Rational(1, 1);
            Type expected = typeof(decimal);

            actual = (decimal)temp;

            Assert.IsInstanceOfType(actual, expected);
        }
    }
}