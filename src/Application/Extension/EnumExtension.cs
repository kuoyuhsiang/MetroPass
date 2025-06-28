using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MetroPass.Application.Extension
{
    public static class EnumExtension
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                        .GetField(enumValue.ToString())
                        ?.GetCustomAttribute<DisplayAttribute>()
                        ?.Name
               ?? enumValue.ToString();
        }
    }
}