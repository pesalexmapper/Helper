﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PESALEXMapper.Helper
{

    /// <summary>
    /// Mapping classes and properties
    /// </summary>
    public static class MapperUtil
    {
        #region IngoreDependencies

        /// <summary>
        /// Ignore dependencies in mapping
        /// </summary>
        /// <typeparam name="S">source type</typeparam>
        /// <typeparam name="D">destine type</typeparam>
        /// <param name="source">source</param>
        /// <param name="destiny">destine</param>
        public static void MapIgnoreDependences<S, D>(S source, D destiny) => Mapper(source, destiny);

        /// <summary>
        /// Ignore dependencies in mapping
        /// </summary>
        /// <typeparam name="S">source type</typeparam>
        /// <typeparam name="D">destine type</typeparam>
        /// <param name="source">source</param>
        /// <returns></returns>
        public static D MapIgnoreDependences<S, D>(S source) => Mapper(source, Activator.CreateInstance<D>());
        
        /// <summary>
        /// Ignore dependencies in mapping
        /// </summary>
        /// <typeparam name="T">destine type</typeparam>
        /// <param name="source">source</param>
        /// <returns></returns>
        public static T MapIgnoreDependences<T>(object source) => Mapper(source, Activator.CreateInstance<T>());

        #endregion

        #region WithDependencies

        /// <summary>
        /// Keep dependencies in mapping
        /// </summary>
        /// <typeparam name="S">source type</typeparam>
        /// <typeparam name="D">destine type</typeparam>
        /// <param name="source">source</param>
        /// <param name="destiny">destine</param>
        public static void MapKeepDependencies<S, D>(S source, D destiny) => Mapper(source, destiny, false);

        /// <summary>
        /// Keep dependencies in mapping
        /// </summary>
        /// <typeparam name="S">source type</typeparam>
        /// <typeparam name="D">destine type</typeparam>
        /// <param name="source">source</param>
        /// <returns></returns>
        public static D MapKeepDependencies<S, D>(S source) => Mapper(source, Activator.CreateInstance<D>(), false);

        /// <summary>
        /// Keep dependencies in mapping
        /// </summary>
        /// <typeparam name="T">destine type</typeparam>
        /// <param name="source">source</param>
        /// <returns></returns>
        public static T MapKeepDependencies<T>(object source) => Mapper(source, Activator.CreateInstance<T>(), false);

        #endregion

        private static T Mapper<T>(object source, T destiny, bool ignoreChildren = true)
        {
            if (source == null) return destiny;
            var type = source.GetType();
            if (type.Equals(typeof(System.Dynamic.ExpandoObject)))
                MapperDynamic(source, destiny, ignoreChildren);
            else
                MapperClass(source, destiny, ignoreChildren);

            return destiny;
        }

        private static void MapperDynamic<T>(object source, T destiny, bool ignoreChildren)
        {
            PropertyInfo temp = null;
            var dictionarySource = (IDictionary<string, object>)source;
            PropertyInfo[] destinies = destiny.GetType().GetProperties();
            for (int i = 0; i < dictionarySource.Keys.Count; i++)
            {
                var value = dictionarySource.Values.ElementAt(i);
                var key = dictionarySource.Keys.ElementAt(i);
                temp = destinies.FirstOrDefault(p => p.Name.Equals(key));
                if (temp == null)
                    continue;

                try
                {
                    if (System.DBNull.Value == value)
                        continue;
                    try
                    {
                        temp.SetValue(destiny, value);
                    }
                    catch (Exception)
                    {
                        temp.SetValue(destiny, Convert.ChangeType(value, temp.GetType()));
                    }

                }
                catch (Exception)
                {

                }

            }

        }

        private static void MapperClass<T>(object source, T destiny, bool ignoreChildren)
        {
            PropertyInfo[] properties = null;
            PropertyInfo temp = null;

            if (ignoreChildren)
            {
                properties = IgnoreChildren(source.GetType());
            }
            else
            {
                properties = source.GetType().GetProperties();
            }

            PropertyInfo[] destinies = destiny.GetType().GetProperties();



            foreach (PropertyInfo property in properties)
            {
                var value = property.GetValue(source);
                temp = destinies.FirstOrDefault(p => p.Name.Equals(property.Name));
                if (temp == null || value == null || System.DBNull.Value == value)
                    continue;
                try
                {
                    try
                    {
                        temp.SetValue(destiny, value);
                    }
                    catch (Exception)
                    {
                        if (!property.PropertyType.Equals(temp.PropertyType) && !temp.PropertyType.FullName.Contains(property.PropertyType.Name))
                            temp.SetValue(destiny, Convert.ChangeType(value, temp.GetType()));
                    }

                }
                catch (InvalidOperationException)
                {
                }
                catch (Exception)
                {
                }

            }
        }

        private static PropertyInfo[] IgnoreChildren(Type source)
        {
            var defaultNamespace = "System";
            string nameSpace = source.Namespace;
            string[] namespaceModel = source.Namespace.Equals(defaultNamespace)
               ? new string[] { "System.Collections.Generic" }
               : new string[] { nameSpace, "System.Collections.Generic" };
            var namespacePrefix = defaultNamespace != nameSpace.Split('.')[0] ? nameSpace.Split('.')[0] : string.Empty;
            var properties = source.GetProperties().Where(x => !namespaceModel.Contains(x.PropertyType.Namespace));
            if (!string.IsNullOrWhiteSpace(namespacePrefix))
                properties = properties.Where(x => !x.PropertyType.Namespace.Contains(namespacePrefix));
            return properties.ToArray();
        }

        /// <summary>
        /// Obtain the distinct properties dynamically (concatenated)
        /// </summary>
        /// <param name="source">data</param>
        /// <returns></returns>
        public static string ConcatCSV<TInput>(object source)
        {
            StringBuilder result = new StringBuilder();
            try
            {
                PropertyInfo temp = null;
                var dictionarySource = (IDictionary<string, object>)source;
                PropertyInfo[] destinies = typeof(TInput).GetProperties();
                for (int i = 0; i < dictionarySource.Keys.Count; i++)
                {
                    var value = dictionarySource.Values.ElementAt(i);
                    var key = dictionarySource.Keys.ElementAt(i);
                    temp = destinies.FirstOrDefault(p => p.Name.Equals(key));
                    if (temp == null)
                    {
                        if (result.Length > 0)
                            result.Append($"-{value}");
                        else
                            result.Append(value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return result.ToString();
        }

        /// <summary>
        /// Concatenate Parameters with Comma Separation
        /// </summary>
        /// <param name="values">any object array to concat</param>
        /// <returns></returns>
        public static string ConcatCSV(params object[] values)
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
        /// Get value on property
        /// </summary>
        /// <typeparam name="T">source type</typeparam>
        /// <param name="obj">source</param>
        /// <param name="keyName">property</param>
        /// <returns></returns>
        public static object GetValue<T>(T obj, string keyName)
            where T : class
        {
            var property = obj.GetType().GetProperty(keyName);
            return property.GetValue(obj);
        }

        /// <summary>
        /// Get value on property
        /// </summary>
        /// <typeparam name="T">source type</typeparam>
        /// <param name="obj">source</param>
        /// <param name="keyName">property</param>
        /// <param name="value">value to apply</param>
        public static void SetValue<T>(T obj, string keyName, object value)
            where T : class
        {
            var property = obj.GetType().GetProperty(keyName);
            property.SetValue(obj, value);
        }
    }

}
