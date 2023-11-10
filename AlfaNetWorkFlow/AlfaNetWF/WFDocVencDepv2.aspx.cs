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
using DevExpress.Web;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxCallbackPanel;
using System.Collections.Generic;
using System.Text;

public partial class AlfaNetWorkFlow_WFRecDep: System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ////////////////////////////////////////////////
            MembershipUser user = Membership.GetUser();
            Object CodigoRuta = user.ProviderUserKey;
            String UserId = Convert.ToString(CodigoRuta);
            ////////////////////////////////////////////////
            // Label5.Visible = false;
            // Panel21.Visible = false;
            this.HFmGrupo.Value = "1";
            this.HFmTipo.Value = "1";
            this.HFmDepCod.Value = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
            this.HFmFecha.Value = DateTime.Now.ToString();

            DataView dv = (DataView)SqlDSMultitarea.Select(DataSourceSelectArguments.Empty);
            string reorderedProducts = (string)dv.Table.Rows[0][0];
            if (reorderedProducts != null)
            {
                this.HFMultiTarea.Value = reorderedProducts;
            }
            else
            {
                this.HFMultiTarea.Value = "0";
            }
        }
    }

    protected void Label5_Init(object sender, EventArgs e)
    {

        //DSWorkFlow.WFMovimientos_ReadAllDependenciasDataTable Datos = new DSWorkFlow.WFMovimientos_ReadAllDependenciasDataTable();
        //DSWorkFlowTableAdapters.WFMovimientos_ReadAllDependenciasTableAdapter Tabla = new DSWorkFlowTableAdapters.WFMovimientos_ReadAllDependenciasTableAdapter();
        //Datos = Tabla.GetData(HFmDepCod);


    }

    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        HiddenField Grupo;
        Grupo = HFmGrupo;
        HyperLink Expediente;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //Expediente.Text = e.Row.
            //Expediente.Text = GV.DataKeys[GVR.Row.RowIndex].Values[6].ToString();
            //if (Expediente.Text == "")
            //{
            //    Expediente.Text = "30001";
            //}
            //HyperLink Expediente = ((HyperLink)e.Row.FindControl
            Label NroDoc = ((Label)e.Row.FindControl("Label18"));
            NroDoc.Attributes.Add("onClick", "url(event," + Grupo.Value + ");");
            ((HyperLink)e.Row.FindControl("HprLnkHisExtven1")).Attributes.Add("onClick", "Historico(event," + NroDoc.Text + "," + Grupo.Value + ");");
            //((HyperLink)e.Row.FindControl("HprLnkExp")).Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + Expediente.Text + "'," + Grupo.Value + ");");
        }
    }

    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ObjectDataSource ODSDoc = ((ObjectDataSource)e.Row.FindControl("ObjectDataReadDocumentos"));
            Label mDato = ((Label)e.Row.FindControl("Label10"));

            ODSDoc.SelectParameters["DependenciaCodigo"].DefaultValue = mDato.Text;
            if (mDato.Text == "")
            {
                Label5.Visible = false;
                Panel21.Visible = false;

            }
            else
            {
                Label5.Visible = false;
                Panel21.Visible = true;
            }

        }
    }

    /*Visualizar los registros asociados al radicado*/
    protected void callbackPanel_Callback(object source, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
    {

        Label LbTitulo = new Label();
        LbTitulo.Text = "Registro Nro.:";
        PnlContent.Controls.Add(LbTitulo);
        PnlContent.Controls.Add(new LiteralControl("<br />"));
        /*Separar los datos de documento y grupo*/
        String s1 = e.Parameter.ToString();
        char[] seps = { '|' };
        String[] Parametros = s1.Split(seps);

        String listDocs = "";

        double Num;

        bool isNum = double.TryParse(Parametros[0].ToString().Trim(), out Num);

        /*Isertar el link referente al registro registro*/

        if (isNum && (Parametros.Length == 2))
        {
            DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter DSRadFuenteReg = new DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter();
            DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable DTRadFuenteReg = new DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable();
            DTRadFuenteReg = DSRadFuenteReg.GetRegistrosRadicadoFuente(Convert.ToInt32(Parametros[0].ToString()), Parametros[1].ToString());

            int i = 1;
            PnlContent.Controls.Add(new LiteralControl("<table valign=\"middle\">"));
            foreach (DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroRow DRRadFuenteReg in DTRadFuenteReg.Rows)
            {
                PnlContent.Controls.Add(new LiteralControl("<tr><td>"));
                HyperLink HprRpta = new HyperLink();
                HprRpta.ID = "HprRpta" + i.ToString();
                HprRpta.Text = DRRadFuenteReg.RegistroCodigo.ToString();
                HprRpta.Target = "_Blank";
                HprRpta.ForeColor = System.Drawing.Color.Blue;
                HprRpta.Font.Underline = true;
                HprRpta.Attributes.Add("onClick", "urlInt(event," + DRRadFuenteReg.GrupoRegistroCodigo + ");");
                PnlContent.Controls.Add(HprRpta);
                PnlContent.Controls.Add(new LiteralControl("</td><td>"));
                System.Web.UI.WebControls.Image ImgRpta = new System.Web.UI.WebControls.Image();
                ImgRpta.ID = "ImgRpta" + i.ToString();
                ImgRpta.Width = new Unit("20px");
                ImgRpta.Height = new Unit("20px");
                ImgRpta.ImageUrl = "~/AlfaNetImagen/iconos/icono_tif.JPG";
                ImgRpta.Attributes.Add("onClick", "VImagenesReg(event," + DRRadFuenteReg.RegistroCodigo + "," + DRRadFuenteReg.GrupoRegistroCodigo + ");");
                PnlContent.Controls.Add(ImgRpta);
                PnlContent.Controls.Add(new LiteralControl("</td></tr>"));

                i += 1;
            }
            PnlContent.Controls.Add(new LiteralControl("</table>"));

        }




    }


    /*función de llamado al modal popup de jquery*/
    private string GetJModalPU()
    {
        StringBuilder b1 = new StringBuilder();
        b1.AppendLine("var id = $(this).attr('href');");
        b1.AppendLine("var maskHeight = $(document).height();");
        b1.AppendLine("var maskWidth = $(window).width();");

        b1.AppendLine("$('#mask').css({'width':maskWidth,'height':maskHeight});");
        b1.AppendLine(" $('#mask').fadeIn(1000);");
        b1.AppendLine(" $('#mask').fadeTo(\"slow\",0.8); ");

        b1.AppendLine("var winH = $(window).height();");
        b1.AppendLine("var winW = $(window).width();");
        b1.AppendLine("$(id).css('top',  winH/2-$(id).height()/2);");
        b1.AppendLine("$(id).css('left', winW/2-$(id).width()/2);");
        b1.AppendLine("$(id).fadeIn(2000);");

        return b1.ToString();
    
    }

    /*funciones para hacer el llamado correspondiente a la función de jquery*/
    private string getjQueryCode(string jsCodetoRun)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("$(document).ready(function() {");
        sb.AppendLine(jsCodetoRun);
        sb.AppendLine(" });");

        return sb.ToString();
    }


    private void runjQueryCode(string jsCodetoRun)
    {

        ScriptManager requestSM = ScriptManager.GetCurrent(this);
        if (requestSM != null && requestSM.IsInAsyncPostBack)
        {
            ScriptManager.RegisterClientScriptBlock(this,
                                                    typeof(Page),
                                                    Guid.NewGuid().ToString(),
                                                    getjQueryCode(jsCodetoRun),
                                                    true);
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(typeof(Page),
                                                   Guid.NewGuid().ToString(),
                                                   getjQueryCode(jsCodetoRun),
                                                   true);
        }
    }

}
