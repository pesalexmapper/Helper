using System;
using System.Text.RegularExpressions;

namespace PELEXMapper
{
    /// <summary>
    /// Gadget of string (this is a extension)
    /// </summary>
    public static class StringUtil
    {
        /// <summary>
        /// Returns null or text without side spaces
        /// </summary>
        /// <param name="value">any value</param>
        /// <returns>Valor tratado pelo métodoa trim, se for diferente de nulo</returns>
        public static string TrimNull(this string value)
        {
            String response = null;
            if (!string.IsNullOrWhiteSpace(value))
                response = value.Trim();
            return response;
        }

        /// <summary>
        /// Remove spaces within the text and return in tiny
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Tyne(this string value)
        {
            String response = null;
            if (!String.IsNullOrEmpty(value))
                response = value.Replace(" ", "").ToLower();
            return response;
        }

        /// <summary>
        /// Removes parentheses from text
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Obsolete("RemoveSpecialChars")]
        public static string WithoutParentheses(this string value)
        {
            string response = null;
            if (!string.IsNullOrEmpty(value))
                response = value.Replace("(", "").Replace(")", "");
            return response;
        }

        /// <summary>
        /// Remove special char from text
        /// </summary>
        /// <param name="value">text</param>
        /// <param name="specials">special characters</param>
        /// <returns></returns>
        public static string RemoveSpecialChars(this string value, params string[] specials)
        {
            string response = value;
            if (!string.IsNullOrEmpty(response))
                foreach (var item in specials)
                    response = response.Replace(item, string.Empty);
            return response;
        }

        /// <summary>
        /// Remove all special characters of string
        /// </summary>
        /// <param name="value">text</param>
        /// <returns></returns>
        public static string Alphanumeric(this string value)
        {
            string response = null;
            if (!string.IsNullOrEmpty(value))
                response = Regex.Replace(value, "[^a-zA-Z0-9]+", "", RegexOptions.Compiled);
            return response;
        }

        /// <summary>
        /// Return only letters
        /// </summary>
        /// <param name="value">text</param>
        /// <returns></returns>
        public static string Alphabetic(this string value)
        {
            string response = null;
            if (!string.IsNullOrEmpty(value))
                response = Regex.Replace(value, "[^a-zA-Z]+", "", RegexOptions.Compiled);
            return response;
        }

        /// <summary>
        /// Returns only numerics
        /// </summary>
        /// <param name="value">text</param>
        /// <returns></returns>
        public static string Numerics(this string value)
        {
            string response = null;
            if (!string.IsNullOrEmpty(value))
                response = Regex.Replace(value, "[^0-9]+", "", RegexOptions.Compiled);
            return response;
        }

        /// <summary>
        /// Capitalize sentence
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Capitalize(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            var info = new System.Globalization.CultureInfo("en-US", false).TextInfo;
            var response = info.ToTitleCase(value);
            return response.ToString();
        }

        /// <summary>
        /// Capitalize first letter in text
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string CapitalizeFirst(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            var response = new System.Text.StringBuilder();
            var info = new System.Globalization.CultureInfo("en-US", false).TextInfo;
            foreach (var item in value.Split(' '))
                if (response.Length == 0)
                    response.Append(info.ToTitleCase(item));
                else
                    response.Append($" {item}");
            return response.ToString();
        }

    }
}
