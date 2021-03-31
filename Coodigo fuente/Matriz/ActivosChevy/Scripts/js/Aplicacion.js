
function BuscarDirector() {

    reg = {};
    reg.USUARIO = leerTexto('#Identidad');
    reg.PROCEDIMIENTO = "SP_SelecActual";

    $.ajax({
        type: "POST",
        url: "api/TrasladoApi/Consultar",
        dataType: "json",
        contentType: 'application/json',
        data: JSON.stringify(reg),
        success: function (data) {
            if (data != null) {
                MostrarTraslado(data)
            } else {
                reg = {};
                reg.Identidad = ''; reg.SNombre = ''; reg.SOCargo = ''; reg.SOArea = ''; reg.Cargo = ''; reg.SOContrato = ''; reg.Papellido = ''; reg.SORol = ''; reg.SOOficina = '';
                MostrarTraslado(reg)
                alert("No existe")
            }
        }
    });
}

function MostrarTraslado(data) {
    setValue('#Ndocuemnto', data.CEDULA, true)
    setValue('#Nombre', data.NOMBRES, true)
    setValue('#Apellidos', data.APELLIDOS, true)
    setValue('#Cargo', data.CARGO, true)
    setValue('#Area', data.AREA, true)
}

///* Formato Entero */
function formatoEntero(control) {
    limitarCaracteres(control, "^[0-9\,]+$");
    $(control).change(formatoEnteroAplicar);
    $(control).change();
}

/* Permite digitar únicamente números en el texto */
function soloNumeros(control) {
    limitarCaracteres(control, "^[0-9]+$");
}

///* Permite digitar únicamente letras en el texto */
function soloLetras(control) {
    limitarCaracteres(control, "^[ a-zA-Z]+$");
}

function inicializar() {
    habilitar('.regAnterior .one input', false)
    soloNumeros('#Ndocuemnto')
    soloLetras('#Apellidos')
    $("#loginForm").validate();
}

$(document).ready(inicializar);