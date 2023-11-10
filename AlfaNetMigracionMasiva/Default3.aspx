<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
       
    protected void Page_Load(object sender, EventArgs e)
    {
        string Grupo = Request["Grupo"];
        if (Grupo == "1")
        {
            Radio1.Checked = true;
            Session["Grupo"] = "1";
        }
        else if (Grupo == "2")
        {
            Radio2.Checked = true;
            Session["Grupo"] = "2"; 
        }
       
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Migracion Masiva de Imagenes</title>
</head>
<body>
<script type="text/vbscript" language="VBScript">
         
    Sub Select_OnClick 
      UploadCtl.Select 
    End Sub
    Sub SelectFolder_OnClick
	    UploadCtl.SelectFolder
    End Sub

    Sub Remove_OnClick 
      UploadCtl.RemoveHighlighted 
    End Sub 

    Sub RemoveAll_OnClick 
      UploadCtl.RemoveAll 
    End Sub 

    Sub Upload_OnClick 
    ''UploadCtl.RemoveAllFormItems
    UploadCtl.Upload
          	    
    End Sub
    
    function load()
        
	  Radio2.value = checked
	  location.href("Default3.aspx?Grupo=2")
	end function
    
    function load1()
      Radio1.value = checked
	  location.href("Default3.aspx?Grupo=1")
	end function

     
    
</script> 

   <H3>INTEGRACIÓN DE IMÁGENES </H3>
   
Importar Imágenes de correspondencia: &nbsp;
   <input type="radio" 
             id="Radio1" 
             name=" grupo"
             onclick="vbscript:load1()"
           
             runat="server"/>
      Recibida
    <input id="Radio2" name="Grupo" type="radio" onclick="vbscript:load()"  runat="server"/>
    Enviada<br>
   
 <div align="center">
    <object 
	classid="CLSID:E87F6C8E-16C0-11D3-BEF7-009027438003" 
	codebase="XUpload.ocx"
	height="250"
	id="UploadCtl" 
	width="100%">
   
	<PARAM NAME="EnablePopupMenu" VALUE="false">
	<PARAM NAME="Server" VALUE="WebAlfa">
	<PARAM NAME="Script" VALUE="/AlfaNetPrePro/AlfaNetAdministracion/AdminImagenes/CodeMigrar.aspx">
	<param name="Redirect" value="True">
    <param name="RedirectURL" value="http://webalfa/AlfanetPrePro/AlfaNetAdministracion/AdminImagenes/showreply.asp">
<%--<PARAM NAME="Redirect" VALUE="True"><PARAM NAME="RedirectURL" VALUE="~/lfaNetAdministracion/AdminImagenes/CodeMigrar.aspx">--%>

<!-- Disable Popup menu. All operations are performed with script-->
<!--Required parameters-->
<!--Redirect browser to a server script upon completion of an upload-->
</OBJECT>  
   <%-- <object 
	classid="CLSID:E87F6C8E-16C0-11D3-BEF7-009027438003" 
	codebase="XUpload.ocx"
	height="250"
	id="Object1" 
	width="550">
      <!-- Disable Popup menu. All operations are performed with script-->
      <PARAM NAME="EnablePopupMenu" VALUE="False">
      <!--Required parameters: upload script's server and location-->
      <param name="Server" value="192.168.0.10">
      <param name="Script" value="/AlfaNetFBSCGR/AlfaNetAdministracion/AdminImagenes/CodeMigrar.aspx">
      <!--Do not view reply from server-->
      <!-- Specify the form's name-->
      <PARAM NAME="HtmlForm" VALUE="MyForm">
      <param name="ViewServerReply" value="False">
      <!--Redirect browser to a server script upon completion of an upload-->
      <%--<param name="Redirect" value="True">
      <param name="RedirectURL" value="http://WebAlfa/showreply.asp">
    </object>--%>
 
  <p> 
    <INPUT TYPE="BUTTON" NAME="SELECT" VALUE="Seleccionar Archivo">
    <INPUT TYPE="BUTTON" NAME="SELECTFOLDER" VALUE="Seleccionar Carpeta">
  </p>
  <p> 
    <INPUT TYPE="BUTTON" NAME="REMOVE" VALUE="Borrar Archivo">
    <INPUT TYPE="BUTTON" NAME="REMOVEALL" VALUE="Borrar Todo">
  </p>
  <p>
    <INPUT TYPE="BUTTON" NAME="UPLOAD" VALUE="Subir">
  </p>
</div>

 
</body>
</html>
