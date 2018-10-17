using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter21
{
    internal sealed class SomeType
    {
        ~SomeType()
        {
            Console.WriteLine("Finalize");
        }
    }
}
