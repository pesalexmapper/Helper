using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PESALEXMapper.Helper
{
    /// <summary>
    /// Gadget of enum
    /// </summary>
    public static class EnumUtil
    {
        /// <summary>
        /// Obtain the description of the member of an enum
        /// </summary>
        /// <param name="member">desired member</param>
        /// <typeparam name="TEnum">enum</typeparam>
        /// <returns></returns>
        public static string GetDescription<TEnum>(string member)
            where TEnum : struct, IConvertible
        {
            var type = typeof(TEnum);
            var memberInfo = type.GetMember(member);
            object[] attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            var description = ((DescriptionAttribute)attributes[0]).Description;
            return description;
        }

        /// <summary>
        /// Obtain the description of an enum
        /// </summary>
        /// <typeparam name="TEnum">enum</typeparam>
        /// <returns></returns>
        public static string GetDescriptionOfType<TEnum>()
            where TEnum : struct, IConvertible
        {
            var type = typeof(TEnum);
            var custonAtributes = type.GetCustomAttributes(typeof(DescriptionAttribute), true);
            string description = ((DescriptionAttribute)custonAtributes[0]).Description;
            return description;
        }

        public static string GetDescription<TEnum>(int value)
            where TEnum : struct, IConvertible
        {
            var type = typeof(TEnum);
            var name = Enum.GetName(type, value);
            var memberInfo = type.GetMember(name);
            object[] attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            string description = ((DescriptionAttribute)attributes[0]).Description;
            return description;
        }

        public static TEnum GetByName<TEnum>(string name) 
            where TEnum : struct, IConvertible
        {
            var type = typeof(TEnum);
            var tmp = (TEnum)Enum.Parse(type, name);
            return tmp;
        }

        public static int GetValue<TEnum>(string description)
            where TEnum : struct, IConvertible
        {
            var type = typeof(TEnum);
            foreach (var name in Enum.GetNames(type))
            {
                var memberInfo = type.GetMember(name);
                object[] attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (((DescriptionAttribute)attributes[0]).Description == description)
                {
                    var tmp = (TEnum)Enum.Parse(type, name);
                    return (int)Convert.ChangeType(tmp, tmp.GetTypeCode());
                }
            }
            return default;
        }

        /// <summary>
        /// Obtain the description list of all members
        /// </summary>
        /// <typeparam name="TEnum">enum</typeparam>
        /// <returns></returns>
       [Obsolete("Use DescriptionArray")]
        public static IList<string> DescriptionList<TEnum>()
            where TEnum : struct, IConvertible
        {
            var result = new List<string>();
            foreach (var value in (TEnum[])Enum.GetValues(typeof(TEnum)))
                result.Add(GetDescription<TEnum>(value.ToString()));
            return result;
        }

        /// <summary>
        /// Obtain the description list of all members
        /// </summary>
        /// <typeparam name="TEnum">enum</typeparam>
        /// <returns></returns>
        public static string[] DescriptionArray<TEnum>()
            where TEnum : struct, IConvertible
        {
            var result = new List<string>();
            foreach (var value in (TEnum[])Enum.GetValues(typeof(TEnum)))
                result.Add(GetDescription<TEnum>(value.ToString()));
            return result.ToArray();
        }

    }
}
