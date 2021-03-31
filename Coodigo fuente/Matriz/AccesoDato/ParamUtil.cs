using System;
using System.Globalization;
namespace AccesoDato
{
    /// <summary>
    /// Métodos utilitarios para la validación de parámetros a los métodos
    /// </summary>
    public static class ParamUtil
    {
        /// <summary>
        /// Utilidad para verificar que los valores recibidos por los métodos no sean null
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="parametro"></param>
        public static void IsNotNull(object valor, string parametro)
        {
            if (valor == null)
            {
                throw new ArgumentNullException("valor", string.Format(CultureInfo.CurrentCulture, "Se recibió el valor null en el parámetro " + parametro));
            }
        }

        /// <summary>
        /// Sobrecarga para validar que las cadenas no lleguen vacías tampoco.
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="parametro"></param>
        public static void IsNotNullOrEmpty(string valor, string parametro)
        {
            IsNotNull(valor, parametro);
            if (string.IsNullOrEmpty(valor))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Se recibió una cadena vacía en el parámetro requerido {0}.", parametro), "valor");
            }
        }
    }
}

