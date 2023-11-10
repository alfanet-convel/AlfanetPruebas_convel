using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class _MaestroSerie : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.TCSerie.ActiveTabIndex = 0;
        }
        else
        {
            
        }    
                 
    }

    protected void ImgBtnFind_Click(object sender, ImageClickEventArgs e)
    {
        if (TxtSerie.Text != "")
        {
            if (TxtSerie.Text.Contains(" | "))
            {
                this.HFCodigoSeleccionado.Value = TxtSerie.Text.Remove(TxtSerie.Text.IndexOf(" | "));
                this.DVSerie.ChangeMode(DetailsViewMode.ReadOnly);
            }
        }
    }


    protected void ImgBtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        TextBox TxtBox = (TextBox)DVSerie.FindControl("TxtPais");

        if (TxtBox.Text != "")
        {
            if (TxtBox.Text.Contains("-"))
            {
                TxtBox.Text = TxtBox.Text.Remove(TxtBox.Text.IndexOf("-"));
            }
        }
    }


    protected void ImgBtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        TextBox TxtBox = (TextBox)DVSerie.FindControl("TxtPais");

        if (TxtBox.Text != "")
        {
            if (TxtBox.Text.Contains("-"))
            {
                TxtBox.Text = TxtBox.Text.Remove(TxtBox.Text.IndexOf("-"));
            }
        }
    }


    protected void DVDepartamento_DataBound(Object sender, EventArgs e)
    {
        if (DVSerie.DataItemCount.ToString() == "0")
        {
            this.DVSerie.ChangeMode(DetailsViewMode.Insert);
        }
        else if (this.DVSerie.CurrentMode == DetailsViewMode.ReadOnly)
        {
            Label Lb = (Label)DVSerie.FindControl("Label2");
            if (Lb.Text == "1")
            {
                CheckBox Ch = (CheckBox)DVSerie.FindControl("CheckBox1");
                Ch.Checked = true;
                Ch.Enabled = false;
            }
        }
        else if (this.DVSerie.CurrentMode == DetailsViewMode.Edit)
        {
            Label LblCodProce = (Label)DVSerie.FindControl("Label1");

            DSSerieSQLTableAdapters.Serie_ReadExisteSerieTableAdapter TASerieExiste = new DSSerieSQLTableAdapters.Serie_ReadExisteSerieTableAdapter();
            DSSerieSQL.Serie_ReadExisteSerieDataTable DTSerieExiste = new DSSerieSQL.Serie_ReadExisteSerieDataTable();
            DTSerieExiste = TASerieExiste.GetSerie_ReadExisteSerie(LblCodProce.Text);

            Label LblProce = (Label)DVSerie.FindControl("Label5");
            TextBox TxtProce = (TextBox)DVSerie.FindControl("TextBox4");
            Label LblProceMsg = (Label)DVSerie.FindControl("Label13");

            if (DTSerieExiste.Count == 0)
            {
                LblProce.Visible = false;
                TxtProce.Visible = true;
                LblProceMsg.Visible = false;
            }
            else
            {
                LblProce.Visible = true;
                LblProceMsg.Visible = true;
                TxtProce.Visible = false;
            }            

            TextBox Txt = (TextBox)DVSerie.FindControl("TextBox2");
            if (Txt.Text == "1")
            {
                CheckBox Ch = (CheckBox)DVSerie.FindControl("CheckBox1");
                Ch.Checked = true;
                Ch.Enabled = true;
            }
            TextBox TxtPadre = (TextBox)DVSerie.FindControl("TextBox3");
            if (TxtPadre.Text != "")
            {
                RadioButtonList RBLPadre = (RadioButtonList)DVSerie.FindControl("RbtnLstSelPadre");
                RBLPadre.SelectedValue = "1";
                TxtPadre.Visible = true;
                
            }
            else
            {
                RadioButtonList RBLPadre = (RadioButtonList)DVSerie.FindControl("RbtnLstSelPadre");
                RBLPadre.SelectedValue = "0";
                TxtPadre.Visible = false;
            }
                
            }
        }
    




    protected void DVDepartamento_ItemInserted(Object sender, DetailsViewInsertedEventArgs e)
    {
        if (e.Exception != null)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de adicionar el registro. ";
            Exception inner = e.Exception.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.MPEMensaje.Show();

            //Indicate that exception has been handled
            e.ExceptionHandled = true;

            //Keep the row in insert mode
            e.KeepInInsertMode = true;
        }
        else if (e.Exception == null)
        {
            this.DVSerie.DataBind();
            this.LblMessageBox.Text = "Registro Adicionado";
            this.MPEMensaje.Show();
        }
    }


    protected void DVDepartamento_ItemUpdated(Object sender, DetailsViewUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de actualizar el registro. ";
            Exception inner = e.Exception.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.MPEMensaje.Show();

            //Indicate that exception has been handled
            e.ExceptionHandled = true;

            //Keep the row in edit mode
            e.KeepInEditMode = true;
        }
        else if (e.Exception == null)
        {
            this.DVSerie.DataBind();
            this.LblMessageBox.Text = "Registro Editado";
            this.MPEMensaje.Show();
        }
    }
