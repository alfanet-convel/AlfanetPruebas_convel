<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PQR_find.aspx.cs" Inherits="PQR_find" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PQR- Busqueda</title>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
<script type="text/javascript" language="javascript" src="AlfaNetScripts/validacion_pqr.js">
</script>
<script type="text/javascript" src="AlfaNetScripts/ModalPopups.js" language="javascript"></script>
<script language="javascript" type="text/javascript">

function stopRKey(evt) {
   var evt = (evt) ? evt : ((event) ? event : null);
   var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
   if ((evt.keyCode == 13) && (node.type=="text")) {return false;}
}
function mis_datos(){
var key=window.event.keyCode;
if (key < 48 || key > 57){
window.event.keyCode=0;
}}

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


function ModalPopupsAlert1() {
var valor =  document.getElementById("HFmensaje").value 
if( valor != "0" )
{
var cabezote = document.getElementById("HFCabezote").value 
var contenido = document.getElementById("HFContenido").value
ModalPopups.Alert("jsAlert1",
        cabezote,
        "<div style='padding:25px;'>"+contenido+"</div>", 
        {
            okButtonText: "Close"
        }
    );
    }
    document.getElementById("HFmensaje").value = "0";
    document.getElementById("HFCabezote").value = "";
    document.getElementById("HFContenido").value = ""
}



document.onkeypress = stopRKey;
window.onload = ModalPopupsAlert1;

</script>
<link href="AlfaNetScripts/pqrstylev2.css" type="text/css" />
<style type="text/css">
@media screen and (-webkit-min-device-pixel-ratio:0) {
/* Reglas específicas para Safari 3.0 y Chrome aquí */

}

	body {
	margin:0;
    padding: 0% 0% 0% 0%;
	
	font-family:Calibri,Arial, Helvetica, sans-serif;
	font-size:100%;
	color:#555;
	line-height:180%;
	background: #fff !important; /* Firefox y los demás */
    }
     
      /*estilo para los elementos del formulario*/
		.WaterMarkedDDL
        {
            /*border: 1px solid #BEBEBE;*/
            background-color: #F2F2F2;
            color: gray;
            width: 100%;
            
            /*font-size: 8pt;
            text-align: center;*/
        }
        
        .WaterMarkedDDLError
        {
            /*border: 1px solid #BEBEBE;*/
            /*background-color: #F0F8FF;*/
            color: red;
            width: 30%;
            /*font-size: 8pt;
            text-align: center;*/
        }
        
        .divddl
        {
            border-width:1pt;
            border-color:#BEBEBE;
            border-style:solid;
            width:30%;
            background-color: #F2F2F2;
        }
          .divddlnorm
        {
            border-width:1pt;
            border-color:#BEBEBE;
            border-style:solid;
            width:100%;
            background-color: #FFFFFF;
        }
		
		
        .WaterMarkedTextBox
        {
        
            
            width: 30%;
            height: 100%;
            border: 1px solid #BEBEBE;
            background-color: #F2F2F2;
            color: gray;
            /*font-size: 8pt;
            text-align: center;*/
        }
        
        .WaterMarkedTextBoxDet
        {
        
            width: 100%;
            height: 100%;
            
            border: 1px solid #BEBEBE;
            background-color: #F2F2F2;
            color: gray;
            font-family:Calibri,Arial, Helvetica, sans-serif;
	        font-size:100%;
            /*font-size: 8pt;
            text-align: center;*/
        }
        
         .TextBoxDet
        {
        
            width: 100%;
            height: 100%;
            
            border: 1px solid #BEBEBE;
            background-color: #FFFFFF;
            color: black;
            font-family:Calibri,Arial, Helvetica, sans-serif;
	        font-size:100%;
            /*font-size: 8pt;
            text-align: center;*/
        }
        
        
        .WaterMarkedTextBoxPSW
        {
            background-position: center;
            
            width: 90%;
            border: 1p% solid #BEBEBE;
            background-color: #F2F2F2;
            color: white;
            vertical-align: middle;
            text-align: right; 
            /*background-image: url(Images/psw_wMark.png);
            background-repeat: no-repeat;*/
        }
        .NormalTextBox
        {
            width: 30%;
			background-color: #FFFFFF;
			border: 1px solid #BEBEBE;
        }
         .NormalTextBoxDis
        {
            width: 90%;
			background-color: #FFFFFF;
			border: 1px solid #BEBEBE;
			
        }
		 .AlarmTextBox2
        {
            width: 30%;
			background-color: #FFFFFF;
			border: 1px solid #DF0101;
        }
        
        /*estilo pra la imagen autoescalable*/
		.banner {
  		width: 34%;
		max-width:417px;
		min-width:100px;
		
		}
		
		#textoLabel
		{
			font-size:12pt ;
		}
		
		
	 .jqmOverlay { background-color: #FFF; }
            .jqmWindow {
                background: #888888 url(modal_bckgrn.gif) left top repeat-x;
                color: #fff;
                border: 1px solid #888888;
                padding: 0 0px 0px;
            }

            button.jqmClose {
                background: none;
                border: 0px solid #EAEAEB;
                color: #000;
                clear: right;
                float: right;
                padding: 0;
                margin-top:0px;
                margin-left:5px;
                cursor: pointer;
                font-size: 10px;

                letter-spacing: 1px;
            }

            button.jqmClose:hover, button.jqmClose:active {
                color: #FFF;
				border: 0px solid #FFF;
            }

            #jqmTitle {
                background: transparent;
                color: black;
                text-transform: capitalize;
                height: 20px;
                padding: 0px 5px 0 10px;

            }

           /* #jqmContent {
                width: 95%;
                height: 95%;
                display: block;
                clear: both;
                margin: 0;
                margin-top: 0px;
                background: #e8e8e8;
                border: 0px solid #888888;
            }*/
            .LinkPQR
            {
		 
                cursor :pointer;
		
            }
	
