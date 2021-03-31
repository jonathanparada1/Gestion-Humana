using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dao
{
    public class Traslado
    {
        public int CEDULA { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string CARGO { get; set; }
        public string AREA { get; set; }
        public string T_CONTRATO { get; set; }
        public string C_OFICINA { get; set; }
        public DateTime FECHA { get; set; }
        public string PROCEDIMIENTO { get; set; }
        public string USUARIO { get; set; }
        public string NOMBRECOMPLETO { get; set; }
    }

    public class TrasladoExistente
    {
        public int CEDULA { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string CARGO { get; set; }
        public string AREA { get; set; }
        public string T_CONTRATO { get; set; }
        public string C_OFICINA { get; set; }
        public DateTime FECHA { get; set; }
        public string PROCEDIMIENTO { get; set; }
        public string USUARIO { get; set; }
        public string NOMBRECOMPLETO { get; set; }
    }
}
