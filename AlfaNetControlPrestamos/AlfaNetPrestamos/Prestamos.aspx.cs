using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
//using AjaxControlToolKit;

public partial class _Prestamos : System.Web.UI.Page 
{
    PrestamosBLL Prestamos = new PrestamosBLL();
    DSPrestamos.PrestamosDataTable DTPrestamos = new DSPrestamos.PrestamosDataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                this.RFVPrestamo.ValidationGroup = "Buscar";
                this.cmdActualizar.Enabled = false;
                this.cmdAceptar.Enabled = true;
                this.TreeVSerie.Attributes["onClick"] = "return OnTreeClick(event);";
                this.TreeVDependencia.Attributes["onClick"] = "return OnTreeDependenciaClick(event);";  
            }
            else
            {

            }

        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
        }
        
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
            tn.Text = dr[Codigo].ToString() + " | " + dr[Nombre].ToString();
            tn.Value = dr[Codigo].ToString();
            tn.NavigateUrl = "javascript:void(  0 );";
            nodes.Add(tn);

            //If node has child nodes, then enable on-demand populating
            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
        }
    }
    protected void TreeVDependencia_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolDep = new ArbolesBLL();
        DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
        DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
        PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre");
    }
    protected void cmdAceptar_Click(object sender, EventArgs e)
    {
        try
        {
           
            //DSPrestamos.PrestamosDataTable DTPrestamos = new DSPrestamos.PrestamosDataTable();
            String PrestamoCodigo = Prestamos.Create_Prestamos(null, "3", DateTime.Now, this.TxtBDependencia.Text, this.TxtBSerie.Text, TxtBCarpeta.Text);
            //this.ODSPrestamos.InsertParameters["PrestamoCodigo"].DefaultValue = null;
            //this.ODSPrestamos.InsertParameters["GrupoCodigo"].DefaultValue = "3";
            //this.ODSPrestamos.InsertParameters["SerieCodigo"].DefaultValue = this.TxtBSerie.Text;
            //this.ODSPrestamos.InsertParameters["DependenciaCodigo"].DefaultValue = this.TxtBDependencia.Text;
            //this.ODSPrestamos.InsertParameters["WFMovimientoFecha"].DefaultValue = DateTime.Now.ToString();
            //this.ODSPrestamos.InsertParameters["PrestamoCarpeta"].DefaultValue = this.TxtBCarpeta.Text;

            //int PrestamoCodigo = this.ODSPrestamos.Insert();
            this.Label22.Text = "Prestamo Creado Número" + " " + PrestamoCodigo +" Hora de Prestamo: "+DateTime.Now.ToString();
            this.LblMessageBox.Text = "Prestamo Creado Número" + " " + PrestamoCodigo;
            this.ModalPopupExtender1.Show();
            
        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
        }
    }
   
    protected void cmdActualizar_Click(object sender, EventArgs e)
    {
        try
        {
            String PrestamoCodigo = Prestamos.Update_Prestamos(this.TextBox1.Text, "3", Convert.ToDateTime(HFWFMovimientoFecha.Value), this.TxtBDependencia.Text, this.TxtBSerie.Text, TxtBCarpeta.Text, "1");

            this.LblMessageBox.Text = "Prestamo Actualizado Nro" + " " + PrestamoCodigo;
            this.ModalPopupExtender1.Show();
        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
        }
    }
    protected void BtnNuevo_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/AlfaNetControlPrestamos/AlfaNetPrestamos/Prestamos.aspx");
        }
        catch (Exception err)
        {
            this.ExceptionDetails.Text = "Error: " + err.Message.ToString();
        }
    }


    protected void ImgBtn_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            this.RFVPrestamo.ValidationGroup = "";
            this.cmdActualizar.Enabled = true;
            this.cmdAceptar.Enabled = false;
   
            if (TextBox1.Text != "")
            {
                if (TextBox1.Text.Contains(" | "))
                {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.IndexOf(" | "));
                }

            }
            DTPrestamos = Prestamos.GetPrestamosById(Convert.ToInt32(TextBox1.Text));
            
            DataRow[] rows = DTPrestamos.Select();

            this.TxtBSerie.Text = DTPrestamos.Rows[0].ItemArray[4].ToString().Trim()+" | "+ DTPrestamos.Rows[0].ItemArray[6].ToString().Trim();
            this.TxtBDependencia.Text = DTPrestamos.Rows[0].ItemArray[3].ToString().Trim() + " | " + DTPrestamos.Rows[0].ItemArray[7].ToString().Trim();
            this.TxtBCarpeta.Text = DTPrestamos.Rows[0].ItemArray[5].ToString().Trim();
            this.HFWFMovimientoFecha.Value = DTPrestamos.Rows[0].ItemArray[2].ToString().Trim();

        }
        catch (Exception err)
        {
            this.ExceptionDetails.Text = "Error: " + err.Message.ToString();
        }
    }
}
