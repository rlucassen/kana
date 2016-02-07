using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System;
using System.Collections.Generic;

namespace Kana.Model.Helpers
{
    public static class EnumHelper
    {
        private static Random random = new Random();

        public static T Random<T>()
        {
            var v = System.Enum.GetValues(typeof(T));
            return (T)v.GetValue(random.Next(v.Length));
        }

        public static List<T> EnumToList<T>()
        {
            Type enumType = typeof(T);

            // Can't use type constraints on value types, so have to do check like this
            if (enumType.BaseType != typeof(System.Enum))
                throw new ArgumentException("T must be of type System.Enum");

            Array enumValArray = System.Enum.GetValues(enumType);

            List<T> enumValList = new List<T>(enumValArray.Length);

            foreach (int val in enumValArray)
            {
                enumValList.Add((T)System.Enum.Parse(enumType, val.ToString()));
            }

            return enumValList;
        }

        public static IList ToList(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            ArrayList list = new ArrayList();
            Array enumValues = System.Enum.GetValues(type);

            foreach (System.Enum value in enumValues)
            {
                if (!string.IsNullOrEmpty(value.GetDescription()))
                    list.Add(new { value = value.GetHashCode(), text = value.GetDescription(), name = value });
            }

            return list;
        }

        public static string GetDescription(this object value)
        {
            Type type = value.GetType();
            string name = System.Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }


    }
}