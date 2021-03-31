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
    public class ActivoLogica
    {
        private IGenerico<IngresoActivo> generar = new ActivoDao();

        public long Generar(IngresoActivo Obj) {
            return generar.Crear(Obj);
        }
        public bool Consultar(string cedula)
        {
            return new ActivoDao().ValidarCedula(cedula);
        }


    }
}
