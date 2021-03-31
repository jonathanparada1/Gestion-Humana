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
    public class ReporteDao : ConBase, IGestionReporte<Reporte>
    {
        public static IList<Reporte> LeerReader(IDataReader reader)
        {
            IList<Reporte> lista = new List<Reporte>();
            while (reader.Read())
            {
                var reg = new Reporte();
                reg.IdActivo = GetInt32(reader, "ID_ACTIVO");
                reg.Placa = GetString(reader, "PLACA");
                reg.Serial = GetString(reader, "SERIAL");
                reg.Categoria = GetString(reader, "CATEGORIA");
                reg.Detalle = GetString(reader, "DETALLE");
                reg.Factura = GetString(reader, "FACTURA");
                reg.Proveedor = GetString(reader, "PROVEEDOR");
                reg.Poliza = GetString(reader, "POLIZA");
                reg.Identificacion = GetString(reader, "IDENTIFICACION");
                reg.Nombre = GetString(reader, "NOMBRE");
                reg.Ubicacion = GetString(reader, "UBICACION");
                reg.Area = GetString(reader, "AREA");
                reg.Cargo = GetString(reader, "CARGO");
                reg.Fecha = GetDateTimeNull(reader, "FECHA");
                reg.Estado = GetString(reader, "ESTADO");
                reg.ActaEntrega = GetString(reader, "ACTA_ENTREGA");

                
                lista.Add(reg);
            }
            return lista;
        }

        public IList<Reporte> ConsultarPor(Reporte Obj)
        {
            IList<Reporte> lista;
            Database db = CreateDatabase();
            using (DbCommand cmd = db.GetStoredProcCommand("SP_ReporteHistorico"))
            {
                db.AddInParameter(cmd, "IDENTIFICACION", DbType.String, Obj.Identificacion);
                db.AddInParameter(cmd, "PLACA", DbType.String, Obj.Placa);

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    lista = LeerReader(reader);
                }
            }
            return lista;
        }
    }
}
