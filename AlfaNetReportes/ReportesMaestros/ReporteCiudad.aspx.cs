using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;


public partial class _ReporteCiudad : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Creo una colección de parámetros de tipo ReportParameter 
            // para añadirlos al control ReportViewer.

            List<ReportParameter> parametros = new List<ReportParameter>();
            // Añado los parámetros necesarios.
            parametros.Add(new ReportParameter("Fecha", DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString()));
            // Añado el/los parámetro/s al ReportViewer.
            this.ReportViewer1.LocalReport.SetParameters(parametros);

            // Creo uno o varios parámetros de tipo ReportParameter con sus valores.
            ReportParameter parametro = new ReportParameter("Fecha", DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString());
            // Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro });

            //this.ReportViewer1.AsyncRendering = false;
            //this.ReportViewer1.LocalReport.Refresh();
        }
        else
        {
            //this.ReportViewer1.AsyncRendering = true;
            //this.ReportViewer1.LocalReport.Refresh();
            return;
        }
        
    }
   
}
