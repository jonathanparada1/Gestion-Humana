using ActivosChevy.Models;
using Logica;
using Dominio.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActivosChevy.Controllers
{
    public class TecnologiaController : Controller
    {
        //
        // GET: /Tecnologia/

        public ActionResult Index()
        {
            var model = new TecnologiaModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string FormatoUsuario)
        {
            var model = new TecnologiaModel();
            Encriptacion DesEncriptar = new Encriptacion();

            if (Session["usuario"] == null)
            {
                if (FormatoUsuario == null || FormatoUsuario.Equals(""))
                {
                    model.estado = false;
                }
                else
                {
                    ////Servidor
                    //model.estado = true;
                    //model.user = DesEncriptar.Descifrar(FormatoUsuario.ToString().Replace(' ', '+'));

                    //Local
                    model.estado = true;
                    model.user = FormatoUsuario;
                    Usuario.UsuarioSession = model.user;
                }
                }
            else
            {
                model.estado = true;
                model.user = Session["usuario"].ToString();

            }

            return View(model);
        }

    }

}
