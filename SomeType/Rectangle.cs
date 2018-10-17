using System;

namespace SomeType
{
    internal struct Point
    {
        public Int32 m_x, m_y;

        //public Point()
        //{
        //    m_x = m_y = 5;
        //}

        //public Int32 z = 5;

        //C#允许为值类型定义有参构造器
        public Point(Int32 x)
        {
            this = new Point();
            m_x = x;
        }
    }
    class Rectangle
    {
        public Point m_topLeft, m_bottomRight;
        public Rectangle()
        {
            //m_topLeft = new Point(1, 2);
            //m_bottomRight = new Point(100, 200);
        }
    }


    internal sealed class SomeRefType
    {
        private static Int32 s_x = 5;
        static SomeRefType()
        {
            //SomeRefType被首次访问时，执行这里的代码
            s_x = 10;
        }
    }

    internal struct SomeValType
    {
        //C#允许值类型定义无参的类型构造器
        static SomeValType()
        {
            Console.WriteLine("这句话永远不会显示");
        }

        public Int32 m_x;
        public static Int32 x = 5;
    }
}
