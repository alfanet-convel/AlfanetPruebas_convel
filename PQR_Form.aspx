<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="PQR_Form.aspx.cs" Inherits="PQR_Form" Culture="es-CO" UICulture="es-CO" %>

<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxUploadControl"
    TagPrefix="dxuc" %>

<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dxuc" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Radicacion PQR</title>
    <script language="javascript" type="text/javascript" src="PQRScripts.js">function TABLE1_onclick() {

}

</script>
<!--Creación Scribe para actualizar captcha-->
</script>
<script type="text/javascript">
    function actucap() {
        obj = document.getElementById("cap");
        if (!obj) obj = window.document.all.cap;
        if (obj) {
            obj.src = "Captcha.aspx?" + Math.random();
        }
    }
    </script>
<script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.4.4.js"></script>
        <script src="jquery.blockUI.js" type="text/javascript"></script>
    
        <script type="text/javascript">
            $(document).ready(function() {

            $('.prueba').click(function() {
                $.blockUI({ css: {
                                    border: 'none',
                                    padding: '15px',
                                    backgroundColor: '#000',
                                    '-webkit-border-radius': '10px',
                                    '-moz-border-radius': '10px',
                                    opacity: .5,
                                     color: '#fff'
                                   }
                          });
                 setTimeout($.unblockUI, 2000);
                });
            });    
        </script>
     <script type="text/javascript">
         $(document).ready(function () {
             $('#check').click(function () {
                 var checkboxValues = "";
                 $('input[name="orderBox[]"]:checked').each(function () {
                     checkboxValues += $(this).val() + ",";
                 });
                 //eliminamos la última coma.
                 checkboxValues = checkboxValues.substring(0, checkboxValues.length - 1);
                 
                 if (checkboxValues == 'datos,correo') {
                     
                     $('#btEnviarPQR').attr('disabled', false);
			
                 }
                 else 
                 {
                     $('#btEnviarPQR').attr('disabled', true);
			
                  }
             });
         });
    
     </script>    
