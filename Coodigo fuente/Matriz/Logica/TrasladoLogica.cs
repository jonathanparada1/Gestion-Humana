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
    public class TrasladoLogica
    {
        private IGestionTraslado<Traslado> generar = new TrasladoDao();

        public Traslado Consultar(Traslado Obj) {
            return generar.Consultar(Obj).FirstOrDefault();
        }

        public Traslado ConsultarExistente(Traslado Obj)
        {
            return generar.ConsultarE(Obj).FirstOrDefault();
        }

        public long Crear(Traslado Obj)
        {
            return generar.Crear(Obj);
        }
    }
}
