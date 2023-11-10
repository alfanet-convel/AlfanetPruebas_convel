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



public partial class _Devoluciones : System.Web.UI.Page
{
    PrestamosBLL Prestamos = new PrestamosBLL();
    DSPrestamos.PrestamosDataTable DTPrestamos = new DSPrestamos.PrestamosDataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
                       
            this.HFmGrupo.Value = "1";
            this.HFmTipo.Value = "1";
            this.HFmDepCod.Value = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
            this.HFmFecha.Value = DateTime.Now.ToString();

            LblDocRecExtVen.Text = ((DataView)(ODSDocRecExtVen.Select())).Table.Rows.Count.ToString();

            LblDocRecExt.Text = LblDocRecExtVen.Text;
                       
        }
        else
        {

        }
        

    }

    protected void TreeVDependencia_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolDep = new ArbolesBLL();
        DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
        DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
        PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre");
    }
     
   
    protected void TreeVAccion_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        DSAccionTableAdapters.WFAccion_SelectByTextTableAdapter TADSWFA = new DSAccionTableAdapters.WFAccion_SelectByTextTableAdapter();
        DSAccion.WFAccion_SelectByTextDataTable DTWFAccion = new DSAccion.WFAccion_SelectByTextDataTable();
        DTWFAccion = TADSWFA.GetWFAccionTreeDataBy(e.Node.Value);
        PopulateNodes(DTWFAccion, e.Node.ChildNodes, "WFAccionCodigo", "WFAccionNombre");
    }
    
    
  
    protected void TreeVSerie_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolSer = new ArbolesBLL();
        DSSerieSQL.SerieByTextDataTable DTSerie = new DSSerieSQL.SerieByTextDataTable();
        DTSerie = ObjArbolSer.GetSerieTree(e.Node.Value);
        PopulateNodes(DTSerie, e.Node.ChildNodes, "SerieCodigo", "SerieNombre");
              
    }
    private void PopulateNodes(DataTable dt, TreeNodeCollection nodes, String Codigo, String Nombre)
    {
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();
            //dr["title"].ToString();
            tn.Text = dr[Codigo].ToString() + " | " + dr[Nombre].ToString();
            tn.Value = dr[Codigo].ToString();
            tn.NavigateUrl = "javascript:void(0);";
            nodes.Add(tn);

            //If node has child nodes, then enable on-demand populating
            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
        }
    }
 
    protected void BtnTerminarDocrecVen_Click(object sender, EventArgs e)
    {
        try
        {
            this.LblMessageBox.Text = "";
            Terminartarea(GVDocRecExtVen, ODSDocRecExtVen, LblDocRecExtVen);
           
        }
        catch (Exception Error)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de descargar el documento. ";
            Exception inner = Error.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.LblMessageBox.Text += Error.Message.ToString();
            this.MPEMensaje.Show();
        }
        finally
        {

        }
    }  
  
    
    protected void Terminartarea(GridView GV,ObjectDataSource ODS,Label LblLocal)
    {
        bool atLeastOneRowSelected = false;
        // Iterate through the Products.Rows property
        foreach (GridViewRow row in GV.Rows)
        {
            // Access the CheckBox
            CheckBox cb = (CheckBox)row.FindControl("SelectorDocumento");

          
            if (cb != null && cb.Checked)
            {
                //// Delete row! (Well, not really...)
                atLeastOneRowSelected = true;
              
                    //// First, get the DocumentID for the selected row
                    int mPrestamoCodigo= Convert.ToInt32(GV.DataKeys[row.RowIndex].Values[0]);

                    string mDependenciaCodigo = GV.DataKeys[row.RowIndex].Values[2].ToString();
                    string mGrupoCodigo = GV.DataKeys[row.RowIndex].Values[5].ToString();

                    // por definir ...
                    DateTime mWFMovimientoFecha = Convert.ToDateTime(GV.DataKeys[row.RowIndex].Values[1].ToString());
                    DateTime mWFMovimientoFechaDevolucion = DateTime.Now;
                   
                    string mSerieCodigo =  GV.DataKeys[row.RowIndex].Values[3].ToString();
                    string mPestamoCarpeta = GV.DataKeys[row.RowIndex].Values[4].ToString();

                    String PrestamoCodigo = Prestamos.Terminar_Prestamos(Convert.ToString(mPrestamoCodigo), mGrupoCodigo, mWFMovimientoFechaDevolucion, "0");

                
                        MailBLL Correo = new MailBLL();
                        MembershipUser usuario;
                        DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter ObjTaUsuarioxDependencia = new DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter();
                        DSUsuario.UsuariosxdependenciaDataTable DTUsuariosxDependencia = new DSUsuario.UsuariosxdependenciaDataTable();
            
                        DTUsuariosxDependencia = ObjTaUsuarioxDependencia.GetUsuariosxDependenciaByDependencia(mDependenciaCodigo);
                        if (DTUsuariosxDependencia.Count > 0)
                        {
                            DataRow[] rows = DTUsuariosxDependencia.Select();
                            System.Guid a = new Guid(rows[0].ItemArray[0].ToString().Trim());
                            usuario = Membership.GetUser(a);
                            string Body = "Realizo la Devolucion del Prestamo Nro " + mPrestamoCodigo + "<BR>" + " Fecha de Prestamo: " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
                            Correo.EnvioCorreo("soporte.archivar@gmail.com", usuario.Email, "Radicado Nro" + " " + mPrestamoCodigo, Body, true, "1");
                        }

                        this.LblMessageBox.Text += string.Format("Se descargo el Prestamo {0}", mPrestamoCodigo);
                    this.LblMessageBox.Text += " de su escritorio<br />";
               
                
            }
        }
        if (atLeastOneRowSelected == true)
        {
            ODS.DataBind();
            GV.DataBind();
            LblLocal.Text = ((DataView)(ODS.Select())).Table.Rows.Count.ToString();
            LblDocRecExt.Text = (Convert.ToInt16(LblDocRecExtVen.Text).ToString());
            this.MPEMensaje.Show();
        }
        else
        {
            this.LblMessageBox.Text = "No selecciono documentos para descargar de su escritorio.";
            this.MPEMensaje.Show();
        }
        
       
    }

  
 
   
    private void ToggleCheckState(bool checkState, GridView GV)
    {
        // Iterate through the Products.Rows property
        foreach (GridViewRow row in GV.Rows)
        {
            // Access the CheckBox
            CheckBox cb = (CheckBox)row.FindControl("SelectorDocumento");
            if (cb != null)
                cb.Checked = checkState;
        }
    }
    protected void LnkBtnSelTodosGVDocRecExtVen_Click(object sender, EventArgs e)
    {
        ToggleCheckState(true, GVDocRecExtVen);
    }
    protected void LnkBtnSelNingunoGVDocRecExtVen_Click(object sender, EventArgs e)
    {
        ToggleCheckState(false, GVDocRecExtVen);
    } 
    protected void ImgBtnFindProcedencia_Click(object sender, ImageClickEventArgs e)
    {
        if (TxtProcedencia.Text != "")
        {
            
        }
        else
        {
            this.ODSDocRecExtVen.DataBind();
        }
        
    }
    protected void GVDocRecExtVen_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((CheckBox)e.Row.FindControl("SelectorDocumento")).Attributes.Add("onClick", "ColorRow(this);");

        }
    }
    protected void ImgBtnFindDependencia_Click(object sender, ImageClickEventArgs e)
    {
        if (TextBox5.Text != "")
        {

        }
        else
        {
            this.ObjectDataSource1.DataBind();
        }
    }
    
}
