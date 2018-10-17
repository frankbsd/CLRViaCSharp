using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter10
{
    class Program
    {


        static void Main()
        {
            Employee e = new Employee();
            //Console.WriteLine(e.Count);
            //Console.WriteLine(e.Count);
            e.Name = "Jeff";
            //Console.WriteLine(e.Count);
        }

    }

    public sealed class Employee
    {
        private String name;
        public Int32 Count { get; set; }

        public String Name
        {
            get
            {
                Count++;
                return name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Name:" + value.ToString(), "名字不可以为空");
                name = value;
            }
        }

    }
}
