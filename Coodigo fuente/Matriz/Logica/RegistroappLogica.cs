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
    public class RegistroappLogica
    {
        private IGestionRegistroapp<Registroapp> generar = new RegistroappDao();

        public List<Registroapp> Consultar(Registroapp Obj)
        {
            return generar.Consultar(Obj).ToList();
        }
        public long Crear(Registroapp Obj)
        {
            return generar.Crear(Obj);
        }
    }
}
