using System;

namespace SomeType
{
    internal sealed class SomeType
    {
        //不要显示初始化下面的字段
        private Int32 m_x;
        private String m_s;
        private Double m_d;
        private Byte m_b;


        //该构造器将所有字段都设为默认值
        //其他所有构造器都显示调用该构造器
        public SomeType()
        {
            m_x = 5;
            m_s = "Hi,there";
            m_d = 3.14159;
            //m_b = 0xff;
        }

       //该构造器将所有字段都设为默认值，然后修改m_x
        public SomeType(Int32 x) : this()
        {
            m_x = x;
        }

        //该构造器将所有字段都设为默认值，然后修改m_s
        public SomeType(String s) : this()
        {
            m_s = s;
        }
    }

}
