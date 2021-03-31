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
    public class TrasladoApiController : ApiController
    {

        [ActionName("Consultar")]
        public Traslado Consultar(Traslado ObjVista)
        {
            try
            {
                return new TrasladoLogica().Consultar(ObjVista);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [ActionName("ConsultarExistente")]
        public Traslado ConsultarExistente(Traslado ObjVista)
        {
            try
            {
                return new TrasladoLogica().ConsultarExistente(ObjVista);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [ActionName("Crear")]
        public long Crear(Traslado ObjVista)
        {
            try
            {
                ObjVista.FECHA = DateTimeOffset.Now.DateTime;
                return new TrasladoLogica().Crear(ObjVista);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
