using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter22
{
    public sealed class MarshalByRefType:MarshalByRefObject
    {
        public MarshalByRefType()
        {
            Console.WriteLine("{0} ctor running in {1}", this.GetType().ToString(), Thread.GetDomain().FriendlyName);
        }

        public void SomeMethod()
        {
            Console.WriteLine("Execute in " + Thread.GetDomain().FriendlyName);
        }

        public MarshalByValType MethodWithReturn()
        {
            Console.WriteLine("Executing in "+Thread.GetDomain().FriendlyName);
            MarshalByValType t = new MarshalByValType();

            return t;
        }

        public NonMarshalableType MethodArgAndReturn(string callingDomainName)
        {
            Console.WriteLine("Calling from '{0}' to '{1}'.",callingDomainName,Thread.GetDomain().FriendlyName);
            NonMarshalableType t = new NonMarshalableType();

            return t;
        }
    }


    [Serializable]
    public sealed class MarshalByValType : Object
    {
        private DateTime m_creationTime = DateTime.Now;

        public MarshalByValType()
        {
            Console.WriteLine("{0} ctor running in {1}, created on {2:D}", this.GetType().ToString(), Thread.GetDomain().FriendlyName, m_creationTime);
        }

        public override string ToString()
        {
            return m_creationTime.ToLongDateString();
        }
    }


    public sealed class NonMarshalableType : Object
    {
        public NonMarshalableType()
        {
            Console.WriteLine("Executing in " + Thread.GetDomain().FriendlyName);
        }
    }
}
