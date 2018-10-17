using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//告诉编译器检查CLS相容性
[assembly: CLSCompliant(true)]

namespace TestCLS
{
    //因为是public，所以会显示警告(????)
    public sealed class SomeLibrary
    {
        //警告 CS3002	“SomeLibrary.Abc()”的返回类型不符合 CLS
        public UInt32 Abc() { return 0; }

        //警告	CS3005	仅大小写不同的标识符“SomeLibrary.abc()”不符合 CLS	
        public void abc() { }

        //不显示警告，因为该方法是私有的
        private UInt32 ABC() { return 0; }
    }

    sealed class SomeLibrary2
    {
        //警告 CS3002	“SomeLibrary.Abc()”的返回类型不符合 CLS
        public UInt32 Abc() { return 0; }

        //警告	CS3005	仅大小写不同的标识符“SomeLibrary.abc()”不符合 CLS	
        public void abc() { }

        //不显示警告，因为该方法是私有的
        private UInt32 ABC() { return 0; }
    }
}
