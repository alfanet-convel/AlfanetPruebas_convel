using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class _TransDocPendientes : System.Web.UI.Page
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
      
    //protected void LinkButton1_Click(object sender, EventArgs e)

    //{
  //      if(RadBtnLstFindby.SelectedValue=="1")
  //      {
  //      int mNumeroDocumento = Convert.ToInt32(this.DVDocumento.DataKey[0].ToString());
  //      int mWFMovimientoPaso = Convert.ToInt32(this.DVDocumento.DataKey[1].ToString());
  //      String mDependenciaCodDestino = this.DVDocumento.DataKey[2].ToString();
  //      String mDependenciaCodOrigen = this.DVDocumento.DataKey[2].ToString();

  //      String mWFMovimientoMultitarea = "0";

  //      int mWFMovimientoTipoini = Convert.ToInt32(this.DVDocumento.DataKey[3].ToString());
  //      int mWFMovimientoTipo = 7;

  //      DateTime mWFFechaMovimientoFin= DateTime.Now;
  //      String mWFMovimientoNotas = this.DVDocumento.DataKey[5].ToString();
  //      if (mWFMovimientoNotas == "")
  //          mWFMovimientoNotas = null;
  //      String mGrupoCodigo = this.DVDocumento.DataKey[4].ToString();
  //      String mWFProcesoCodigo = null;
  //      String mWFAccionCodigo = "1";
  //      DateTime mWFMovimientoFecha = DateTime.Now;
  //      DateTime mWFMovimientoFechaEst = DateTime.Now;
  //      String mSerieCodigo = null;
  //      mSerieCodigo = this.TextBox3.Text;
  //      if (mSerieCodigo != "")
  //      {
  //          if (mSerieCodigo.Contains(" | "))
  //          {
  //              mSerieCodigo = mSerieCodigo.Remove(mSerieCodigo.IndexOf(" | "));
  //          }
  //          else
  //          {
  //              mSerieCodigo = null;
  //          }
  //      }
  //      else
  //      {
  //          mSerieCodigo = null;
  //      }
  //      DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();
  //      Object ErrorMessage = TAWFMovimiento.InsertaWFMovimiento(mNumeroDocumento,
  //                                                         mDependenciaCodDestino,
  //                                                         mWFMovimientoPaso,
  //                                                         0,
  //                                                         1,
  //                                                         mWFFechaMovimientoFin,
  //                                                         mWFMovimientoTipo,
  //                                                         mWFMovimientoTipoini,
  //                                                         mWFMovimientoNotas,
  //                                                         mGrupoCodigo,
  //                                                         mDependenciaCodOrigen,
  //                                                         mWFProcesoCodigo,
  //                                                         mWFAccionCodigo,
  //                                                         mWFMovimientoFecha,
  //                                                         mWFMovimientoFechaEst,
  //                                                         mSerieCodigo,
  //                                                         mWFMovimientoMultitarea);

  //this.TxtDocumento.Text = null;
  //string MensajeError = Convert.ToString(ErrorMessage);
  //if (MensajeError == "")
  //{
  //    this.LblMessageBox.Text = "Documento Nro. " + mNumeroDocumento + " Archivado en Serie " + this.TextBox3.Text;
  //}
  //else
  //{
  //        this.SetFocus(this.TxtDocumento);
  //        //Display a user-friendly message
  //        this.LblMessageBox.Text = "Ocurrio un problema al tratar de archivar el Documento. ";
  //        Exception inner = new Exception(MensajeError);           
  //        this.LblMessageBox.Text += ErrorHandled.FindError(inner);
  //        this.MPEMensaje.Show();
          
  //}
  //      }   
    //}
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        String DependenciaOrigen;
        String DependenciaDestino;
        DependenciaOrigen = this.TxtDocumento.Text;
        DependenciaDestino = this.TxtDepFinal.Text;

        if (DependenciaOrigen.Contains(" | "))
        {
            DependenciaOrigen = DependenciaOrigen.Remove(DependenciaOrigen.IndexOf(" | "));            
        }
        else
        {
            DependenciaOrigen = null;
        }
        if (DependenciaDestino.Contains(" | "))
        {
            DependenciaDestino = DependenciaDestino.Remove(DependenciaDestino.IndexOf(" | "));
        }
        else
        {
            DependenciaDestino = null;
        }

        if (this.ChBoxLst.Items[0].Selected)
        {
            if (this.TxtDocumento.Text != "")
            {
                ////////////////////////////////////////////////
                MembershipUser user = Membership.GetUser();
                Object CodigoRuta = user.ProviderUserKey;
                String UserId = Convert.ToString(CodigoRuta);
                ////////////////////////////////////////////////
                DSWorkFlowTableAdapters.TRANSferenciaDOCSTableAdapter TATransferencia = new DSWorkFlowTableAdapters.TRANSferenciaDOCSTableAdapter();
                DSWorkFlow.TRANSferenciaDOCSDataTable DTTranferencia = new DSWorkFlow.TRANSferenciaDOCSDataTable();
                DTTranferencia = TATransferencia.GetDocRECIBIDO(DependenciaOrigen);

                foreach (DSWorkFlow.TRANSferenciaDOCSRow row in DTTranferencia.Rows)
                {
                    DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();
                    TAWFMovimiento.InsertaWFMovimiento(row.NumeroDocumento,
                                                       DependenciaDestino,
                                                       row.WFMovimientoPaso,
                                                       1,
                                                       0,
                                                       DateTime.Now,
                                                       row.WFMovimientoTipo,
                                                       row.WFMovimientoTipo,
                                                       row.WFMovimientoNotas,
                                                       row.GrupoCodigo,
                                                       row.DependenciaCodDestino,
                                                       null,
                                                       row.WFAccionCodigo,
                                                       DateTime.Now,
                                                       DateTime.Now,
                                                       null,
                                                       "0",
                                                       UserId);
                }
            }
        }
        if (this.ChBoxLst.Items[1].Selected)
        {
            DSWorkFlowTableAdapters.TranferenciaEnviadaTableAdapter TATransferencia = new DSWorkFlowTableAdapters.TranferenciaEnviadaTableAdapter();
            DSWorkFlow.TranferenciaEnviadaDataTable DTTranferencia = new DSWorkFlow.TranferenciaEnviadaDataTable();
            DTTranferencia = TATransferencia.GetEnviada(DependenciaOrigen);
            ////////////////////////////////////////////////
            MembershipUser user = Membership.GetUser();
            Object CodigoRuta = user.ProviderUserKey;
            String UserId = Convert.ToString(CodigoRuta);
            ////////////////////////////////////////////////
            foreach (DSWorkFlow.TranferenciaEnviadaRow row in DTTranferencia.Rows)
            {
                DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();
                TAWFMovimiento.InsertaWFMovimiento(row.NumeroDocumento,
                                                   DependenciaDestino,
                                                   row.WFMovimientoPaso,
                                                   1,
                                                   0,
                                                   DateTime.Now,
                                                   row.WFMovimientoTipo,
                                                   row.WFMovimientoTipo,
                                                   row.WFMovimientoNotas,
                                                   row.GrupoCodigo,
                                                   row.DependenciaCodDestino,
                                                   null,
                                                   row.WFAccionCodigo,
                                                   DateTime.Now,
                                                   DateTime.Now,
                                                   null,
                                                   "0",
                                                   UserId);
            }
        }

    }
}