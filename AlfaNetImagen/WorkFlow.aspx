<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="WorkFlow.aspx.cs" Inherits="_WorkFlow" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>
    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript">
   
//            function setTextValue(textBoxID,text,panelID){
//                $get(textBoxID).value = text;
//                $get(panelID).style.display="None";
//            }    

</script>
    <table  style="width: 710px">
        <tr>
            <td align="center" style="width: 728px">
            
    
    <asp:Panel ID="Panel2" runat="server" CssClass="collapsePanelHeader" BackImageUrl="~/AlfaNetImagen/MainMaster/bg-menu-main.png" Width="736px" style="vertical-align: top; text-align: left"> 
              <div style="padding:5px; cursor: pointer; vertical-align: middle;">
               <div style="float: left; width: 350px; font-weight: bold;">
                    <asp:Label ID="LblDocRecExt" runat="server" Font-Bold="False" Height="20px" Width="41px" Font-Italic="False" Font-Size="Larger">#</asp:Label>
                  DOCUMENTOS RECIBIDOS EXTERNOS</div>
                  <div style="float: left; margin-left: 20px;">
                        <asp:Label ID="Label1" runat="server" Height="20px" Width="180px" style="vertical-align: middle; text-align: left" Font-Size="Smaller">(Ver Detalles...)</asp:Label>
                  </div>
                <asp:ImageButton ID="Image1" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
          </asp:Panel>

                    <asp:Panel ID="Panel1" runat="server" CssClass="collapsePanel" Height="0" Width="738px" style="vertical-align: top; text-align: left">
                        <asp:Panel ID="Panel3" runat="server" CssClass="collapsePanelHeader" Width="730px" BackColor="Lavender" BorderColor="Red" BorderStyle="Solid" BorderWidth="3px">
                            <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                                <div style="float: left">
                                    <img src="../../AlfaNetImagen/ToolBar/alarmaroja.gif" />&nbsp;</div>
                                <div style="float: left; width: 400px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                                    &nbsp;USTED TIENE &nbsp;<asp:Label ID="LblDocRecExtVen" runat="server" Font-Bold="False" Height="20px" Width="25px" Font-Size="Larger" style="vertical-align: bottom; text-align: center; font: caption;">#</asp:Label>&nbsp; &nbsp;DOCUMENTOS VENCIDOS</div>
                                <div style="float: left; margin-left: 20px;">
                                    <asp:Label ID="Label2" runat="server" ForeColor="ActiveCaption" Height="20px" Width="180px" Font-Size="Smaller">(Ver Documentos...)</asp:Label>
                                </div>
                                <asp:ImageButton ID="Image2" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" />&nbsp;
                            </div>
                        </asp:Panel>

                        
                        
                        <asp:Panel ID="Panel4" runat="server" CssClass="collapsePanel" Height="0" Width="736px" style="text-align: left"><table style="width: 560px">
                            <tr>
                                <td style="width: 26px; text-align: center;">
                                    <asp:Button ID="Button3" runat="server" OnClick="BtnTerminarDocrecVen_Click" Text="Terminar" /></td>
                                <td style="width: 409px;">
                                    &nbsp;Seleccionar:&nbsp;
                                    <asp:LinkButton ID="LinkButton13" runat="server" OnClick="LnkBtnSelTodos_Click" Width="54px">Todos</asp:LinkButton>
                                    ,
                                    <asp:LinkButton ID="LinkButton16" runat="server" OnClick="LnkBtnSelNinguno_Click"
                                        Width="61px">Ninguno</asp:LinkButton></td>
                            </tr>
                        </table>
                            <asp:GridView ID="GVDocRecExtVen" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CellPadding="1" DataKeyNames="NumeroDocumento,DependenciaCodDestino,WFMovimientoPaso,WFMovimientoTipo,GrupoCodigo"
                                DataSourceID="ODSDocRecExtVen" EmptyDataText="No tiene documentos recibidos externos vencidos"
                                Font-Size="Smaller" ForeColor="#333333" HorizontalAlign="Right"
                                OnRowDataBound="GVDocRecExtVen_RowDataBound" Width="730px" PageSize="5">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="SelectorDocumento" runat="server"/>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Radicado No." SortExpression="NumeroDocumento">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("NumeroDocumento") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton5" runat="server" CssClass="LinKBtnStyle" OnClick="LinkButton5_Click"
                                                Text='<%# Eval("NumeroDocumento") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle Font-Bold="True" Font-Size="Smaller" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Procedencia" SortExpression="ProcedenciaNombre">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ProcedenciaNombre") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" CssClass="LabelStyleGrid" Text='<%# Bind("ProcedenciaNombre") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Descripcion" SortExpression="WFAccionNombre">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("WFAccionNombre") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" CssClass="LabelStyleGrid" Text='<%# Bind("WFAccionNombre") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cargado" SortExpression="DependenciaNombre">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Panel ID="PnlcargadoDocExtven" runat="server" CssClass="popupControl" Style="left: 34px">
                                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:Label>
                                            </asp:Panel>
                                            <asp:Image ID="ImgCargadoDocExtven" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user.png" /><ajaxToolkit:PopupControlExtender
                                                ID="PCECargadoDocExtven" runat="server" PopupControlID="PnlcargadoDocExtven"
                                                TargetControlID="ImgCargadoDocExtven">
                                            </ajaxToolkit:PopupControlExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Notas" SortExpression="WFMovimientoNotas">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Image ID="ImgDocNotasExtVen" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/user_comment.png" /><asp:Panel
                                                ID="PnlNotasDocExtven" runat="server" CssClass="popupControl" Style="left: 34px">
                                                <asp:TextBox ID="TxtDocNotasExtVen" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="100px" Text='<%# Bind("WFMovimientoNotas") %>' TextMode="MultiLine" Width="400px"></asp:TextBox>
                                            </asp:Panel>
                                            <ajaxToolkit:PopupControlExtender ID="PCEDocNotasExtVen" runat="server" PopupControlID="PnlNotasDocExtven"
                                                TargetControlID="ImgDocNotasExtVen">
                                            </ajaxToolkit:PopupControlExtender>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="20px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Post It">
                                        <ItemTemplate>
                                            <asp:Image ID="Image5" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/post-it.gif" />
                                            <ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server" PopupControlID="Panel14"
                                                Position="Right" TargetControlID="Image5">
                                            </ajaxToolkit:PopupControlExtender>
                                            <asp:Panel ID="Panel14" runat="server" CssClass="popupControl" Height="150px" Width="400px">
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                <asp:TextBox ID="TextBox4" runat="server" Height="100px" TextMode="MultiLine" Width="382px"></asp:TextBox>
                                            </asp:Panel>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Detalle" SortExpression="RadicadoDetalle">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("RadicadoDetalle") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Image ID="ImgDocDetalleExtVen" runat="server" ImageUrl="../../AlfaNetImagen/ToolBar/text_detalle.png" />
                                            <asp:Panel ID="PnlDetalleDocExtven" runat="server" CssClass="popupControl" Style="left: 0px">
                                                <asp:TextBox ID="TextBox6" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    Height="100px" Text='<%# Bind("RadicadoDetalle") %>' TextMode="MultiLine" Width="400px"></asp:TextBox>
                                            </asp:Panel>
                                            &nbsp;
                                            <ajaxToolkit:PopupControlExtender ID="PCEDocDetalleExtven" runat="server" PopupControlID="PnlDetalleDocExtven"
                                                Position="Left" TargetControlID="ImgDocDetalleExtVen">
                                            </ajaxToolkit:PopupControlExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cargar A">
                                        <ItemTemplate>
                                            <asp:UpdatePanel id="UpdatePanel2" runat="server">
                                                <contenttemplate>
<asp:TextBox id="TxtCargarDocVen" runat="server" CssClass="TextBoxStyleGrid" __designer:wfdid="w3"></asp:TextBox>&nbsp;&nbsp;<asp:Panel id="PnlCargarDocVen" runat="server" Width="300px" CssClass="popupControl" __designer:wfdid="w4" ScrollBars="Vertical"><DIV><asp:TreeView id="TreeVSerie" runat="server" __designer:wfdid="w5" PopulateNodesFromClient="False" ExpandDepth="0" ShowLines="True" NodeWrap="True" ShowCheckBoxes="All" OnTreeNodePopulate="TreeVSerie_TreeNodePopulate">
<ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

<HoverNodeStyle Font-Underline="True"></HoverNodeStyle>

<SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True"></SelectedNodeStyle>
<Nodes>
<asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Dependencia..." Value="0"></asp:TreeNode>
</Nodes>

<NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"></NodeStyle>
</asp:TreeView> <asp:TreeView id="TreeView1" runat="server" __designer:wfdid="w6" ExpandDepth="0" ShowLines="True" NodeWrap="True" ShowCheckBoxes="All" OnSelectedNodeChanged="TreeVSerie_SelectedNodeChanged" OnTreeNodePopulate="TreeVSerie_TreeNodePopulate">
<ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

<HoverNodeStyle Font-Underline="True"></HoverNodeStyle>

<SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True"></SelectedNodeStyle>
<Nodes>
<asp:TreeNode Expanded="False" PopulateOnDemand="True" SelectAction="Expand" Text="Seleccione Dependencia..." Value="0"></asp:TreeNode>
</Nodes>

<NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"></NodeStyle>
</asp:TreeView> </DIV></asp:Panel> <ajaxToolkit:AutoCompleteExtender id="ACECargarDocEnv" runat="server" TargetControlID="TxtCargarDocVen" __designer:wfdid="w9" Enabled="True" CompletionInterval="100" MinimumPrefixLength="0" ServiceMethod="GetSerieByText" ServicePath="../../AutoComplete.asmx"></ajaxToolkit:AutoCompleteExtender> <ajaxToolkit:PopupControlExtender id="PCECargarDocEnv" runat="server" TargetControlID="TxtCargarDocVen" PopupControlID="PnlCargarDocVen" __designer:wfdid="w10" Position="Right"></ajaxToolkit:PopupControlExtender> 
</contenttemplate>
                                            </asp:UpdatePanel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Accion">
                                        <ItemTemplate>
                                            <ajaxToolkit:TextBoxWatermarkExtender ID="TBWEAccion" runat="server" TargetControlID="TxtAccionDocExtVen"
                                                WatermarkText="Seleccion Accion...">
                                            </ajaxToolkit:TextBoxWatermarkExtender>
                                            <asp:TextBox ID="TxtAccionDocExtVen" runat="server" CssClass="TextBoxStyleGrid"></asp:TextBox><ajaxToolkit:AutoCompleteExtender
                                                ID="AutoCompleteExtender1" runat="server" CompletionInterval="100" MinimumPrefixLength="0"
                                                ServiceMethod="GetWFAccionTextByText" ServicePath="../../AutoComplete.asmx" TargetControlID="TxtAccionDocExtVen">
                                            </ajaxToolkit:AutoCompleteExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Opciones" SortExpression="GrupoCodigo">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HprLnkImgExtVen" runat="server" NavigateUrl='<%# Eval("NumeroDocumento", "~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?RadicadoCodigo=1{0}          ") %>'
                                                Target="_blank" Text="Imagenes"></asp:HyperLink>
                                            <br />
                                            <asp:HyperLink ID="HprLnkHisExtven" runat="server" NavigateUrl='<%# Eval("NumeroDocumento", "~/AlfaNetWorkFlow/AlfaNetWF/HistorialWF.aspx?RadicadoCodigo={0}          ") %>'
                                                Width="55px">Historico</asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <EmptyDataTemplate>
                                    No tiene documentos recibidos externos vencidos !
                                </EmptyDataTemplate>
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                            &nbsp;
                            </asp:Panel>

                        
                        <asp:ObjectDataSource ID="ODSDocRecExtVen" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFDocVen"
                            TypeName="DSWorkFlowTableAdapters.WFMovimientoTableAdapter">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo" Type="Int32" />
                                <asp:Parameter DefaultValue="4" Name="WFMovimientoTipo2" Type="Int32" />
                                <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                    PropertyName="Value" Type="String" />
                                <asp:Parameter DefaultValue="1" Name="GrupoCodigo" Type="String" />
                                <asp:ControlParameter ControlID="HFmFecha" DefaultValue="" Name="WFMovimientoFecha"
                                    PropertyName="Value" Type="DateTime" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                            <ajaxToolkit:CollapsiblePanelExtender ID="CPExtender2" runat="server"
        TargetControlID="Panel4"
        ExpandControlID="Panel3"
        CollapseControlID="Panel3" 
        Collapsed="True"
        TextLabelID="Label2"
        ImageControlID="Image2"    
        ExpandedText="(Ocultar Documentos...)"
        CollapsedText="(Ver Documentos...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true"/>
                        <asp:Panel ID="Panel5" runat="server" CssClass="collapsePanelHeader" Width="730px" BorderColor="Yellow" BorderStyle="Solid" BorderWidth="3px" BackColor="Lavender">
                            <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                                    <div style="float: left">
                                    <img src="../../AlfaNetImagen/ToolBar/alarmaamarilla.gif" />&nbsp;</div>
                                <div style="float: left; width: 400px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                                    &nbsp;USTED TIENE &nbsp;<asp:Label ID="LblDocRecExtProxVen" runat="server" Font-Bold="False" Height="20px" Width="25px" Font-Size="Larger" style="vertical-align: bottom; text-align: center; font: caption;">#</asp:Label>&nbsp; DOCUMENTOS PROXIMOS A VENCER</div>
                                <div style="float: left; margin-left: 20px;">
                                    <asp:Label ID="Label3" runat="server" ForeColor="ActiveCaption" Height="20px" Width="180px" Font-Size="Smaller">(Ver Documentos...)</asp:Label>
                                </div>
                                <asp:ImageButton ID="Image3" runat="server" AlternateText="(Ver Detalles...)"
                    ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
                        </asp:Panel><asp:Panel ID="Panel6" runat="server" CssClass="collapsePanel" Height="0px" Width="736px">
                            <p><table style="width: 560px">
                                <tr>
                                    <td style="width: 26px; text-align: center;">
                                        <asp:Button ID="Button4" runat="server" OnClick="BtnTerminarDocRecProx_Click" Text="Terminar" /></td>
                                    <td style="width: 409px;">
                                        &nbsp;Seleccionar:&nbsp;
                                        <asp:LinkButton ID="LinkButton17" runat="server" OnClick="LnkBtnSelTodos_Click" Width="54px">Todos</asp:LinkButton>
                                        ,
                                        <asp:LinkButton ID="LinkButton18" runat="server" OnClick="LnkBtnSelNinguno_Click"
                                            Width="61px">Ninguno</asp:LinkButton></td>
                                </tr>
                            </table>
                                <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CellPadding="1" DataKeyNames="NumeroDocumento,DependenciaCodDestino,WFMovimientoPaso,WFMovimientoTipo,GrupoCodigo"
                                    DataSourceID="ODSDocRecExtProxVen" ForeColor="#333333" GridLines="None" Width="730px" EmptyDataText="No tiene documentos recibidos externos vencidos" HorizontalAlign="Right" Font-Size="Smaller" OnRowDataBound="GridView3_RowDataBound">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                                <Columns>
                                 <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="SelectorDocumento" runat="server"/>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nro Doc" SortExpression="NumeroDocumento">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("NumeroDocumento") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click" Text='<%# Eval("NumeroDocumento") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="WFAccionNombre" HeaderText="Accion" SortExpression="WFAccionNombre">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ProcedenciaNombre" HeaderText="Procedencia" SortExpression="ProcedenciaNombre">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Cargado" SortExpression="DependenciaNombre">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Panel CssClass="popupMenu" ID="PopupMenu2" runat="server">
                                                <div style="border:1px outset white;padding:2px;">
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:Label>
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="Pane200" runat="server">
                                                <img src="../../AlfaNetImagen/ToolBar/user.png" />
                                                </asp:Panel>
                                            <ajaxToolkit:HoverMenuExtender ID="hme2" runat="Server"
                                                HoverCssClass="popupHover"
                                                PopupControlID="PopupMenu2"
                                                TargetControlID="Pane200"
                                                PopDelay="35"/>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="Small" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Notas" SortExpression="WFMovimientoNotas">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Panel CssClass="popupMenu" ID="PopupMenu1" runat="server">
                                                <div style="border:1px outset white;padding:2px;">
                                                    <div>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:Label></div>
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel00" runat="server">
                                                <img src="../../AlfaNetImagen/ToolBar/user_comment.png" />
                                            </asp:Panel>
                                            <ajaxToolkit:HoverMenuExtender ID="hme1" runat="Server"
                                                HoverCssClass="popupHover"
                                                PopupControlID="PopupMenu1"
                                                PopupPosition="Center"
                                                TargetControlID="Panel00"
                                                PopDelay="25"/>
                                        </ItemTemplate>
                                        <HeaderStyle Width="20px" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="Small" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Post It">
                                            <ItemTemplate>
                                                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                                    <contenttemplate>
