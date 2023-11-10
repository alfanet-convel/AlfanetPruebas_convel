
using System;
using ASP;
using Microsoft;

using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DSRadicadoTableAdapters;
using DSGrupoSQLTableAdapters;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections;
using System.Collections.Generic;
using AjaxControlToolkit;
using System.Text;
using DevExpress.Web;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxCallbackPanel;

public partial class _Expediente : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string documento = Request["ExpedienteCodigo"];
        string Grupo = Request["GrupoCodigo"];
        //object objeto = new object();
        //EventArgs evento= new EventArgs();
        //ImageClickEventArgs eventoImg = new ImageClickEventArgs(
        //string Grupopadre = Request["GrupoPadreCodigo"];
        //this.ltexto2.Text = Grupopadre;
        
        try
        {
            if (!String.IsNullOrEmpty(Grupo) && !String.IsNullOrEmpty(documento))
            {
                if(Grupo=="1")
                {
                    cmdBuscar_Click_Rad();
                    this.AccordionPane3.Visible = false;
                    this.AccordionPane4.Visible = true;
                    this.AccordionPane1.Visible = false;
                    this.AccordionPane2.Visible = false;
                }
                else if(Grupo=="2")
                {
                    cmdBuscar_Click_Reg();
                    this.AccordionPane3.Visible = true;
                    this.AccordionPane4.Visible = false;
                    this.AccordionPane1.Visible = false;
                    this.AccordionPane2.Visible = false;
                }
                else if(Grupo=="3")
                {
                    ImgBtnFind_Click();
                    this.AccordionPane3.Visible = false;
                    this.AccordionPane4.Visible = false;
                    this.AccordionPane1.Visible = true;
                    this.AccordionPane2.Visible = true;
                }
            }

            //ACExpediente.ContextKey = Profile.GetProfile(Profile.UserName).CodigoDepUsuario;
            //HFDependenciaConsulta.Value = Profile.GetProfile(Profile.UserName).CodigoDepUsuario;
            this.ODSBuscar.SelectParameters["DependenciaConsulta"].DefaultValue = Profile.GetProfile(Profile.UserName).CodigoDepUsuario;
            if (!IsPostBack)
                {
                    string Expediente = Request["ExpedienteCodigo"];
                    //string Expediente = Request["ExpedienteCodigo"];
                    /*if (Expediente != null)
                    {
                        this.MyAccordion.SelectedIndex = 1;

                        this.ODSWFExpediente.SelectParameters["ExpedienteCodigo"].DefaultValue = Expediente;

                        //this.GVExpediente.DataBind();
                    }*/
                 
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
    protected void ImgBtnFind_Click()
    {
        String ExpedienteCodigo;
        ExpedienteCodigo = Request["ExpedienteCodigo"];
        if (ExpedienteCodigo != null)
        {
            if (ExpedienteCodigo.Contains(" | "))
            {
                ExpedienteCodigo = ExpedienteCodigo.Remove(ExpedienteCodigo.IndexOf(" | "));
            }
        }
        //String HF = HFCodigoSeleccionado.Value;
        this.ODSBuscar.SelectParameters["ExpedienteNombre"].DefaultValue = null;
        this.ODSBuscar.SelectParameters["ExpedienteCodigo"].DefaultValue = ExpedienteCodigo;
        //this.ASPxGridViewExp.gr
        this.ASPxGridViewExp.DataBind();

    }
   /* protected void RadBtnLstFindby_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "1")
            this.ACExpediente.ServiceMethod = "GetExpedienteByTextNombre";
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "2")
            this.ACExpediente.ServiceMethod = "GetExpedienteByTextId";
    }*/
    /*protected void ImgBtnNew_Click(object sender, ImageClickEventArgs e)
    {
        this.TxtExpediente.Text = "";
        this.ODSBuscar.SelectParameters["ExpedienteNombre"].DefaultValue = null;
        this.ODSBuscar.SelectParameters["ExpedienteCodigo"].DefaultValue = null;
        ASPxGridViewExp.DataBind();
    }*/
    protected void LBtnExpediente_Click(object sender, EventArgs e)
    {
        /*Aqui se muestra los documentos relacionados al expediente*/
        this.MyAccordion.SelectedIndex = 1;
               
        this.ODSWFExpediente.SelectParameters["ExpedienteCodigo"].DefaultValue = ((LinkButton)sender).Text;
        this.ASPxGVExpediente.DataSourceID = "ODSWFExpediente";
        this.ASPxGVExpediente.DataBind();
                
    }       
    /*protected void LinkButton5_Click(object sender, EventArgs e)
    {
        this.HFCodigoSeleccionado.Value = "NroDoc";
    } */  
    
   /* protected void LinkButton1_Click1(object sender, EventArgs e)
    {
        this.HFCodigoSeleccionado.Value = "Imagenes";
    }*/
    
    protected void ASPxGVExpediente_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {
            String NroDoc1 = (String)e.GetValue("NumeroDocumento");
            String CodArchivo = (String)e.GetValue("CZ");
           
            GridViewDataColumn colRad =
                ((ASPxGridView)sender).Columns["NumeroDocumento"] as GridViewDataColumn;
            GridViewDataColumn colOps =
                ((ASPxGridView)sender).Columns["Opciones"] as GridViewDataColumn;
            
            //HyperLink NroDoc = ((HyperLink)e.Row.FindControl("HyperLink1"));

                HyperLink NroDoc =
                    (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colRad, "HyperLink1");
                
                

                HyperLink HprVisor =
               (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HprLnkImgExtVen");
                

            //   // HyperLink HprHisto =
            //   //(HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HprLnkHisExtven");
            //   // HprHisto.Attributes.Add("onClick", "Historico(event," + NroDoc.Text + ",1);");
                String[] Ext = e.KeyValue.ToString().Split('|');

                if (Ext[0] == "1")
                {
                    NroDoc.Attributes.Add("onClick", "url(event,1);");
                    HprVisor.Attributes.Add("onClick", "VImagenes(event," + NroDoc.Text + ",1);");
                    
                }
                else if (Ext[0] == "2")
                {
                    NroDoc.Attributes.Add("onClick", "urlInt(event,1);");
                    HprVisor.Attributes.Add("onClick", "VImagenesReg(event," + NroDoc.Text + ",2);");
                }
//                else if (Ext[2] == "Archivo")
//                {
//                    if (Ext[1] != "")
//                    {
//                        NroDoc.Attributes.Add("onClick", "urlInt(event,1);");
//                    }else
//                        if (NroDoc.Text == "")
//                        {
//                            NroDoc.Text = "undefined";
//                        }
//                    HprVisor.Attributes.Add("onClick", "VImagenesArc(event," + NroDoc.Text + "," + CodArchivo + ",1);");
//
//                }
//                else if (Ext[2] == "")
//                {
//                    if (Ext[0] == "1")
//                    {
//                        NroDoc.Attributes.Add("onClick", "url(event,1);");
//                        HprVisor.Attributes.Add("onClick", "VImagenes(event," + NroDoc.Text + ",1);");
//                    }
//                    else if (Ext[0] == "2")
//                    {
//                        NroDoc.Attributes.Add("onClick", "urlInt(event,1);");
//                        HprVisor.Attributes.Add("onClick", "VImagenesReg(event," + NroDoc.Text + ",2);");
//                    }
//                }
        }

      
    }

    protected void callbackPanel_Callback(object source, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
    {

        litText.Text = GetNotes(e.Parameter).ToString();
    }
    object GetNotes(string id)
    {
        DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter DSRadFuenteReg = new DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter();
        DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable DTRadFuenteReg = new DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable();
        DTRadFuenteReg = DSRadFuenteReg.GetRegistrosRadicadoFuente(Convert.ToInt32(id), "1");

        int i = 1;
        foreach (DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroRow DRRadFuenteReg in DTRadFuenteReg.Rows)
        {
            HyperLink HprRpta = new HyperLink();
            HprRpta.ID = "HprRpta" + i.ToString();
            HprRpta.Text = DRRadFuenteReg.RegistroCodigo.ToString();
            HprRpta.Target = "_Blank";
            HprRpta.ForeColor = System.Drawing.Color.Blue;
            HprRpta.Font.Underline = true;
            HprRpta.Visible = true;
            HprRpta.Attributes.Add("onClick", "urlInt(event," + DRRadFuenteReg.GrupoRegistroCodigo + ");");

            callbackPanel.Controls.Add(HprRpta);
            callbackPanel.Controls.Add(new LiteralControl("&nbsp;"));
            System.Web.UI.WebControls.Image ImgRpta = new System.Web.UI.WebControls.Image();
            ImgRpta.ID = "ImgRpta" + i.ToString();
            ImgRpta.ImageUrl = "~/AlfaNetImagen/iconos/icono_tif.JPG";
            ImgRpta.Attributes.Add("onClick", "VImagenesReg(event," + DRRadFuenteReg.RegistroCodigo + "," + DRRadFuenteReg.GrupoRegistroCodigo + ");");
            callbackPanel.Controls.Add(ImgRpta);
            callbackPanel.Controls.Add(new LiteralControl("<br />"));
            i += 1;
        }
        //Image1.Visible = true;
        //Panel popup = ((Panel)e.Row.FindControl("popup"));

        return "";
    }

    protected void ASPxGridViewReg_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        //if (e.RowType == GridViewRowType.Filter) 
        //{ 

        //}
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {
            // Int32 Radicado = (Int32)e.GetValue("RadicadoCodigo");
            String ExpedienteCodigo = (String)e.GetValue("ExpedienteCodigo");
            String GrupoCodigo = (String)e.GetValue("GrupoCodigo");

            GridViewDataColumn colRad =
                ((ASPxGridView)sender).Columns["RadicadoCodigo"] as GridViewDataColumn;
            GridViewDataColumn colOps =
                ((ASPxGridView)sender).Columns["Opciones"] as GridViewDataColumn;
            GridViewDataColumn colRpta =
                ((ASPxGridView)sender).Columns["Rpta"] as GridViewDataColumn;

            HyperLink NroDoc =
                (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colRad, "HyperLink3");
            NroDoc.Attributes.Add("onClick", "url(event,1);");

            HyperLink HprVisor =
           (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HyperLink4");
            HprVisor.Attributes.Add("onClick", "VImagenes(event," + NroDoc.Text + ",1);");

        /*    HyperLink HprHisto =
           (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HprLnkHisExtven");
            HprHisto.Attributes.Add("onClick", "Historico(event," + NroDoc.Text + ",1);");

            HyperLink HprExp =
          (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HprLnkExp");
            HprExp.Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + ExpedienteCodigo + "'," + GrupoCodigo + ");");

            System.Web.UI.WebControls.Image ImgRpta =
          (System.Web.UI.WebControls.Image)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colRpta, "Image1");
*/
         /*   Label LabelResuesta =
          (Label)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colRpta, "Label6");


            if (LabelResuesta.Text == "0")
            {
                ImgRpta.Visible = false;
            }
            else if (Convert.ToInt32(LabelResuesta.Text) > 0)
            {
                ImgRpta.Visible = true;

            }*/
        }
    }

    protected void ASPxGridViewRad_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        //if (e.RowType == GridViewRowType.Filter) 
        //{ 

        //}
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {
            String ExpedienteCodigo = (String)e.GetValue("ExpedienteCodigo");
            String GrupoCodigo = (String)e.GetValue("GrupoCodigo");

            GridViewDataColumn colRad =
                ((ASPxGridView)sender).Columns["RegistroCodigo"] as GridViewDataColumn;
            GridViewDataColumn colOps =
                ((ASPxGridView)sender).Columns["Opciones"] as GridViewDataColumn;
            GridViewDataColumn colRpta =
                ((ASPxGridView)sender).Columns["Rpta"] as GridViewDataColumn;

            HyperLink NroDoc =
                (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colRad, "HyperLink2");
            NroDoc.Attributes.Add("onClick", "urlInt(event,2);");

            HyperLink HprVisor =
           (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HyperLinkVisor");
            HprVisor.Attributes.Add("onClick", "VImagenesReg(event," + NroDoc.Text + ",2);");

       /*     HyperLink HprHisto =
           (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HprLnkHisExtven");
            HprHisto.Attributes.Add("onClick", "HistoricoReg(event," + NroDoc.Text + ",2);");

            HyperLink HprExp =
         (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HprLnkExp");
            HprExp.Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + ExpedienteCodigo + "'," + GrupoCodigo + ");");
           */ 
        }
    }

    protected void cmdBuscar_Click_Rad()
    {
        ////////////////////////////////////////////////
       /* MembershipUser user = Membership.GetUser();
        Object CodigoRuta = user.ProviderUserKey;
        String UserId = Convert.ToString(CodigoRuta);*/
        ////////////////////////////////////////////////

        string lotros = "";
        string dt_qw = "";
        try
        {
            /*if (DDLOtros.SelectedValue == "Detalle" || DDLOtros.SelectedValue == String.Empty)
            {
                this.ODSBuscarGraph.SelectParameters["RadicadoDetalle"].DefaultValue = this.TxtBOtros.Text;
                lotros += "Detalle:" + TxtBOtros.Text;
            }
            else if (DDLOtros.SelectedValue == "NroExterno")
            {
                this.ODSBuscarGraph.SelectParameters["RadicadoNumeroExterno"].DefaultValue = this.TxtBOtros.Text;
                lotros += "NroExterno:" + TxtBOtros.Text;
            }
            else if (DDLOtros.SelectedValue == "Anexo")
            {
                this.ODSBuscarGraph.SelectParameters["RadicadoAnexo"].DefaultValue = this.TxtBOtros.Text;
                lotros += "Anexo:" + TxtBOtros.Text;
            }
            else if (DDLOtros.SelectedValue == "NúmerodeGuía")
            {
                this.ODSBuscarGraph.SelectParameters["RadicadoGuia"].DefaultValue = this.TxtBOtros.Text;
                lotros += "NúmerodeGuía:" + TxtBOtros.Text;
            }*/

            this.ODSBuscarGraph.SelectParameters["RadicadoDetalle"].DefaultValue = "";// this.TxtBOtros.Text;
            this.ODSBuscarGraph.SelectParameters["RadicadoNumeroExterno"].DefaultValue = "";// this.TxtBOtros.Text;
            this.ODSBuscarGraph.SelectParameters["RadicadoAnexo"].DefaultValue = "";// this.TxtBOtros.Text;
            this.ODSBuscarGraph.SelectParameters["RadicadoGuia"].DefaultValue = "";// this.TxtBOtros.Text;

            this.ODSBuscarGraph.SelectParameters["WFMovimientoFecha"].DefaultValue = "";// this.TxtFechaInicial.Text;
            this.ODSBuscarGraph.SelectParameters["WFMovimientoFecha1"].DefaultValue = "";// this.TxtFechaFinal.Text;
            this.ODSBuscarGraph.SelectParameters["RadicadoCodigo"].DefaultValue = Request["ExpedienteCodigo"];//this.TxtNroRadInicial.Text;
            this.ODSBuscarGraph.SelectParameters["RadicadoCodigo1"].DefaultValue = Request["ExpedienteCodigo"];//this.TxtNroRadFinal.Text;
            this.ODSBuscarGraph.SelectParameters["ExpedienteCodigo"].DefaultValue = "";// this.TxtBExpediente.Text;
            this.ODSBuscarGraph.SelectParameters["ProcedenciaCodigo"].DefaultValue = "";// this.TxtBProcedencia.Text;
            this.ODSBuscarGraph.SelectParameters["ProcedenciaNombre"].DefaultValue = "";// this.TxtBProcedencia.Text;
            this.ODSBuscarGraph.SelectParameters["MedioCodigo"].DefaultValue = "";// this.TxtBMedio.Text;
            this.ODSBuscarGraph.SelectParameters["DependenciaCodDestino"].DefaultValue = "";// this.TxtBDestino.Text;
            this.ODSBuscarGraph.SelectParameters["DependenciaNomDestino"].DefaultValue = "";// this.TxtBDestino.Text;
            this.ODSBuscarGraph.SelectParameters["DependenciaConsulta"].DefaultValue = "311";// Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString();
            this.ODSBuscarGraph.SelectParameters["NaturalezaCodigo"].DefaultValue = "";// this.TxtBNaturaleza.Text;
            this.ODSBuscarGraph.SelectParameters["NaturalezaNombre"].DefaultValue = "";// this.TxtBNaturaleza.Text;

            ASPxGridViewRad.DataSourceID = "ODSBuscarGraph";
            //ReportViewerRad.LocalReport.DataSources[0].DataSourceId = "";
            ASPxGridViewRad.DataBind();

            /*if (this.RBLTblRpt.SelectedValue == "1")
            {
                this.AccordionPane2.Visible = true;
                this.AccordionPane3.Visible = false;

                ASPxGridViewRad.DataSourceID = "ODSBuscarGraph";
                ReportViewerRad.LocalReport.DataSources[0].DataSourceId = "";
                ASPxGridViewRad.DataBind();
            }
            else
            {
                ASPxGridViewRad.DataSourceID = "";
                this.AccordionPane3.Visible = true;
                this.AccordionPane2.Visible = false;

                ReportViewer1.LocalReport.DataSources[0].DataSourceId = "ODSBuscarGraph";
                //Microsoft.Reporting.WebForms.ReportDataSource RDS = new Microsoft.Reporting.WebForms.ReportDataSource();
                //RDS.Name = ODSBuscarGraph.ToString();
                //RDS.Value = ODSBuscarGraph.Select();
                //this.ReportViewer1.LocalReport.DataSources.Add(RDS);
                this.ReportViewer1.DataBind();
            }*/

            this.MyAccordion.SelectedIndex = 1;


            /*Registrar el evento de busqueda*/
            String Ip_cliente = Context.Request.UserHostAddress;
            //String Uri_OrigRef = Context.Request.UrlReferrer.OriginalString;

           // log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


           /* String Log = "6" + " " + this.TxtFechaInicial.Text + "?" + this.TxtFechaFinal.Text + "?" + this.TxtNroRadInicial.Text + "?" +
                this.TxtNroRadFinal.Text + "?" + this.TxtNroRadFinal.Text + "?" + value_pipe(this.TxtBExpediente.Text) + "?" +
                value_pipe(TxtBProcedencia.Text) + "?" + value_pipe(TxtBProcedencia.Text) + "?" + value_pipe(TxtBMedio.Text) + "?" + value_pipe(TxtBDestino.Text) + "?" + value_pipe(TxtBDestino.Text) + "?" +
                Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString() + "?" + value_pipe(TxtBNaturaleza.Text) + "?" + lotros;
            */

          //  logger.Fatal(Ip_cliente + " ");// + Log);


        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
        }

    }

    protected void cmdBuscar_Click_Reg()
    {
        ////////////////////////////////////////////////
       // MembershipUser user = Membership.GetUser();
        /*Object CodigoRuta = user.ProviderUserKey;
        String UserId = Convert.ToString(CodigoRuta);*/
        ////////////////////////////////////////////////

        string lotros = "";
        string dt_qw = "";


        try
        {
            //RegistroBLL ObjConsultaReg = new RegistroBLL();
            //DSRegistro.Registro_ConsultasRegistroDataTable ConsultaRegistro = new DSRegistro.Registro_ConsultasRegistroDataTable();
            //
            //
            /*if (DDLOtros.SelectedValue == "Detalle" || DDLOtros.SelectedValue == String.Empty)
            {
                this.ODSBuscarReg.SelectParameters["RegistroDetalle"].DefaultValue = this.TxtBOtros.Text;
                lotros += "Detalle:" + TxtBOtros.Text;
            }

            else if (DDLOtros.SelectedValue == "Radicado")
            {
                this.ODSBuscarReg.SelectParameters["RadicadoCodigo"].DefaultValue = this.TxtBOtros.Text;
                lotros += "RadicadoCodigo:" + TxtBOtros.Text;
            }
            else if (DDLOtros.SelectedValue == "Anexo")
            {
                this.ODSBuscarReg.SelectParameters["AnexoExtRegistro"].DefaultValue = this.TxtBOtros.Text;
                lotros += "AnexoExtRegistro:" + TxtBOtros.Text;
            }
            else if (DDLOtros.SelectedValue == "NumerodeGuia")
            {
                this.ODSBuscarReg.SelectParameters["RegistroGuia"].DefaultValue = this.TxtBOtros.Text;
                lotros += "RegistroGuia:" + TxtBOtros.Text;
                //this.ODSBuscarGraph.SelectParameters["RegistroGuia"].DefaultValue = this.TxtBOtros.Text;
            }*/

            this.ODSBuscarReg.SelectParameters["RegistroDetalle"].DefaultValue = "";// this.TxtBOtros.Text;
            this.ODSBuscarReg.SelectParameters["RadicadoCodigo"].DefaultValue = "";// this.TxtBOtros.Text;
            this.ODSBuscarReg.SelectParameters["AnexoExtRegistro"].DefaultValue = "";// this.TxtBOtros.Text;
            this.ODSBuscarReg.SelectParameters["RegistroGuia"].DefaultValue = "";// this.TxtBOtros.Text;


            this.ODSBuscarReg.SelectParameters["RegistroTipo"].DefaultValue = "";// this.RadioButtonList1.SelectedValue.ToString();
            this.ODSBuscarReg.SelectParameters["WFMovimientoFecha"].DefaultValue = "";// this.TxtFechaInicial.Text;
            this.ODSBuscarReg.SelectParameters["WFMovimientoFecha1"].DefaultValue = "";// this.TxtFechaFinal.Text;
            this.ODSBuscarReg.SelectParameters["RegistroCodigo"].DefaultValue = Request["ExpedienteCodigo"];// this.TxtNroRegInicial.Text;
            this.ODSBuscarReg.SelectParameters["RegistroCodigo1"].DefaultValue = Request["ExpedienteCodigo"];// this.TxtNroRegFinal.Text;
            this.ODSBuscarReg.SelectParameters["ExpedienteCodigo"].DefaultValue = "";// this.TxtBExpediente.Text;
            this.ODSBuscarReg.SelectParameters["ProcedenciaCodigo"].DefaultValue = "";// this.TxtBProcedencia.Text;
            this.ODSBuscarReg.SelectParameters["MedioCodigo"].DefaultValue = "";// this.TxtBMedio.Text;
            //if (this.RadioButtonList1.SelectedValue=="0")
            this.ODSBuscarReg.SelectParameters["ProcedenciaCodigo"].DefaultValue = "";// this.TxtBDestino.Text;
            //this.ODSBuscar.SelectParameters["ProcedenciaCodigo"].DefaultValue = this.TxtBProcedencia;
            //else if (this.RadioButtonList1.SelectedValue == "1")             
            this.ODSBuscarReg.SelectParameters["DependenciaCodDestino"].DefaultValue = "";// this.TxtBDestino.Text;
            this.ODSBuscarReg.SelectParameters["NaturalezaCodigo"].DefaultValue = "";// this.TxtBNaturaleza.Text;
            this.ODSBuscarReg.SelectParameters["NaturalezaNombre"].DefaultValue = "";// this.TxtBNaturaleza.Text;
            this.ODSBuscarReg.SelectParameters["DependenciaCodigo"].DefaultValue = "";// this.TxtBRemite.Text;
            this.ODSBuscarReg.SelectParameters["SerieCodigo"].DefaultValue = "";// this.TxtBSerie.Text;
            this.ODSBuscarReg.SelectParameters["RemiteNombre"].DefaultValue = "";// this.TxtBRemite.Text;
            this.ODSBuscarReg.SelectParameters["DestinoNombre"].DefaultValue = "";// this.TxtBDestino.Text;
            this.ODSBuscarReg.SelectParameters["DependenciaConsulta"].DefaultValue = "311";// Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString();

            this.ASPxGridViewReg.DataSourceID = "ODSBuscarReg";
            //this.ASPxGridViewReg.LocalReport.DataSources[0].DataSourceId = "";
            this.ASPxGridViewReg.DataBind();

            /*if (this.RBLTblRpt.SelectedValue == "1")
            {
                this.AccordionPane2.Visible = true;
                this.AccordionPane3.Visible = false;

                this.ASPxGridView1.DataSourceID = "ODSBuscarReg";
                this.ReportViewer1.LocalReport.DataSources[0].DataSourceId = "";
                this.ASPxGridView1.DataBind();
            }
            else
            {
                this.ASPxGridView1.DataSourceID = "";
                this.AccordionPane3.Visible = true;
                this.AccordionPane2.Visible = false;

                this.ReportViewer1.LocalReport.DataSources[0].DataSourceId = "ODSBuscarReg";
                //Microsoft.Reporting.WebForms.ReportDataSource RDS = new Microsoft.Reporting.WebForms.ReportDataSource();
                //RDS.Name = ODSBuscar.ToString();
                //RDS.Value = ODSBuscar.Select();
                //this.ReportViewer1.LocalReport.DataSources.Add(RDS);
                this.ReportViewer1.DataBind();
            }*/

            /*Registrar el evento de busqueda
             
             */
            /*
            rutinas r1 = new rutinas();
            DataTable t1 = r1.rtn_registrar_log("0", UserId, "6",
                this.TxtFechaInicial.Text + "?" + this.TxtFechaFinal.Text + "?" + this.TxtNroRegInicial.Text + "?" +
                this.TxtNroRegFinal.Text + "?" + this.TxtNroRegFinal.Text + "?" + value_pipe(this.TxtBExpediente.Text) + "?" +
                value_pipe(TxtBProcedencia.Text) + "?" + value_pipe(TxtBDestino.Text) + "?" + value_pipe(TxtBMedio.Text) + "?" + value_pipe(TxtBDestino.Text) + "?" + value_pipe(TxtBRemite.Text) + "?" +
                value_pipe(TxtBSerie.Text) + "?" + Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString() + "?" + value_pipe(TxtBNaturaleza.Text) + "?" + lotros
                , "2");*/

            //GVBuscar.DataSource = ConsultaRegistro;
            //GVBuscar.Visible = true;
            //GVBuscar.DataBind();
            this.MyAccordion.SelectedIndex = 1;

            /*Registrar el evento de busqueda*/
            String Ip_cliente = Context.Request.UserHostAddress;
            //String Uri_OrigRef = Context.Request.UrlReferrer.OriginalString;

            //log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


           /* String Log = "7" + " " + this.TxtFechaInicial.Text + "?" + this.TxtFechaFinal.Text + "?" + this.TxtNroRegInicial.Text + "?" +
                this.TxtNroRegFinal.Text + "?" + this.TxtNroRegFinal.Text + "?" + value_pipe(this.TxtBExpediente.Text) + "?" +
                value_pipe(TxtBProcedencia.Text) + "?" + value_pipe(TxtBDestino.Text) + "?" + value_pipe(TxtBMedio.Text) + "?" + value_pipe(TxtBDestino.Text) + "?" + value_pipe(TxtBRemite.Text) + "?" +
                value_pipe(TxtBSerie.Text) + "?" + Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString() + "?" + value_pipe(TxtBNaturaleza.Text) + "?" + lotros;
            */

            //ILog logger = LogManager.GetLogger("primerEjemplo");
            //logger.Fatal(Ip_cliente + " ");// + Log);

        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
        }
    }
}
      
