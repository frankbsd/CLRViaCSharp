using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCLS
{
    internal class TestIL
    {
        //构造器
        public TestIL() { }

        //终结器
        ~TestIL() { }

        //操作符重载
        public static Boolean operator ==(TestIL t1, TestIL t2) { return true; }

        public static Boolean operator !=(TestIL t1, TestIL t2) { return false; }

        public static TestIL operator +(TestIL t1, TestIL t2) { return null; }

        //属性
        public String AProperty
        {
            get { return null; }
            set { }
        }

        //索引器
        public String this[Int32 x]
        {
            get { return null; }
            set { }
        }

        //事件
        event EventHandler AnEvent;
    }
}
