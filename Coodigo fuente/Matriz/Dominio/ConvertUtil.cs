using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Collections;
namespace Dominio
{
    /// <summary>
    /// Métodos utilitarios para convertir datos del usuario a tipos Nullable o tipos Nativos usando CultureInfo.CurrentCulture.
    /// </summary>
    public static class ConvertUtil
    {
        /// <summary>
        /// Construye el mensaje de la excepción
        /// </summary>
        /// <param name="type">
        /// A <see cref="System.String"/>
        /// </param>
        /// <param name="value">
        /// A <see cref="System.Object"/>
        /// </param>
        /// <returns>
        /// A <see cref="System.String"/>
        /// </returns>
        private static string MensajeInvalidCastException(string type, object value)
        {
            return string.Format(CultureInfo.InvariantCulture, "No es posible convertir '{0}' a {1} usando la cultura {2}.", value, type, CultureInfo.CurrentCulture.Name);
        }

        #region "Int32"
        /// <summary>
        /// Convierte a Int32 usando CultureInfo.CurrentCulture
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt32(string value)
        {
            int resultado;
            if (!int.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out resultado))
            {
                throw new InvalidCastException(MensajeInvalidCastException("int32", value));
            }
            return resultado;
        }

        /// <summary>
        /// Convierte a Int32 usando CultureInfo.CurrentCulture
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt32(object value)
        {
            try
            {
                return Convert.ToInt32(value, CultureInfo.CurrentCulture);
            }
            catch (InvalidCastException ex)
            {
                throw new InvalidCastException(MensajeInvalidCastException("int32", value), ex);
            }
            catch (OverflowException ex)
            {
                throw new OverflowException(MensajeInvalidCastException("int32", value), ex);
            }
        }

