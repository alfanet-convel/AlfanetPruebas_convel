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

    /*metodos para llenar los arboles*/
    protected void TreeVDependencia_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolDep = new ArbolesBLL();
        DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
        DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
        PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre", "0");
    }

    protected void TreeVAccion_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        DSAccionTableAdapters.WFAccion_SelectByTextTableAdapter TADSWFA = new DSAccionTableAdapters.WFAccion_SelectByTextTableAdapter();
        DSAccion.WFAccion_SelectByTextDataTable DTWFAccion = new DSAccion.WFAccion_SelectByTextDataTable();
        DTWFAccion = TADSWFA.GetWFAccionTreeDataBy(e.Node.Value);
        PopulateNodes(DTWFAccion, e.Node.ChildNodes, "WFAccionCodigo", "WFAccionNombre", "0");
    }

    protected void TreeVSerie_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolSer = new ArbolesBLL();
        DSSerieSQL.SerieByTextDataTable DTSerie = new DSSerieSQL.SerieByTextDataTable();
        DTSerie = ObjArbolSer.GetSerieTree(e.Node.Value);
        PopulateNodes(DTSerie, e.Node.ChildNodes, "SerieCodigo", "SerieNombre", "1");

    }

    private void PopulateNodes(DataTable dt, TreeNodeCollection nodes, String Codigo, String Nombre, string SeleccionarNodo)
    {
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();
            //dr["title"].ToString();
            tn.Text = dr[Codigo].ToString() + " | " + dr[Nombre].ToString();
            tn.Value = dr[Codigo].ToString();
            tn.NavigateUrl = "javascript:void(0);";

            if (SeleccionarNodo == "1")
            {
                if (Convert.ToInt32(dr["childnodecount"]) > 0)
                {
                    tn.SelectAction = TreeNodeSelectAction.None;

                }
                else
                {
                }
            }
            else
            {
                //tn.NavigateUrl = "javascript:void(0);";
                tn.SelectAction = TreeNodeSelectAction.Select;
            }

            nodes.Add(tn);

            //If node has child nodes, then enable on-demand populating
            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
        }
    }


    /*Prepara los datos a llenar*/

    protected void ASPxRowBoundEnvIntVen_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {

            ASPxRowBoundEnvIntVen(ASPxGVDocEnvIntVen, e, sender);
        }
    }

    /*Llenar los campos referentes a documentos copia enviados*/

    /*Lllena los campos referentes a documentos recibidos pendientes*/
    protected void ASPxRowBoundEnvIntVen(ASPxGridView GV, ASPxGridViewTableRowEventArgs GVR, Object sender)
    {
        /*Busca las columnas a editar*/
        GridViewDataColumn colReg =
                ((ASPxGridView)sender).Columns["Registro&lt;br/&gt;No."] as GridViewDataColumn;
        GridViewDataColumn colVB =
               ((ASPxGridView)sender).Columns["V.B"] as GridViewDataColumn;
        GridViewDataColumn colOpc =
               ((ASPxGridView)sender).Columns["Opciones"] as GridViewDataColumn;
        GridViewDataColumn colCargar =
               ((ASPxGridView)sender).Columns["Cargar a:"] as GridViewDataColumn;
        GridViewDataColumn colAccion =
               ((ASPxGridView)sender).Columns[11] as GridViewDataColumn;
        GridViewDataColumn colpit =
               ((ASPxGridView)sender).Columns[6] as GridViewDataColumn;
        GridViewDataColumn colvpit =
               ((ASPxGridView)sender).Columns[5] as GridViewDataColumn;


        TextBox mCargar = (TextBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "TxtCargarDocVen");
        TextBox TAcc = (TextBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colAccion, "TxtAccionDocExtVen");

        HyperLink NroDoc = (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colReg, "HyperLink1");

        HiddenField Expediente = (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HFExpediente");
        HiddenField Grupo = (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HFGrupo");

        HiddenField mHFCarga = (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "HFCargar");

        if (Expediente.Value == "")
        {
            Expediente.Value = "30001";
        }

        /*Adicionar las funciones al hyperlink del numero de registro*/
        NroDoc.Attributes.Add("onClick", "urlInt(event," + Grupo.Value + ");");

        /*Adicionar las funciones a los hyperlinks de la columna de opciones*/
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkImgExtVen")).Attributes.Add("onClick", "VImagenes(event," + NroDoc.Text + "," + Grupo.Value + ");");
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkHisExtven")).Attributes.Add("onClick", "HistoricoReg(event," + NroDoc.Text + "," + Grupo.Value + ");");
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkExp")).Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + Expediente.Value + "'," + Grupo.Value + ");");

        /*Insertar el metodo para el checkbox de visto bueno*/

        ((CheckBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colVB, "SelectorDocumento")).Attributes.Add("onClick", "ColorRowVen(this," + mCargar.ClientID + "," + TAcc.ClientID + ");");

        /*Inserta las funcionalidades a los treeview*/

        mCargar.Attributes.Add("onkeydown", "return Disable_Attr(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");

        ((TreeView)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "TreeVDependencia")).Attributes.Add("onClick", "return OnTreeClick2(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");
        ((TreeView)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "TreeVFinalizar")).Attributes.Add("onClick", "return OnTreeClickSerie(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");
        ((TreeView)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "TreeVMultitarea")).Attributes.Add("onClick", "OnTreeClickMultitarea(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");


        /*Controlar la visualizacion de la opcion de ver post it*/

        TextBox LblNot = (TextBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colvpit, "TxtDocNotasextven");
        Image ImgNot = (Image)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colvpit, "ImgDocNotasExtVen");

        if (LblNot.Text == "")
        {
            ImgNot.Visible = false;
        }


        if (HFMultiTarea.Value != "1")
        {
            ((TreeView)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "TreeVMultitarea")).Visible = false;
        }

        /*
         if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox mCargar = ((TextBox)e.Row.FindControl("TxtCargarDocVen"));
            //mCargar.Attributes.Add("onkeypress", "return Disable_Attr(event)");

            TextBox TAcc = (TextBox)e.Row.FindControl("TxtAccionDocExtVen");
            // FORMATEA ROWS
            ((ImageButton)e.Row.FindControl("ImageButton3")).Attributes.Add("onClick", "urlRpta(event);");
            ((LinkButton)e.Row.FindControl("linkButton5")).Attributes.Add("onClick", "urlInt(event);");
            HyperLink NroDoc = ((HyperLink)e.Row.FindControl("HyperLink1"));

            HyperLink Expediente = new HyperLink();
            
            Expediente.Text = GVDocEnvIntVen.DataKeys[e.Row.RowIndex].Values[5].ToString();
          
            if (Expediente.Text == "")
            {
                Expediente.Text = "30001";
            }     

            HiddenField Grupo = ((HiddenField)e.Row.FindControl("HFGrupo"));
            NroDoc.Attributes.Add("onClick", "urlInt(event," + Grupo.Value + ");");
            ((HyperLink)e.Row.FindControl("HprLnkImgExtVen")).Attributes.Add("onClick", "VImagenesReg(event," + NroDoc.Text + "," + Grupo.Value + ");");
            ((HyperLink)e.Row.FindControl("HprLnkHisExtven")).Attributes.Add("onClick", "HistoricoReg(event," + NroDoc.Text + "," + Grupo.Value + ");");
            CheckBox Chk = ((CheckBox)e.Row.FindControl("SelectorDocumento"));
            Chk.Attributes.Add("onClick", "ColorRowVen(this," + mCargar.ClientID + "," + TAcc.ClientID + ");");
            ((HyperLink)e.Row.FindControl("HprLnkExp")).Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + Expediente.Text + "'," + Grupo.Value + ");");
            
            HiddenField mHFCarga = (HiddenField)e.Row.FindControl("HFCargar");


            mCargar.Attributes.Add("onkeydown", "return Disable_Attr(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");

            ((TreeView)e.Row.FindControl("TreeVDependencia")).Attributes.Add("onClick", "return OnTreeClick2(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");
            ((TreeView)e.Row.FindControl("TreeVFinalizar")).Attributes.Add("onClick", "return OnTreeClickSerie(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");
            ((TreeView)e.Row.FindControl("TreeVMultitarea")).Attributes.Add("onClick", "OnTreeClickMultitarea(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");
            TextBox LblNot = (TextBox)e.Row.Cells[5].FindControl("TxtDocNotasextven");
            Image ImgNot = (Image)e.Row.Cells[5].FindControl("ImgDocNotasExtVen");
            if (LblNot.Text == "")
            {
                ImgNot.Visible = false;
            }
            if (HFMultiTarea.Value != "1")
            {
                TreeView TreeMulti = (TreeView)e.Row.FindControl("TreeVMultitarea");
                TreeMulti.Visible = false;

            }
        } 
        */

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
            //TerminarCopia(ASPxGVDocEnvIntVen, ODSDocRecCopia, new Label());
            Terminartarea(ASPxGVDocEnvIntVen, ODSDocEnvIntVen, new Label());

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


    /*Sobrescritura del método de terminar tarea*/
    protected void Terminartarea(ASPxGridView GV, ObjectDataSource ODS, Label LblLocal)
    {
        ////////////////////////////////////////////////
        MembershipUser user = Membership.GetUser();
        Object CodigoRuta = user.ProviderUserKey;
        String UserId = Convert.ToString(CodigoRuta);
        ////////////////////////////////////////////////


        try
        {
            bool atLeastOneRowSelected = false;
            // Iterate through the Products.Rows property

            // The visible index of the fist row within the current page. 
            int startVisibleIndex = GV.VisibleStartIndex;
            // The number of visible rows displayed within the current page. 
            int visibleRowCount = GV.GetCurrentPageRowValues("V.B").Count;
            // The visible index of the last row within the current page. 
            int endVisibleIndex = startVisibleIndex + visibleRowCount - 1;


            for (int i = startVisibleIndex; i <= endVisibleIndex; i++)
            {

                GridViewDataColumn colVB = GV.Columns["V.B"] as GridViewDataColumn;

                GridViewDataColumn colOpc = GV.Columns["Opciones"] as GridViewDataColumn;


                /*Revisa el checkBox*/
                CheckBox ch1 = (CheckBox)GV.FindRowCellTemplateControl(i, colVB, "SelectorDocumento");

                HiddenField hdWfMovTipo = (HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFWFMovimiento");


                //Label Lb10 = (Label)row.FindControl("Label10");
                if (ch1 != null && ch1.Checked)
                {
                    //// Delete row! (Well, not really...)
                    atLeastOneRowSelected = true;


                    /*Si se va el radicado normal (1)*/
                    if (hdWfMovTipo.Value == "1")
                    {
                        //// First, get the DocumentID for the selected row
                        GridViewDataColumn colDoc = GV.Columns[1] as GridViewDataColumn;
                        int mNumeroDocumento = Convert.ToInt32(((HyperLink)GV.FindRowCellTemplateControl(i, colDoc, "HyperLink1")).Text.ToString());

                        //// por definir ...

                        GridViewDataColumn colCarga = GV.Columns["Cargar a:"] as GridViewDataColumn;
                        TextBox TxtDepDesitno = ((TextBox)GV.FindRowCellTemplateControl(i, colCarga, "TxtCargarDocVen"));


                        HiddenField mHFCarga = ((HiddenField)GV.FindRowCellTemplateControl(i, colCarga, "HFCargar"));

                        if (TxtDepDesitno.Text != "")
                        {
                            if (TxtDepDesitno.Text.Contains(" | "))
                            {
                                TxtDepDesitno.Text = TxtDepDesitno.Text.Remove(TxtDepDesitno.Text.IndexOf(" | "));
                            }
                            else
                            {
                                TxtDepDesitno.Text = null;
                            }
                        }
                        else
                        {
                            TxtDepDesitno.Text = null;
                        }

                        string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                        GridViewDataColumn colAccion = GV.Columns["Acci&#243;n:"] as GridViewDataColumn;
                        TextBox TxtNewAccion = ((TextBox)GV.FindRowCellTemplateControl(i, colAccion, "TxtAccionDocExtVen"));

                        //TextBox TxtNewAccion = (TextBox)row.Cells[9].FindControl("TxtAccionDocExtVen");


                        string mWFAccionCodigo = TxtNewAccion.Text;
                        if (mWFAccionCodigo != "")
                        {
                            if (mWFAccionCodigo.Contains(" | "))
                            {
                                mWFAccionCodigo = mWFAccionCodigo.Remove(mWFAccionCodigo.IndexOf(" | "));
                            }
                            else
                            {
                                mWFAccionCodigo = null;
                                TxtNewAccion.Text = null;
                            }
                        }
                        else
                        {
                            mWFAccionCodigo = null;
                            TxtNewAccion.Text = null;
                        }



                        int mWFMovimientoPaso = Convert.ToInt32(((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFWFMovimientoPaso")).Value.ToString());
                        int mWFMovimientoPasoActual = 1;
                        int mWFMovimientoPasoFinal = 0;


                        int mWFMovimientoTipoini = Convert.ToInt32(hdWfMovTipo.Value.ToString());
                        //int mWFMovimientoTipoini = Convert.ToInt32(GV.DataKeys[row.RowIndex].Values[3]);

                        GridViewDataColumn colPit = GV.Columns["Post<br/>It"] as GridViewDataColumn;

                        TextBox TxtNewNotas = ((TextBox)GV.FindRowCellTemplateControl(i, colPit, "TextBox4"));



                        //TextBox TxtNewNotas = (TextBox)row.Cells[6].FindControl("TextBox4");


                        string mWFMovimientoNotas = TxtNewNotas.Text;

                        //string mGrupoCodigo = GV.DataKeys[row.RowIndex].Values[4].ToString();


                        string mGrupoCodigo = ((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFGrupo")).Value.ToString();





                        // por definir ...
                        DateTime mWFMovimientoFecha = DateTime.Now;
                        DateTime mWFMovimientoFechaEst = DateTime.Now;
                        DateTime mWFFechaMovimientoFin = DateTime.Now;
                        // por definir ...
                        string mWFProcesoCodigo = null;

                        string mSerieCodigo;
                        string mDependenciaCodDestino;
                        string mWFMovimientoMultitarea;
                        int mWFMovimientoTipo;

                        if ((mHFCarga.Value == "Dependencia" || mHFCarga.Value == "") && TxtDepDesitno.Text != "" && TxtNewAccion.Text != "")
                        {
                            mDependenciaCodDestino = TxtDepDesitno.Text;
                            if (TxtDepDesitno.Text == "")
                                mDependenciaCodDestino = null;
                            mSerieCodigo = null;
                            mWFMovimientoMultitarea = "0";
                            mWFMovimientoTipo = 1;

                            DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();
                            TAWFMovimiento.InsertaWFMovimiento(mNumeroDocumento,
                                                               mDependenciaCodDestino,
                                                               mWFMovimientoPaso,
                                                               mWFMovimientoPasoActual,
                                                               mWFMovimientoPasoFinal,
                                                               mWFFechaMovimientoFin,
                                                               mWFMovimientoTipo,
                                                               mWFMovimientoTipoini,
                                                               mWFMovimientoNotas,
                                                               mGrupoCodigo,
                                                               mDependenciaCodOrigen,
                                                               mWFProcesoCodigo,
                                                               mWFAccionCodigo,
                                                               mWFMovimientoFecha,
                                                               mWFMovimientoFechaEst,
                                                               mSerieCodigo,
                                                               mWFMovimientoMultitarea,
                                                               UserId
                                                               );


                            //TreeView TreeMulti = (TreeView)row.Cells[8].FindControl("TreeVMultitarea");


                            TreeView TreeMulti = ((TreeView)(GV.FindRowCellTemplateControl(i, colCarga, "TreeVMultitarea")));


                            foreach (TreeNode myNode in TreeMulti.CheckedNodes)
                            {
                                mWFMovimientoMultitarea = "1";
                                mSerieCodigo = null;
                                mDependenciaCodDestino = null;
                                mWFAccionCodigo = "2";
                                if (mGrupoCodigo == "1")
                                {
                                    mWFMovimientoTipo = 2;
                                }
                                else if (mGrupoCodigo == "2")
                                {
                                    mWFMovimientoTipo = 6;
                                }

                                mDependenciaCodDestino = myNode.Value;

                                //DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();
                                TAWFMovimiento.InsertaWFMovimiento(mNumeroDocumento,
                                                                   mDependenciaCodDestino,
                                                                   mWFMovimientoPaso,
                                                                   mWFMovimientoPasoActual,
                                                                   mWFMovimientoPasoFinal,
                                                                   mWFFechaMovimientoFin,
                                                                   mWFMovimientoTipo,
                                                                   mWFMovimientoTipoini,
                                                                   mWFMovimientoNotas,
                                                                   mGrupoCodigo,
                                                                   mDependenciaCodOrigen,
                                                                   mWFProcesoCodigo,
                                                                   mWFAccionCodigo,
                                                                   mWFMovimientoFecha,
                                                                   mWFMovimientoFechaEst,
                                                                   mSerieCodigo,
                                                                   mWFMovimientoMultitarea,
                                                                   UserId
                                                                   );
                            }
                            this.LblMessageBox.Text += string.Format("Se descargó el documento {0}", mNumeroDocumento);
                            this.LblMessageBox.Text += " de su escritorio \\n";
                            String DEpremite = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                            if (DEpremite != TxtDepDesitno.Text)
                            {
                                this.hvcontador.Value = Convert.ToString((Int32.Parse(this.hvcontador.Value.ToString()) + 1));
                            }


                            //this.hvcontador.Value = Convert.ToString((Int32.Parse(this.hvcontador.Value.ToString()) + 1));

                            /*
                            MailBLL Correo = new MailBLL();
                            MembershipUser usuario;
                            DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter ObjTaUsuarioxDependencia = new DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter();
                            DSUsuario.UsuariosxdependenciaDataTable DTUsuariosxDependencia = new DSUsuario.UsuariosxdependenciaDataTable();

                            DTUsuariosxDependencia = ObjTaUsuarioxDependencia.GetUsuariosxDependenciaByDependencia(mDependenciaCodDestino);
                            if (DTUsuariosxDependencia.Count > 0)
                            {
                                DataRow[] rows = DTUsuariosxDependencia.Select();
                                System.Guid a = new Guid(rows[0].ItemArray[0].ToString().Trim());
                                usuario = Membership.GetUser(a);
                                string Body = "Tiene una nueva Tarea Nro " + mNumeroDocumento + "<BR>" + " Fecha de Radicacion: " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + " Accion: " + mWFAccionCodigo + "<BR>";
                                Correo.EnvioCorreo("soporte.archivar@gmail.com", "soporte.archivar@gmail.com", "Tarea Nro" + " " + mNumeroDocumento, Body, true, "1");
                            }*/
                        }

                        else if (mHFCarga.Value == "Serie" && TxtDepDesitno.Text != "")
                        {
                            if (TxtDepDesitno.Text == "")
                            {
                                mSerieCodigo = null;
                                mDependenciaCodDestino = null;

                            }
                            else
                            {
                                mSerieCodigo = TxtDepDesitno.Text;
                                mDependenciaCodDestino = mDependenciaCodOrigen;
                            }
                            mWFMovimientoMultitarea = "0";
                            mWFMovimientoTipo = 3;
                            if (mWFAccionCodigo == null)
                                mWFAccionCodigo = "2";
                            DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();
                            TAWFMovimiento.InsertaWFMovimiento(mNumeroDocumento,
                                                               mDependenciaCodDestino,
                                                               mWFMovimientoPaso,
                                                               0,
                                                               1,
                                                               mWFFechaMovimientoFin,
                                                               mWFMovimientoTipo,
                                                               mWFMovimientoTipoini,
                                                               mWFMovimientoNotas,
                                                               mGrupoCodigo,
                                                               mDependenciaCodOrigen,
                                                               mWFProcesoCodigo,
                                                               mWFAccionCodigo,
                                                               mWFMovimientoFecha,
                                                               mWFMovimientoFechaEst,
                                                               mSerieCodigo,
                                                               mWFMovimientoMultitarea,
                                                               UserId
                                                               );
                            this.LblMessageBox.Text += string.Format("Se descargó el documento {0}", mNumeroDocumento);
                            this.LblMessageBox.Text += " de su escritorio \\n";

                            this.hvcontador.Value = Convert.ToString((Int32.Parse(this.hvcontador.Value.ToString()) + 1));

                        }
                        else if (mHFCarga.Value == "Finalizar")
                        {
                            mWFMovimientoMultitarea = "0";
                            //mWFAccionCodigo = "2";
                            DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();

                            TAWFMovimiento.WFMovimiento_UpdateWFMovimientoCopia(mNumeroDocumento,
                                                               mWFMovimientoPaso,
                                                               mWFFechaMovimientoFin,
                                                               mWFMovimientoTipoini,
                                                               mWFMovimientoNotas,
                                                               mGrupoCodigo,
                                                               mDependenciaCodOrigen,
                                                               mWFMovimientoMultitarea);
                            this.LblMessageBox.Text += string.Format("Se descargó el documento {0}", mNumeroDocumento);
                            this.LblMessageBox.Text += " de su escritorio. \\n";
                            this.hvcontador.Value = Convert.ToString((Int32.Parse(this.hvcontador.Value.ToString()) + 1));

                        }
                        else
                        {
                            this.LblMessageBox.Text += string.Format("Falta uno o mas parámetros para descargar el documento {0}. \\n", mNumeroDocumento);
                            //this.hvcontador.Value = Convert.ToString((Int32.Parse(this.hvcontador.Value.ToString()) + 1));
                        }

                        //this.LblMessageBox.Text += string.Format("Se descargo el documento {0}", mNumeroDocumento);
                        //this.LblMessageBox.Text += " de su escritorio<br />";
                        //this.MPEMensaje.Show();

                    }
                    else if (hdWfMovTipo.Value == "4") /*Si se va el radicado por proceso (4)*/
                    {
                        GridViewDataColumn colDoc = GV.Columns[1] as GridViewDataColumn;

                        GridViewDataColumn colPit = GV.Columns["Post<br/>It"] as GridViewDataColumn;




                        //TextBox TxtNewAccion = ((TextBox)GV.FindRowCellTemplateControl(i, colAccion, "TxtAccionDocExtVen")).Text.ToString();


                        //LinkButton LnkNro = (LinkButton)row.FindControl("LinkButton5");
                        int mNumeroDocumento = Convert.ToInt32(((HyperLink)GV.FindRowCellTemplateControl(i, colDoc, "HyperLink1")).Text.ToString());


                        //int mNumeroDocumento = Convert.ToInt32(GV.DataKeys[row.RowIndex].Values[0]);
                        // por definir ...
                        //string mDependenciaCodDestino = "694";

                        int mWFMovimientoPaso = Convert.ToInt32(((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFWFMovimientoPaso")).Value.ToString());

                        //int mWFMovimientoPaso = Convert.ToInt32(GV.DataKeys[row.RowIndex].Values[2]);

                        DateTime mWFFechaMovimientoFin = DateTime.Now;

                        int mWFMovimientoTipoini = Convert.ToInt32(((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFWFMovimiento")).Value.ToString());


                        //int mWFMovimientoTipoini = Convert.ToInt32(GV.DataKeys[row.RowIndex].Values[3]);

                        // por definir ...


                        TextBox TxtNewNotas = ((TextBox)GV.FindRowCellTemplateControl(i, colPit, "TextBox4"));

                        //TextBox TxtNewNotas = (TextBox)row.Cells[6].FindControl("TextBox4");



                        string mWFMovimientoNotas = TxtNewNotas.Text;


                        string mGrupoCodigo = ((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFGrupo")).Value.ToString();

                        //string mGrupoCodigo = GV.DataKeys[row.RowIndex].Values[4].ToString();

                        string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();


                        string mWFProcesoCodigo = ((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFProceso")).Value.ToString();
                        //string mWFProcesoCodigo = GV.DataKeys[row.RowIndex].Values[5].ToString();

                        // por definir ...
                        //string mWFAccionCodigo = "1";
                        DateTime mWFMovimientoFecha = DateTime.Now;
                        DateTime mWFMovimientoFechaEst = DateTime.Now;
                        // por definir ...
                        //string mSerieCodigo = null;
                        string mWFMovimientoMultitarea = "0";

                        DSWorkFlowTableAdapters.WFMovimientos_CreateRadicadoProcesosTableAdapter TAWFMovPro = new DSWorkFlowTableAdapters.WFMovimientos_CreateRadicadoProcesosTableAdapter();

                        TAWFMovPro.WFMovimientos_CreateRadicadoProcesos(mNumeroDocumento,
                                                                        mWFMovimientoPaso,
                                                                        1,
                                                                        0,
                                                                        mWFFechaMovimientoFin,
                                                                        mWFMovimientoTipoini,
                                                                        mWFMovimientoTipoini,
                                                                        mWFMovimientoNotas,
                                                                        mGrupoCodigo,
                                                                        mDependenciaCodOrigen,
                                                                        mWFProcesoCodigo,
                                                                        mWFMovimientoFecha,
                                                                        mWFMovimientoFechaEst,
                                                                        mWFMovimientoMultitarea);

                        this.LblMessageBox.Text += string.Format("Se descargo el documento {0}", mNumeroDocumento);
                        this.LblMessageBox.Text += " de su escritorio. \\n";
                        this.hvcontador.Value = Convert.ToString((Int32.Parse(this.hvcontador.Value.ToString()) + 1));
                    }


                }


            }
            if (atLeastOneRowSelected == true)
            {
                ODS.DataBind();
                GV.DataBind();
                //LblLocal.Text = ((DataView)(ODS.Select())).Table.Rows.Count.ToString();
                //LblDocRecExt.Text = LblDocRecExt.Text = (Convert.ToInt16(LblDocRecExtVen.Text) + Convert.ToInt16(LblDocRecExtProxVen.Text) + Convert.ToInt16(LblDocRecExtPen.Text) + Convert.ToInt16(LblDocRecCopia.Text)).ToString();
                //this.MPEMensaje.Show();
                runjQueryCode("alert(\"" + this.LblMessageBox.Text + "\");");

                //runjQueryCode("confirm(\"" + this.LblMessageBox.Text + "\", function () {});");
                // Response.Write(@"<script language='javascript'>alert('The following errors have occurred: \\n" + "sasas\\n" + " .');</script>"); 
            }
            else
            {
                this.LblMessageBox.Text = "No selecciono documentos para descargar de su escritorio.";
                //this.MPEMensaje.Show();
                PnlMensaje.Visible = true;
                //runjQueryCode(GetJModalPU());
            }
        }
        catch (Exception Error)
        {
            ODS.DataBind();
            GV.DataBind();
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de descargar el documento. ";
            Exception inner = Error.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.LblMessageBox.Text += Error.Message.ToString();
            runjQueryCode("alert(\"" + this.LblMessageBox.Text + "\");");
            //PnlMensaje.Visible = true;
            //this.MPEMensaje.Show();
        }
        finally
        {

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
