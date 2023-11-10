<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" EnableEventValidation="false" ValidateRequest="false" CodeFile="WorkFlowMOD.aspx.cs" Inherits="_WorkFlow" %>

<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Configuration" %>

<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxPopupControl"
    TagPrefix="dxpc" %>

<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxCallbackPanel"
    TagPrefix="dxcp" %>
    
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxPanel"
    TagPrefix="dxp" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

<div id="global">
<script runat="server">
    protected void ODSDocRecExtVen_Filtering(object sender, ObjectDataSourceFilteringEventArgs e)
    {
        
    }
</script>
   
    
            
 <script type="text/javascript" src="_scripts/jquery-1.2.6.js">
        </script>
        <script src="jqModal.js" type="text/javascript">
        </script>
        <script type="text/javascript">
            $(document).ready(function(){
                 //thickbox replacement
    var closeModal = function(hash)
    {
        var $modalWindow = $(hash.w);
        
        //$('#jqmContent').attr('src', 'blank.html');
        $modalWindow.fadeOut('2000', function()
        {
          var windowjQuery = $('#jqmContent')[0].contentWindow.$;
          
          var f = $('#jqmContent').contents().find('#hvcontador').val();
          var g = $('#jqmContent').contents().find('#hvcontrol').val(); 
          var h = $('#jqmContent').contents().find('#HFmFecha').val();
          var $modalContainer = $('iframe', $modalWindow);
          $modalContainer.html('').attr('src', '');
          hash.o.remove();
          /*obtener los valores de los labels*/
          
          /*recibidos externos*/
          var dato1 = $('#<%= LblDocRecExtVen.ClientID %>').html();
          var dato2 = $('#<%= LblDocRecExtProxVen.ClientID %>').html();
          var dato3 = $('#<%= LblDocRecExtPen.ClientID %>').html();
          var dato4 = $('#<%= LblDocRecCopia.ClientID %>').html();
          
          /*enviados copia*/
          var dato5 = $('#<%= LblDocEnvExtCopia.ClientID %>').html();
          var dato6 = $('#<%= LblDocEnvExt.ClientID %>').html();
          
          /*enviados internos*/
          var dato7 = $('#<%= LblDocCopiaInt.ClientID %>').html();
          var dato8 = $('#<%= LblDocEnvIntVen.ClientID %>').html();
          
          /*totales de externos e internos*/
          var dato9 = $('#<%= LblDocEnvInt.ClientID %>').html();
          
          var dato10 = $('#<%= LblDocRecExt.ClientID %>').html();
          
          /*actualizar los campos respectivos*/
          
          switch (g) {
       case 'docrecven':
            var resultado = dato1 - f;
            var resultado2 = dato10 - f; 
            $('#<%= LblDocRecExtVen.ClientID %>').text(resultado);
            $('#<%= LblDocRecExt.ClientID %>').text(resultado2);
            break
       case 'docrecproxven':
            var resultado = dato2 - f;
            var resultado2 = dato10 - f; 
            $('#<%= LblDocRecExtProxVen.ClientID %>').text(resultado);
            $('#<%= LblDocRecExt.ClientID %>').text(resultado2);
            break
        case 'docrecpend':
            var resultado = dato3 - f;
            var resultado2 = dato10 - f; 
            $('#<%= LblDocRecExtPen.ClientID %>').text(resultado);
            $('#<%= LblDocRecExt.ClientID %>').text(resultado2);
            break
         case 'docreccopia':
            var resultado = dato4 - f;
            var resultado2 = dato10 - f; 
            $('#<%= LblDocRecCopia.ClientID %>').text(resultado);
            $('#<%= LblDocRecExt.ClientID %>').text(resultado2);
            break
         case 'docrecextcopia':
            var resultado = dato5 - f;
            $('#<%= LblDocEnvExtCopia.ClientID %>').text(resultado);
            $('#<%= LblDocEnvExt.ClientID %>').text(resultado);
            break
         case 'docenvint':
            var resultado = dato8 - f;
            var resultado2 = dato9 - f; 
            $('#<%= LblDocEnvIntVen.ClientID %>').text(resultado);
            $('#<%= LblDocEnvInt.ClientID %>').text(resultado2);
            break
         case 'docenvintcopia':
            var resultado = dato7 - f;
            var resultado2 = dato9 - f; 
            $('#<%= LblDocCopiaInt.ClientID %>').text(resultado);
            $('#<%= LblDocEnvInt.ClientID %>').text(resultado2);
            break
    default:
        var resultado = '';
} 
          
            
        //refresh parent
        if (hash.refreshAfterClose == true)
        {
            window.location.href = document.location.href;
        }
        /*
        //$('#jqmContent').attr('src', 'blank.html');
        $modalWindow.fadeOut('2000', function()
        {
            hash.o.remove();
            //refresh parent
              //window.location.href = 'WorkFlow.aspx';
            if (hash.refreshAfterClose === 'true')
            {
               
                window.location.href = 'WorkFlow.aspx';
                
            }
            else
            {
                 var $modalContainer = $('iframe', $modalWindow);
                $modalContainer.html('').attr('src', '');
            }*/
           
           
        });
    };
    var openInFrame = function(hash)
    {
        var $trigger = $(hash.t);
        var $modalWindow = $(hash.w);
        var $modalContainer = $('iframe', $modalWindow);
        var myUrl = $trigger.attr('href');
        var myTitle = $trigger.attr('title');
        var newWidth = 0, newHeight = 0, newLeft = 0, newTop = 0;
        $modalContainer.html('').attr('src', myUrl);
        $('#jqmTitleText').text(myTitle);
        myUrl = (myUrl.lastIndexOf("#") > -1) ? myUrl.slice(0, myUrl.lastIndexOf("#")) : myUrl;
        var queryString = (myUrl.indexOf("?") > -1) ? myUrl.substr(myUrl.indexOf("?") + 1) : null;

        if (queryString != null && typeof queryString != 'undefined')
        {
            var queryVarsArray = queryString.split("&");
            for (var i = 0; i < queryVarsArray.length; i++)
            {
                if (unescape(queryVarsArray[i].split("=")[0]) == 'width')
                {
                    var newWidth = queryVarsArray[i].split("=")[1];
                }
                if (escape(unescape(queryVarsArray[i].split("=")[0])) == 'height')
                {
                    var newHeight = queryVarsArray[i].split("=")[1];
                }
                if (escape(unescape(queryVarsArray[i].split("=")[0])) == 'jqmRefresh')
                {
                    // if true, launches a "refresh parent window" order after the modal is closed.

                    hash.refreshAfterClose = queryVarsArray[i].split("=")[1]
                } else
                {

                    hash.refreshAfterClose = false;
                }
            }
            // let's run through all possible values: 90%, nothing or a value in pixel
            if (newHeight != 0)
            {
                if (newHeight.indexOf('%') > -1)
                {

                    newHeight = Math.floor(parseInt($(window).height()) * (parseInt(newHeight) / 100));

                }
                var newTop = Math.floor(parseInt($(window).height() - newHeight) / 2);
            }
            else
            {
                newHeight = $modalWindow.height();
            }
            if (newWidth != 0)
            {
                if (newWidth.indexOf('%') > -1)
                {
                    newWidth = Math.floor(parseInt($(window).width() / 100) * parseInt(newWidth));
                }
                var newLeft = Math.floor(parseInt($(window).width() / 2) - parseInt(newWidth) / 2);

            }
            else
            {
                newWidth = $modalWindow.width();
            }

            // do the animation so that the windows stays on center of screen despite resizing
            $modalWindow.css({
                width: newWidth,
                height: newHeight,
                opacity: 0
            }).jqmShow().animate({
                width: newWidth,
                height: newHeight,
                top: newTop,
                left: newLeft,
                marginLeft: 0,
                opacity: 1
            }, 'slow');
        }
        else
        {
            // don't do animations
            $modalWindow.jqmShow();
        }

    }

    $('#modalWindow').jqm({
        overlay: 70,
        modal: true,
        trigger: 'a.thickbox',
        target: '#jqmContent',
        onHide: closeModal,
        onShow: openInFrame
    });

            });
        </script>

