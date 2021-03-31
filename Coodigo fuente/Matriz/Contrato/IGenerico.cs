using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrato
{
    public interface IGenerico<T>
    {
        long Crear(T Obj);
        IList<T> Consultar(T Obj);

        IList<T> ConsultarE(T Obj);

    }
}
