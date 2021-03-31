using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrato
{
    public interface IGestionReporte<T>
    {
        IList<T> ConsultarPor(T Obj);
    }
}
