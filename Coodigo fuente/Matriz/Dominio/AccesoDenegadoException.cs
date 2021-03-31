using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Serializable]
    public class AccesoDenegadoException: Exception
    {
        public AccesoDenegadoException()
            : base()
        {
        }

        public AccesoDenegadoException(string msg, System.Exception innerException)
            : base(msg, innerException)
        {
        }

        public AccesoDenegadoException(string msg)
            : base(msg)
        {
        }

        protected AccesoDenegadoException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public AccesoDenegadoException(string msg, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, msg, args))
        {
        }

        public AccesoDenegadoException(string msg, Exception innerException, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, msg, args), innerException)
        {
        }

        /// <summary>
        /// Implementa la regla de serialización definida por Microsoft en http://msdn.microsoft.com/library/ms182342%28VS.90%29.aspx
        /// La ausencia de este método es reportada por FxCop
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
