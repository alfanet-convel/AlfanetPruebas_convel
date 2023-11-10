using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AjaxControlToolkit;
using ASP;
using Microsoft;
using Infragistics.Shared;
using Infragistics.WebUI.UltraWebGrid;


public partial class _WorkFlow : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            WorkFlowBLL b1 = new WorkFlowBLL();
            ////////////////////////////////////////////////
            MembershipUser user = Membership.GetUser();
            Object CodigoRuta = user.ProviderUserKey;
            String UserId = Convert.ToString(CodigoRuta);
            ////////////////////////////////////////////////

            /*asignar el total de resultados obtenidos de las consultas*/

            //Recibidos
            LblDocRecExtVen.Text = b1.GetDocVenv1Rowsv2(1,4,Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString(),"1",DateTime.Now).ToString();
            LblDocRecExtProxVen.Text =  b1.GetDocProxVenv1Rowsv2(1,4,Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString(),"1",DateTime.Now).ToString();
            LblDocRecExtPen.Text =  b1.GetDocPendv1Rowsv2(1,4,Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString(),"1",DateTime.Now).ToString();
            LblDocRecCopia.Text = b1.GetDocCopiav1Rowsv2(2, 2, Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString(), "1", DateTime.Now).ToString();

            //Enviados

            LblDocEnvExtCopia.Text = b1.GetDocCopiaEnviadosv1Rowsv2(5, 4, Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString(), "2", DateTime.Now).ToString();
            LblDocEnvExt.Text = b1.GetDocCopiaEnviadosv1Rowsv2(5, 4, Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString(), "2", DateTime.Now).ToString();
            LblDocCopiaInt.Text = b1.GetDocCopiaEnviadosv1Rowsv2(6, 4, Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString(), "2", DateTime.Now).ToString();
            LblDocEnvIntVen.Text = b1.GetDocEnviadosv1Rowsv2(1,Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString(), "2", DateTime.Now,1).ToString();
            
            
            LblDocEnvInt.Text = (Convert.ToInt16(LblDocCopiaInt.Text) + Convert.ToInt16(LblDocEnvIntVen.Text)).ToString();
            LblDocRecExt.Text = (Convert.ToInt16(LblDocRecExtVen.Text) + Convert.ToInt16(LblDocRecExtProxVen.Text) + Convert.ToInt16(LblDocRecExtPen.Text) + Convert.ToInt16(LblDocRecCopia.Text)).ToString();

        }
        else
        {

        }
        

    }

    protected void PrntDataload(object sender, EventArgs ex)
    { 
    
    }


 
}
