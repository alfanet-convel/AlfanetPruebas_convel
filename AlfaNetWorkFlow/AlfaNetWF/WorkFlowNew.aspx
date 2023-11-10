<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" EnableEventValidation="false" ValidateRequest="false" CodeFile="WorkFlowNew.aspx.cs" Inherits="_WorkFlowNew" %>

<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxDataView" TagPrefix="dxdv" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
 <script type="text/javascript">
    // <![CDATA[
        var postponedCallbackValue = null;
        function OnListBoxIndexChanged(s, e) {
            var item = ListBox.GetSelectedItem();
            if(CallbackPanel.InCallback())
                postponedCallbackValue = item.value;
            else
                CallbackPanel.PerformCallback(item.value);
        }
        function OnEndCallback(s, e) {
            if(postponedCallbackValue != null) {
                CallbackPanel.PerformCallback(postponedCallbackValue);
                postponedCallbackValue = null;
            }
        } 
    // ]]> 
    </script>
    <div style="float: left; width: 28%">
        
        
               
       
        <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" HeaderText="Employee" Width="100%" BackColor="White" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
            <PanelCollection>
                <dxrp:PanelContent runat="server">
                    <dxe:ASPxListBox runat="server" Height="221px" Width="73%" TextField="DependenciaNombre" DataSourceID="ObjectDataSource1"
                        ValueField="DependenciaCodigo" ID="ASPxListBox1" ClientInstanceName="ListBox" BackColor="Transparent">
                        <Border BorderWidth="0px"></Border>
                        <ItemStyle>
                            <Border BorderWidth="0px"></Border>
                        </ItemStyle>
                        <ClientSideEvents SelectedIndexChanged="OnListBoxIndexChanged" />
                    </dxe:ASPxListBox>
                </dxrp:PanelContent>
            </PanelCollection>
            <TopEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpTopEdge.gif"
                    Repeat="RepeatX" VerticalPosition="Top" />
            </TopEdge>
            <BottomRightCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpBottomRight.png"
                Width="7px" />
            <ContentPaddings Padding="10px" />
            <NoHeaderTopRightCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpNoHeaderTopRight.png"
                Width="7px" />
            <HeaderRightEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpHeaderBackground.gif"
                    Repeat="RepeatX" VerticalPosition="Top" />
            </HeaderRightEdge>
            <Border BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
            <HeaderLeftEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpHeaderBackground.gif"
                    Repeat="RepeatX" VerticalPosition="Top" />
            </HeaderLeftEdge>
            <HeaderStyle BackColor="#E0EDFF">
                <BorderBottom BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
            </HeaderStyle>
            <TopRightCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpTopRight.png"
                Width="7px" />
            <HeaderContent>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpHeaderBackground.gif"
                    Repeat="RepeatX" VerticalPosition="Top" />
            </HeaderContent>
            <NoHeaderTopEdge BackColor="White">
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpNoHeaderTopEdge.gif" Repeat="RepeatX"
                    VerticalPosition="Top" />
            </NoHeaderTopEdge>
            <NoHeaderTopLeftCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpNoHeaderTopLeft.png"
                Width="7px" />
            <TopLeftCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpTopLeft.png"
                Width="7px" />
            <BottomLeftCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpBottomLeft.png"
                Width="7px" />
            <LeftEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpLeftEdge.gif" Repeat="RepeatY"
                    VerticalPosition="Top" />
            </LeftEdge>
            <RightEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpRightEdge.gif" Repeat="RepeatY"
                    VerticalPosition="Top" />
            </RightEdge>
            <BottomEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpBottomEdge.gif" Repeat="RepeatX"
                    VerticalPosition="Bottom" />
            </BottomEdge>
        </dxrp:ASPxRoundPanel>
    </div>
    <div style="float: right; width: 70%">
        <dxrp:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" HeaderText="Personal information"
            Width="100%" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" BackColor="White">
            <PanelCollection>
                <dxrp:PanelContent runat="server">
                    <dxcp:ASPxCallbackPanel runat="server" ID="ASPxCallbackPanel1" Height="330px" ClientInstanceName="CallbackPanel">
                        <ClientSideEvents EndCallback="OnEndCallback"></ClientSideEvents>
                        <PanelCollection>
