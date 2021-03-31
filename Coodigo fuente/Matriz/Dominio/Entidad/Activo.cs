using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad
{
    public partial class Activo
    {
        public int IdActivo { get; set; }
        public string Placa { get; set; }
        public string Serial { get; set; }
        public int Estado { get; set; }
        public int Categoria { get; set; }
        public string Detalle { get; set; }
        public string Factura { get; set; }
        public string Proveedor { get; set; }
        public string ActaEntrega { get; set; }
        public string poliza { get; set; }
        public bool _Activo { get; set; }

    }
}
