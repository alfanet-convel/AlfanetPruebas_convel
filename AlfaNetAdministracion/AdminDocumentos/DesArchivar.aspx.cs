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


public partial class _DesArchivar : System.Web.UI.Page
{
    rutinas ejecutar = new rutinas();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            this.DVDocumento.Visible = false;
        }
        else
        {

        }
    }
    protected void ImgBtnFind_Click(object sender, ImageClickEventArgs e)
    {
        this.DVDocumento.Visible = true;
        String vGrupoCodigo = this.RadBtnLstFindby.SelectedValue;

        if (vGrupoCodigo == "0")
        {
            this.CiudadByIdDataSource.SelectParameters["GrupoCodigo"].DefaultValue = "2";
        }
        else 
        {
            this.CiudadByIdDataSource.SelectParameters["GrupoCodigo"].DefaultValue = "1";
        }

        if (TxtDocumento.Text != "")
        {
            if (TxtDocumento.Text.Contains(" | "))
            {
                TxtDocumento.Text = TxtDocumento.Text.Remove(TxtDocumento.Text.IndexOf(" | "));
            }
        }
        else
        {
            TxtDocumento.Text = null;
        }
        this.CiudadByIdDataSource.SelectParameters["NumeroDocumento"].DefaultValue = this.TxtDocumento.Text;
        this.DVDocumento.ChangeMode(DetailsViewMode.ReadOnly);
        //this.Label3.Visible = true;
        //this.TextBox3.Visible = true;
        this.LinkButton1.Visible = true;
        this.Image5.Visible = true;
        this.Image6.Visible = true;
        this.DVDocumento.DataBind();


    }
    protected void ImgBtnInsert_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ImgBtnUpdateActualizar_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ImgBtnEdit_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ImgBtnNew_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ImgBtnDelete_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void DVDocumento_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
    {

    }
    protected void DVDocumento_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {

    }
    protected void DVDocumento_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {

    }
    protected void DVDocumento_DataBound(object sender, EventArgs e)
    {

    }
    protected void RadBtnLstFindby_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "1")
        {
            this.DVDocumento.Visible = false;
            //this.Label3.Visible = false;
            //this.TextBox3.Visible = false;
            this.LinkButton1.Visible = true;
            this.ACDocumento.ServiceMethod = "GetDocArchivadosRecibidos";
        }
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "0")
        {
            this.DVDocumento.Visible = false;
            //this.Label3.Visible = false;
            //this.TextBox3.Visible = false;
            this.LinkButton1.Visible = true;
            this.ACDocumento.ServiceMethod = "GetDocArchivadosEnviados";
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        DataTable DesarchivarExito = new DataTable();
        String vDocumentoCodigo = TxtDocumento.Text;
        String vGrupoCodigo = this.RadBtnLstFindby.SelectedValue;

        if (vGrupoCodigo == "0")
        {
            vGrupoCodigo = "2";
        }

        DesarchivarExito = ejecutar.rtn_actualizar_DesarchivarDoc(vDocumentoCodigo, vGrupoCodigo);

        if (DesarchivarExito.Rows.Count != 0)
        {
            this.LblMessageBox.Text = "El Documento: " + TxtDocumento.Text + " Ha sido Desarchivado Correctamente";
            this.MPEMensaje.Show();
        }
        else
        {
            this.LblMessageBox.Text = "Ocurrio un Problema al Intentar DesArchivar el Documento: " + TxtDocumento.Text + " Contacte al Administrador";
            this.MPEMensaje.Show();
        }

        // Despues de DesArchivar.
                
        this.TxtDocumento.Text = "";
        this.CiudadByIdDataSource.SelectParameters["NumeroDocumento"].DefaultValue = "";
        this.DVDocumento.DataBind();
        this.LinkButton1.Visible = false;
        this.Image5.Visible = false;
        this.Image6.Visible = false;
    }

  
}