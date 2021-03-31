using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dao
{
    public partial class Listado
    {
        public int IdListado { get; set; }
        public string Nombre { get; set; }
        public int Tipo { get; set; }
        public bool Activo { get; set; }

        public string pUsuario { get; set; }
    }
}