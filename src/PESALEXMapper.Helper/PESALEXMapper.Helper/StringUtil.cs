using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PESALEXMapper.Helper
{
    public static class StringUtil
    {
        /// <summary>
        /// Retorna null ou texto sem espaços laterais
        /// </summary>
        /// <param name="value">Qualquer valor de string, inclusive null</param>
        /// <returns>Valor tratado pelo métodoa trim, se for diferente de nulo</returns>
        public static string TrimNull(this System.String value)
        {
            String response = null;
            if (!string.IsNullOrWhiteSpace(value))
                response = value.Trim();
            return response;
        }

        public static string GetDescriptionEnum(string member, Type type)
        {
            string description = string.Empty;

            var memInfo = type.GetMember(member);

            var newInfo = memInfo[0];

            object[] attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            description = ((DescriptionAttribute)attributes[0]).Description;

            return description;
        }
        public static string GetDescriptionEnumName(Type type)
        {
            string description = string.Empty;

            var custonAtributes = type.GetCustomAttributes(typeof(DescriptionAttribute), true);

            description = ((DescriptionAttribute)custonAtributes[0]).Description;

            return description;
        }
        public static List<string> CreateListDescriptionEnum<TEntity>(Type type) where TEntity : struct
        {
            List<string> lstDescription = new List<string>();

            TEntity[] lstValues = (TEntity[])Enum.GetValues(typeof(TEntity));

            for (int i = 0, ii = lstValues.Length; i < ii; i++)
            {
                string descriptionEnum = GetDescriptionEnum(lstValues[i].ToString(), type);

                lstDescription.Add(descriptionEnum);
            }

            return lstDescription;
        }
        /// <summary>
        /// Normalizar nome de  manipulador
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string HandlerNormalized(this System.String value)
        {
            String response = null;
            if (!String.IsNullOrEmpty(value))
                response = value.Replace(" ", "").ToLower();
            return response;
        }

        /// <summary>
        /// Obter id na formatação do sistema
        /// </summary>
        /// <param name="values">values para composição do id em ordem</param>
        /// <returns></returns>
        public static string GetIdFormat(params object[] values)
        {

            var result = new StringBuilder();
            for (int i = 0; i < values.Length; i++)
            {
                if (result.Length > 0)
                    result.Append("-");
                result.Append(values[i]);
            }
            return result.ToString();
        }
        /// <summary>
        /// Retorna texto sem parênteses
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string WithoutParentheses(this string value)
        {
            String response = null;
            if (!String.IsNullOrEmpty(value))
                response = value.Replace("(", "").Replace(")", "");
            return response;
        }
    }
}
