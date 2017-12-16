namespace Notch.Infrastructure.Extensions
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public static class EnumExtensions
    {
        public static string GetDisplayName<TEnum>(this TEnum value) 
            where TEnum : struct, IConvertible
        {
            var attr = value.GetAttributeOfType<TEnum, DisplayAttribute>();
            return attr == null ? value.ToString() : attr.Name;
        }

        /// <summary>
        /// Gets an attribute on an enum field value
        /// </summary>
        /// <typeparam name="TEnum">The enum type</typeparam>
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
        /// <param name="value">The enum value</param>
        /// <returns>The attribute of type T that exists on the enum value</returns>
        private static T GetAttributeOfType<TEnum, T>(this TEnum value)
            where TEnum : struct, IConvertible
            where T : Attribute
        {

            return value.GetType()
                        .GetMember(value.ToString())
                        .First()
                        .GetCustomAttributes(false)
                        .OfType<T>()
                        .LastOrDefault();
        }
    }
}
