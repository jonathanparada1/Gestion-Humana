using AccesoDato.Dao;
using Contrato;
using Dominio.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class GestionListadoLogica
    {
        private IGestionListado<Listado> generar = new GestionListadoDao();

        public IList<Listado> Consultar(Listado Obj)
        {
            return generar.Consultar(Obj);
        }
    }
}
