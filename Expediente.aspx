<%@ Page Language="C#" MasterPageFile="~/MainMasterVisor.master" AutoEventWireup="true" CodeFile="Expediente.aspx.cs" Inherits="_Expediente" %>
   
<%@ Import Namespace="System.Configuration" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1.Export, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dxpc" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>



<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<div>
    <script language="javascript" type="text/javascript">

        function url(evt,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
             //var Rad = src.innerText || src.innerHTML;
            //hidden = open('AlfaNetDocumentos/DocRecibido/DocRecibidoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + Rad + '&GrupoCodigo=' + Grupo + '&ControlDias=1&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
            function urlInt(evt,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            // var Rad = src.innerText || src.innerHTML;
            //hidden = open('AlfaNetDocumentos/DocEnviado/DocEnviadoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1' + Rad + '&GrupoCodigo=' + Grupo + '&ControlDias=1&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
        }
        //Respuesta
           function urlRpta(evt) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('AlfaNetDocumentos/DocEnviado/NuevoDocEnviadoInt.aspx?Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
        //Visor de Imagenes Recibida
           function VImagenes(evt,NumeroDocumento,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=1&Admon=S&ImagenFolio=1', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
        //Visor de Imagenes Enviada
           function VImagenesReg(evt,NumeroDocumento,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=2&Admon=S&ImagenFolio=1', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
        //Visor de Imagenes Archivo
           function VImagenesArc(evt,NumeroDocumento,CodArchivo,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=1&GrupoPadreCodigo=101&Admon=S&CZ=' + CodArchivo + '&ImagenFolio=1', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
        //Historico Recibida
           function Historico(evt,NumeroDocumento,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('AlfaNetWorkFlow/AlfaNetWF/HistorialWF.aspx?RadicadoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=1&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
         //Historico Recibida
           function HistoricoReg(evt,NumeroDocumento,Grupo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('AlfaNetWorkFlow/AlfaNetWF/HistorialWFEnviada.aspx?RadicadoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + Grupo + '&GrupoPadreCodigo=1&Admon=S', 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes');
            
        }
        
// ]]>
    </script>

    <table style="font-size: 8pt; width: 100%;">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <contenttemplate>
                        <asp:Panel ID="PnlMensaje" runat="server" Style="display: none" Width="280px" BackColor="ControlLight">
                            <table style="width: 385px">
                                <tbody>
                                    <tr>
                                        <td align="center" style="background-color: activecaption">
                                            <asp:Label ID="Label555" runat="server" Font-Bold="False" Font-Size="14pt" ForeColor="White"
                                                Text="Mensaje" Width="120px"></asp:Label></td>
                                        <td style="width: 5%; background-color: activecaption">
                                            <asp:ImageButton ID="btnCerrar" runat="server" ImageAlign="Right" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png"
                                                Style="vertical-align: top" ValidationGroup="789" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="height: 45px; background-color: highlighttxt">
                                            <br />
                                            <asp:Label ID="LblMessageBox" runat="server" Font-Size="XX-Large" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="PnlMensaje"
                            TargetControlID="LblMessageBox" BackgroundCssClass="MessageStyle">
                        </cc1:ModalPopupExtender>
                    </contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="ltexto"  runat="server" Text=""></asp:Label>
                <asp:Label ID="ltexto1" runat="server" Text=""></asp:Label>
                <asp:Label ID="ltexto2" runat="server"></asp:Label>
                <cc1:Accordion ID="MyAccordion" runat="server" AutoSize="None" ContentCssClass="accordionContent"
                    FadeTransitions="false" FramesPerSecond="40" HeaderCssClass="accordionHeader"
                    HeaderSelectedCssClass="accordionHeaderSelected" RequireOpenedPane="false" SuppressHeaderPostbacks="true"
                    TransitionDuration="250" Width="100%">
                    <Panes>
                        <cc1:AccordionPane ID="AccordionPane1" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="">Consulta Expedientes.:</a>
                            
</Header>
                            <Content>       
                            <TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 20%" colSpan=1></TD><TD colSpan=3><dxwgv:aspxgridview id="ASPxGridViewExp" runat="server" Width="100%" datasourceid="ODSBuscar" csspostfix="Office2003_Blue" cssfilepath="~/App_Themes/Office2003 Blue/{0}/styles.css" autogeneratecolumns="False" KeyFieldName="ExpedienteCodigo">
<Styles CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css">
<Header SortingImageSpacing="5px" ImageSpacing="5px"></Header>

<LoadingPanel ImageSpacing="10px"></LoadingPanel>
</Styles>

<SettingsLoadingPanel Text="Cargando&amp;hellip;" ShowImage="False"></SettingsLoadingPanel>

<SettingsPager PageSize="20" ShowSeparators="True">
<Summary AllPagesText="Paginas: {0} - {1} ({2} Registros)" Text="Pagina {0} de {1} ({2} Registros)"></Summary>
</SettingsPager>

<ImagesFilterControl>
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
</ImagesFilterControl>

<Images ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
<CollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></CollapsedButton>

<ExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></ExpandedButton>

<DetailCollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></DetailCollapsedButton>

<DetailExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></DetailExpandedButton>

<FilterRowButton Height="13px" Width="13px"></FilterRowButton>
</Images>

<SettingsText Title="Medio" GroupPanel="Coloque la Columna por la que desea agrugar" ConfirmDelete="Confirmar Eliminar" PopupEditFormCaption="Editar Formulario" EmptyHeaders="Encabezados Vacios" GroupContinuedOnNextPage="Grupo Continua En la Siguiente Pagina" EmptyDataRow="No se han Encontrado registros que Cumplan con este Criterio" CommandEdit="Editar" CommandNew="Nuevo" CommandDelete="Eliminar" CommandSelect="Seleccionar" CommandCancel="Cancelar" CommandUpdate="Actualizar" CommandClearFilter="Borrar Filtro" HeaderFilterShowAll="Mostrar todos los Encabezados de Filtro" FilterControlPopupCaption="Filtro Aplicado" FilterBarClear="Limpiar Barra de Filtro" FilterBarCreateFilter="Crear Filtro"></SettingsText>
<Columns>
<dxwgv:GridViewDataTextColumn FieldName="ExpedienteCodigoPadre" GroupIndex="0" SortIndex="0" SortOrder="Ascending" Caption="Expediente Padre" VisibleIndex="0"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="ExpedienteCodigo" ReadOnly="True" VisibleIndex="1"><DataItemTemplate>
<asp:LinkButton id="LBtnExpediente" onclick="LBtnExpediente_Click" runat="server" Width="40px" Text='<%# Bind("ExpedienteCodigo") %>' CommandName="Select"></asp:LinkButton>
</DataItemTemplate>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="ExpedienteNombre" VisibleIndex="2"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="ExpedienteMail2" Caption="NIT" VisibleIndex="3"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="ExpedienteDireccion" Caption="Folio" VisibleIndex="4"></dxwgv:GridViewDataTextColumn>
</Columns>

<Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterBar="Visible"></Settings>

<StylesEditors>
<ProgressBar Height="25px"></ProgressBar>
</StylesEditors>
</dxwgv:aspxgridview></TD><TD style="WIDTH: 20%" colSpan=1></TD></TR></TBODY></TABLE>
</Content>
                        </cc1:AccordionPane>
                        <cc1:AccordionPane ID="AccordionPane2" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="">Resultados Expedientes.:</a>
                            
</Header>
                            <Content>
                            <asp:HiddenField id="HFTipoSeleccionado" runat="server"></asp:HiddenField>
                            <dxwgv:aspxgridview id="ASPxGVExpediente" runat="server" Width="100%" csspostfix="Office2003_Blue" cssfilepath="~/App_Themes/Office2003 Blue/{0}/styles.css" autogeneratecolumns="False" OnHtmlRowPrepared="ASPxGVExpediente_HtmlRowPrepared" KeyFieldName="GrupoCodigo;NumeroDocumento;GrupoCodigoPadre">
<Styles CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css">
<Header SortingImageSpacing="5px" ImageSpacing="5px"></Header>

<LoadingPanel ImageSpacing="10px"></LoadingPanel>
</Styles>

<SettingsLoadingPanel Text="Cargando&amp;hellip;" ShowImage="False"></SettingsLoadingPanel>

<SettingsPager PageSize="20" ShowSeparators="True">
<Summary AllPagesText="Paginas: {0} - {1} ({2} Registros)" Text="Pagina {0} de {1} ({2} Registros)"></Summary>
</SettingsPager>

<ImagesFilterControl>
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
</ImagesFilterControl>

<Images ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
<CollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></CollapsedButton>

<ExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></ExpandedButton>

<DetailCollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></DetailCollapsedButton>

<DetailExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></DetailExpandedButton>

<FilterRowButton Height="13px" Width="13px"></FilterRowButton>
</Images>

<SettingsText Title="Medio" GroupPanel="Coloque la Columna por la que desea agrugar" ConfirmDelete="Confirmar Eliminar" PopupEditFormCaption="Editar Formulario" EmptyHeaders="Encabezados Vacios" GroupContinuedOnNextPage="Grupo Continua En la Siguiente Pagina" EmptyDataRow="No se han Encontrado registros que Cumplan con este Criterio" CommandEdit="Editar" CommandNew="Nuevo" CommandDelete="Eliminar" CommandSelect="Seleccionar" CommandCancel="Cancelar" CommandUpdate="Actualizar" CommandClearFilter="Borrar Filtro" HeaderFilterShowAll="Mostrar todos los Encabezados de Filtro" FilterControlPopupCaption="Filtro Aplicado" FilterBarClear="Limpiar Barra de Filtro" FilterBarCreateFilter="Crear Filtro"></SettingsText>
<Columns>
<dxwgv:GridViewDataTextColumn FieldName="AutoId" VisibleIndex="0">
<EditFormSettings Visible="False"></EditFormSettings>
<DataItemTemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("AutoId") %>'></asp:Label>
</DataItemTemplate>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="GrupoNombre" ReadOnly="True" Caption="Grupo" VisibleIndex="1"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="NumeroDocumento" ReadOnly="True" Caption="Numero Documento" VisibleIndex="2"><DataItemTemplate>
<asp:HyperLink id="HyperLink1" runat="server" Font-Size="XX-Small" Text='<%# Eval("NumeroDocumento") %>' Font-Underline="True" CssClass="LinKBtnStyleBig"></asp:HyperLink>
</DataItemTemplate>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataDateColumn FieldName="WFMovimientoFecha" ReadOnly="True" Caption="Fecha" VisibleIndex="3"></dxwgv:GridViewDataDateColumn>
<dxwgv:GridViewDataTextColumn FieldName="Detalle" ReadOnly="True" Width="200px" VisibleIndex="4"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="GrupoCodigoPadre" ReadOnly="True" Visible="False" VisibleIndex="5"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="ExpedienteDireccion" ReadOnly="True" VisibleIndex="5" Caption="Expediente Folio"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="CZ" Caption="Codigo Archivo" VisibleIndex="6"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn ReadOnly="True" VisibleIndex="7"><DataItemTemplate>
<asp:HyperLink id="HprLnkImgExtVen" runat="server" Font-Size="XX-Small" Text="Imagenes" Font-Underline="True" CssClass="LinKBtnStyleBig"></asp:HyperLink> 
</DataItemTemplate>
</dxwgv:GridViewDataTextColumn>
</Columns>

<Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterBar="Visible"></Settings>

<StylesEditors>
<ProgressBar Height="25px"></ProgressBar>
</StylesEditors>
</dxwgv:aspxgridview>
                            
</Content>
                        </cc1:AccordionPane>
                        






<cc1:AccordionPane ID="AccordionPane3" Font-Size="medium" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="">Resultados Recibidos.:</a>
                            </Header>
                            <Content>
                                   <TABLE style="WIDTH: 100%; HEIGHT: 100%"><TBODY><TR><TD><dxwgv:ASPxGridViewExporter id="ASPxGridViewExporterReg" runat="server">
</dxwgv:ASPxGridViewExporter> 
<dxpc:ASPxPopupControl id="popup" runat="server" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" ImageFolder="~/App_Themes/Office2003 Blue/{0}/" ClientInstanceName="popup" AllowDragging="True" PopupHorizontalAlign="OutsideRight" HeaderText="Vinculo a Respuesta">
<ClientSideEvents Shown="popup_Shown"></ClientSideEvents>
<ContentCollection>
<dxpc:PopupControlContentControl runat="server"><dxcp:ASPxCallbackPanel runat="server" ClientInstanceName="callbackPanel" RenderMode="Table" Width="100%" Height="100%" ID="callbackPanel" OnCallback="callbackPanel_Callback">
<LoadingPanelImage Url="~/App_Themes/Office2003 Blue/Web/Loading.gif"></LoadingPanelImage>

<LoadingDivStyle Opacity="100" BackColor="White"></LoadingDivStyle>
<PanelCollection>
<dxp:PanelContent runat="server">
<TABLE><TBODY><TR><TD align=center><asp:Literal runat="server" ID="litText"></asp:Literal>

 </TD></TR></TBODY></TABLE></dxp:PanelContent>
</PanelCollection>
</dxcp:ASPxCallbackPanel>
 </dxpc:PopupControlContentControl>
</ContentCollection>
</dxpc:ASPxPopupControl> <asp:UpdatePanel id="UpdatePanel10" runat="server"><ContentTemplate>
<dxwgv:ASPxGridView id="ASPxGridViewReg" runat="server" Width="100%" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" AutoGenerateColumns="False" KeyFieldName="RadicadoCodigo" OnHtmlRowPrepared="ASPxGridViewRad_HtmlRowPrepared">
<Styles CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css">
<Header SortingImageSpacing="5px" ImageSpacing="5px"></Header>

<LoadingPanel ImageSpacing="10px"></LoadingPanel>
</Styles>

<SettingsLoadingPanel Text="Cargando&amp;hellip;" ShowImage="False"></SettingsLoadingPanel>

<SettingsPager ShowSeparators="True">
<Summary AllPagesText="Paginas: {0} - {1} ({2} Radicados)" Text="Pagina {0} de {1} ({2} Radicados)"></Summary>
</SettingsPager>

<ImagesFilterControl>
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
</ImagesFilterControl>

<Images ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
<CollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></CollapsedButton>

<ExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></ExpandedButton>

<DetailCollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></DetailCollapsedButton>

<DetailExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></DetailExpandedButton>

<FilterRowButton Height="13px" Width="13px"></FilterRowButton>
</Images>

<SettingsText Title="Medio" GroupPanel="Coloque la Columna por la que desea agrugar" ConfirmDelete="Confirmar Eliminar" PopupEditFormCaption="Editar Formulario" EmptyHeaders="Encabezados Vacios" GroupContinuedOnNextPage="Grupo Continua En la Siguiente Pagina" EmptyDataRow="No se han Encontrado registros que Cumplan con este Criterio" CommandEdit="Editar" CommandNew="Nuevo" CommandDelete="Eliminar" CommandSelect="Seleccionar" CommandCancel="Cancelar" CommandUpdate="Actualizar" CommandClearFilter="Borrar Filtro" HeaderFilterShowAll="Mostrar todos los Encabezados de Filtro" FilterControlPopupCaption="Filtro Aplicado" FilterBarClear="Limpiar Barra de Filtro" FilterBarCreateFilter="Crear Filtro"></SettingsText>
<Columns>
<dxwgv:GridViewCommandColumn VisibleIndex="0">
<ClearFilterButton Visible="True"></ClearFilterButton>
</dxwgv:GridViewCommandColumn>
<dxwgv:GridViewDataTextColumn FieldName="RadicadoCodigo" Caption="Radicado" VisibleIndex="1">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
<asp:HyperLink id="HyperLink2" runat="server" Text='<%# Request["ExpedienteCodigo"] %>' Font-Underline="True" CssClass="LinKBtnStyleBig"></asp:HyperLink>
</DataItemTemplate>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="WFMovimientoFecha" Caption="Fecha Radicacion" VisibleIndex="2">
<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>

<dxwgv:GridViewDataTextColumn FieldName="NaturalezaNombre" Caption="Naturaleza" VisibleIndex="5">
<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="MedioNombre" Caption="Medio" VisibleIndex="6">
<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="ExpedienteNombre" Caption="Expediente" VisibleIndex="7">
<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="DependenciaNombre" Caption="Destino" VisibleIndex="8">
<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>

<dxwgv:GridViewDataTextColumn FieldName="ExpedienteCodigo" UnboundType="String" Caption="Opciones" VisibleIndex="10">
<Settings AllowDragDrop="False" AllowAutoFilterTextInputTimer="False" AllowAutoFilter="False" ShowFilterRowMenu="False" AllowHeaderFilter="False" ShowInFilterControl="False" AllowSort="False" AllowGroup="False"></Settings>
<DataItemTemplate>
<asp:HyperLink id="HyperLinkVisor" runat="server" Text="Imágenes" Font-Underline="True" CssClass="LinKBtnStyleBig"></asp:HyperLink><BR /><asp:HyperLink id="HprLnkHisExtven" runat="server" Font-Underline="True" Visible="false" CssClass="LinKBtnStyleBig">Histórico</asp:HyperLink><BR /><asp:HyperLink id="HprLnkExp" runat="server" Text="Expediente" Visible="false" CssClass="LinKBtnStyleBig" Target="_blank"></asp:HyperLink> <asp:HiddenField id="HFExp" runat="server" Value='<%# Eval("ExpedienteCodigo") %>'></asp:HiddenField> <asp:HiddenField id="HFGrupo" runat="server" Value='<%# Eval("GrupoCodigo") %>'></asp:HiddenField> 
</DataItemTemplate>
</dxwgv:GridViewDataTextColumn>
</Columns>

<Settings ShowFilterRow="True" ShowGroupPanel="True"></Settings>

<StylesEditors>
<ProgressBar Height="25px"></ProgressBar>
</StylesEditors>
</dxwgv:ASPxGridView> 
</ContentTemplate>
</asp:UpdatePanel></TD></TR></TBODY></TABLE>           
                            </Content>
                        </cc1:AccordionPane>









<cc1:AccordionPane ID="AccordionPane4" Font-Size="medium" runat="server" ContentCssClass="" HeaderCssClass="">
                            <Header>
                                <a class="accordionLink" href="">Resultados Enviados.:</a>
                            </Header>
                            <Content>
                                <TABLE style="WIDTH: 100%; HEIGHT: 100%">
                                <TBODY>
                                <TR>
                                <TD><dxwgv:ASPxGridViewExporter id="ASPxGridViewExporterRad" runat="server">
</dxwgv:ASPxGridViewExporter> 
<asp:UpdatePanel id="UpdatePanel2" runat="server"><ContentTemplate>
<dxwgv:ASPxGridView id="ASPxGridViewRad" runat="server" Width="100%" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" CssPostfix="Office2003_Blue" AutoGenerateColumns="False" KeyFieldName="RegistroCodigo" OnHtmlRowPrepared="ASPxGridViewReg_HtmlRowPrepared">
<Styles CssPostfix="Office2003_Blue" CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css">
<Header SortingImageSpacing="5px" ImageSpacing="5px"></Header>

<LoadingPanel ImageSpacing="10px"></LoadingPanel>
</Styles>

<SettingsLoadingPanel Text="Cargando&amp;hellip;" ShowImage="False"></SettingsLoadingPanel>

<SettingsPager ShowSeparators="True">
<Summary AllPagesText="Paginas: {0} - {1} ({2} Registros)" Text="Pagina {0} de {1} ({2} Registros)"></Summary>
</SettingsPager>

<ImagesFilterControl>
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
</ImagesFilterControl>

<Images ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
<CollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></CollapsedButton>

<ExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></ExpandedButton>

<DetailCollapsedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png"></DetailCollapsedButton>

<DetailExpandedButton Height="12px" Width="11px" Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png"></DetailExpandedButton>

<FilterRowButton Height="13px" Width="13px"></FilterRowButton>
</Images>

<SettingsText Title="Medio" GroupPanel="Coloque la Columna por la que desea agrugar" ConfirmDelete="Confirmar Eliminar" PopupEditFormCaption="Editar Formulario" EmptyHeaders="Encabezados Vacios" GroupContinuedOnNextPage="Grupo Continua En la Siguiente Pagina" EmptyDataRow="No se han Encontrado registros que Cumplan con este Criterio" CommandEdit="Editar" CommandNew="Nuevo" CommandDelete="Eliminar" CommandSelect="Seleccionar" CommandCancel="Cancelar" CommandUpdate="Actualizar" CommandClearFilter="Borrar Filtro" HeaderFilterShowAll="Mostrar todos los Encabezados de Filtro" FilterControlPopupCaption="Filtro Aplicado" FilterBarClear="Limpiar Barra de Filtro" FilterBarCreateFilter="Crear Filtro"></SettingsText>
<Columns>
<dxwgv:GridViewCommandColumn VisibleIndex="0">
<ClearFilterButton Visible="True"></ClearFilterButton>
</dxwgv:GridViewCommandColumn>
<dxwgv:GridViewDataTextColumn FieldName="RegistroCodigo" Caption="Registro" VisibleIndex="1">
<Settings AutoFilterCondition="Contains"></Settings>
<DataItemTemplate>
<asp:HyperLink id="HyperLink3"  runat="server" Text='<%# Request["ExpedienteCodigo"] %>' Font-Underline="True" CssClass="LinKBtnStyleBig"></asp:HyperLink>
</DataItemTemplate>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="WFMovimientoFecha" Caption="Fecha Registro" VisibleIndex="2">
<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>

<dxwgv:GridViewDataTextColumn FieldName="NaturalezaNombre" Caption="Naturaleza" VisibleIndex="5">
<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="MedioNombre" Caption="Medio" VisibleIndex="6">
<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="ExpedienteNombre" Caption="Expediente" VisibleIndex="7">
<Settings AutoFilterCondition="Contains"></Settings>
</dxwgv:GridViewDataTextColumn>

<dxwgv:GridViewDataTextColumn FieldName="Opciones" UnboundType="String" Caption="Opciones" VisibleIndex="9">
<Settings AllowDragDrop="False" AllowAutoFilterTextInputTimer="False" AllowAutoFilter="False" ShowFilterRowMenu="False" AllowHeaderFilter="False" ShowInFilterControl="False" AllowSort="False" AllowGroup="False"></Settings>
<DataItemTemplate>
<asp:HyperLink id="HyperLink4" runat="server" Text="Imágenes" Font-Underline="True" CssClass="LinKBtnStyleBig"></asp:HyperLink><BR /><asp:HyperLink id="HyperLink5"  Visible="false" runat="server" Width="55px" Font-Underline="True" CssClass="LinKBtnStyleBig">Histórico</asp:HyperLink><BR /><asp:HyperLink id="HyperLink6" Visible="false" runat="server" Text="Expediente" CssClass="LinKBtnStyleBig" Target="_blank"></asp:HyperLink> <asp:HiddenField id="HiddenField1" runat="server" Value='<%# Eval("ExpedienteCodigo") %>'></asp:HiddenField> <asp:HiddenField id="HiddenField2" runat="server" Value='<%# Eval("GrupoCodigo") %>'></asp:HiddenField>
</DataItemTemplate>
</dxwgv:GridViewDataTextColumn>
</Columns>

<Settings ShowFilterRow="True" ShowGroupPanel="True"></Settings>

<StylesEditors>
<ProgressBar Height="25px"></ProgressBar>
</StylesEditors>
</dxwgv:ASPxGridView> 
</ContentTemplate>
</asp:UpdatePanel></TD></TR></TBODY></TABLE>
                            </Content>
                        </cc1:AccordionPane>




                        
                        
                        
                        
                        </Panes>
                </cc1:Accordion>
                <asp:ObjectDataSource ID="ODSBuscar" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetExpedienteConsulta1" TypeName="DSExpedienteSQLTableAdapters.Expediente_ConsultasExpedienteTableAdapter">
                    <SelectParameters>
                        <asp:Parameter Name="ExpedienteNombre" Type="String" />
                        <asp:Parameter DefaultValue="" Name="ExpedienteCodigo" Type="String" />
                        <asp:Parameter DefaultValue="" Name="DependenciaConsulta" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                
                <asp:ObjectDataSource ID="ODSWFExpediente" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetWFMovimientoExpediente" TypeName="DSWorkFlowTableAdapters.WFMovimiento_ReadExpedienteWFMovimientoTableAdapter">
                    <SelectParameters>
                        <asp:Parameter Name="ExpedienteCodigo" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ODSBuscarGraph" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetConsultasRadicado" TypeName="RadicadoBLL" UpdateMethod="UpdateRadicado">
                    <SelectParameters>
                        <asp:Parameter Name="WFMovimientoFecha" Type="String" />
                        <asp:Parameter Name="WFMovimientoFecha1" Type="String" />
                        <asp:Parameter Name="RadicadoCodigo" Type="String" />
                        <asp:Parameter Name="RadicadoCodigo1" Type="String" />
                        <asp:Parameter DefaultValue="" Name="ExpedienteCodigo" Type="String" />
                        <asp:Parameter Name="ProcedenciaCodigo" Type="String" />
                        <asp:Parameter Name="ProcedenciaNombre" Type="String" />
                        <asp:Parameter Name="MedioCodigo" Type="String" />
                        <asp:Parameter Name="DependenciaCodDestino" Type="String" />
                        <asp:Parameter Name="DependenciaNomDestino" Type="String" />
                        <asp:Parameter Name="RadicadoDetalle" Type="String" />
                        <asp:Parameter Name="RadicadoNumeroExterno" Type="String" />
                        <asp:Parameter Name="RadicadoAnexo" Type="String" />
                        <asp:Parameter Name="NaturalezaCodigo" Type="String" />
                        <asp:Parameter Name="NaturalezaNombre" Type="String" />
                        <asp:Parameter Name="DependenciaConsulta" Type="String" />
                        <asp:Parameter Name="RadicadoGuia" Type="String" />
                    </SelectParameters>
                    
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ODSBuscarReg" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetConsultasRegistro" TypeName="RegistroBLL" InsertMethod="CopiasRegistro" UpdateMethod="UpdateRegistro">
                    <SelectParameters>
                        <asp:Parameter Name="RegistroTipo" Type="String" />
                        <asp:Parameter Name="WFMovimientoFecha" Type="String" />
                        <asp:Parameter Name="WFMovimientoFecha1" Type="String" />
                        <asp:Parameter Name="RegistroCodigo" Type="String" />
                        <asp:Parameter Name="RegistroCodigo1" Type="String" />
                        <asp:Parameter Name="RadicadoCodigo" Type="String" />
                        <asp:Parameter DefaultValue="" Name="ExpedienteCodigo" Type="String" />
                        <asp:Parameter Name="ProcedenciaCodigo" Type="String" />
                        <asp:Parameter Name="MedioCodigo" Type="String" />
                        <asp:Parameter Name="DependenciaCodDestino" Type="String" />
                        <asp:Parameter Name="RegistroDetalle" Type="String" />
                        <asp:Parameter Name="AnexoExtRegistro" Type="String" />
                        <asp:Parameter Name="NaturalezaCodigo" Type="String" />
                        <asp:Parameter Name="NaturalezaNombre" Type="String" />
                        <asp:Parameter Name="DependenciaCodigo" Type="String" />
                        <asp:Parameter Name="SerieCodigo" Type="String" />
                        <asp:Parameter Name="RemiteNombre" Type="String" />
                        <asp:Parameter Name="DestinoNombre" Type="String" />
                        <asp:Parameter Name="DependenciaConsulta" Type="String" />
                        <asp:Parameter Name="RegistroGuia" Type="String" />
                    </SelectParameters>
                   
                </asp:ObjectDataSource>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="ExceptionDetails" runat="server" Font-Size="10pt" ForeColor="Red"
                    Width="420px"></asp:Label>
                <asp:ValidationSummary Style="vertical-align: middle; text-align: float" ID="ValidationSummaryRadicado"
                    runat="server" Width="418px" Height="1px" Font-Size="10pt" DisplayMode="List"></asp:ValidationSummary>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
