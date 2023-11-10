// Archivo JScript


//Esta funcion de acontinuacion se utiliza para controlar la aparición
//de un popupmodal basado en el control de ajax toolkit 
var launch = false;
function launchModal(){
    launch = true;
}
function pageLoad(){
    if(launch){
        $find("ModalPopupAjax").show();
    }
}

//Control que los caracteres ingresados en el textbox sean solo numeros
function validarSoloNumeros(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;

    patron = /[0-9]/; 
    //caracteres y numeros 
    te = String.fromCharCode(tecla);
    return patron.test(te);

    //EJEMPLOS: de patrones 
    //patron = /[a-zA-ZÑñ]/; //letras
    //patron = /[a-zA-ZÑñ1234567890@.-_áéíóú;:()+*!"·$%& ]/; //caracteres y numeros 
    //patron = /[1234567890]/; //solo numeros 
}

/*
  Valida que solo se admitan numeros si el tipo de identificacion es CC.
*/
function validarIdentificacion(e) {

    //Obtenemos el combo tipo de identificacion
    var listaTipoId = document.getElementById("ddlTipoDeIdentificacion");
    
    if(("cc" == listaTipoId.options[listaTipoId.selectedIndex].value)||("ti" == listaTipoId.options[listaTipoId.selectedIndex].value))
        patron = /[0-9]/;
    else
        patron = /[a-zA-Z0-9]/;

    /*if("ti" == listaTipoId.options[listaTipoId.selectedIndex].value)
        patron = /[0-9]/;
    else
        patron = /[a-zA-Z0-9]/;*/
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
     
    //caracteres y numeros 
    te = String.fromCharCode(tecla);
    return patron.test(te);

    //EJEMPLOS: de patrones 
    //patron = /[a-zA-ZÑñ]/; //letras
    //patron = /[a-zA-ZÑñ1234567890@.-_áéíóú;:()+*!"·$%& ]/; //caracteres y numeros 
    //patron = /[1234567890]/; //solo numeros 
}

/*
 Limita el numero maximo de caracteres que el objeto admite
*/
function ConteoCaracteres(objTxt, objLb, nmax){
    cant = document.getElementById(objTxt).value.length;
    document.getElementById(objLb).innerHTML = cant;
    
    //nmax = 20;
    if(cant>=nmax){
        document.getElementById(objTxt).value = document.getElementById(objTxt).value.substring(0, nmax);
        cant = document.getElementById(objTxt).value.length;
        document.getElementById(objLb).innerHTML = cant;
        
        if (document.layers)
        document.captureEvents(Event.KEYPRESS);
        var keyCode = event.keyCode;
        if ( keyCode == 16 || (keyCode >= 32 && keyCode <= 44) || keyCode == 46 || keyCode == 47     || (keyCode >= 58)    || keyCode == 45)
        event.returnValue = false;
    }
    
}

/*
    DEFINE EL ESTILO CSS DE LA LISTA DEPLEGABLE, SEGUN SI SE HA SELECCIONADO O NO ALGUN VALOR
    EN LA LISTA
*/
function DefineEstiloCCSenListaDesplegable(lista, estilo1, estilo2){
    if("" == lista.options[lista.selectedIndex].value){
        //lista.setAttribute("classname", estilo1);
        //lista.style.backgroundColor = "#F2F2F2";
        //lista.style.color = "gray";
        lista.className = estilo1;
    }
    else{
        //lista.setAttribute("classname", estilo2);
        //lista.style.color = "black";
        //lista.style.backgroundColor = "white";
        lista.className = estilo2;
    }
    //lista.setAttribute("display", "none");
    //alert(lista.getAttribute("display"));
}

/*
 Como el botón reset no funciono a la hora de limpiar o resetear los elementos del formulario
 esa tarea se hace a traves de esta funcion
*/
function limpiarFormulario(){
    elemento = document.getElementById("ctIdentificacion");
    elemento.value = "";
    elemento.blur();
}

