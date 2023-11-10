<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MainMaster.master"
    CodeFile="alfanetMantenimiento.aspx.cs" Inherits="alfanetMantenimiento" %>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div align="center">
        <asp:Image ID="IMantenimiento"  runat="server" 
            ImageUrl="~/images/mantenimiento.jpg" />
    </div>
    <div align="center">
        <asp:Label ID="Label1" runat="server" Text="Opción en Mantenimiento"></asp:Label>
    </div>
    <div align="center">
        <asp:Label ID="Label2" runat="server" 
            Text="Enviar los siguientes datos de la procedencia al correo: tickets.archivar@gmail.com con Asunto: Procedencia a Crear (Nombre)." 
            Font-Bold="True" Font-Size="Large"></asp:Label>
    </div>
    <br />
    <div align="center">
        <asp:Label ID="Label3" runat="server" Text="Nui (Número de Procedencía)." 
            ></asp:Label>
    </div>
    <div align="center">
        <asp:Label ID="Label4" runat="server" Text="Nombre."></asp:Label>
    </div>
    <div align="center">
        <asp:Label ID="Label5" runat="server" Text="Dirección."></asp:Label>
    </div>
    <div align="center">
        <asp:Label ID="Label6" runat="server" Text="Teléfono."></asp:Label>
    </div>
    <div align="center">
        <asp:Label ID="Label7" runat="server" Text="Email."></asp:Label>
    </div>
    <div align="center">
        <asp:Label ID="Label8" runat="server" Text="Ciudad."></asp:Label>
    </div>
    <div align="center">
        <asp:Label ID="Label9" runat="server" Text="Página Web."></asp:Label>
    </div>
</asp:Content>