<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StickerImpresion.aspx.cs" Inherits="AlfaNetDocumentos_DocRecibido_StickerImpresion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sticker Impresion</title>
     <script language="javascript" type="text/javascript">
    function exit()
        {

        window.close()

        }
    </script>
    <script src="jscripts/cufon-yui.js"type="text/javascript"></script>
    <script src="jscripts/3_of_9_Barcode_400.font.js" type="text/javascript"></script>
	<script type="text/javascript">
			//Cufon.replace('h1'); // Works without a selector engine
			Cufon.replace('#LblCodigoBarras'); // Requires a selector engine for IE 6-7, see above
	 </script>

</head>
<body>    
    <form id="form1" runat="server">
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </cc1:ToolkitScriptManager>
         <cc1:DragPanelExtender ID="DragPanelExtender1" runat="server" TargetControlID="PnlSticker" DragHandleID="Panel2">
                    </cc1:DragPanelExtender>
        <asp:HiddenField ID="HFSticker" runat="server" />
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/cross.png"
            OnClientClick="return exit();" Visible="False" /><asp:LinkButton ID="LinkButton2" runat="server"
                OnClientClick="return exit();" Visible="False">Cerrar</asp:LinkButton>
        <asp:Panel ID="Panel2" runat="server" Height="600px" Width="800px" 
        HorizontalAlign="Left" style="margin-top: 0px">
                        <asp:Panel ID="PnlSticker" runat="server" HorizontalAlign="Center" Style="text-align: left "
                            Width="400px" BorderWidth="0px" Direction="LeftToRight">
                            <table style="width: 100%; height: 100%; line-height: normal;">
                                <tr>
                                    <td colspan="3">
                            <asp:Label ID="LblCliente" runat="server" Text="MINISTERIO DE LAS TECNOLOGIAS DE LA INFORMACION Y LAS COMUNICACIONES"
                                Font-Size="7pt" Font-Bold="False"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="1" style="width: 190px; text-align: left;">
                            <asp:Label ID="Label1" runat="server" Font-Size="X-Small" Text="Fecha:  "></asp:Label><asp:Label ID="LblStickerFecRad" runat="server" Font-Size="X-Small" Font-Bold="False"></asp:Label></td>
                                    
                                    <td colspan="1" style="text-align: left; width: 170px;">
                                        <asp:Label ID="Label6" runat="server" Font-Size="X-Small" Text="Hora:  "></asp:Label><asp:Label ID="Label17" runat="server" Font-Size="X-Small" Text="Hora:  "></asp:Label></td>
                                    
                                    <td colspan="1" style="text-align: left; width: 200px;">
                                    
                                    <asp:Label ID="Label3" runat="server"
                                    Font-Size="X-Small"> FOLIOS: </asp:Label><asp:Label ID="Label19" runat="server" Font-Size="X-Small"> FOLIOS: </asp:Label></td>
                                    <%--<td colspan="1" style="text-align: left; width: 35%;">
                                    </td>--%>
                                    
                                </tr>
                                <tr>
                                    <td colspan="3" style="vertical-align: text-top">
                            <asp:Label ID="Label8" runat="server" Font-Bold="False" Font-Size="X-Small" 
                                Text="Radicado No:"></asp:Label><asp:Label ID="LblStickerNroRad" runat="server" Font-Bold="True"
                                Font-Size="Small"></asp:Label><asp:Label ID="Label13" runat="server" Font-Size="XX-Small" Text=" RADICADOR:  " Visible="False"></asp:Label><asp:Label ID="LblStickerUsr" runat="server" Font-Size="XX-Small" Font-Bold="False" Visible="False"></asp:Label><br />
                            <asp:Label ID="LabelProcedencia" runat="server" Font-Bold="False" Font-Size="X-Small" 
                                Text="Procedencia:" Width="76px"></asp:Label><asp:Label ID="Label18" runat="server"
                                    Font-Bold="False" Font-Size="X-Small" Text="Procedencia:"></asp:Label></td>
                                </tr>
                               
                               
                                <tr>
                                     <td colspan="3" style="width: 375px">
                            <asp:Label ID="Label11" runat="server" Font-Size="X-Small" Text="TRAMITE A:.     " Width="74px"></asp:Label><asp:Label ID="LblStickercargarA" runat="server" Font-Bold="False" Font-Size="XX-Small"></asp:Label></td>
                                </tr>
                                <tr>
                                  <%-- <td colspan="3" rowspan="1" style="width: 375px">
                            <asp:Label ID="Label2" runat="server" Font-Size="X-Small" Text="DIRECCION: "></asp:Label><asp:Label ID="LblDireccion" runat="server" Font-Size="X-Small" 
                                Font-Bold="False"></asp:Label></td>--%>
                                </tr>
                                <tr>
                                 <td style="width: 375px" colspan="3">
                                     <asp:Label ID="Label4" runat="server" Font-Size="X-Small" Text="CIUDAD: " 
                                         Visible="False"></asp:Label>
                                     <asp:Label ID="Label5" runat="server" Font-Size="X-Small"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" rowspan="1">
                            <asp:Label ID="LblCodigoBarras" runat="server"
                                Font-Size="30pt" Font-Names="3 of 9 Barcode">Archivar Ltda</asp:Label></td>
                                </tr>
                            </table>
                        </asp:Panel>
        </asp:Panel>
    </form>
</body>
</html>
