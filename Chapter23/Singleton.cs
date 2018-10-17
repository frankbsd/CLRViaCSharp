using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Chapter23
{
    [Serializable]
    public sealed class Singleton:ISerializable
    {
        private static readonly Singleton s_theOneObject = new Singleton();

        public string Name = "Jeff";
        public DateTime Date = DateTime.Now;

        private Singleton() { }

        public static Singleton GetSingleton()
        {
            return s_theOneObject;
        }


        [SecurityPermission(SecurityAction.Demand,SerializationFormatter =true)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.SetType(typeof(SingletonSerializationHelper));
        }


        [Serializable]
        private sealed class SingletonSerializationHelper : IObjectReference
        {
            public object GetRealObject(StreamingContext context)
            {
                return Singleton.GetSingleton();
            }
        }
    }
}
