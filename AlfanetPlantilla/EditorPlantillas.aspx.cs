using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class AlfanetPlantilla_EditorPlantillas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargaPanel("Inicio");
        }
        //LstCamposSel.Attributes.Add("onChange", "concatena();");
    }

    void CargaPanel(string panel)
    {
        PnlPlantilla.Visible = false;
        PnlMenu.Visible = false;

        LstPlantillasModificar.Visible = false;
        //LstPlantillasEliminar.Visible = false;

        LnkNuevaP.Visible = false;
        LnkModificarP.Visible = false;
        //LnkEliminarP.Visible = false;
        LnkVerModificar.Visible = false;
        //LnkVerEliminar.Visible = false;

        ImgBtnLimpiar.Visible = false;
        ImgBtnGuardar.Visible = false;
        ImgBtnModificar.Visible = false;
        //ImgBtnEliminar.Visible = false;
        ImgBtnRegresar.Visible = false;

        LblResultado.Visible = false;

        TxtCodigo.Enabled = true;
        TxtDescripcion.Enabled = true;
        ChkEstado.Enabled = true;
        Editor.Enabled = true;

        switch (panel)
        {
            case "Inicio":
                LnkNuevaP.Visible = true;
                LnkModificarP.Visible = true;
                //LnkEliminarP.Visible = true;
                PnlMenu.Visible = true;
                break;

            case "Nuevo":
                PnlPlantilla.Visible = true;
                TxtCodigo.Text = string.Empty;
                TxtDescripcion.Text = string.Empty;
                //Editor.Content = string.Empty;
                Editor.Text = string.Empty;
                //ImgBtnLimpiar.Visible = true;
                ImgBtnRegresar.Visible = true;
                ImgBtnGuardar.Visible = true;
                break;

            case "Modificar":
                PnlMenu.Visible = true;
                LnkModificarP.Visible = true;
                LstPlantillasModificar.Visible = true;
                LnkVerModificar.Visible = true;
                TxtCodigo.Text = string.Empty;
                TxtDescripcion.Text = string.Empty;
                //Editor.Content = string.Empty;
                Editor.Text = string.Empty;
                ImgBtnRegresar.Visible = true;
                break;

            case "VerModificar":
                PnlPlantilla.Visible = true;
                ImgBtnModificar.Visible = true;
                ImgBtnRegresar.Visible = true;
                break;

            /* case "Eliminar":
                 PnlMenu.Visible = true;
                 LnkEliminarP.Visible = true;
                 LstPlantillasEliminar.Visible = true;
                 LnkVerEliminar.Visible = true;
                 ImgBtnRegresar.Visible = true;
                 break;*/

            /*case "VerEliminar":
                PnlPlantilla.Visible = true;
                ImgBtnEliminar.Visible = true;
                TxtCodigo.Enabled = false;
                TxtDescripcion.Enabled = false;
                ChkEstado.Enabled = false;
                Editor.Enabled = false;
                ImgBtnRegresar.Visible = true;
                break;*/
        }
    }

    protected void LnkNuevaP_Click(object sender, EventArgs e)
    {
        LstCampos.Items.Clear();
        LstCamposSel.Items.Clear();

        DSPlantillaTableAdapters.Plantilla_CamposTableAdapter TAPlantilla_Campos = new DSPlantillaTableAdapters.Plantilla_CamposTableAdapter();
        DSPlantilla.Plantilla_CamposDataTable DTPlantillaCampos = new DSPlantilla.Plantilla_CamposDataTable();
        Int32 mTipoCampos = 2; //Radicados
        DTPlantillaCampos = TAPlantilla_Campos.GetPlantillaCampos(mTipoCampos);
        LstCampos.DataValueField = "TABLE_COLUMN";
        LstCampos.DataTextField = "CAMPO";
        LstCampos.DataSource = DTPlantillaCampos;
        LstCampos.DataBind();
        CargaPanel("Nuevo");
    }

    protected void LnkModificarP_Click(object sender, EventArgs e)
    {
        LstCampos.Items.Clear();
        LstCamposSel.Items.Clear();
        DSPlantillaTableAdapters.PlantillaTableAdapter TAPlantilla = new DSPlantillaTableAdapters.PlantillaTableAdapter();
        DSPlantilla.PlantillaDataTable DTPlantilla = new DSPlantilla.PlantillaDataTable();
        DTPlantilla = TAPlantilla.GetPlantillaLista();
        LstPlantillasModificar.DataValueField = "Codigo";
        LstPlantillasModificar.DataTextField = "Descripcion";
        LstPlantillasModificar.DataSource = DTPlantilla;
        LstPlantillasModificar.DataBind();
        CargaPanel("Modificar");
    }

    /* protected void LnkEliminarP_Click(object sender, EventArgs e)
     {
         DSPlantillaTableAdapters.PlantillaTableAdapter TAPlantilla = new DSPlantillaTableAdapters.PlantillaTableAdapter();
         DSPlantilla.PlantillaDataTable DTPlantilla = new DSPlantilla.PlantillaDataTable();
         DTPlantilla = TAPlantilla.GetPlantillaLista();
         LstPlantillasEliminar.DataValueField = "Codigo";
         LstPlantillasEliminar.DataTextField = "Descripcion";
         LstPlantillasEliminar.DataSource = DTPlantilla;
         LstPlantillasEliminar.DataBind();
         CargaPanel("Eliminar");
     }*/


    protected void LnkVerModificar_Click(object sender, EventArgs e)
    {
        try
        {
            DSPlantillaTableAdapters.PlantillaTableAdapter TAPlantilla = new DSPlantillaTableAdapters.PlantillaTableAdapter();
            DSPlantilla.PlantillaDataTable DTPlantilla = new DSPlantilla.PlantillaDataTable();
            DTPlantilla = TAPlantilla.GetPlantillaById(LstPlantillasModificar.SelectedValue);

            LstCampos.Items.Clear();
            LstCamposSel.Items.Clear();
            DSPlantillaTableAdapters.Plantilla_CamposTableAdapter TAPlantilla_Campos = new DSPlantillaTableAdapters.Plantilla_CamposTableAdapter();
            DSPlantilla.Plantilla_CamposDataTable DTPlantillaCampos = new DSPlantilla.Plantilla_CamposDataTable();

            if (DTPlantilla.Rows.Count > 0)
            {
                TxtCodigo.Text = DTPlantilla.Rows[0]["Codigo"].ToString();
                TxtDescripcion.Text = DTPlantilla.Rows[0]["Descripcion"].ToString();
                if ((bool)DTPlantilla.Rows[0]["Estado"] == true)
                {
                    ChkEstado.Checked = true;
                }
                else
                {
                    ChkEstado.Checked = false;
                }
                Int32 mTipoCampos = 2; //Radicados
                DTPlantillaCampos = TAPlantilla_Campos.GetPlantillaCampos(mTipoCampos);
                LstCampos.DataValueField = "TABLE_COLUMN";
                LstCampos.DataTextField = "CAMPO";
                LstCampos.DataSource = DTPlantillaCampos;
                LstCampos.DataBind();

                //Editor.Content = DTPlantilla.Rows[0]["HTML"].ToString();
                Editor.Text = DTPlantilla.Rows[0]["HTML"].ToString();
                Session.Add("CodPlantillaModif", DTPlantilla.Rows[0]["Codigo"].ToString());
                CargaPanel("VerModificar");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*  protected void LnkVerEliminar_Click(object sender, EventArgs e)
      {
          DSPlantillaTableAdapters.PlantillaTableAdapter TAPlantilla = new DSPlantillaTableAdapters.PlantillaTableAdapter();
          DSPlantilla.PlantillaDataTable DTPlantilla = new DSPlantilla.PlantillaDataTable();
          DTPlantilla = TAPlantilla.GetPlantillaById(LstPlantillasEliminar.SelectedValue);
          if (DTPlantilla.Rows.Count > 0)
          {
              TxtCodigo.Text = DTPlantilla.Rows[0]["Codigo"].ToString();
              TxtDescripcion.Text = DTPlantilla.Rows[0]["Descripcion"].ToString();
              if ((bool)DTPlantilla.Rows[0]["Estado"] == true)
              {
                  ChkEstado.Checked = true;
              }
              else
              {
                  ChkEstado.Checked = false;
              }
              //Editor.Content =  DTPlantilla.Rows[0]["HTML"].ToString();
              Editor.Text = DTPlantilla.Rows[0]["HTML"].ToString();
              CargaPanel("VerEliminar");
          }
      }*/

    protected void BtnAddOne_Click(object sender, EventArgs e)
    {
        bool Existe = false;
        for (int i = 0; i < LstCampos.Items.Count; i++)
        {
            if (LstCampos.Items[i].Selected == true)
            {
                Existe = false;
                for (int j = 0; j < LstCamposSel.Items.Count; j++)
                {
                    if (LstCampos.Items[i].Value == LstCamposSel.Items[j].Value)
                    {
                        Existe = true;
                        break;
                    }
                }
                if (Existe == false)
                    LstCamposSel.Items.Add(new ListItem(LstCampos.Items[i].Text, LstCampos.Items[i].Value));
            }
        }
    }

    protected void BtnMenu_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }





    protected void ImgBtnRegresar_Click(object sender, ImageClickEventArgs e)
    {
        CargaPanel("Inicio");
    }
    /*   protected void ImgBtnEliminar_Click(object sender, ImageClickEventArgs e)
       {
           try
           {
               DSPlantillaTableAdapters.PlantillaTableAdapter TAPlantilla = new DSPlantillaTableAdapters.PlantillaTableAdapter();
               TAPlantilla.Plantilla_Delete(LstPlantillasEliminar.SelectedValue);

               LblResultado.Visible = true;
               LblResultado.Text = "Plantilla Eliminada correctamente";

           }
           catch (Exception ex)
           {
               throw ex;
           }
       }*/

    protected void ImgBtnModificar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DSPlantillaTableAdapters.PlantillaTableAdapter TAPlantilla = new DSPlantillaTableAdapters.PlantillaTableAdapter();
            if (Session["CodPlantillaModif"] != null)
            {
                TAPlantilla.Plantilla_Update(
                    TxtCodigo.Text,
                    TxtDescripcion.Text,
                    Convert.ToInt32(2),
                    ChkEstado.Checked,
                    Editor.Text,
                    Session["CodPlantillaModif"].ToString()
                    );

                LblResultado.Visible = true;
                LblResultado.Text = "Plantilla Modificada correctamente";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ImgBtnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DSPlantillaTableAdapters.PlantillaTableAdapter TAPlantilla = new DSPlantillaTableAdapters.PlantillaTableAdapter();
            TAPlantilla.Insert(
                TxtCodigo.Text,
                TxtDescripcion.Text,
                Convert.ToInt32(2),
                ChkEstado.Checked,
                Editor.Text);

            LblResultado.Visible = true;
            LblResultado.Text = "Plantilla Creada correctamente";

        }
        catch (Exception ex)
            {
                Console.WriteLine("{0}Exception caught.", ex);
                string s = "alert('La Plantilla numero " + TxtCodigo.Text + " ya se encuentra creada, por favor asigne otro codigo y nombre a la plantilla.');";
                ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
            }
    }
    protected void ImgBtnLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        CargaPanel("Nuevo");
    }
    protected void LstCamposSel_SelectedIndexChanged(object sender, EventArgs e)
    {
        string cadena = Editor.Text;
        string valor = "<span style='color:#ff0000;'>" + "##" + LstCamposSel.SelectedValue.ToString() + "##" + "</span>";
        cadena += valor;
        Editor.Text = cadena;
    }
}
