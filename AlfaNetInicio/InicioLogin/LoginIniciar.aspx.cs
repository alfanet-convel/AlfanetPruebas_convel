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

public partial class LoginIniciar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DSInfoTableAdapters.Info_ReadInfoTableAdapter TAInfo = new DSInfoTableAdapters.Info_ReadInfoTableAdapter();
        DSInfo.Info_ReadInfoDataTable DTInfo = new DSInfo.Info_ReadInfoDataTable();

        DTInfo = TAInfo.GetInfoAlfaNet();
        this.Label1.Text = "Licenciado a: " + DTInfo[0].empresa.ToString();
        //ARCHIVAR LTDA";

        if (!IsPostBack)
        {
            //Recordar el usuario de ser necesario
            HttpCookie LaCookie = null;
            LaCookie = this.Request.Cookies["alfaUsuario"];
            if (LaCookie != null)
            {
                TextBox alfaUsuario = (TextBox)Login1.FindControl("UserName");
                alfaUsuario.Text = LaCookie.Value;
            }

            LaCookie = this.Request.Cookies["alfaRecordar"];
            if (LaCookie != null && "true" == LaCookie.Value)
            {
                CheckBox alfaRecordar = (CheckBox)Login1.FindControl("RememberMe");
                alfaRecordar.Checked = true;
                Login1.RememberMeSet = true;
            }
        }
        

    }
   
        
    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        HttpCookie LaCookie = null;
        CheckBox Recordarme = (CheckBox)Login1.FindControl("RememberMe");
        TextBox alfaUsuario = (TextBox)Login1.FindControl("UserName");
        TextBox alfaPassword = (TextBox)Login1.FindControl("Password");
        

        if (Recordarme.Checked)
        {
            //Preservar el deseo del usuario de recordar los datos
            LaCookie = new HttpCookie("alfaRecordar", "true");
            LaCookie.Expires = DateTime.Now.AddDays(5);
            this.Response.Cookies.Add(LaCookie);

            //Preservar el usuario
            LaCookie = new HttpCookie("alfaUsuario", alfaUsuario.Text.ToString());
            LaCookie.Expires = DateTime.Now.AddDays(5);
            this.Response.Cookies.Add(LaCookie);

            //Preservar el password
            LaCookie = new HttpCookie("alfaPassword", alfaPassword.Text.ToString());
            LaCookie.Expires = DateTime.Now.AddDays(5);
            this.Response.Cookies.Add(LaCookie);

        }
        else
        {
            LaCookie = new HttpCookie("alfaRecordar");
            LaCookie.Expires = DateTime.Now.AddDays(-1);
            this.Response.Cookies.Add(LaCookie);
            
            LaCookie = new HttpCookie("alfaUsuario");
            LaCookie.Expires = DateTime.Now.AddDays(-1);
            this.Response.Cookies.Add(LaCookie);
            
            LaCookie = new HttpCookie("alfaPassword");
            LaCookie.Expires = DateTime.Now.AddDays(-1);
            this.Response.Cookies.Add(LaCookie);
        }
        
    }
    protected void Login1_LoginError(object sender, EventArgs e)
    {
        TextBox alfaUsuario = (TextBox)Login1.FindControl("UserName");
        MembershipUser Usuario = Membership.GetUser(alfaUsuario.Text);
        
        if(null != Usuario && !Usuario.IsApproved)
        {
            this.Login1.FailureText = "El intento de conexión falló, el usuario \"" + alfaUsuario.Text.ToString() + "\" está inactivo";
        }
    }
}
