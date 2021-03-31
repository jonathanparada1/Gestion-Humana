using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Respuesta<T> : RespuestaMensaje
    {
        public T Dato
        {
            get;
            set;
        }
    }
}