<script language="javascript" type="text/javascript">
function numbersonly(myfield, e, dec)
{
var key;
var keychar;

if (window.event)
key = window.event.keyCode;
else if (e)
key = e.which;
else
return true;
keychar = String.fromCharCode(key);

// control keys
if ((key==null) || (key==0) || (key==8) ||
(key==9) || (key==13) || (key==27) )
return true;

// numbers
else if ((("0123456789").indexOf(keychar) > -1))
return true;

// decimal point jump
else if (dec && (keychar == "."))
{
myfield.form.elements[dec].focus();
return false;
}
else
return false;
}
</script>
    <style type="text/css">
        body
        {
            font-family:Calibri,Arial, Helvetica, sans-serif;
            color:#555;
            text-align:justify;
	        line-height:150%;
	        padding: 0% 2% 0% 2%;
	        max-width: 100%;

        }
        
        .cajasTexto
        {
            width:99%;
            background-color: white;
            color: black; 
                
        }
        
        .WaterMarkedTextBox
        {
            width:99%;
            height: 100%;
            border: 1px solid #BEBEBE;
            background-color: #F2F2F2;
            color: gray;
            /*font-size: 8pt;
            text-align: center;*/
        }
        
        .WaterMarkedDDL
        {
            /*border: 1px solid #BEBEBE;*/
            background-color: #F2F2F2;
            color: gray;
            width:100%;
            
            /*font-size: 8pt;
            text-align: center;*/
        }
        
        .modalBackground 
        { 
            background-color: Gray; 
            filter: alpha(opacity=50); 
            opacity: 0.50; 
        } 
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <cc1:ModalPopupExtender ID="ModalPopupAjax" runat="server" PopupControlID="pnMsgPopup" 
            OkControlID="btMsgPupup" TargetControlID="pnMsgPopup" BackgroundCssClass="modalBackground">
        </cc1:ModalPopupExtender>
        <asp:Panel ID="pnMsgPopup" runat="server" Width="560px" BackColor="ControlLightLight" Visible="true" style="display:none;">
            <table width="100%" id="TABLE1" onclick="return TABLE1_onclick()">
                <tr>
                    <td colspan="3" bgcolor="activecaption">
                        <span style="color:White; font-weight:bold;">
                            <asp:Label ID="etMsgPopupTitulo" runat="server" ForeColor="White" Text="" Font-Size="14pt"></asp:Label></span></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="etMsgPopuMensaje" runat="server" ForeColor="Red" Font-Size="12pt"></asp:Label></td>
                </tr>
                <tr>
                    <td width="50%">
                        &nbsp;
                        </td>
                    <td>
                        <asp:Button ID="btMsgPupup" Text="Aceptar" runat="server" CausesValidation="False" UseSubmitBehavior="False"  /></td>
                </tr>
            </table>
        </asp:Panel>
        <!--<img src="AlfaNetImagen/icoMinisterioTic.gif" />--></div>
        <p>
            Los campos marcados con <span style="color:red;">*</span> son obligatorios.&nbsp;
        </p>
            <table width="100%">
                <tr>
                    <td style="width: 30%"><span style="color:red;">*</span><asp:Label ID="etTipoIdentificacion" runat="server" Text="Tipo de Identificación" EnableViewState="False" Font-Size="9pt"></asp:Label></td>
                    <td style="width: 45%">
                        <asp:DropDownList ID="ddlTipoDeIdentificacion" runat="server" CssClass="WaterMarkedDDL" AutoPostBack="True" >
                            <asp:ListItem>---Seleccione un Tipo de Documento---</asp:ListItem>
                            <asp:ListItem Value="cc">C&#233;dula de Ciudadan&#237;a</asp:ListItem>
                            <asp:ListItem Value="ti">Tarjeta de Identidad</asp:ListItem>
                            <asp:ListItem Value="ce">C&#233;dula de Extranjer&#237;a</asp:ListItem>
                            <asp:ListItem Value="nit">Nit</asp:ListItem>
                            <asp:ListItem Value="pas">Pasaporte</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 35%">
                        <asp:RequiredFieldValidator  Font-Size="Small"  ID="cvTipoIdentificacion" runat="server" ControlToValidate="ddlTipoDeIdentificacion"
                            Display="Dynamic" ErrorMessage="Debe seleccionar un tipo de identificación"> * Debe Seleccionar un Tipo de Identificacion</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="left" style="width: 30%"><span style="color:red;">*</span><asp:Label ID="etNumIdentificacion" runat="server" Text="Número de Identificación" EnableViewState="False" Font-Size="9pt"></asp:Label></td>
                    <td style="width: 45%">
                        <asp:UpdatePanel ID="UpdPnIdentificacion" runat="server">
                            <ContentTemplate>
                        <asp:TextBox ID="ctIdentificacion" runat="server" onKeyPress="return numbersonly(this, event)"  CssClass="cajasTexto" AutoPostBack="True" OnTextChanged="ctIdentificacion_TextChanged"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TBWIdentificacion" runat="server" TargetControlID="ctIdentificacion" WatermarkText="Numero de Identifacion" WatermarkCssClass="WaterMarkedTextBox">
                        </cc1:TextBoxWatermarkExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 35%">
                    <asp:RequiredFieldValidator Font-Size="Small"  ID="cvIdentificacion" runat="server"
                            ControlToValidate="ctIdentificacion" Display="Dynamic" ErrorMessage="El número de identificación es requerido"> * El numero de identificacion es requerido</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 30%"><span style="color:red;">*</span><asp:Label ID="etNombreProcedencia" runat="server" Text="Nombres y Apellidos" EnableViewState="False" Font-Size="9pt"></asp:Label></td>
                    <td style="width: 45%">
                        <asp:UpdatePanel ID="UpdPnNombreProcedencia" runat="server">
                            <ContentTemplate>
                        <asp:TextBox ID="ctNombreProcedencia" runat="server" CssClass="cajasTexto"></asp:TextBox><cc1:TextBoxWatermarkExtender ID="TBWNombreProcedencia" runat="server" WatermarkText="Nombres y Apellidos" TargetControlID="ctNombreProcedencia" WatermarkCssClass="WaterMarkedTextBox">
                        </cc1:TextBoxWatermarkExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 35%">
                    <asp:RequiredFieldValidator Font-Size="Small" ID="cvNombreProcedencia" runat="server"
                            ControlToValidate="ctNombreProcedencia" Display="Dynamic" ErrorMessage="Su nombre es requerido"> * Su nombre es requerido</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 30%"><span style="color:red;">*</span><asp:Label ID="etEmail" runat="server" Text="Email" EnableViewState="False" Font-Size="9pt"></asp:Label></td>
                    <td style="width: 45%">
                        <asp:UpdatePanel ID="UpdPnEmail" runat="server">
                            <ContentTemplate>
                        <asp:TextBox ID="ctEmail" runat="server" CssClass="cajasTexto" ValidationGroup="cvEmail"></asp:TextBox><cc1:TextBoxWatermarkExtender ID="TBWEmail" runat="server" TargetControlID="ctEmail" WatermarkText="Email, Ejemplo: email@correo.com" WatermarkCssClass="WaterMarkedTextBox">
                        </cc1:TextBoxWatermarkExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 35%">
                    <asp:RequiredFieldValidator Font-Size="Small" ID="cvEmail" runat="server"
                            ControlToValidate="ctEmail" Display="Dynamic" ErrorMessage="El correo electronico es requerido"> * El correo electronico es Requerido</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="cvfEmail" runat="server" ControlToValidate="ctEmail"
                            Display="Dynamic" ErrorMessage="El correo electronico suministrado no es valido"
                            SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Font-Size="Small"> * El correo electronico suministrado no es valido</asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td style="width: 30%"><span style="color:red;">*</span><asp:Label ID="etTelefono" runat="server" Text="Teléfono" EnableViewState="False" Font-Size="9pt"></asp:Label>
                    </td>
                    <td style="width: 45%">
                        <asp:UpdatePanel ID="UpdPnTelefono" runat="server">
                            <ContentTemplate>
                        <asp:TextBox ID="ctTelefono" runat="server" CssClass="cajasTexto" CausesValidation="True"></asp:TextBox><cc1:TextBoxWatermarkExtender
                            ID="TBWTelefono" runat="server" TargetControlID="ctTelefono" WatermarkText="Numero Telefonico" WatermarkCssClass="WaterMarkedTextBox">
                        </cc1:TextBoxWatermarkExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 35%">
                        <asp:RequiredFieldValidator Font-Size="Small" ID="cvTelefono" runat="server"
                            ControlToValidate="ctTelefono" Display="Dynamic" ErrorMessage="El teléfono es requerido">* El telefono es requerido</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 30%"><span style="color:red;">*</span><asp:Label ID="etDireccion" runat="server" Text="Dirección" EnableViewState="False" Font-Size="9pt"></asp:Label></td>
                    <td style="width: 45%">
                        <asp:UpdatePanel ID="UpdPnDireccion" runat="server">
                            <ContentTemplate>
                        <asp:TextBox ID="ctDireccion" runat="server" CssClass="cajasTexto"></asp:TextBox><cc1:TextBoxWatermarkExtender
                            ID="TBWDireccion" runat="server" TargetControlID="ctDireccion" WatermarkText="Direccion de Correspondencia" WatermarkCssClass="WaterMarkedTextBox">
                        </cc1:TextBoxWatermarkExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 35%">
                    <asp:RequiredFieldValidator Font-Size="Small" ID="cvDireccion" runat="server"
                            ControlToValidate="ctDireccion" Display="Dynamic" ErrorMessage="La dirección es requerida"> * La Direccion es requerida</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 30%"><span style="color:red;">*</span><asp:Label ID="etPais" runat="server" Text="País" EnableViewState="False" Font-Size="9pt"></asp:Label></td>
                    <td style="width: 45%">
                        <asp:DropDownList ID="ddlPais" runat="server" CssClass="WaterMarkedDDL" AutoPostBack="True" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged">
                        </asp:DropDownList>
                        <cc1:CascadingDropDown ID="cddPais" runat="server" ServicePath="CascadinDropDown.asmx" ServiceMethod="GetPais" Category="Pais" PromptText="Seleccione un país ..." SelectedValue="170"
                            TargetControlID="ddlPais">
                        </cc1:CascadingDropDown>
                    </td>
                    <td style="width: 35%">
                    <asp:RequiredFieldValidator ID="cvPais" runat="server"
                            ControlToValidate="ddlPais" Display="Dynamic" ErrorMessage="Seleccione un país" Font-Size="Small"> * Seleccione un Pais</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 30%"><span style="color:red;">*</span><asp:Label ID="etDepartamento" runat="server" Text="Departamento" EnableViewState="False" Font-Size="9pt"></asp:Label></td>
                    <td style="width: 45%">
                        <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="WaterMarkedDDL">
                        </asp:DropDownList><cc1:CascadingDropDown ID="cddDepartamento" runat="server" TargetControlID="ddlDepartamento" ServicePath="CascadinDropDown.asmx" ServiceMethod="GetDepartamentoByPais " ParentControlID="DDLPais" Category="Departamento" PromptText="Seleccione un Departamento..." SelectedValue="11">
                        </cc1:CascadingDropDown>
                        <asp:TextBox ID="ctDepartamento" runat="server" Visible="False" CssClass="cajasTexto"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TBWDepartamento" runat="server" TargetControlID="ctDepartamento" WatermarkCssClass="WaterMarkedTextBox" WatermarkText="Ingrese la Provincia">
                        </cc1:TextBoxWatermarkExtender>
                    </td>
                    <td style="width: 35%">
                    <asp:RequiredFieldValidator ID="cvDepartamento" runat="server"
                            ControlToValidate="ddlDepartamento" Display="Dynamic" ErrorMessage="Seleccione un departamento" Font-Size="Small"> * Seleccione un departamento</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 30%"><span style="color:red;">*</span><asp:Label ID="etCiudad" runat="server" Text="Ciudad" EnableViewState="False" Font-Size="9pt"></asp:Label></td>
                    <td style="width: 45%">
                        <asp:DropDownList ID="ddlCiudad" runat="server" CssClass="WaterMarkedDDL">
                        </asp:DropDownList><cc1:CascadingDropDown ID="cddCiudad" runat="server" TargetControlID="ddlCiudad" ServicePath="CascadinDropDown.asmx" ServiceMethod="GetCiudadByDepartamento" ParentControlID="DDLDepartamento" Category="Ciudad" PromptText="Seleccione Ciudad..." SelectedValue="11001">
                        </cc1:CascadingDropDown>
                        <asp:TextBox ID="ctCiudad" runat="server" Visible="False" CssClass="cajasTexto"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TBWCiudad" runat="server" TargetControlID="ctCiudad" WatermarkCssClass="WaterMarkedTextBox" WatermarkText="Ingrese la Ciudad de Residencia">
                        </cc1:TextBoxWatermarkExtender>
                    </td>
                    <td style="width: 35%">
                    <asp:RequiredFieldValidator ID="cvCiudad" runat="server"
                            ControlToValidate="ddlCiudad" Display="Dynamic" ErrorMessage="Seleccione una ciudad" Font-Size="Small"> * Seleccione una Ciudad</asp:RequiredFieldValidator></td>
                </tr>
             </table>
             <table width="75%">
                <tr>
                    <td>
                        <p style="color:Red; font-size:small; width:100%">
                            La respuesta a su solicitud le será enviada a través de la dirección de 
                            correspondencia o al correo electrónico, por lo tanto verifique que los 
                            datos se incluyeron correctamente.
                        </p>
                    </td>
                </tr>
             </table>
             <table  width="100%">
                <tr>
                    <td style="height: 74px; width: 30%;"><span style="color:red;">*</span><asp:Label ID="etTipoDePQR" runat="server" Text="Tipo de Solicitud" EnableViewState="False" Font-Size="9pt"></asp:Label></td>
                    <td style="height: 74px; width: 45%;">
                        <asp:DropDownList ID="ddlTipoDePQR" runat="server" CssClass="WaterMarkedDDL">
                        </asp:DropDownList>
                        <cc1:CascadingDropDown ID="CCDTipoDePQR" runat="server" TargetControlID="ddlTipoDePQR" ServicePath="CascadinDropDown.asmx" ServiceMethod="GetNaturalezaByPQR" PromptText="Seleccione el tipo de Solicitud" Category="Naturaleza">
                        </cc1:CascadingDropDown>
                    </td>
                    <td style="height: 74px; width: 35%;">
                    <asp:RequiredFieldValidator ID="cvTipoPQR" runat="server"
                            ControlToValidate="ddlTipoDePQR" Display="Dynamic" ErrorMessage="Seleccione un tipo de solicitud" Font-Size="Small"> * Seleccione un tipo de Solicitud</asp:RequiredFieldValidator></td>
                </tr>
               <tr>
                    <td style="width: 30%"><span style="color:red;">*</span><asp:Label ID="etDetalle" runat="server" Text="Detalle" EnableViewState="False" Font-Size="9pt"></asp:Label></td>
                    <td style="text-align: left; font-size: 12px; width: 45%;">
                        <asp:TextBox ID="ctDetalle" runat="server" TextMode="MultiLine" CssClass="cajasTexto" MaxLength="300" Rows="6" OnTextChanged="ctDetalle_TextChanged" Height="58px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender
                            ID="TBWDetalle" runat="server" TargetControlID="ctDetalle" WatermarkText="Escriba el detalle de su Peticion, Queja o Reclamo" WatermarkCssClass="WaterMarkedTextBox">
                        </cc1:TextBoxWatermarkExtender>	                   
			<br />                        
                        <asp:Label ID="LbRadicadoRepetido" runat="server" Font-Size="9pt" ForeColor="Red" Width="100%"></asp:Label>
                        <br />
                        <span style="font-size: 12px">
                            Puede ingresar hasta un máximo de 300 caracteres.</span>
                        <span>Caracteres ingresados: </span><asp:Label ID="etMaximoCaracteres" runat="server" Text="0"></asp:Label>, m<span>áximo
                            300 caracteres</span>
                    </td>
                    <td style="width: 35%">
			
                    <asp:RequiredFieldValidator ID="cvDetalle" runat="server"
                            ControlToValidate="ctDetalle" Display="Dynamic" ErrorMessage="Debe indicar el detalle de la solicitud" Font-Size="Small"> * Debe indicar el detalle de la solicitud</asp:RequiredFieldValidator></td>
                </tr>
             </table>
             <table width="100%">
                 <tr>
                    <td style="width: 30%">
                        <asp:Label ID="etAdjunto" runat="server" Text="Adjunto" EnableViewState="False" Font-Size="9pt"></asp:Label></td>
                    <td style="width: 40%">
                        <dxuc:aspxuploadcontrol id="devExUpLoadArchivo" runat="server" cssfilepath="/App_Themes/Aqua/{0}/styles.css"
                            csspostfix="Aqua" showaddremovebuttons="True" Font-Size="Smaller">
                            <RemoveButton Text="Remover Archivo"></RemoveButton>
                            <ClientSideEvents FileInputCountChanged="function(s, e) {
                                var fcount = s.GetFileInputCount(); 
                                if(fcount == 5)
                                    s.SetAddButtonText('');
                                else
                                    s.SetAddButtonText('Agregar Nuevo Archivo');
                                }"></ClientSideEvents>
                        <ProgressBarStyle Height="25px"></ProgressBarStyle>
                        <AddButton Text="Adicionar Mas Archivos">
		<Image Url="~/AlfaNetImagen/adjunto2.png"></Image>
		</AddButton>
                        </dxuc:aspxuploadcontrol>
                        <asp:Label ID="etFormaArchivosValidos" runat="server" Text="Formatos válidos: Imagen (jpg,jpeg,gif,png), Texto (doc,docx,pdf),  compresión de archivos  (zip, rar)" Font-Size="Smaller" Width="100%"></asp:Label>
                    </td>
                    <td style="width: 30%">
                        </td>
                </tr>
		<tr>
                <td colspan="2">
		<div id ="check">
		<span style="color:red;">*</span><input type="checkbox" id="datos" name="orderBox[]" value="datos" />
                        &nbsp;<asp:Label ID="LblAutDatos" Font-Bold="true" runat="server" Text="He leído y estoy de acuerdo con los términos y condiciones de uso de datos, implementados por CONVEL S.A.S."></asp:Label>
			<asp:LinkButton ID="LkBUsoDatos" CausesValidation="False" OnClick= "LinkUsoDatos_Click" runat="server">Ver términos y condiciones.</asp:LinkButton>
                        <br /><span style="color:red;">
                        <br />
                        *</span><input type="checkbox" id="correo" name="orderBox[]" value="correo" />
                        &nbsp;<asp:Label ID="LblAutCorreo" Font-Bold="true" runat="server" Text="Certifico que el correo electrónico ingresado en mis datos personales se encuentra vigente, de igual manera autorizo a CONVEL S.A.S para el envío de la respuesta a mi solicitud por este medio."></asp:Label>
			</div>
		</td>
                </tr>
                <tr>
                    <td style="width: 30%">
                    </td>
                    <td style="width: 45%">
			
			<%--Creación Captcha John Vela 11/08/2016 para evitar Robot Informaticos--%>
			            <img alt="" src="Captcha.aspx" id="cap"  />
                        <a href="javascript:actucap();"  title="Actualizar Captcha" style="background-position: center center; padding: inherit; margin: inherit; background-image: url('AlfaNetImagen/ToolBar/actualizar.png'); color: #FFFFFF; text-decoration: none; text-transform: none; font-variant: normal; font-style: normal; font-weight: 100; font-size: -66px; font-family: Arial, Helvetica, sans-serif; position: absolute; z-index: auto; height: 65px; width: 74px; background-repeat: no-repeat; background-attachment: scroll;" >.....</a>
                        <br />
                        <asp:Label ID="LblCaptcha" EnableViewState="False" runat="server" Text="Favor digite el Texto de la Imagen.                                                                       " Font-Size="9pt"></asp:Label>
                        <asp:TextBox ID="TxtBCaptcha" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;<asp:Label ID="LblCaptchaError" runat="server" 
                            AssociatedControlID="TxtBCaptcha" Font-Size="9pt" ForeColor="Red" Width="50%" ></asp:Label>
                        <br />


                        <%--Modificación John VEla 22/06/2015 para bloquear el boton enviar despues del primer clikc--%>
			<asp:Button ID="btEnviarPQR" runat="server" Text="Enviar" OnClientClick = "this.disabled = true;" OnClick="btEnviarPQR_Click" CssClass = "prueba" Enabled="False"/>

                        <%--<asp:Button ID="btEnviarPQR" runat="server" Text="Enviar" OnClick="btEnviarPQR_Click" CssClass = "prueba" />
                       --%>&nbsp; 
                        <asp:Button ID="btLimpiarFormulario" runat="server"
                            OnClick="btLimpiarFormulario_Click" Text="Limpiar" CausesValidation="False" UseSubmitBehavior="False" />
                        &nbsp; 
                        <%--<input id="Button1" onclick="parent.location.href='http://www.mintic.gov.co/index.php/pqr'" type="button" value="Volver al Inicio"/>--%></td>
                    <td style="width: 25%">
                    </td>

                </tr>
            </table>      
<p style="color:#24698e;">
    &nbsp;</p>
        <p style="color: #24698e; font-size:small; text-align:justify;">
    CONVEL S.A.S , garantiza la confidencialidad 
    de los datos personales facilitados por los usuarios y su tratamiento de acuerdo con la legislación sobre 
    protección de datos de carácter personal; siendo de uso exclusivo de la entidad y trasladados a terceros con 
    autorización previa del usuario.
</p>
<p style="font-size:small; text-align:justify;">
Mayor Información: <br />
<span style=" color:#24698e; font-size:small;">PUNTO DE ATENCIÓN</span><br />
CONVEL S.A.S<br />
Cra 63b No. 32E 26 Cerro Nutibara Medellín - Colombia <br />
Horario de atención : Lunes a Viernes de 8:30 a.m. a 4:30 p.m. <br />
PBX : (574) 350 8866
</p>


    </form>
</body>
</html>
