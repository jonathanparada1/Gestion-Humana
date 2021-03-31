using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdActivo { get; set; }
        public string Identificacion { get; set; }
        public string NombreUsuario { get; set; }
        public string Ubicacion { get; set; }
        public string Area { get; set; }
        public string Cargo { get; set; }
        public DateTime Fecha { get; set; }

    }
}
