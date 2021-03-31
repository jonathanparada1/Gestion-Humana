using Dominio;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;

namespace ActivosChevy
{
    // Nota: para obtener instrucciones sobre cómo habilitar el modo clásico de IIS6 o IIS7, 
    // visite http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_PostAuthorizeRequest()
        {
            if (IsWebApiRequest())
            {
                //Habilita la sesión en Web API
                HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
            }
        }

        private bool IsWebApiRequest()
        {
            return HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.StartsWith(WebApiConfig.UrlPrefixRelative);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory());
    

            //Inicializa el Log
           // Logger.SetLogWriter(new LogWriterFactory().Create());

            System.Net.ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            if (exception != null)
            {
                Response.Clear();

                string action;
                if (exception is AccesoDenegadoException)
                {
                    action = "AccesoDenegado";
                }
                else
                {
                    HttpException httpException = exception as HttpException;
                    if (httpException == null)
                    {
                        action = "ErrorInesperado";
                    }
                    else
                    {
                        switch (httpException.GetHttpCode())
                        {
                            case 401:
                                action = "AccesoDenegado";
                                break;
                            case 404:
                                action = "RecursoNoEncontrado";
                                break;
                            default:
                                action = "ErrorInesperado";
                                break;
                        }
                    }
                }

                if (action == "ErrorInesperado")
                {
               //     Logger.Write(exception.ToString());
                }

                // clear error on server
                Server.ClearError();

                Response.Redirect(String.Format("~/{0}/", action));
            }
            else
            {
             //   Logger.Write("Excepción null en Application_Error");
            }
        }
    }
}