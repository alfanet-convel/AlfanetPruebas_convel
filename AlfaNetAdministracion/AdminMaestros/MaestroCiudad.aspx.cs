using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class _MaestroCiudad : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.Button1.Visible = false;
        //this.Button2.Visible = false;
        if (!IsPostBack)
        {
        //this.Button1.Visible = false;
        //this.Button2.Visible = false; 
        }
        else
        {
        //this.Button1.Visible = false;
        //this.Button2.Visible = false;   
        }
                        
    }

    protected void ImgBtnFind_Click(object sender, ImageClickEventArgs e)
    {
        if (TxtCiudad.Text != "")
        {
            if (TxtCiudad.Text.Contains(" | "))
            {
                this.HFCodigoSeleccionado.Value = TxtCiudad.Text.Remove(TxtCiudad.Text.IndexOf(" | "));
                this.DVCiudad.ChangeMode(DetailsViewMode.ReadOnly);
                
               // this.ModalPopupExtender1.Show();
            }
        }
    }

    protected void DVDepartamento_DataBound(Object sender, EventArgs e)
    {
        //if (DVCiudad.DataItemCount.ToString() == "0")
        //{
        //    this.DVCiudad.ChangeMode(DetailsViewMode.Insert);
        //}

        //TextBox TxtBox = (TextBox)(DVCiudad.FindControl("TxtDepartamento"));

        //if (TxtBox != null)
        //{
        //    TxtBox.Text = "";
        //}

        if (DVCiudad.DataItemCount.ToString() == "0")
        {
            this.DVCiudad.ChangeMode(DetailsViewMode.Insert);
        }
        else if (this.DVCiudad.CurrentMode == DetailsViewMode.ReadOnly)
        {
            Label Lb = (Label)DVCiudad.FindControl("Label2");
            if (Lb.Text == "1")
            {
                CheckBox Ch = (CheckBox)DVCiudad.FindControl("CheckBox1");
                Ch.Checked = true;
                Ch.Enabled = false;
            }
        }
        else if (this.DVCiudad.CurrentMode == DetailsViewMode.Edit)
        {
            TextBox Txt = (TextBox)DVCiudad.FindControl("TextBox2");
            if (Txt.Text == "1")
            {
                CheckBox Ch = (CheckBox)DVCiudad.FindControl("CheckBox1");
                Ch.Checked = true;
                Ch.Enabled = true;
            }
            //TextBox TxtPadre = (TextBox)DVCiudad.FindControl("TextBox1");
            //if (TxtPadre.Text != "")
            //{
            //    //RadioButtonList RBLPadre = (RadioButtonList)DVProcedencia.FindControl("RbtnLstSelPadre");
            //    //RBLPadre.SelectedValue = "1";
            //    TxtPadre.Visible = true;

            //}
            //else
            //{
            //    //RadioButtonList RBLPadre = (RadioButtonList)DVProcedencia.FindControl("RbtnLstSelPadre");
            //    //RBLPadre.SelectedValue = "0";
            //    TxtPadre.Visible = false;
            //}

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
            this.LblMessageBox.Text += e.Exception.Message.ToString();
            this.MPEMensaje.Show();

            //Indicate that exception has been handled
            e.ExceptionHandled = true;

            //Keep the row in insert mode
            e.KeepInInsertMode = true;
        }
        else if (e.Exception == null)
        {
            //this.Button1.Visible = false;
            //this.Button2.Visible = false;
            this.DVCiudad.DataBind();
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
            this.LblMessageBox.Text += e.Exception.Message.ToString();
            this.MPEMensaje.Show();

            //Indicate that exception has been handled
            e.ExceptionHandled = true;

            //Keep the row in edit mode
            e.KeepInEditMode = true;
        }
        else if (e.Exception == null)
        {
            //this.Button1.Visible = false;
            //this.Button2.Visible = false;
            this.DVCiudad.DataBind();
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
            this.LblMessageBox.Text += e.Exception.Message.ToString();
            this.MPEMensaje.Show();

            //Indicate that exception has been handled
            e.ExceptionHandled = true;

        }
        else if (e.Exception == null)
        {
            this.DVCiudad.DataBind();
            this.LblMessageBox.Text = "Registro Eliminado";
            this.MPEMensaje.Show();
        }
    }

    protected void RadBtnLstFindby_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "1")
            this.AutoCompleteCiudad.ServiceMethod = "GetCiudadByTextNombrenull";
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "2")
            this.AutoCompleteCiudad.ServiceMethod = "GetCiudadByTextIdnull";
    }
    protected void ImgBtnUpdateActualizar_Click(object sender, ImageClickEventArgs e)
    {
        CheckBox Ch = (CheckBox)DVCiudad.FindControl("CheckBox1");
        if (Ch.Checked == true)
        {
            TextBox Txt = (TextBox)DVCiudad.FindControl("TextBox2");
            Txt.Text = "1";

            this.CiudadByIdDataSource.UpdateParameters["CiudadHabilitar"].DefaultValue = "1";
        }
        else
        {
            TextBox Txt = (TextBox)DVCiudad.FindControl("TextBox2");
            Txt.Text = "0";
            this.CiudadByIdDataSource.UpdateParameters["CiudadHabilitar"].DefaultValue = "0";
        }
        this.CiudadByIdDataSource.UpdateParameters["Original_CiudadCodigo"].DefaultValue = HFCodigoSeleccionado.Value;

    }
    protected void ImgBtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        //TextBox TxtBox = (TextBox)DVCiudad.FindControl("TxtPais");

        //if (TxtBox.Text != "")
        //{
        //    if (TxtBox.Text.Contains(" | "))
        //    {
        //        TxtBox.Text = TxtBox.Text.Remove(TxtBox.Text.IndexOf(" | "));
        //    }
        //}
    }
    protected void ImgBtnInsert_Click(object sender, ImageClickEventArgs e)
    {
       CheckBox Ch = (CheckBox)DVCiudad.FindControl("CheckBox1");
        if (Ch.Checked == true)
        {
            TextBox Txt = (TextBox)DVCiudad.FindControl("TextBox2");
            Txt.Text = "1";
            this.CiudadByIdDataSource.InsertParameters["CiudadHabilitar"].DefaultValue = "1";
        }
        else
        {
            TextBox Txt = (TextBox)DVCiudad.FindControl("TextBox2");
            Txt.Text = "0";
            this.CiudadByIdDataSource.InsertParameters["CiudadHabilitar"].DefaultValue = "0";
        }
    }
    protected void ImgBtnNew_Click(object sender, ImageClickEventArgs e)
    {
        this.TxtCiudad.Text = "";
    }
    protected void ImgBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.CiudadByIdDataSource.UpdateParameters["Original_CiudadCodigo"].DefaultValue = HFCodigoSeleccionado.Value;
        this.TxtCiudad.Text = "";
        this.Label7.Text = "¿Va a eliminar la Ciudad seleccionada esta seguro?" + " ";
        this.MPEPregunta.Show();
                
    }
        
    protected void Button1_Click1(object sender, EventArgs e)
    {
        CiudadBLL Ciudad = new CiudadBLL();
        bool Correcto;

        try
        {

            Correcto = Ciudad.DeleteCiudad(HFCodigoSeleccionado.Value);
        }
        catch (Exception Error)
        {
            this.LblMessageBox.Text = "No se pudo eliminar el registro. ";
            this.MPEMensaje.Show();
        }

        //this.DVDepartamento.DataBind();
        this.LblMessageBox.Text = "Registro Eliminado";
        this.MPEMensaje.Show();
        this.TxtCiudad.Text = "";
    }
}

