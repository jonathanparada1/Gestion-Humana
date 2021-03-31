using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;
using System.Globalization;
using Dominio;

namespace AccesoDato
{
    /// <summary>
    /// Clase Base para derivar los Daos.  Incluye la posibilidad de establecer el connectionStringName
    /// y un método CreateDatabase que resuelve el caso por el que la Enterprise Library falla si se envía un valor null como parámetro
    /// Incluye métodos utilitarios para convertir los datos de IDataReader (Se usa IDataRecord por generalidad).
    /// </summary>
    public class ConBase
    {
        protected IDaoProvider DaoProvider
        {
            get;
            private set;
        }

        public ConBase()
        {
            this.DaoProvider = new GenericDaoProvider();
        }

        public ConBase(string connectionStringName)
        {
            this.DaoProvider = new GenericDaoProvider(connectionStringName);
        }

        public ConBase(IDaoProvider daoProvider)
        {
            this.DaoProvider = daoProvider;
        }

        /// <summary>
        /// Determina el token adecuado para los parámetros al DBMS.
        /// Agrega un espacio después de la cadena de resultado para evitar que al concatenar se mezclen otras cláusulas con el parámetro.
        /// En este caso el servidor SQL reporta que el parámetro es desconocido pero se debe en realidad a un error al concatenar.
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public string Parametro(string nombre)
        {
            ParamUtil.IsNotNullOrEmpty(nombre, "nombre");

            return DaoProvider.TokenParametro + nombre + " ";
        }

        public Database CreateDatabase()
        {
            return DaoProvider.CreateDatabase();
        }

        public static object NullONEmpty(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                return DBNull.Value;
            }
            return valor;
        }

        public static object NullONEmptyString(object valor)
        {
            if (valor == null)
            {
                return DBNull.Value;
            }
            return Convert.ToString(valor);
        }

        public static object FechaFinal(DateTime valor)
        {
            return valor.AddDays(1);
        }

        public static object FechaFinal(DateTime? valor)
        {
            if (valor == null)
            {
                return DBNull.Value;
            }
            return FechaFinal(valor.Value);
        }

        private static string MensajeInvalidCastException(IDataRecord reader, string columna, string tipoEsperado)
        {
            string tipo = reader.GetFieldType(reader.GetOrdinal(columna)).Name;
            return string.Format(CultureInfo.CurrentCulture,
                    "No fue posible convertir el valor de la columna {0} a {1} porque su tipo es {2}.", columna, tipoEsperado, tipo);
        }

        public static string GetString(IDataRecord reader, string columna)
        {
            ParamUtil.IsNotNull(reader, "reader");
            ParamUtil.IsNotNullOrEmpty(columna, "columna");

            int i = reader.GetOrdinal(columna);
            if (reader.IsDBNull(i))
            {
                return string.Empty;
            }
            else
            {
                try
                {
                    return reader.GetString(i);
                }
                catch (InvalidCastException)
                {
                    return ConvertUtil.ToString(reader.GetValue(i));
                    //throw new InvalidCastException(MensajeInvalidCastException(reader, columna, "String"));
                }
            }
        }

        public static int GetInt32(IDataRecord reader, string columna)
        {
            ParamUtil.IsNotNull(reader, "reader");
            ParamUtil.IsNotNullOrEmpty(columna, "columna");

            try
            {
                return reader.GetInt32(reader.GetOrdinal(columna));
            }
            catch (InvalidCastException)
            {
                throw new InvalidCastException(MensajeInvalidCastException(reader, columna, "Int32"));
            }
        }

        public static int GetInt32FromDecimal(IDataRecord reader, string columna)
        {
            ParamUtil.IsNotNull(reader, "reader");
            ParamUtil.IsNotNullOrEmpty(columna, "columna");

            try
            {
                return Decimal.ToInt32(reader.GetDecimal(reader.GetOrdinal(columna)));
            }
            catch (InvalidCastException)
            {
                throw new InvalidCastException(MensajeInvalidCastException(reader, columna, "Int32"));
            }
        }

        public static int? GetInt32Null(IDataRecord reader, string columna)
        {
            ParamUtil.IsNotNull(reader, "reader");
            ParamUtil.IsNotNullOrEmpty(columna, "columna");

            int i = reader.GetOrdinal(columna);
            if (reader.IsDBNull(i))
            {
                return null;
            }
            else
            {
                return reader.GetInt32(i);
            }
        }

        public static long GetInt64(IDataRecord reader, string columna)
        {
            ParamUtil.IsNotNull(reader, "reader");
            ParamUtil.IsNotNullOrEmpty(columna, "columna");

            try
            {
                return reader.GetInt64(reader.GetOrdinal(columna));
            }
            catch (InvalidCastException)
            {
                throw new InvalidCastException(MensajeInvalidCastException(reader, columna, "Int64"));
            }
        }

