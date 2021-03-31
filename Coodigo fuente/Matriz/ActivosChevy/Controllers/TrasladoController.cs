using ActivosChevy.Models;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActivosChevy.Controllers
{
    public class TrasladoController : Controller
    {
        //
        // GET: /Traslado/

        public ActionResult Index()
        {
            var model = new TrasladoModel();
            var datos = new GestionListadoLogica().Consultar(new Dominio.Entidad.Listado());
            model.Estado = datos.Where(x => x.Tipo.Equals(2)).ToList();
            model.Area = datos.Where(x => x.Tipo.Equals(3)).ToList();
            

            return View(model);
        }

    }
}