<ajaxToolkit:PopupControlExtender id="PCEDocProxVenNotas" runat="server" TargetControlID="ImgDocProxVenNotas" PopupControlID="PnlDocProxVenNotas" __designer:wfdid="w38" Position="Right"></ajaxToolkit:PopupControlExtender> <asp:Image id="ImgDocProxVenNotas" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/post-it.gif" __designer:wfdid="w39"></asp:Image>&nbsp;<asp:Panel style="LEFT: 28px; TOP: 20px" id="PnlDocProxVenNotas" runat="server" Width="400px" CssClass="popupControl" Height="150px" __designer:wfdid="w40">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox id="TxtDocProxVen" runat="server" Width="382px" Height="100px" __designer:wfdid="w41" TextMode="MultiLine"></asp:TextBox> <asp:LinkButton id="LnkProxVenNotas" onclick="LnkProxVenNotas_Click" runat="server" Width="47px" __designer:wfdid="w42">Enviar</asp:LinkButton></asp:Panel> 
</contenttemplate>
                                                </asp:UpdatePanel>
                                                &nbsp;
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Detalle" SortExpression="RadicadoDetalle">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("RadicadoDetalle") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox333" runat="server" BackColor="Transparent" BorderStyle="None"
                                                MaxLength="350" ReadOnly="True" Text='<%# Bind("RadicadoDetalle") %>' Width="200px"></asp:TextBox>
                                        </ItemTemplate>
                                        <ControlStyle Width="350px" />
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Opciones" SortExpression="GrupoCodigo">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HprLnkImgExtVen" runat="server" NavigateUrl='<%# Eval("NumeroDocumento", "~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?RadicadoCodigo=1{0}          ") %>'
                                                Target="_blank" Text="Imagenes"></asp:HyperLink>
                                            <br />
                                                <asp:HyperLink ID="HprLnkHisExtven" runat="server" NavigateUrl='<%# Eval("NumeroDocumento", "~/AlfaNetWorkFlow/AlfaNetWF/HistorialWF.aspx?RadicadoCodigo={0}          ") %>' 
                                                Width="55px">Historico</asp:HyperLink>                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <EmptyDataTemplate>
                                    No tiene documentos recibidos externos vencidos !
                                </EmptyDataTemplate>
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                                &nbsp;</p>
                        </asp:Panel>
                        <asp:ObjectDataSource ID="ODSDocRecExtProxVen" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFDocProxVen"
                            TypeName="DSWorkFlowTableAdapters.WFMovimientoTableAdapter">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo" Type="Int32" />
                                    <asp:Parameter DefaultValue="4" Name="WFMovimientoTipo2" Type="Int32" />
                                    <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                        PropertyName="Value" Type="String" />
                                    <asp:Parameter DefaultValue="1" Name="GrupoCodigo" Type="String" />
                                    <asp:ControlParameter ControlID="HFmFecha" DefaultValue="" Name="WFMovimientoFecha"
                                        PropertyName="Value" Type="DateTime" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        <ajaxToolkit:CollapsiblePanelExtender ID="CPExtender3" runat="server"
        TargetControlID="Panel6"
        ExpandControlID="Panel5"
        CollapseControlID="Panel5" 
        Collapsed="True"
        TextLabelID="Label3"
        ImageControlID="Image3"    
        ExpandedText="(Ocultar Documentos...)"
        CollapsedText="(Ver Documentos...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true"/>
                        <asp:Panel ID="Panel7" runat="server" CssClass="collapsePanelHeader" Width="730px" BorderColor="Green" BorderStyle="Solid" BorderWidth="3px" BackColor="Lavender">
                            <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                                    <div style="float: left">
                                    <img src="../../AlfaNetImagen/ToolBar/alarmaverde.gif" />&nbsp;</div>
                                <div style="float: left; width: 400px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                                    &nbsp;USTED TIENE &nbsp;<asp:Label ID="LblDocRecExtPen" runat="server" Font-Bold="False" Height="20px" Width="25px" Font-Size="Larger" style="vertical-align: bottom; text-align: center; font: caption;">#</asp:Label>&nbsp; DOCUMENTOS PENDIENTES</div>
                                <div style="float: left; margin-left: 20px;">
                                    <asp:Label ID="Label4" runat="server" ForeColor="ActiveCaption" Height="20px" Width="180px" Font-Size="Smaller">(Ver Documentos...)</asp:Label>
                                </div>
                                <asp:ImageButton ID="Image4" runat="server" AlternateText="(Ver Detalles...)"
                    ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
                        </asp:Panel><asp:Panel ID="Panel8" runat="server" CssClass="collapsePanel" Height="0" Width="736px">
                            <p><table style="width: 560px">
                                <tr>
                                    <td style="width: 26px; text-align: center;">
                                        <asp:Button ID="Button5" runat="server" OnClick="BtnTerminarDocRecPen_Click" Text="Terminar" /></td>
                                    <td style="width: 409px;">
                                        &nbsp;Seleccionar:&nbsp;
                                        <asp:LinkButton ID="LinkButton19" runat="server" OnClick="LnkBtnSelTodos_Click" Width="54px">Todos</asp:LinkButton>
                                        ,
                                        <asp:LinkButton ID="LinkButton20" runat="server" OnClick="LnkBtnSelNinguno_Click"
                                            Width="61px">Ninguno</asp:LinkButton></td>
                                </tr>
                            </table>
                                <asp:GridView ID="GridView8" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CellPadding="1" DataKeyNames="NumeroDocumento,DependenciaCodDestino,WFMovimientoPaso,WFMovimientoTipo,GrupoCodigo"
                                    DataSourceID="ODSDocRecExtPen" ForeColor="#333333" GridLines="None" Width="730px" EmptyDataText="No tiene documentos recibidos externos vencidos" HorizontalAlign="Right" Font-Size="Smaller" OnRowDataBound="GridView8_RowDataBound">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                                <Columns>
                                <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="SelectorDocumento" runat="server"/>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nro Doc" SortExpression="NumeroDocumento">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("NumeroDocumento") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton7_Click" Text='<%# Eval("NumeroDocumento") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="WFAccionNombre" HeaderText="Accion" SortExpression="WFAccionNombre">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ProcedenciaNombre" HeaderText="Procedencia" SortExpression="ProcedenciaNombre">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Cargado" SortExpression="DependenciaNombre">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Panel CssClass="popupMenu" ID="PopupMenu2" runat="server">
                                                <div style="border:1px outset white;padding:2px;">
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:Label>
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="Pane200" runat="server">
                                                <img src="../../AlfaNetImagen/ToolBar/user.png" /></asp:Panel>
                                            <ajaxToolkit:HoverMenuExtender ID="hme2" runat="Server"
                                                HoverCssClass="popupHover"
                                                PopupControlID="PopupMenu2"
                                                TargetControlID="Pane200"
                                                PopDelay="35"/>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="Small" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Notas" SortExpression="WFMovimientoNotas">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Panel CssClass="popupMenu" ID="PopupMenu1" runat="server">
                                                <div style="border:1px outset white;padding:2px;">
                                                    <div>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:Label></div>
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel00" runat="server">
                                                <img src="../../AlfaNetImagen/ToolBar/user_comment.png" />
                                            </asp:Panel>
                                            <ajaxToolkit:HoverMenuExtender ID="hme1" runat="Server"
                                                HoverCssClass="popupHover"
                                                PopupControlID="PopupMenu1"
                                                PopupPosition="Center"
                                                TargetControlID="Panel00"
                                                PopDelay="25"/>
                                        </ItemTemplate>
                                        <HeaderStyle Width="20px" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="Small" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Post It">
                                            <ItemTemplate>
                                                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                                    <contenttemplate>
