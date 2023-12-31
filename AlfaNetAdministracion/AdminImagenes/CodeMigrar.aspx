<%@ import Namespace="System.IO" %>

<script runat="server" language="C#">

    void Page_Load(Object sender, EventArgs e)
    {        
       if (Request.ContentType.IndexOf("multipart/form-data") < 0)
                return;

            Response.Write(Request.Files.Count.ToString() + " Archivos(s) Fueron Cargados:\r\n\r\n" + "<br/><br/>");

        String Grupo = Session["Grupo"].ToString();

            if (Convert.ToInt32(Grupo) == 1)
            {
                DSImagenTableAdapters.RadicadoImagenTableAdapter TARadicadoImagen = new DSImagenTableAdapters.RadicadoImagenTableAdapter();
                DSImagenTableAdapters.ImagenRutaTableAdapter TAImgRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();
                DSImagen.ImagenRutaDataTable DTImgRuta = new DSImagen.ImagenRutaDataTable();

                Object CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "1");
                int codigoR = Convert.ToInt32(CodigoRuta);

                String GrupoStr = "Radicados";
                String Ano = DateTime.Today.Year.ToString();
                String Mes = DateTime.Today.Month.ToString();

                String PathVirtual = HttpContext.Current.Server.MapPath("~/AlfaNetRepositorioImagenes/" + GrupoStr + "/" + Ano + "/" + Mes + "/");

                if (CodigoRuta == null)
                {
                    TAImgRuta.Insert(1, "", DateTime.Today.Year, DateTime.Today.Month, 1, PathVirtual);
                    CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "1");
                    codigoR = Convert.ToInt32(CodigoRuta);
                }

                if (!Directory.Exists(PathVirtual))
                {
                    Directory.CreateDirectory(PathVirtual);
                }

                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFile objFile = Request.Files[i];
                    String strPath = PathVirtual + "\\" + Path.GetFileName(objFile.FileName);
                    String[] Extension = Path.GetFileName(objFile.FileName).Split('.');
                    String NroRadicado = Extension[0].Trim();
                    try
                    {
                        int Prueba = Convert.ToInt32(NroRadicado);
                        TARadicadoImagen.InsertRadicadoImagen(Grupo,Convert.ToInt32(NroRadicado), Path.GetFileName(objFile.FileName), codigoR);
                        objFile.SaveAs(strPath);

                    }
                    catch (Exception ex)
                    {
                        strPath += " No Corresponde a un radicado";
                    }
                    Response.Write(strPath + "\r\n" + "<br/>");
                }
            }
            //Registro
            if (Convert.ToInt32(Grupo) == 2)
            {
                DSImagenTableAdapters.RegistroImagenTableAdapter TARegistroImagen = new DSImagenTableAdapters.RegistroImagenTableAdapter();
                DSImagenTableAdapters.ImagenRutaTableAdapter TAImgRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();
                DSImagen.ImagenRutaDataTable DTImgRuta = new DSImagen.ImagenRutaDataTable();

                Object CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "2");
                int codigoR = Convert.ToInt32(CodigoRuta);
                String GrupoStr = "Registros";
                String Ano = DateTime.Today.Year.ToString();
                String Mes = DateTime.Today.Month.ToString();

                String PathVirtual = HttpContext.Current.Server.MapPath("~/AlfaNetRepositorioImagenes/" + GrupoStr + "/" + Ano + "/" + Mes + "/");

                if (CodigoRuta == null)
                {
                    TAImgRuta.Insert(1, "", DateTime.Today.Year, DateTime.Today.Month, 2, PathVirtual);
                    CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "2");
                    codigoR = Convert.ToInt32(CodigoRuta);
                }

                if (!Directory.Exists(PathVirtual))
                {
                    Directory.CreateDirectory(PathVirtual);
                }

                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFile objFile = Request.Files[i];
                    String strPath = PathVirtual + "\\" + i + "_"+ DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + "_" + Path.GetFileName(objFile.FileName);
                    string fileName = i + "_" + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + "_" + Path.GetFileName(objFile.FileName); 
                    String[] Extension = Path.GetFileName(objFile.FileName).Split('.');
                    String NroRegistro = Extension[0].Trim();
                    try
                    {
                        int Prueba = Convert.ToInt32(NroRegistro);
                        TARegistroImagen.InsertRegistroImagen(Grupo, Convert.ToInt32(NroRegistro), fileName, codigoR);
                        objFile.SaveAs(strPath);

                    }
                    catch (Exception ex)
                    {
                        strPath += " No Corresponde a un Registro";
                    }
                    Response.Write(strPath + "\r\n" + "<br/>");
                }
            }
            Session.RemoveAll();
            Session.Clear();
                 
    }
</script>