protected void DVDepartamento_ItemDeleted(Object sender, DetailsViewDeletedEventArgs e)
    {
        if (e.Exception != null)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de eliminar el registro. ";
            Exception inner = e.Exception.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.MPEMensaje.Show();

            //Indicate that exception has been handled
            e.ExceptionHandled = true;

        }
        else if (e.Exception == null)
        {
            this.DVSerie.DataBind();
            this.LblMessageBox.Text = "Registro Eliminado";
            this.MPEMensaje.Show();
        }
    }

    
protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {

    }
   
protected void ImgBtnInsertExpediente_Click(object sender, ImageClickEventArgs e)
    {
        CheckBox Ch = (CheckBox)DVSerie.FindControl("CheckBox1");
        if (Ch.Checked == true)
        {
            TextBox Txt = (TextBox)DVSerie.FindControl("TextBox2");
            Txt.Text = "1";
            this.SerieByIdDataSource.InsertParameters["SerieHabilitar"].DefaultValue = "1";
        }
        else
        {
            TextBox Txt = (TextBox)DVSerie.FindControl("TextBox2");
            Txt.Text = "0";
            this.SerieByIdDataSource.InsertParameters["SerieHabilitar"].DefaultValue = "0";
        }
        this.SerieByIdDataSource.InsertParameters["SeriePermiso"].DefaultValue = RbtnLstPermiso.SelectedValue.ToString();
        TextBox Txt4 = (TextBox)DVSerie.FindControl("TextBox4");
        HFCodigoSeleccionado.Value = Txt4.Text;
    }
    
