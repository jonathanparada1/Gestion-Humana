using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrato
{
    public interface IGestionActivoActual<T>
    {
        IList<T> Consultar(T Obj);
    }
}
