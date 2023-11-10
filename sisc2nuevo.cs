using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using System.Net;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Description;
using System.Data;
using System.Web.Security;
using System.Collections.Generic;
using System.Collections;


/// <summary>
/// Descripción breve de sisc2
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class sisc2 : System.Web.Services.WebService
{
    private string AuthenticateUser(string strUser, string strPwd)
    {

        if (strUser == "user" && strPwd == "1234")

            return "Login usuario";


        else

            return null;

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

    public void LogOut()
    {

        // Cuando el cliente no reconoce el Password


        FormsAuthentication.SignOut();

    }

    public sisc2()
    {

        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string Radicar_Tramite(string NUI, string Nombre, string Direccion, string Ciudad, string Telefono1,
        string Telefono2, string Email1, string Email2, string Fax, string Naturaleza, string Dependencia,
        string Expediente, string Detalle, string NombreArchivo, Byte[] URL, string NumeroExterno,
        string NumerodeGuia, string MediodeRecibo, string FechadeProcedencia, string Cargar, string Accion,
        string Anexos, string enterar, string user, string password)
    {
        Boolean ingreso = Login(user, password);
        //Boolean ingreso = true;
        if (ingreso == true)
        {
            string coderror = null;


            //string ExpedienteBDU = BDU(Expediente);
            try
            {
                if (Expediente == "")
                {
                    Expediente = null;
                }
                if (Detalle == "")
                {
                    Detalle = null;
                }
                string respuesta;

                string sizeURL;
                string[] search;
                int sizeNombre;
                //string NombreArchivo = null;
                //***********************************************************************************//
                /*        NUI = "800123145-2";
         Nombre=				"PRUEBAS REGISTRO POSTAL 07-01-2012";
         Direccion	=		"PRUEBAS REG POSTAL DIR NOTIFICACION";
         Ciudad		=		"11001";
         Telefono1	=		"5706949";
         Telefono2	=		"5706949";
         Email1		=		"consultoria2@todosistemassti.com";
         Email2		=		"consultoria2@todosistemassti.com";
         Fax			=		"";
         Naturaleza = "10002";
         Dependencia = "2.02.2.2.42";
         //Expediente	=		"";
         Detalle		=		"Solicitud de Registro Operadores Postal";
         NombreArchivo=		"IM-REGISTRO OPERADORES POSTALES_32945_PRUEBAS REGISTRO POSTAL 07-01-2012_ROP-421.PDF";
        //string Archivo		=		{byte[2048]};
         string URL = "pagina web";
         NumeroExterno=		"";
         NumerodeGuia	=	"";
         MediodeRecibo=		"10";
         //FechaProcedencia=	"07/02/2012";
          Cargar		=		"";
          Accion = "";
          Anexos = "No hay Anexos";
          enterar = "";
          user = "user";
          password = "1234";*/

                /*   Registro = sisc.Radicar_Tramite("", //NUI
                                                                     "ABCDEGE SA", //Nombre 
                                                                     "CR 8 NO. 20 - 56 P 6", //Direccion 
                                                                     "11001", //Ciudad
                                                                     "999777", //Telefono1 
                                                                     "111555", //Telefono2
                                                                     "consultoria2@todosistemassti.com", //Email1 
                                                                     "consultoria2@todosistemassti.com", //Email2
                                                                     "", //Fax 
                                                                     "10002", //Naturaleza 
                                                                     "2.02.2.2.42", //Dependencia 
                                                                     "", //Expediente 
                                                                     "Pruebas sisc", //Detalle 
                                                                     NombreDoc, //Nombrearchivo 
                                                                     bytedoc, //URL 
                                                                     "353535", //NumeroExterno 
                                                                     "9-89985", //NumerodeGuia 
                                                                     "10", //MediodeRecibo 
                                                                     DateTime.Now.ToShortDateString(), //FechaProcedencia 
                                                                     "1.1", //cargar
                                                                     "9", //Accion 
                                                                     "No hay Anexos", //Anexos 
                                                                     "301.1"
                                                                     , "user",
                                                                     "1234");*/
                //***********************************************************************************//

                String Fecha = Convert.ToString(DateTime.Now);
                RadicarTramiteUAndesTableAdapters.Expediente_RadicarTramiteESPTableAdapter Tabla = new RadicarTramiteUAndesTableAdapters.Expediente_RadicarTramiteESPTableAdapter();
                RadicarTramiteUAndes.Expediente_RadicarTramiteESPDataTable Dtabla = new RadicarTramiteUAndes.Expediente_RadicarTramiteESPDataTable();

                /*  RadicarTramiteUAndesTableAdapters.Consulta_NuiTableAdapter consultanui = new RadicarTramiteUAndesTableAdapters.Consulta_NuiTableAdapter();
                  DataTable existe = new DataTable();
                  existe = consultanui.GetData(NUI);

                  string a = "";

                  foreach (DataRow item in existe.Rows)
                  {
                      a = item["Column1"].ToString();
                  }*/
                string Result;
                /* if (a == "0")
                 {
                     NUI = "TICS_" + NUI;
                     //string mensaje = "Nos Encontramos en mantenimiento por favor comunicarse con Mintic.";

                     //Result = "<Root>" + "<RadicadoCodigo></RadicadoCodigo>" + "<WFMovimientoFecha></WFMovimientoFecha><ExpedienteCodigo></ExpedienteCodigo>" + "<CodigoError>" + "1" + "</CodigoError>" + "<MensajeError>" + mensaje + "</MensajeError>" + "</Root>";
                     //return Result;
                 }*/

                Dtabla = Tabla.GetData(NUI, Nombre, Direccion, Ciudad, Telefono1, Telefono2, Email1, Email2, Fax, Naturaleza, Dependencia, Expediente, Detalle, URL.ToString(), Convert.ToString(DateTime.Now.ToString()));
                coderror = Dtabla[0].ErrorNumber;
                if (coderror == null || coderror == "")
                {
                    coderror = "0";
                }
                else
                {
                    coderror = "1";
                }
                //string Result="";

                String Descarga = AdjuntarImgRad(Dtabla[0].RadicadoCodigo, NombreArchivo, URL, user, password);
                if (Descarga == "Proceso Finalizado")
                {
                    Result = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<Root>" + "<RadicadoCodigo>" + Dtabla[0].RadicadoCodigo + "</RadicadoCodigo>" + "<WFMovimientoFecha>" + Dtabla[0].WFMovimientoFecha + "</WFMovimientoFecha>" + "<ExpedienteCodigo>" + Dtabla[0].ExpedienteCodigo + "</ExpedienteCodigo>" + "<CodigoError>" + coderror + "</CodigoError>" + "<MensajeError>" + Dtabla[0].ErrorMessage + "</MensajeError>" + "</Root>";
                }
                else
                {
                    Result = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<Root>" + "<RadicadoCodigo>" + "Ocurrio un problema al Radicar. " + "</RadicadoCodigo>" + "<WFMovimientoFecha>" + Dtabla[0].WFMovimientoFecha + "</WFMovimientoFecha>" + "<ExpedienteCodigo>" + Dtabla[0].ExpedienteCodigo + "</ExpedienteCodigo>" + "<CodigoError>" + "1" + "</CodigoError>" + "<MensajeError>" + Descarga + "</MensajeError>" + "</Root>";
                }

                return Result;
            }
            catch (Exception ex)
            {
                string Resultex;

                String Result;
                Resultex = "Ocurrio un problema al Radicar. ";
                //Exception inner = Error.InnerException;
                Resultex += ErrorHandled.FindError(ex);
                Resultex += " " + ex.Message;
                Result = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<Root>" + "<RadicadoCodigo></RadicadoCodigo>" + "<WFMovimientoFecha></WFMovimientoFecha><ExpedienteCodigo></ExpedienteCodigo>" + "<CodigoError>" + "1" + "</CodigoError>" + "<MensajeError>" + Resultex + "</MensajeError>" + "</Root>";
                return Result;
            }
        }
        else
        {
            return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " <Root> " + "<Error>" + "El usuario o la clave esta mal escrito" + "</Error>" + "</Root>";
        }
    }

    [WebMethod]
    public string AdjuntarImgRad(String Radicado, String NombreArchivo, Byte[] oArchivo, string user, string password)
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
                if (TipoArchivo == "docx" || TipoArchivo == "doc" || TipoArchivo == "xls" || TipoArchivo == "xlsx" || TipoArchivo == "pdf" || TipoArchivo == "tif" || TipoArchivo == "tiff" || TipoArchivo == "jpg" || TipoArchivo == "txt" || TipoArchivo == "cvs" || TipoArchivo == "rtf" || TipoArchivo == "zip" || TipoArchivo == "rar" || TipoArchivo == "xml")
                {

                    String Grupo = "Radicados";
                    String Ano = DateTime.Today.Year.ToString();
                    String Mes = DateTime.Today.Month.ToString();

                    String PathVirtual = HttpContext.Current.Server.MapPath("~/AlfaNetRepositorioImagenes/" + Grupo + "/" + Ano + "/" + Mes + "/");

                    DSImagenTableAdapters.RadicadoImagenTableAdapter TARadicadoImagen = new DSImagenTableAdapters.RadicadoImagenTableAdapter();
                    DSImagenTableAdapters.ImagenRutaTableAdapter TAImgRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();
                    DSImagen.ImagenRutaDataTable DTImgRuta = new DSImagen.ImagenRutaDataTable();

                    Object CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "1");
                    int codigoR = Convert.ToInt32(CodigoRuta);

                    if (CodigoRuta == null)
                    {
                        TAImgRuta.Insert(1, "", DateTime.Today.Year, DateTime.Today.Month, 1, PathVirtual);
                    }
                    CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "1");
                    codigoR = Convert.ToInt32(CodigoRuta);
                    if (!Directory.Exists(PathVirtual))
                    {
                        Directory.CreateDirectory(PathVirtual);

                    }
                    NombreArchivo = Radicado + "1" + Ano + Mes + DateTime.Today.Day.ToString() + NombreArchivo;
                    TARadicadoImagen.InsertRadicadoImagen("1", Convert.ToInt32(Radicado), NombreArchivo, codigoR);



                    System.IO.File.WriteAllBytes(@PathVirtual + NombreArchivo, oArchivo);

                    return "Proceso Finalizado";
                }
                else
                {
                    return "<Mensaje>" + "El formato no corresponde con los permitidos(Word, Excel, Pdf, Jpg, Tif, Zip, Rar, Csv, Rtf, Xml)" + "</Mensaje>";
                }
            }

            catch (Exception Ex)
            {
                return Ex.Message.ToString();
            }
        }
        else
        {
            return "<Error>" + "El usuario o la clave esta mal escrito" + "</Error>";
        }

    }

    [WebMethod]
    public string adjuntarimgsrad(string rad, String[] nombres, List<Byte[]> oArchivos, string user, string password)
    {
        Boolean ingreso = Login(user, password);
        if (ingreso == true)
        {
            int i = 0;

            try
            {
                foreach (Byte[] ing in oArchivos)
                {
                    AdjuntarImgRad(rad, nombres[i], ing, user, password);
                    i = i + 1;
                }
                return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " <Root> " + "<Ok>Procedo Finalizado Correctamente</Ok>" + "</Root>";
            }
            catch (Exception Ex)
            {
                return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<Root>" + "<Error>" + "Error Adjuntando Imagenes Radicado: " + Ex.Message + "<Error>" + "</Root>";
            }
        }
        else
        {
            return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " <Root> " + "<Error>" + "El usuario o la clave esta mal escrito" + "</Error>" + "</Root>";
        }
    }

    [WebMethod]
    public string adjuntarimgsreg(string reg, String[] nombres, List<Byte[]> oArchivos, string user, string password)
    {
        Boolean ingreso = Login(user, password);
        if (ingreso == true)
        {
            int i = 0;

            try
            {
                foreach (Byte[] ing in oArchivos)
                {
                    AdjuntarImgReg(reg, nombres[i], ing, user, password);
                    i = i + 1;
                    //return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " <Root> " + "<Ok>Procedo Finalizado Correctamente</Ok>" + "</Root>";
                }
                return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " <Root> " + "<Ok>Procedo Finalizado Correctamente</Ok>" + "</Root>";
            }
            catch (Exception Ex)
            {
                return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<Root>" + "<Error>" + "Error Adjuntando Imagenes Radicado: " + Ex.Message + "<Error>" + "</Root>";
            }
        }
        else
        {
            return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " <Root> " + "<Error>" + "El usuario o la clave esta mal escrito" + "</Error>" + "</Root>";
        }
    }

    public string RegistrarImg(string URL, String Radicado, String PathVirtual, String NombreArchivo, string user, string password)
    {
        Boolean ingreso = Login(user, password);
        if (ingreso == true)
        {
            try
            {
                DSImagenTableAdapters.RadicadoImagenTableAdapter TARadicadoImagen = new DSImagenTableAdapters.RadicadoImagenTableAdapter();
                DSImagenTableAdapters.ImagenRutaTableAdapter TAImgRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();
                DSImagen.ImagenRutaDataTable DTImgRuta = new DSImagen.ImagenRutaDataTable();

                Object CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "1");
                int codigoR = Convert.ToInt32(CodigoRuta);

                if (CodigoRuta == null)
                {
                    TAImgRuta.Insert(1, "", DateTime.Today.Year, DateTime.Today.Month, 1, PathVirtual);
                }
                CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "1");
                codigoR = Convert.ToInt32(CodigoRuta);
                if (!Directory.Exists(PathVirtual))
                {
                    Directory.CreateDirectory(PathVirtual);

                }
                TARadicadoImagen.InsertRadicadoImagen("1", Convert.ToInt32(Radicado), NombreArchivo, codigoR);

                return null;
            }

            catch (Exception Ex)
            {
                return Ex.Message.ToString();
            }
        }
        else
        {
            return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " <Root> " + "<Error>" + "El usuario o la clave esta mal escrito" + "</Error>" + "</Root>";
        }
    }

    [WebMethod]
    public String[] ArchivosxTramite(string numerodeidentificacion, string numeroderadicacion, string numerodetramite, string user, string password)
    {
        Boolean ingreso = Login(user, password);
        if (ingreso == true)
        {
            try
            {
                DataTable tabla = new DataTable();
                rutinas ejecutar = new rutinas();
                tabla = ejecutar.rtn_traer_FilexTramite(numerodeidentificacion, numeroderadicacion, numerodetramite);
                string salida = " <?xml version=\"1.0\" encoding=\"utf-8\"?>";
                salida += "<Root>";

                String[] registros = new String[tabla.Rows.Count + 1];
                registros[0] = salida;
                int contador = 0;
                foreach (DataRow dr in tabla.Rows)
                {
                    contador = contador + 1;
                    salida = "";
                    //salida += "<Root>";
                    salida += "<Tramite NumeroDocumento=\"" + dr["NumeroDocumento"].ToString() + "\"" + ">";

                    // trae Tipo_de_Documento
                    salida += "<Tipo_de_Documento>";
                    salida += dr["GrupoNombre"].ToString();
                    salida += "</Tipo_de_Documento>";

                    // trae Numero_de_Tramite
                    salida += "<Numero_de_Tramite>";
                    salida += dr["ExpedienteCodigo"].ToString();
                    salida += "</Numero_de_Tramite>";

                    // ruta rutaimagen
                    salida += "<RutaImagen>";
                    salida += dr["ImagenRutaPath"].ToString() + dr["NombreImagen"].ToString();
                    salida += "</RutaImagen>";

                    salida += "</Tramite>";
                    //salida += "</Root>";

                    registros[contador] = salida;
                }

                if (contador == 0)
                {
                    salida = "";
                    salida += "<Tramite NumeroDocumento>";
                    salida += "</Tramite NumeroDocumento>";

                    // trae Tipo_de_Documento
                    salida += "<Tipo_de_Documento>";
                    salida += "</Tipo_de_Documento>";

                    // trae Numero_de_Tramite
                    salida += "<Numero_de_Tramite>";
                    salida += "</Numero_de_Tramite>";

                    // ruta rutaimagen
                    salida += "<RutaImagen>";
                    salida += "</RutaImagen>";

                    salida += "</Tramite>";
                    //salida += "</Root>";
                    registros[contador] = salida;
                }

                registros[contador] += "</Root>";


                return registros;

            }
            catch (Exception ex)
            {


            }
            finally
            {

            }
            return null;
        }
        else
        {
            String[] registros = new String[1];
            registros[0] = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " <Root> " + "<ERROR>" + "El usuario o la clave esta mal escrito" + "</ERROR>" + "</Root>";
            return registros;
        }
    }

    //Autor: Juan Ricardo Gonzalez Sepulveda
    //Fecha: 25/06/2011
    //RegistroCoumenicaciones enviadas, 
    [WebMethod]
    public string Registrar_Tramite(string DependenciaRemite, String CodDestino, string NomDestino, string WFTipo, String[] RadFuente, string Expediente, string Naturaleza, String SerieDocumental, string Detalle, String NombreArchivo, Byte[] Archivo, string MetododeEnvio, string guia, string archivaren, string anexos, string copiar, string user, string password)
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

                Result = RegBLL.AddRegistro("2", DateTime.Now, CodDestino, null, DependenciaRemite, Naturaleza, Convert.ToInt32(RadFuente[0].ToString()), Detalle, null, null, null, null, m.ProviderUserKey.ToString(), Expediente, "TL", SerieDocumental, null, "0", "2", DateTime.Now, DateTime.Now, 0, Detalle, "0");
                //RadicarTramiteUAndesTableAdapters.Expediente_RadicarTramiteUATableAdapter Tabla = new RadicarTramiteUAndesTableAdapters.Expediente_RadicarTramiteUATableAdapter();
                //RadicarTramiteUAndes.Expediente_RadicarTramiteUADataTable Dtabla = new RadicarTramiteUAndes.Expediente_RadicarTramiteUADataTable();
                //Dtabla = Tabla.GetData(NUI, Nombre, Direccion, Ciudad, Telefono1, Telefono2, Email1, Email2, Fax, Naturaleza, Dependencia, Expediente, Detalle, Archivo.ToString(), DateTime.Now);
                //coderror = Dtabla[0].ErrorNumber;
                //if (coderror == null)
                //{
                //    coderror = "0";
                //}
                //else
                //{
                //    coderror = "1";
                //}
                if (Result == "Error al crear registro. Verifique que los parametros sean validosInstrucción INSERT en conflicto con la restricción FOREIGN KEY \"FK_Registro_Dependencia\". El conflicto ha aparecido en la base de datos \"BDMINTIC\", tabla \"dbo.Dependencia\", column 'DependenciaCodigo'.")
                {
                    Result = "La dependecia está mal escrita. ";
                }
                if (Result == "Error al crear registro. Verifique que los parametros sean validosInstrucción INSERT en conflicto con la restricción FOREIGN KEY \"FK_Registro_Naturaleza\". El conflicto ha aparecido en la base de datos \"BDMINTIC\", tabla \"dbo.Naturaleza\", column 'NaturalezaCodigo'.")
                {
                    Result = "La Naturaleza está mal escrita. ";
                }
                if (Result == "Error al crear registro. Verifique que los parametros sean validosInstrucción INSERT en conflicto con la restricción FOREIGN KEY \"FK_Registro_Expediente\". El conflicto ha aparecido en la base de datos \"BDMINTIC\", tabla \"dbo.Expediente\", column 'ExpedienteCodigo'.")
                {
                    Result = "El expediente está mal escrito. ";
                }
                if (Result == "Error al crear registro. Verifique que los parametros sean validosInstrucción INSERT en conflicto con la restricción FOREIGN KEY \"FK_Registro_Serie\". El conflicto ha aparecido en la base de datos \"BDMINTIC\", tabla \"dbo.Serie\", column 'SerieCodigo'.")
                {
                    Result = "La serie documental está mal escrita. ";
                }

                Descarga = AdjuntarImgReg(Result, NombreArchivo, Archivo, user, password);
                if (Descarga == "Proceso Finalizado")
                {
                    Result = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<Root>" + "<RegistroCodigo>" + Result + "</RegistroCodigo>" + "<WFMovimientoFecha>" + Fecha + "</WFMovimientoFecha>" + "<ExpedienteCodigo>" + Expediente + "</ExpedienteCodigo>" + //"<CodigoError>" + coderror + "</CodigoError>" + 
                        "<Mensaje>" + "Proceso exitoso" + "</Mensaje>" + "</Root>";

                }
                else
                {
                    Result = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<Root>" + "<RegistroCodigo>" + "Ocurrio un problema al Registrar." + "</RegistroCodigo>" + "<WFMovimientoFecha>" + Fecha + "</WFMovimientoFecha>" + "<ExpedienteCodigo>" + Expediente + "</ExpedienteCodigo>" + "<CodigoError>" + "1" + "</CodigoError>" + "<MensajeError>" + Result + Descarga + "</MensajeError>" + "</Root>";
                }

                return Result;
            }
            catch (Exception ex)
            {
                string Resultex;


                Resultex = "Ocurrio un problema al Registrar.";
                //Exception inner = Error.InnerException;
                Resultex = ErrorHandled.FindError(ex);
                Resultex += " " + ex.Message;
                Result = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<Root>" + "<RegistroCodigo></RegistroCodigo>" + "<WFMovimientoFecha></WFMovimientoFecha>" + "<ExpedienteCodigo></ExpedienteCodigo>" + "<CodigoError>" + "1" + "</CodigoError>" + "<MensajeError>" + Resultex + "</MensajeError>" + "</Root>";
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

                    return "Proceso Finalizado";
                }
                else
                {
                    return "<Mensaje>" + "El formato no corresponde con los permitidos(Word, Excel, Pdf, Jpg, Tif, Zip, Rar, Csv, Rtf)" + "</Mensaje>";
                }

            }

            catch (Exception Ex)
            {
                return Ex.Message.ToString();
            }
        }
        else
        {
            return "<Error>" + "El usuario o la clave esta mal escrito" + "</Error>";
        }
    }

    [WebMethod]
    public String[] ConsultaComunicadosXTramite(string vDocumentoCodigo, string vExpedienteCodigo, string user, string password)
    {
        Boolean ingreso = Login(user, password);
        if (ingreso == true)
        {
            try
            {
                DataTable tablaComunicado = new DataTable();
                DataTable tablaImagen = new DataTable();
                rutinas ejecutar = new rutinas();
                tablaComunicado = ejecutar.rtn_traer_ComunicadosxTramite(vDocumentoCodigo, vExpedienteCodigo);
                String[] registros = new String[tablaComunicado.Rows.Count + 1];

                if (tablaComunicado.Rows.Count == 0)
                {
                    registros[0] = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " <Root> " + "<ERROR>No hay registros con esos datos</ERROR>" + "</Root>";
                    return registros;
                }

                string salida = " <?xml version=\"1.0\" encoding=\"utf-8\"?>";
                salida += "<Root>";
                registros[0] = salida;
                int contador = 0;
                int contador2 = 0;

                foreach (DataRow dr in tablaComunicado.Rows)
                {
                    contador = contador + 1;
                    contador2 = 0;
                    salida = "";

                    salida += "<Documento Nro=\"" + dr["DocumentoNro"].ToString() + "\"" + ">";

                    //Ruta del Archivo
                    tablaImagen = ejecutar.rtn_traer_RutaImagenxTramite(vDocumentoCodigo, dr["TipoDocumento"].ToString());
                    foreach (DataRow dr2 in tablaImagen.Rows)
                    {
                        contador2 = contador2 + 1;
                        salida += "<Archivo\"" + contador2 + "\"" + ">";
                        salida += dr2["Ruta"].ToString();
                        salida += "</Archivo>";
                    }


                    //Expediente
                    salida += "<Expediente>";
                    salida += dr["Expediente"].ToString();
                    salida += "</Expediente>";


                    //Tipo de Documento
                    salida += "<Tipo_Documento>";
                    salida += dr["TipoDocumento"].ToString();
                    salida += "</Tipo_Documento>";

                    //Detalle del Documento
                    salida += "<Detalle_Documento>";
                    salida += dr["Detalle"].ToString();
                    salida += "</Detalle_Documento>";

                    salida += "</Documento>";

                    registros[contador] = salida;
                }

                registros[contador] += "</Root>";
                return registros;

            }
            catch (Exception Ex)
            {
                String[] registros = new String[1];
                registros[0] = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " <Root> " + "<ERROR>" + Ex.Message.ToString() + "</ERROR>" + "</Root>";
                return registros;
            }
        }
        else
        {
            String[] registros = new String[1];
            registros[0] = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " <Root> " + "<ERROR>" + "El usuario o la clave esta mal escrito" + "</ERROR>" + "</Root>";
            return registros;
        }
    }
    //Fin Juan Ricardo Gonzalez Sepulveda
    [WebMethod]
    public string asignarTramite(string vDocumentoCodigo, string vGrupoCodigo, string vMovimientoTipo, string vDependenciaCodigo, string vAccionCodigo, string user, string password)
    {
        Boolean ingreso = Login(user, password);
        if (ingreso == true)
        {

            string vSerieCodigo = "";
            string vWFMovimientoPasoActual = "";
            string vWFMovimientoPasoFinal = "";

            if (vMovimientoTipo == "3")// Cuando el movimiento es archivar el Documento
            {
                vSerieCodigo = vDependenciaCodigo;
                vWFMovimientoPasoActual = "0";
                vWFMovimientoPasoFinal = "1";
                vDependenciaCodigo = "";
            }
            else if (vMovimientoTipo == "1")//Cuando solo se va a pasar a otra dependencia
            {
                vSerieCodigo = "";
                vWFMovimientoPasoActual = "1";
                vWFMovimientoPasoFinal = "0";
            }

            try
            {
                DataTable tablaComunicado = new DataTable();
                DataTable tablaConsulta = new DataTable();
                rutinas ejecutar = new rutinas();

                string vWFMovimientoPaso = "";
                string vWFMovimientoTipoIni = "1";
                string vWFMovimientoNotas = "";
                string vWFProcesoCodigo = null;
                string vWFMovimientoMultitarea = "0";
                string vDependenciaCodOrigen = "";
                string vUserId = "";
                DateTime vWFFechaMovimientoFin = DateTime.Now;
                DateTime vWFMovimientoFecha = DateTime.Now;
                DateTime vWFMovimientoFechaEst = DateTime.Now;

                tablaComunicado = ejecutar.rtn_traer_wfmovimiento(vDocumentoCodigo, vDependenciaCodigo, vWFMovimientoPaso,
                                                                    vWFMovimientoPasoActual, vWFMovimientoPasoFinal,
                                                                    vWFFechaMovimientoFin, vMovimientoTipo,
                                                                    vWFMovimientoTipoIni, vWFMovimientoNotas,
                                                                    vGrupoCodigo, vDependenciaCodOrigen,
                                                                    vWFProcesoCodigo, vAccionCodigo, vWFMovimientoFecha,
                                                                    vWFMovimientoFechaEst, vSerieCodigo,
                                                                    vWFMovimientoMultitarea, vUserId);
                //En caso de existir un error en la insercion de los datos, se captura el mensaje de error de la BD.
                foreach (DataRow dr in tablaComunicado.Rows)
                {
                    string errores = dr["ErrorMessage"].ToString();
                    return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<Root>" + "<Error>" + "Se encontro el Siguiente Error: " + errores + "</Error>" + "</Root>";
                }

                //Mensaje de exito en caso de finalizar el proceso exitosamente.
                if (tablaComunicado.Rows.Count == 0)
                {
                    return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " <Root> " + "<EXITO>Procedo Finalizado Exitosamente</EXITO>" + "</Root>";
                }
                return "";
            }
            catch (Exception Ex)
            {
                return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " <Root> " + "<Error>" + Ex.Message + " - exception " + "</Error>" + "</Root>";
            }
        }
        else
        {
            return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " <Root> " + "<Error>" + "El usuario o la clave esta mal escrito" + "</Error>" + "</Root>";
        }
    }
}