&nbsp;<table width="100%">
        <tr>
        <td align="left" style="height: 44px">
                <a href="WFDocVencDepv2.aspx?q=jqmodal&width=100%&height=100%&jqmRefresh=false" class="thickbox" style="text-decoration:none; color:#E6E6FA">
          &nbsp;<asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="Red" EnableViewState="False" Visible="true">Ver Documentos Vencidos de sus dependencias</asp:Label>
        </a>
        <br />
        <br />
        </td>
        </tr>
        <tr>
            <td align="center">            
       <asp:Panel ID="Panel2" runat="server" CssClass="collapsePanelHeader" BackImageUrl="~/AlfaNetImagen/MainMaster/bg-menu-main.png" style="vertical-align: top; text-align: left; font-size:small" Width="100%"> 
              <div style="padding:5px; cursor: pointer; vertical-align: middle;">
               <div style="float: left; width: 350px; font-weight: bold;">
                    <asp:Label ID="LblDocRecExt" runat="server" Font-Bold="False" Height="20px" Width="41px" Font-Italic="False">#</asp:Label>
                  DOCUMENTOS RECIBIDOS EXTERNOS</div>
                  <div style="float: left; margin-left: 20px;">
                        <asp:Label ID="Label1" runat="server" Height="20px" Width="180px" style="vertical-align: middle; text-align: left" Font-Size="Smaller">(Ver Detalles...)</asp:Label>
                  </div>
                <asp:ImageButton ID="Image1" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
        </asp:Panel>
         
                    <asp:Panel ID="Panel1" runat="server" Height="0" Width="100%" style="vertical-align: top; text-align: left; font-size:small" CssClass="collapsePanel">
            <div>
                        <table style="width: 100%; height: 100%">
                            <tr>
                                <td style="text-align: float">
                                </td>
                            </tr>
                        </table>
                        </div>
                        <asp:Panel ID="Panel3" runat="server" CssClass="collapsePanelHeader" Width="99%" BackColor="Lavender" BorderColor="Red" BorderStyle="Solid" BorderWidth="3px">
                                 <a href="WFRecvenv2.aspx?q=jqmodal&width=100%&height=100%&jqmRefresh=false" class="thickbox" style="text-decoration:none; color:#E6E6FA">
                             
                            <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                                <div style="float: left">
                                    <img src="../../AlfaNetImagen/ToolBar/alarmaroja.gif" />&nbsp;</div>
                                <div style="float: left; width: 400px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                                    &nbsp;<asp:Label ID="Label14" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">USTED TIENE</asp:Label>
                                    &nbsp;<asp:Label ID="LblDocRecExtVen" runat="server" Font-Bold="False" Height="20px" Width="25px" Font-Size="Larger" style="vertical-align: bottom; text-align: center; font: caption;">#</asp:Label>&nbsp; 
                                    <asp:Label ID="Label19" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">DOCUMENTOS VENCIDOS</asp:Label></div>
                                 <div style="float: left; margin-left: 20px;">
                                    <asp:Label ID="Label2" runat="server" ForeColor="ActiveCaption" Height="20px" Width="180px" Font-Size="Smaller">(Ver Documentos...)</asp:Label>
                                </div>
                                <asp:ImageButton ID="Image2" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" />&nbsp;
                            </div>
                            </a>
                        </asp:Panel>        
                        
                        
                            &nbsp;       
                       
                        <asp:Panel ID="Panel5" runat="server" CssClass="collapsePanelHeader" Width="99%" BorderColor="Yellow" BorderStyle="Solid" BorderWidth="3px" BackColor="Lavender">
                           <a href="WFRecProxvenv2.aspx?q=jqmodal&width=100%&height=100%&jqmRefresh=false" class="thickbox" style="text-decoration:none; color:#E6E6FA">
                             
                            <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                                    <div style="float: left">
                                    <img src="../../AlfaNetImagen/ToolBar/alarmaamarilla.gif" />&nbsp;</div>
                                <div style="float: left; width: 400px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                                    &nbsp;<asp:Label ID="Label20" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">USTED TIENE</asp:Label>
                                    &nbsp;<asp:Label ID="LblDocRecExtProxVen" runat="server" Font-Bold="False" Height="20px" Width="25px" Font-Size="Larger" style="vertical-align: bottom; text-align: center; font: caption;">#</asp:Label>&nbsp; 
                                    <asp:Label ID="Label21" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">DOCUMENTOS PROXIMOS A VENCER</asp:Label></div>
                                <div style="float: left; margin-left: 20px;">
                                    <asp:Label ID="Label3" runat="server" ForeColor="ActiveCaption" Height="20px" Width="180px" Font-Size="Smaller">(Ver Documentos...)</asp:Label>
                                </div>
                                <asp:ImageButton ID="Image3" runat="server" AlternateText="(Ver Detalles...)"
                    ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
                        </a>
                        </asp:Panel>
                     
                        &nbsp;
                 
                        <asp:Panel ID="Panel7" runat="server" CssClass="collapsePanelHeader" Width="99%" BorderColor="Green" BorderStyle="Solid" BorderWidth="3px" BackColor="Lavender">
                            <a href="WFRecPendv2.aspx?q=jqmodal&width=100%&height=100%&jqmRefresh=false" class="thickbox" style="text-decoration:none; color:#E6E6FA">
                           
                            
                            <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                                    <div style="float: left">
                                    <img src="../../AlfaNetImagen/ToolBar/alarmaverde.gif" />&nbsp;</div>
                                <div style="float: left; width: 400px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                                    &nbsp;<asp:Label ID="Label22" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">USTED TIENE</asp:Label>
                                    &nbsp;<asp:Label ID="LblDocRecExtPen" runat="server" Font-Bold="False" Height="20px" Width="25px" Font-Size="Larger" style="vertical-align: bottom; text-align: center; font: caption;">#</asp:Label>&nbsp; 
                                    <asp:Label ID="Label24" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">DOCUMENTOS PENDIENTES</asp:Label></div>
                                <div style="float: left; margin-left: 20px;">
                                    <asp:Label ID="Label4" runat="server" ForeColor="ActiveCaption" Height="20px" Width="180px" Font-Size="Smaller">(Ver Documentos...)</asp:Label>
                                </div>
                                <asp:ImageButton ID="Image4" runat="server" AlternateText="(Ver Detalles...)"
                    ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
                        </a>
                        </asp:Panel>
                        
                        &nbsp;
                       
        <asp:Panel ID="Panel25" runat="server" CssClass="collapsePanelHeader" Width="99%" BorderColor="SlateBlue" BorderStyle="Solid" BorderWidth="3px" BackColor="Lavender">
            <a href="WFRecCopiav2.aspx?q=jqmodal&width=100%&height=100%&jqmRefresh=false" class="thickbox" style="text-decoration:none; color:#E6E6FA">
                        
            <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                <div style="float: left">
                    <img src="../../AlfaNetImagen/ToolBar/wfcopias.gif" height="14" width="14" />&nbsp;</div>
                <div style="float: left; width: 400px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                    &nbsp;<asp:Label ID="Label25" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">USTED TIENE</asp:Label>&nbsp;<asp:Label ID="LblDocRecCopia" runat="server" Font-Bold="False"
                        Font-Size="Larger" Height="20px" Style="font: caption; vertical-align: bottom;
                        text-align: center" Width="25px">#</asp:Label>&nbsp; 
                    <asp:Label ID="Label26" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">DOCUMENTOS COPIA</asp:Label></div>
                <div style="float: left; margin-left: 20px;">
                    <asp:Label ID="Label23" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption"
                        Height="20px" Width="180px">(Ver Documentos...)</asp:Label>
                </div>
                <asp:ImageButton ID="ImageBtnCopia" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" />
            </div>
            </a>
        </asp:Panel>
        
                       
                     
  
                        
      </asp:Panel>
                &nbsp;
                <ajaxToolkit:CollapsiblePanelExtender ID="CPExtender1" runat="Server"
        TargetControlID="Panel1"
        ExpandControlID="Panel2"
        CollapseControlID="Panel2"
        TextLabelID="Label1"
        ImageControlID="Image1"    
        ExpandedText="(Ocultar Detalles...)"
        CollapsedText="(Ver Detalles...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true" Collapsed="False"/>
                <br />
                <asp:Panel ID="Panel16" runat="server" CssClass="collapsePanelHeader" BackImageUrl="~/AlfaNetImagen/MainMaster/bg-menu-main.png" style="vertical-align: top; text-align: left" Width="100%">
            
                    <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                        <div style="float: left; width: 350px; font-weight: bold;">
                            <asp:Label ID="LblDocEnvExt" runat="server" Font-Bold="False" Font-Italic="False" Font-Size="Larger"
                                Height="20px" Width="41px">#</asp:Label>
                            DOCUMENTOS ENVIADOS EXTERNOS</div>
                        <div style="float: left; margin-left: 20px;">
                            <asp:Label ID="Label13" runat="server" Font-Size="Smaller" Height="20px" Style="vertical-align: middle;
                                text-align: left" Width="180px">(Ver Detalles...)</asp:Label>
                        </div>
                        <asp:ImageButton ID="ImageButton4" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
                
                </asp:Panel>
       
                <asp:Panel ID="Panel9" runat="server" CssClass="collapsePanel" Height="0" Width="100%" style="vertical-align: top; text-align: left">
                    <table style="width: 100%; height: 100%">
                        <tr>
                            <td style="width: 20%">
                            </td>
                            <td>
                            </td>
                            <td style="width: 20%">
                            </td>
                        </tr>
                    </table>
                <asp:Panel ID="Panel12" runat="server" CssClass="collapsePanelHeader" Width="99%" BorderColor="SlateBlue" BorderStyle="Solid" BorderWidth="3px" BackColor="Lavender">
                 <a href="WFRecExtCopiav2.aspx?q=jqmodal&width=100%&height=100%&jqmRefresh=false" class="thickbox" style="text-decoration:none; color:#E6E6FA">
                           
                    <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                        <div style="float: left">
                            <img src="../../AlfaNetImagen/ToolBar/wfcopias.gif" height="14" width="14" />&nbsp;</div>
                        <div style="float: left; width: 400px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                            &nbsp;<asp:Label ID="Label27" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">USTED TIENE</asp:Label>
                            &nbsp;<asp:Label ID="LblDocEnvExtCopia" runat="server" Font-Bold="False" Font-Size="Larger"
                                Height="20px" Style="font: caption; vertical-align: bottom; text-align: center"
                                Width="25px">#</asp:Label>&nbsp; 
                            <asp:Label ID="Label28" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption">DOCUMENTOS COPIA EXTERNOS</asp:Label></div>
                        <div style="float: left; margin-left: 20px;">
                            <asp:Label ID="Label9" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption"
                                Height="20px" Width="180px">(Ver Documentos...)</asp:Label>
                        </div>
                        <asp:ImageButton ID="ImageButton2" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" />
        </div>
               </a>
                </asp:Panel>
                   
                    &nbsp;
                   
       
              
                </asp:Panel>
                &nbsp;
                <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender4" runat="server"
        TargetControlID="Panel9"
        ExpandControlID="Panel16"
        CollapseControlID="Panel16"
        TextLabelID="Label13"
        ImageControlID="ImageButton4"    
        ExpandedText="(Ocultar Detalles...)"
        CollapsedText="(Ver Detalles...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true" Collapsed="False"/>
                <br />
                <asp:Panel ID="Panel17" runat="server" CssClass="collapsePanelHeader" BackImageUrl="~/AlfaNetImagen/MainMaster/bg-menu-main.png" style="vertical-align: top; text-align: left" Width="100%">
                    <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                        <div style="float: left; width: 350px; font-weight: bold;">
                            <asp:Label ID="LblDocEnvInt" runat="server" Font-Bold="False" Font-Italic="False" Font-Size="Larger"
                                Height="20px" Width="41px">#</asp:Label>
                            DOCUMENTOS ENVIADOS INTERNOS</div>
                        <div style="float: left; margin-left: 20px;">
                            <asp:Label ID="Label15" runat="server" Font-Size="Smaller" Height="20px" Style="vertical-align: middle;
                                text-align: left" Width="180px">(Ver Detalles...)</asp:Label>
                        </div>
                        <asp:ImageButton ID="ImageButton5" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
                </asp:Panel>
                <asp:Panel ID="Panel18" runat="server" CssClass="collapsePanel" Width="100%" style="vertical-align: top; text-align: left" Height="0px" HorizontalAlign="Center">
                   
                    &nbsp;
                    <asp:Panel ID="Panel19" runat="server" CssClass="collapsePanelHeader" Width="99%" BackColor="Lavender" BorderColor="Green" BorderStyle="Solid" BorderWidth="3px">
                          <a href="WFRecIntv2.aspx?q=jqmodal&width=100%&height=100%&jqmRefresh=false" class="thickbox" style="text-decoration:none; color:#E6E6FA">
                        <div style="padding:5px; cursor: pointer;">
                            <div style="float: left">
                                <img src="../../AlfaNetImagen/ToolBar/alarmaverde.gif" />&nbsp;</div>
                            <div style="float: left; vertical-align: middle; color: activecaption; text-align: left; font: caption; width: 400px;">
                                &nbsp;USTED TIENE &nbsp;<asp:Label ID="LblDocEnvIntVen" runat="server" Font-Bold="False"
                                    Font-Size="Larger" Style="font: caption; vertical-align: bottom;
                                    text-align: center" Width="25px">#</asp:Label>&nbsp; &nbsp;DOCUMENTOS RECIBIDOS</div>
                            <div style="float: left; margin-left: 20px;">
                                <asp:Label ID="Label17" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption"
                                    Width="180px" Height="20px">(Ver Documentos...)</asp:Label>
                            </div>
                            <asp:ImageButton ID="ImageButton6" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
                            </a>
                    </asp:Panel>
                    &nbsp;
                    <asp:Panel ID="Panel10" runat="server" CssClass="collapsePanelHeader" Width="99%" BorderColor="SlateBlue" BorderStyle="Solid" BorderWidth="3px" BackColor="Lavender">
              <a href="WFRecIntCopiav2.aspx?q=jqmodal&width=100%&height=100%&jqmRefresh=false" class="thickbox" style="text-decoration:none; color:#E6E6FA">
                             
            <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                <div style="float: left">
                    <img src="../../AlfaNetImagen/ToolBar/wfcopias.gif" height="14" width="14" alt="" />&nbsp;</div>
                <div style="float: left; width: 400px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                    &nbsp;USTED TIENE &nbsp;<asp:Label ID="LblDocCopiaInt" runat="server" Font-Bold="False" Font-Size="Larger"
                        Height="20px" Style="font: caption; vertical-align: bottom; text-align: center"
                        Width="25px">#</asp:Label>&nbsp; DOCUMENTOS COPIA</div>
                <div style="float: left; margin-left: 20px;">
                    <asp:Label ID="Label7" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption"
                        Height="20px" Width="180px">(Ver Documentos...)</asp:Label>
                </div>
                <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" />
            </div>
            </a>
        </asp:Panel>
                    
                   
                   
                    
                    &nbsp;
                </asp:Panel>
                &nbsp;
                <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender8" runat="server"
        TargetControlID="Panel18"
        ExpandControlID="Panel17"
        CollapseControlID="Panel17"
        TextLabelID="Label15"
        ImageControlID="ImageButton5"    
        ExpandedText="(Ocultar Detalles...)"
        CollapsedText="(Ver Detalles...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true" Collapsed="False"/>
               
                <%--<asp:UpdatePanel ID="UP1" runat="server">
                    <ContentTemplate>
