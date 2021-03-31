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
    public class RegistroAppApiController : ApiController
    {
        [ActionName("Consultar")]
        public List<Registroapp> Consultar(Registroapp ObjVista)
        {
            try
            {
                return new RegistroappLogica().Consultar(ObjVista);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [ActionName("Crear")]
        public long Crear(Registroapp ObjVista)
        {
            try
            {
                
                return new RegistroappLogica().Crear(ObjVista);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
