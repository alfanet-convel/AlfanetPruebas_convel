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


public partial class _WorkFlow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //Label m_label = (Label)LoginView1.FindControl("LblDependencia");
        //m_label.Text = Profile.GetProfile(User.Identity.Name).NombreDepUsuario.ToString() + " | ";

        this.HFmGrupo.Value = "1";
        this.HFmTipo.Value = "1";
        this.HFmDepCod.Value = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
        this.HFmFecha.Value = DateTime.Now.ToString();

        LblDocRecExtVen.Text = ((DataView)(ODSDocRecExtVen.Select())).Table.Rows.Count.ToString();
        LblDocRecExtProxVen.Text = ((DataView)(ODSDocRecExtProxVen.Select())).Table.Rows.Count.ToString();
        LblDocRecExtPen.Text = ((DataView)(ODSDocRecExtPen.Select())).Table.Rows.Count.ToString();
        LblDocRecCopia.Text = ((DataView)(ODSDocRecCopia.Select())).Table.Rows.Count.ToString();

        LblDocEnvExtCopia.Text = ((DataView)(ODSDocEnvExt.Select())).Table.Rows.Count.ToString();
        Label12.Text = ((DataView)(ODSDocEnvExt.Select())).Table.Rows.Count.ToString();
        LblDocCopiaInt.Text = ((DataView)(ODSDocEnvInt.Select())).Table.Rows.Count.ToString();
        Label16.Text = ((DataView)(ODSDocEnvIntVen.Select())).Table.Rows.Count.ToString();
        Label14.Text = (Convert.ToInt16(LblDocCopiaInt.Text) + Convert.ToInt16(Label16.Text)).ToString();

        LblDocRecExt.Text = (Convert.ToInt16(LblDocRecExtVen.Text) + Convert.ToInt16(LblDocRecExtProxVen.Text) + Convert.ToInt16(LblDocRecExtPen.Text) + Convert.ToInt16(LblDocRecCopia.Text)).ToString();



        //foreach (GridViewRow row in GVDocRecExtVen.Rows)
        //    {
        //    Panel myPanel = (Panel)row.FindControl("PnlCargarDocVen");
        //    TextBox myTextBox = (TextBox)row.FindControl("TxtCargarDocVen");
        //    TreeView myTV = (TreeView)myPanel.FindControl("TreeVSerie");
        //    myTV.Attributes.Add("onclick", "setTextValue('" + myTextBox.ClientID + "','" + myTV.SelectedValue.ToString() + "','" + myPanel.ClientID + "');");

        //    }


    }
    private void ToggleCheckState(bool checkState)
    {
        // Iterate through the Products.Rows property
        foreach (GridViewRow row in GridView9.Rows)
        {
            // Access the CheckBox
            CheckBox cb = (CheckBox)row.FindControl("SelectorDocumento");
            if (cb != null)
                cb.Checked = checkState;
        }
    }
    protected void BtnTerminar_Click(object sender, EventArgs e)
    {
        try
        {

            this.LblMessageBox.Text = "";
            bool atLeastOneRowSelected = false;

            // Iterate through the Products.Rows property
            foreach (GridViewRow row in GVDocRecExtVen.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("SelectorDocumento");
                if (cb != null && cb.Checked)
                {
                    // Delete row! (Well, not really...)
                    atLeastOneRowSelected = true;

                    // First, get the DocumentID for the selected row
                    int mNumeroDocumento = Convert.ToInt32(GVDocRecExtVen.DataKeys[row.RowIndex].Values[0]);
                    // por definir ...
                    string mDependenciaCodDestino = "694";
                    int mWFMovimientoPaso = Convert.ToInt32(GVDocRecExtVen.DataKeys[row.RowIndex].Values[2]);
                    DateTime mWFFechaMovimientoFin = DateTime.Now;
                    int mWFMovimientoTipo = Convert.ToInt32(GVDocRecExtVen.DataKeys[row.RowIndex].Values[3]);
                    // por definir ...
                    string mWFMovimientoNotas = "Sin notas";
                    string mGrupoCodigo = GVDocRecExtVen.DataKeys[row.RowIndex].Values[4].ToString();
                    string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                    string mWFProcesoCodigo = null;
                    // por definir ...
                    string mWFAccionCodigo = "1";
                    DateTime mWFMovimientoFecha = DateTime.Now;
                    DateTime mWFMovimientoFechaEst = DateTime.Now;
                    // por definir ...
                    string mSerieCodigo = null;
                    string mWFMovimientoMultitarea = "0";

                    DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();

                    //TAWFMovimiento.InsertaWFMovimiento(mNumeroDocumento, 
                    //                                   mDependenciaCodDestino, 
                    //                                   mWFMovimientoPaso,
                    //                                   mWFMovimientoPasoActual,
                    //                                   mWFMovimientoPasoFinal,
                    //                                   mWFFechaMovimientoFin, 
                    //                                   mWFMovimientoTipo, 
                    //                                   mWFMovimientoNotas,
                    //                                   mGrupoCodigo, 
                    //                                   mDependenciaCodOrigen, 
                    //                                   mWFProcesoCodigo,
                    //                                   mWFAccionCodigo, 
                    //                                   mWFMovimientoFecha, 
                    //                                   mWFMovimientoFechaEst,
                    //                                   mSerieCodigo, 
                    //                                   mWFMovimientoMultitarea);

                    this.LblMessageBox.Text += string.Format("Se descargo el documento {0}", mNumeroDocumento);
                    this.LblMessageBox.Text += " de su escritorio<br />";
                }
            }

            if (atLeastOneRowSelected == true)
            {
                ODSDocRec.DataBind();
                ODSDocRecExtVen.DataBind();
                GVDocRecExtVen.DataBind();
                LblDocRecExt.Text = ((DataView)(ODSDocRec.Select())).Table.Rows.Count.ToString();
                LblDocRecExtVen.Text = ((DataView)(ODSDocRecExtVen.Select())).Table.Rows.Count.ToString();
                this.MPEMensaje.Show();
            }
            else
            {
                this.LblMessageBox.Text = "No selecciono documentos para descargar de su escritorio.";
                this.MPEMensaje.Show();
            }

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
    protected void LnkBtnSelTodos_Click(object sender, EventArgs e)
    {
        ToggleCheckState(true);
    }
    protected void LnkBtnSelNinguno_Click(object sender, EventArgs e)
    {
        ToggleCheckState(false);
    }

    protected void TreeVDependencia_SelectedNodeChanged(object sender, EventArgs e)
    {

        //if ((String.IsNullOrEmpty(this.TreeVDependencia.SelectedNode.Text)) == false)
        //{
        // Popup result is the selected task}
        //PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVDependencia.SelectedNode.Text);
        //this.TreeVExpediente.CollapseAll();
        //this.TreeVExpediente.Dispose();
        //}
    }
    protected void TreeVDependencia_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolDep = new ArbolesBLL();
        DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
        DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
        PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre");
    }
    //private void PopulateNodes(DataTable dt, TreeNodeCollection nodes, String Codigo, String Nombre)
    //{
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        TreeNode tn = new TreeNode();
    //        //dr["title"].ToString();
    //        tn.Text = dr[Codigo].ToString() + " | " + dr[Nombre].ToString();
    //        tn.Value = dr[Codigo].ToString();
    //        nodes.Add(tn);

    //        //If node has child nodes, then enable on-demand populating
    //        tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
    //    }
    //}

    //protected void TreeVSerie_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    //{
    //    ArbolesBLL ObjArbolSer = new ArbolesBLL();
    //    DSSerieSQL.SerieByTextDataTable DTSerie = new DSSerieSQL.SerieByTextDataTable();

    //    //DTDependencia = ObjArbolDep.GetDependenciaTree(Int32.Parse(e.Node.Value));
    //    DTSerie = ObjArbolSer.GetSerieTree(e.Node.Value);

    //    PopulateNodes(DTSerie, e.Node.ChildNodes, "SerieCodigo", "SerieNombre");
    //}
    protected void BtnTerminarDocRecExt_Click(object sender, EventArgs e)
    {
        try
        {

            this.LblMessageBox.Text = "";
            bool atLeastOneRowSelected = false;

            // Iterate through the Products.Rows property
            foreach (GridViewRow row in GVDocRecExtVen.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("SelectorDocumento");
                if (cb != null && cb.Checked)
                {
                    // Delete row! (Well, not really...)
                    atLeastOneRowSelected = true;

                    // First, get the DocumentID for the selected row
                    int mNumeroDocumento = Convert.ToInt32(GVDocRecExtVen.DataKeys[row.RowIndex].Values[0]);
                    int mWFMovimientoPaso = Convert.ToInt32(GVDocRecExtVen.DataKeys[row.RowIndex].Values[2]);
                    DateTime mWFFechaMovimientoFin = DateTime.Now;

                    int mWFMovimientoTipo = Convert.ToInt32(GVDocRecExtVen.DataKeys[row.RowIndex].Values[3]);
                    // por definir ...

                    string mWFMovimientoNotas = "Sin notas";
                    string mGrupoCodigo = GVDocRecExtVen.DataKeys[row.RowIndex].Values[4].ToString();
                    string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                    string mWFProcesoCodigo = null;
                    // por definir ...

                    string mWFAccionCodigo = "1";
                    DateTime mWFMovimientoFecha = DateTime.Now;
                    DateTime mWFMovimientoFechaEst = DateTime.Now;
                    // por definir ...
                    string mSerieCodigo = null;

                    TreeView Tree = (TreeView)row.FindControl("TreeVDepIntVen");

                    //int Nro_Nodos = Tree.CheckedNodes.Count;
                    string mWFMovimientoMultitarea;
                    if (Tree.CheckedNodes.Count > 0)
                        mWFMovimientoMultitarea = "1";
                    mWFMovimientoMultitarea = "0";

                    for (int Nro_Nodos = 0; Nro_Nodos < Tree.CheckedNodes.Count; Nro_Nodos++)
                    {
                        String mDependenciaCodDestino = Tree.CheckedNodes[Nro_Nodos].Text;
                        if (mDependenciaCodDestino != "")
                        {
                            if (mDependenciaCodDestino.Contains(" | "))
                            {
                                mDependenciaCodDestino = mDependenciaCodDestino.Remove(mDependenciaCodDestino.IndexOf(" | "));
                            }
                        }
                        DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();

                        //TAWFMovimiento.InsertaWFMovimiento(mNumeroDocumento,
                        //                                   mDependenciaCodDestino,
                        //                                   mWFMovimientoPaso,
                        //                                   mWFFechaMovimientoFin,
                        //                                   mWFMovimientoTipo,
                        //                                   mWFMovimientoNotas,
                        //                                   mGrupoCodigo,
                        //                                   mDependenciaCodOrigen,
                        //                                   mWFProcesoCodigo,
                        //                                   mWFAccionCodigo,
                        //                                   mWFMovimientoFecha,
                        //                                   mWFMovimientoFechaEst,
                        //                                   mSerieCodigo,
                        //                                   mWFMovimientoMultitarea);
                    }
                    // por definir ...
                    this.LblMessageBox.Text += string.Format("Se descargo el documento {0}", mNumeroDocumento);
                    this.LblMessageBox.Text += " de su escritorio<br />";
                }
            }
            if (atLeastOneRowSelected == true)
            {
                ODSDocRec.DataBind();
                ODSDocRecExtVen.DataBind();
                GVDocRecExtVen.DataBind();
                LblDocRecExt.Text = ((DataView)(ODSDocRec.Select())).Table.Rows.Count.ToString();
                LblDocRecExtVen.Text = ((DataView)(ODSDocRecExtVen.Select())).Table.Rows.Count.ToString();
                this.MPEMensaje.Show();
            }
            else
            {
                this.LblMessageBox.Text = "No selecciono documentos para descargar de su escritorio.";
                this.MPEMensaje.Show();
            }
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
    protected void TreeVAccion_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        DSAccionTableAdapters.WFAccion_SelectByTextTableAdapter TADSWFA = new DSAccionTableAdapters.WFAccion_SelectByTextTableAdapter();
        DSAccion.WFAccion_SelectByTextDataTable DTWFAccion = new DSAccion.WFAccion_SelectByTextDataTable();
        DTWFAccion = TADSWFA.GetWFAccionTreeDataBy(e.Node.Value);
        PopulateNodes(DTWFAccion, e.Node.ChildNodes, "WFAccionCodigo", "WFAccionNombre");
    }

    protected void OnSelectMedio(object sender, EventArgs e)
    {
        //if (((LinkButton)sender).Text == "Nombre")
        // this.AutoCompleteMedioRecibo.ServiceMethod = "GetMedioByText";
        //if (((LinkButton)sender).Text == "Codigo")
        //this.AutoCompleteMedioRecibo.ServiceMethod = "GetMedioByTextId";
        //LblSearchMedio.Text = ((LinkButton)sender).Text;
        //this.TxtMedioRecibo.Text = "";
    }
    protected void OnSelect(object sender, EventArgs e)
    {
        try
        {

            this.LblMessageBox.Text = "";
            bool atLeastOneRowSelected = false;

            // Iterate through the Products.Rows property
            foreach (GridViewRow row in GVDocRecExtVen.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("SelectorDocumento");
                if (cb != null && cb.Checked)
                {
                    // Delete row! (Well, not really...)
                    atLeastOneRowSelected = true;
                    //lblSelection.Text = "You selected <b>" + ((LinkButton)sender).Text + "</b>.";           
                    // Access the image
                    Image ImagenDep = (Image)row.FindControl("ImgDepPasoIntVen");
                    Image ImagenOtros = (Image)row.FindControl("ImgDepPasoSigIntVen");
                    Image ImagenArch = (Image)row.FindControl("ImgArchivarIntVen");

                    if (((LinkButton)sender).Text == "Dependencia")
                    {
                        ImagenDep.Visible = true;
                        //this.ImgDepPasoIntVen.Visible = true;
                    }
                    if (((LinkButton)sender).Text == "Archivar")
                    {
                        ImagenArch.Visible = true;
                    }
                    if (((LinkButton)sender).Text == "Otros Tramites")
                    {
                        ImagenDep.Visible = true;
                        ImagenOtros.Visible = true;
                    }
                }
            }
            //if (atLeastOneRowSelected == true)
            //{
            //    //ODSDocRec.DataBind();
            //    //ODSDocRecExtVen.DataBind();
            //    //GVDocRecExtVen.DataBind();
            //    //LblDocRecExt.Text = ((DataView)(ODSDocRec.Select())).Table.Rows.Count.ToString();
            //    //LblDocRecExtVen.Text = ((DataView)(ODSDocRecExtVen.Select())).Table.Rows.Count.ToString();
            //    //this.MPEMensaje.Show();
            //}
            //else
            //{
            //    //this.LblMessageBox.Text = "No selecciono documentos para descargar de su escritorio.";
            //    //this.MPEMensaje.Show();
            //}
        }
        catch (Exception Error)
        {
            //Display a user-friendly message
            //this.LblMessageBox.Text = "Ocurrio un problema al tratar de descargar el documento. ";
            //Exception inner = Error.InnerException;
            //this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            //this.LblMessageBox.Text += Error.Message.ToString();
            //this.MPEMensaje.Show();
        }
        finally
        {

        }
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        //try
        //{

        //    this.LblMessageBox.Text = "";
        //    bool atLeastOneRowSelected = false;

        //    // Iterate through the Products.Rows property
        //    foreach (GridViewRow row in GVDocRecExtVen.Rows)
        //    {
        //        // Access the CheckBox
        //        CheckBox cb = (CheckBox)row.FindControl("SelectorDocumento");
        //        if (cb != null && cb.Checked)
        //        {
        //            // Delete row! (Well, not really...)
        //            atLeastOneRowSelected = true;

        //            // First, get the DocumentID for the selected row
        //            int mNumeroDocumento = Convert.ToInt32(GVDocRecExtVen.DataKeys[row.RowIndex].Values[0]);
        //            // por definir ...
        //            string mDependenciaCodDestino = "694";
        //            int mWFMovimientoPaso = Convert.ToInt32(GVDocRecExtVen.DataKeys[row.RowIndex].Values[2]);
        //            DateTime mWFFechaMovimientoFin = DateTime.Now;
        //            int mWFMovimientoTipo = Convert.ToInt32(GVDocRecExtVen.DataKeys[row.RowIndex].Values[3]);
        //            // por definir ...
        //            string mWFMovimientoNotas = "Sin notas";
        //            string mGrupoCodigo = GVDocRecExtVen.DataKeys[row.RowIndex].Values[4].ToString();
        //            string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
        //            string mWFProcesoCodigo = null;
        //            // por definir ...
        //            string mWFAccionCodigo = "1";
        //            DateTime mWFMovimientoFecha = DateTime.Now;
        //            DateTime mWFMovimientoFechaEst = DateTime.Now;
        //            // por definir ...
        //            string mSerieCodigo = null;
        //            string mWFMovimientoMultitarea = "0";

        //            this.LblMessageBox.Text += string.Format("Se descargo el documento {0}", mNumeroDocumento);
        //            this.LblMessageBox.Text += " de su escritorio<br />";
        //        }
        //    }

        //    if (atLeastOneRowSelected == true)
        //    {
        //        ODSDocRec.DataBind();
        //        ODSDocRecExtVen.DataBind();
        //        GVDocRecExtVen.DataBind();
        //        LblDocRecExt.Text = ((DataView)(ODSDocRec.Select())).Table.Rows.Count.ToString();
        //        LblDocRecExtVen.Text = ((DataView)(ODSDocRecExtVen.Select())).Table.Rows.Count.ToString();
        //        this.MPEMensaje.Show();
        //    }
        //    else
        //    {
        //        this.LblMessageBox.Text = "No selecciono documentos para descargar de su escritorio.";
        //        this.MPEMensaje.Show();
        //    }

        //}
        //catch (Exception Error)
        //{
        //    //Display a user-friendly message
        //    this.LblMessageBox.Text = "Ocurrio un problema al tratar de descargar el documento. ";
        //    Exception inner = Error.InnerException;
        //    this.LblMessageBox.Text += ErrorHandled.FindError(inner);
        //    this.LblMessageBox.Text += Error.Message.ToString();
        //    this.MPEMensaje.Show();
        //}
        //finally
        //{

        //}
        Response.Redirect("~/AlfaNetDocumentos/DocRecibido/DocRecibidoWF.aspx?TipoCodigo=1&RadicadoCodigo=1" + ((LinkButton)sender).Text + "&GrupoCodigo=1&ControlDias=1");
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AlfaNetDocumentos/DocRecibido/DocRecibidoWF.aspx?TipoCodigo=1&RadicadoCodigo=1" + ((LinkButton)sender).Text + "&GrupoCodigo=1&ControlDias=2");
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AlfaNetDocumentos/DocRecibido/DocRecibidoWF.aspx?TipoCodigo=1&RadicadoCodigo=1" + ((LinkButton)sender).Text + "&GrupoCodigo=1&ControlDias=1000");
    }
    protected void BtnTerminarCop_Click(object sender, EventArgs e)
    {
        try
        {

            this.LblMessageBox.Text = "";
            bool atLeastOneRowSelected = false;

            // Iterate through the Products.Rows property
            foreach (GridViewRow row in GridView9.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("SelectorDocumento");
                Label Lb10 = (Label)row.FindControl("Label10");
                if (cb != null && cb.Checked)
                {
                    if (Lb10.Text == "2")
                    {
                        // Delete row! (Well, not really...)
                        atLeastOneRowSelected = true;

                        // First, get the DocumentID for the selected row
                        int mNumeroDocumento = Convert.ToInt32(GridView9.DataKeys[row.RowIndex].Values[0]);
                        // por definir ...
                        //string mDependenciaCodDestino = "694";
                        int mWFMovimientoPaso = Convert.ToInt32(GridView9.DataKeys[row.RowIndex].Values[2]);
                        DateTime mWFFechaMovimientoFin = DateTime.Now;
                        int mWFMovimientoTipoini = Convert.ToInt32(GridView9.DataKeys[row.RowIndex].Values[3]);
                        // por definir ...
                        string mWFMovimientoNotas = "Sin notas";
                        string mGrupoCodigo = GridView9.DataKeys[row.RowIndex].Values[4].ToString();
                        string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                        //string mWFProcesoCodigo = null;
                        // por definir ...
                        //string mWFAccionCodigo = "1";
                        DateTime mWFMovimientoFecha = DateTime.Now;
                        DateTime mWFMovimientoFechaEst = DateTime.Now;
                        // por definir ...
                        //string mSerieCodigo = null;
                        string mWFMovimientoMultitarea = "0";

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
                        this.LblMessageBox.Text += " de su escritorio<br />";
                    }
                    else if (Lb10.Text == "4")
                    {
                        LinkButton LnkNro = (LinkButton)row.FindControl("LnkBtnRecIntCop");
                        int mNumeroDocumento = Convert.ToInt32(GridView9.DataKeys[row.RowIndex].Values[0]);
                        //DSWorkFlowTableAdapters.WFMovimientoTableAdapter ObjWorkFlow = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();
                        //DSWorkFlow.WFMovimientoDataTable DTEnviada = new DSWorkFlow.WFMovimientoDataTable();
                        //DTEnviada = ObjWorkFlow.GetUnDocExtBy(Convert.ToInt32(HFTipoDB.Value), HFDepenOrig.Value, HFGrupo.Value, Convert.ToDateTime(HFWFMovFecha.Value), Convert.ToInt32(HFControlDias.Value), Convert.ToInt32(HFNroRad.Value));
                        //DataRow[] rows = DTEnviada.Select("NumeroDocumento=" + mNumeroDocumentopro);

                        // por definir ...
                        //string mDependenciaCodDestino = "694";
                        int mWFMovimientoPaso = Convert.ToInt32(GridView9.DataKeys[row.RowIndex].Values[2]);
                        DateTime mWFFechaMovimientoFin = DateTime.Now;
                        int mWFMovimientoTipoini = Convert.ToInt32(GridView9.DataKeys[row.RowIndex].Values[3]);
                        // por definir ...
                        string mWFMovimientoNotas = "Sin notas";
                        string mGrupoCodigo = GridView9.DataKeys[row.RowIndex].Values[4].ToString();
                        string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                        string mWFProcesoCodigo = GridView9.DataKeys[row.RowIndex].Values[5].ToString();
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

                    }

                }
            }

            if (atLeastOneRowSelected == true)
            {
                //ODSDocRec.DataBind();
                //ODSDocRecExtVen.DataBind();
                //GVDocRecExtVen.DataBind();
                //LblDocRecExt.Text = ((DataView)(ODSDocRec.Select())).Table.Rows.Count.ToString();
                //LblDocRecExtVen.Text = ((DataView)(ODSDocRecExtVen.Select())).Table.Rows.Count.ToString();
                //this.MPEMensaje.Show();
            }
            else
            {
                this.LblMessageBox.Text = "No selecciono documentos para descargar de su escritorio.";
                //this.MPEMensaje.Show();
            }
            GridView9.DataBind();
            //GridView1.DataBind();
            this.LblDocRecCopia.Text = ((DataView)(ODSDocRecCopia.Select())).Table.Rows.Count.ToString();
            //this.LblDocEnvExtCopia.Text = ((DataView)(ODSDocEnvExt.Select())).Table.Rows.Count.ToString();

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
    protected void BtnTerminarCopEnvExt_Click(object sender, EventArgs e)
    {
        try
        {

            this.LblMessageBox.Text = "";
            bool atLeastOneRowSelected = false;

            // Iterate through the Products.Rows property
            foreach (GridViewRow row in GridView1.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("SelectorDocumento");
                if (cb != null && cb.Checked)
                {
                    // Delete row! (Well, not really...)
                    atLeastOneRowSelected = true;

                    // First, get the DocumentID for the selected row
                    int mNumeroDocumento = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values[0]);
                    // por definir ...
                    //string mDependenciaCodDestino = "694";
                    int mWFMovimientoPaso = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values[2]);
                    DateTime mWFFechaMovimientoFin = DateTime.Now;
                    int mWFMovimientoTipoini = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values[3]);
                    // por definir ...
                    string mWFMovimientoNotas = "Sin notas";
                    string mGrupoCodigo = GridView1.DataKeys[row.RowIndex].Values[4].ToString();
                    string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                    //string mWFProcesoCodigo = null;
                    // por definir ...
                    //string mWFAccionCodigo = "1";
                    DateTime mWFMovimientoFecha = DateTime.Now;
                    DateTime mWFMovimientoFechaEst = DateTime.Now;
                    // por definir ...
                    //string mSerieCodigo = null;
                    string mWFMovimientoMultitarea = "0";

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
                    this.LblMessageBox.Text += " de su escritorio<br />";

                }
            }

            if (atLeastOneRowSelected == true)
            {
                //ODSDocRec.DataBind();
                //ODSDocRecExtVen.DataBind();
                //GVDocRecExtVen.DataBind();
                //LblDocRecExt.Text = ((DataView)(ODSDocRec.Select())).Table.Rows.Count.ToString();
                //LblDocRecExtVen.Text = ((DataView)(ODSDocRecExtVen.Select())).Table.Rows.Count.ToString();
                //this.MPEMensaje.Show();
            }
            else
            {
                this.LblMessageBox.Text = "No selecciono documentos para descargar de su escritorio.";
                //this.MPEMensaje.Show();
            }
            //GridView9.DataBind();
            GridView1.DataBind();
            //this.LblDocRecCopia.Text = ((DataView)(ODSDocRecCopia.Select())).Table.Rows.Count.ToString();
            this.LblDocEnvExtCopia.Text = ((DataView)(ODSDocEnvExt.Select())).Table.Rows.Count.ToString();
            this.Label12.Text = ((DataView)(ODSDocEnvExt.Select())).Table.Rows.Count.ToString();
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
    protected void BtnTerminarIntEnvVen_Click(object sender, EventArgs e)
    {
        try
        {

            this.LblMessageBox.Text = "";
            bool atLeastOneRowSelected = false;

            // Iterate through the Products.Rows property
            foreach (GridViewRow row in GridView4.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("SelectorDocumento");
                if (cb != null && cb.Checked)
                {
                    // Delete row! (Well, not really...)
                    atLeastOneRowSelected = true;

                    // First, get the DocumentID for the selected row
                    int mNumeroDocumento = Convert.ToInt32(GridView4.DataKeys[row.RowIndex].Values[0]);
                    // por definir ...
                    //string mDependenciaCodDestino = "694";
                    int mWFMovimientoPaso = Convert.ToInt32(GridView4.DataKeys[row.RowIndex].Values[2]);
                    DateTime mWFFechaMovimientoFin = DateTime.Now;
                    int mWFMovimientoTipoini = Convert.ToInt32(GridView4.DataKeys[row.RowIndex].Values[3]);
                    // por definir ...
                    string mWFMovimientoNotas = "Sin notas";
                    string mGrupoCodigo = GridView4.DataKeys[row.RowIndex].Values[4].ToString();
                    string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                    //string mWFProcesoCodigo = null;
                    // por definir ...
                    //string mWFAccionCodigo = "1";
                    DateTime mWFMovimientoFecha = DateTime.Now;
                    DateTime mWFMovimientoFechaEst = DateTime.Now;
                    // por definir ...
                    //string mSerieCodigo = null;
                    string mWFMovimientoMultitarea = "0";

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
                    this.LblMessageBox.Text += " de su escritorio<br />";

                }
            }

            if (atLeastOneRowSelected == true)
            {
                //ODSDocRec.DataBind();
                //ODSDocRecExtVen.DataBind();
                //GVDocRecExtVen.DataBind();
                //LblDocRecExt.Text = ((DataView)(ODSDocRec.Select())).Table.Rows.Count.ToString();
                //LblDocRecExtVen.Text = ((DataView)(ODSDocRecExtVen.Select())).Table.Rows.Count.ToString();
                //this.MPEMensaje.Show();
            }
            else
            {
                this.LblMessageBox.Text = "No selecciono documentos para descargar de su escritorio.";
                //this.MPEMensaje.Show();
            }
            //GridView9.DataBind();
            GridView1.DataBind();
            GridView4.DataBind();
            //this.LblDocRecCopia.Text = ((DataView)(ODSDocRecCopia.Select())).Table.Rows.Count.ToString();
            this.LblDocEnvExtCopia.Text = ((DataView)(ODSDocEnvExt.Select())).Table.Rows.Count.ToString();
            Label16.Text = ((DataView)(ODSDocEnvIntVen.Select())).Table.Rows.Count.ToString();
            Label14.Text = (Convert.ToInt16(LblDocCopiaInt.Text) + Convert.ToInt16(Label16.Text)).ToString();
            this.Label12.Text = ((DataView)(ODSDocEnvExt.Select())).Table.Rows.Count.ToString();
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
    protected void BtnTerminarEnvIntCop_Click(object sender, EventArgs e)
    {
        try
        {

            this.LblMessageBox.Text = "";
            bool atLeastOneRowSelected = false;

            // Iterate through the Products.Rows property
            foreach (GridViewRow row in GridView2.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("SelectorDocumento");
                if (cb != null && cb.Checked)
                {
                    // Delete row! (Well, not really...)
                    atLeastOneRowSelected = true;

                    // First, get the DocumentID for the selected row
                    int mNumeroDocumento = Convert.ToInt32(GridView2.DataKeys[row.RowIndex].Values[0]);
                    // por definir ...
                    //string mDependenciaCodDestino = "694";
                    int mWFMovimientoPaso = Convert.ToInt32(GridView2.DataKeys[row.RowIndex].Values[2]);
                    DateTime mWFFechaMovimientoFin = DateTime.Now;
                    int mWFMovimientoTipoini = Convert.ToInt32(GridView2.DataKeys[row.RowIndex].Values[3]);
                    // por definir ...
                    string mWFMovimientoNotas = "Sin notas";
                    string mGrupoCodigo = GridView2.DataKeys[row.RowIndex].Values[4].ToString();
                    string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                    //string mWFProcesoCodigo = null;
                    // por definir ...
                    //string mWFAccionCodigo = "1";
                    DateTime mWFMovimientoFecha = DateTime.Now;
                    DateTime mWFMovimientoFechaEst = DateTime.Now;
                    // por definir ...
                    //string mSerieCodigo = null;
                    string mWFMovimientoMultitarea = "0";

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
                    this.LblMessageBox.Text += " de su escritorio<br />";

                }
            }

            if (atLeastOneRowSelected == true)
            {
                //ODSDocRec.DataBind();
                //ODSDocRecExtVen.DataBind();
                //GVDocRecExtVen.DataBind();
                //LblDocRecExt.Text = ((DataView)(ODSDocRec.Select())).Table.Rows.Count.ToString();
                //LblDocRecExtVen.Text = ((DataView)(ODSDocRecExtVen.Select())).Table.Rows.Count.ToString();
                //this.MPEMensaje.Show();
            }
            else
            {
                this.LblMessageBox.Text = "No selecciono documentos para descargar de su escritorio.";
                //this.MPEMensaje.Show();
            }
            //GridView9.DataBind();
            GridView2.DataBind();
            //this.LblDocRecCopia.Text = ((DataView)(ODSDocRecCopia.Select())).Table.Rows.Count.ToString();
            this.LblDocCopiaInt.Text = ((DataView)(ODSDocEnvInt.Select())).Table.Rows.Count.ToString();
            this.Label14.Text = (Convert.ToInt16(LblDocCopiaInt.Text) + Convert.ToInt16(Label16.Text)).ToString();
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
    protected void LnkBtnEnvIntVen_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AlfaNetDocumentos/DocEnviado/DocEnviadoWF.aspx?TipoCodigo=1&RadicadoCodigo=1" + ((LinkButton)sender).Text + "&GrupoCodigo=2&ControlDias=2");
    }
    protected void LnkBtnEnvIntCop_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AlfaNetDocumentos/DocEnviado/DocEnviadoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1" + ((LinkButton)sender).Text + "&GrupoCodigo=2&ControlDias=2");
    }
    protected void LnkBtnRecIntCop_Click(object sender, EventArgs e)
    {

    }
    protected void LinkButton13_Click(object sender, EventArgs e)
    {
        try
        {

            this.LblMessageBox.Text = "";
            //bool atLeastOneRowSelected = false;

            // Iterate through the Products.Rows property
            foreach (GridViewRow row in GVDocRecExtVen.Rows)
            {


                TextBox TxtNota = (TextBox)row.FindControl("TextBox4");

                if (TxtNota.Text != "")
                {
                    LinkButton LnkNro = (LinkButton)row.FindControl("LinkButton5");
                    Label NotaAnt = (Label)row.FindControl("Label1");
                    DSWorkFlowTableAdapters.WFMovimientoTableAdapter DSWFMOvimientoRad = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();

                    DSWFMOvimientoRad.WFMovimiento_UpdateWFMovimientoVencidoNotas(Convert.ToInt32(GVDocRecExtVen.DataKeys[row.RowIndex].Values[3]), Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString(), GVDocRecExtVen.DataKeys[row.RowIndex].Values[4].ToString(), NotaAnt.Text + "\r\n" + TxtNota.Text, Convert.ToInt32(LnkNro.Text));
                }
                //AjaxControlToolkit.PopupControlExtender PCEIMG = (AjaxControlToolkit.PopupControlExtender)row.FindControl("PopupControlExtender1");
                //PCEIMG.ToString();

            }
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
    protected void GridView9_DataBound(object sender, EventArgs e)
    {
        // Iterate through the Products.Rows property
        foreach (GridViewRow row in GridView9.Rows)
        {
            Label Lb10 = (Label)row.FindControl("Label10");
            Image IMG = (Image)row.FindControl("Image6");
            if (Lb10.Text == "2")
                IMG.ImageUrl = "../../AlfaNetImagen/ToolBar/" + "documentos.GIF";
            else
                IMG.ImageUrl = "../../AlfaNetImagen/ToolBar/" + "dia_100mini.PNG";
        }
    }


    protected void LnkProxVenNotas_Click(object sender, EventArgs e)
    {
        try
        {

            this.LblMessageBox.Text = "";
            //bool atLeastOneRowSelected = false;

            // Iterate through the Products.Rows property
            foreach (GridViewRow row in GridView3.Rows)
            {


                TextBox TxtNota = (TextBox)row.FindControl("TxtDocProxVen");

                if (TxtNota.Text != "")
                {
                    LinkButton LnkNro = (LinkButton)row.FindControl("LinkButton6");
                    Label NotaAnt = (Label)row.FindControl("Label1");
                    DSWorkFlowTableAdapters.WFMovimientoTableAdapter DSWFMOvimientoRad = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();

                    DSWFMOvimientoRad.WFMovimiento_UpdateWFMovimientoVencidoNotas(Convert.ToInt32(GridView3.DataKeys[row.RowIndex].Values[3]), Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString(), GridView3.DataKeys[row.RowIndex].Values[4].ToString(), NotaAnt.Text + "\r\n" + TxtNota.Text, Convert.ToInt32(LnkNro.Text));
                }
                //AjaxControlToolkit.PopupControlExtender PCEIMG = (AjaxControlToolkit.PopupControlExtender)row.FindControl("PopupControlExtender1");
                //PCEIMG.ToString();

            }
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

    protected void LnkDocPenNotas_Click(object sender, EventArgs e)
    {

    }
    protected void LnkDocCopiaNotas_Click(object sender, EventArgs e)
    {

    }
    protected void LnkDocExtCopiaNotas_Click(object sender, EventArgs e)
    {

    }
    protected void LnkDcoEnvIntNotas_Click(object sender, EventArgs e)
    {

    }
    protected void LnkDocEnvCopiaNotas_Click(object sender, EventArgs e)
    {

    }
    protected void TreeView1_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {

    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        //if ((String.IsNullOrEmpty(this.TreeView1.SelectedNode.Text)) == false)
        //{
        //    // Popup result is the selected task}+
        //    this.TxtSerieD.Text = TreeView1.SelectedNode.Text.ToString();
        //    this.TreeView1.CollapseAll();
        //    this.TreeView1.Dispose();
        //    this.HFCargar.Value = "Dependencia";


        //}

    }
    protected void TreeVSerie_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        
            if (((TreeView)sender).SelectedNode == null)
        {
            foreach (GridViewRow row in GVDocRecExtVen.Rows)
            {
                //GVDocRecExtVen.
                TreeView TSerie = (TreeView)row.FindControl("TreeVSerie");

                if (TSerie.SelectedNode == null)
                {
                    ArbolesBLL ObjArbolSer = new ArbolesBLL();
                    DSSerieSQL.SerieByTextDataTable DTSerie = new DSSerieSQL.SerieByTextDataTable();

                    //DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
                    DTSerie = ObjArbolSer.GetSerieTree(e.Node.Value);
                    PopulateNodes(DTSerie, e.Node.ChildNodes, "SerieCodigo", "SerieNombre");
                }
                break;
            }
        }
    }
    protected void TreeVSerie_SelectedNodeChanged(object sender, EventArgs e)
    {

        if ((String.IsNullOrEmpty(((TreeView)sender).SelectedNode.Text)) == false)
        {
            // Popup result is the selected task}
            foreach (GridViewRow row in GVDocRecExtVen.Rows)
            {
                TreeView TVSerie = (TreeView)row.FindControl("TreeVSerie");
                TextBox TxCargar = (TextBox)row.FindControl("TxtCargarDocVen");
                if  (TVSerie.SelectedNode != null)
                {
                    TxCargar.Text = TVSerie.SelectedNode.Text;
                }
                
                //PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(((TreeView)sender).SelectedNode.Text);

                //this.TxtSerieD.Text = this.TreeVSerie.SelectedNode.Text;
                //((TreeView)sender).CollapseAll();
                //this.HFCargar.Value = "Serie";

            }
        }

    }
    private void PopulateNodes(DataTable dt, TreeNodeCollection nodes, String Codigo, String Nombre)
    {
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();
            //dr["title"].ToString();
            tn.Text = dr[Codigo].ToString() + " | " + dr[Nombre].ToString();
            tn.Value = dr[Codigo].ToString();
            nodes.Add(tn);

            //If node has child nodes, then enable on-demand populating
            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
        }
    }


    protected void TreeVProceso_SelectedNodeChanged(object sender, EventArgs e)
    {
        //if ((String.IsNullOrEmpty(this.TreeVProceso.SelectedNode.Text)) == false)
        //{
        //    // Popup result is the selected task}
        //    this.TxtSerieD.Text = this.TreeVProceso.SelectedNode.Text;
        //    this.TreeVProceso.CollapseAll();
        //    this.HFCargar.Value = "Procesos";
        //}
    }
    protected void TreeVProceso_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {

    }
    protected void GVDocRecExtVen_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex >= 0)
        {
            TextBox LblNot = (TextBox)e.Row.Cells[5].FindControl("TxtDocNotasextven");
            Image ImgNot = (Image)e.Row.Cells[5].FindControl("ImgDocNotasExtVen");
            if (LblNot.Text == "")
            {
                ImgNot.Visible = false;
            }

            if (GVDocRecExtVen.DataKeys[e.Row.RowIndex].Values[3].ToString() == "1")
            {
                CheckBox Chk = (CheckBox)e.Row.Cells[0].FindControl("SelectorDocumento");
                Chk.Visible = false;
            }
            else if (GVDocRecExtVen.DataKeys[e.Row.RowIndex].Values[3].ToString() == "4")
            {
                TextBox TCar = (TextBox)e.Row.Cells[8].FindControl("TxtCargarDocVen");
                TextBox TAcc = (TextBox)e.Row.Cells[9].FindControl("TxtAccionDocExtVen");
                TCar.Text = "Definido Por Proceso";
                TCar.Enabled = false;
                TAcc.Text = "Definido Por Proceso";
                TAcc.Enabled = false;
            }
                    
        }
    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex >= 0)
        {


            if (GridView3.DataKeys[e.Row.RowIndex].Values[3].ToString() == "1")
            {
                CheckBox Chk = (CheckBox)e.Row.Cells[0].FindControl("SelectorDocumento");
                Chk.Visible = false;

            }
            else if (GridView3.DataKeys[e.Row.RowIndex].Values[3].ToString() == "4")
            {
                //TextBox TCar = (TextBox)e.Row.Cells[8].FindControl("TxtCargarDocVen");
                //TextBox TAcc = (TextBox)e.Row.Cells[9].FindControl("TxtAccionDocExtVen");
                //TCar.Text = "Definido Por Proceso";
                //TCar.Enabled = false;
                //TAcc.Text = "Definido Por Proceso";
                //TAcc.Enabled = false;
            }

        }
    }
    protected void GridView8_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex >= 0)
        {


            if (GridView8.DataKeys[e.Row.RowIndex].Values[3].ToString() == "1")
            {
                CheckBox Chk = (CheckBox)e.Row.Cells[0].FindControl("SelectorDocumento");
                Chk.Visible = false;

            }
            else if (GridView8.DataKeys[e.Row.RowIndex].Values[3].ToString() == "4")
            {
                //TextBox TCar = (TextBox)e.Row.Cells[8].FindControl("TxtCargarDocVen");
                //TextBox TAcc = (TextBox)e.Row.Cells[9].FindControl("TxtAccionDocExtVen");
                //TCar.Text = "Definido Por Proceso";
                //TCar.Enabled = false;
                //TAcc.Text = "Definido Por Proceso";
                //TAcc.Enabled = false;
            }

        }
    }
    protected void BtnTerminarDocrecVen_Click(object sender, EventArgs e)
    {
        try
        {

            this.LblMessageBox.Text = "";
            bool atLeastOneRowSelected = false;

            // Iterate through the Products.Rows property
            foreach (GridViewRow row in GVDocRecExtVen.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("SelectorDocumento");
                Label Lb10 = (Label)row.FindControl("Label10");
                if (cb != null && cb.Checked)
                {
                    if (GVDocRecExtVen.DataKeys[row.RowIndex].Values[3].ToString() == "1")
                    {
                        //// Delete row! (Well, not really...)
                        //atLeastOneRowSelected = true;

                        //// First, get the DocumentID for the selected row
                        //int mNumeroDocumento = Convert.ToInt32(GridView9.DataKeys[row.RowIndex].Values[0]);
                        //// por definir ...
                        ////string mDependenciaCodDestino = "694";
                        //int mWFMovimientoPaso = Convert.ToInt32(GridView9.DataKeys[row.RowIndex].Values[2]);
                        //DateTime mWFFechaMovimientoFin = DateTime.Now;
                        //int mWFMovimientoTipoini = Convert.ToInt32(GridView9.DataKeys[row.RowIndex].Values[3]);
                        //// por definir ...
                        //string mWFMovimientoNotas = "Sin notas";
                        //string mGrupoCodigo = GridView9.DataKeys[row.RowIndex].Values[4].ToString();
                        //string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                        ////string mWFProcesoCodigo = null;
                        //// por definir ...
                        ////string mWFAccionCodigo = "1";
                        //DateTime mWFMovimientoFecha = DateTime.Now;
                        //DateTime mWFMovimientoFechaEst = DateTime.Now;
                        //// por definir ...
                        ////string mSerieCodigo = null;
                        //string mWFMovimientoMultitarea = "0";

                        //DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();

                        //TAWFMovimiento.WFMovimiento_UpdateWFMovimientoCopia(mNumeroDocumento,
                        //                                   mWFMovimientoPaso,
                        //                                   mWFFechaMovimientoFin,
                        //                                   mWFMovimientoTipoini,
                        //                                   mWFMovimientoNotas,
                        //                                   mGrupoCodigo,
                        //                                   mDependenciaCodOrigen,
                        //                                   mWFMovimientoMultitarea);

                        //this.LblMessageBox.Text += string.Format("Se descargo el documento {0}", mNumeroDocumento);
                        //this.LblMessageBox.Text += " de su escritorio<br />";
                    }
                    else if (GVDocRecExtVen.DataKeys[row.RowIndex].Values[3].ToString() == "4")
                    {
                        LinkButton LnkNro = (LinkButton)row.FindControl("LinkButton5");
                        int mNumeroDocumento = Convert.ToInt32(GVDocRecExtVen.DataKeys[row.RowIndex].Values[0]);
                        //DSWorkFlowTableAdapters.WFMovimientoTableAdapter ObjWorkFlow = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();
                        //DSWorkFlow.WFMovimientoDataTable DTEnviada = new DSWorkFlow.WFMovimientoDataTable();
                        //DTEnviada = ObjWorkFlow.GetUnDocExtBy(Convert.ToInt32(HFTipoDB.Value), HFDepenOrig.Value, HFGrupo.Value, Convert.ToDateTime(HFWFMovFecha.Value), Convert.ToInt32(HFControlDias.Value), Convert.ToInt32(HFNroRad.Value));
                        //DataRow[] rows = DTEnviada.Select("NumeroDocumento=" + mNumeroDocumentopro);

                        // por definir ...
                        //string mDependenciaCodDestino = "694";
                        int mWFMovimientoPaso = Convert.ToInt32(GVDocRecExtVen.DataKeys[row.RowIndex].Values[2]);
                        DateTime mWFFechaMovimientoFin = DateTime.Now;
                        int mWFMovimientoTipoini = Convert.ToInt32(GVDocRecExtVen.DataKeys[row.RowIndex].Values[3]);
                        // por definir ...
                        string mWFMovimientoNotas = "Sin notas";
                        string mGrupoCodigo = GVDocRecExtVen.DataKeys[row.RowIndex].Values[4].ToString();
                        string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                        string mWFProcesoCodigo = GVDocRecExtVen.DataKeys[row.RowIndex].Values[5].ToString();
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

                    }

                }
            }

            if (atLeastOneRowSelected == true)
            {
                //ODSDocRec.DataBind();
                //ODSDocRecExtVen.DataBind();
                //GVDocRecExtVen.DataBind();
                //LblDocRecExt.Text = ((DataView)(ODSDocRec.Select())).Table.Rows.Count.ToString();
                //LblDocRecExtVen.Text = ((DataView)(ODSDocRecExtVen.Select())).Table.Rows.Count.ToString();
                //this.MPEMensaje.Show();
            }
            else
            {
                this.LblMessageBox.Text = "No selecciono documentos para descargar de su escritorio.";
                //this.MPEMensaje.Show();
            }
            GVDocRecExtVen.DataBind();
            //GridView1.DataBind();
            this.LblDocRecCopia.Text = ((DataView)(ODSDocRecCopia.Select())).Table.Rows.Count.ToString();
            //this.LblDocEnvExtCopia.Text = ((DataView)(ODSDocEnvExt.Select())).Table.Rows.Count.ToString();

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
    protected void BtnTerminarDocRecProx_Click(object sender, EventArgs e)
    {
        try
        {

            this.LblMessageBox.Text = "";
            bool atLeastOneRowSelected = false;

            // Iterate through the Products.Rows property
            foreach (GridViewRow row in GridView3.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("SelectorDocumento");
                Label Lb10 = (Label)row.FindControl("Label10");
                if (cb != null && cb.Checked)
                {
                    if (GridView3.DataKeys[row.RowIndex].Values[3].ToString() == "1")
                    {
                        //// Delete row! (Well, not really...)
                        //atLeastOneRowSelected = true;

                        //// First, get the DocumentID for the selected row
                        //int mNumeroDocumento = Convert.ToInt32(GridView9.DataKeys[row.RowIndex].Values[0]);
                        //// por definir ...
                        ////string mDependenciaCodDestino = "694";
                        //int mWFMovimientoPaso = Convert.ToInt32(GridView9.DataKeys[row.RowIndex].Values[2]);
                        //DateTime mWFFechaMovimientoFin = DateTime.Now;
                        //int mWFMovimientoTipoini = Convert.ToInt32(GridView9.DataKeys[row.RowIndex].Values[3]);
                        //// por definir ...
                        //string mWFMovimientoNotas = "Sin notas";
                        //string mGrupoCodigo = GridView9.DataKeys[row.RowIndex].Values[4].ToString();
                        //string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                        ////string mWFProcesoCodigo = null;
                        //// por definir ...
                        ////string mWFAccionCodigo = "1";
                        //DateTime mWFMovimientoFecha = DateTime.Now;
                        //DateTime mWFMovimientoFechaEst = DateTime.Now;
                        //// por definir ...
                        ////string mSerieCodigo = null;
                        //string mWFMovimientoMultitarea = "0";

                        //DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();

                        //TAWFMovimiento.WFMovimiento_UpdateWFMovimientoCopia(mNumeroDocumento,
                        //                                   mWFMovimientoPaso,
                        //                                   mWFFechaMovimientoFin,
                        //                                   mWFMovimientoTipoini,
                        //                                   mWFMovimientoNotas,
                        //                                   mGrupoCodigo,
                        //                                   mDependenciaCodOrigen,
                        //                                   mWFMovimientoMultitarea);

                        //this.LblMessageBox.Text += string.Format("Se descargo el documento {0}", mNumeroDocumento);
                        //this.LblMessageBox.Text += " de su escritorio<br />";
                    }
                    else if (GridView3.DataKeys[row.RowIndex].Values[3].ToString() == "4")
                    {
                        LinkButton LnkNro = (LinkButton)row.FindControl("LinkButton6");
                        int mNumeroDocumento = Convert.ToInt32(GridView3.DataKeys[row.RowIndex].Values[0]);
                        //DSWorkFlowTableAdapters.WFMovimientoTableAdapter ObjWorkFlow = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();
                        //DSWorkFlow.WFMovimientoDataTable DTEnviada = new DSWorkFlow.WFMovimientoDataTable();
                        //DTEnviada = ObjWorkFlow.GetUnDocExtBy(Convert.ToInt32(HFTipoDB.Value), HFDepenOrig.Value, HFGrupo.Value, Convert.ToDateTime(HFWFMovFecha.Value), Convert.ToInt32(HFControlDias.Value), Convert.ToInt32(HFNroRad.Value));
                        //DataRow[] rows = DTEnviada.Select("NumeroDocumento=" + mNumeroDocumentopro);

                        // por definir ...
                        //string mDependenciaCodDestino = "694";
                        int mWFMovimientoPaso = Convert.ToInt32(GridView3.DataKeys[row.RowIndex].Values[2]);
                        DateTime mWFFechaMovimientoFin = DateTime.Now;
                        int mWFMovimientoTipoini = Convert.ToInt32(GridView3.DataKeys[row.RowIndex].Values[3]);
                        // por definir ...
                        string mWFMovimientoNotas = "Sin notas";
                        string mGrupoCodigo = GridView3.DataKeys[row.RowIndex].Values[4].ToString();
                        string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                        string mWFProcesoCodigo = GridView3.DataKeys[row.RowIndex].Values[5].ToString();
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

                    }

                }
            }

            if (atLeastOneRowSelected == true)
            {
                //ODSDocRec.DataBind();
                //ODSDocRecExtVen.DataBind();
                //GVDocRecExtVen.DataBind();
                //LblDocRecExt.Text = ((DataView)(ODSDocRec.Select())).Table.Rows.Count.ToString();
                //LblDocRecExtVen.Text = ((DataView)(ODSDocRecExtVen.Select())).Table.Rows.Count.ToString();
                //this.MPEMensaje.Show();
            }
            else
            {
                this.LblMessageBox.Text = "No selecciono documentos para descargar de su escritorio.";
                //this.MPEMensaje.Show();
            }
            GridView3.DataBind();
            //GridView1.DataBind();
            this.LblDocRecCopia.Text = ((DataView)(ODSDocRecCopia.Select())).Table.Rows.Count.ToString();
            //this.LblDocEnvExtCopia.Text = ((DataView)(ODSDocEnvExt.Select())).Table.Rows.Count.ToString();

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
    protected void BtnTerminarDocRecPen_Click(object sender, EventArgs e)
    {
        try
        {

            this.LblMessageBox.Text = "";
            bool atLeastOneRowSelected = false;

            // Iterate through the Products.Rows property
            foreach (GridViewRow row in GridView8.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("SelectorDocumento");
                Label Lb10 = (Label)row.FindControl("Label10");
                if (cb != null && cb.Checked)
                {
                    if (GridView8.DataKeys[row.RowIndex].Values[3].ToString() == "1")
                    {
                        //// Delete row! (Well, not really...)
                        //atLeastOneRowSelected = true;

                        //// First, get the DocumentID for the selected row
                        //int mNumeroDocumento = Convert.ToInt32(GridView9.DataKeys[row.RowIndex].Values[0]);
                        //// por definir ...
                        ////string mDependenciaCodDestino = "694";
                        //int mWFMovimientoPaso = Convert.ToInt32(GridView9.DataKeys[row.RowIndex].Values[2]);
                        //DateTime mWFFechaMovimientoFin = DateTime.Now;
                        //int mWFMovimientoTipoini = Convert.ToInt32(GridView9.DataKeys[row.RowIndex].Values[3]);
                        //// por definir ...
                        //string mWFMovimientoNotas = "Sin notas";
                        //string mGrupoCodigo = GridView9.DataKeys[row.RowIndex].Values[4].ToString();
                        //string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                        ////string mWFProcesoCodigo = null;
                        //// por definir ...
                        ////string mWFAccionCodigo = "1";
                        //DateTime mWFMovimientoFecha = DateTime.Now;
                        //DateTime mWFMovimientoFechaEst = DateTime.Now;
                        //// por definir ...
                        ////string mSerieCodigo = null;
                        //string mWFMovimientoMultitarea = "0";

                        //DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();

                        //TAWFMovimiento.WFMovimiento_UpdateWFMovimientoCopia(mNumeroDocumento,
                        //                                   mWFMovimientoPaso,
                        //                                   mWFFechaMovimientoFin,
                        //                                   mWFMovimientoTipoini,
                        //                                   mWFMovimientoNotas,
                        //                                   mGrupoCodigo,
                        //                                   mDependenciaCodOrigen,
                        //                                   mWFMovimientoMultitarea);

                        //this.LblMessageBox.Text += string.Format("Se descargo el documento {0}", mNumeroDocumento);
                        //this.LblMessageBox.Text += " de su escritorio<br />";
                    }
                    else if (GridView8.DataKeys[row.RowIndex].Values[3].ToString() == "4")
                    {
                        LinkButton LnkNro = (LinkButton)row.FindControl("LinkButton7");
                        int mNumeroDocumento = Convert.ToInt32(GridView8.DataKeys[row.RowIndex].Values[0]);
                        //DSWorkFlowTableAdapters.WFMovimientoTableAdapter ObjWorkFlow = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();
                        //DSWorkFlow.WFMovimientoDataTable DTEnviada = new DSWorkFlow.WFMovimientoDataTable();
                        //DTEnviada = ObjWorkFlow.GetUnDocExtBy(Convert.ToInt32(HFTipoDB.Value), HFDepenOrig.Value, HFGrupo.Value, Convert.ToDateTime(HFWFMovFecha.Value), Convert.ToInt32(HFControlDias.Value), Convert.ToInt32(HFNroRad.Value));
                        //DataRow[] rows = DTEnviada.Select("NumeroDocumento=" + mNumeroDocumentopro);

                        // por definir ...
                        //string mDependenciaCodDestino = "694";
                        int mWFMovimientoPaso = Convert.ToInt32(GridView8.DataKeys[row.RowIndex].Values[2]);
                        DateTime mWFFechaMovimientoFin = DateTime.Now;
                        int mWFMovimientoTipoini = Convert.ToInt32(GridView8.DataKeys[row.RowIndex].Values[3]);
                        // por definir ...
                        string mWFMovimientoNotas = "Sin notas";
                        string mGrupoCodigo = GridView8.DataKeys[row.RowIndex].Values[4].ToString();
                        string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                        string mWFProcesoCodigo = GridView8.DataKeys[row.RowIndex].Values[5].ToString();
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

                    }

                }
            }

            if (atLeastOneRowSelected == true)
            {
                //ODSDocRec.DataBind();
                //ODSDocRecExtVen.DataBind();
                //GVDocRecExtVen.DataBind();
                //LblDocRecExt.Text = ((DataView)(ODSDocRec.Select())).Table.Rows.Count.ToString();
                //LblDocRecExtVen.Text = ((DataView)(ODSDocRecExtVen.Select())).Table.Rows.Count.ToString();
                //this.MPEMensaje.Show();
            }
            else
            {
                this.LblMessageBox.Text = "No selecciono documentos para descargar de su escritorio.";
                //this.MPEMensaje.Show();
            }
            GridView8.DataBind();
            //GridView1.DataBind();
            this.LblDocRecCopia.Text = ((DataView)(ODSDocRecCopia.Select())).Table.Rows.Count.ToString();
            //this.LblDocEnvExtCopia.Text = ((DataView)(ODSDocEnvExt.Select())).Table.Rows.Count.ToString();

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
}
