using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;
using System.Drawing;
using System.IO;

public partial class _Sticker : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

      try
      {
          this.LinkButton1.Attributes.Add("onClick", "url("+CheckBox1.ClientID+");");

          this.HFNroDoc.Value = Request["RadicadoCodigo"];
          this.HFGrupo.Value = Request["GrupoCodigo"];
          if (!IsPostBack)
            {
                string Admon = Request["Admon"];
                if (Admon == "S")
                {
                    ((MainMaster)this.Master).hidemenu();
                }
                else
                {
                    ((MainMaster)this.Master).showmenu();
                }

                string nrodoc = Request["RadicadoCodigo"];
                string Grupo = Request["GrupoCodigo"];
                             
            
                //string senrodoc = (string)(Session["NroDoc"]);
                if (nrodoc != null)
                {
                    //senrodoc = Session["NroDoc"].ToString();
                    //string Tipo = senrodoc.Substring(0, 1);
                    //string nrodoc = senrodoc.Substring(1);

                    this.HFSticker.Value = nrodoc;
                    this.PnlSticker.Visible = true;
                    this.PnlSticker.Enabled = true;
                    this.LblCodigoBarras.Text = HFSticker.Value;

                    DSInfoTableAdapters.infoTableAdapter Info = new DSInfoTableAdapters.infoTableAdapter();
                    DSInfo.infoDataTable DTInfo = new DSInfo.infoDataTable();
                    DTInfo = Info.GetInfo();
                    LblCliente.Text = DTInfo[0].empresa.ToString();

                    if (Grupo == "1")
                    {
                        this.NavDocRecibido1.Visible = true;
                        this.NavDocEnviado1.Visible = false;

                        DSRadicadoTableAdapters.Radicado_ReadRadTableAdapter TARadSticker = new DSRadicadoTableAdapters.Radicado_ReadRadTableAdapter();

                        DSRadicado.Radicado_ReadRadDataTable radicado = new DSRadicado.Radicado_ReadRadDataTable();

                        radicado = TARadSticker.GetDataBy(nrodoc, Grupo);
                        DataRow[] rows = radicado.Select();

                        this.LblStickercargarA.Text = radicado[0].DependenciaNombre;
                        this.LblStickerFecRad.Text = rows[0].ItemArray[2].ToString();
                        this.LblStickerNroRad.Text = rows[0].ItemArray[0].ToString();
                        this.LblStickerUsr.Text = User.Identity.Name;
                        this.Label22.Text = "Radicado Nro" + " " + nrodoc;
                        this.NavDocRecibido1.HFRadicadoCodigoValor(nrodoc);
                        this.NavDocRecibido1.HFGrupoCodigoValor(Grupo);
                    }
                    else if (Grupo == "2")
                    {
                        this.NavDocRecibido1.Visible = false;
                        this.NavDocEnviado1.Visible = true;

                        DSRegistroTableAdapters.Registro_ReadRegistroTableAdapter TARegSticker = new DSRegistroTableAdapters.Registro_ReadRegistroTableAdapter();

                        DSRegistro.Registro_ReadRegistroDataTable registro = new DSRegistro.Registro_ReadRegistroDataTable();
                        registro = TARegSticker.GetRegistroById(nrodoc,Grupo);
                        DataRow[] rows = registro.Select();
                        
                        if (rows[0].ItemArray[2].ToString() == "0")
                            this.LblStickercargarA.Text = rows[0].ItemArray[2].ToString();
                        else
                            this.LblStickercargarA.Text = rows[0].ItemArray[3].ToString();

                            this.LblStickerFecRad.Text = rows[0].ItemArray[1].ToString();
                            this.LblStickerNroRad.Text = rows[0].ItemArray[0].ToString();
                            this.LblStickerUsr.Text = User.Identity.Name;
                            this.Label22.Text = "Registro Nro" + " " + nrodoc;
                            this.NavDocEnviado1.HFRegistroCodigoValor(nrodoc);
                            this.NavDocEnviado1.HFGrupoCodigoValor(Grupo);

                    }
                    }
                    else
                        {
                        this.PnlSticker.Enabled = false;
                        //this.PnlContainSticker.Enabled = false;
                        this.PnlSticker.Visible = false;
                        this.ExceptionDetails.Text = "No ha Cargado Ningun Documento !";
                        }
                       

            }
        }
        catch (Exception err)
        {       
            this.ExceptionDetails.Text ="Error"+ err;
        }
        finally
        {

        }

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //Response.Write("<script language='JavaScript'>window.open('../../AlfaNetDocumentos/DocRecibido/StickerImpresion.aspx?Admon=S" + "&RadicadoCodigo="+Request["RadicadoCodigo"]+ "&GrupoCodigo="+Request["GrupoCodigo"]+ "', 'NewWindow','top=0,left=0, width=800,height=600,titlebar=yes,menubar=yes, resizable=yes,scrollbars=yes')</script>");

    }
}
