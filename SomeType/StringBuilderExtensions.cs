using System;
using System.Collections.Generic;
using System.Text;

namespace SomeType
{
    static class StringBuilderExtensions
    {
        public static Int32 IndexOf(this StringBuilder sb, Char value)
        {
            if (sb == null)
                throw new NullReferenceException();
            for (Int32 i = 0; i < sb.Length; i++)
                if (sb[i] == value) return i;
            return -1;
        }

        public static void ShowItems<T>(this IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        public static void InvokeAndCatch<TException>(this Action<Object> d, Object o)
            where TException : Exception
        {
            try
            {
                d(o);
            }
            catch (TException)
            {

            }
        }

    }

    //static class StringBuilderExtensions2
    //{
    //    public static Int32 IndexOf(this StringBuilder sb, Char value)
    //    {
    //        for (Int32 i = 0; i < sb.Length; i++)
    //            if (sb[i] == value) return i;
    //        return -1;
    //    }
    //}

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly)]
    public sealed class ExtensionAttribute : Attribute
    {

    }



    //工具生成的代码，存储在某个源代码文件中
    internal class Base
    {

        private String name;

        public String Name
        {
            get { return name; }
            set
            {
                OnNameChanging(value.ToUpper());    //告诉类要进行更改了
                name = value;                       //更改字段
            }
        }

        //在更改name字段前调用
        protected virtual void OnNameChanging(String value)
        {
        }
    }

    //开发人员生成的代码，存储在另一个源代码文件中
    internal class Derived : Base
    {
        protected override void OnNameChanging(string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException("value");
        }
    }


}

namespace MyNamespace
{
    //工具生成的代码，存储在某个源文件中
    internal sealed partial class Base
    {
        private String name;

        public String MyProperty
        {
            get { return name; }
            set
            {
                OnNameChanging(value);  //通知类要进行更改了
                name = value;           //更改字段
            }
        }

        //这是分部方法的声明
        partial void OnNameChanging(String value);
    }

    //开发人员生成的代码，存储在另一个源代码文件中
    internal sealed partial class Base
    {
        //这是分部方法的实现，会在name更改前调用
        //partial void OnNameChanging(string value)
        //{
        //    if (String.IsNullOrEmpty(value))
        //        throw new NullReferenceException("value");
        //}

    }
}
