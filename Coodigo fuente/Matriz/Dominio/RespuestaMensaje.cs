using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class RespuestaMensaje
    {
        private List<string> mensajes = new List<string>();

        public bool Ok
        {
            get
            {
                return mensajes.Count == 0;
            }
        }

        public string Mensaje
        {
            get
            {
                return string.Join<string>("\n- ", mensajes);
            }
        }

        public void Agregar(string mensaje)
        {
            mensajes.Add(mensaje);
        }

        public void Agregar(string mensaje, params object[] args)
        {
            mensajes.Add(string.Format(mensaje, args));
        }

        public void Agregar(RespuestaMensaje mensaje)
        {
            mensajes.AddRange(mensaje.mensajes);
        }
    }
}
