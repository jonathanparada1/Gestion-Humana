using System;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;
using System.Globalization;
namespace AccesoDato
{
    public abstract class DaoProviderBase
    {
        public string ConnectionStringName
        {
            get;
            private set;
        }

        protected string ConnectionString
        {
            get;
            private set;
        }

        protected DaoProviderBase(string connectionStringName, string tokenParametro)
        {
            this.ConnectionStringName = connectionStringName;
            this.TokenParametro = tokenParametro;
            CalcularConnectionString();
        }

        public abstract Database CreateDatabase();

        public string TokenParametro
        {
            get;
            protected set;
        }

        private void CalcularConnectionString()
        {
            if (!string.IsNullOrEmpty(this.ConnectionStringName))
            {
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[this.ConnectionStringName];
                if (settings == null)
                {
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture,
                                                                "No existe el connectionString '{0}' en el config de la aplicación",
                                                                this.ConnectionStringName));
                }
                this.ConnectionString = settings.ConnectionString;
            }
            else
            {
                this.ConnectionString = string.Empty;
            }
        }
    }
}

