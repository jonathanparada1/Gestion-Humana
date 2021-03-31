using System;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace AccesoDato
{
    public interface IDaoProvider
    {
        Database CreateDatabase();

        string ConnectionStringName
        {
            get;
        }

        string TokenParametro
        {
            get;
        }
    }
}

