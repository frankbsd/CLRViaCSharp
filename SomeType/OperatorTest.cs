using System;
using System.Collections.Generic;
using System.Text;

namespace SomeType
{
    class OperatorTest
    {
    }

    public sealed class Complex
    {
        public int Age { get; set; }

        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex { Age = c1.Age + c2.Age };
        }

    }
}
