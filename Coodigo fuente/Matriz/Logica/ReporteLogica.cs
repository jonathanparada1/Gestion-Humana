using AccesoDato.Dao;
using Contrato;
using Dominio.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ReporteLogica
    {
        private IGestionReporte<Reporte> generar = new ReporteDao();

        public IList<Reporte> Consultar(Reporte Obj) {
            return generar.ConsultarPor(Obj);
        }

    }
}
