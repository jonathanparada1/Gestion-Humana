using ActivosChevy.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Web.Security;
using ChevyPlan;


namespace ActivosChevy.Controllers
{
    public class LoginController : ApiController
    {
        // GET api/login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/login
        [HttpPost]
        public List<string> ingresar(LogModel value)
        {
            List<string> res;
            
            string Grupo = null;
          

            try
            {

                Grupo = new ActiveDirectory(ConfigurationManager.AppSettings["UrlDominio"].ToString(), "DC=chevyplan,DC=col").GetAuthorizedGroups("CHEVYPLAN.COL\\" + value.user, value.pass);

               
                if (Grupo != null)
                {
 
                        //Response.Cookies.Add(cookie);
                        //Response.Redirect(FormsAuthentication.GetRedirectUrl(Login1.UserName, false));
                        res = new List<string>();
                        res.Add("sdfsdfsdfsdfsdfsdffsad");
                        res.Add("asfsdfsdfsdfsdfdssdfsdf");
                        res.Add(Grupo);
                        return res;
                                    }
                else
                {
                    //lblError.Text = "Autenticación errada. Verifique Usuario y Clave";
                    res = new List<string>();
                    res.Add("");
                    res.Add("Autenticación errada. Verifique Usuario y Clave");
                    res.Add("Fail");
                    return res;
                }
            }
            catch (Exception ex)
            {
                //lblError.Text = "Error de autenticación. Nombre de usuario desconocido o contraseña incorrecta ";
                res = new List<string>();
                res.Add("");
                res.Add("Error de autenticación. Nombre de usuario desconocido o contraseña incorrecta");
                res.Add("Fail");
                return res;
            }
        }

        // PUT api/login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/login/5
        public void Delete(int id)
        {
        }

      
    }
}
