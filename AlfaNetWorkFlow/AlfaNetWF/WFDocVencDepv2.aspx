<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WFDocVencDepv2.aspx.cs" Inherits="AlfaNetWorkFlow_WFRecDep" %>

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
    
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
<link rel="Stylesheet"
        type="text/css"
        href="../../AlfaNetStyle.css" />
<script src="_scripts/jquery-1.5.js" type="text/javascript"></script>
<style>
 
/* Z-index of #mask must lower than #boxes .window */
#mask {
  position:absolute;
  z-index:9000;
  background-color:#000;
  display:none;
}
   
#boxes .window {
  position:absolute;
  width:440px;
  height:200px;
  display:none;
  z-index:9999;
  padding:20px;
}
 
 
/* Customize your modal window here, you can add background image too */
#boxes #dialog {
  width:375px;
  height:203px;
}
</style>
<script type="text/javascript">
          
           $(document).ready(function() {
                $(".ContenidoPanel").show();
                $(".ContenidoPanel2").hide();
                $(".ArrowSube").attr("class", "ArrowSube");
                $(".ArrowSube2").attr("class", "ArrowSube2");
                $(".ExpandTexto").html("(Ocultar Detalles..)");
                $(".ExpandTexto2").html("(Ocultar Documentos..)");
                
                $("DIV.PanelDes > DIV.PanelMovible").toggle(
                function() {
                    $(this).parent().find(".ContenidoPanel").slideToggle(200);
                    $(this).parent().find(".ArrowSube").attr("class", "ArrowBaja");
                    $(this).parent().find(".ExpandTexto").html("(Mostar Detalles..)");
                },
                function() {
                    $(this).parent().find(".ContenidoPanel").slideToggle(200);
                    $(this).parent().find(".ArrowBaja").attr("class", "ArrowSube");
                    $(this).parent().find(".ExpandTexto").html("(Ocultar Detalles..)");
                    
                });
                
                $("DIV.PanelDes2 > DIV.PanelMovible2").toggle(
                function() {
                    $(this).parent().find(".ContenidoPanel2").slideToggle(200);
                    $(this).parent().find(".ArrowSube2").attr("class", "ArrowBaja2");
                    $(this).parent().find(".ExpandTexto2").html("(Mostrar Documentos..)");
                },
                function() {
                    $(this).parent().find(".ContenidoPanel2").slideToggle(200);
                    $(this).parent().find(".ArrowBaja2").attr("class", "ArrowSube2");
                    $(this).parent().find(".ExpandTexto2").html("(Ocultar Documentos..)");
                    
                });
                
                 //if close button is clicked
                     $('.window .close').click(function (e) {
                   //Cancel the link behavior
                   e.preventDefault();
                $('#mask, .window').hide();
                });    
     
                 //if mask is clicked
                 $('#mask').click(function () {
                $(this).hide();
                $('.window').hide();
                });         

            });            
        
        
        
        //Funcion para controlar el evento de cargar a:
       function Disable_Attr(e,ToggleControl,HFControl)
        {
             var s_len=ToggleControl.value.length ;
             var s_charcode = 0;
             var contador = 0;
             for (var s_i=0;s_i<s_len;s_i++)
             {
                s_charcode = ToggleControl.value.charCodeAt(s_i);
                if(s_charcode == 124)
                {
                   contador = 1;
                }
              }
              
              if(contador == 0)
              {
                 HFControl.value = "Dependencia";
              }
           
        } 
     
   
        function Resaltar_On(GridView)
        {
            if(GridView != null)
            {
                GridView.originalBgColor = GridView.style.backgroundColor;
                GridView.style.backgroundColor="#DBE7F6";
            }
        }
        function Resaltar_Off(GridView)
        {
            if(GridView != null)
            {
                GridView.style.backgroundColor = GridView.originalBgColor;
            }
        }

        function ColorRow(CheckBoxObj)
        {  
            
           if (CheckBoxObj.checked == true) 
           {
                CheckBoxObj.parentElement.parentElement.originalBgColor = CheckBoxObj.parentElement.parentElement.style.backgroundColor;
                CheckBoxObj.parentElement.parentElement.style.backgroundColor='#88AAFF'; 
           }                  
         
           else
           {
                CheckBoxObj.parentElement.parentElement.style.backgroundColor=CheckBoxObj.parentElement.parentElement.originalBgColor;
           }
        }
        function ColorRowVen(CheckBoxObj,ToggleControl,ToggleControlAccion)
        {   
           if (CheckBoxObj.checked == true) 
           {
                var btn = document.getElementById('BtnTerminarDocRecVen');
                btn.disabled=false;
                
                ToggleControl.disabled = false;
                ToggleControl.className = '';
                ToggleControl.focus();
                             
                ToggleControlAccion.disabled = false;
                ToggleControlAccion.className = '';
                //ToggleControlAccion.focus();    
                                             
                CheckBoxObj.parentElement.parentElement.originalBgColor = CheckBoxObj.parentElement.parentElement.style.backgroundColor;
                CheckBoxObj.parentElement.parentElement.style.backgroundColor='#88AAFF';
                                
           } 
           else
           {
                var btn = document.getElementById('BtnTerminarDocRecVen');
                btn.disabled=true;
                ToggleControl.disabled = true;
                ToggleControl.className = 'disabled';
                ToggleControl.innerText = "";                
                               
                ToggleControlAccion.disabled = true;
                ToggleControlAccion.className = 'disabled';
                ToggleControlAccion.innerText = "";
                
                CheckBoxObj.parentElement.parentElement.style.backgroundColor=CheckBoxObj.parentElement.parentElement.originalBgColor;
           }
        }
       
         
      
        function OnTreeClickSerie(evt,ToggleControl,HFControl) 
        {    
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick)        
          ToggleControl.value = src.innerText || src.innerHTML;
          HFControl.value = "Serie";  
