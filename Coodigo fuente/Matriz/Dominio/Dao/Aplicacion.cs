using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dao
{
    public partial class Aplicacion
            {
                public long CEDULA { get; set; }
                public string NOMBRES { get; set; }
                public string CARGO { get; set; }
                public string AREA { get; set; }
                public DateTime FECHA { get; set; }
                public string OBSERVACIONES { get; set; }
          }
}