protected void RbtnLstPermiso_SelectedIndexChanged(object sender, EventArgs e)
    {
        

        DSSerieSQLTableAdapters.SerieTableAdapter ObjTASerPer = new DSSerieSQLTableAdapters.SerieTableAdapter();
        DSSerieSQL.SerieDataTable DTSeriePer = new DSSerieSQL.SerieDataTable();
        DTSeriePer = ObjTASerPer.GetSerieById(HFCodigoSeleccionado.Value);

        DataRow[] rows = DTSeriePer.Select();
        String Padre;

        if (rows[0].ItemArray[2].ToString() == "")
            Padre = null;
        else
            Padre = rows[0].ItemArray[2].ToString();

        
        DTSeriePer = ObjTASerPer.GetSerie_UpdateSerieBy(rows[0].ItemArray[1].ToString(),
                                                        Padre,
                                                        Convert.ToInt32(rows[0].ItemArray[3].ToString()),
                                                        rows[0].ItemArray[5].ToString(),
                                                        this.RbtnLstPermiso.SelectedValue,
                                                        rows[0].ItemArray[0].ToString());



        
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //this.DVNaturaleza.ChangeMode(DetailsViewMode.Edit);
    }
    protected void ImgBtnNewExpediente_Click(object sender, ImageClickEventArgs e)
    {
        this.DVSerie.ChangeMode(DetailsViewMode.Insert);
        this.TxtSerie.Text = "";
        
    }
    protected void ImgBtnDeleteExpedientePermiso_Click(object sender, ImageClickEventArgs e)
    {
        this.SerieByIdDataSource.DeleteParameters["Original_SerieCodigo"].DefaultValue = HFCodigoSeleccionado.Value;
        this.TxtSerie.Text = "";
        this.Label7.Text = "¿Va a eliminar la Serie seleccionada esta seguro?" + " ";
        this.MPEPregunta.Show();
    }
    protected void ImgBtnEditExpediente_Click(object sender, ImageClickEventArgs e)
    {
       
        CheckBox Ch = (CheckBox)DVSerie.FindControl("CheckBox1");
        if (Ch.Checked == true)
        {
            TextBox Txt = (TextBox)DVSerie.FindControl("TextBox2");
            Txt.Text = "1";
            
            this.SerieByIdDataSource.UpdateParameters["SerieHabilitar"].DefaultValue = "1";
           
        }
        else
        {
            TextBox Txt = (TextBox)DVSerie.FindControl("TextBox2");
            Txt.Text = "0";
            this.SerieByIdDataSource.UpdateParameters["SerieHabilitar"].DefaultValue = "0";
        }



        this.SerieByIdDataSource.UpdateParameters["SeriePermiso"].DefaultValue = RbtnLstPermiso.SelectedValue.ToString();
        this.SerieByIdDataSource.UpdateParameters["Original_SerieCodigo"].DefaultValue = HFCodigoSeleccionado.Value;
    }
    protected void TCSerie_ActiveTabChanged(object sender, EventArgs e)
    {
        if (this.TCSerie.ActiveTabIndex.ToString() == "1")
        {
            if (this.HFCodigoSeleccionado.Value.Length.ToString() == "0")
            {
                this.LblMessageBox.Text = "No ha seleccionado un expediente";
                this.MPEMensaje.Show();

            }
            else
            {
                this.RbtnLstPermiso.Enabled = true;

                //Label Lb = (Label)DVExpedientePermiso.FindControl("Label1");
                //Lb.Text = HFCodigoSeleccionado.Value;

            }
        }
    }
    protected void RbtnLstSelPadre_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox TxtBox = (TextBox)DVSerie.FindControl("TextBox3");
        RadioButtonList rblst = (RadioButtonList)DVSerie.FindControl("RbtnLstSelPadre");

        if (rblst != null)
        {
            if (rblst.SelectedValue.ToString() == "0")
            {
                TxtBox.Visible = false;
                TxtBox.Text = null;
            }
            else
            {
                TxtBox.Visible = true;
            }

        }

    }
    protected void GVExpedientePermiso_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if (e.Exception != null)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar eliminar el registro. ";
            Exception inner = e.Exception.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.LblMessageBox.Text += e.Exception.Message.ToString();
            this.MPEMensaje.Show();

            //Indicate that exception has been handled
            e.ExceptionHandled = true;
        }
        else if (e.Exception == null)
        {
            this.DVSerie.DataBind();
            this.GVExpedientePermiso.DataBind();
            this.LblMessageBox.Text = "Registro Eliminado";
            this.MPEMensaje.Show();
        }
    }
    protected void DVExpediente_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
    {
        if (e.Exception != null)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de eliminar el registro. ";
            Exception inner = e.Exception.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.LblMessageBox.Text += e.Exception.Message.ToString();
            this.MPEMensaje.Show();

            //Indicate that exception has been handled
            e.ExceptionHandled = true;

        }
        else if (e.Exception == null)
        {
            this.DVSerie.DataBind();
            this.GVExpedientePermiso.DataBind();
            this.LblMessageBox.Text = "Registro Eliminado";
            this.MPEMensaje.Show();
        }
    }
    protected void DVExpediente_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        if (e.Exception != null)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de adicionar el registro. ";
            Exception inner = e.Exception.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.LblMessageBox.Text += e.Exception.Message.ToString();
            this.MPEMensaje.Show();

            //Indicate that exception has been handled
            e.ExceptionHandled = true;

            //Keep the row in insert mode
            e.KeepInInsertMode = true;
        }
        else if (e.Exception == null)
        {
            this.DVSerie.DataBind();
            this.GVExpedientePermiso.DataBind();
            this.LblMessageBox.Text = "Registro Adicionado";
            this.MPEMensaje.Show();
        }
    }
    protected void DVExpediente_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de actualizar el registro. ";
            Exception inner = e.Exception.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.LblMessageBox.Text += e.Exception.Message.ToString();
            this.MPEMensaje.Show();

            //Indicate that exception has been handled
            e.ExceptionHandled = true;

            //Keep the row in edit mode
            e.KeepInEditMode = true;
        }
        else if (e.Exception == null)
        {
            this.DVSerie.DataBind();
            this.GVExpedientePermiso.DataBind();
            this.LblMessageBox.Text = "Registro Editado";
            this.MPEMensaje.Show();
        }
    }
    protected void DVExpediente_DataBound(object sender, EventArgs e)
    {
        Label Lb = (Label)DVExpedientePermiso.FindControl("Label1");
        Lb.Text = HFCodigoSeleccionado.Value;
        //this.DVDependencia.
        /*
        this.MPEMensaje.Show(this.DVExpediente.DefaultMode.ToString());

        if (this.DVExpediente.DataItemCount.ToString() == "0")
        {
            this.DVExpediente.ChangeMode(DetailsViewMode.Insert);
        }

        if (this.DVExpediente.DefaultMode.ToString() == "Insert")
        {
            this.RbtnLstPermiso.Enabled = true;
        }
        */
    }

    protected void ImgBtnInsertExpedientePermiso_Click(object sender, ImageClickEventArgs e)
    {
        TextBox TxtDep = (TextBox)DVExpedientePermiso.FindControl("TextBox2");
        String DepCod = TxtDep.Text;
        if (DepCod != "")
        {
            if (DepCod.Contains(" | "))
            {
                DepCod = DepCod.Remove(DepCod.IndexOf(" | "));
            }
        }

        //DSDependenciaSQLTableAdapters.DependenciaPermiso_ReadDependenciaPermisoByIdTableAdapter ObjTADepPer = new DSDependenciaSQLTableAdapters.DependenciaPermiso_ReadDependenciaPermisoByIdTableAdapter();
        //int correcto = ObjTADepPer.Insert(DepCod,this.HFCodigoSeleccionado.Value);
        this.ODSPermisoSerie.InsertParameters["SerieCodigo"].DefaultValue = this.HFCodigoSeleccionado.Value;
        this.ODSPermisoSerie.InsertParameters["DependenciaCodigo"].DefaultValue = DepCod;
        //this.ODSPermisoDependencia.Insert();
        //this.ODSPermisoExpediente.InsertParameters["ExpedienteCodigo"].DefaultValue = this.HFCodigoSeleccionado.Value;
        //this.GVExpedientePermiso.DataBind();
        TxtDep.Text = "";
        Label Lb = (Label)DVExpedientePermiso.FindControl("Label1");
        Lb.Text = HFCodigoSeleccionado.Value;
    }
    protected void RadBtnLstFindby_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "1")
            this.ACSearchSerie.ServiceMethod = "GetSerieByTextnull";
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "2")
            this.ACSearchSerie.ServiceMethod = "GetSerieTextByIdnull";
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        SerieBLL Serie = new SerieBLL();
        bool Correcto;

        try
        {

            Correcto = Serie.DeleteSerie(HFCodigoSeleccionado.Value);
            this.LblMessageBox.Text = "Registro Eliminado";
        }
        catch (Exception Error)
        {
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de eliminar el registro. ";
            this.MPEMensaje.Show();
        }

        //this.DVDepartamento.DataBind();
       
        this.MPEMensaje.Show();
        this.TxtSerie.Text = "";
    }
}

