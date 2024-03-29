using System.ComponentModel;
using System.Reflection;

namespace TestWinForm
{
    public static class EnumExtension
    {
        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            if (attributes != null && attributes.Any()) return attributes.First().Description;

            return value.ToString();
        }
    }
}