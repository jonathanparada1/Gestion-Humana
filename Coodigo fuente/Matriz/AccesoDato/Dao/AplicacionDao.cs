using Contrato;
using Dominio.Dao;
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
    public class AplicacionDao : ConBase, IGestionAplicacion<Aplicacion>
    {
        public static IList<Aplicacion> LeerReader(IDataReader reader)
        {
            IList<Aplicacion> lista = new List<Aplicacion>();
            while (reader.Read())
            {

                var reg = new Aplicacion();
                reg.CEDULA = GetInt32(reader, "CEDULA");
                lista.Add(reg);
            }

            return lista;
        }

        public long Crear(Aplicacion reg)
        {
            long id;
            Database db = CreateDatabase();

            using (DbCommand cmd = db.GetStoredProcCommand("SP_LogicaAplicacion"))
            {

                db.AddInParameter(cmd, "CEDULA", DbType.String, reg.CEDULA);
                db.AddInParameter(cmd, "NOMBRES", DbType.String, reg.NOMBRES);
                db.AddInParameter(cmd, "CARGO", DbType.String, reg.CARGO);
                db.AddInParameter(cmd, "AREA", DbType.String, reg.AREA);
                db.AddInParameter(cmd, "FECHA", DbType.DateTime, reg.FECHA);
                db.AddInParameter(cmd, "OBSERVACIONES", DbType.String, reg.OBSERVACIONES);


                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                        id = GetInt32(reader, "ID");
                    else
                        throw new InvalidOperationException("No se recibió el ID");
                }

            }

            return id;
        }
        public IList<Aplicacion> Consultar(Aplicacion Obj)
        {
            IList<Aplicacion> lista;
            Database db = CreateDatabase();
            using (DbCommand cmd = db.GetStoredProcCommand("SP_SelecAplicacion"))
            {
                db.AddInParameter(cmd, "CEDULA", DbType.Int32, Obj.CEDULA);

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    lista = LeerReader(reader);
                }
            }
            return lista;
        }

        public IList<Aplicacion> ConsultarE(Aplicacion Obj)
        {
            throw new NotImplementedException();
        }
    }
}