        public static long? GetInt64Null(IDataRecord reader, string columna)
        {
            ParamUtil.IsNotNull(reader, "reader");
            ParamUtil.IsNotNullOrEmpty(columna, "columna");

            int i = reader.GetOrdinal(columna);
            if (reader.IsDBNull(i))
            {
                return null;
            }
            else
            {
                return reader.GetInt64(i);
            }
        }

        public static double GetDouble(IDataRecord reader, string columna)
        {
            ParamUtil.IsNotNull(reader, "reader");
            ParamUtil.IsNotNullOrEmpty(columna, "columna");

            try
            {
                return reader.GetDouble(reader.GetOrdinal(columna));
            }
            catch (InvalidCastException)
            {
                throw new InvalidCastException(MensajeInvalidCastException(reader, columna, "Double"));
            }
        }

        public static double? GetDoubleNull(IDataRecord reader, string columna)
        {
            ParamUtil.IsNotNull(reader, "reader");
            ParamUtil.IsNotNullOrEmpty(columna, "columna");

            int i = reader.GetOrdinal(columna);
            if (reader.IsDBNull(i))
            {
                return null;
            }
            else
            {
                return reader.GetDouble(i);
            }
        }

        public static decimal GetDecimal(IDataRecord reader, string columna)
        {
            ParamUtil.IsNotNull(reader, "reader");
            ParamUtil.IsNotNullOrEmpty(columna, "columna");

            try
            {
                return reader.GetDecimal(reader.GetOrdinal(columna));
            }
            catch (InvalidCastException)
            {
                throw new InvalidCastException(MensajeInvalidCastException(reader, columna, "Decimal"));
            }
        }

        public static decimal? GetDecimalNull(IDataRecord reader, string columna)
        {
            ParamUtil.IsNotNull(reader, "reader");
            ParamUtil.IsNotNullOrEmpty(columna, "columna");

            int i = reader.GetOrdinal(columna);
            if (reader.IsDBNull(i))
            {
                return null;
            }
            else
            {
                return reader.GetDecimal(i);
            }
        }

        public static Boolean GetBoolean(IDataRecord reader, string columna)
        {
            ParamUtil.IsNotNull(reader, "reader");
            ParamUtil.IsNotNullOrEmpty(columna, "columna");

            try
            {
                return reader.GetBoolean(reader.GetOrdinal(columna));
            }
            catch (InvalidCastException)
            {
                throw new InvalidCastException(MensajeInvalidCastException(reader, columna, "Boolean"));
            }
        }

        public static Boolean? GetBooleanNull(IDataRecord reader, string columna)
        {
            ParamUtil.IsNotNull(reader, "reader");
            ParamUtil.IsNotNullOrEmpty(columna, "columna");

            int i = reader.GetOrdinal(columna);
            if (reader.IsDBNull(i))
            {
                return null;
            }
            else
            {
                return reader.GetBoolean(i);
            }
        }

        public static DateTime GetDateTime(IDataRecord reader, string columna)
        {
            ParamUtil.IsNotNull(reader, "reader");
            ParamUtil.IsNotNullOrEmpty(columna, "columna");

            try
            {
                return reader.GetDateTime(reader.GetOrdinal(columna));
            }
            catch (InvalidCastException)
            {
                throw new InvalidCastException(MensajeInvalidCastException(reader, columna, "DateTime"));
            }
        }

        public static DateTime? GetDateTimeNull(IDataRecord reader, string columna)
        {
            ParamUtil.IsNotNull(reader, "reader");
            ParamUtil.IsNotNullOrEmpty(columna, "columna");

            int i = reader.GetOrdinal(columna);
            if (reader.IsDBNull(i))
            {
                return null;
            }
            else
            {
                return reader.GetDateTime(i);
            }
        }

        public static byte[] GetBytes(IDataRecord reader, string columna)
        {
            ParamUtil.IsNotNull(reader, "reader");
            ParamUtil.IsNotNullOrEmpty(columna, "columna");

            int i = reader.GetOrdinal(columna);
            if (reader.IsDBNull(i))
            {
                return null;
            }
            else
            {
                return (byte[])reader.GetValue(i); ;
            }
        }


        public static object LikeUpper(string texto)
        {
            string like;
            if (texto == null)
            {
                like = "%";
            }
            else
            {
                like = '%' + texto.Trim().ToUpperInvariant().Replace(' ', '%') + '%';
            }
            return NullONEmpty(like);
        }
    }
}
