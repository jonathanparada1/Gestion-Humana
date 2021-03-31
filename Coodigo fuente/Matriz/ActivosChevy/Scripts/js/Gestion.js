
function leerDatos2() {

    var reg = {};
    reg.CEDULA = leerTexto('#Identidad')
    reg.NOMBRES = leerTexto('#SNombre')
    reg.CARGO = leerTexto('#SOCargo')
    reg.AREA = leerTexto('#SOArea')
    reg.T_CONTRATO = leerTexto('#SOContrato')
    reg.APELLIDOS = leerTexto('#Papellido')
    reg.OBSERVACIONES = leerTexto('#OBSERVACIONES')
    reg.CEDULA_J = leerTexto('#Ndocuemnto')
    reg.NOMBRES_J = leerTexto('#Nombre')
    reg.CARGO_J = leerTexto('#Cargo')
    reg.AREA_J = leerTexto('#Area')
    reg.APELLIDOS_J = leerTexto('#Apellidos')
    reg.CEDULA_JEFE = leerTexto('#Ndocuemnto')
    //reg.ID_APLICACION = leerTexto('#gar')
    reg.APLICACION = leerTexto('#gar')
    reg.USER = leerTexto('#user')
    reg.AREA_P = leerTexto('#Sarea')

    return reg;
}


function btnEnviarActivo() {

    var reg = leerDatos2();

    if ($("#loginForm").valid()) {

        if (ValidarGestion(reg, 1)) {
            if (confirm('¿Está seguro de enviar esta informacion?')) {
                $.ajax({
                    type: "POST",
                    url: "api/HomeApi/Crear",
                    dataType: "json",
                    contentType: 'application/json',
                    data: JSON.stringify(reg),
                    success: function (data) {

                        if (data) {
                            alert("Muchas Gracias");
                            $('#Ndocuemnto').val("");
                            $('#Nombre').val("");
                            $('#Cargo').val("");
                            $('#Apellidos').val("");
                            $('#Area').val("");
                            $('#Identidad').val("");
                            $('#SNombre').val("");
                            $('#SOCargo').val("");
                            $('#SOArea').val("");
                            $('#Papellido').val("");
                            $('#SOCorreo').val("");
                            $('#OBSERVACIONES').val("");
                            $('#gar').val("");
                            $('#App').html("");
                            $('#SOContrato').val("");
                            $('#SOOficina').val("");
                            $('#Sarea').val("LISTADO AREAS");
                        } else
                            alert("Error")
                    }
                })
            }
        } else { alert('Ingrese todos los valores'); }


    }
    else { alert('Ingrese todos los valores'); }
}

function BuscarUsuario() {

    reg = {};
    reg.CEDULA = leerTexto('#Identidad');
    reg.PROCEDIMIENTO = "SP_ConsultaKactus";

    $.ajax({
        type: "POST",
        url: "api/TrasladoApi/Consultar",
        dataType: "json",
        contentType: 'application/json',
        data: JSON.stringify(reg),
        success: function (data) {
            if (data != null) {
                MostrarUsuario(data)
            } else {
                alert("No existe")

            }
        }
    })
}

function BuscarCreado() {
    reg = {};
    reg.CEDULA = leerTexto('#Identidad');
    reg.PROCEDIMIENTO = "SP_ConsultaExistente";

    $.ajax({
        type: "POST",
        url: "api/TrasladoApi/ConsultarExistente",
        dataType: "json",
        contentType: 'application/json',
        data: JSON.stringify(reg),
        success: function (data) {
            if (data != null) {
                MostrarUsuario2(data)
            } else {
                alert("No existe")
                $('#Usuario').val("");
            }
        }
    })
}

function MostrarUsuario2(data) {
    setValue('#Identidad', data.CEDULA, true)
    setValue('#Usuario', data.NOMBRECOMPLETO, true)
}

