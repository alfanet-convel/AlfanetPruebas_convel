using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using WebServiceAlfaBDU;
using System.Web.Security;
using System.IO;


/// <summary>
/// Descripción breve de ActualizarProcedencia
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class ActualizarBDU : System.Web.Services.WebService {
    FuncionalidadServicioImplementacion bdu = new FuncionalidadServicioImplementacion();
    public ActualizarBDU () 
    {
        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string ModificarProcedencia
       (string nit       , string razonsocial, string direccion , string  telefono1, 
        string telefono2 ,  string fax       , string ciudad    , 
        string correo1   , string correo2    , string paginaweb , string  sucursal )
    
    {

        string salida = "";
        DataTable tabla = new DataTable();
        rutinas ejecutar = new rutinas();
        tabla = ejecutar.rtn_actualizar_procedencia_por_id
            (
            nit,
            razonsocial,
            direccion,
            telefono1,
            telefono2,
            fax,
            ciudad,
            correo1,
            correo2,
            paginaweb,
            sucursal 
            );

        if (tabla.Columns.Count == 1)
        {
            salida = "Error " + tabla.Rows[0]["error"].ToString();
        }

        if (tabla.Columns.Count>1)
        {
        if (tabla.Rows.Count==0) salida = "Error el Nui(Nit)  no existe ";
        if (tabla.Rows.Count > 0) salida =  "Ok. proceso existoso " ;
        }

        return salida;

    }

    [WebMethod]
    public string ModificarPreExpediente
       (string nit, string sucursal, string expediente, string ClaseDeServicio)
    {

        string salida = "";
        DataTable tabla = new DataTable();
        rutinas ejecutar = new rutinas();
        tabla = ejecutar.rtn_actualizar_preexpediente(nit, sucursal, expediente, ClaseDeServicio);

        if (tabla.Columns.Count == 1)
        {
            salida = "Error " + tabla.Rows[0]["error"].ToString();
        }

        if (tabla.Columns.Count > 1)
        {
            if (tabla.Rows.Count == 0) salida = " 0 filas actualizadas ";
            if (tabla.Rows.Count > 0) salida = "Actualizacion de preexpediente Ok.. ";
        }


        //foreach (DataRow xreader in tabla.Rows)
        //{
            
        //    string xerror = xreader["error"].ToString().Trim();
        //    string xfilas = xreader["filas"].ToString().Trim();

        //    if ((xerror == "0") && (xfilas == "0")) salida = " 0 filas actualizadas ";
        //    if ((xerror != "0") && (xfilas == "0")) salida = "Error.." + xerror;
        //    if ((xerror == "0") && (xfilas != "0")) salida = "proceso actualizacion de preexpediente Ok.." + xfilas + " Registros Actualizados";


        //}
        return salida;

    }
    [WebMethod]
    public string GetAlfaNetBDI (string Documento, string GrupoCodigo)
    {
        string salida = "";
        DataTable tabla = new DataTable();
        rutinas ejecutar = new rutinas();
        tabla = ejecutar.rtn_Getalfanetbdi(Documento, GrupoCodigo);
        DataRow[] rows = tabla.Select();
        if (tabla.Rows.Count == 0)
        {
            salida = "El Documento No Existe ";
        }
        else if (tabla.Rows.Count >= 1)
        {
            salida = "<Root>" + "<Documento>" + rows[0]["documento"].ToString() + "</Documento>" + "<FechaDocumento>" + rows[0]["fechadocumento"].ToString() + "</FechaDocumento>" + "<Remitente>" + rows[0]["remitente"].ToString() + "</Remitente>" + "<FechaRecibido>" + rows[0]["fecharecibido"].ToString() + "</FechaRecibido>" + "<Vinculo>" + rows[0]["vinculo"].ToString() + "</Vinculo>" + "</Root>";  
                  
        }                        
        return salida;
    }
    [WebMethod]
    public string GetAlfaNetBDI2(string Documento, string GrupoCodigo)
    {
        string salida = string.Empty;
        DataTable tabla = new DataTable();
        rutinas rtn = new rutinas();
        tabla = rtn.rtn_Getalfanetbdi(Documento, GrupoCodigo); 
        
        if (tabla.Rows.Count == 0)
        {
            salida = "El Documento No Existe";
        }
        else
        {
            salida += "<Root>"
                        + "<Documento>" + tabla.Rows[0]["documento"].ToString() + "</Documento>"
                        + "<FechaDocumento>" + tabla.Rows[0]["fechadocumento"].ToString() + "</FechaDocumento>"
                        + "<Remitente>" + tabla.Rows[0]["remitente"].ToString() + "</Remitente>"
                        + "<FechaRecibido>" + tabla.Rows[0]["fecharecibido"].ToString() + "</FechaRecibido>";
            foreach (DataRow row in tabla.Rows)
            {
                salida += "<Vinculo>" + row["vinculo"].ToString() + "</Vinculo>";
                        
            }
            salida +=  "</Root>";
        }
        return salida;
    }

    //Autor: Juan Ricardo Gonzalez Sepulveda
    //Fecha: 25/06/2011
    //RegistroCoumenicaciones enviadas, 
    [WebMethod]
    public string Registrar_Tramite(string DependenciaRemite, string CodDestino, string NomDestino, string WFTipo, string[] RadFuente, string Expediente,
                                     string Naturaleza, string SerieDocumental, string Detalle, string NombreArchivo, byte[] Archivo,
                                     string MetododeEnvio, string guia, string archivaren, string anexos, string copiar, string user, string password)
    {       

        Boolean ingreso = Login(user, password);
        if (ingreso == true)
        {
            RegistroBLL RegBLL = new RegistroBLL();

            if (Expediente == "")
            {
                Expediente = null;
            }
            if (Detalle == "")
            {
                Detalle = null;
            }

            string coderror = null;
            string respuesta;
            string sizeURL;
            string[] search;
            int sizeNombre;
            string Result = null;
            String Descarga;

            //Codigo Temporal Simular Session Usuario        

            try
            {
                MembershipUser m = Membership.GetUser("TLINEA");

                String Fecha = Convert.ToString(DateTime.Now);

                Result = RegBLL.AddRegistroBDU("2", DateTime.Now, null, CodDestino, DependenciaRemite, Naturaleza, Convert.ToInt32(RadFuente[0].ToString()),
                                               Detalle, null, null, null, null, m.ProviderUserKey.ToString(), Expediente, "TL", SerieDocumental, null, WFTipo,
                                               "2", DateTime.Now, DateTime.Now, Convert.ToInt32(WFTipo), Detalle, "0");

                Descarga = AdjuntarImgReg(Result, NombreArchivo, Archivo, user, password);
                if (Descarga == "Proceso Finalizado")
                {
                    Result = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<Root>" + "<RadicadoCodigo>" + Result + "</RadicadoCodigo>" + "<WFMovimientoFecha>" +
                            Fecha + "</WFMovimientoFecha>" + "<ExpedienteCodigo>" + Expediente + "</ExpedienteCodigo>" + "<CodigoError>" +
                            coderror + "</CodigoError>" + "<MensajeError>" + "OK" + "</MensajeError>" + "</Root>";
                }
                else
                {
                    Result = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<Root>" + "<RadicadoCodigo>" + Result + "</RadicadoCodigo>" + "<WFMovimientoFecha>" +
                            Fecha + "</WFMovimientoFecha>" + "<ExpedienteCodigo>" + Expediente + "</ExpedienteCodigo>" + "<CodigoError>" + "1" + "</CodigoError>" + "<MensajeError>" +
                            Result + "</MensajeError>" + "</Root>";
                }

                return Result;
            }
            catch (Exception ex)
            {
                string Resultex;

                CrearLog(ex.Message);
                Resultex = "Ocurrio un problema al Radicar. ";
                //Exception inner = Error.InnerException;
                Resultex += ErrorHandled.FindError(ex);
                Resultex += " " + ex.Message;
                Result = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<Root>" + "<RadicadoCodigo></RadicadoCodigo>" +
                         "<WFMovimientoFecha></WFMovimientoFecha><ExpedienteCodigo></ExpedienteCodigo>" + "<CodigoError>" + "1" + "</CodigoError>" + "<MensajeError>" +
                         Resultex + "</MensajeError>" + "</Root>";
                return Result;
            }
        }
        else
        {
            String registros = "";
            registros = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " <Root> " + "<ERROR>" + "El usuario o la clave esta mal escrito" + "</ERROR>" + "</Root>";
            return registros;
        }
    }
    private bool CrearLog(string log)
    {
        try
        {
            if (System.IO.File.Exists(@"E:\LogsAlfanet"))
            {
                const string fic = @"E:\LogsAlfanet\Log.txt";
                string fecha = DateTime.Now.ToString();
                string texto = fecha + "Error | " + log;

                StreamWriter sw = new StreamWriter(fic, true);
                sw.WriteLine(texto);
                sw.WriteLine("-------------------------------------------------");
                sw.Flush();
                sw.Close();
            }
            else
            {
                string activeDir = @"E:\";

                //Create a new subfolder under the current active folder
                string newPath = System.IO.Path.Combine(activeDir, "LogsAlfanet");

                // Create the subfolder
                System.IO.Directory.CreateDirectory(newPath);
                const string fic = @"E:\LogsAlfanet\Log.txt";
                string fecha = DateTime.Now.ToString();
                string texto = fecha + "Error | " + log;

                StreamWriter sw = new StreamWriter(fic, true);
                sw.WriteLine(texto);
                sw.WriteLine("-------------------------------------------------");
                sw.Flush();
                sw.Close();
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
        
    }
    [WebMethod]
    public string AdjuntarImgReg(String Registro, String NombreArchivo, Byte[] oArchivo, string user, string password)
    {
        Boolean ingreso = Login(user, password);
        if (ingreso == true)
        {

            try
            {
                String[] Extension = NombreArchivo.Split('.');
                String TipoArchivo = Extension[Extension.Length - 1];
                TipoArchivo = TipoArchivo.ToLower();

                if (oArchivo.Length >= 10240000)
                {
                    return "El tamaño del archivo no corresponde con el maximo permitido";
                }
                if (TipoArchivo == "docx" || TipoArchivo == "doc" || TipoArchivo == "xls" || TipoArchivo == "xlsx" || TipoArchivo == "pdf" || TipoArchivo == "tif" || TipoArchivo == "tiff" || TipoArchivo == "jpg" || TipoArchivo == "txt" || TipoArchivo == "cvs" || TipoArchivo == "rtf" || TipoArchivo == "zip" || TipoArchivo == "rar")
                {
                    String Grupo = "Registros";
                    String Ano = DateTime.Today.Year.ToString();
                    String Mes = DateTime.Today.Month.ToString();

                    String PathVirtual = HttpContext.Current.Server.MapPath("~/AlfaNetRepositorioImagenes/" + Grupo + "/" + Ano + "/" + Mes + "/");

                    DSImagenTableAdapters.RegistroImagenTableAdapter TARegistroImagen = new DSImagenTableAdapters.RegistroImagenTableAdapter();

                    DSImagenTableAdapters.ImagenRutaTableAdapter TAImgRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();
                    DSImagen.ImagenRutaDataTable DTImgRuta = new DSImagen.ImagenRutaDataTable();

                    Object CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "2");
                    int codigoR = Convert.ToInt32(CodigoRuta);

                    if (CodigoRuta == null)
                    {
                        TAImgRuta.Insert(2, "", DateTime.Today.Year, DateTime.Today.Month, 2, PathVirtual);
                    }
                    CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "2");
                    codigoR = Convert.ToInt32(CodigoRuta);
                    if (!Directory.Exists(PathVirtual))
                    {
                        Directory.CreateDirectory(PathVirtual);
                    }
                    NombreArchivo = Registro + "2" + Ano + Mes + DateTime.Today.Day.ToString() + NombreArchivo;
                    TARegistroImagen.InsertRegistroImagen("2", Convert.ToInt32(Registro), NombreArchivo, codigoR);

                    System.IO.File.WriteAllBytes(@PathVirtual + NombreArchivo, oArchivo);
                    //CrearLog("Log de prueba...");
                    return "Proceso Finalizado";
                }
                else
                {
                    return "<Mensaje>" + "El formato no corresponde con los permitidos(Word, Excel, Pdf, Jpg, Tif, Zip, Rar, Csv, Rtf)" + "</Mensaje>";
                }
            }

            catch (Exception Ex)
            {
                CrearLog(Ex.Message);
                return "No fue posible adjuntar la imagen. "+Ex.Message.ToString();
            }
        }
        else
        {
            return "<Error>" + "El usuario o la clave esta mal escrito" + "</Error>";
        }
    }

    [WebMethod]
    public string asignarTramite(string vDocumentoCodigo, string vGrupoCodigo, string vMovimientoTipo, string vDependenciaCodigo, string vAccionCodigo, string user, string password)
    {
        Boolean ingreso = Login(user, password);
        if (ingreso)
        {
            string serieCodigo = vDependenciaCodigo.Trim();
            string documento = vDocumentoCodigo.Trim();
            string mensaje = string.Empty;
            bool valido = ValidarDatos(documento, serieCodigo, out mensaje);
            if (valido == false)
            {
                CrearLog(mensaje);
                return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<Root>" + "<Error>" + "Se encontro el Siguiente Error: " + mensaje + "</Error>" + "</Root>";
            }

            string resultado = string.Empty;
            DalWebService dal = null;
            try
            {                
                dal = new DalWebService();
                resultado = dal.asignarTramite(documento, serieCodigo);
                if (resultado == "OK")
                {
                    return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " <Root> " + "<EXITO>Proceso finalizado exitosamente</EXITO>" + "</Root>";
                }
                else
                {
                    string errores = resultado
                       + " Documento: " + documento
                       + " Grupo: " + vGrupoCodigo
                       + " MovTipo: " + vMovimientoTipo
                       + " Dependencia: " + serieCodigo
                       + " Accion: " + vAccionCodigo;
                    CrearLog(errores);
                    return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<Root>" + "<Error>" + "Se encontro el Siguiente Error: " + errores + "</Error>" + "</Root>";                
                }
            }
            catch (Exception ex)
            {
                CrearLog(ex.Message);
                return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " <Root> " + "<Error>" + ex.Message + " - exception " + "</Error>" + "</Root>";
            }
        }
        else
        {
            return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " <Root> " + "<Error>" + "El usuario o la clave esta mal escrito" + "</Error>" + "</Root>";
        }
    }

    private bool ValidarDatos(string documento, string serie, out string message)
    {
        DalWebService dal = null;
        try
        {
            if (documento == "" || serie == "")
            {
                message = "Faltan parámetros obligatorios.";
                return false;
            }
            dal = new DalWebService();
            int valDocumento = dal.ValidarDocumento(documento);
            if (valDocumento == 0)
            {
                message = "El documento que intenta archivar no existe.";
                return false;
            }
            int valSerie = dal.ValidarSerie(serie);
            if (valSerie == 0)
            {
                message = "La serie a la que intenta archivar el documento no existe.";
                return false;
            }
            message = "Validación correcta.";
            return true;
        }
        catch (Exception ex)
        {            
            throw ex;
        }
    }

    public bool Login(string strUser, string strPwd)
    {
        string strRole = AuthenticateUser(strUser, strPwd);
        if (strRole != null)
        {
            // Pregunta el Password al Cliente
            FormsAuthentication.SetAuthCookie(strUser, false);
            return true;
        }
        else
            return false;
    }

    private string AuthenticateUser(string strUser, string strPwd)
    {
        if (strUser == "user" && strPwd == "1234")
            return "Login usuario";
        else
            return null;
    }
}

