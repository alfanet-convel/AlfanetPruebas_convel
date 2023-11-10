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

using System.Data.SqlClient;
using System.Drawing;
using System.IO;

public partial class Imagen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Recuperamos el paramento con el id de imagen
        string codImagen = Request["codImagen"];
        string strcnn = ConfigurationManager.ConnectionStrings["ConnStrSQLServer"].ConnectionString;
        SqlConnection cnn = new SqlConnection(strcnn);

        string cmd = "Select Imagen From RegistroImagenes where ImagenesId=@ImagenesId";

        SqlCommand comm = new SqlCommand(cmd, cnn);
        comm.Parameters.Add(new SqlParameter("@ImagenesId", SqlDbType.Int)).Value = codImagen;
        
        try
        {

            cnn.Open();
            //Recuperamos la imagen de la Base de datos
            byte[] imagen = (byte[])comm.ExecuteScalar();
            MemoryStream imageStream = new MemoryStream(imagen);
            Response.Clear();
            Response.ContentType = "image/jpeg";
            //Mostramos la imagen en la página directamente
            imageStream.WriteTo(Response.OutputStream);

        }
        catch (SqlException err)
        {
            Response.Clear();
            Response.Write("Error:" + err.Message.ToString());

        }
        finally
        {

            cnn.Close();

        }

    }
}