        /// <summary>
        /// Convertir enteros usando la cultura actual
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int? ToInt32Null(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            int result;
            if (!int.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out result))
            {
                throw new InvalidCastException(MensajeInvalidCastException("int32", value));
            }
            return result;
        }

        /// <summary>
        /// Convertir enteros usando la cultura actual
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int? ToInt32Null(object value)
        {
            if (value == null)
            {
                return null;
            }
            if (Convert.IsDBNull(value))
            {
                return null;
            }

            return ToInt32(value);
        }

        /// <summary>
        /// Indica si es posible convertir a int32
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInt32(string value)
        {
            int result;
            if (!int.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out result))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Indica si es posible convertir a int32?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInt32Null(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }
            return IsInt32(value);
        }
        #endregion


        #region "Int64"
        /// <summary>
        /// Convierte a Int64 usando CultureInfo.CurrentCulture
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToInt64(string value)
        {
            long resultado;
            if (!long.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out resultado))
            {
                throw new InvalidCastException(MensajeInvalidCastException("long", value));
            }
            return resultado;
        }

        /// <summary>
        /// Convierte a Int64 usando CultureInfo.CurrentCulture
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToInt64(object value)
        {
            try
            {
                return Convert.ToInt64(value, CultureInfo.CurrentCulture);
            }
            catch (InvalidCastException ex)
            {
                throw new InvalidCastException(MensajeInvalidCastException("long", value), ex);
            }
            catch (OverflowException ex)
            {
                throw new OverflowException(MensajeInvalidCastException("long", value), ex);
            }
        }

        /// <summary>
        /// Convertir enteros usando la cultura actual
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long? ToInt64Null(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            long result;
            if (!long.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out result))
            {
                throw new InvalidCastException(MensajeInvalidCastException("long", value));
            }
            return result;
        }

        /// <summary>
        /// Convertir enteros usando la cultura actual
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long? ToInt64Null(object value)
        {
            if (value == null)
            {
                return null;
            }
            if (Convert.IsDBNull(value))
            {
                return null;
            }

            return ToInt64(value);
        }

        /// <summary>
        /// Indica si es posible convertir a long
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInt64(string value)
        {
            long result;
            if (!long.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out result))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Indica si es posible convertir a long?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInt64Null(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }
            return IsInt64(value);
        }
        #endregion


        #region "Double"
        /// <summary>
        /// Convierte a Double usando CultureInfo.CurrentCulture
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ToDouble(string value)
        {
            double resultado;
            if (!double.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out resultado))
            {
                throw new InvalidCastException(MensajeInvalidCastException("Double", value));
            }
            return resultado;
        }

        /// <summary>
        /// Convierte a Double usando CultureInfo.CurrentCulture
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ToDouble(object value)
        {
            try
            {
                return Convert.ToDouble(value, CultureInfo.CurrentCulture);
            }
            catch (InvalidCastException ex)
            {
                throw new InvalidCastException(MensajeInvalidCastException("Double", value), ex);
            }
            catch (OverflowException ex)
            {
                throw new OverflowException(MensajeInvalidCastException("Double", value), ex);
            }
        }

        /// <summary>
        /// Convertir enteros usando la cultura actual
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double? ToDoubleNull(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            double result;
            if (!double.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out result))
            {
                throw new InvalidCastException(MensajeInvalidCastException("Double", value));
            }
            return result;
        }

        /// <summary>
        /// Convertir enteros usando la cultura actual
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double? ToDoubleNull(object value)
        {
            if (value == null)
            {
                return null;
            }
            if (Convert.IsDBNull(value))
            {
                return null;
            }

            return ToDouble(value);
        }

        /// <summary>
        /// Indica si es posible convertir a Double
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDouble(string value)
        {
            double result;
            if (!double.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out result))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Indica si es posible convertir a Double?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDoubleNull(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }
            return IsDouble(value);
        }
        #endregion


        #region "Decimal"
        /// <summary>
        /// Convierte a Decimal usando CultureInfo.CurrentCulture
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ToDecimal(string value)
        {
            decimal resultado;
            if (!decimal.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out resultado))
            {
                throw new InvalidCastException(MensajeInvalidCastException("Decimal", value));
            }
            return resultado;
        }

        /// <summary>
        /// Convierte a Decimal usando CultureInfo.CurrentCulture
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object value)
        {
            try
            {
                return Convert.ToDecimal(value, CultureInfo.CurrentCulture);
            }
            catch (InvalidCastException ex)
            {
                throw new InvalidCastException(MensajeInvalidCastException("Decimal", value), ex);
            }
            catch (OverflowException ex)
            {
                throw new OverflowException(MensajeInvalidCastException("Decimal", value), ex);
            }
        }

        /// <summary>
        /// Convertir enteros usando la cultura actual
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal? ToDecimalNull(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            decimal result;
            if (!decimal.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out result))
            {
                throw new InvalidCastException(MensajeInvalidCastException("Decimal", value));
            }
            return result;
        }

        /// <summary>
        /// Convertir enteros usando la cultura actual
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal? ToDecimalNull(object value)
        {
            if (value == null)
            {
                return null;
            }
            if (Convert.IsDBNull(value))
            {
                return null;
            }

            return ToDecimal(value);
        }

        /// <summary>
        /// Indica si es posible convertir a Decimal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDecimal(string value)
        {
            decimal result;
            if (!decimal.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out result))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Indica si es posible convertir a Decimal?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDecimalNull(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }
            return IsDecimal(value);
        }
        #endregion

        #region "DateTime"

        public static string NombreMes(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }
        /// <summary>
        /// Convierte a DateTime usando CultureInfo.CurrentCulture
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(string value)
        {
            DateTime resultado;
            if (!DateTime.TryParse(value, CultureInfo.CurrentCulture, DateTimeStyles.None, out resultado))
            {
                throw new InvalidCastException(MensajeInvalidCastException("DateTime", value));
            }
            return resultado;
        }

        /// <summary>
        /// Convierte a DateTime usando CultureInfo.CurrentCulture
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(object value)
        {
            try
            {
                return Convert.ToDateTime(value, CultureInfo.CurrentCulture);
            }
            catch (InvalidCastException ex)
            {
                throw new InvalidCastException(MensajeInvalidCastException("DateTime", value), ex);
            }
            catch (OverflowException ex)
            {
                throw new OverflowException(MensajeInvalidCastException("DateTime", value), ex);
            }
        }

        /// <summary>
        /// Convertir enteros usando la cultura actual
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime? ToDateTimeNull(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            DateTime result;
            if (!DateTime.TryParse(value, CultureInfo.CurrentCulture, DateTimeStyles.None, out result))
            {
                throw new InvalidCastException(MensajeInvalidCastException("DateTime", value));
            }
            return result;
        }

        /// <summary>
        /// Convertir enteros usando la cultura actual
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime? ToDateTimeNull(object value)
        {
            if (value == null)
            {
                return null;
            }
            if (Convert.IsDBNull(value))
            {
                return null;
            }

            return ToDateTime(value);
        }

        /// <summary>
        /// Indica si es posible convertir a DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDateTime(string value)
        {
            DateTime result;
            if (!DateTime.TryParse(value, CultureInfo.CurrentCulture, DateTimeStyles.None, out result))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Indica si es posible convertir a DateTime?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDateTimeNull(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }
            return IsDateTime(value);
        }
        #endregion

        #region "Boolean"
        /// <summary>
        /// Convierte a Boolean usando CultureInfo.CurrentCulture
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ToBoolean(string value)
        {
            bool resultado;
            if (!bool.TryParse(value, out resultado))
            {
                throw new InvalidCastException(MensajeInvalidCastException("Boolean", value));
            }
            return resultado;
        }

        /// <summary>
        /// Convierte a Boolean usando CultureInfo.CurrentCulture
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ToBoolean(object value)
        {
            try
            {
                return Convert.ToBoolean(value, CultureInfo.CurrentCulture);
            }
            catch (InvalidCastException ex)
            {
                throw new InvalidCastException(MensajeInvalidCastException("Boolean", value), ex);
            }
            catch (OverflowException ex)
            {
                throw new OverflowException(MensajeInvalidCastException("Boolean", value), ex);
            }
        }

        /// <summary>
        /// Convertir enteros usando la cultura actual
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool? ToBooleanNull(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            bool result;
            if (!bool.TryParse(value, out result))
            {
                throw new InvalidCastException(MensajeInvalidCastException("Boolean", value));
            }
            return result;
        }

        /// <summary>
        /// Convertir enteros usando la cultura actual
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool? ToBooleanNull(object value)
        {
            if (value == null)
            {
                return null;
            }
            if (Convert.IsDBNull(value))
            {
                return null;
            }

            return ToBoolean(value);
        }

        /// <summary>
        /// Indica si es posible convertir a Boolean
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsBoolean(string value)
        {
            bool result;
            if (!bool.TryParse(value, out result))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Indica si es posible convertir a Boolean?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsBooleanNull(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }
            return IsBoolean(value);
        }
        #endregion

        #region "String"
        /// <summary>
        /// Convierte el objeto a cadena
        /// </summary>
        /// <param name="value">
        /// A <see cref="System.Object"/>
        /// </param>
        /// <returns>
        /// A <see cref="System.String"/>
        /// </returns>
        public static string ToString(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            return value.ToString();
        }

        public static string ToString(IEnumerable values)
        {
            if (values == null)
            {
                return string.Empty;
            }
            StringBuilder buffer = new StringBuilder();
            int cont = 0;
            foreach (object value in values)
            {
                buffer.AppendFormat(CultureInfo.CurrentCulture, "{0}:{1}\n", cont, ToStringDepth(value));
                cont++;
            }
            //Quita el último fin de línea
            if (buffer.Length > 0)
            {
                return buffer.ToString(0, buffer.Length - 1);
            }
            else
            {
                return string.Empty;
            }
        }

        public static string ToString(IDictionary map)
        {
            if (map == null)
            {
                return string.Empty;
            }
            StringBuilder buffer = new StringBuilder();
            foreach (DictionaryEntry kvp in map)
            {
                buffer.AppendFormat(CultureInfo.CurrentCulture, "[{0}]={1}\n", kvp.Key, ToStringDepth(kvp.Value));
            }
            //Quita el último fin de línea
            if (buffer.Length > 0)
            {
                return buffer.ToString(0, buffer.Length - 1);
            }
            else
            {
                return string.Empty;
            }
        }

        public static string ToString(DateTime? value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            else
            {
                return ToString(value.Value);
            }
        }




        public static string ToString(DateTime value)
        {
            string formato;
            if (value.TimeOfDay.TotalMilliseconds == 0)
            {
                formato = "{0:d}";
            }
            else
            {
                formato = "{0:G}";
            }
            return string.Format(CultureInfo.CurrentCulture, formato, value);
        }

        public static string ToStringConSeparadorMiles(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            else
            {
                return string.Format(CultureInfo.CurrentCulture, "{0:#,###}", value);
            }
        }
        public static string ToStringFecha(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            else
            {
                string fecha = value.ToString().Substring(0, 4) + "/" + value.ToString().Substring(4, 2) + "/" + value.ToString().Substring(6, 2);
                return fecha;
                //return string.Format(CultureInfo.CurrentCulture, "{yyyy/MM/dd}", value);
            }
        }


        /// <summary>
        /// Convierte el objeto a string y agrega un tabulador después de cada fin de línea para facilitar la lectura
        /// </summary>
        /// <param name="value">
        /// A <see cref="System.Object"/>
        /// </param>
        /// <returns>
        /// A <see cref="System.String"/>
        /// </returns>
        public static string ToStringDepth(object value)
        {
            return ToString(value).Replace("\n", "\n\t");
        }

        public static string ToStringDepth(IEnumerable value)
        {
            return ToString(value).Replace("\n", "\n\t");
        }

        public static string ToStringDepth(IDictionary value)
        {
            return ToString(value).Replace("\n", "\n\t");
        }
        #endregion


    }
}

