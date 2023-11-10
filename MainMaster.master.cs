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

public partial class MainMaster : System.Web.UI.MasterPage
{
    public void showmenu()
    {
        this.WebPanel2.Visible = true;
        this.SiteMapPath1.Visible = true;
        this.LoginViewAlfaNet.Visible = true;
        this.btnCerrar.Visible = false;
        this.LnkCerrar.Visible = false;
    }

    public void hidemenu()
    {
        this.WebPanel2.Visible = false;
        this.SiteMapPath1.Visible = false;
        this.LoginViewAlfaNet.Visible = false;
        this.btnCerrar.Visible = true;
        this.LnkCerrar.Visible = true;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        
        //Page.Form.Attributes.Add("onload", "javascript:(window.close())");
        //}
        //else
        //{

        //}
        
        //UltraWebMenu1.Items[0].TargetUrl = "_blank";

        string Admon = Request["Admon"];
        if (Admon == "S")
        {
            Session["Admon"] = "S";
            hidemenu();
        }
        else if (WebPanel2.Visible = false)
        {
            //Session["Admon"] = "S";
            hidemenu();
        }
        else
        {
            showmenu();
           
        }
        Label m_label = (Label)this.LoginViewAlfaNet.FindControl("LblDependencia");
        if (m_label != null)
            m_label.Text = Profile.GetProfile(Profile.UserName).NombreDepUsuario.ToString() + " | ";
        
        if (SessionTimeOut.IsSessionTimedOut() == true)
            {
               // m_label.Text = "El Tiempo de session ha caducado";
                //Response.Redirect("~", true);
            } 
    }



    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }
   
}
