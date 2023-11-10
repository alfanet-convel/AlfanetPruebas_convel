using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class _MaestroPais : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
        else
        {

        }         
    }

    protected void ImgBtnFind_Click(object sender, ImageClickEventArgs e)
    {
        if (TxtPais.Text != "")
        {
            if (TxtPais.Text.Contains(" | "))
            {
                this.HFCodigoSeleccionado.Value = TxtPais.Text.Remove(TxtPais.Text.IndexOf(" | "));
                this.DVPais.ChangeMode(DetailsViewMode.ReadOnly);
            }
        }
    }

    protected void DVDepartamento_DataBound(Object sender, EventArgs e)
    {
        if (DVPais.DataItemCount.ToString() == "0")
        {
            this.DVPais.ChangeMode(DetailsViewMode.Insert);
        }
        else if (this.DVPais.CurrentMode == DetailsViewMode.ReadOnly)
        {
            Label Lb = (Label)DVPais.FindControl("Label2");
            if (Lb.Text == "1")
            {
                CheckBox Ch = (CheckBox)DVPais.FindControl("CheckBox1");
                Ch.Checked = true;
                Ch.Enabled = false;
            }
        }
        else if (this.DVPais.CurrentMode == DetailsViewMode.Edit)
        {
            TextBox Txt = (TextBox)DVPais.FindControl("TextBox2");
            if (Txt.Text == "1")
            {
                CheckBox Ch = (CheckBox)DVPais.FindControl("CheckBox1");
                Ch.Checked = true;
                Ch.Enabled = true;
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
            this.LblMessageBox.Text += e.Exception.Message.ToString();
            this.MPEMensaje.Show();

            //Indicate that exception has been handled
            e.ExceptionHandled = true;

            //Keep the row in insert mode
            e.KeepInInsertMode = true;
        }
        else if (e.Exception == null)
        {
            this.DVPais.DataBind();
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
            this.DVPais.DataBind();
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
            this.DVPais.DataBind();
            this.LblMessageBox.Text = "Registro Eliminado";
            this.MPEMensaje.Show();
        }
    }


    protected void RadBtnLstFindby_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "1")
          this.AutoCompletePais.ServiceMethod = "GetPaisByTextNombrenull";
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "2")
          this.AutoCompletePais.ServiceMethod = "GetPaisByTextIdNull";
    }
    
    protected void ImgBtnUpdateActualizar_Click(object sender, ImageClickEventArgs e)
    {
        CheckBox Ch = (CheckBox)DVPais.FindControl("CheckBox1");
        if (Ch.Checked == true)
        {
            TextBox Txt = (TextBox)DVPais.FindControl("TextBox2");
            Txt.Text = "1";

            this.PaisByIdDataSource.UpdateParameters["PaisHabilitar"].DefaultValue = "1";
        }
        else
        {
            TextBox Txt = (TextBox)DVPais.FindControl("TextBox2");
            Txt.Text = "0";
            this.PaisByIdDataSource.UpdateParameters["PaisHabilitar"].DefaultValue = "0";
        }
        this.PaisByIdDataSource.UpdateParameters["Original_PaisCodigo"].DefaultValue = HFCodigoSeleccionado.Value;

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
        CheckBox Ch = (CheckBox)DVPais.FindControl("CheckBox1");
        if (Ch.Checked == true)
        {
            TextBox Txt = (TextBox)DVPais.FindControl("TextBox2");
            Txt.Text = "1";
            this.PaisByIdDataSource.InsertParameters["PaisHabilitar"].DefaultValue = "1";
        }
        else
        {
            TextBox Txt = (TextBox)DVPais.FindControl("TextBox2");
            Txt.Text = "0";
            this.PaisByIdDataSource.InsertParameters["PaisHabilitar"].DefaultValue = "0";
        }
    }
    protected void ImgBtnNew_Click(object sender, ImageClickEventArgs e)
    {
        this.TxtPais.Text = "";
    }
    protected void ImgBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.PaisByIdDataSource.UpdateParameters["Original_PaisCodigo"].DefaultValue = HFCodigoSeleccionado.Value;
        this.TxtPais.Text= "";
        this.Label7.Text = "¿Va a eliminar el País seleccionado esta seguro?" + " ";
        this.MPEPregunta.Show();

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        PaisBLL Pais = new PaisBLL();
        bool Correcto;

        try
        {

            Correcto = Pais.DeletePais(HFCodigoSeleccionado.Value);
            this.LblMessageBox.Text = "Registro Eliminado";
        }
        catch (Exception Error)
        {
            this.LblMessageBox.Text = "No se pudo eliminar el registro. ";
            
        }

        //this.DVDepartamento.DataBind();
        
        this.MPEMensaje.Show();
        this.TxtPais.Text = "";
    }
}