<asp:Panel style="LEFT: 30px" id="PnlDocPenNotas" runat="server" Width="400px" CssClass="popupControl" Height="150px" __designer:wfdid="w76">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox id="TxtDocPenNotas" runat="server" Width="382px" Height="100px" __designer:wfdid="w81" TextMode="MultiLine"></asp:TextBox> <asp:LinkButton id="LnkDocPenNotas" onclick="LnkDocPenNotas_Click" runat="server" Width="47px" __designer:wfdid="w82">Enviar</asp:LinkButton></asp:Panel> <ajaxToolkit:PopupControlExtender id="PCEDocPenNotas" runat="server" TargetControlID="ImgDocPenNotas" PopupControlID="PnlDocPenNotas" __designer:wfdid="w79" Position="Right"></ajaxToolkit:PopupControlExtender> <asp:Image id="ImgDocPenNotas" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/post-it.gif" __designer:wfdid="w80"></asp:Image> 
</contenttemplate>
                                                </asp:UpdatePanel>
                                                &nbsp;
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Detalle" SortExpression="RadicadoDetalle">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("RadicadoDetalle") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox333" runat="server" BackColor="Transparent" BorderStyle="None"
                                                MaxLength="350" ReadOnly="True" Text='<%# Bind("RadicadoDetalle") %>' Width="200px"></asp:TextBox>
                                        </ItemTemplate>
                                        <ControlStyle Width="350px" />
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Opciones" SortExpression="GrupoCodigo">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HprLnkImgExtVen" runat="server" NavigateUrl='<%# Eval("NumeroDocumento", "~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?RadicadoCodigo=1{0}          ") %>'
                                                Target="_blank" Text="Imagenes"></asp:HyperLink>
                                            <br />
                                                <asp:HyperLink ID="HprLnkHisExtven" runat="server" NavigateUrl='<%# Eval("NumeroDocumento", "~/AlfaNetWorkFlow/AlfaNetWF/HistorialWF.aspx?RadicadoCodigo={0}          ") %>' 
                                                Width="55px">Historico</asp:HyperLink>                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <EmptyDataTemplate>
                                    No tiene documentos recibidos externos vencidos !
                                </EmptyDataTemplate>
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                                &nbsp;</p>
                        </asp:Panel>
                        <asp:ObjectDataSource ID="ODSDocRecExtPen" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFDocPen"
                            TypeName="DSWorkFlowTableAdapters.WFMovimientoTableAdapter">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo" Type="Int32" />
                                    <asp:Parameter DefaultValue="4" Name="WFMovimientoTipo2" Type="Int32" />
                                    <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                        PropertyName="Value" Type="String" />
                                    <asp:Parameter DefaultValue="1" Name="GrupoCodigo" Type="String" />
                                    <asp:ControlParameter ControlID="HFmFecha" DefaultValue="" Name="WFMovimientoFecha"
                                        PropertyName="Value" Type="DateTime" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        <ajaxToolkit:CollapsiblePanelExtender ID="CPExtender4" runat="server"
        TargetControlID="Panel8"
        ExpandControlID="Panel7"
        CollapseControlID="Panel7" 
        Collapsed="True"
        TextLabelID="Label4"
        ImageControlID="Image4"    
        ExpandedText="(Ocultar Documentos...)"
        CollapsedText="(Ver Documentos...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true"/><asp:Panel ID="Panel25" runat="server" CssClass="collapsePanelHeader" Width="730px" BorderColor="SlateBlue" BorderStyle="Solid" BorderWidth="3px" BackColor="Lavender">
            <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                <div style="float: left">
                    <img src="../../AlfaNetImagen/ToolBar/wfcopias.gif" height="14" width="14" />&nbsp;</div>
                <div style="float: left; width: 400px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                    &nbsp;USTED TIENE &nbsp;<asp:Label ID="LblDocRecCopia" runat="server" Font-Bold="False"
                        Font-Size="Larger" Height="20px" Style="font: caption; vertical-align: bottom;
                        text-align: center" Width="25px">#</asp:Label>&nbsp; DOCUMENTOS COPIA</div>
                <div style="float: left; margin-left: 20px;">
                    <asp:Label ID="Label23" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption"
                        Height="20px" Width="180px">(Ver Documentos...)</asp:Label>
                </div>
                <asp:ImageButton ID="ImageBtnCopia" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" />
            </div>
        </asp:Panel>
                        <asp:Panel ID="Panel26" runat="server" CssClass="collapsePanel" Height="0" Width="730px">
                            <p>
                                <table style="width: 560px">
                                    <tr>
                                        <td style="width: 26px; text-align: center;">
                                            <asp:Button ID="BtnTerminaCopia" runat="server" OnClick="BtnTerminarCop_Click" Text="Terminar" /></td>
                                        <td style="width: 409px;">
                                            &nbsp;Seleccionar:&nbsp;
                                            <asp:LinkButton ID="LnkBtnTdsCopia" runat="server" OnClick="LnkBtnSelTodos_Click"
                                                Width="54px">Todos</asp:LinkButton>
                                            ,
                                            <asp:LinkButton ID="LnkBtnNgnCopia" runat="server" OnClick="LnkBtnSelNinguno_Click"
                                                Width="61px">Ninguno</asp:LinkButton></td>
                                    </tr>
                                </table><asp:GridView ID="GridView9" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CellPadding="1" DataKeyNames="NumeroDocumento,DependenciaCodDestino,WFMovimientoPaso,WFMovimientoTipo,GrupoCodigo,WFProcesoCodigo"
                                    DataSourceID="ODSDocRecCopia" ForeColor="#333333" GridLines="None" Width="718px" EmptyDataText="No tiene documentos recibidos externos vencidos" HorizontalAlign="Right" Font-Size="Smaller" OnDataBound="GridView9_DataBound">
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="Label10" runat="server" Text='<%# Eval("WFMovimientoTipo") %>' Visible="False"
                                                    Width="27px"></asp:Label>
                                                <asp:CheckBox ID="SelectorDocumento" runat="server" /><asp:Image ID="Image6" runat="server"
                                                    Height="25px" Width="23px" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="Label10" runat="server" Text='<%# Eval("WFMovimientoTipo") %>'></asp:Label>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nro Doc" SortExpression="NumeroDocumento">
                                            <EditItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("NumeroDocumento") %>'></asp:Label>&nbsp;
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LnkBtnRecIntCop" runat="server" OnClick="LnkBtnRecIntCop_Click"
                                                    Text='<%# Eval("NumeroDocumento") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="WFAccionNombre" HeaderText="Accion" SortExpression="WFAccionNombre">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ProcedenciaNombre" HeaderText="Procedencia" SortExpression="ProcedenciaNombre">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Cargado" SortExpression="DependenciaNombre">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Panel CssClass="popupMenu" ID="PopupMenu2" runat="server">
                                                    <div style="border:1px outset white;padding:2px;">
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:Label>
                                                    </div>
                                                </asp:Panel>
                                                <asp:Panel ID="Pane200" runat="server">
                                                    <img src="../../AlfaNetImagen/ToolBar/user.png" /></asp:Panel>
                                                <ajaxToolkit:HoverMenuExtender ID="hme2" runat="Server"
                                                HoverCssClass="popupHover"
                                                PopupControlID="PopupMenu2"
                                                TargetControlID="Pane200"
                                                PopDelay="35"/>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                            <ItemStyle HorizontalAlign="Center" Font-Size="Small" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Notas" SortExpression="WFMovimientoNotas">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Panel CssClass="popupMenu" ID="PopupMenu1" runat="server">
                                                    <div style="border:1px outset white;padding:2px;">
                                                        <div>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:Label></div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:Panel ID="Panel00" runat="server">
                                                    <img src="../../AlfaNetImagen/ToolBar/user_comment.png" />
                                                </asp:Panel>
                                                <ajaxToolkit:HoverMenuExtender ID="hme1" runat="Server"
                                                HoverCssClass="popupHover"
                                                PopupControlID="PopupMenu1"
                                                PopupPosition="Center"
                                                TargetControlID="Panel00"
                                                PopDelay="25"/>
                                            </ItemTemplate>
                                            <HeaderStyle Width="20px" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Font-Size="Small" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Post It">
                                            <ItemTemplate>
                                                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                                    <contenttemplate>
<ajaxToolkit:PopupControlExtender id="PCEDocCopiaNotas" runat="server" TargetControlID="ImgDocCopiaNotas" PopupControlID="PnlDocCopiaNotas" __designer:wfdid="w100" Position="Right"></ajaxToolkit:PopupControlExtender> <asp:Image id="ImgDocCopiaNotas" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/post-it.gif" __designer:wfdid="w101"></asp:Image> <asp:Panel id="PnlDocCopiaNotas" runat="server" Width="400px" CssClass="popupControl" Height="150px" __designer:wfdid="w102">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox id="TxtDocCopiaNotas" runat="server" Width="382px" Height="100px" __designer:wfdid="w103" TextMode="MultiLine"></asp:TextBox> <asp:LinkButton id="LnkDocCopiaNotas" runat="server" Width="47px" __designer:wfdid="w104" OnClick="LnkDocCopiaNotas_Click">Enviar</asp:LinkButton></asp:Panel>
</contenttemplate>
                                                </asp:UpdatePanel>
                                                &nbsp;
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Detalle" SortExpression="RadicadoDetalle">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("RadicadoDetalle") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox333" runat="server" BackColor="Transparent" BorderStyle="None"
                                                    MaxLength="350" ReadOnly="True" Text='<%# Bind("RadicadoDetalle") %>' Width="200px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ControlStyle Width="350px" />
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Opciones" SortExpression="GrupoCodigo">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HprLnkImgExtVen" runat="server" NavigateUrl='<%# Eval("NumeroDocumento", "~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?RadicadoCodigo=1{0}          ") %>'
                                                    Target="_blank" Text="Imagenes"></asp:HyperLink>
                                                <br />
                                                <asp:HyperLink ID="HprLnkHisExtven" runat="server" NavigateUrl='<%# Eval("NumeroDocumento", "~/AlfaNetWorkFlow/AlfaNetWF/HistorialWF.aspx?RadicadoCodigo={0}          ") %>' 
                                                Width="55px">Historico</asp:HyperLink>                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <EmptyDataTemplate>
                                        No tiene documentos recibidos externos vencidos !
                                    </EmptyDataTemplate>
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </p>
                        </asp:Panel>
                        <ajaxToolkit:CollapsiblePanelExtender ID="CPEDocRecCopia" runat="server"
        TargetControlID="Panel26"
        ExpandControlID="Panel25"
        CollapseControlID="Panel25" 
        Collapsed="True"
        TextLabelID="Label23"
        ImageControlID="ImageBtnCopia"    
        ExpandedText="(Ocultar Documentos...)"
        CollapsedText="(Ver Documentos...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true"/>
                        <asp:ObjectDataSource ID="ODSDocRecCopia" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFDocCopia"
                            TypeName="DSWorkFlowTableAdapters.WFMovimientoTableAdapter">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="2" Name="WFMovimientoTipo" Type="Int32" />
                                <asp:Parameter DefaultValue="2" Name="WFMovimientoTipo2" Type="Int32" />
                                <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                        PropertyName="Value" Type="String" />
                                <asp:Parameter DefaultValue="1" Name="GrupoCodigo" Type="String" />
                                <asp:ControlParameter ControlID="HFmFecha" DefaultValue="" Name="WFMovimientoFecha"
                                        PropertyName="Value" Type="DateTime" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
  
                        
      </asp:Panel><asp:ObjectDataSource ID="ODSDocRec" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetWFDoc" TypeName="DSWorkFlowTableAdapters.WFMovimientoTableAdapter">
          <SelectParameters>
              <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo" Type="Int32" />
              <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                            PropertyName="Value" Type="String" />
              <asp:Parameter DefaultValue="1" Name="GrupoCodigo" Type="String" />
          </SelectParameters>
      </asp:ObjectDataSource>
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
        SuppressPostBack="true" Collapsed="True"/>
                <br />
                <asp:Panel ID="Panel16" runat="server" CssClass="collapsePanelHeader" BackImageUrl="~/AlfaNetImagen/MainMaster/bg-menu-main.png" Width="736px" style="vertical-align: top; text-align: left">
                    <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                        <div style="float: left; width: 350px; font-weight: bold;">
                            <asp:Label ID="Label12" runat="server" Font-Bold="False" Font-Italic="False" Font-Size="Larger"
                                Height="20px" Width="41px">#</asp:Label>
                            DOCUMENTOS ENVIADOS EXTERNOS</div>
                        <div style="float: left; margin-left: 20px;">
                            <asp:Label ID="Label13" runat="server" Font-Size="Smaller" Height="20px" Style="vertical-align: middle;
                                text-align: left" Width="180px">(Ver Detalles...)</asp:Label>
                        </div>
                        <asp:ImageButton ID="ImageButton4" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
                </asp:Panel>
                <asp:Panel ID="Panel9" runat="server" CssClass="collapsePanel" Height="0" Width="738px" style="vertical-align: top; text-align: left"><asp:Panel ID="Panel12" runat="server" CssClass="collapsePanelHeader" Width="730px" BorderColor="SlateBlue" BorderStyle="Solid" BorderWidth="3px" BackColor="Lavender">
                    <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                        <div style="float: left">
                            <img src="../../AlfaNetImagen/ToolBar/wfcopias.gif" height="14" width="14" />&nbsp;</div>
                        <div style="float: left; width: 400px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                            &nbsp;USTED TIENE &nbsp;<asp:Label ID="LblDocEnvExtCopia" runat="server" Font-Bold="False" Font-Size="Larger"
                                Height="20px" Style="font: caption; vertical-align: bottom; text-align: center"
                                Width="25px">#</asp:Label>&nbsp; DOCUMENTOS COPIA</div>
                        <div style="float: left; margin-left: 20px;">
                            <asp:Label ID="Label9" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption"
                                Height="20px" Width="180px">(Ver Documentos...)</asp:Label>
                        </div>
                        <asp:ImageButton ID="ImageButton2" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" />
                    </div>
                </asp:Panel>
                    <asp:Panel ID="Panel11" runat="server" CssClass="collapsePanel" Height="0" Width="736px" style="text-align: left">
                        <table style="width: 360px">
                            <tr>
                                <td style="width: 25px; text-align: center;">
                                    <asp:Button ID="BtnTerminarCopEnvExt" runat="server" OnClick="BtnTerminarCopEnvExt_Click" Text="Terminar" /></td>
                                <td style="width: 190px;">
                                    &nbsp;Seleccionar:&nbsp;
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LnkBtnSelTodos_Click" Width="20px">Todos</asp:LinkButton>
                                    ,
                                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LnkBtnSelNinguno_Click"
                                        Width="34px">Ninguno</asp:LinkButton></td>
                            </tr>
                        </table><asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CellPadding="1" DataKeyNames="NumeroDocumento,DependenciaCodDestino,WFMovimientoPaso,WFMovimientoTipo,GrupoCodigo"
                                    DataSourceID="ODSDocEnvExt" ForeColor="#333333" GridLines="None" Width="730px" EmptyDataText="No tiene documentos recibidos externos vencidos" HorizontalAlign="Right" Font-Size="Smaller">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="SelectorDocumento" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nro Doc" SortExpression="NumeroDocumento">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("NumeroDocumento") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        &nbsp;<asp:LinkButton ID="LnkBtnEnvIntVen" runat="server" OnClick="LnkBtnEnvIntCop_Click"
                                            Text='<%# Eval("NumeroDocumento") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="WFAccionNombre" HeaderText="Accion" SortExpression="WFAccionNombre">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DependenciaNombre" HeaderText="Remite" SortExpression="DependenciaNombre">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Cargado" SortExpression="DependenciaNombre">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Panel CssClass="popupMenu" ID="PopupMenu2" runat="server">
                                            <div style="border:1px outset white;padding:2px;">
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:Label>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="Pane200" runat="server">
                                            <img src="../../AlfaNetImagen/ToolBar/user.png" /></asp:Panel>
                                        <ajaxToolkit:HoverMenuExtender ID="hme2" runat="Server"
                                                HoverCssClass="popupHover"
                                                PopupControlID="PopupMenu2"
                                                TargetControlID="Pane200"
                                                PopDelay="35"/>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" Font-Size="Small" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Notas" SortExpression="WFMovimientoNotas">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Panel CssClass="popupMenu" ID="PopupMenu1" runat="server">
                                            <div style="border:1px outset white;padding:2px;">
                                                <div>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:Label></div>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="Panel00" runat="server">
                                            <img src="../../AlfaNetImagen/ToolBar/user_comment.png" />
                                        </asp:Panel>
                                        <ajaxToolkit:HoverMenuExtender ID="hme1" runat="Server"
                                                HoverCssClass="popupHover"
                                                PopupControlID="PopupMenu1"
                                                PopupPosition="Center"
                                                TargetControlID="Panel00"
                                                PopDelay="25"/>
                                    </ItemTemplate>
                                    <HeaderStyle Width="20px" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Font-Size="Small" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Post It">
                                            <ItemTemplate>
                                                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                                    <contenttemplate>
