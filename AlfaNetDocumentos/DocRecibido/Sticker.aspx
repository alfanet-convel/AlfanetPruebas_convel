<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeFile="Sticker.aspx.cs" Inherits="_Sticker" %>

<%@ Register Src="../DocEnviado/NavDocEnviado.ascx" TagName="NavDocEnviado" TagPrefix="uc2" %>

<%@ Register Src="../../AlfaNetDocumentos/DocRecibido/NavDocRecibido.ascx" TagName="NavDocRecibido"
    TagPrefix="uc1" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebToolbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebToolbar" TagPrefix="igtbar" %>
<%@ Register Assembly="Infragistics2.WebUI.WebCombo.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebCombo" TagPrefix="igcmbo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="Infragistics2.WebUI.WebHtmlEditor.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebHtmlEditor" TagPrefix="ighedit" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebTab.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebTab" TagPrefix="igtab" %>
<%@ Register Assembly="Infragistics2.WebUI.WebDateChooser.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebSchedule" TagPrefix="igsch" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script language="javascript" type="text/javascript">

// <!CDATA[
        function url(CheckBoxObj) 
        {
            //var email= prompt('Please enter your email address', ' ');
            //alert(document.getElementById("<%=HFNroDoc.ClientID%>").getAttribute("value"));
            //var ID = this.document.getElementById("<%=HFGrupo.ClientID%>").Value;
            //ID.Value = email;
            var CodBar;
             if (CheckBoxObj.checked == true) 
           {
           CodBar = '1';    
           } 
           else
           {
           CodBar = '0';
           }
            var Grupo = document.getElementById("<%=HFGrupo.ClientID%>").getAttribute("value");
            var NroDoc = document.getElementById("<%=HFNroDoc.ClientID%>").getAttribute("value");
            
            hidden = open('../../AlfaNetDocumentos/DocRecibido/StickerImpresion.aspx?Admon=S&RadicadoCodigo='+NroDoc+'&GrupoCodigo='+Grupo+'&CodBar='+CodBar, 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes,menubar=yes');
           //window.open('../../AlfaNetDocumentos/DocRecibido/StickerImpresion.aspx?Admon=S" + "&RadicadoCodigo="+Request["RadicadoCodigo"]+ "&GrupoCodigo="+Request["GrupoCodigo"]+ "', 'NewWindow','top=0,left=0, width=800,height=600,titlebar=yes,menubar=yes, resizable=yes,scrollbars=yes');
        }
// ]]>

    </script>
    
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td style="color: inactivecaption; font-family: Sans-Serif; font-size:10pt; background-image: none;
                    background-color: transparent; width: 601px; text-align: center; height: 219px;">
                    <uc1:NavDocRecibido ID="NavDocRecibido1" runat="server" />
                    <uc2:NavDocEnviado ID="NavDocEnviado1" runat="server" />
                    <br />
                    <asp:Label ID="Label22" runat="server" Font-Size="14pt" Height="17px" Style="text-align: left"
                            Width="696px"></asp:Label>
                    <br />
                    <br />
                            
                      <asp:Panel ID="PnlSticker" runat="server" style="text-align: left" Width="600px">      
                    <%--<a href="StickerImpresion.aspx" target ="_blank">--%>
                    <div>    
                                    <asp:Label ID="LblCliente" runat="server" Width="101px"></asp:Label>
                                    <asp:Label ID="LblStickerFecRad" runat="server" Width="164px"></asp:Label><br />
                            <asp:Label ID="LblRadNro" runat="server" Text="RadicadoNro" Width="79px"></asp:Label>
                                    <asp:Label ID="LblStickerNroRad" runat="server" Width="58px"></asp:Label>
                            <asp:Label ID="LblUser" runat="server" Text="User" Width="34px"></asp:Label>
                                    <asp:Label ID="LblStickerUsr" runat="server" Width="58px"></asp:Label><br />
                            <asp:Label ID="LblTramite" runat="server" Text="Tramite A:" Width="79px"></asp:Label>
                                    <asp:Label ID="LblStickercargarA" runat="server" Width="419px"></asp:Label><br />
                        <br />
                            <asp:Label ID="LblCodigoBarras" runat="server" Font-Names="3 of 9 Barcode" Font-Size="40pt" Width="507px"></asp:Label><br />
                        </div>
                   <%-- </a>  --%>
                    </asp:Panel>                  
                    <asp:HiddenField ID="HFSticker" runat="server" />
                    <asp:HiddenField ID="HFNroDoc" runat="server" />
                    <asp:HiddenField ID="HFGrupo" runat="server" />
                    <br />
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" PostBackUrl="javascript:void(  0 );">Version Para Impresion</asp:LinkButton>
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" Text="Codigo de Barras" /><br />
                        &nbsp;
                    <asp:Label ID="ExceptionDetails" runat="server" Font-Size="10pt" ForeColor="Red"
                        Width="346px"></asp:Label></td>
            </tr>
        </table>
  </asp:Content>
