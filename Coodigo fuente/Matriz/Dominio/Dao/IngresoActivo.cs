using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dao
{
    public partial class IngresoActivo
    {
        public long CEDULA { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string CARGO { get; set; }
        public string AREA { get; set; }
        public string T_CONTRATO { get; set; }
        public string ROL { get; set; }
        public string C_OFICINA { get; set; }
        public DateTime FECHA { get; set; }
        public string OBSERVACIONES { get; set; }
        public long CEDULA_J { get; set; }
        public string NOMBRES_J { get; set; }
        public string APELLIDOS_J { get; set; }
        public string CARGO_J { get; set; }
        public string AREA_J { get; set; }
        public DateTime FECHA_J { get; set; }
        public long CEDULA_JEFE { get; set; }
        public string USER_LOG { get; set; }
        public long CEDULA_US { get; set; }
        public string ID_APLICACION { get; set; }
        public string USER { get; set; }
        public string CORREO { get; set; }

    }
}
