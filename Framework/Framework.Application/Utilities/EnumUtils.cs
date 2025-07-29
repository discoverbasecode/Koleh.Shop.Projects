using System;
using System.ComponentModel;
using System.Reflection;

namespace Framework.Application.Utilities
{
    public static class EnumHelper
    {
        public static string ToStringWithSpaces(this Enum e)
        {
            return e.ToString().Replace("_", " ");
        }

        // چک کردن DescriptionAttribute، در صورت نبود جایگزینی _
        public static string ToFriendlyString(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);

            if (name == null)
                return string.Empty;

            var field = type.GetField(name);
            if (field == null)
                return name.Replace("_", " ");

            var attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attr?.Description ?? name.Replace("_", " ");
        }
    }
}
