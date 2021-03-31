function btnEnviartec() {
    var reg = leerDatos();

    if ($("#loginForm").valid()) {


        if (validarActivo(reg, 1)) {
            if (confirm('¿Está seguro de enviar esta informacion?')) {
                $.ajax({
                    type: "POST",
                    url: "api/TecnologiaApi/Crear",
                    dataType: "json",
                    contentType: 'application/json',
                    data: JSON.stringify(reg),
                    success: function (data) {
                        if (data == "NO") {
                            alert("Usuario Ya Existe")

                        }
                        if (data) {
                            alert("Gracias");
                            $('#Identidad').val("");
                            $('#Correo').val("");
                            $('#ConUsuario').val("");
                            $('#SicoUsu').val("");
                            $('#SicoUsuario2').val("");
                            $('#Usuario').val("");
                            $('#ClaveUsuario').val("");
                            $('#OBSERVACIONES').val("");
                            $('#To').val("");
                            $('#Cco').val("");

                        } else
                            alert("Error")
                    }
                })
            }
        }
    }
    else { alert('Ingrese todos los valores'); }
}


function validarActivo(reg, num) {
    var bool = true;
    if (num == 1) {
        if (reg.CEDULA == null)
            bool = false;
    }
    if (num == 2) {
        if (reg.CEDULA == null)
            bool = false;
    }

    return bool;
}

function ValidarPlaca(id) {
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

function leerDatos() {
    reg = {};
    reg.CEDULA = leerTexto('#Identidad')
    reg.Correo = leerTexto('#Correo')
    reg.NOMBRES = leerTexto('#ConUsuario')
    reg.USUSICO1 = leerTexto('#SicoUsu')
    reg.USUSICO2 = leerTexto('#SicoUsuario2')
    reg.USUARIO = leerTexto('#Usuario')
    reg.CLAVE = leerTexto('#ClaveUsuario')
    reg.CLAVSICO1 = leerTexto('#ClaveSico')
    reg.CLAVSICO2 = leerTexto('#ClaveSico2')
    reg.OBSERVACIONES = leerTexto('#OBSERVACIONES')
    reg.To = leerTexto('#To')
    reg.Cco = leerTexto('#Cco')
    reg.USERLOG = leerTexto('#user')


    return reg;
}

$('.one #Placa').live('change', function (event) {
    ValidarPlaca(this.value);
})

// Regresa el valor del control. Si el control no existe (está oculto) regresa
// cadena vacía.
function leerTexto(nombre) {
    var control = $(nombre);
    var resultado = null
    if (control != null) {
        resultado = control.val();
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
    soloNumeros('#Cedula')
    soloLetras('#PNombre')
    $("#loginForm").validate();
}

$(document).ready(inicializar);