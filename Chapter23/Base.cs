using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Chapter23
{
    [Serializable]
    internal class Base
    {
        protected string m_name = "Jeff";
        public Base()
        {
            /*Make the type instantiable */
        }

        internal class Derived : Base, ISerializable
        {
            private DateTime m_date = DateTime.Now;
            public Derived()
            {
                /*make the type instantiable*/
            }

            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            private Derived(SerializationInfo info, StreamingContext context)
            {
                Type baseType = this.GetType().BaseType;
                MemberInfo[] mi = FormatterServices.GetSerializableMembers(baseType, context);
                for (int i = 0; i < mi.Length; i++)
                {
                    FieldInfo field = (FieldInfo)mi[i];
                    field.SetValue(this, info.GetValue(baseType.FullName + "+" + field.Name, field.FieldType));
                }

                m_date = info.GetDateTime("Date");
            }

            [SecurityPermission(SecurityAction.Demand,SerializationFormatter =true)]
            public virtual void GetObjectData(SerializationInfo info,StreamingContext context)
            {
                info.AddValue("Date", m_date);
                Type baseType = this.GetType().BaseType;
                MemberInfo[] mi = FormatterServices.GetSerializableMembers(baseType, context);

                for (int i = 0; i < mi.Length; i++)
                {
                    info.AddValue(baseType.FullName + "+" + mi[i].Name,((FieldInfo)mi[i]).GetValue(this));
                }
            }

            public override string ToString()
            {
                return string.Format("Name={0}, Date={1}", m_name, m_date);
            }
        }
    }
}