<ajaxToolkit:PopupControlExtender id="PCEDocExtCopaNotas" runat="server" TargetControlID="ImgDocExtCopiaNotas" PopupControlID="PnlDocExtCopiaNotas" __designer:wfdid="w117" Position="Right"></ajaxToolkit:PopupControlExtender> <asp:Image id="ImgDocExtCopiaNotas" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/post-it.gif" __designer:wfdid="w118"></asp:Image> <asp:Panel id="PnlDocExtCopiaNotas" runat="server" Width="400px" CssClass="popupControl" Height="150px" __designer:wfdid="w119">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox id="TxtDocExtCopiaNotas" runat="server" Width="382px" Height="100px" __designer:wfdid="w120" TextMode="MultiLine"></asp:TextBox> <asp:LinkButton id="LnkDocExtCopiaNotas" onclick="LnkDocExtCopiaNotas_Click" runat="server" Width="47px" __designer:wfdid="w121">Enviar</asp:LinkButton></asp:Panel> 
</contenttemplate>
                                                </asp:UpdatePanel>
                                                &nbsp;
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                <asp:TemplateField HeaderText="Detalle" SortExpression="RegistroDetalle">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("RegistroDetalle") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBox333" runat="server" BackColor="Transparent" BorderStyle="None"
                                            MaxLength="350" ReadOnly="True" Text='<%# Bind("RegistroDetalle") %>' Width="200px"></asp:TextBox>
                                    </ItemTemplate>
                                    <ControlStyle Width="350px" />
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Opciones" SortExpression="GrupoCodigo">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HprLnkImgExtVen" runat="server" NavigateUrl='<%# Eval("NumeroDocumento", "~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?RadicadoCodigo=1{0}          ") %>'
                                            Target="_blank" Text="Imagenes"></asp:HyperLink>
                                        <br />
                                        <asp:HyperLink ID="HprLnkHisExtven" runat="server" NavigateUrl="www.google.com" Width="55px">Historico</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                No tiene documentos recibidos externos vencidos !
                            </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </asp:Panel>
                    <asp:ObjectDataSource ID="ODSDocEnvExt" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFDocCopiaEnviada"
                            TypeName="DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoCopiaEnviadoTableAdapter">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="5" Name="WFMovimientoTipo" Type="Int32" />
                            <asp:Parameter DefaultValue="4" Name="WFMovimientoTipo2" Type="Int32" />
                            <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                    PropertyName="Value" Type="String" />
                            <asp:Parameter DefaultValue="2" Name="GrupoCodigo" Type="String" />
                            <asp:ControlParameter ControlID="HFmFecha" DefaultValue="" Name="WFMovimientoFecha"
                                    PropertyName="Value" Type="DateTime" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server"
        TargetControlID="Panel11"
        ExpandControlID="Panel12"
        CollapseControlID="Panel12" 
        Collapsed="True"
        TextLabelID="Label7"
        ImageControlID="ImageButton1"    
        ExpandedText="(Ocultar Documentos...)"
        CollapsedText="(Ver Documentos...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true"/>
                </asp:Panel>
                <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetWFDoc" TypeName="DSWorkFlowTableAdapters.WFMovimientoTableAdapter">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo" Type="Int32" />
                        <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                            PropertyName="Value" Type="String" />
                        <asp:Parameter DefaultValue="1" Name="GrupoCodigo" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
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
        SuppressPostBack="true" Collapsed="True"/>
                <br />
                <asp:Panel ID="Panel17" runat="server" CssClass="collapsePanelHeader" BackImageUrl="~/AlfaNetImagen/MainMaster/bg-menu-main.png" Width="736px" style="vertical-align: top; text-align: left">
                    <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                        <div style="float: left; width: 350px; font-weight: bold;">
                            <asp:Label ID="Label14" runat="server" Font-Bold="False" Font-Italic="False" Font-Size="Larger"
                                Height="20px" Width="41px">#</asp:Label>
                            DOCUMENTOS ENVIADOS INTERNOS</div>
                        <div style="float: left; margin-left: 20px;">
                            <asp:Label ID="Label15" runat="server" Font-Size="Smaller" Height="20px" Style="vertical-align: middle;
                                text-align: left" Width="180px">(Ver Detalles...)</asp:Label>
                        </div>
                        <asp:ImageButton ID="ImageButton5" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
                </asp:Panel>
                <asp:Panel ID="Panel18" runat="server" CssClass="collapsePanel" Height="0" Width="738px" style="vertical-align: top; text-align: left">
                    <asp:Panel ID="Panel19" runat="server" CssClass="collapsePanelHeader" Width="730px" BackColor="Lavender" BorderColor="Red" BorderStyle="Solid" BorderWidth="3px">
                        <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                            <div style="float: left">
                                <img src="../../AlfaNetImagen/ToolBar/alarmaroja.gif" />&nbsp;</div>
                            <div style="float: left; width: 400px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                                &nbsp;USTED TIENE &nbsp;<asp:Label ID="Label16" runat="server" Font-Bold="False"
                                    Font-Size="Larger" Height="20px" Style="font: caption; vertical-align: bottom;
                                    text-align: center" Width="25px">#</asp:Label>&nbsp; &nbsp;DOCUMENTOS RECIBIDOS</div>
                            <div style="float: left; margin-left: 20px;">
                                <asp:Label ID="Label17" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption"
                                    Height="20px" Width="180px">(Ver Documentos...)</asp:Label>
                            </div>
                            <asp:ImageButton ID="ImageButton6" runat="server" AlternateText="(Ver Detalles...)" ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
                    </asp:Panel>
                    <asp:Panel ID="Panel20" runat="server" CssClass="collapsePanel" Height="0" Width="736px" style="text-align: left">
                        <table style="width: 360px">
                            <tr>
                                <td style="width: 25px; text-align: center">
                                    <asp:Button ID="BtnTerminarDocEnvIntVen" runat="server" OnClick="BtnTerminarIntEnvVen_Click" Text="Terminar" /></td>
                                <td style="width: 190px">
                                    &nbsp;Seleccionar:&nbsp;
                                    <asp:LinkButton ID="LinkButton7" runat="server" OnClick="LnkBtnSelTodos_Click" Width="20px">Todos</asp:LinkButton>
                                    ,
                                    <asp:LinkButton ID="LinkButton8" runat="server" OnClick="LnkBtnSelNinguno_Click"
                                        Width="34px">Ninguno</asp:LinkButton></td>
                            </tr>
                        </table><asp:GridView ID="GridView4" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CellPadding="1" DataKeyNames="NumeroDocumento,DependenciaCodDestino,WFMovimientoPaso,WFMovimientoTipo,GrupoCodigo"
                                    DataSourceID="ODSDocEnvIntVen" ForeColor="#333333" GridLines="None" Width="730px" EmptyDataText="No tiene documentos recibidos externos vencidos" HorizontalAlign="Right" Font-Size="Smaller">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="SelectorDocumento" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nro Doc" SortExpression="NumeroDocumento">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("NumeroDocumento") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LnkBtnEnvIntVen" runat="server" OnClick="LnkBtnEnvIntVen_Click" Text='<%# Eval("NumeroDocumento") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="WFAccionNombre" HeaderText="Accion" SortExpression="WFAccionNombre">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DependenciaNombre" HeaderText="Remite" SortExpression="DependenciaNombre">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Cargado" SortExpression="DependenciaNombre">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Panel CssClass="popupMenu" ID="PopupMenu2" runat="server">
                                            <div style="border:1px outset white;padding:2px;">
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:Label>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="Pane200" runat="server">
                                            <img src="../../AlfaNetImagen/ToolBar/user.png" /></asp:Panel>
                                        <ajaxToolkit:HoverMenuExtender ID="hme2" runat="Server"
                                                HoverCssClass="popupHover"
                                                PopupControlID="PopupMenu2"
                                                TargetControlID="Pane200"
                                                PopDelay="35"/>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" Font-Size="Small" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Notas" SortExpression="WFMovimientoNotas">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Panel CssClass="popupMenu" ID="PopupMenu1" runat="server">
                                            <div style="border:1px outset white;padding:2px;">
                                                <div>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:Label></div>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="Panel00" runat="server">
                                            <img src="../../AlfaNetImagen/ToolBar/user_comment.png" />
                                        </asp:Panel>
                                        <ajaxToolkit:HoverMenuExtender ID="hme1" runat="Server"
                                                HoverCssClass="popupHover"
                                                PopupControlID="PopupMenu1"
                                                PopupPosition="Center"
                                                TargetControlID="Panel00"
                                                PopDelay="25"/>
                                    </ItemTemplate>
                                    <HeaderStyle Width="20px" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Font-Size="Small" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Post It">
                                            <ItemTemplate>
                                                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                                    <contenttemplate>
