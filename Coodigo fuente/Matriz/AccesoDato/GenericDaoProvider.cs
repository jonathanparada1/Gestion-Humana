using System;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace AccesoDato
{
    public class GenericDaoProvider : DaoProviderBase, IDaoProvider
    {
    
        public GenericDaoProvider()
            : base(null, ":")
        {
        }

        public GenericDaoProvider(string connectionStringName)
            : base(connectionStringName, ":")
        {
        }

        public override Database CreateDatabase()
        {
            if (string.IsNullOrEmpty(this.ConnectionStringName))
            {
                return DatabaseFactory.CreateDatabase();
            }
            else
            {
                return DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            }
        }
    }
}
