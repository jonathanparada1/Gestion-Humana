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
    public class AplicacionLogica
    {
        private IGestionAplicacion<Aplicacion> generar = new AplicacionDao();

        public long Generar(Aplicacion Obj)  {
            return generar.Crear(Obj);
        }
    }
}