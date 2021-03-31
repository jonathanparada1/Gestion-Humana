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
    public class ReporteApiController : ApiController
    {
        [ActionName("ConsultarHistorico")]
        public IList<Reporte> ConsultarHistorico(Reporte ObjVista)
        {
            try
            {
                return new ReporteLogica().Consultar(ObjVista);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