&nbsp;<ajaxToolkit:PopupControlExtender id="PCEDocEnvIntNotas" runat="server" TargetControlID="ImgDcoEnvIntNotas" PopupControlID="PnlDcoEnvIntNotas" __designer:wfdid="w127" Position="Right"></ajaxToolkit:PopupControlExtender> <asp:Image id="ImgDcoEnvIntNotas" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/post-it.gif" __designer:wfdid="w128"></asp:Image> <asp:Panel style="LEFT: 15px" id="PnlDcoEnvIntNotas" runat="server" Width="400px" CssClass="popupControl" Height="150px" __designer:wfdid="w129">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox id="TxtDcoEnvIntNotas" runat="server" Width="382px" Height="100px" __designer:wfdid="w130" TextMode="MultiLine"></asp:TextBox> <asp:LinkButton id="LnkDcoEnvIntNotas" runat="server" Width="47px" __designer:wfdid="w131" OnClick="LnkDcoEnvIntNotas_Click">Enviar</asp:LinkButton></asp:Panel>
</contenttemplate>
                                                </asp:UpdatePanel>
                                                &nbsp;
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                <asp:TemplateField HeaderText="Detalle" SortExpression="RegistroDetalle">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("RegistroDetalle") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBox333" runat="server" BackColor="Transparent" BorderStyle="None"
                                            MaxLength="350" ReadOnly="True" Text='<%# Bind("RegistroDetalle") %>' Width="200px"></asp:TextBox>
                                    </ItemTemplate>
                                    <ControlStyle Width="350px" />
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Opciones" SortExpression="GrupoCodigo">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HprLnkImgExtVen" runat="server" NavigateUrl='<%# Eval("NumeroDocumento", "~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?RadicadoCodigo=1{0}          ") %>'
                                            Target="_blank" Text="Imagenes"></asp:HyperLink>
                                        <br />
                                        <asp:HyperLink ID="HprLnkHisExtven" runat="server" NavigateUrl="www.google.com" Width="55px">Historico</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                No tiene documentos recibidos externos vencidos !
                            </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </asp:Panel>
                    <asp:ObjectDataSource ID="ODSDocEnvIntVen" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFDocEnviado"
                            TypeName="DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoCopiaEnviadoTableAdapter">
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
                    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender5" runat="server"
        TargetControlID="Panel20"
        ExpandControlID="Panel19"
        CollapseControlID="Panel19" 
        Collapsed="True"
        TextLabelID="Label17"
        ImageControlID="ImageButton6"    
        ExpandedText="(Ocultar Documentos...)"
        CollapsedText="(Ver Documentos...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true"/>
                    <asp:Panel ID="Panel21" runat="server" CssClass="collapsePanelHeader" Width="730px" BorderColor="Yellow" BorderStyle="Solid" BorderWidth="3px" BackColor="Lavender" Visible="False">
                        <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                            <div style="float: left">
                                <img src="../../AlfaNetImagen/ToolBar/alarmaamarilla.gif" />&nbsp;</div>
                            <div style="float: left; width: 400px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                                &nbsp;USTED TIENE &nbsp;<asp:Label ID="Label18" runat="server" Font-Bold="False"
                                    Font-Size="Larger" Height="20px" Style="font: caption; vertical-align: bottom;
                                    text-align: center" Width="25px">#</asp:Label>&nbsp; DOCUMENTOS PROXIMOS A VENCER</div>
                            <div style="float: left; margin-left: 20px;">
                                <asp:Label ID="Label19" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption"
                                    Height="20px" Width="180px">(Ver Documentos...)</asp:Label>
                            </div>
                            <asp:ImageButton ID="ImageButton7" runat="server" AlternateText="(Ver Detalles...)"
                    ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
                    </asp:Panel>
                    <asp:Panel ID="Panel22" runat="server" CssClass="collapsePanel" Height="0px" Width="736px" Visible="False">
                        <p>
                            <table style="width: 560px">
                                <tr>
                                    <td style="width: 26px; text-align: center;">
                                        <asp:Button ID="Button6" runat="server" OnClick="BtnTerminar_Click" Text="Terminar" /></td>
                                    <td style="width: 409px;">
                                        &nbsp;Seleccionar:&nbsp;
                                        <asp:LinkButton ID="LinkButton9" runat="server" OnClick="LnkBtnSelTodos_Click" Width="101px">Todos</asp:LinkButton>
                                        ,
                                        <asp:LinkButton ID="LinkButton10" runat="server" OnClick="LnkBtnSelNinguno_Click"
                                            Width="34px">Ninguno</asp:LinkButton></td>
                                </tr>
                            </table>
                            <asp:GridView ID="GridView5" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="NumeroDocumento,DependenciaCodDestino,WFMovimientoPaso,WFMovimientoTipo,GrupoCodigo"
                                    DataSourceID="ODSDocRecExtProxVen" ForeColor="#333333" GridLines="None" Width="736px" EmptyDataText="No tiene documentos recibidos externos vencidos" HorizontalAlign="Right">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                                <Columns>
                                    <asp:TemplateField>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="SelectorDocumento" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Documento" SortExpression="NumeroDocumento">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("NumeroDocumento") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("NumeroDocumento") %>'></asp:HyperLink>
                                        </ItemTemplate>
                                        <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="WFAccionNombre" HeaderText="Accion" SortExpression="WFAccionNombre">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ProcedenciaNombre" HeaderText="Procedencia" SortExpression="ProcedenciaNombre">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="Small" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Cargado Por" SortExpression="DependenciaNombre">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Panel CssClass="popupMenu" ID="PopupMenu2" runat="server">
                                                <div style="border:1px outset white;padding:2px;">
                                                    <div>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:Label></div>
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="Pane200" runat="server">
                                                <img src="../../AlfaNetImagen/ToolBar/user.png" />
                                            </asp:Panel>
                                            <ajaxToolkit:HoverMenuExtender ID="hme2" runat="Server"
                                                HoverCssClass="popupHover"
                                                PopupControlID="PopupMenu2"
                                                TargetControlID="Pane200"
                                                PopDelay="25"/>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="Small" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Notas" SortExpression="WFMovimientoNotas">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Panel CssClass="popupMenu" ID="PopupMenu1" runat="server">
                                                <div style="border:1px outset white;padding:2px;">
                                                    <div>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:Label></div>
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel00" runat="server">
                                                <img src="../../AlfaNetImagen/ToolBar/user_comment.png" />
                                            </asp:Panel>
                                            <ajaxToolkit:HoverMenuExtender ID="hme1" runat="Server"
                                                HoverCssClass="popupHover"
                                                PopupControlID="PopupMenu1"
                                                PopupPosition="Center"
                                                TargetControlID="Panel00"
                                                PopDelay="25"/>
                                        </ItemTemplate>
                                        <HeaderStyle Width="20px" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="Small" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Detalle" SortExpression="RadicadoDetalle">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("RadicadoDetalle") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Panel CssClass="popupMenu" ID="PopupMenu3" runat="server">
                                                <div style="border:1px outset white;padding:2px;">
                                                    <div>
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("RadicadoDetalle") %>'></asp:Label></div>
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="Pane300" runat="server">
                                                <img src="../../AlfaNetImagen/ToolBar/text_detalle.png" />
                                            </asp:Panel>
                                            <ajaxToolkit:HoverMenuExtender ID="hme3" runat="Server"
                                                HoverCssClass="popupHover"
                                                PopupControlID="PopupMenu3"
                                                PopupPosition="Center"
                                                TargetControlID="Pane300"
                                                PopDelay="25"/>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="Small" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <EmptyDataTemplate>
                                    No tiene documentos recibidos externos vencidos !
                                </EmptyDataTemplate>
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </p>
                        <p>
                            &nbsp;</p>
                    </asp:Panel>
                    <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFDocProxVen"
                            TypeName="DSWorkFlowTableAdapters.WFMovimientoTableAdapter">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo" Type="Int32" />
                            <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                        PropertyName="Value" Type="String" />
                            <asp:Parameter DefaultValue="1" Name="GrupoCodigo" Type="String" />
                            <asp:ControlParameter ControlID="HFmFecha" DefaultValue="" Name="WFMovimientoFecha"
                                        PropertyName="Value" Type="DateTime" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender6" runat="server"
        TargetControlID="Panel22"
        ExpandControlID="Panel21"
        CollapseControlID="Panel21" 
        Collapsed="True"
        TextLabelID="Label19"
        ImageControlID="ImageButton7"    
        ExpandedText="(Ocultar Documentos...)"
        CollapsedText="(Ver Documentos...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true"/>
                    <asp:Panel ID="Panel23" runat="server" CssClass="collapsePanelHeader" Width="730px" BorderColor="Green" BorderStyle="Solid" BorderWidth="3px" BackColor="Lavender" Visible="False">
                        <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                            <div style="float: left">
                                <img src="../../AlfaNetImagen/ToolBar/alarmaverde.gif" />&nbsp;</div>
                            <div style="float: left; width: 400px; vertical-align: middle; color: activecaption; text-align: left; font: caption;">
                                &nbsp;USTED TIENE &nbsp;<asp:Label ID="Label20" runat="server" Font-Bold="False"
                                    Font-Size="Larger" Height="20px" Style="font: caption; vertical-align: bottom;
                                    text-align: center" Width="25px">#</asp:Label>&nbsp; DOCUMENTOS PENDIENTES</div>
                            <div style="float: left; margin-left: 20px;">
                                <asp:Label ID="Label21" runat="server" Font-Size="Smaller" ForeColor="ActiveCaption"
                                    Height="20px" Width="180px">(Ver Documentos...)</asp:Label>
                            </div>
                            <asp:ImageButton ID="ImageButton8" runat="server" AlternateText="(Ver Detalles...)"
                    ImageUrl="~/AlfaNetImagen/MainMaster/expand_blue.jpg" /></div>
                    </asp:Panel>
                    <asp:Panel ID="Panel24" runat="server" CssClass="collapsePanel" Height="0" Width="736px" Visible="False">
                        <p>
                            <table style="width: 560px">
                                <tr>
                                    <td style="width: 26px; text-align: center;">
                                        <asp:Button ID="Button7" runat="server" OnClick="BtnTerminar_Click" Text="Terminar" /></td>
                                    <td style="width: 409px;">
                                        &nbsp;Seleccionar:&nbsp;
                                        <asp:LinkButton ID="LinkButton11" runat="server" OnClick="LnkBtnSelTodos_Click" Width="54px">Todos</asp:LinkButton>
                                        ,
                                        <asp:LinkButton ID="LinkButton12" runat="server" OnClick="LnkBtnSelNinguno_Click"
                                            Width="61px">Ninguno</asp:LinkButton></td>
                                </tr>
                            </table>
                            <asp:GridView ID="GridView6" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="NumeroDocumento,DependenciaCodDestino,WFMovimientoPaso,WFMovimientoTipo,GrupoCodigo"
                                    DataSourceID="ODSDocRecExtPen" ForeColor="#333333" GridLines="None" Width="736px" EmptyDataText="No tiene documentos recibidos externos vencidos" HorizontalAlign="Right">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                                <Columns>
                                    <asp:TemplateField>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="SelectorDocumento" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Documento" SortExpression="NumeroDocumento">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("NumeroDocumento") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("NumeroDocumento") %>'></asp:HyperLink>
                                        </ItemTemplate>
                                        <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="WFAccionNombre" HeaderText="Accion" SortExpression="WFAccionNombre">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ProcedenciaNombre" HeaderText="Procedencia" SortExpression="ProcedenciaNombre">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="Small" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Cargado Por" SortExpression="DependenciaNombre">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Panel CssClass="popupMenu" ID="PopupMenu2" runat="server">
                                                <div style="border:1px outset white;padding:2px;">
                                                    <div>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:Label></div>
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="Pane200" runat="server">
                                                <img src="../../AlfaNetImagen/ToolBar/user.png" />
                                            </asp:Panel>
                                            <ajaxToolkit:HoverMenuExtender ID="hme2" runat="Server"
                                                HoverCssClass="popupHover"
                                                PopupControlID="PopupMenu2"
                                                TargetControlID="Pane200"
                                                PopDelay="25"/>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="Small" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Notas" SortExpression="WFMovimientoNotas">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Panel CssClass="popupMenu" ID="PopupMenu1" runat="server">
                                                <div style="border:1px outset white;padding:2px;">
                                                    <div>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:Label></div>
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel00" runat="server">
                                                <img src="../../AlfaNetImagen/ToolBar/user_comment.png" />
                                            </asp:Panel>
                                            <ajaxToolkit:HoverMenuExtender ID="hme1" runat="Server"
                                                HoverCssClass="popupHover"
                                                PopupControlID="PopupMenu1"
                                                PopupPosition="Center"
                                                TargetControlID="Panel00"
                                                PopDelay="25"/>
                                        </ItemTemplate>
                                        <HeaderStyle Width="20px" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="Small" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Detalle" SortExpression="RadicadoDetalle">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("RadicadoDetalle") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Panel CssClass="popupMenu" ID="PopupMenu3" runat="server">
                                                <div style="border:1px outset white;padding:2px;">
                                                    <div>
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("RadicadoDetalle") %>'></asp:Label></div>
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="Pane300" runat="server">
                                                <img src="../../AlfaNetImagen/ToolBar/text_detalle.png" />
                                            </asp:Panel>
                                            <ajaxToolkit:HoverMenuExtender ID="hme3" runat="Server"
                                                HoverCssClass="popupHover"
                                                PopupControlID="PopupMenu3"
                                                PopupPosition="Center"
                                                TargetControlID="Pane300"
                                                PopDelay="25"/>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="Small" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <EmptyDataTemplate>
                                    No tiene documentos recibidos externos vencidos !
                                </EmptyDataTemplate>
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </p>
                    </asp:Panel>
                    <asp:ObjectDataSource ID="ObjectDataSource7" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFDocPen"
                            TypeName="DSWorkFlowTableAdapters.WFMovimientoTableAdapter">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo" Type="Int32" />
                            <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                        PropertyName="Value" Type="String" />
                            <asp:Parameter DefaultValue="1" Name="GrupoCodigo" Type="String" />
                            <asp:ControlParameter ControlID="HFmFecha" DefaultValue="" Name="WFMovimientoFecha"
                                        PropertyName="Value" Type="DateTime" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender7" runat="server"
        TargetControlID="Panel24"
        ExpandControlID="Panel23"
        CollapseControlID="Panel23" 
        Collapsed="True"
        TextLabelID="Label21"
        ImageControlID="ImageButton8"    
        ExpandedText="(Ocultar Documentos...)"
        CollapsedText="(Ver Documentos...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true"/><asp:Panel ID="Panel10" runat="server" CssClass="collapsePanelHeader" Width="730px" BorderColor="SlateBlue" BorderStyle="Solid" BorderWidth="3px" BackColor="Lavender">
            <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                <div style="float: left">
                    <img src="../../AlfaNetImagen/ToolBar/wfcopias.gif" height="14" width="14" />&nbsp;</div>
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
        </asp:Panel>
                    <asp:Panel ID="Panel13" runat="server" CssClass="collapsePanel" Height="0" Width="736px">
                        <p>
                            <table style="width: 560px">
                                <tr>
                                    <td style="width: 26px; text-align: center;">
                                        <asp:Button ID="BtnTerminarDocEnvIntCop" runat="server" OnClick="BtnTerminarEnvIntCop_Click" Text="Terminar" /></td>
                                    <td style="width: 409px;">
                                        &nbsp;Seleccionar:&nbsp;
                                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LnkBtnSelTodos_Click" Width="54px">Todos</asp:LinkButton>
                                        ,
                                        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LnkBtnSelNinguno_Click"
                                            Width="61px">Ninguno</asp:LinkButton></td>
                                </tr>
                            </table><asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CellPadding="1" DataKeyNames="NumeroDocumento,DependenciaCodDestino,WFMovimientoPaso,WFMovimientoTipo,GrupoCodigo"
                                    DataSourceID="ODSDocEnvInt" ForeColor="#333333" GridLines="None" Width="730px" EmptyDataText="No tiene documentos recibidos externos vencidos" HorizontalAlign="Right" Font-Size="Smaller">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="SelectorDocumento" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nro Doc" SortExpression="NumeroDocumento">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("NumeroDocumento") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LnkBtnEnvIntVen" runat="server" OnClick="LnkBtnEnvIntCop_Click"
                                                Text='<%# Eval("NumeroDocumento") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="WFAccionNombre" HeaderText="Accion" SortExpression="WFAccionNombre">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DependenciaNombre" HeaderText="Remite" SortExpression="DependenciaNombre">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Cargado" SortExpression="DependenciaNombre">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Panel CssClass="popupMenu" ID="PopupMenu2" runat="server">
                                                <div style="border:1px outset white;padding:2px;">
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("DependenciaNombre") %>'></asp:Label>
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="Pane200" runat="server">
                                                <img src="../../AlfaNetImagen/ToolBar/user.png" /></asp:Panel>
                                            <ajaxToolkit:HoverMenuExtender ID="hme2" runat="Server"
                                                HoverCssClass="popupHover"
                                                PopupControlID="PopupMenu2"
                                                TargetControlID="Pane200"
                                                PopDelay="35"/>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="Small" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Notas" SortExpression="WFMovimientoNotas">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Panel CssClass="popupMenu" ID="PopupMenu1" runat="server">
                                                <div style="border:1px outset white;padding:2px;">
                                                    <div>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("WFMovimientoNotas") %>'></asp:Label></div>
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel00" runat="server">
                                                <img src="../../AlfaNetImagen/ToolBar/user_comment.png" />
                                            </asp:Panel>
                                            <ajaxToolkit:HoverMenuExtender ID="hme1" runat="Server"
                                                HoverCssClass="popupHover"
                                                PopupControlID="PopupMenu1"
                                                PopupPosition="Center"
                                                TargetControlID="Panel00"
                                                PopDelay="25"/>
                                        </ItemTemplate>
                                        <HeaderStyle Width="20px" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="Small" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Post It">
                                            <ItemTemplate>
                                                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                                    <contenttemplate>
