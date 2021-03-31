using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dao
{
    public partial class Reporte
    {
        public int IdActivo { get; set; }
        public string Placa { get; set; }
        public string Serial { get; set; }
        public string Categoria { get; set; }
        public string Detalle { get; set; }
        public string Factura { get; set; }
        public string Proveedor { get; set; }
        public string Poliza { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string Area { get; set; }
        public string Cargo { get; set; }
        public DateTime? Fecha { get; set; }
        public string Estado { get; set; }
        public string ActaEntrega { get; set; }        
        public bool Activo { get; set; }
 
    }
}