<dxrp:PanelContent runat="server"><dxdv:ASPxDataView runat="server" ColumnCount="1" RowPerPage="1" DataSourceID="ObjectDataSource1" EnableDefaultAppearance="False" Width="100%" EnableTheming="False" ID="ASPxDataView1">
<Paddings Padding="0px"></Paddings>

<PagerSettings Visible="False"></PagerSettings>

<ItemStyle Width="100%"></ItemStyle>
</dxdv:ASPxDataView>

 </dxrp:PanelContent>
</PanelCollection>
                    </dxcp:ASPxCallbackPanel>
                </dxrp:PanelContent>
            </PanelCollection>
            <BottomRightCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpBottomRight.png"
                Width="7px" />
            <Border BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
            <TopRightCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpTopRight.png"
                Width="7px" />
            <TopLeftCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpTopLeft.png"
                Width="7px" />
            <BottomLeftCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpBottomLeft.png"
                Width="7px" />
            <BottomEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpBottomEdge.gif" Repeat="RepeatX" VerticalPosition="Bottom" />
            </BottomEdge>
            <TopEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpTopEdge.gif" Repeat="RepeatX"
                    VerticalPosition="Top" />
            </TopEdge>
            <LeftEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpLeftEdge.gif" Repeat="RepeatY"
                    VerticalPosition="Top" />
            </LeftEdge>
            <ContentPaddings Padding="14px" />
            <NoHeaderTopRightCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpNoHeaderTopRight.png"
                Width="7px" />
            <RightEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpRightEdge.gif" Repeat="RepeatY"
                    VerticalPosition="Top" />
            </RightEdge>
            <HeaderRightEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpHeaderBackground.gif" Repeat="RepeatX"
                    VerticalPosition="Top" />
            </HeaderRightEdge>
            <HeaderLeftEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpHeaderBackground.gif" Repeat="RepeatX"
                    VerticalPosition="Top" />
            </HeaderLeftEdge>
            <HeaderStyle BackColor="#E0EDFF">
                <BorderBottom BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
            </HeaderStyle>
            <HeaderContent>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpHeaderBackground.gif" Repeat="RepeatX"
                    VerticalPosition="Top" />
            </HeaderContent>
            <NoHeaderTopEdge BackColor="White">
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpNoHeaderTopEdge.gif" Repeat="RepeatX"
                    VerticalPosition="Top" />
            </NoHeaderTopEdge>
            <NoHeaderTopLeftCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpNoHeaderTopLeft.png"
                Width="7px" />
        </dxrp:ASPxRoundPanel>
    </div>
    
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeleteDependencia"
        InsertMethod="AddDependencia" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDependencia"
        TypeName="DependenciaBLL" UpdateMethod="UpdateDependencia">
        <DeleteParameters>
            <asp:Parameter Name="Original_DependenciaCodigo" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="DependenciaNombre" Type="String" />
            <asp:Parameter Name="DependenciaCodigoPadre" Type="String" />
            <asp:Parameter Name="DependenciaHabilitar" Type="String" />
            <asp:Parameter Name="DependenciaPermiso" Type="String" />
            <asp:Parameter Name="Original_DependenciaCodigo" Type="String" />
            <asp:Parameter Name="DistriTareas" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="DependenciaCodigo" Type="String" />
            <asp:Parameter Name="DependenciaNombre" Type="String" />
            <asp:Parameter Name="DependenciaCodigoPadre" Type="String" />
            <asp:Parameter Name="DependenciaHabilitar" Type="String" />
            <asp:Parameter Name="DependenciaPermiso" Type="String" />
            <asp:Parameter Name="DistriTareas" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>


</asp:Content>



    