&nbsp;<ajaxToolkit:PopupControlExtender id="PCEDocEnvCopiaNotas" runat="server" TargetControlID="ImgDocEnvCopiaNotas" PopupControlID="PnlDocEnvCopiaNotas" __designer:wfdid="w137" Position="Right"></ajaxToolkit:PopupControlExtender> <asp:Image id="ImgDocEnvCopiaNotas" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/post-it.gif" __designer:wfdid="w138"></asp:Image> <asp:Panel id="PnlDocEnvCopiaNotas" runat="server" Width="400px" CssClass="popupControl" Height="150px" __designer:wfdid="w139">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox id="TxtDocEnvCopiaNotas" runat="server" Width="382px" Height="100px" __designer:wfdid="w140" TextMode="MultiLine"></asp:TextBox> <asp:LinkButton id="LnkDocEnvCopiaNotas" runat="server" Width="47px" __designer:wfdid="w141" OnClick="LnkDocEnvCopiaNotas_Click">Enviar</asp:LinkButton></asp:Panel>
</contenttemplate>
                                                </asp:UpdatePanel>
                                                &nbsp;
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Detalle" SortExpression="RegistroDetalle">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("RegistroDetalle") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox333" runat="server" BackColor="Transparent" BorderStyle="None"
                                                MaxLength="350" ReadOnly="True" Text='<%# Bind("RegistroDetalle") %>' Width="200px"></asp:TextBox>
                                        </ItemTemplate>
                                        <ControlStyle Width="350px" />
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Opciones" SortExpression="GrupoCodigo">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HprLnkImgExtVen" runat="server" NavigateUrl='<%# Eval("NumeroDocumento", "~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?RadicadoCodigo=1{0}          ") %>'
                                                Target="_blank" Text="Imagenes"></asp:HyperLink>
                                            <br />
                                            <asp:HyperLink ID="HprLnkHisExtven" runat="server" NavigateUrl="www.google.com" Width="55px">Historico</asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <EmptyDataTemplate>
                                    No tiene documentos recibidos externos vencidos !
                                </EmptyDataTemplate>
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                            &nbsp;&nbsp;
                        </p>
                    </asp:Panel>
                    <asp:ObjectDataSource ID="ODSDocEnvInt" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWFDocCopiaEnviada"
                            TypeName="DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoCopiaEnviadoTableAdapter">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="6" Name="WFMovimientoTipo" Type="Int32" />
                            <asp:Parameter DefaultValue="4" Name="WFMovimientoTipo2" Type="Int32" />
                            <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                                    PropertyName="Value" Type="String" />
                            <asp:Parameter DefaultValue="2" Name="GrupoCodigo" Type="String" />
                            <asp:ControlParameter ControlID="HFmFecha" DefaultValue="" Name="WFMovimientoFecha"
                                    PropertyName="Value" Type="DateTime" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server"
        TargetControlID="Panel13"
        ExpandControlID="Panel10"
        CollapseControlID="Panel10" 
        Collapsed="True"
        TextLabelID="Label7"
        ImageControlID="ImageButton1"    
        ExpandedText="(Ocultar Documentos...)"
        CollapsedText="(Ver Documentos...)"
        ExpandedImage="~/AlfaNetImagen/MainMaster/collapse_blue.jpg"
        CollapsedImage="~/AlfaNetImagen/MainMaster/expand_blue.jpg"
        SuppressPostBack="true"/>
                </asp:Panel>
                <asp:ObjectDataSource ID="ObjectDataSource8" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetWFDoc" TypeName="DSWorkFlowTableAdapters.WFMovimientoTableAdapter">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="WFMovimientoTipo" Type="Int32" />
                        <asp:ControlParameter ControlID="HFmDepCod" DefaultValue="" Name="DependenciaCodDestino"
                            PropertyName="Value" Type="String" />
                        <asp:Parameter DefaultValue="1" Name="GrupoCodigo" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
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
        SuppressPostBack="true" Collapsed="True"/>
                <asp:UpdatePanel ID="UP1" runat="server">
                    <ContentTemplate>
