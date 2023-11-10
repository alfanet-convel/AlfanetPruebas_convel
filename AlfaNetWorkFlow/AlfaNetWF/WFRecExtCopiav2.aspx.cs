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

public partial class AlfaNetWorkFlow_WFRecVen : System.Web.UI.Page
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


    /*metodo para insertar el número máximo de elementos por página*/
    protected void ODSDocRecExtVen_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        if (!e.ExecutingSelectCount)
        {
            e.Arguments.MaximumRows = 10;
            e.InputParameters.Add("e", e);
        }
    }



    /*Prepara los datos a llenar*/

    protected void ASPxGVDocRecExtCopia_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {

            ASPxRowBoundCopiaEnv(ASPxGVDocRecExtCopia, e, sender);
        }
    }


    /*Llenar los campos referentes a documentos copia enviados*/

    protected void ASPxRowBoundCopiaEnv(ASPxGridView GV, ASPxGridViewTableRowEventArgs GVR, Object sender)
    {
        GridViewDataColumn colReg =
                ((ASPxGridView)sender).Columns["Registro&lt;br/&gt;No."] as GridViewDataColumn;
        GridViewDataColumn colVB =
               ((ASPxGridView)sender).Columns["V.B"] as GridViewDataColumn;
        GridViewDataColumn colOpc =
               ((ASPxGridView)sender).Columns["Opciones"] as GridViewDataColumn;


        /*Obtiene los valores de los hiddenfield en opciones*/

        HiddenField Grupo =
            (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HFGrupo");
        HiddenField Expediente =
            (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HFExpediente");
        if (Expediente.Value == "")
        {
            Expediente.Value = "30001";
        }

        /*Insertar el metodo para el checkbox de visto bueno*/

        ((CheckBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colVB, "SelectorDocumento")).Attributes.Add("onClick", "ColorRow(this);");

        /*Insertar el método del hiperlink del numero de registro*/

        HyperLink NroDoc =
            (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colReg, "HyperLink1");
        NroDoc.Attributes.Add("onClick", "urlInt(event," + Grupo.Value + ");");

        /*Añadir las funciones en los hyperlinks de la columna opciones*/
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkImgExtVen")).Attributes.Add("onClick", "VImagenes(event," + NroDoc.Text + "," + Grupo.Value + ");");
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkHisExtven")).Attributes.Add("onClick", "HistoricoReg(event," + NroDoc.Text + "," + Grupo.Value + ");");
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkExp")).Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + Expediente.Value + "'," + Grupo.Value + ");");


        /*
        ((LinkButton)GVR.Row.FindControl("linkButton5")).Attributes.Add("onClick", "urlInt(event);");
        HyperLink NroDoc = ((HyperLink)GVR.Row.FindControl("HyperLink1"));

        HyperLink Expediente = new HyperLink();
        String ID = GVR.Row.NamingContainer.ID;

        if (ID == "GVDocEnvExtCopia")
            Expediente.Text = GVDocEnvExtCopia.DataKeys[GVR.Row.RowIndex].Values[5].ToString();
        else
            Expediente.Text = GVDocEnvIntCopia.DataKeys[GVR.Row.RowIndex].Values[5].ToString();
        if (Expediente.Text == "")
        {
            Expediente.Text = "30001";
        }

        HiddenField Grupo = ((HiddenField)GVR.Row.FindControl("HFGrupo"));
        NroDoc.Attributes.Add("onClick", "urlInt(event," + Grupo.Value + ");");
        ((HyperLink)GVR.Row.FindControl("HprLnkImgExtVen")).Attributes.Add("onClick", "VImagenesReg(event," + NroDoc.Text + "," + Grupo.Value + ");");
        ((HyperLink)GVR.Row.FindControl("HprLnkHisExtven")).Attributes.Add("onClick", "HistoricoReg(event," + NroDoc.Text + "," + Grupo.Value + ");");
        ((HyperLink)GVR.Row.FindControl("HprLnkExp")).Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + Expediente.Text + "'," + Grupo.Value + ");");
        CheckBox Chk = ((CheckBox)GVR.Row.FindControl("SelectorDocumento"));
        Chk.Attributes.Add("onClick", "ColorRow(this);");

        TextBox LblNot = (TextBox)GVR.Row.Cells[5].FindControl("TxtDocNotasextven");
        Image ImgNot = (Image)GVR.Row.Cells[5].FindControl("ImgDocNotasExtVen");
        if (LblNot.Text == "")
        {
            ImgNot.Visible = false;
        }*/


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

    

    /**/
    protected void BtnTerminarDocrecVen_Click(object sender, EventArgs e)
    {
        try
        {
            
            this.LblMessageBox.Text = "";
            TerminarCopia(ASPxGVDocRecExtCopia, ODSDocRecCopia, new Label());
            //Terminartarea(GVDocRecExtVen, ODSDocRecExtVen, LblDocRecExtVen);

        }
        catch (Exception Error)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de descargar el documento. ";
            Exception inner = Error.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.LblMessageBox.Text += Error.Message.ToString();
            runjQueryCode("alert(\"" + this.LblMessageBox.Text + "\")");
            //PnlMensaje.Visible = true;
            //this.MPEMensaje.Show();
        }
        finally
        {

        }
    }


    
    /*Sobreescritura del método de terminar copia */
    /*Sobreescritura del método de terminar copia */
    protected void TerminarCopia(ASPxGridView GV, ObjectDataSource ODS, Label LblLocal)
    {

        // Iterate through the Products.Rows property

        // The visible index of the fist row within the current page. 
        int startVisibleIndex = GV.VisibleStartIndex;
        // The number of visible rows displayed within the current page. 
        int visibleRowCount = GV.GetCurrentPageRowValues("V.B").Count;
        // The visible index of the last row within the current page. 
        int endVisibleIndex = startVisibleIndex + visibleRowCount - 1;

        bool atLeastOneRowSelected = false;

        for (int i = startVisibleIndex; i <= endVisibleIndex; i++)
        {

            GridViewDataColumn colVB = GV.Columns["V.B"] as GridViewDataColumn;
            GridViewDataColumn colOpc = GV.Columns["Opciones"] as GridViewDataColumn;
            GridViewDataColumn colPit = GV.Columns["Post<br/>It"] as GridViewDataColumn;

            /*Revisa el checkBox*/
            CheckBox ch1 = (CheckBox)GV.FindRowCellTemplateControl(i, colVB, "SelectorDocumento");

            HiddenField hdWfMovTipo = (HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFWFMovimiento");

            if (ch1 != null && ch1.Checked)
            {

                atLeastOneRowSelected = true;

                // First, get the DocumentID for the selected row
                GridViewDataColumn colDoc = GV.Columns["NumeroDocumento"] as GridViewDataColumn;
                int mNumeroDocumento = Convert.ToInt32(((HyperLink)GV.FindRowCellTemplateControl(i, colDoc, "HyperLink1")).Text.ToString());

                int mWFMovimientoPaso = Convert.ToInt32(((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFWFMovimientoPaso")).Value.ToString());
                DateTime mWFFechaMovimientoFin = DateTime.Now;

                int mWFMovimientoTipoini = Convert.ToInt32(hdWfMovTipo.Value.ToString());


                TextBox TxtNewNotas = ((TextBox)GV.FindRowCellTemplateControl(i, colPit, "TextBox4"));
                string mWFMovimientoNotas = TxtNewNotas.Text;
                string mGrupoCodigo = ((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFGrupo")).Value.ToString();
                string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();



                /*
                    
                TextBox TxtNewNotas = (TextBox)row.Cells[6].FindControl("TextBox4");
                string mWFMovimientoNotas = TxtNewNotas.Text;
                string mGrupoCodigo = GV.DataKeys[row.RowIndex].Values[4].ToString();
                string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                */

                DateTime mWFMovimientoFecha = DateTime.Now;
                DateTime mWFMovimientoFechaEst = DateTime.Now;

                string mWFMovimientoMultitarea = "1";




                DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();

                TAWFMovimiento.WFMovimiento_UpdateWFMovimientoCopia(mNumeroDocumento,
                                                   mWFMovimientoPaso,
                                                   mWFFechaMovimientoFin,
                                                   mWFMovimientoTipoini,
                                                   mWFMovimientoNotas,
                                                   mGrupoCodigo,
                                                   mDependenciaCodOrigen,
                                                   mWFMovimientoMultitarea);

                this.LblMessageBox.Text += string.Format("Se descargo el documento {0}", mNumeroDocumento);
                this.LblMessageBox.Text += " de su escritorio. \\n";
                this.hvcontador.Value = Convert.ToString((Int32.Parse(this.hvcontador.Value.ToString()) + 1));

            }
        }
        if (atLeastOneRowSelected == true)
        {
            GV.DataBind();
            ODS.DataBind();
            LblLocal.Text = ((DataView)(ODS.Select())).Table.Rows.Count.ToString();
            runjQueryCode("alert(\"" + this.LblMessageBox.Text + "\")");
            //this.MPEMensaje.Show();

        }
        else
        {
            this.LblMessageBox.Text = "No selecciono documentos para descargar de su escritorio. \\n";
            runjQueryCode("alert(\"" + this.LblMessageBox.Text + "\")");
            //this.MPEMensaje.Show();
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
