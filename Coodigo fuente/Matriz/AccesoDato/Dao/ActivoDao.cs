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
    public class ActivoDao : ConBase, IGenerico<IngresoActivo>
    {


        public static IList<IngresoActivo> LeerReader(IDataReader reader)
        {
            IList<IngresoActivo> lista = new List<IngresoActivo>();
            while (reader.Read())
            {
                var reg = new IngresoActivo();
                reg.CEDULA = GetInt64(reader, "CEDULA");
                reg.CEDULA_J = GetInt64(reader, "CEDULA_J");
                lista.Add(reg);
            }
            return lista;
        }

        public bool ValidarCedula(string cedula)
        {
            Database db = CreateDatabase();
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("SP_ValidarCedula"))
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

        public long Crear(IngresoActivo reg)
        {
            long id;
            Database db = CreateDatabase();

            using (DbCommand cmd = db.GetStoredProcCommand("SP_LogicaActual"))
            {
                db.AddInParameter(cmd, "CEDULA", DbType.String, reg.CEDULA);
                db.AddInParameter(cmd, "NOMBRES", DbType.String, reg.NOMBRES);
                db.AddInParameter(cmd, "APELLIDOS", DbType.String, reg.APELLIDOS);
                db.AddInParameter(cmd, "CARGO", DbType.String, reg.CARGO);
                db.AddInParameter(cmd, "AREA", DbType.String, reg.AREA);
                db.AddInParameter(cmd, "T_CONTRATO", DbType.String, reg.T_CONTRATO);
                db.AddInParameter(cmd, "C_OFICINA", DbType.String, reg.C_OFICINA);
                db.AddInParameter(cmd, "FECHA", DbType.DateTime, reg.FECHA);
                db.AddInParameter(cmd, "OBSERVACIONES", DbType.String, reg.OBSERVACIONES);
                db.AddInParameter(cmd, "CEDULA_J", DbType.String, reg.CEDULA_J);
                db.AddInParameter(cmd, "NOMBRES_J", DbType.String, reg.NOMBRES_J);
                db.AddInParameter(cmd, "APELLIDOS_J", DbType.String, reg.APELLIDOS_J);
                db.AddInParameter(cmd, "CARGO_J", DbType.String, reg.CARGO_J);
                db.AddInParameter(cmd, "AREA_J", DbType.String, reg.AREA_J);
                db.AddInParameter(cmd, "FECHA_J", DbType.DateTime, reg.FECHA_J);
                db.AddInParameter(cmd, "CEDULA_JEFE", DbType.String, reg.CEDULA_JEFE);
                db.AddInParameter(cmd, "USER_LOG", DbType.String, reg.USER);


                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        id = Convert.ToInt64(GetString(reader, "ID"));
                    }
                    else
                    {
                        throw new InvalidOperationException("No se recibió el ID");
                    }
                }

            }
            string[] aplicacion = reg.ID_APLICACION.Split(',');
            for (int i = 0; i < aplicacion.Length; i++)
            {
                using (DbCommand cmd = db.GetStoredProcCommand("SP_LogicaApp"))
                {
                    db.AddInParameter(cmd, "ID_US", DbType.String, id);
                    db.AddInParameter(cmd, "CEDULA_US", DbType.String, reg.CEDULA);
                    db.AddInParameter(cmd, "ID_APLICACION", DbType.String, aplicacion[i]);


                    using (IDataReader reader = db.ExecuteReader(cmd))
                    {
                        if (reader.Read())
                        {
                        }
                        else
                        {
                        }
                    }

                }
            }
            return id;
        }

        public IList<IngresoActivo> Consultar(IngresoActivo Obj)
        {
            throw new NotImplementedException();
        }

        public IList<IngresoActivo> ConsultarE(IngresoActivo Obj)
        {
            throw new NotImplementedException();
        }
    }
}
