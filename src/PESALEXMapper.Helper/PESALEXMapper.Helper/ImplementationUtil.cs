using System;

namespace PESALEXMapper.Helper
{
    /// <summary>
    /// Auxiliar de implementação
    /// </summary>
    public static class ImplementationUtil
    {
        /// <summary>
        /// Verificar se a interface está sendo implementada
        /// </summary>
        /// <param name="type">implementação</param>
        /// <param name="interfaceName">nome da interface</param>
        /// <returns></returns>
        public static bool ContainsInterface(Type type, string interfaceName)
        {
            return type.GetInterface(interfaceName) != null;
        }

        /// <summary>
        /// Verifica se a propriedade existe
        /// </summary>
        /// <param name="type">implementação</param>
        /// <param name="propertyName">nome da propriedade</param>
        /// 
        /// <returns></returns>
        public static bool ContainsProperty(Type type, string propertyName)
        {
            return type.GetProperty(propertyName) != null;
        }


    }
}
