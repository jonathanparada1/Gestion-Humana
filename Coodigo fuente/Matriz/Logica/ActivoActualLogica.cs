using AccesoDato.Dao;
using Dominio.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ActivoActualLogica
    {
        private readonly Contrato.IGestionActivoActual<ActivoActual> generar = new ActivoActualDao();

        public IList<ActivoActual> Consultar(ActivoActual obj)
        {
            return this.generar.Consultar(obj);
        }
    }
}
