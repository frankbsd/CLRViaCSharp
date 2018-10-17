using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.HostSDK;

namespace Wintellect.AddInTypes
{
    public sealed class AddIn_A:IAddIn
    {
        public AddIn_A() { }

        public string DoSomething(int x)
        {
            return "AddIn_A:" + x.ToString();
        }
    }
}
