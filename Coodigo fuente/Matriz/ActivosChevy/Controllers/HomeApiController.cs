using Dominio.Dao;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Providers.Entities;
using System.Configuration;

namespace ActivosChevy.Controllers
{
    public class HomeApiController : ApiController
    {

        [ActionName("Crear")]
        public object Crear(IngresoActivo ObjVista)
        {
            Mail.Service ws = new Mail.Service();
            try
            {
                ObjVista.FECHA = DateTimeOffset.Now.DateTime;
                ObjVista.FECHA_J = DateTimeOffset.Now.DateTime;

                var obj = new ActivoLogica().Generar(ObjVista);
                ws.EnvioCorreos(
                    new ChevyPlan.Mail("", ConfigurationManager.AppSettings["Correo"].ToString(), "", "", "Modificación de Usuario",
                        "Cordial Saludo,<br/><br/>Por Favor modificar las aplicaciones del siguiente usuario:<br/><br/>"
                         + "<table class='egt' border='1' width='2050' cellspacing='0' cellpadding='0' style='text-align:center;' >"
                            +"<tr>"
                              + "<th width='850'>IDENTIFICACIÓN</th>"
                              + "<th width='850'>NOMBRES</th>"
                              + "<th width='850'>APELLIDOS</th>"
                              + "<th width='850'>CARGO</th>"
                              + "<th width='850'>CONTRATO</th>"
                              + "<th width='1050'>CONCESIONARIO</th>"
                              + "<th width='1050'>APLICACIONES</th>"
                              + "<th width='850'>OBSERVACIONES</th>"
                            +"</tr>"
                            +"<tr>"
                              + "<td width='850'>" + ObjVista.CEDULA + "</td>"
                              + "<td width='850'>" + ObjVista.NOMBRES + "</td>"
                              + "<td width='850'>" + ObjVista.APELLIDOS + "</td>"
                              + "<td width='850'>" + ObjVista.CARGO + "</td>"
                              + "<td width='850'>" + ObjVista.T_CONTRATO + "</td>"
                              + "<td width='1050'>" + ObjVista.AREA + "</td>"
                              + "<td width='1050'>" + ObjVista.ID_APLICACION+ "</td>"
                              + "<td width='850'>" + ObjVista.OBSERVACIONES + "</td>"
                            +"</tr>"
                         +"</table>"
                        + "<br/><br/>Coordialmente,<br/><br/>"
                        + "<label style=\"font-size:15px; color: #0040FF; font-family: arial;\">"
                        + "Área de Sistemas </label> <br>"
                        + "<label style=\"font-size:15px; color: #0040FF; font-family: arial;\">"
                        + "ChevyPlan® S.A. </label> <br>"
                        + "<label style=\"font-size:15px; color: #0040FF; font-family: arial;\"> "
                        + "Carrera 7 Nº 75 – 26 </label> <br>"
                        + "<label style=\"font-size:15px; color: #0040FF; font-family: arial;\">"
                        + "Código Postal: 110221 </label> <br>"
                        + "<label style=\"font-size:15px; color: #0040FF; font-family: arial;\"> "
                        + "Bogotá D.C., Colombia </label> <br>"
                        + "<label style=\"font-size:15px; color: #0040FF; font-family: arial;\"> "
                        + "Tel. (57)(1) 6286820 Extensión 1301 o 1308 <label> <br>"
                        + "<label style=\"font-size:15px; color: #0040FF; font-family: arial;\"> "
                        + "infraestructuratecnologica@chevyplan.com.co <label> <br> <br>"
                        + "<label style=\"font-size:9px; color: #A4A4A4; font-family: arial;\">"
                        + "Este correo y sus anexos son confidenciales y están protegidos por derechos de autor, están dirigidos única y exclusivamente para uso de él (los) destinatario(s). Si usted por error lo ha recibido por favor notifíquelo inmediatamente al remitente y destrúyalo de su sistema. No debe copiar, ni imprimir, ni distribuir este correo o sus anexos, ni usarlos para propósito alguno ni dar a conocer su contenido a persona alguna. Las opiniones, conclusiones y otra información contenida en este correo no relacionadas con el negocio oficial de ChevyPlan®, deben entenderse como personales y de ninguna manera son avaladas por la compañía. Será sujeto de sanciones penales el que, en provecho propio o ajeno o en perjuicio de terceros, divulgue o emplee la información contenida en este correo electrónico. Si usted no es el destinatario, por favor notifique de este hecho al remitente de este correo electrónico y borre o destruya el correo y todas sus copias.“La marca registrada CHEVYPLAN® pertenece a General Motors Corporation, usado bajo la licencia a Megaplan S.A.” <label>"
                           , "").envicorreo()
                    , "Formato.Usuario@chevyplan.com.co"

                    , true);
                return true;

            }
            catch (Exception ex)
            {
                string a = ex.Message.ToString();
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
