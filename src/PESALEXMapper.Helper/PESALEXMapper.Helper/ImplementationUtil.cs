using System;

namespace PELEXMapper
{
    /// <summary>
    /// Implementation helper
    /// </summary>
    public static class ImplementationUtil
    {
        /// <summary>
        /// Verify that the interface is being implemented
        /// </summary>
        /// <param name="type">implementation</param>
        /// <param name="interfaceName">interface</param>
        /// <returns></returns>
        public static bool ContainsInterface(Type type, string interfaceName)
        {
            return type.GetInterface(interfaceName) != null;
        }

        /// <summary>
        /// Checks if the property exists
        /// </summary>
        /// <param name="type">implementation</param>
        /// <param name="propertyName">property</param>
        /// 
        /// <returns></returns>
        public static bool ContainsProperty(Type type, string propertyName)
        {
            return type.GetProperty(propertyName) != null;
        }


    }
}
