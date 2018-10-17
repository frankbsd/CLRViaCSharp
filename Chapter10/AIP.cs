using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter10
{
    public sealed class AIP
    {
        private String Address; 
      
        public String Test { get; set; }

        private Int32 age;

        public Int32 Age
        {
            get { return age; }
            set { age = value; }
        }

        public AIP()
        {
            Console.WriteLine("AIP constructor");
        }

    }
}
