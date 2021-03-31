using Contrato;
using Dominio.Entidad;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDato.Dao
{
    public class GestionListadoDao : ConBase, IGestionListado<Listado>
    {

        public static IList<Listado> LeerReader(IDataReader reader)
        {
            IList<Listado> lista = new List<Listado>();
            while (reader.Read())
            {
                var reg = new Listado();
                reg.IdListado = GetInt32(reader, "ID_LISTADO");
                reg.Nombre = GetString(reader, "NOMBRE");
                reg.Tipo = GetInt32(reader, "TIPO");
                reg.Activo = GetBoolean(reader, "ACTIVO");
                lista.Add(reg);
            }
            return lista;
        }

        public long Crear(Listado Obj)
        {
            throw new NotImplementedException();
        }

        public IList<Listado> Consultar(Listado Obj)
        {
            IList<Listado> lista;
            Database db = CreateDatabase();
            using (DbCommand cmd = db.GetStoredProcCommand("SP_SelectListado"))
            {
                db.AddInParameter(cmd, "TIPO", DbType.Int32, Obj.Tipo);

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    lista = LeerReader(reader);
                }
            }
            return lista;
        }

        public IList<Listado> ConsultarE(Listado Obj)
        {
            throw new NotImplementedException();
        }
    }
}