//         return false;          
        }      
       
        
        function OnTreeClick2(evt,ToggleControl,HFControl) 
        {    
          var src ;
          if( window.event != window.undefined)
          {
            src = window.event.srcElement;
          }
          else
          {
            src = evt.target;
          }
        
          //var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";
          var Rad = src.innerText || src.innerHTML;                      
           if (nodeClick)        
           ToggleControl.value = Rad;           
           HFControl.value = "Dependencia";
           //return false; 
        }
           function OnTreeClickSerie(evt,ToggleControl,HFControl) 
        {    
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick)        
          ToggleControl.value = src.innerText || src.innerHTML;
          HFControl.value = "Serie";  
//         return false;          
        }      
          
           function OnTreeClickMultitarea(evt,ToggleControl,HFControl) 
        {    
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick)        
            //ToggleControl.value = "Dependencia";
            HFControl.value = "Dependencia";
            return false; 
        }
           function OnTreeClickFinalizar(evt,ToggleControl,HFControl) 
        {    
          var src = window.event != window.undefined ? window.event.srcElement : evt.target;    
          var nodeClick = src.tagName.toLowerCase() == "a";    
          if (nodeClick)        
            ToggleControl.value = "Finalizar";
            HFControl.value = "Finalizar";
        }
           function url(evt,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            var Rad = src.innerText || src.innerHTML;
            hidden = open('../../AlfaNetDocumentos/DocRecibido/DocRecibidoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + Rad + '&GrupoCodigo=' + Grupo + '&ControlDias=1&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
            function urlInt(evt,Grupo)
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            var Rad = src.innerText || src.innerHTML;
            hidden = open('../../AlfaNetDocumentos/DocEnviado/DocEnviadoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + Rad  + '&GrupoCodigo=' + Grupo + '&ControlDias=1&Admon=S&RptaImg=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
        //Respuesta
           function urlRpta(evt)
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetDocumentos/DocEnviado/NuevoDocEnviadoInt.aspx?Admon=S&RptaImg=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
        //Visor de Imagenes Recibida
           function VImagenes(evt,NumeroDocumento,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=1&Admon=S&ImagenFolio=1', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
        //Visor de Imagenes Enviada
           function VImagenesReg(evt,NumeroDocumento,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=2&Admon=S&ImagenFolio=1', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
        //Historico Recibida
           function Historico(evt,NumeroDocumento,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetWorkFlow/AlfaNetWF/HistorialWF.aspx?RadicadoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=1&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
        //Expediente
           function Expediente(evt,NumeroDocumento,Expediente,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            //var Expediente1 = "101";
            hidden = open('../../AlfaNetConsultas/Gestion/Expediente.aspx?NumeroDocumento=' + NumeroDocumento + '&ExpedienteCodigo=' + Expediente + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=101&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
         //Historico ENVIDAD
           function HistoricoReg(evt,NumeroDocumento,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetWorkFlow/AlfaNetWF/HistorialWFEnviada.aspx?RadicadoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=1&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
        
          function OnMoreInfoClick(element, key) {
            callbackPanel.PerformCallback(key);
            popup.ShowAtElement(element);
            }
        function popup_Shown(s, e) {
        callbackPanel.AdjustControl();
            }
</script>    
</head>
<body>
<div align="center">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UdPnRecExtVen" runat="server">
                                                        <ContentTemplate>
<dxpc:ASPxPopupControl id="popup" runat="server" ImageFolder="~/App_Themes/Office2003 Blue/{0}/" CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" HeaderText="Vinculo a Respuesta" PopupHorizontalAlign="OutsideRight" AllowDragging="True" ClientInstanceName="popup">
<ClientSideEvents Shown="popup_Shown"></ClientSideEvents>
<ContentCollection>
<dxpc:PopupControlContentControl runat="server"><dxcp:ASPxCallbackPanel runat="server" ClientInstanceName="callbackPanel" RenderMode="Table" Width="100%" Height="100%" ID="callbackPanel" OnCallback="callbackPanel_Callback">
<LoadingPanelImage Url="~/App_Themes/Office2003 Blue/Web/Loading.gif"></LoadingPanelImage>

<LoadingDivStyle Opacity="100" BackColor="White"></LoadingDivStyle>
<PanelCollection>
<dxp:PanelContent runat="server"><asp:Panel runat="server" ID="PnlContent">
    </asp:Panel>

 </dxp:PanelContent>
</PanelCollection>
</dxcp:ASPxCallbackPanel>
 </dxpc:PopupControlContentControl>
</ContentCollection>
</dxpc:ASPxPopupControl>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
    
    
       <table>
                                        <tr>
                                            <td align="right">
                                                &nbsp;<asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="Red" OnInit="Label5_Init" EnableViewState="False" Visible="true">Hay Documentos Vencidos de sus dependencias</asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="Panel21" runat="server" BackColor="White" BorderStyle="Solid" ForeColor="#0000C0" HorizontalAlign="Left">
                                                    <table>
                                                        <tr>
                                                            <td style="background-color: #0066ff">
                                                                            <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="White" Text="Dependencias con Documentos Vencidos"
                                                                                ></asp:Label>
                                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                                <asp:ImageButton ID="ImageButton18" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                    DataKeyNames="DependenciaCodigo" DataSourceID="ObjectDataSourceReadAllDependencias"
                                                                    ForeColor="#333333" GridLines="None" OnRowDataBound="GridView3_RowDataBound" AllowPaging="True" HorizontalAlign="Left" EmptyDataText="Sus Dependencias no tienen Documentos Vencidos." Width="360px">
                                                                    <RowStyle BackColor="#EFF3FB" />
                                                                    <Columns>
                                                                        <asp:TemplateField></asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Codigo">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label10" runat="server" Text='<%# Eval("DependenciaCodigo") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Dependencia">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label11" runat="server" Text='<%# Eval("DependenciaNombre") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Lista de Vencidos">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton6" runat="server">Ver Documentos...</asp:LinkButton><br />
                                                                                <asp:UpdatePanel ID="UpdatePanel10" runat="server" RenderMode="Inline">
                                                                                    <ContentTemplate>
                                                                                    <table style="border-left-color: #0066ff; border-bottom-color: #0066ff; border-top-style: solid; border-top-color: #0066ff; border-right-style: solid; border-left-style: solid; border-right-color: #0066ff; border-bottom-style: solid" border="2">
                                                                                        <tr>
                                                                                            <td style="background-color: #0066ff; text-align: left">
                                                                                                <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="White" Text="Lista de Documentos"
                                                                                                    ></asp:Label></td>
                                                                                            <td style="background-color: #0066ff; text-align: right">
                                                                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:ImageButton ID="ImageButton19" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Cancel.png" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                                        DataSourceID="ObjectDataReadDocumentos" ForeColor="Black" GridLines="None" AllowPaging="True" OnRowDataBound="GridView4_RowDataBound" Width="230px" BorderColor="RoyalBlue" BorderStyle="Solid" PageSize="12">
                                                                                        <RowStyle BackColor="#EFF3FB" />
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="Radicado">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Label18" runat="server" Text='<%# Eval("RadicadoCodigo") %>' Font-Underline="True" ForeColor="Blue"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="D&#237;as">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Label16" runat="server" Text='<%# Eval("DiasVencimiento") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Opciones">
                                                                                                <ItemTemplate>
                                                                                                    <asp:HyperLink ID="HprLnkImgExtVen1" runat="server" CssClass="LinKBtnStyleBig" Font-Underline="True">Imágenes</asp:HyperLink>
                                                                                                    <br />
                                                                                                    <asp:HyperLink ID="HprLnkHisExtven1" runat="server" CssClass="LinKBtnStyleBig" Font-Underline="True">Histórico</asp:HyperLink>&nbsp;<br />
                                                                                                    <asp:HyperLink ID="HprLnkExp" runat="server" CssClass="LinKBtnStyleBig" Target="_blank"
                                                                                                        Text="Expediente"></asp:HyperLink>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                                        <EditRowStyle BackColor="#2461BF" />
                                                                                        <AlternatingRowStyle BackColor="White" />
                                                                                    </asp:GridView>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                                <br />
                                                                                &nbsp;
                                                                                &nbsp;&nbsp;
                                                <asp:ObjectDataSource ID="ObjectDataReadDocumentos" runat="server" OldValuesParameterFormatString="original_{0}"
                                                    SelectMethod="GetData" TypeName="DSWorkFlowTableAdapters.WFMovimientosReadDocumentosTableAdapter">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="50" Name="DependenciaCodigo" Type="String" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                                                                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server"
                                                                                    CancelControlID="ImageButton19"
                                                                                    PopupControlID="UpdatePanel10"
                                                                                    TargetControlID="LinkButton6" Enabled="True"> 
                                                                                </ajaxToolkit:ModalPopupExtender>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                    <EditRowStyle BackColor="#2461BF" />
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    &nbsp;</asp:Panel>
                                                <asp:ObjectDataSource ID="ObjectDataSourceReadAllDependencias" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DSWorkFlowTableAdapters.WFMovimientos_ReadAllDependenciasTableAdapter">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="HFmDepCod" Name="Dependencia" PropertyName="Value"
                                                            Type="String" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                                
                                                &nbsp; &nbsp;
                                            </td>
                                        </tr>
                                    </table>
    
   
                        <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>
<asp:Panel style="BORDER-RIGHT: black 2px solid; BORDER-TOP: black 2px solid; DISPLAY: none; BORDER-LEFT: black 2px solid; BORDER-BOTTOM: black 2px solid; BACKGROUND-COLOR: white" id="PnlMensaje" runat="server"><TABLE><TBODY><TR><TD style="BACKGROUND-COLOR: activecaption" align=center><asp:Label id="Label555" runat="server" Width="120px" Font-Size="12pt" ForeColor="White" Text="Mensaje" Font-Bold="False"></asp:Label></TD><TD style="BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right" ValidationGroup="789"></asp:ImageButton>&nbsp;</TD></TR><TR><TD style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px" align=center colSpan=2><asp:Label id="LblMessageBox" runat="server" Font-Size="Small" ForeColor="Red" Font-Bold="True"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> 

</contenttemplate>
                </asp:UpdatePanel>
           <table border="0">
               <tr>
                   <td style="width: 100px; height: 45px;">
                <asp:HiddenField ID="HFmFecha" runat="server" />
                   </td>
                   <td style="width: 100px; height: 45px;">
                <asp:HiddenField ID="HFmDepCod" runat="server" />
                   </td>
                   <td style="width: 100px;">
                <asp:HiddenField ID="HFmTipo" runat="server" />
                   </td>
                   <td style="width: 100px; height: 45px;">
                <asp:HiddenField ID="HFmGrupo" runat="server" />
                   </td>
                   <td style="width: 100px; height: 45px">
                       <asp:HiddenField ID="HFMultiTarea" runat="server" />
                       <asp:SqlDataSource ID="SqlDSMultitarea" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrSQLServer %>"
                           SelectCommand="SELECT [DistriTareas] FROM [Dependencia] WHERE ([DependenciaCodigo] = @DependenciaCodigo)">
                           <SelectParameters>
                               <asp:ControlParameter ControlID="HFmDepCod" Name="DependenciaCodigo" PropertyName="Value"
                                   Type="String" />
                           </SelectParameters>
                       </asp:SqlDataSource>
                   </td>
               </tr>
           </table>
           <div id="boxes">
 
     
    <!-- #customize your modal window here -->
 
    <div id="dialog" class="window">
        <b>Testing of Modal Window</b> |
         
        <!-- close button is defined as close class -->
        <a href="#" class="close">Close it</a>
 
    </div>
 
     
    <!-- Do not remove div#mask, because you'll need it to fill the whole screen --> 
    <div id="mask">csdfsdfsdf</div>
    </div>
    
    </form>
</div>
</body>
</html>