<BR /><asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" Width="125px" Height="63px"><TABLE width=275 border=0><TBODY><TR><TD style="HEIGHT: 32px; BACKGROUND-COLOR: activecaption" align=center><asp:Label id="LblMensaje" runat="server" Width="120px" Font-Size="14pt" ForeColor="White" Font-Bold="False" Text="Mensaje"></asp:Label></TD><TD style="WIDTH: 12%; HEIGHT: 32px; BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right"></asp:ImageButton> </TD></TR><TR><TD style="HEIGHT: 45px; BACKGROUND-COLOR: highlighttext" align=center colSpan=2><BR /><IMG src="../../AlfaNetImagen/ToolBar/error.png" />&nbsp; &nbsp;<asp:Label id="LblMessageBox" runat="server" Font-Size="12pt" ForeColor="Red"></asp:Label><BR /><BR /><asp:Button id="Button1" runat="server" BackColor="ActiveCaption" Font-Size="X-Small" ForeColor="White" Font-Bold="True" Text="Aceptar" Font-Italic="False"></asp:Button><BR /></TD></TR></TBODY></TABLE></asp:Panel> <ajaxToolkit:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="PnlMensaje" OkControlID="Button1" CancelControlID="btnCerrar" PopupControlID="PnlMensaje"></ajaxToolkit:ModalPopupExtender>
</ContentTemplate>
                </asp:UpdatePanel>--%>
                </td>
        </tr>
    </table>
</div>
<div id="modalWindow" class="jqmWindow" style="background: #999; 

filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#cccccc', endColorstr='#000000'); 
background: -webkit-gradient(linear, left top, left bottom, from(#ccc), to(#000));
background: -moz-linear-gradient(top, #ccc, #000);
">
        <div id="jqmTitle" style="background: #999; 

filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#1052A0', endColorstr='#70A7E4'); 
background: -webkit-gradient(linear, left top, left bottom, from(#1052A0), to(#70A7E4));
background: -moz-linear-gradient(top, #1052A0, #70A7E4);">

            <button class="jqmClose" style="color: red">
               Cerrar</button>
            <span id="jqmTitleText">Title of modal window</span>
        </div>
        <iframe id="jqmContent" src="" style="overflow-x: hidden;overflow-y: scroll; ">
        </iframe>
    </div>
  </asp:Content>



