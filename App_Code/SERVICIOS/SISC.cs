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


/// <summary>
/// Descripción breve de SISC
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class SISC : System.Web.Services.WebService
{

    public SISC()
    {
        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }
        
    [WebMethod]
    public string Radicar_Tramite(string NUI, string Nombre, string Direccion, string Ciudad, string Telefono1, string Telefono2, string Email1, string Email2, string Fax, string Naturaleza, string Dependencia, string Expediente, string Detalle, string URL)
    {
        string coderror = null;
        string url;

        url = URL;
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
            string NombreArchivo = null;

            WebClient Client = new WebClient();

            String Grupo = "Radicados";
            String Ano = DateTime.Today.Year.ToString();
            String Mes = DateTime.Today.Month.ToString();

            String PathVirtual = HttpContext.Current.Server.MapPath("~/AlfaNetRepositorioImagenes/" + Grupo + "/" + Ano + "/" + Mes + "/");

            sizeURL = Convert.ToString(URL.Length);

            if (URL != "")
            {
                if (URL.Contains("\\"))
                {
                    search = URL.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);

                }
                else //if (URL.Contains("/"))
                {
                    search = URL.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                }
                sizeNombre = search.Length;
                NombreArchivo = Convert.ToString(search.GetValue(sizeNombre - 1));

                Client.DownloadFile(URL, PathVirtual + NombreArchivo);
                Client.Dispose();
            }

            String Fecha = Convert.ToString(DateTime.Now);
            RadicarTramiteUAndesTableAdapters.Expediente_RadicarTramiteUATableAdapter Tabla = new RadicarTramiteUAndesTableAdapters.Expediente_RadicarTramiteUATableAdapter();
            RadicarTramiteUAndes.Expediente_RadicarTramiteUADataTable Dtabla = new RadicarTramiteUAndes.Expediente_RadicarTramiteUADataTable();

           /* RadicarTramiteUAndesTableAdapters.Consulta_NuiTableAdapter consultanui = new RadicarTramiteUAndesTableAdapters.Consulta_NuiTableAdapter();
            DataTable existe = new DataTable();
            existe=consultanui.GetData(NUI);

            string a = "";

            foreach (DataRow item in existe.Rows)
            {
                a=item["Column1"].ToString();
            }*/
            string Result;
           /* if (a == "0")
            {
                NUI = "TICS_" + NUI;
               // string mensaje = "Nos Encontramos en mantenimiento por favor comunicarse con Mintic.";
                
               // Result = "<Root>" + "<RadicadoCodigo></RadicadoCodigo>" + "<WFMovimientoFecha></WFMovimientoFecha><ExpedienteCodigo></ExpedienteCodigo>" + "<CodigoError>" + "1" + "</CodigoError>" + "<MensajeError>" + mensaje + "</MensajeError>" + "</Root>";
               // return Result;
            }*/

            
            Dtabla = Tabla.GetData(NUI, Nombre, Direccion, Ciudad, Telefono1, Telefono2, 
                Email1, Email2, Fax, Naturaleza, Dependencia, Expediente, Detalle, url, DateTime.Now);
            coderror = Dtabla[0].ErrorNumber;
            if (coderror == null)
            {
                coderror = "0";
            }
            else
            {
                coderror = "1";
            }
            
            Result = "<Root>" + "<RadicadoCodigo>" + Dtabla[0].RadicadoCodigo + "</RadicadoCodigo>" + "<WFMovimientoFecha>" + Dtabla[0].WFMovimientoFecha + "</WFMovimientoFecha>" + "<ExpedienteCodigo>" + Dtabla[0].ExpedienteCodigo + "</ExpedienteCodigo>" + "<CodigoError>" + coderror + "</CodigoError>" + "<MensajeError>" + Dtabla[0].ErrorMessage + "</MensajeError>" + "</Root>";
            if (URL != "")
            {
                String Descarga = RegistrarImg(URL, Dtabla[0].RadicadoCodigo, PathVirtual, NombreArchivo);
                if (Descarga != null)
                {
                    Result = "<Root>" + "<RadicadoCodigo>" + Dtabla[0].RadicadoCodigo + "</RadicadoCodigo>" + "<WFMovimientoFecha>" + Dtabla[0].WFMovimientoFecha + "</WFMovimientoFecha>" + "<ExpedienteCodigo>" + Dtabla[0].ExpedienteCodigo + "</ExpedienteCodigo>" + "<CodigoError>" + 1 + "</CodigoError>" + "<MensajeError>" + Descarga + "</MensajeError>" + "</Root>";
                }
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
            Result = "<Root>" + "<RadicadoCodigo></RadicadoCodigo>" + "<WFMovimientoFecha></WFMovimientoFecha><ExpedienteCodigo></ExpedienteCodigo>" + "<CodigoError>" + "1" + "</CodigoError>" + "<MensajeError>" + Resultex + "</MensajeError>" + "</Root>";
            return Result;
        }

    }

    public string RegistrarImg(string URL, String Radicado, String PathVirtual, String NombreArchivo)
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

    [WebMethod]
    public String[] ArchivosxTramite(string numerodeidentificacion, string numeroderadicacion, string numerodetramite)
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
    
    //Autor: Juan Ricardo Gonzalez Sepulveda
    //Fecha: 25/06/2011
    //RegistroCoumenicaciones enviadas, 
    [WebMethod]
    public string Registrar_Tramite(string DependenciaRemite, String CodDestino, string NomDestino, string WFTipo, String[] RadFuente, string Expediente, string Naturaleza, String SerieDocumental, string Detalle, String NombreArchivo, Byte[] Archivo)
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

            Descarga = AdjuntarImgReg(Result, NombreArchivo, Archivo);
            if (Descarga == "Proceso Finalizado")
            {
                Result = "<Root>" + "<RadicadoCodigo>" + Result + "</RadicadoCodigo>" + "<WFMovimientoFecha>" + Fecha + "</WFMovimientoFecha>" + "<ExpedienteCodigo>" + Expediente + "</ExpedienteCodigo>" + "<CodigoError>" + coderror + "</CodigoError>" + "<MensajeError>" + "Dtabla[0].ErrorMessage" + "</MensajeError>" + "</Root>";
            }
            else
            {
                Result = "<Root>" + "<RadicadoCodigo>" + Result + "</RadicadoCodigo>" + "<WFMovimientoFecha>" + Fecha + "</WFMovimientoFecha>" + "<ExpedienteCodigo>" + Expediente + "</ExpedienteCodigo>" + "<CodigoError>" + "1" + "</CodigoError>" + "<MensajeError>" + Descarga + "</MensajeError>" + "</Root>";
            }

            return Result;
        }
        catch (Exception ex)
        {
            string Resultex;


            Resultex = "Ocurrio un problema al Radicar. ";
            //Exception inner = Error.InnerException;
            Resultex += ErrorHandled.FindError(ex);
            Resultex += " " + ex.Message;
            Result = "<Root>" + "<RadicadoCodigo></RadicadoCodigo>" + "<WFMovimientoFecha></WFMovimientoFecha><ExpedienteCodigo></ExpedienteCodigo>" + "<CodigoError>" + "1" + "</CodigoError>" + "<MensajeError>" + Resultex + "</MensajeError>" + "</Root>";
            return Result;
        }

    }

    [WebMethod]
    public string AdjuntarImgReg(String Registro, String NombreArchivo, Byte[] oArchivo)
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
                return "El formato no corresponde con los permitidos(Word, Excel, Pdf, Jpg, Tif, Zip, Rar, Csv, Rtf)";
            }




        }

        catch (Exception Ex)
        {
            return Ex.Message.ToString();
        }

    }
   
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
            registros[0] = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " < Root > " + "<ERROR>" + Ex.Message.ToString() + "</ERROR>" + "</Root>";
            return registros;
        }
    }
    //Fin Juan Ricardo Gonzalez Sepulveda
}
