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
    public class AplicacionApiController : ApiController
    {
    [ActionName("Crear")]
        public bool Crear(Aplicacion ObjVista)
        {
            try
            {
                ObjVista.FECHA = DateTimeOffset.Now.DateTime;
                var obj = new AplicacionLogica().Generar(ObjVista);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [ActionName("Consultar")]
        public bool Consultar(Traslado ObjVista)
        {
            try
            {
                if (!string.IsNullOrEmpty(new TrasladoLogica().Consultar(ObjVista).NOMBRES))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
