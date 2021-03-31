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
    public class TecnologiaDao : ConBase, IGestionTecnologia<Tecnologia>
          {
              public static IList<Tecnologia> LeerReader(IDataReader reader)
              {
                  IList<Tecnologia> lista = new List<Tecnologia>();
                  while (reader.Read())
                  {
                      var reg = new Tecnologia();
                      reg.CEDULA = GetInt32(reader, "CEDULA");
                      lista.Add(reg);
                  }
                  return lista;
              }

              public bool ValidarCedulatec(string cedula)
              {
                  Database db = CreateDatabase();
                  try
                  {
                      using (DbCommand cmd = db.GetStoredProcCommand("SP_ValidarCedulaTec"))
                      {
                          db.AddInParameter(cmd, "CEDULA", DbType.String, cedula);
                          using (IDataReader reader = db.ExecuteReader(cmd))
                          {
                              return reader.Read();

                          }
                      }
                  }
                  catch (Exception ex)
                  {
                      return true;
                  }
              }

              public long Crear(Tecnologia reg)
              {
                  long id;
                  Database db = CreateDatabase();

                  using (DbCommand cmd = db.GetStoredProcCommand("SP_LogicaTecnologia"))
                  {
                      db.AddInParameter(cmd, "CEDULA", DbType.String, reg.CEDULA);
                      db.AddInParameter(cmd, "NOMBRES", DbType.String, reg.USUARIO);
                      db.AddInParameter(cmd, "CORREO", DbType.String, reg.CORREO);
                      db.AddInParameter(cmd, "USUARIO", DbType.String, reg.NOMBRES);
                      db.AddInParameter(cmd, "USUSICO1", DbType.String, reg.USUSICO1);
                      db.AddInParameter(cmd, "USUSICO2", DbType.String, reg.USUSICO2);
                      db.AddInParameter(cmd, "CLAVE", DbType.String, reg.CLAVE);
                      db.AddInParameter(cmd, "CLAVSICO1", DbType.String, reg.CLAVSICO1);
                      db.AddInParameter(cmd, "CLAVSICO2", DbType.String, reg.CLAVSICO2);
                      db.AddInParameter(cmd, "FECHA_TEC", DbType.DateTime, reg.FECHA);
                      db.AddInParameter(cmd, "OBSERVACIONES", DbType.String, reg.OBSERVACIONES);
                      db.AddInParameter(cmd, "REG_USUARIO", DbType.String, reg.USERLOG);

                      using (IDataReader reader = db.ExecuteReader(cmd))
                      {
                          if (reader.Read())
                              id = Convert.ToInt64(GetString(reader, "ID"));
                          else
                              throw new InvalidOperationException("No se recibió el ID");
                      }

                  }

                  return id;
              }

              public IList<Tecnologia> Consultar(Tecnologia Obj)
              {
                  throw new NotImplementedException();
              }
        public IList<Tecnologia> ConsultarE(Tecnologia Obj)
        {
            throw new NotImplementedException();
        }
    }
}