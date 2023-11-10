using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text;

//namespace Plantillas
//{
    public class ItsEvents : PdfPageEventHelper
    {
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            iTextSharp.text.Image header = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(@"~\Plantillas\Plantillas\Imagenes\Encabezado.png"));
            header.ScalePercent(75f);
            //header.ScalePercent(18f);
            header.SetAbsolutePosition(document.PageSize.Width - 71f - 540f, document.PageSize.Height - 101f);
            //header.SetAbsolutePosition(document.PageSize.Width - 90f - 540f, document.PageSize.Height - 110f);

            iTextSharp.text.Image footer = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(@"~\Plantillas\Plantillas\Imagenes\Pie.png"));
            footer.ScalePercent(24f);
            footer.SetAbsolutePosition(document.PageSize.Width - 72f - 540f, document.PageSize.Height - 67f - 700f);
            //footer.ScalePercent(74f);
            //footer.SetAbsolutePosition(document.PageSize.Width - 45f - 540f, document.PageSize.Height - 100f - 700f);
            document.Add(header);
            document.Add(footer);
        }
    }
//}
