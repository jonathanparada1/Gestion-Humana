
function BuscarPor() {
    var reg = {};

    if ($('#CkeckDoc').is(':checked')) {
        reg.Identificacion = leerTexto("#txtBusqueda");
        reg.Placa = null;
    } else if ($('#CkeckPlaca').is(':checked')) {
        reg.Placa = leerTexto("#txtBusqueda");
        reg.Identificacion = null;    
    } else if ($('#CkeckTodos').is(':checked')) {
        reg.Placa = null;
        reg.Identificacion = null;
    }

    $('.contTbl').empty();
    $('.contTbl').append('<p>Espere...</p>');

    $.ajax({
        type: "POST",
        url: "api/ReporteApi/ConsultarHistorico",
        dataType: "json",
        contentType: 'application/json',
        data: JSON.stringify(reg),
        success: function (data) {
            if (data != null) {

                MostrarHistorico(data)

                $(".tblHistorico").dataTable({
                    "bRetrieve": true,
                    "bFilter": true,
                    "bLengthChange": false,
                    "bAutoWidth": true,
                    "processing": true,
                    "iDisplayLength": 20
                });
            } else {                
                alert("Error")
            }
        }
    })
}

function MostrarHistorico(response) {

    $('.contTbl').empty();

    var htmlBody = '';
     htmlBody += '<table class="tblHistorico"><thead><tr>';
     htmlBody += '<th>Placa</th><th>Serial</th><th>Categoría</th>';
     htmlBody += '<th>Detalle</th><th>Factura</th>';
     htmlBody += '<th>Proveedor</th><th>Poliza</th>';
     htmlBody += '<th>Identificación</th><th>Nombre</th>';
     htmlBody += '<th>Ubicación</th><th>Area</th>';
     htmlBody += '<th>Cargo</th><th>Fecha</th>';
     htmlBody += '<th>Estado</th><th>Acta</th>';
     htmlBody += '</tr></thead>';
     htmlBody += '<tbody></tbody></table>';
    $('.contTbl').append(htmlBody);
    
    var html = '';
    $.each(response, function (index, value) {
        html += '<tr>';
        html += '<td>' + value.Placa + '</td>';
        html += '<td>' + value.Serial + '</td>';
        html += '<td>' + value.Categoria + '</td>';
        html += '<td>' + value.Detalle + '</td>';
        html += '<td>' + value.Factura + '</td>';
        html += '<td>' + value.Proveedor + '</td>';
        html += '<td>' + value.Poliza + '</td>';
        html += '<td>' + value.Identificacion + '</td>';
        html += '<td>' + value.Nombre + '</td>';
        html += '<td>' + value.Ubicacion + '</td>';
        html += '<td>' + value.Area + '</td>';
        html += '<td>' + value.Cargo + '</td>';
        html += '<td>' + value.Fecha + '</td>';
        html += '<td>' + value.Estado + '</td>';
        html += '<td>' + value.ActaEntrega + '</td>';
        html += '</tr>';
    })

    $('.tblHistorico tbody').append(html);
}

// Regresa el valor del control. Si el control no existe (está oculto) regresa
// cadena vacía.
function leerTexto(nombre) {
    var control = $(nombre);
    var resultado = "";
    if (control != null) {
        resultado = control.val();
    }
    return resultado;
}

function inicializar() {
    //habilitar('.regAnterior .one input', false)
}

$(document).ready(inicializar);