</style>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1"/>
<link rel="stylesheet" type="text/css" media="screen" href="AlfaNetScripts/jqModal.css"/>
<script type="text/javascript" src="AlfaNetScripts/jquery-1.2.6.js"></script>
<script type="text/javascript" src="AlfaNetScripts/jquery.ezpz_tooltip.js"></script>
<script type="text/javascript" src="AlfaNetScripts/jqModal.js"></script>
<script type="text/javascript">
    
    
    
    $.fn.ezpz_tooltip.positions.topLeft = function(contentInfo, mouseX, mouseY, offset, targetInfo) {
	contentInfo['top'] = 100;
	contentInfo['left'] = 400;

	return contentInfo;
    };

    $(document).ready(function(){
    
    /*Funciones del modal popup*/
    
        //thickbox replacement
    var closeModal = function(hash)
    {
        var $modalWindow = $(hash.w);

        //$('#jqmContent').attr('src', 'blank.html');
        $modalWindow.fadeOut('2000', function()
        {
            hash.o.remove();
            //refresh parent

            if (hash.refreshAfterClose === 'true')
            {

                window.location.href = document.location.href;
            }
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

                    newHeight = Math.floor(parseInt($(window).height()) * (parseInt(newHeight) / 110));

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
                    newWidth = Math.floor(parseInt($(window).width() / 65) * parseInt(newWidth));
                }
                var newLeft = Math.floor(parseInt($(window).width() / 3) - parseInt(newWidth) /3);

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
    
    
    
    /*Funciones de las ayudas*/
    $('#example-target-1').ezpz_tooltip({
	contentId: 'example-content-1',
	showContent: function(content) {
		content.fadeIn('slow');
	},
	hideContent: function(content) {
		// if the showing animation is still running, be sure to stop it
		// and clear the animation queue. otherwise, repeatedly hovering will
		// cause the content to blink.
		content.stop(true, true).fadeOut('slow');
	}
    });
 
               $('#example-target-2').ezpz_tooltip({
	contentId: 'example-content-2',
	showContent: function(content) {
		content.fadeIn('slow');
	},
	hideContent: function(content) {
		// if the showing animation is still running, be sure to stop it
		// and clear the animation queue. otherwise, repeatedly hovering will
		// cause the content to blink.
		content.stop(true, true).fadeOut('slow');
	}
    });

    $('#example-target-3').ezpz_tooltip({
	contentId: 'example-content-3',
	showContent: function(content) {
		content.fadeIn('slow');
	},
	hideContent: function(content) {
		// if the showing animation is still running, be sure to stop it
		// and clear the animation queue. otherwise, repeatedly hovering will
		// cause the content to blink.
		content.stop(true, true).fadeOut('slow');
	}
    });
 
    $('#example-target-4').ezpz_tooltip({
	contentId: 'example-content-4',
	showContent: function(content) {
		content.fadeIn('slow');
	},
	hideContent: function(content) {
		// if the showing animation is still running, be sure to stop it
		// and clear the animation queue. otherwise, repeatedly hovering will
		// cause the content to blink.
		content.stop(true, true).fadeOut('slow');
	}
    });

    $('#example-target-5').ezpz_tooltip({
	contentId: 'example-content-5',
	showContent: function(content) {
		content.fadeIn('slow');
	},
	hideContent: function(content) {
		// if the showing animation is still running, be sure to stop it
		// and clear the animation queue. otherwise, repeatedly hovering will
		// cause the content to blink.
		content.stop(true, true).fadeOut('slow');
	}
    });

    $('#example-target-6').ezpz_tooltip({
	contentId: 'example-content-6',
	showContent: function(content) {
		content.fadeIn('slow');
	},
	hideContent: function(content) {
		// if the showing animation is still running, be sure to stop it
		// and clear the animation queue. otherwise, repeatedly hovering will
		// cause the content to blink.
		content.stop(true, true).fadeOut('slow');
	}
    });

    $('#example-target-7').ezpz_tooltip({
	contentId: 'example-content-7',
	showContent: function(content) {
		content.fadeIn('slow');
	},
	hideContent: function(content) {
		// if the showing animation is still running, be sure to stop it
		// and clear the animation queue. otherwise, repeatedly hovering will
		// cause the content to blink.
		content.stop(true, true).fadeOut('slow');
	}
    });

    $('#example-target-8').ezpz_tooltip({
	contentId: 'example-content-8',
	showContent: function(content) {
		content.fadeIn('slow');
	},
	hideContent: function(content) {
		// if the showing animation is still running, be sure to stop it
		// and clear the animation queue. otherwise, repeatedly hovering will
		// cause the content to blink.
		content.stop(true, true).fadeOut('slow');
	}
    });

    $('#example-target-9').ezpz_tooltip({
                    contentId: 'example-content-9',
	showContent: function(content) {
		content.fadeIn('slow');
	},
	hideContent: function(content) {
		// if the showing animation is still running, be sure to stop it
		// and clear the animation queue. otherwise, repeatedly hovering will
		// cause the content to blink.
		content.stop(true, true).fadeOut('slow');
	}

                	
   });
               
   $('#example-target-10').ezpz_tooltip();
   
   $('#example-target-11').ezpz_tooltip();
               
            
   });
    
    </script>
 
 
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
        <tr>
        <td colspan="2">
        <asp:Label ID="Label4" runat="server" Text="Seleccione la opción que le sea mas conveniente para conocer el estado <br/> de su solicitud." Font-Bold="True" Font-Size="Medium" ForeColor="#C00000"></asp:Label>
        </td>
        
        </tr>
        </table>
        <asp:Table runat="server" ID="tentrada" Width="560" Visible="true">
          <asp:TableRow runat="server" >
            <asp:TableCell runat="server" HorizontalAlign="Center">
              <asp:Button ID="Button3" runat="server" Text="Tipo y Nro. de Identificaci&#243;n" OnClick="Button3_Click" />
            </asp:TableCell>
          </asp:TableRow>
          <asp:TableRow runat="server">
            <asp:TableCell runat="server" HorizontalAlign="Center">
              <asp:Button ID="Button4" runat="server" Text="Nro. de Solicitud" OnClick="Button4_Click" />
            </asp:TableCell>
          </asp:TableRow>
          <asp:TableRow runat="server">
            <asp:TableCell runat="server" HorizontalAlign="Center">
              <input id="Button5" onclick="parent.location.href='http://www.convel.com.co/'" type="button" value="Volver al Inicio" />
            </asp:TableCell>
          </asp:TableRow>
        </asp:Table>
        
        
        <table>
            <tr>
                <td style="width: 224px">
                    <asp:Label ID="Label7" runat="server" Text="Tipo de documento:" Visible="False"></asp:Label>
         &nbsp;&nbsp;</td>
                <td style="width: 100px">
                    <asp:DropDownList ID="DDLTipoID" runat="server" CssClass="WaterMarkedDDL" Width="100%" AutoPostBack="True" Visible="False">
          <asp:ListItem>Seleccione el tipo de documento</asp:ListItem>
    <asp:ListItem Value="cc">C&#233;dula de Ciudadan&#237;a</asp:ListItem>
    <asp:ListItem Value="ti">Tarjeta de Identidad</asp:ListItem>
    <asp:ListItem Value="ce">C&#233;dula de Extranjer&#237;a</asp:ListItem>
    <asp:ListItem Value="nit">Nit</asp:ListItem>
    <asp:ListItem Value="pas">Pasaporte</asp:ListItem>
          </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 224px">
                    <asp:Label ID="Label9" runat="server" Text="Número de identificacion:" Visible="False"></asp:Label>
                    </td>
                <td style="width: 100px">
                    <asp:TextBox ID="txbnit" runat="server" onKeyPress="return numbersonly(this, event)" onfocus="Focus(this.id,'Ejemplo:12544789')" 
                     onChange="javascript: return validador_campos(this,0,this.id,'Ejemplo:12544789','Ejemplo:12544789')"
                     onblur="javascript: return validador_campos(this,0,this.id,'Ejemplo:12544789','Ejemplo:12544789')" CssClass="WaterMarkedTextBox" Width="250px" Visible="False">Ejemplo:12544789</asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 224px; height: 31px;">
                    <asp:Label ID="Label10" runat="server" Text="Número de solicitud:" Visible="False"></asp:Label>
                    </td>
                <td style="width: 100px; height: 31px;">
                    <asp:TextBox ID="txbpqr" runat="server" onKeyPress="return numbersonly(this, event)" onfocus="Focus(this.id,'Ejemplo:12544789')"
                     onChange="javascript: return validador_campos(this,0,this.id,'Ejemplo:12544789','Ejemplo:12544789')"
                     onblur="javascript: return validador_campos(this,0,this.id,'Ejemplo:12544789','Ejemplo:12544789')" CssClass="WaterMarkedTextBox" Width="250px" Visible="False">Ejemplo:82564</asp:TextBox></td>
            </tr>
        </table>
        &nbsp;
        <asp:Table runat="server" ID="tablaBotones" Visible="false">
        <asp:TableRow>
        <asp:TableCell>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Consultar PQR" Visible="True" />
        
        </asp:TableCell>
        <asp:TableCell>
        <input id="Button2" onclick="parent.location.href='http://www.convel.com.co/'" type="button" value="Volver al Inicio" />
        </asp:TableCell>
        <asp:TableCell>
          <asp:Button ID="btnNuevaConsulta"
            runat="server" OnClick="btnNuevaConsulta_Click" Text="Nueva Consulta" Width="126px" Visible="True" />
        </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
             <br />
        <asp:DataList ID="DataList1" runat="server" CellPadding="4" ForeColor="#333333" 
             RepeatColumns="1" OnItemDataBound="DataList1_ItemDataBound" Width="580px">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingItemStyle BackColor="White" />
            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <ItemTemplate>
            
                <b>
                    <table >
                        <tr>
                            <td style="width: 100px; height: 21px">
                                N° Solicitud: 
                            </td>
                            <td style="width: 200px; height: 21px">
                                Numero de Identificación:</td>
                            <td style="width: 180px; height: 21px">
                             Fecha de Radicación:
                            </td>
                            <td style="width: 100px; height: 21px">
                                Estado:</td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 19px">
                                <asp:Label ID="LbNPQR" runat="server" font-bold="false"  Text='<%#Eval("RADICADO") %>'>'></asp:Label></td>
                            <td style="width: 200px; height: 19px">
                                <asp:Label ID="Label1" runat="server" font-bold="false" Text='<%#Eval("PROCEDENCIACODIGO") %>'>'></asp:Label></td>
                            <td style="width: 180px; height: 19px">
                               <asp:Label ID="Label2" runat="server" font-bold="false" Text='<%#Eval("FECHARADICACION") %>'>'></asp:Label> </td> 
                                <td style="width: 100px; height: 19px">
                                <asp:Label ID="Label3" runat="server" font-bold="false" Text='<%#Eval("ESTADO") %>'>'></asp:Label></td>
                        </tr>
                    </table>
                </b>
                <div id="divrespuesta" runat="server" visible="false">
                <b>N° Respuesta: </b><asp:Label ID="Label5" runat="server" Text='<%#Eval("numeroderespuesta") %>'>'></asp:Label><b>Fecha Respuesta: </b><asp:Label ID="Label6" runat="server" Text='<%#Eval("fechaderespuesta") %>'>'></asp:Label><b>Respuesta: </b><asp:Label ID="Label8" runat="server" Text='<%#Eval("respuesta") %>'>'></asp:Label>
                <a id="LinkImagen" runat="server" visible="false" class="thickbox" style="text-decoration:none; color:Red;">Ver Imagen
                </a>
                <asp:HiddenField ID="HFPQRNat" runat="server" Value='<%#Eval("NaturalezaPQR") %>' />
                <asp:HiddenField ID="HFImagen" runat="server" Value='<%#Eval("nombreimagen") %>' />
                </div>
            </ItemTemplate>
            <SeparatorStyle Font-Bold="False" />
            <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
        </asp:DataList>
        <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px">
        </asp:DetailsView>
        <asp:HiddenField ID="HFmensaje" runat="server"/>
<asp:HiddenField ID="HFCabezote" runat="server"/>
<asp:HiddenField ID="HFContenido" runat="server"/>
<asp:HiddenField ID="HFIsClicked" runat="server"/>
         <div>
             &nbsp;</div></div>
    </form>
    <div id="modalWindow" class="jqmWindow" runat="server" height="50px" width="25px" style="left: 101%; width: 409px; top: 65%; height: 266px">
        <div id="jqmTitle">
            <button class="jqmClose">Salir</button>
            <span id="jqmTitleText">Title of modal window</span>
        </div>
        <iframe id="jqmContent" runat="server" src="" scrolling="auto" height='95%' width='100%' enableviewstate="true">
        </iframe>
    </div>
</body>
</html>
