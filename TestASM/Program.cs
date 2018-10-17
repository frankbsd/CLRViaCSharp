using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestASM
{
    public sealed class Employee
    {
        public String Name { get; set; }
        public Int32 Age;
        private String Id;
        internal String Nick;
        protected String Test;  //警告 CS0628	“Employee.Test”: 在密封类中声明了新的保护成员

    }
    class Program
    {
        static void Main()
        {
            String s = new Employee { Name = "Frank", Age = 5, Nick = "nick" }.ToString().ToUpper();

        }
    }


}