function MostrarUsuario(data) {
    setValue('#Identidad', data.CEDULA, true)
    setValue('#SNombre', data.NOMBRES, true)
    setValue('#SOCargo', data.CARGO, true)
    setValue('#SOArea', data.AREA, true)
    setValue('#SOOficina', data.C_OFICINA, true)
    setValue('#Papellido', data.APELLIDOS, true)
    setValue('#identificador', data.NOMBRE_APP, true)
    setValue('#App', data.CEDULA_US, true)
    setValue('#SOContrato', data.T_CONTRATO, true)
}


function ValidarGestion(reg, num) {
    if (reg.CEDULA == null || reg.T_CONTRATO == null || reg.NOMBRES == null || reg.APELLIDOS == null ||
        reg.CARGO == null || reg.AREA == null || reg.ID_APLICACION == null)
        return false;

    return true;
}

function Validarpl(id) {
    reg = {};
    reg.Placa = id;
    $.ajax({
        type: "POST",
        url: "api/HomeApi/Consultar",
        dataType: "json",
        contentType: 'application/json',
        data: JSON.stringify(reg),
        success: function (data) {
            if (data) {
                $('.wpcf7-submit').addClass('ocultar');
                alert("La placa ya existe")
            } else {
                $('.wpcf7-submit').removeClass('ocultar');
            }
        }
    })
}


$('.one #Ndocuemnto').live('change', function (event) {
    Validarpl(this.value);
})

// Regresa el valor del control. Si el control no existe (está oculto) regresa
// cadena vacía.
function leerTexto(nombre) {
    var control = $(nombre);
    var resultado = null
    if (control != null) {
        resultado = control.text();// val();

        if (resultado == '') resultado = null;

    }
    return resultado;
}

//Regresa el valor del control. Si el control no existe regresa null.
function leerFecha(nombre) {
    return convertStringToDate(leerTexto(nombre));
}

/*
 * Regresa un número a partir del contenido del texto. Si está vacío regresa
 * null.
 */
function leerNumero(control) {
    return convertStringToNumber($(control).val());
}

//Guarda valor
//id= Identificador , valor , tipo = value o html
function setValue(id, valor, tipo) {
    if (tipo) {
        $(id).val(valor);
    } else {
        $(id).html(valor);
    }
}

//Permite habilitar controles html
function habilitar(control, habilitar) {
    if (habilitar) {
        $(control).prop('disabled', false);
    } else {
        $(control).prop('disabled', 'disabled');
    }
}


/* Regresa true si se trata de un caracter especial como backspace */
function esCaracterEspecial(event) {
    var whichCode = !event.charCode ? event.which : event.charCode;

    if (whichCode == 0) return true;
    if (whichCode == 8) return true;
    if (whichCode == 9) return true;
    if (whichCode == 13) return true;
    if (whichCode == 16) return true;
    if (whichCode == 17) return true;
    if (whichCode == 27) return true;
    return false;
}

/* Únicamente permite digitar los caracteres que cumplan la expresión regular */
function limitarCaracteres(control, expresion) {
    $(control).bind('keypress', function (event) {
        var regex = new RegExp(expresion);
        if (esCaracterEspecial(event)) {
            return true;
        }
        else {
            var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
            if (!regex.test(key)) {
                event.preventDefault();
                return false;
            }
        }
    });
}

/* Formato Entero */
function formatoEntero(control) {
    limitarCaracteres(control, "^[0-9\,]+$");
    $(control).change(formatoEnteroAplicar);
    $(control).change();
}

/* Permite digitar únicamente números en el texto */
function soloNumeros(control) {
    limitarCaracteres(control, "^[0-9]+$");
}

/* Permite digitar únicamente letras en el texto */
function soloLetras(control) {
    limitarCaracteres(control, "^[ a-zA-Z]+$");
}

function inicializar() {
    habilitar('.regAnterior .one input', false)
    soloNumeros('#Identidad')
    soloNumeros('#Ndocuemnto')
    soloLetras('#PNombre')
    $("#loginForm").validate();
}

$(document).ready(inicializar);