using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Security;
////////////////////////////////////////
using System.IO;
using System.Net;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Description;
using WebServiceAlfaBDU;
using System.Data;
///////////////////////////////////////////////////

/// <summary>
/// Descripción breve de InterOpAlfaNet_Sage
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class InterOpAlfaNet_Sage : System.Web.Services.WebService
{

    //string Procedencia_Codigo ="";
    FuncionalidadServicioImplementacion bdu = new FuncionalidadServicioImplementacion();

    public InterOpAlfaNet_Sage()
    {

        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public String BDU(String Expediente)
    {
        try
        {
            string Resultex;
            Resultex = "a";
            IAB_003Request RequestIAB003 = new IAB_003Request();
            IAB_003Response ResponseIAB003 = new IAB_003Response();
            //IMB_001Request RequestIAB001 = new IMB_001Request();
            IMB_001Response ResponseIMB001 = new IMB_001Response();

            ResponseIMB001 = bdu.IMB_001();

            RequestIAB003.NitOperador = "860014923";
            RequestIAB003.ClaseServicio = "13";
            RequestIAB003.NumeroExpediente = "52684";
            RequestIAB003.Sucursal = "4";
            ResponseIAB003 = bdu.IAB_003(RequestIAB003);

            return Resultex;
        }
        catch (Exception ex)
        {
            string Resultex;
            Resultex = "Ocurrio un problema. ";
            //Exception inner = Error.InnerException;
            Resultex += ErrorHandled.FindError(ex);
            Resultex += " " + ex.Message;
            return Resultex;
        }
    }

    [WebMethod]
    public string Radicar_Tramite(string NUI, string Nombre, string Direccion, string Ciudad, string Telefono1, string Telefono2, string Email1, string Email2, string Fax, string Naturaleza, string Dependencia, string Expediente, string Detalle, String NombreArchivo, Byte[] Archivo)
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

            String Fecha = Convert.ToString(DateTime.Now);
            RadicarTramiteUAndesTableAdapters.Expediente_RadicarTramiteESPTableAdapter Tabla = new RadicarTramiteUAndesTableAdapters.Expediente_RadicarTramiteESPTableAdapter();
            RadicarTramiteUAndes.Expediente_RadicarTramiteESPDataTable Dtabla = new RadicarTramiteUAndes.Expediente_RadicarTramiteESPDataTable();
            /* RadicarTramiteUAndesTableAdapters.Consulta_NuiTableAdapter consultanui = new RadicarTramiteUAndesTableAdapters.Consulta_NuiTableAdapter();
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
                 // string mensaje = "Nos Encontramos en mantenimiento por favor comunicarse con Mintic.";

                 // Result = "<Root>" + "<RadicadoCodigo></RadicadoCodigo>" + "<WFMovimientoFecha></WFMovimientoFecha><ExpedienteCodigo></ExpedienteCodigo>" + "<CodigoError>" + "1" + "</CodigoError>" + "<MensajeError>" + mensaje + "</MensajeError>" + "</Root>";
                 // return Result;
             }*/
            Dtabla = Tabla.GetData(NUI, Nombre, Direccion, Ciudad, Telefono1, Telefono2, Email1, Email2, Fax, Naturaleza, Dependencia, Expediente, Detalle, Archivo.ToString(), Convert.ToString(DateTime.Now.ToString()));
            coderror = Dtabla[0].ErrorNumber;
            if (coderror == null || coderror == "")
            {
                coderror = "0";
            }
            else
            {
                coderror = "1";
                CrearLog(Dtabla[0].ErrorMessage.ToString());
            }
            //string Result;

            String Descarga = AdjuntarImgRad(Dtabla[0].RadicadoCodigo, NombreArchivo, Archivo);
            if (Descarga == "Proceso Finalizado")
            {
                Result = "<Root>" + "<RadicadoCodigo>" + Dtabla[0].RadicadoCodigo + "</RadicadoCodigo>" + "<WFMovimientoFecha>" + Dtabla[0].WFMovimientoFecha + "</WFMovimientoFecha>" + "<ExpedienteCodigo>" + Dtabla[0].ExpedienteCodigo + "</ExpedienteCodigo>" + "<CodigoError>" + coderror + "</CodigoError>" + "<MensajeError>" + Dtabla[0].ErrorMessage + "</MensajeError>" + "</Root>";
            }
            else
            {
                Result = "<Root>" + "<RadicadoCodigo>" + Dtabla[0].RadicadoCodigo + "</RadicadoCodigo>" + "<WFMovimientoFecha>" + Dtabla[0].WFMovimientoFecha + "</WFMovimientoFecha>" + "<ExpedienteCodigo>" + Dtabla[0].ExpedienteCodigo + "</ExpedienteCodigo>" + "<CodigoError>" + "1" + "</CodigoError>" + "<MensajeError>" + Descarga + "</MensajeError>" + "</Root>";
            }

            return Result;
        }
        catch (Exception ex)
        {
            string Resultex;
            CrearLog(ex.Message);
            String Result;
            Resultex = "Ocurrio un problema al Radicar. ";
            //Exception inner = Error.InnerException;
            Resultex += ErrorHandled.FindError(ex);
            Resultex += " " + ex.Message;
            CrearLog(Resultex);
            Result = "<Root>" + "<RadicadoCodigo></RadicadoCodigo>" + "<WFMovimientoFecha></WFMovimientoFecha><ExpedienteCodigo></ExpedienteCodigo>" + "<CodigoError>" + "1" + "</CodigoError>" + "<MensajeError>" + Resultex + "</MensajeError>" + "</Root>";
            return Result;
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
    public string AdjuntarImgRad(String Radicado, String NombreArchivo, Byte[] oArchivo)
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
                return "El formato no corresponde con los permitidos(Word, Excel, Pdf, Jpg, Tif, Zip, Rar, Csv, Rtf, Xml)";
            }




        }

        catch (Exception Ex)
        {
            return Ex.Message.ToString();
        }

    }

    //Autor: Juan
    //Fecha: 06/04/2011
    //WebResponse resp = request.GetResponse(); 
    //var buffer = new byte[4096]; 
    //Stream responseStream = resp.GetResponseStream(); 
    //{   int count;   
    //    do   
    //    {     
    //        count = responseStream.Read(buffer, 0, buffer.Length);     
    //        memoryStream.Write(buffer, 0, responseStream.Read(buffer, 0, buffer.Length));   
    //    } 
    //    while (count != 0); 
    //} 
    //        resp.Close(); 
    //        byte[] memoryBuffer = memoryStream.ToArray(); 
    //           System.IO.File.WriteAllBytes(@"E:\sample1.pdf", memoryBuffer); 
    //            int s = memoryBuffer.Length;  
    //            BinaryWriter binaryWriter = new BinaryWriter(File.Open(@"E:\sample2.pdf", FileMode.Create)); 
    //            binaryWriter.Write(memoryBuffer); 

    //Autor: Anderson Ardila Martinez
    //Fecha: 06/02/2011
    //Consulta Comunicaciones x Tramite
    [WebMethod]
    public String[] ConsultaComunicadosXTramite(string vDocumentoCodigo, string vExpedienteCodigo)
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
                registros[0] = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " < Root > " + "<ERROR>No hay registros con esos datos</ERROR>" + "</Root>";
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
                    salida += "<Archivo Nro=\"" + contador2 + "\"" + ">";
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
            registros[0] = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " < Root >" + "<ERROR>" + Ex.Message.ToString() + "</ERROR>" + "</Root>";
            return registros;
        }
    }
    //Fin Anderson Ardila


    //Autor: Anderson Ardila Martinez
    //Fecha: 09/02/2011
    //Consulta Comunicaciones x Fecha y Naturaleza
    [WebMethod]
    public String[] ConsultaComunicadosXFechaNaturaleza(string vFechaInicial, string vNaturalezaCodigo)
    {
        try
        {
            DataTable tablaComunicado = new DataTable();
            rutinas ejecutar = new rutinas();
            tablaComunicado = ejecutar.rtn_traer_ComunicadosXFechaNaturaleza(vFechaInicial, vNaturalezaCodigo);
            String[] registros = new String[tablaComunicado.Rows.Count + 1];

            if (tablaComunicado.Rows.Count == 0)
            {
                registros[0] = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " < Root > " + "<ERROR>No hay registros con esos datos</ERROR>" + "</Root>";
                return registros;
            }

            string salida = " <?xml version=\"1.0\" encoding=\"utf-8\"?>";
            salida += "<Root>";
            registros[0] = salida;
            int contador = 0;

            foreach (DataRow dr in tablaComunicado.Rows)
            {
                contador = contador + 1;
                salida = "";

                //Documento
                salida += "<Documento Nro=\"" + dr["DocumentoNro"].ToString() + "\"" + ">";

                //Expediente
                salida += "<Expediente>";
                salida += dr["Expediente"].ToString();
                salida += "</Expediente>";


                //Tipo de Documento
                salida += "<Tipo_Documento>";
                salida += dr["TipoDocumento"].ToString();
                salida += "</Tipo_Documento>";

                salida += "</Documento>";

                registros[contador] = salida;
            }

            registros[contador] += "</Root>";
            return registros;

        }
        catch (Exception Ex)
        {
            String[] registros = new String[1];
            registros[0] = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " < Root > " + "<ERROR>" + Ex.Message.ToString() + "</ERROR>" + "</Root>";
            return registros;
        }
    }
    //Fin Anderson Ardila


    //Autor: Juan Ricardo Gonzalez Sepulveda
    //Fecha: 09/02/2011
    //Consulta RegistroCoumenicaciones enviadas, 
    [WebMethod]
    public string Registrar_Tramite(string DependenciaRemite, string CodDestino, string NomDestino, string WFTipo, string[] RadFuente, string Expediente,
                                     string Naturaleza, string SerieDocumental, string Detalle, string NombreArchivo, byte[] Archivo,
                                     string MetododeEnvio, string guia, string archivaren, string anexos, string copiar, string user, string password)
    {

        Boolean ingreso = Login(user, password);
        if (ingreso == true)
        {
            string Result = null;
            String Descarga = string.Empty;
            String mensaje = "";
            String mensaje2 = "";
            string coderror = string.Empty;
            string procedenciaCodDestino = null;
            string dependenciaCodDestino = CodDestino;
            string registroSalida = string.Empty;

            try
            {
                MembershipUser m = Membership.GetUser("TLINEA");
                String Fecha = Convert.ToString(DateTime.Now);
                if (WFTipo.Trim() == "0")
                {
                    procedenciaCodDestino = CodDestino.Trim();
                    dependenciaCodDestino = null;
                }

                bool registro = RegistrarTramite("2", DateTime.Now, procedenciaCodDestino, dependenciaCodDestino, DependenciaRemite.Trim(), Naturaleza,
                                                 0, Detalle, null, null, null, null, m.ProviderUserKey.ToString(), Expediente.Trim(), "TL", SerieDocumental,
                                                 null, WFTipo, "2", DateTime.Now, DateTime.Now, Convert.ToInt32(WFTipo), Detalle, "0", out registroSalida);
                if (registro)
                {
                    for (int i = 0; i < RadFuente.Length; i++)
                    {
                        bool asocio = AsociarRespuestaARadicado(registroSalida, RadFuente[i].Trim());
                        if (!asocio)
                        {
                            mensaje += mensaje + RadFuente[i].Trim() + " | ";
                        }
                    }
                    if (mensaje != "")
                    {
                        mensaje = "Ocurrio un problema al intentar asociar el registro con algun radicado. " + mensaje;
                        coderror = "3";
                    }

                    Descarga = AdjuntarImgReg(registroSalida, NombreArchivo, Archivo, user, password);

                    if (Descarga == "Proceso Finalizado")
                    {
                        Result = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<Root>" + "<RegistroCodigo>" + registroSalida + "</RegistroCodigo>" + "<WFMovimientoFecha>" +
                                Fecha + "</WFMovimientoFecha>" + "<ExpedienteCodigo>" + Expediente + "</ExpedienteCodigo>" + "</Root>";
                    }
                    else
                    {
                        mensaje2 = " No se pudo adjuntar la imagen al registro.";
                        Result = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<Root>" + "<RegistroCodigo>" + registroSalida + "</RegistroCodigo>" + "<WFMovimientoFecha>" +
                                Fecha + "</WFMovimientoFecha>" + "<ExpedienteCodigo>" + Expediente + "</ExpedienteCodigo>" + "<CodigoError>" + "2" + "</CodigoError>"
                                + "<MensajeError>" + mensaje + mensaje2 + "</MensajeError>" + "</Root>";
                    }
                }
                else
                {
                    Result = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<Root>" + "<RegistroCodigo>" + "" + "</RegistroCodigo>" + "<WFMovimientoFecha>" +
                                Fecha + "</WFMovimientoFecha>" + "<ExpedienteCodigo>" + Expediente + "</ExpedienteCodigo>" + "<CodigoError>" + "1" + "</CodigoError>"
                                + "<MensajeError>" + registroSalida + "</MensajeError>" + "</Root>";
                }
                return Result;
            }
            catch (Exception ex)
            {
                string Resultex;

                CrearLog(ex.Message);
                Resultex = "Ocurrio un problema al Registrar. ";
                //Exception inner = Error.InnerException;
                Resultex += ErrorHandled.FindError(ex);
                Resultex += " " + ex.Message;
                Result = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<Root>" + "<RegistroCodigo></RegistroCodigo>" +
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

    private bool RegistrarTramite(String GrupoCodigo, DateTime WFMovimientoFecha, String ProcedenciaCodDestino, String DependenciaCodDestino, String DependenciaCodigo,
                              String NaturalezaCodigo, int RadicadoCodigo, String RegistroDetalle, String RegistroGuia, String RegPesoEnvio, String RegistroEmpGuia,
                              String AnexoExtRegistro, String LogDigitador, String ExpedienteCodigo, String MedioCodigo, String SerieCodigo, String RegValorEnvio,
                              String RegistroTipo, String WFAccionCodigo, DateTime WFMovimientoFechaEst, DateTime WFMovimientoFechaFin, int WFMovimientoTipo,
                              String WFMovimientoNotas, String WFMovimientoMultitarea, out string Result)
    {
        DalWebService dal = null;
        string error = string.Empty;
        try
        {
            String UserId;
            MembershipUser user = Membership.GetUser();
            if (user != null)
            {
                Object CodigoRuta = user.ProviderUserKey;
                UserId = Convert.ToString(CodigoRuta);
            }
            else
            {
                UserId = LogDigitador;
                LogDigitador = "TLINEA";
            }

            dal = new DalWebService();

            error = dal.RegistrarTramite(out Result, GrupoCodigo, WFMovimientoFecha, ProcedenciaCodDestino, DependenciaCodDestino,
                                      DependenciaCodigo, NaturalezaCodigo, RadicadoCodigo, RegistroDetalle, RegistroGuia,
                                      RegistroEmpGuia, AnexoExtRegistro, LogDigitador, ExpedienteCodigo, MedioCodigo, SerieCodigo,
                                      RegPesoEnvio, RegValorEnvio, RegistroTipo, WFAccionCodigo, WFMovimientoFechaEst,
                                      WFMovimientoFechaFin, WFMovimientoTipo, WFMovimientoNotas, WFMovimientoMultitarea, UserId);
            if (error != "OK")
            {
                Result = error;
                CrearLog("Error realizando el proceso de registro. " + Result);
                return false;
            }
            else
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            CrearLog("Error realizando el proceso de registro. " + ex.Message);
            Result = "Error durante el proceso de registro. Metodo privado RegistrarTramite.";
            return false;
        }
    }

    private bool AsociarRespuestaARadicado(string registro, string radicado)
    {
        DalWebService dal = null;
        try
        {
            dal = new DalWebService();

            dal.AsociarRespuestaARadicado(Convert.ToInt32(registro.Trim()), Convert.ToInt32(radicado.Trim()));
            return true;
        }
        catch (Exception ex)
        {
            CrearLog("Error asociando respuesta a radicado. " + ex.Message);
            return false;
        }
    }
    //[WebMethod]
    //public string AdjuntarImgReg(String Registro, String NombreArchivo, Byte[] oArchivo)
    //{

    //    try
    //    {
    //        String[] Extension = NombreArchivo.Split('.');
    //        String TipoArchivo = Extension[Extension.Length - 1];
    //        TipoArchivo = TipoArchivo.ToLower();

    //        if (oArchivo.Length >= 10240000)
    //        {
    //            return "El tamaño del archivo no corresponde con el maximo permitido";
    //        }
    //        if (TipoArchivo == "docx" || TipoArchivo == "doc" || TipoArchivo == "xls" || TipoArchivo == "xlsx" || TipoArchivo == "pdf" || TipoArchivo == "tif" || TipoArchivo == "tiff" || TipoArchivo == "jpg" || TipoArchivo == "txt" || TipoArchivo == "cvs" || TipoArchivo == "rtf" || TipoArchivo == "zip" || TipoArchivo == "rar")
    //        {
    //            String Grupo = "Registros";
    //            String Ano = DateTime.Today.Year.ToString();
    //            String Mes = DateTime.Today.Month.ToString();

    //            String PathVirtual = HttpContext.Current.Server.MapPath("~/AlfaNetRepositorioImagenes/" + Grupo + "/" + Ano + "/" + Mes + "/");

    //            DSImagenTableAdapters.RegistroImagenTableAdapter TARegistroImagen = new DSImagenTableAdapters.RegistroImagenTableAdapter();

    //            DSImagenTableAdapters.ImagenRutaTableAdapter TAImgRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();
    //            DSImagen.ImagenRutaDataTable DTImgRuta = new DSImagen.ImagenRutaDataTable();

    //            Object CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "2");
    //            int codigoR = Convert.ToInt32(CodigoRuta);

    //            if (CodigoRuta == null)
    //            {
    //                TAImgRuta.Insert(2, "", DateTime.Today.Year, DateTime.Today.Month, 2, PathVirtual);
    //            }
    //            CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "2");
    //            codigoR = Convert.ToInt32(CodigoRuta);
    //            if (!Directory.Exists(PathVirtual))
    //            {
    //                Directory.CreateDirectory(PathVirtual);
    //            }
    //            NombreArchivo = Registro + "2" + Ano + Mes + DateTime.Today.Day.ToString() + NombreArchivo;
    //            TARegistroImagen.InsertRegistroImagen("2", Convert.ToInt32(Registro), NombreArchivo, codigoR);

    //            System.IO.File.WriteAllBytes(@PathVirtual + NombreArchivo, oArchivo);

    //            return "Proceso Finalizado";
    //        }
    //        else
    //        {
    //            return "El formato no corresponde con los permitidos(Word, Excel, Pdf, Jpg, Tif, Zip, Rar, Csv, Rtf)";
    //        }




    //    }

    //    catch (Exception Ex)
    //    {
    //        return Ex.Message.ToString();
    //    }

    //}
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
        if (strUser == "usersage" && strPwd == "0qLpWZIlpg2zlKSYcj0D")
            return "Login usuario";
        else
            return null;
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
                return "No fue posible adjuntar la imagen. " + Ex.Message.ToString();
            }
        }
        else
        {
            return "<Error>" + "El usuario o la clave esta mal escrito" + "</Error>";
        }
    }
    [WebMethod]
    public string ArchivarDocumento(string[] DocumentoCodigo, string SerieCodigo, string user, string password)
    {
        Boolean ingreso = Login(user, password);
        if (ingreso)
        {
            string serieCodigo = SerieCodigo.Trim();
            //string documento = DocumentoCodigo.Trim();
            string mensaje = string.Empty;
            //bool valido = ValidarDatos(documento, serieCodigo, out mensaje);
            //if (valido == false)
            //{
            //    CrearLog(mensaje);
            //    return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<Root>" + "<Error>" + "Se encontro el Siguiente Error: " + mensaje + "</Error>" + "</Root>";
            //}

            string resultado = string.Empty;
            string sumary = string.Empty;
            DalWebService dal = null;
            try
            {
                dal = new DalWebService();
                for (int i = 0; i < DocumentoCodigo.Length; i++)
                {
                    resultado = dal.asignarTramite(DocumentoCodigo[i].Trim(), serieCodigo);
                    if (resultado != "OK")
                    {
                        sumary += DocumentoCodigo[i].Trim() + " | ";
                        CrearLog(resultado);
                    }
                }

                if (sumary == string.Empty)
                {
                    return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " <Root> " + "<Mensaje>Proceso finalizado exitosamente</Mensaje>" + "</Root>";
                }
                else
                {
                    return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<Root>" + "<Mensaje>" + "Los siguientes radicados no pudieron ser archivados: " + sumary + "</Mensaje>" + "</Root>";
                }
            }
            catch (Exception ex)
            {
                CrearLog(ex.Message);
                return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " <Root> " + "<Mensaje>Ocurrio un error al realizar el proceso solicitado</Mensaje>" + "</Root>";
            }
        }
        else
        {
            return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " <Root> " + "<Error>" + "Usuario o contraseña incorrecta" + "</Error>" + "</Root>";
        }
    }
    //private bool ValidarDatos(string documento, string serie, out string message)
    //{
    //    DalWebService dal = null;
    //    try
    //    {
    //        if (documento == "" || serie == "")
    //        {
    //            message = "Faltan parámetros obligatorios.";
    //            return false;
    //        }
    //        dal = new DalWebService();
    //        int valDocumento = dal.ValidarDocumento(documento);
    //        if (valDocumento == 0)
    //        {
    //            message = "El documento que intenta archivar no existe.";
    //            return false;
    //        }
    //        int valSerie = dal.ValidarSerie(serie);
    //        if (valSerie == 0)
    //        {
    //            message = "La serie a la que intenta archivar el documento no existe.";
    //            return false;
    //        }
    //        message = "Validación correcta.";
    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
}