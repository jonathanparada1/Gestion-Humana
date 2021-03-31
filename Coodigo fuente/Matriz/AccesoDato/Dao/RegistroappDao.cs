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
  public class RegistroappDao : ConBase, IGestionRegistroapp <Registroapp>
       {

      public static IList<Registroapp> LeerReader(IDataReader reader)
      { 
        IList<Registroapp> lista = new List<Registroapp>();
            while (reader.Read())
            {
                var reg = new Registroapp();
                reg.AREA_P = GetString(reader, "NOMBRE_AREA");
                reg.ID_AREA = GetString(reader, "ID_AREA");
                reg.APLICACION = GetString(reader, "NOMBRE_APP");
                reg.ID_APLICACION = GetString(reader, "ID_APLICACION");
           
                lista.Add(reg);
            }
            return lista;
        }


      public long Crear(Registroapp Obj)
      {
          long id;
          Database db = CreateDatabase();

          using (DbCommand cmd = db.GetStoredProcCommand("SP_LogicaTraslado"))
          {

              db.AddInParameter(cmd, "NOMBRE", DbType.String, Obj.AREA_P);
              db.AddInParameter(cmd, "ID_AREA", DbType.String, Obj.ID_AREA);
              db.AddInParameter(cmd, "ESTADO", DbType.String, Obj.ESTADO);
          


              using (IDataReader reader = db.ExecuteReader(cmd))
              {
                  if (reader.Read())
                      id = GetInt32FromDecimal(reader, "ID");
                  else
                      throw new InvalidOperationException("No se recibió el ID");
              }
          }

          return id;
      }

      public IList<Registroapp> Consultar(Registroapp Obj)
      {
          IList<Registroapp> lista;
          Database db = CreateDatabase();
          using (DbCommand cmd = db.GetStoredProcCommand("SP_Selecapp"))
          {
              db.AddInParameter(cmd, "AREA", DbType.String, Obj.AREA_P);

              using (IDataReader reader = db.ExecuteReader(cmd))
              {
                  lista = LeerReader(reader);
              }
          }
          return lista;
      }

        public IList<Registroapp> ConsultarE(Registroapp Obj)
        {
            throw new NotImplementedException();
        }
    }
    }

