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
    public class TrasladoDao : ConBase, IGestionTraslado<Traslado>
    {
        Gestion usua = new Gestion();


        public IList<Traslado> Consultar(Traslado Obj)
        {
            IList<Traslado> lista;
            Database db = CreateDatabase();
            using (DbCommand cmd = db.GetStoredProcCommand(Obj.PROCEDIMIENTO))
            {

                if (Obj.PROCEDIMIENTO == "SP_ConsultaKactus")

                {
                    Obj.USUARIO = Usuario.UsuarioSession;
                    db.AddInParameter(cmd, "@CEDULA", DbType.String, Obj.CEDULA);
                }
                else
                {
                    Obj.USUARIO = Usuario.UsuarioSession;
                    db.AddInParameter(cmd, "box_mail", DbType.String, Obj.USUARIO);
                }

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    lista = LeerReader2(reader);
                }
            }
            return lista;
        }
        public static IList<Traslado> LeerReader2(IDataReader reader)
        {
            IList<Traslado> lista = new List<Traslado>();
            while (reader.Read())
            {
                var reg = new Traslado();
                reg.CEDULA = Convert.ToInt32(GetDecimal(reader, "CEDULA"));
                reg.NOMBRES = GetString(reader, "NOMBRES");
                reg.APELLIDOS = GetString(reader, "APELLIDOS");
                reg.CARGO = GetString(reader, "CARGO");
                reg.AREA = GetString(reader, "AREA");
                reg.T_CONTRATO = GetString(reader, "TIPO");
                reg.C_OFICINA = GetString(reader, "C_OFICINA");

                lista.Add(reg);
            }
            return lista;
        }


        //Existente
        public static IList<Traslado> LeerReader(IDataReader reader)
        {
            IList<Traslado> lista = new List<Traslado>();
            while (reader.Read())
            {
                var reg = new Traslado();
                reg.CEDULA = Convert.ToInt32(GetString(reader, "CEDULA"));
                reg.NOMBRECOMPLETO = GetString(reader, "NOMBRECOMPLETO");

                lista.Add(reg);
            }
            return lista;
        }


        //Existente
        IList<Traslado> IGenerico<Traslado>.ConsultarE(Traslado Obj)
        {
            IList<Traslado> lista;
            Database db = CreateDatabase();
            using (DbCommand cmd = db.GetStoredProcCommand(Obj.PROCEDIMIENTO))
            {

                if (Obj.PROCEDIMIENTO == "SP_ConsultaExistente")

                {
                    Obj.USUARIO = Usuario.UsuarioSession;
                    db.AddInParameter(cmd, "@CEDULA", DbType.Int64, Obj.CEDULA);
                }
                else
                {
                    Obj.USUARIO = Usuario.UsuarioSession;
                    db.AddInParameter(cmd, "box_mail", DbType.String, Obj.USUARIO);
                }

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    lista = LeerReader(reader);
                }
            }
            return lista;
        }

        public long Crear(Traslado Obj)
        {
            long id;
            Database db = CreateDatabase();

            using (DbCommand cmd = db.GetStoredProcCommand("SP_LogicaTraslado"))
            {
                db.AddInParameter(cmd, "CEDULA", DbType.String, Obj.CEDULA);
                db.AddInParameter(cmd, "NOMBRES", DbType.String, Obj.NOMBRES);
                db.AddInParameter(cmd, "APELLIDOS", DbType.String, Obj.APELLIDOS);
                db.AddInParameter(cmd, "CARGO", DbType.String, Obj.CARGO);
                db.AddInParameter(cmd, "AREA", DbType.String, Obj.AREA);
                db.AddInParameter(cmd, "T_CONTRATO", DbType.String, Obj.T_CONTRATO);
                db.AddInParameter(cmd, "C_OFICINA", DbType.String, Obj.C_OFICINA);
                db.AddInParameter(cmd, "FECHA", DbType.DateTime, Obj.FECHA);

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

        public IList<IngresoActivo> ConsultarAplicaciones(IngresoActivo Obj)
        {
            IList<IngresoActivo> lista;
            Database db = CreateDatabase();
            Obj.PROCEDIMIENTO = "SP_ConsultaAplicaciones";
            using (DbCommand cmd = db.GetStoredProcCommand(Obj.PROCEDIMIENTO))
            {
                    db.AddInParameter(cmd, "@ID_APLICACION", DbType.String, Obj.ID_APLICACION);

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    lista = LeerReader3(reader);
                }
            }
            return lista;
        }

        public static IList<IngresoActivo> LeerReader3(IDataReader reader)
        {
            IList<IngresoActivo> lista = new List<IngresoActivo>();
            while (reader.Read())
            {
                var reg = new IngresoActivo();

                reg.APLICACION = GetString(reader, "APLICACION");

                lista.Add(reg);
            }
            return lista;
        }
    }
}