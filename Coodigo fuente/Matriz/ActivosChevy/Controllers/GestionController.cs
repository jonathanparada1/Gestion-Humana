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
    public class GestionController : Controller
    {

        
        // GET: /Traslado/

        public ActionResult Index()
        {
            var model = new GestionModels();
            var datos = new GestionListadoLogica().Consultar(new Dominio.Entidad.Listado());
            model.Estado = datos.Where(x => x.Tipo.Equals(2)).ToList();
            model.Area = datos.Where(x => x.Tipo.Equals(3)).ToList();
            model.Area2 = datos.Where(x => x.Tipo.Equals(4)).ToList();


            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string FormatoUsuario)
        {
            var model = new GestionModels();
            var datos = new GestionListadoLogica().Consultar(new Dominio.Entidad.Listado());
            
            model.Estado = datos.Where(x => x.Tipo.Equals(2)).ToList();
            model.Area = datos.Where(x => x.Tipo.Equals(3)).ToList();
            model.Area2 = datos.Where(x => x.Tipo.Equals(4)).ToList();
           
            Encriptacion DesEncriptar = new Encriptacion();
            
            if (Session["usuario"] == null)
            {
                if (FormatoUsuario == null || FormatoUsuario.Equals(""))
                {
                    model.estado = false;
                }
                else
                {

                    //Servidor
                    //model.estado = true;
                    //model.user = DesEncriptar.Descifrar(FormatoUsuario.ToString().Replace(' ', '+'));
                    //Usuario.UsuarioSession = model.user;

                    // Local
                    model.estado = true;
                    model.user = FormatoUsuario;
                    Usuario.UsuarioSession = model.user;
                }
            }
            else
            {
                model.estado = true;
                model.user = Session["usuario"].ToString();
                Usuario.UsuarioSession = FormatoUsuario;
            }

            return View(model);
        }
    
    }

}
