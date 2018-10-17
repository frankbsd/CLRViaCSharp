using System;
using System.Collections.Generic;
using System.Text;

namespace SomeType
{
    class Program
    {
        static void Main(string[] args)
        {
            //Rectangle rectangle = new Rectangle();
            //Point p = default(Point);
            //Console.WriteLine(p);
            //Console.WriteLine("rectangle.m_topLeft:(" + rectangle.m_topLeft.m_x + ","+rectangle.m_topLeft.m_y+"),rectangle.m_bottomRight:(" + rectangle.m_bottomRight.m_x+","+rectangle.m_bottomRight.m_y+")");

            //SomeValType[] a = new SomeValType[10];
            //a[0].m_x = 123;
            //a[1].m_x = 456;
            //Console.WriteLine(a[0].m_x);
            //Console.WriteLine(a[1].m_x);

            //Rational r1 = 5;
            //Rational r2 = 2.5f;

            //Int32 x = (Int32)r1;
            //Single s = (Single)r2;

            //StringBuilder sb = new StringBuilder("Hello. my name is Jeff");
            //Int32 index = StringBuilderExtensions.IndexOf(sb.Replace('.', '!'), '!');
            //Console.WriteLine(index);
            //index = sb.Replace('!', '@').IndexOf('@');
            //Console.WriteLine(index);
            //StringBuilder sb = null;

            ////调用扩展方法，NullReferenceException异常不会在IndexOf时抛出
            ////而是在IndexOf内部的for循环时抛出。
            //Int32 index = sb.IndexOf('X');

            ////调用实例方法：NullReferenceException异常在调用Replace时抛出
            //StringBuilder result = sb.Replace('.', '!');
            //"Frank".ShowItems();
            //new[] { "frank", "jeff" }.ShowItems();
            //new List<Int32> { 1, 2, 3 }.ShowItems();

            //定义action
            //Action<Object> action = o => Console.WriteLine(o.GetType());
            //Console.WriteLine("吞噬NullReferenceException的调用");
            //action.InvokeAndCatch<NullReferenceException>(null);
            //Console.WriteLine("普通调用，抛出NullReferenceException");
            //action.Invoke(null);

            //创建一个Action委托（实例）来引用静态ShowItems扩展方法，
            //并初始化第一个实参来引用字符串“Jeff”
            Action a = "Jeff".ShowItems;
            //调用（Invoke）委托，
            //后者调用（call）ShowItems，并向它传递字符串“Jeff”的引用。
            a();
            Console.ReadKey();
        }
    }
}
