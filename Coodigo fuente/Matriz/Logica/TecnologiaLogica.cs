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
   public class TecnologiaLogica
    {
        private IGestionTecnologia<Tecnologia> generar = new TecnologiaDao();

        public long Generar(Tecnologia Obj)
        {
            return generar.Crear(Obj);
        }

        public bool Consultar(string cedula)
        {
            return new TecnologiaDao().ValidarCedulatec(cedula);
        }


    }
}
