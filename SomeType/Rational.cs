using System;
using System.Collections.Generic;
using System.Text;

namespace SomeType
{
    public sealed class Rational
    {
      
        //有一个Int32构造一个Rational
        public Rational(Int32 num)
        {

        }

        //由一个Single构造Rational
        public Rational(Single num)
        {

        }

        //将一个Rational转换成Int32
        public Int32 ToInt32()
        {
            return 0;
        }

        //将一个Rational转换成Single
        public Single ToSingle()
        {
            return 0.0f;
        }

        //由一个Int32隐式构造并返回一个Rational
        public  static implicit operator Rational(Int32 num)
        {
            return new Rational(num);
        }

        //由一个Single隐式构造并返回一个Rational
        public static implicit operator Rational(Single num)
        {
            return new Rational(num);
        }

        //由一个Rational显示返回一个Int32
        public static explicit operator Int32(Rational rational)
        {
            return rational.ToInt32();
        }

        //由一个Rational显示返回一个Single
        public static explicit operator Single(Rational rational)
        {
            return rational.ToSingle();
        }
    }
}
