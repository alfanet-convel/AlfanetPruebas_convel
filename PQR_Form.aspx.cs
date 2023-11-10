using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using WebServiceAlfaBDU;
using iTextSharp.text;
using iTextSharp.text.pdf;
using DSRadicadoTableAdapters;
using DSGrupoSQLTableAdapters;
using System.Text.RegularExpressions;
//using System.Web.Mail;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using ASP;
using Microsoft;
//using DSRadicadoTableAdapters;
//using DSGrupoSQLTableAdapters;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;
using AjaxControlToolkit;
using System.Text;
using System.Net.Security;



public partial class PQR_Form : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
     {
         if (!IsPostBack)
         {
             ctIdentificacion.Enabled = false;
             ctNombreProcedencia.Enabled = false;
             ctEmail.Enabled = false;
             ctTelefono.Enabled = false;
             ctDireccion.Enabled = false;
             ddlPais.Enabled = false;
             cddPais.Enabled = false;
             ddlDepartamento.Enabled = false;
             cddDepartamento.Enabled = false;
             ctDepartamento.Enabled = false;
             ddlCiudad.Enabled = false;
             cddCiudad.Enabled = false;
             ctCiudad.Enabled = false;
             ddlTipoDePQR.Enabled = false;
             CCDTipoDePQR.Enabled = false;
             ctDetalle.Enabled = false;
             devExUpLoadArchivo.Enabled = false;
         }
         else
         {
             ctIdentificacion.Enabled = true;
             ctNombreProcedencia.Enabled = true;
             ctEmail.Enabled = true;
             ctTelefono.Enabled = true;
             ctDireccion.Enabled = true;
             ddlPais.Enabled = true;
             cddPais.Enabled = true;
             ddlDepartamento.Enabled = true;
             cddDepartamento.Enabled = true;
             ctDepartamento.Enabled = true;
             ddlCiudad.Enabled = true;
             cddCiudad.Enabled = true;
             ctCiudad.Enabled = true;
             ddlTipoDePQR.Enabled = true;
             CCDTipoDePQR.Enabled = true;
             ctDetalle.Enabled = true;
             devExUpLoadArchivo.Enabled = true;
         }


        this.ctTelefono.Attributes.Add("onkeypress", "return validarSoloNumeros(event)");
        this.ctIdentificacion.Attributes.Add("onkeypress", "return validarIdentificacion(event)");
        this.ctDetalle.Attributes.Add("onkeypress", "ConteoCaracteres('" + this.ctDetalle.ClientID  + "', '" + this.etMaximoCaracteres.ClientID + "', 300)");
        this.ctDetalle.Attributes.Add("onblur", "ConteoCaracteres('" + this.ctDetalle.ClientID + "', '" + this.etMaximoCaracteres.ClientID + "', 300)");
        this.ddlTipoDeIdentificacion.Attributes.Add("onchange", "DefineEstiloCCSenListaDesplegable(this, 'WaterMarkedDDL', 'cajasTexto')");
        this.ddlTipoDePQR.Attributes.Add("onchange", "DefineEstiloCCSenListaDesplegable(this, 'WaterMarkedDDL', 'cajasTexto')");
    }
    protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ("170" == this.ddlPais.SelectedValue) 
        {
            this.etDepartamento.Text = "DEPARTAMENTO";
            this.ddlDepartamento.Visible = true;
            this.ctDepartamento.Visible = false;
            this.cvDepartamento.ControlToValidate = this.ddlDepartamento.ClientID;

            this.ddlCiudad.Visible = true;
            this.ctCiudad.Visible = false;
            this.cvCiudad.ControlToValidate = this.ddlCiudad.ClientID;

        }
        else
        {
            this.etDepartamento.Text = "PROVINCIA";
            this.ddlDepartamento.Visible = false;
            this.ctDepartamento.Visible = true;
            this.cvDepartamento.ControlToValidate = this.ctDepartamento.ClientID;

            this.ddlCiudad.Visible = false;
            this.ctCiudad.Visible = true;
            this.cvCiudad.ControlToValidate = this.ctCiudad.ClientID;
        }
        
    }
    protected void ctIdentificacion_TextChanged(object sender, EventArgs e)
    {
        /*pregunta si existe en Alfanet*/
        //Creamos un tableAdapter
        DSProcedenciaSQLTableAdapters.ProcedenciaTableAdapter TAProcedencias = new DSProcedenciaSQLTableAdapters.ProcedenciaTableAdapter();
        //Creamos un DataTable
        DSProcedenciaSQL.ProcedenciaDataTable DTProcedencia = new DSProcedenciaSQL.ProcedenciaDataTable();
        DTProcedencia = TAProcedencias.GetProcedenciaIdV2DataBy(this.ctIdentificacion.Text.Trim().ToString(), ddlTipoDeIdentificacion.SelectedValue.ToString().Trim());
        //DTProcedencia = ProcedenciaBLL.GetProcedenciaByID(this.txtUserId.Text.Trim().ToString());

        //Si la procedencia ya existe en base de datos
        if (DTProcedencia.Rows.Count == 1)
        {
            DSProcedenciaSQL.ProcedenciaRow DRProcedencia = (DSProcedenciaSQL.ProcedenciaRow)DTProcedencia.Rows[0];
            this.ctNombreProcedencia.Text = DRProcedencia.ProcedenciaNombre;
            this.ctTelefono.Text = DRProcedencia.ProcedenciaTelefono1;
            this.ctEmail.Text = DRProcedencia.ProcedenciaMail1;
            this.ctDireccion.Text = DRProcedencia.ProcedenciaDireccion;

            //this.UpdPnNombreProcedencia.Update();
            //this.UpdPnTelefono.Update();
            //this.UpdPnEmail.Update();
            //this.UpdPnDireccion.Update();
        }
        else if(DTProcedencia.Rows.Count == 0)
        {
            this.ctNombreProcedencia.Text = "";
            this.ctTelefono.Text = "";
            this.ctEmail.Text = "";
            this.ctDireccion.Text = "";
        }
    }
    public static DateTime SumarDiasLaborables(DateTime fechaInicio, int cantidad)
    {
        string f;
        while (cantidad != 0)
        {
            DSFestivosTableAdapters.Fecha_FestivosTableAdapter Festivos = new DSFestivosTableAdapters.Fecha_FestivosTableAdapter();
            DSFestivos.Fecha_FestivosDataTable Festi = new DSFestivos.Fecha_FestivosDataTable();
            fechaInicio = fechaInicio.AddDays(1);
            f = Convert.ToString(fechaInicio.ToString("dd/MM/yyyy"));
            Festi = Festivos.GetData(f);
            if (fechaInicio.DayOfWeek != DayOfWeek.Saturday && fechaInicio.DayOfWeek != DayOfWeek.Sunday && Festi.Count != 1)
                cantidad--;
        }


        return fechaInicio;
    }

    protected void btEnviarPQR_Click(object sender, EventArgs e)
     {
         
             btEnviarPQR.Enabled = true;
		Boolean ExisteRadicado = false;
             Boolean ExisteProcedencia = false, ErrorDeValidacion = true;
             int ActualizaProcedencia = 0;
             string CiudadCodigo = "";
		string mensaje; 

             //VALIDAMOS LOS CAMPOS DILIGENCIADOS POR EL USUARIO
             //Validando El tipo de Identificacion
             string[] TiposDeId = { "cc", "ti", "ce", "nit", "pas" };

             foreach (string tipoDeID in TiposDeId)
             {
                 if (ddlTipoDeIdentificacion.SelectedValue == tipoDeID)
                     ErrorDeValidacion = false;
             }
             if (ErrorDeValidacion)
             {
                 ClientScript.RegisterStartupScript(this.GetType(), "key", "launchModal();", true);
                 this.etMsgPopuMensaje.Text = "Error: No ha elegido un Tipo de Identificación Valido";
                 return;
             }
             //ErrorDeValidacion = true;

             if ("0" == ddlTipoDeIdentificacion.SelectedValue || "" == ddlTipoDeIdentificacion.SelectedValue)
             {
                 this.cvTipoIdentificacion.Visible = true;
             }
             //Comprobar todos los campos recibidos por el formulario
             if (this.devExUpLoadArchivo.FileInputCount > 0)
             {
                 for (int i = 0; i < this.devExUpLoadArchivo.FileInputCount; i++)
                 {
                     if (this.devExUpLoadArchivo.UploadedFiles[i].FileName != "")
                     {
                         if (!((this.devExUpLoadArchivo.UploadedFiles[i].FileName.ToLower().Contains(".jpg")) ||
                             (this.devExUpLoadArchivo.UploadedFiles[i].FileName.ToLower().Contains(".jpeg")) ||
                             (this.devExUpLoadArchivo.UploadedFiles[i].FileName.ToLower().Contains(".gif")) ||
                             (this.devExUpLoadArchivo.UploadedFiles[i].FileName.ToLower().Contains(".png")) ||
                             (this.devExUpLoadArchivo.UploadedFiles[i].FileName.ToLower().Contains(".doc")) ||
                             (this.devExUpLoadArchivo.UploadedFiles[i].FileName.ToLower().Contains(".docx")) ||
                             (this.devExUpLoadArchivo.UploadedFiles[i].FileName.ToLower().Contains(".zip")) ||
                             (this.devExUpLoadArchivo.UploadedFiles[i].FileName.ToLower().Contains(".rar")) ||
                             (this.devExUpLoadArchivo.UploadedFiles[i].FileName.ToLower().Contains(".pdf"))))
                         {
                             ClientScript.RegisterStartupScript(this.GetType(), "key", "launchModal();", true);
                             this.etMsgPopuMensaje.Text = "Error: El tipo de archivo seleccionado no es valido";
                             return;
                         }
                     }
                 }
             }


             try
             {
                 //NOS PREPARAMOS PARA INSERTAR DATOS
                 //Obtenemos el GrupoCodigo de los Radicados
                 rutinas Rutinas = new rutinas();
                 string GrupoRadicado = ((DataTable)Rutinas.rtn_traer_tbtablas_por_Id("GRUPORAD")).Rows[0][0].ToString().Trim();

                 
                 //Verificamos si la procedencia ya existe en Alfanet
                 DSProcedenciaSQLTableAdapters.ProcedenciaTableAdapter TAProcedencias = new DSProcedenciaSQLTableAdapters.ProcedenciaTableAdapter();
                 //Creamos un DataTable
                 DSProcedenciaSQL.ProcedenciaDataTable DTProcedencia = new DSProcedenciaSQL.ProcedenciaDataTable();
                 DTProcedencia = TAProcedencias.GetProcedenciaIdV2DataBy(this.ctIdentificacion.Text.Trim().ToString(), ddlTipoDeIdentificacion.SelectedValue.ToString().Trim());
                 if (1 == DTProcedencia.Rows.Count) ExisteProcedencia = true;


                 //Verificamos que si se eligio un pais diferente de colombia,
                 //la ciudad suministrada exista en base de datos o de no crear la ciudad
                 if ("170" != this.ddlPais.SelectedValue)
                     CiudadCodigo = ((DataTable)Rutinas.rtn_verificar_CiudadPQR(this.ctCiudad.Text, this.ctDepartamento.Text, this.ddlPais.SelectedValue)).Rows[0][0].ToString().Trim();
                 else
                     CiudadCodigo = ddlCiudad.SelectedValue;



                 //Verificamos la existencia de la procedencia, si no existe hay que crearla, si existe
                 //ver si cambio para hacer la actualización
                 ActualizaProcedencia = (ExisteProcedencia) ? 1 : 0;

		//Creación Captcha John Vela 11/08/2016 para evitar Robot Informaticos
            	String CaptchaString = Session["CAPTCHA"].ToString();

            	if (this.TxtBCaptcha.Text.Equals(CaptchaString))
            	{
                	this.LblCaptchaError.Text = "";
            	}
            	else
            	{
                	this.LblCaptchaError.Text = "Captcha invalido";                
            	}
                 
                 //...[Insertamos La procedencia y el radicado]
                 //Este paso actualiza o inserta la procedencia y a la vez crea el radicado
                 //Creamos el TableAdapter
                 RadicarTramiteInTableAdapters.insertarprocedenciaTableAdapter TAInsertProcyRad = new RadicarTramiteInTableAdapters.insertarprocedenciaTableAdapter();
                 //Creamos el DataTable
                 RadicarTramiteIn.insertarprocedenciaDataTable DTInsertProcyRad = new RadicarTramiteIn.insertarprocedenciaDataTable();
                 //Obtenemos datos de una plantialla
                 DSRadicadoTableAdapters.PlantillaPQRTableAdapter TAPlantillaPQR = new DSRadicadoTableAdapters.PlantillaPQRTableAdapter();
                 DSRadicado.PlantillaPQRDataTable DTPlantillaPQR = new DSRadicado.PlantillaPQRDataTable();
                 DTPlantillaPQR = TAPlantillaPQR.GetPlantillaPQR();
                 DSRadicado.PlantillaPQRRow DRPlantPQR = (DSRadicado.PlantillaPQRRow)DTPlantillaPQR.Rows[0];
                 RadicarTramiteInTableAdapters.Dias_VenceTableAdapter DiasVence = new RadicarTramiteInTableAdapters.Dias_VenceTableAdapter();
                 RadicarTramiteIn.Dias_VenceDataTable DiasVencimiento = new RadicarTramiteIn.Dias_VenceDataTable();
                 int Dias = 0;
                 DiasVencimiento = DiasVence.GetData(ddlTipoDePQR.SelectedValue.ToString());
                 Dias = Convert.ToInt32(DiasVencimiento.Rows[0].ItemArray[0].ToString().Trim());
                 DateTime fechaInicial = DateTime.Now;    
                 DateTime fechahabil = SumarDiasLaborables(fechaInicial, Dias);
                 //string holyday = Convert.ToString(fechahabil);
                 //Verificamos que no se haya grabado un radicado identico 
                 RadicarTramiteInTableAdapters.Radicado_ReadRadicadoExistentePQRTableAdapter TARadicadoExiste = new RadicarTramiteInTableAdapters.Radicado_ReadRadicadoExistentePQRTableAdapter();
                 RadicarTramiteIn.Radicado_ReadRadicadoExistentePQRDataTable DTRadicadoExiste = new RadicarTramiteIn.Radicado_ReadRadicadoExistentePQRDataTable();
                 DTRadicadoExiste = TARadicadoExiste.GetData(this.ctIdentificacion.Text.Trim().ToString(), this.ddlTipoDePQR.Text.ToString(), this.ctDetalle.Text.ToString());
                 if (1 <= DTRadicadoExiste.Rows.Count) ExisteRadicado = true;
		         
                 if (ExisteRadicado == false)
                 {

			//Validamos que se envien los datos completos a la BD --John Vela 14/06/2016--
                	if (ctIdentificacion.Text != null & ctNombreProcedencia.Text != null & ctDireccion.Text != null & CiudadCodigo != null & ctTelefono.Text != null & ctEmail.Text != null & ddlTipoDePQR.SelectedValue.ToString() != null & ctDetalle.Text != null & ctIdentificacion.Text != "" & ctNombreProcedencia.Text != "" & ctDireccion.Text != "" & CiudadCodigo != "" & ctTelefono.Text != "" & ctEmail.Text != "" & ddlTipoDePQR.SelectedValue.ToString() != "" & ctDetalle.Text != "" & this.TxtBCaptcha.Text.Equals(CaptchaString))
                	{
                 		DTInsertProcyRad = TAInsertProcyRad.GetinsertpqrBy(ctIdentificacion.Text, ctNombreProcedencia.Text, ctDireccion.Text,
                     		CiudadCodigo, ctTelefono.Text, "", ctEmail.Text, "", null, "", ddlTipoDePQR.SelectedValue.ToString(), 
                     		DRPlantPQR.DependenciaCodigo, DRPlantPQR.ExpedienteCodigo, ctDetalle.Text, DateTime.Now, 
                     		ddlTipoDeIdentificacion.SelectedValue, ActualizaProcedencia.ToString(), fechahabil);
			}
		 }
                 else
                 {
                     if ("nit" == ddlTipoDeIdentificacion.SelectedValue)
                        mensaje = "Señores ";
                    else
                        mensaje = "Señor(a) ";

                     this.LbRadicadoRepetido.Text =  mensaje  + ctNombreProcedencia.Text + " el dia de hoy ya creo una PQRS con la misma información, puede intentar de nuevo en 24 horas.";
                 }
                 string coderror = DTInsertProcyRad[0].ErrorNumber;
                 if (!string.IsNullOrEmpty(coderror))
                     throw new ApplicationException(DTInsertProcyRad[0].ErrorMessage);

                 //Si hasta aqui todo va bien, hay que crear el documento pdf a partir del detalle del radicado
                 string CodigoDocumento = DTInsertProcyRad[0].RadicadoCodigo.ToString();
                 create_pdf(GrupoRadicado, CodigoDocumento, ddlTipoDeIdentificacion.SelectedValue, ctIdentificacion.Text,
                            ctNombreProcedencia.Text, ctDireccion.Text, ddlCiudad.SelectedValue, ddlDepartamento.SelectedValue, ctTelefono.Text, ctEmail.Text, ctDetalle.Text);

                 //Ahora se suben los archivos que el usuario adjunto
                 DSImagenTableAdapters.RadicadoImagenTableAdapter TARadicadoImagen = new DSImagenTableAdapters.RadicadoImagenTableAdapter();
                 DSImagenTableAdapters.ImagenRutaTableAdapter TAImgRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();
                 DSImagen.ImagenRutaDataTable DTImgRuta = new DSImagen.ImagenRutaDataTable();
                 Object CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "1");
                 int codigoR = Convert.ToInt32(CodigoRuta); //41;//Convert.ToInt32(CodigoRuta);
                 String Grupo = "Radicados";
                 String Ano = DateTime.Today.Year.ToString();
                 String Mes = DateTime.Today.Month.ToString();
                 String PathVirtual = HttpContext.Current.Server.MapPath("~/AlfaNetRepositorioImagenes/" + Grupo + "/" + Ano + "/" + Mes + "/");

                 if (null != this.devExUpLoadArchivo.UploadedFiles)
                 {
                     for (int i = 0; i < devExUpLoadArchivo.UploadedFiles.Length; i++)
                     {
                         if (this.devExUpLoadArchivo.UploadedFiles[i].FileName != "")
                         {
                             if (!Directory.Exists(PathVirtual))
                                 Directory.CreateDirectory(PathVirtual);

                             if (CodigoRuta == null)
                             {
                                 TAImgRuta.Insert(1, "", DateTime.Today.Year, DateTime.Today.Month, 1, PathVirtual);
                                 CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "1");
                                 codigoR = Convert.ToInt32(CodigoRuta);
                             }
                              //MofificaciÃ³n realizada por John Vela 06/08/2015 para que modificar el nombre con el que queda guardado el radicado
                              //TARadicadoImagen.InsertRadicadoImagen(GrupoRadicado, Convert.ToInt32(CodigoDocumento), DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + devExUpLoadArchivo.UploadedFiles[i].FileName, codigoR);
                              //devExUpLoadArchivo.UploadedFiles[i].SaveAs(PathVirtual + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + devExUpLoadArchivo.UploadedFiles[i].FileName);
                             TARadicadoImagen.InsertRadicadoImagen(GrupoRadicado, Convert.ToInt32(CodigoDocumento), DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + devExUpLoadArchivo.UploadedFiles[i].FileName, codigoR);
                             devExUpLoadArchivo.UploadedFiles[i].SaveAs(PathVirtual + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + devExUpLoadArchivo.UploadedFiles[i].FileName);

                         }
                     }
                 }

                 MailBLL Correo = new MailBLL();
                 //    MembershipUser usuario;
                 //    DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter ObjTaUsuarioxDependencia = new DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter();
                 //    DSUsuario.UsuariosxdependenciaDataTable DTUsuariosxDependencia = new DSUsuario.UsuariosxdependenciaDataTable();

                 //    DTUsuariosxDependencia = ObjTaUsuarioxDependencia.GetUsuariosxDependenciaByDependencia(DDLNaturalezaDependenciaPQR.SelectedValue);
                 //    if (DTUsuariosxDependencia.Count > 0)
                 //    {
                 //        DataRow[] rows = DTUsuariosxDependencia.Select();
                 //        System.Guid a = new Guid(rows[0].ItemArray[0].ToString().Trim());
                 //        usuario = Membership.GetUser(a);
                 string url = "http://www.convel.com.co/AlfanetPruebas/pqr_find.aspx";
                 string Body = "CONVEL S.A.S." + "<BR>" +
                         "le informa que su solicitud ha sido radicada con el" + "<b> número " + CodigoDocumento.ToString() + "</b>" +
                         "<BR>" + " Fecha de Radicación: " + DateTime.Now.ToLongDateString() +
                         " " + DateTime.Now.ToLongTimeString() + "<BR>" + "Procedencia: " +
                         ctNombreProcedencia.Text.ToString() + "<BR>" + "<BR>" +
                         "Tenga presente este número de solicitud para consultar su trámite." +
                         "<BR>" + "Para conocer el estado de su solicitud ingrese al siguiente enlace" +
                         "<a href=" + "http://www.convel.com.co/AlfanetPruebas/pqr_find.aspx" + ">" + " Consultar" + "</a>";
                 // Correo.EnvioCorreo("mesadeservicio@mintic.gov.co", ctEmail.Text, "Radicado Nro" + " " + CodigoDocumento.ToString(), Body, true, "1");
                 //   }

                 /*  try
                  {*/
                 //Configuración del Mensaje
                 MailMessage mail = new MailMessage();
                 SmtpClient SmtpServer = new SmtpClient();
                 SmtpServer.Host = "smtp.gmail.com";
                 SmtpServer.EnableSsl = true;
                 SmtpServer.Port = 587; //Puerto que utiliza Gmail para sus servicios
                 //Especificamos las credenciales con las que enviaremos el mail
                 SmtpServer.Credentials = new System.Net.NetworkCredential("convelsas@gmail.com", "convelcarrera63b");
                 //Especificamos el correo desde el que se enviará el Email y el nombre de la persona que lo envía
                 mail.From = new MailAddress("convelsas@gmail.com", "CONVEL S.A.S.", Encoding.UTF8);
                 //Aquí ponemos el asunto del correo
                 mail.Subject = "Radicado Nro" + " " + CodigoDocumento.ToString();
                 //Aquí ponemos el mensaje que incluirá el correo

                 mail.Body = "CONVEL S.A.S." + "<BR>" +
                     "le informa que su solicitud ha sido radicada con el" + "<b> número " + CodigoDocumento.ToString() + "</b>" +
                     "<BR>" + "<BR>" + " Fecha de Radicación: " + DateTime.Now.ToLongDateString() +
                     " " + DateTime.Now.ToLongTimeString() + "<BR>" + "<BR>" + "Procedencia: " +
                     ctNombreProcedencia.Text.ToString() + "<BR>" + "<BR>" +
                     "Tenga presente este número de solicitud para consultar su trámite." +
                     "<BR>" + "Si desea conocer el estado de su solicitud ingrese al siguiente enlace: " +
                     "<a href=" + "http://www.convel.com.co/AlfanetPruebas/pqr_find.aspx" + ">" + "Consultar" + "</a>" +
                     "<BR>" + "<BR>" +
                     "Nota: favor no responder este correo, este medio solo es utilizado para informar sobre su trámite ante CONVEL S.A.S..";
                 mail.IsBodyHtml = true;
                 //Especificamos a quien enviaremos el Email, no es necesario que sea Gmail, puede ser cualquier otro proveedor
                 mail.To.Add(ctEmail.Text);
                 //Si queremos enviar archivos adjuntos tenemos que especificar la ruta en donde se encuentran
                 //mail.Attachments.Add(new Attachment(@"C:\Documentos\carta.docx"));
                 //Configuracion del SMTP

                 
                 ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
               {
                   return true;
               };


                 SmtpServer.Send(mail);
                 //return true;
                 /* }
                  catch (Exception ex)
                  {
                      //return false;
                  }*/


                 /*  MailMessage msg = new MailMessage();

                   msg.To = this.ctEmail.Text;

                   msg.From = "alfanet.archivar@gmail.com";

                   msg.Subject = "El asunto del mail";

                   msg.Body = "Este es el contenido del email";

                   msg.Priority = MailPriority.High;

                   msg.BodyFormat = MailFormat.Text; //o MailFormat.Html */

                 //Si todo ha salido bien, Enviamos un mensaje en pantalla y blanqueamos el formulario
                 string mensajeExitoso = "";
                 if ("nit" == ddlTipoDeIdentificacion.SelectedValue)
                     mensajeExitoso = "Señores ";
                 else
                     mensajeExitoso = "Señor(a) ";

                 mensajeExitoso += ctNombreProcedencia.Text + ", su solicitud ha sido radicada con el No. "
                                + CodigoDocumento.ToString() + ", tenga en cuenta este número para hacerle seguimiento a su solicitud";

                 ClientScript.RegisterStartupScript(this.GetType(), "key", "launchModal();", true);
                 this.etMsgPopuMensaje.Text = mensajeExitoso;
                 this.btMsgPupup.OnClientClick = "parent.location.href='http://www.convel.com.co/'; return false;";
                 //this.etMsgPopuMensaje.ForeColor = System.Drawing.Color.DodgerBlue;



                 //Si todo salio bien blanqueamos el Formulario
                 this.ddlTipoDeIdentificacion.SelectedIndex = 0;
                 this.ctIdentificacion.Text = "";
                 this.ctNombreProcedencia.Text = "";
                 this.ctDireccion.Text = "";
                 this.ctTelefono.Text = "";
                 this.ctEmail.Text = "";
                 this.ddlPais.SelectedIndex = 0;
                 this.ddlTipoDePQR.SelectedIndex = 0;
                 this.ctDetalle.Text = "";

             }
        catch(Exception excepcion)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "key", "launchModal();", true);
            this.pnMsgPopup.Visible = true;
            if (excepcion.Message == "No se pudieron habilitar las restricciones. Una o varias filas contienen valores que infringen las restricciones NON-NULL, UNIQUE o FOREIGN-KEY.")
            
                this.etMsgPopuMensaje.Text = "Error: Ocurrio un error al guardar la PQR. Por favor valide los datos del formulario.";
            
            if (excepcion.Message == "No hay ninguna fila en la posición 0.")

                this.etMsgPopuMensaje.Text = "Error: Ocurrio un error al guardar la PQR. Por favor valide los datos del formulario.";
            if (excepcion.Message == "PQR ya existe")

                this.etMsgPopuMensaje.Text = "Ya se encuentra un radicado realizado el dia de hoy con la misma información.";
             
             

        }

             //------------------------------
         
    }

    /*Metodo para como primer documento adjunto el detalle del radicado*/
    protected void create_pdf(string GrupoRadicado, string CodigoDocumento, string tipoid, string nid, string nombre, string dir,string ciudad,string departamento, string telefono, string correo, string detalle)
    {
        /*Obtener Departamento*/

        DSDepartamentoSQLTableAdapters.DepartamentoTableAdapter TADepartamento = new DSDepartamentoSQLTableAdapters.DepartamentoTableAdapter();
        DataTable dtDepartamento = TADepartamento.GetDepartamentoById(departamento);
        string nombredepartamento = "";
        foreach (DataRow item in dtDepartamento.Rows)
        {
            nombredepartamento = item[1].ToString();
        }

        /*Obtener la descripcion de la ciudad*/
        DSCiudadSQLTableAdapters.CiudadTableAdapter TACiudad = new DSCiudadSQLTableAdapters.CiudadTableAdapter();
        DataTable ciudadd = TACiudad.GetCiudadById(ciudad);
        string nombreciudad="";
        foreach (DataRow item in ciudadd.Rows)
        {
            nombreciudad = item[1].ToString();
        }

 

        /*Guardarlo en alfanet*/
        DSImagenTableAdapters.RadicadoImagenTableAdapter TARadicadoImagen = new DSImagenTableAdapters.RadicadoImagenTableAdapter();
        DSImagenTableAdapters.ImagenRutaTableAdapter TAImgRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();
        DSImagen.ImagenRutaDataTable DTImgRuta = new DSImagen.ImagenRutaDataTable();

        Object CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "1");
        int codigoR = Convert.ToInt32(CodigoRuta);
        String Grupo = "Radicados";
        String Ano = DateTime.Today.Year.ToString();
        String Mes = DateTime.Today.Month.ToString();

        String PathVirtual = HttpContext.Current.Server.MapPath("~/AlfaNetRepositorioImagenes/" + Grupo + "/" + Ano + "/" + Mes + "/");
        /**/
        Document document = new Document();
        if (!Directory.Exists(PathVirtual))
        {
            Directory.CreateDirectory(PathVirtual);
        }
        PdfWriter.GetInstance(document, new FileStream(PathVirtual + "soporterad" + CodigoDocumento + ".pdf", FileMode.OpenOrCreate));
        document.Open();
        document.Add(new Paragraph("Documentos de soporte"));
        document.Add(new Paragraph(""));
        document.Add(new Paragraph("Nombre : " + nombre));
        document.Add(new Paragraph("Identificación : " + nid));
        document.Add(new Paragraph("N° Radicado : " + CodigoDocumento));
        document.Add(new Paragraph("E-Mail : " + correo));
        document.Add(new Paragraph("Teléfono : " + telefono));
        document.Add(new Paragraph("Dirección : " + dir));
        document.Add(new Paragraph("Ciudad : " + nombreciudad));
        document.Add(new Paragraph("Departamento : " + nombredepartamento));
        document.Add(new Paragraph("Detalle : "));
        document.Add(new Paragraph(detalle));
        document.Close();


        if (CodigoRuta == null)
        {
            TAImgRuta.Insert(1, "", DateTime.Today.Year, DateTime.Today.Month, 1, PathVirtual);
            CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "1");
            codigoR = Convert.ToInt32(CodigoRuta);
            if (Directory.Exists(PathVirtual))
            {
                TARadicadoImagen.InsertRadicadoImagen(GrupoRadicado, Int32.Parse(CodigoDocumento), "soporterad" + CodigoDocumento + ".pdf", codigoR);
                //this.devExUpLoadArchivo.UploadedFiles[i].SaveAs(PathVirtual + this.devExUpLoadArchivo.UploadedFiles[i].FileName);
            }
            else
            {
                Directory.CreateDirectory(PathVirtual);
                TARadicadoImagen.InsertRadicadoImagen(GrupoRadicado, Int32.Parse(CodigoDocumento), "soporterad" + CodigoDocumento + ".pdf", codigoR);
                //this.devExUpLoadArchivo.UploadedFiles[i].SaveAs(PathVirtual + this.devExUpLoadArchivo.UploadedFiles[i].FileName);
            }
        }
        else
        {
            if (Directory.Exists(PathVirtual))
            {
                TARadicadoImagen.InsertRadicadoImagen(GrupoRadicado, Int32.Parse(CodigoDocumento), "soporterad" + CodigoDocumento + ".pdf", codigoR);
                //this.devExUpLoadArchivo.UploadedFiles[i].SaveAs(PathVirtual + this.devExUpLoadArchivo.UploadedFiles[i].FileName);
            }
            else
            {
                Directory.CreateDirectory(PathVirtual);
                TARadicadoImagen.InsertRadicadoImagen(GrupoRadicado, Int32.Parse(CodigoDocumento), "soporterad" + CodigoDocumento + ".pdf", codigoR);
                //this.devExUpLoadArchivo.UploadedFiles[i].SaveAs(PathVirtual + this.devExUpLoadArchivo.UploadedFiles[i].FileName);

            }
        }

        /*Response.Clear();
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-disposition", "attachment; filename=" + "devjoker.pdf");
        Response.WriteFile(HttpContext.Current.Server.MapPath("~/devjoker.pdf"));
        Response.Flush();
        Response.Close();*/

        //File.Delete(Server.MapPath("~/devjoker.pdf"));


    }
    public void Page_Error(object Sender, EventArgs e)
     {
        Exception objErr = Server.GetLastError().GetBaseException();
        string err = "<b>Error Caught in Page_Error event</b><hr><br>" +
                "<br><b>Error in: </b>" + Request.Url.ToString() +
                "<br><b>Error Message: </b>" + objErr.Message.ToString() +
                "<br><b>Stack Trace:</b><br>" +
                          objErr.StackTrace.ToString();
        Response.Write(err.ToString());
        Server.ClearError();
    }
    //using System;


