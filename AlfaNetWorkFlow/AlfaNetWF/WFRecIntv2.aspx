<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WFRecIntv2.aspx.cs" EnableEventValidation="false"  Inherits="AlfaNetWorkFlow_WFRecVen" %>

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
    <title>P�gina sin t�tulo</title>
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
           
                var btn = document.getElementById('BtnTerminarDocRecVen');
                btn.disabled=false;
                CheckBoxObj.parentElement.parentElement.originalBgColor = CheckBoxObj.parentElement.parentElement.style.backgroundColor;
                CheckBoxObj.parentElement.parentElement.style.backgroundColor='#88AAFF'; 
           }                  
         
           else
           {
                
                var btn = document.getElementById('BtnTerminarDocRecVen');
                btn.disabled=true;
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
    <br />
    <div align="left" style="padding-left:5%">
    <asp:Button ID="BtnTerminarDocRecVen" runat="server" OnClick="BtnTerminarDocrecVen_Click" Text="Terminar" Enabled="false" />
    </div>
    <br />
   
    <!--Insercion del GridView-->
    
                                <dxwgv:ASPxGridView ID="ASPxGVDocEnvIntVen" runat="server" AutoGenerateColumns="False"
                                                                CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue"
                                                                DataSourceID="ODSDocEnvIntVen"
                                                                Width="900px"
                                                                OnHtmlRowPrepared="ASPxRowBoundEnvIntVen_HtmlRowPrepared"
                                                                EnableCallBacks="False" DataSourceForceStandardPaging="True">
                                                                
                            <styles cssfilepath="~/App_Themes/Office2003 Blue/{0}/styles.css" csspostfix="Office2003_Blue">
<Header SortingImageSpacing="5px" ImageSpacing="5px"></Header>

 

<LoadingPanel ImageSpacing="10px"></LoadingPanel>
</styles>
                            <SettingsLoadingPanel ShowImage="False" Text="Cargando&amp;hellip;" />
                            <settingspager showseparators="True">
<Summary AllPagesText="Paginas: {0} - {1} ({2} Radicados)" Text="Pagina {0} de {1} ({2} Radicados)"></Summary>
</settingspager>
                            <imagesfiltercontrol>
<AddButton AlternateText="Agregar"></AddButton>

<RemoveButton AlternateText="Remover"></RemoveButton>

<AddCondition AlternateText="Adicionar Condicion"></AddCondition>

<AddGroup AlternateText="Adiccionar Grupo"></AddGroup>

<RemoveGroup AlternateText="Remover Grupo"></RemoveGroup>

<OperationAnyOf AlternateText="Todos De"></OperationAnyOf>

<OperationBeginsWith AlternateText="Empezar por"></OperationBeginsWith>

<OperationBetween AlternateText="Entre"></OperationBetween>

<OperationContains AlternateText="Contiene"></OperationContains>

<OperationDoesNotContain AlternateText="No Contiene"></OperationDoesNotContain>

<OperationDoesNotEqual AlternateText="Diferente de"></OperationDoesNotEqual>

<OperationEndsWith AlternateText="Finaliza En"></OperationEndsWith>

<OperationEquals AlternateText="Igual A"></OperationEquals>

<OperationGreater AlternateText="Mayor Que"></OperationGreater>

<OperationGreaterOrEqual AlternateText="Mayor o Igual a"></OperationGreaterOrEqual>

<OperationIsNotNull AlternateText="No es Nulo"></OperationIsNotNull>

<OperationIsNull AlternateText="Es Nulo"></OperationIsNull>

<OperationLess AlternateText="Menor que"></OperationLess>

<OperationLessOrEqual AlternateText="Menor o Igual que"></OperationLessOrEqual>

<OperationLike AlternateText="Hace Parte de"></OperationLike>

<OperationNoneOf AlternateText="Nada de"></OperationNoneOf>

<OperationNotBetween AlternateText="Fuera de"></OperationNotBetween>

<OperationNotLike AlternateText="No Hace Parte de"></OperationNotLike>

<LoadingPanel AlternateText="Cargando..."></LoadingPanel>
</imagesfiltercontrol>
                            <images imagefolder="~/App_Themes/Office2003 Blue/{0}/">
<CollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></CollapsedButton>

<ExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></ExpandedButton>

<DetailCollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></DetailCollapsedButton>

<DetailExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></DetailExpandedButton>

 

<FilterRowButton Height="13px" Width="13px"></FilterRowButton>
</images>
                            <SettingsText CommandCancel="Cancelar" CommandClearFilter="Borrar Filtro" CommandDelete="Eliminar"
                                                                    CommandEdit="Editar" CommandNew="Nuevo" CommandSelect="Seleccionar" CommandUpdate="Actualizar"
                                                                    ConfirmDelete="Confirmar Eliminar" EmptyDataRow="No se han Encontrado registros que Cumplan con este Criterio"
                                                                    EmptyHeaders="Encabezados Vacios" FilterBarClear="Limpiar Barra de Filtro" FilterBarCreateFilter="Crear Filtro"
                                                                    FilterControlPopupCaption="Filtro Aplicado" GroupContinuedOnNextPage="Grupo Continua En la Siguiente Pagina"
                                                                    GroupPanel="Coloque la Columna por la que desea agrugar" HeaderFilterShowAll="Mostrar todos los Encabezados de Filtro"
                                                                    PopupEditFormCaption="Editar Formulario" Title="Medio" />
                            <columns>
<dxwgv:GridViewDataTextColumn Width="3px" Caption="V.B" VisibleIndex="0">
<PropertiesTextEdit Native="True"></PropertiesTextEdit>
<DataItemTemplate>
<asp:CheckBox id="SelectorDocumento" runat="server"></asp:CheckBox>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="NumeroDocumento" Width="23px" Caption="Registro&lt;br/&gt;No." VisibleIndex="1">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>

<asp:LinkButton ID="LinkButton5" runat="server" CssClass="LinKBtnStyle" 
                                            Text='<%# Eval("NumeroDocumento") %>' PostBackUrl="javascript:void(0);" Visible="False"></asp:LinkButton>
<asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" ForeColor="Blue"
                                            Text='<%# Eval("NumeroDocumento") %>'>
                                                 </asp:HyperLink>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="WFAccionNombre" Width="23px" Caption="Ver&lt;br/&gt;Acci&#243;n" VisibleIndex="2">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
      <asp:Label ID="Label2" runat="server" CssClass="LabelStyleGrid" Text='<%# Bind("WFAccionNombre") %>'></asp:Label>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt" HorizontalAlign="Left"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="DependenciaNombre" Width="30px" Caption="Remite" VisibleIndex="3">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
     <asp:Label ID="Label3" runat="server" Font-Size="Smaller"   Text='<%# Bind("DependenciaNombre") %>'></asp:Label>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt" HorizontalAlign="Left"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="DependenciaNombre" Width="11px" Caption="Proviene&lt;br/&gt;de:" VisibleIndex="4">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
     <asp:Panel ID="PnlcargadoDocExtven" runat="server" CssClass="popupControl" Style="left: 34px; border-style:none" HorizontalAlign="Left">
                                                 <div style="position: relative;left: 5px;top: 5px; ">
                                            <div style="background-color: #d1cfd0;">
                                            <div style="background-color: white;border: 0px solid gray;padding: 6px;position: relative;left: -5px;top: -5px;">
    
                                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("DependenciaNombre") %>' Width="200px"></asp:Label>
                                            </div>
                                            </div>
                                            </div>
                                            </asp:Panel>
                                            <asp:Image ID="ImgCargadoDocExtven" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user.png" CssClass="PointerCursor"  />
                                            
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender13" runat="server" PopupControlID="PnlcargadoDocExtven"
        TargetControlID="ImgCargadoDocExtven"
        PopupPosition="Right"
    OffsetX="0"
    OffsetY="0"
    PopDelay="50">
    </ajaxToolkit:HoverMenuExtender>

<HeaderStyle Font-Size="8pt"></HeaderStyle>
</DataItemTemplate>
<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="WFMovimientoNotas" Width="15px" Caption="Ver&lt;br/&gt;Post&lt;br/&gt;It" VisibleIndex="5">
<Settings AllowAutoFilter="False" AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
<asp:Image ID="ImgDocNotasExtVen" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user_comment.png" CssClass="PointerCursor"  /><asp:Panel
                                                ID="PnlNotasDocExtven" runat="server" CssClass="popupControl" Style="left: 34px; border-style:none">
                                                  <div style="position: relative;left: 5px;top: 5px; ">
                                            <div style="background-color: #d1cfd0;">
                                            <div style="background-color: white;border: 0px solid gray;padding: 6px;position: relative;left: -5px;top: -5px;">
    
                                                <asp:TextBox ID="TxtDocNotasExtVen" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="100px" Text='<%# Bind("WFMovimientoNotas") %>' TextMode="MultiLine" Width="400px" Font-Names="Tahoma, Arial, sans-serif" Font-Size="X-Small"></asp:TextBox>
                                            </div>
                                            </div>
                                            </div>
                                            </asp:Panel>
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender14" runat="server" PopupControlID="PnlNotasDocExtven"
        TargetControlID="ImgDocNotasExtVen">
    </ajaxToolkit:HoverMenuExtender>
                                        
                                        

</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="13px" Caption="Post&lt;br/&gt;It" VisibleIndex="6">
<DataItemTemplate>
      <asp:Image ID="Image5" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/post-it.gif" CssClass="PointerCursor"  />
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender10" runat="server" PopupControlID="Panel14"
                                                Position="Right" TargetControlID="Image5">
                                            </ajaxToolkit:PopupControlExtender>
                                            <asp:Panel ID="Panel14" runat="server" CssClass="popupControl" Height="150px" Width="400px">
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                <asp:TextBox ID="TextBox4" runat="server" Height="100px" TextMode="MultiLine" Width="382px"></asp:TextBox>
                                            </asp:Panel>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="12px" Caption="Rpta" VisibleIndex="7">
<DataItemTemplate>
      <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/reply.gif"
                PostBackUrl="javascript:void(0);" CssClass="PointerCursor" Enabled="False" />
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="RadicadoDetalle" Width="14px" Caption="Detalle" VisibleIndex="8">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
       <asp:Image ID="ImgDocDetalleExtVen" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/text_detalle.png" CssClass="PointerCursor"  />
                                            <asp:Panel ID="PnlDetalleDocExtven" runat="server" CssClass="popupControl" Style="left: 26px; border-style:none">
                                                    <div style="position: relative;left: 5px;top: 5px; ">
                                            <div style="background-color: #d1cfd0;">
                                            <div style="background-color: white;border: 0px solid gray;padding: 6px;position: relative;left: -5px;top: -5px;">
    
                                                <asp:TextBox ID="TextBox6" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="100px" Text='<%# Bind("RegistroDetalle") %>' TextMode="MultiLine" Width="400px" ReadOnly="True" Font-Names="Tahoma, Arial, sans-serif" Font-Size="X-Small"></asp:TextBox>
                                            </div>
                                            </div>
                                            </div>
                                            </asp:Panel>
                                            &nbsp;&nbsp;
    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender15" runat="server" PopupControlID="PnlDetalleDocExtven"
        TargetControlID="ImgDocDetalleExtVen"
        PopupPosition="Right"
    OffsetX="0"
    OffsetY="0"
    PopDelay="50">
    </ajaxToolkit:HoverMenuExtender>
                                            
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="NaturalezaNombre" Width="14px" Caption="Natu-&lt;br/&gt;raleza" VisibleIndex="9">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
           
           <asp:Panel ID="Panel1" runat="server" CssClass="popupControl" Style="left: 26px; border-style:none">
                                                    <div style="position: relative;left: 5px;top: 5px; ">
                                            <div style="background-color: #d1cfd0;">
                                            <div style="background-color: white;border: 0px solid gray;padding: 6px;position: relative;left: -5px;top: -5px;">
            <asp:Label ID="Label1" runat="server" BackColor="White" 
                Text='<%# Bind("NaturalezaNombre") %>'></asp:Label>
                </div>
                </div>
                </div>                
              
                </asp:Panel>
            <asp:Image ID="Image6" runat="server" Height="15px" ImageUrl="~/AlfaNetImagen/ToolBar/bag_green.png"
                Width="15px" />
                <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender1" runat="server"
                    PopupControlID="Panel1" TargetControlID="Image6"
                    PopupPosition="Right"
    OffsetX="0"
    OffsetY="0"
    PopDelay="50">
                </ajaxToolkit:HoverMenuExtender>                        
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle HorizontalAlign="Center" Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="162px" Caption="Cargar a:" VisibleIndex="10">
<DataItemTemplate>
<asp:HiddenField ID="HFCargar" runat="server" />
                  <asp:TextBox ID="TxtCargarDocVen" runat="server" CssClass="TextBoxStyleGrid" Font-Size="X-Small" Width="161px" Enabled="False"></asp:TextBox>
                            <asp:Panel style="LEFT: 213px; TOP: 132px"  id="PnlCargarDocVen" runat="server" CssClass="popupControl" ScrollBars="Both" Height="300px" Width="440px" HorizontalAlign="Left">
                                            <div>
                                               <asp:TreeView id="TreeVDependencia" runat="server" ExpandDepth="0" Width="440px" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate" ShowLines="True">
                                                    <ParentNodeStyle Font-Bold="True" />
                                                    <HoverNodeStyle Font-Underline="True" />
                                                    <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                    <Nodes>
                                                        <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction= "None" Text="Seleccione Dependencia..." Value="0"></asp:TreeNode>
                                                    </Nodes>
                                                    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                            NodeSpacing="0px" VerticalPadding="0px" Width="440px" />
                                                </asp:TreeView>
                                                <asp:TreeView id="TreeVFinalizar" runat="server" ExpandDepth="0" Width="440px" OnTreeNodePopulate="TreeVSerie_TreeNodePopulate" ShowLines="True">
                                                    <ParentNodeStyle Font-Bold="True" />
                                                    <HoverNodeStyle Font-Underline="True" />
                                                    <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                    <Nodes>
                                                        <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction= "None" Text="Seleccione Archivar..." Value="0" ShowCheckBox="False"></asp:TreeNode>
                                                    </Nodes>
                                                    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                        NodeSpacing="0px" VerticalPadding="0px" />
                                                      </asp:TreeView>
                                                <asp:TreeView id="TreeVMultitarea" runat="server" PopulateNodesFromClient="true" Width="440px" OnTreeNodePopulate="TreeVDependencia_TreeNodePopulate" ShowCheckBoxes="All" ExpandDepth="0" ShowLines="True">
                                                 <ParentNodeStyle Font-Bold="True" />
                                                  <HoverNodeStyle Font-Underline="True" />
                                                <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                <Nodes>
                                                <asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccion Multitarea..." Value="0" ShowCheckBox="False"></asp:TreeNode>
                                                </Nodes>
                                                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                    NodeSpacing="0px" VerticalPadding="0px" />
                                                <LeafNodeStyle ForeColor="Black" />
                                                </asp:TreeView>                                   
                                                &nbsp;
                                                &nbsp;&nbsp;</div>
                                        </asp:Panel>
                                        <ajaxToolkit:AutoCompleteExtender id="ACECargarDocEnv" runat="server" TargetControlID="TxtCargarDocVen" ServicePath="../../AutoComplete.asmx" ServiceMethod="GetDependenciaByText" MinimumPrefixLength="0" CompletionInterval="100" Enabled="True" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                        </ajaxToolkit:AutoCompleteExtender>
                                        <ajaxToolkit:PopupControlExtender id="PCECargarDocEnv" runat="server" TargetControlID="TxtCargarDocVen" PopupControlID="PnlCargarDocVen" Position="Center" OffsetY="30" OffsetX="-450">
                                        </ajaxToolkit:PopupControlExtender>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Width="149" Caption="Acci&#243;n:" VisibleIndex="11">
<DataItemTemplate>
    <asp:TextBox ID="TxtAccionDocExtVen" runat="server" CssClass="TextBoxStyleGrid" Font-Size="X-Small" Width="145px" Enabled="False"></asp:TextBox>
                                        <ajaxToolkit:AutoCompleteExtender
                                                ID="AutoCompleteExtender5" runat="server" CompletionInterval="100" MinimumPrefixLength="0"
                                                ServiceMethod="GetWFAccionTextByText" ServicePath="../../AutoComplete.asmx" TargetControlID="TxtAccionDocExtVen" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem " CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                        </ajaxToolkit:AutoCompleteExtender>
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt"></CellStyle>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="GrupoCodigo" Width="11px" Caption="Opciones" VisibleIndex="12">
<Settings AllowAutoFilter="False"></Settings>
<DataItemTemplate>
             <asp:HyperLink ID="HprLnkImgExtVen" runat="server" Text="Im�genes" CssClass="LinKBtnStyleBig" Font-Overline="False" Font-Underline="True"></asp:HyperLink><br />
                                            <asp:HyperLink ID="HprLnkHisExtven" runat="server" CssClass="LinKBtnStyleBig" Font-Overline="False" Font-Underline="True">Hist�rico</asp:HyperLink><br />
                                            <asp:HyperLink ID="HprLnkExp" runat="server" Target="_blank" Text="Expediente" CssClass="LinKBtnStyleBig"></asp:HyperLink>
    <asp:HiddenField ID="HFGrupo" Value='<%# Bind("GrupoCodigo") %>' runat="server" />    
    <asp:HiddenField ID="HFExpediente" Value='<%# Bind("ExpedienteCodigo") %>' runat="server" />   
    <asp:HiddenField ID="HFWFMovimiento" Value='<%# Bind("WFMovimientoTipo") %>' runat="server" />   
    <asp:HiddenField ID="HFWFMovimientoPaso" Value='<%# Bind("WFMovimientoPaso") %>' runat="server" />  
    <asp:HiddenField ID="HFDepCodOr" Value='<%# Bind("DependenciaCodOrigen") %>' runat="server" />  
    <!--WFProcesoCodigo -->                      
</DataItemTemplate>

<HeaderStyle Font-Size="8pt"></HeaderStyle>

<CellStyle Font-Size="8pt" HorizontalAlign="Left"></CellStyle>
</dxwgv:GridViewDataTextColumn>
</columns>
                            <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                            <styleseditors>
<ProgressBar Height="25px"></ProgressBar>
</styleseditors>
                        </dxwgv:ASPxGridView>   
    
     <asp:ObjectDataSource ID="ODSDocEnvIntVen" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocEnviadosv1"
                            TypeName="WorkFlowBLL" EnablePaging="true" SelectCountMethod="GetDocEnviadosv1Rows" OnSelecting="ODSDocRecExtVen_Selecting">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo" Type="Int32" />
                            <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                    PropertyName="Value" Type="String" />
                            <asp:Parameter DefaultValue="2" Name="GrupoCodigo" Type="String" />
                            <asp:ControlParameter ControlID="HFmFecha" DefaultValue="" Name="WFMovimientoFecha"
                                    PropertyName="Value" Type="DateTime" />
                            <asp:Parameter DefaultValue="1" Name="WFControlDias" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
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
         <asp:HiddenField ID="hvcontador" runat="server" Value="0" />
            
          <input type="hidden" id="hvcontrol" name="hvcontrol" value="docenvint" />
    
    </form>
</div>
</body>
</html>
