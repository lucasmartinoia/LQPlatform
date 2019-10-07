using QuickFix.Fields;
using System;
using System.Linq;
using System.Reflection;

namespace BymaFixTester.WinForm
{
    public static class QFHelper
    {
        public static string GetNameByValue(object Value, Type typeClass)
        {
            string returnValue = "";
            var props = typeClass.GetFields(BindingFlags.Public | BindingFlags.Static);
            MemberInfo memberInfo = props.FirstOrDefault(prop => prop.GetValue(null).Equals(Value));
            if (memberInfo != null)
            {
                returnValue = memberInfo.Name;
            }
            return returnValue;
        }

        public static bool HasEnumValues(string name)
        {
            Type typeParameterType = typeof(Account).Assembly.GetType("QuickFix.Fields." + name);
            var props = typeParameterType.GetFields(BindingFlags.Public | BindingFlags.Static);
            return props.Count() > 0;
        }

        public static string GetTagNameByValue(int Value)
        {
            return GetNameByValue(Value, typeof(Tags));
        }

        public static string GetMsgTypeByValue(string Value)
        {
            return GetNameByValue(Value, typeof(MsgType));
        }

    }
}
