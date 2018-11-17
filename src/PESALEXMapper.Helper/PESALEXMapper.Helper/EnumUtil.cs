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
        #region typeparam

        /// <summary>
        /// Obtain the description of the member of an enum
        /// </summary>
        /// <param name="member">desired member</param>
        /// <typeparam name="TEnum">enum</typeparam>
        /// <returns></returns>
        public static string GetDescription<TEnum>(string member)
            where TEnum : struct, IConvertible
        {
            string description = string.Empty;
            var type = typeof(TEnum);
            var memberInfo = type.GetMember(member);
            var newInfo = memberInfo[0];
            object[] attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            description = ((DescriptionAttribute)attributes[0]).Description;
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
            string description = string.Empty;
            var type = typeof(TEnum);
            var custonAtributes = type.GetCustomAttributes(typeof(DescriptionAttribute), true);
            description = ((DescriptionAttribute)custonAtributes[0]).Description;
            return description;
        }

        /// <summary>
        /// Obtain the description list of all members
        /// </summary>
        /// <typeparam name="TEnum">enum</typeparam>
        /// <returns></returns>
        public static ICollection<string> DescriptionList<TEnum>()
            where TEnum : struct, IConvertible
        {
            var result = new List<string>();
            foreach (var value in (TEnum[])Enum.GetValues(typeof(TEnum)))
                result.Add(GetDescription<TEnum>(value.ToString()));
            return result;
        }

        #endregion

    }
}
