using Dominio.Dao;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ActivosChevy.Controllers
{
    public class ActivoActualApiController : ApiController
    {

        [ActionName("Consultar")]
        public IList<ActivoActual> Consultar(ActivoActual ObjVista)
        {
            try
            {
                return new ActivoActualLogica().Consultar(ObjVista);
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
