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
    public class TecnologiaApiController : ApiController
    {
        [ActionName("Crear")]
        public object Crear(Tecnologia ObjVista)
        {
            Mail.Service ws = new Mail.Service();
            try
            {
                ObjVista.FECHA = DateTimeOffset.Now.DateTime;
                if (new TecnologiaLogica().Consultar(ObjVista.CEDULA.ToString()))
                {
                    return "NO";
                }
                else
                {
                    var obj = new TecnologiaLogica().Generar(ObjVista);
                    ws.EnvioCorreos(
                        new ChevyPlan.Mail("", "" + ObjVista.To, "", "" + ObjVista.Cco, "Creacion de Usuario",
                            "<p> Cordial Saludo, <br> <br>Confirmo la creación de usuario y habilitación de privilegios para:  "
                            + ObjVista.USUARIO
                            + "   quien desempeñará labores en CHEVYPLAN:  </p> <br>"
                            + "<table width=\"40%\""
                            + "border = \"0\""
                            + "cellspacing=\"0\""
                            + "cellpadding=\"0\""
                            + "style=\"border: 2px solid #000;\" >"
                            + "<tr  width=\"20%\" "
                            + "style=\"background-color: #c5c5c5;"
                            + "width: 99px;height: 22px;\">"
                            + "<th>NOMBRE USUARIO <br>"
                            + ObjVista.USUARIO
                            + "</th>"
                            + "</tr>"
                            + "</table>"
                            + "<table width=\"40%\""
                            + "border = \"0\""
                            + "cellspacing=\"0\""
                            + "cellpadding=\"0\""
                            + "style=\"border: 2px solid #000;\" >"
                            + "<tr  width=\"20%\" "
                            + "style=\"background-color: #0000;"
                            + "width: 99px;height: 22px;\">"
                            + "<th>CORREO <br>"
                            + ObjVista.CORREO
                            + "</th>"
                            + "</tr>"
                            + "</table>"
                            + "<table width=\"40%\""
                            + "border = \"0\""
                            + "cellspacing=\"0\""
                            + "cellpadding=\"0\""
                            + "style=\"border: 2px solid #000;\" >"
                            + " <tr>"
                            + "<td width=\"40%\">"
                            + "<p style=\"padding: 0 70px; font-family: arial; text-align: center\">"
                            + "USUARIO DE RED <br>"
                            + ObjVista.NOMBRES
                            + " </p>"
                            + " </td>"
                            + "<td width=\"40%\" "
                            + "style=\"border-left: 1px solid #000\">"
                            + "<p style=\"padding: 0 70px; font-family: arial; text-align: center\">"
                            + " CLAVE <br>"
                            + ObjVista.CLAVE
                            + "</p>"
                            + " </td>"
                            + "</tr>"
                            + " <tr>"
                            + "<td width=\"40%\" style=\"background-color: #c5c5c5\">"
                            + "<p style=\"padding: 0 70px; font-family: arial; text-align: center\">"
                            + "1 USUARIO SICO <br>"
                            + ObjVista.USUSICO1
                            + " </p>"
                            + "  </td>"
                            + "<td width=\"40%\" style=\"background-color: #c5c5c5\">"
                        //+ "style=\"border-left: 1px solid #000\">"
                            + "<p style=\"padding: 0 70px; font-family: arial; text-align: center\">"
                            + " CLAVE <br>"
                            + ObjVista.CLAVSICO1
                            + "</p>"
                            + " </td>"
                            + "</tr>"
                             + " <tr>"
                            + "<td width=\"40%\">"
                            + "<p style=\"padding: 0 70px; font-family: arial; text-align: center\">"
                            + " 2 USUARIO SICO  <br>"
                            + ObjVista.USUSICO2
                            + " </p>"
                            + "  </td>"
                            + "<td width=\"40%\" "
                            + "style=\"border-left: 1px solid #000\">"
                            + "<p style=\"padding: 0 70px; font-family: arial; text-align: center\">"
                            + " CLAVE <br>"
                            + ObjVista.CLAVSICO2
                            + "</p>"
                            + " </td>"
                            + "</tr>"
                            + "</table>"
                            + "<br> <br>"
                            + "<p>	Compañeros de soporte por favor mapear carpetas compartidas y validar el ingreso a las siguientes aplicaciones: "
                            + ObjVista.OBSERVACIONES
                            + "</p> <br>"
                            + "<H4> NOTA OFICINA PRINCIPAL :  </H4> "
                            + "<label> Una vez que realice el cambio de contraseña de correo recuerde diligenciar la encuesta para el "
                            + "desbloqueo de sus usuarios (Correo y/o Sico) ingresando al siguiente link para : http://intranet:8080/SeguridaddelaInformacion/BiblioCuestionarioValidacionIdentidad/Forms/AllItems.aspx en la opción"
                            + "“Encuesta de Desbloqueo de Usuarios”; POR FAVOR INGRESAR CON SU USUARIO DE CORREO Y CONTRASEÑA ACTUAL del correo.</label> <br> "
                            + "<H4>NOTA CONCESIONARIO:  </H4> "
                            + "<label> Una vez que realice el cambio de contraseña de correo recuerde diligenciar la encuesta para el desbloqueo de sus usuarios (Correo y Sico) ingresando al siguiente link: https://www.chevynet.com.co:8004/Login.aspx en la opción "
                            + "“Encuesta de Desbloqueo de Usuarios”.</label> <br> <br> <br>"
                            + "Infraestructura Tecnologica</label><br>"
                            + "<label style=\"font-size:15px; color: #0040FF; font-family: arial;\">"
                            + "<H4> Área de Sistemas  </H4>  <br>"
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
            }
            catch (Exception ex)
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