//namespace WebMail
//{
 //   class email
   // {
      /*  protected void Main(string[] args)
        {
            try 
            {
                MailMessage oMsg = new MailMessage();
        
                oMsg.From = "sender@somewhere.com";
            
                oMsg.To = "recipient@somewhere.com";
                oMsg.Subject = "Send Using Web Mail";
                
              
                oMsg.BodyFormat = MailFormat.Html;
                
         
                oMsg.Body = "<HTML><BODY><B>Hello World!</B></BODY></HTML>";
                
                // ADJUNTO
                String sFile = @"C:\temp\Hello.txt";  
                MailAttachment oAttch = new MailAttachment(sFile, MailEncoding.Base64);
  
                oMsg.Attachments.Add(oAttch);

                
                SmtpMail.SmtpServer = "MySMTPServer";
                SmtpMail.Send(oMsg);

                oMsg = null;
                oAttch = null;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }*/
   // }
//} 
    protected void btLimpiarFormulario_Click(object sender, EventArgs e)
    {
        //Si todo salio bien blanqueamos el Formulario
       /* this.ddlTipoDeIdentificacion.SelectedIndex = 0;
        this.ctIdentificacion.Text = "";
        this.ctNombreProcedencia.Text = "";
        this.ctDireccion.Text = "";
        this.ctTelefono.Text = "";
        this.ctEmail.Text = "";
        this.ddlPais.SelectedIndex = 0;
        this.ddlTipoDePQR.SelectedIndex = 0;
        this.ctDetalle.Text = "";*/
        Response.Redirect("PQR_form.aspx");
    }
    protected void ctDetalle_TextChanged(object sender, EventArgs e)
    {

    }
    protected void LinkUsoDatos_Click(object sender, EventArgs e)
    {
        string _open = "window.open('http://www.convel.com.co/PoliticadeDatosPersonalesConvel.pdf', '_blank' , 'top=100,left=100, width=1000,height=800,status=yes, resizable=yes,scrollbars=yes');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
    }
}
