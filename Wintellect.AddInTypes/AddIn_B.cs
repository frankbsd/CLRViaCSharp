using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.HostSDK;

namespace Wintellect.AddInTypes
{
    public sealed class AddIn_B : IAddIn
    {
        public AddIn_B() { }

        public string DoSomething(int x)
        {
            return "AddIn_B:" + x.ToString();
        }
    }
}
