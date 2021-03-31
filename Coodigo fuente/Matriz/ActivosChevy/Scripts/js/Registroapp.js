function Buscarapp() {

    reg = {};
    reg.AREA_P = leerTexto('#Sarea');

            $.ajax({
            type: "POST",
            url: "api/RegistroAppApi/Consultar",
            dataType: "json",
            contentType: 'application/json',
            data: JSON.stringify(reg),
            success: function (data) {
                if (data != null) {

                    if (data) {
                        $('#App').html("");
                        $('#gar').val("");

                    }

                    $('#App').html("");
                    for (var i = 0; i < data.length; i++) {

                        $('#App').html($('#App').html() + '<div class="col-md-2"><input type="checkbox" id="ID_' + data[i].APLICACION + '" onclick="exem(\'' + data[i].ID_APLICACION + '\',\'ID_' + data[i].APLICACION + '\')" /> <label>' + data[i].APLICACION + '</label></div>');                        //  alert(data[i].APLICACION);
                    }

                } else {
                    reg = {};
                    reg.App = '';
                    MostrarUsuario(reg)
                    alert("No existe")
                }
            }
        })
    }
    


       

////$('#App').html($('#App').html() + '<div class="col-md-2"><label>' + data[i].APLICACION + '</label><input type="checkbox" id="ID_' + data[i].APLICACION + '" onclick="exem(\'' + data[i].ID_APLICACION + '\',\'ID_' + data[i].APLICACION + '\')" /><br /></div>');

////function leerDatos() {
////    reg = {};
////    reg.AREA = leerTexto('#Sarea')
////    reg.AREA = leerTexto('#Sarea')



////return reg;
////}



//// Regresa el valor del control. Si el control no existe (está oculto) regresa
//// cadena vacía.
//function leerDatos(nombre) {
//    var control = $(nombre);
//    var resultado = null
//    if (control != null) {
//        resultado = control.val();
//        if (resultado == '') resultado = null;
//    }
//    return resultado;
//}

//function setValue(id, valor, tipo) {
//    if (tipo) {
//        $(id).val(valor);
//    } else {
//        $(id).html(valor);
//    }
//}