<BR /><asp:Panel style="DISPLAY: none" id="PnlMensaje" runat="server" Width="125px" Height="63px"><TABLE width=275 border=0><TBODY><TR><TD style="HEIGHT: 32px; BACKGROUND-COLOR: activecaption" align=center><asp:Label id="LblMensaje" runat="server" Width="120px" Font-Size="14pt" ForeColor="White" Font-Bold="False" Text="Mensaje"></asp:Label></TD><TD style="WIDTH: 12%; HEIGHT: 32px; BACKGROUND-COLOR: activecaption"><asp:ImageButton style="VERTICAL-ALIGN: top" id="btnCerrar" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png" ImageAlign="Right"></asp:ImageButton> </TD></TR><TR><TD style="HEIGHT: 45px; BACKGROUND-COLOR: highlighttext" align=center colSpan=2><BR /><IMG src="../../AlfaNetImagen/ToolBar/error.png" />&nbsp; &nbsp;<asp:Label id="LblMessageBox" runat="server" Font-Size="12pt" ForeColor="Red"></asp:Label><BR /><BR /><asp:Button id="Button1" runat="server" BackColor="ActiveCaption" Font-Size="X-Small" ForeColor="White" Font-Bold="True" Text="Aceptar" Font-Italic="False"></asp:Button><BR /></TD></TR></TBODY></TABLE></asp:Panel> <ajaxToolkit:ModalPopupExtender id="MPEMensaje" runat="server" TargetControlID="PnlMensaje" OkControlID="Button1" CancelControlID="btnCerrar" PopupControlID="PnlMensaje"></ajaxToolkit:ModalPopupExtender>
</ContentTemplate>
                </asp:UpdatePanel>
           <table border="0">
               <tr>
                   <td style="width: 100px">
                <asp:HiddenField ID="HFmFecha" runat="server" />
                   </td>
                   <td style="width: 100px">
                <asp:HiddenField ID="HFmDepCod" runat="server" />
                   </td>
                   <td style="width: 100px">
                <asp:HiddenField ID="HFmTipo" runat="server" />
                   </td>
                   <td style="width: 100px">
                <asp:HiddenField ID="HFmGrupo" runat="server" />
                   </td>
               </tr>
           </table>
                </td>
        </tr>
    </table>
</asp:Content>



