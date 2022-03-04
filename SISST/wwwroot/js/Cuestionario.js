$(document).ready(function () {
    $('#cP').val('');
    $('#dP').val('');
    ObtenerPreguntas();        
    InicializaPreguntas();
    //tooltip
    $('#tablaPreguntasPartial').tooltip({
        selector: "[title]",
        container: "table"
    });
    $('[data-toggle="tooltip"]').tooltip();
});
function selecTodas() {    
    $('#tablaPreguntasModal').LoadingOverlay("show");
    var rows = $('#tablaPreguntasModal').DataTable().rows({ search: 'applied' }).data();
    for (var i = 0; i < rows.length; i++) {
        $('#tablaPreguntasModal').DataTable().column(0).search("^" + rows[i][0] + "$", true, false).draw();
        if ($("#pregunta_" + rows[i][0]).attr("disabled") != "disabled") {
            $("#pregunta_" + rows[i][0]).prop("checked", true);
            $("#pregunta_" + rows[i][0]).attr("checked", "checked");
        }
    }
    $('#tablaPreguntasModal').DataTable().column(0).search("").draw();
    $('#tablaPreguntasModal').LoadingOverlay("hide");
}
function deSelecTodas() {   
    $('#tablaPreguntasModal').LoadingOverlay("show");
    var rows = $('#tablaPreguntasModal').DataTable().rows({ search: 'applied' }).data();
    for (var i = 0; i < rows.length; i++) {
        $('#tablaPreguntasModal').DataTable().column(0).search("^" + rows[i][0] + "$", true, false).draw();
        if ($("#pregunta_" + rows[i][0]).attr("disabled") != "disabled") {
            $("#pregunta_" + rows[i][0]).prop("checked", false);
        }
    }
    $('#tablaPreguntasModal').DataTable().column(0).search("").draw();
    $('#tablaPreguntasModal').LoadingOverlay("hide");
}
function InicializaPreguntas() {
    if ($('#tablaPreguntasPartial').length > 0) {
        if ($.fn.DataTable.isDataTable('#tablaPreguntasPartial')) {
            $('#tablaPreguntasPartial').DataTable().destroy();
        }
        $('#tablaPreguntasPartial').DataTable({
            dom: '<"clear">lrftip',
            "scrollCollapse": false,
            "paging": true,
            "bFilter": true,
            "bInfo": false,
            "compact": true,
            "dt-left": true,
            "ordering": false,
            responsive: true,
            "bLengthChange": true,
            "bPaginate": true,
            lengthMenu: [
                [20, 50, -1],
                ['20', '50', 'Ver todo']
            ],
            language: {
                buttons: {
                    pageLength: "Mostrar _MENU_ registros",
                    print: "Imprimir"
                },
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ registros por página",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }
            },
        });
    }
}
function InicializaPreguntasModal() {
    if ($('#tablaPreguntasModal').length > 0) {
        if ($.fn.DataTable.isDataTable('#tablaPreguntasModal')) {
            $('#tablaPreguntasModal').DataTable().destroy();
        }
        $('#tablaPreguntasModal').DataTable({
            dom: 'lfrtip',
            responsive: true,
            order: [],
            lengthMenu: [
                [10, 20, -1],
                ['10', '20', 'Ver todo']
            ],
            language: {
                buttons: {
                    pageLength: "Mostrar _MENU_ registros",
                    print: "Imprimir"
                },
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ registros por página",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }
            },
        });
    }
}

function ObtenerPreguntas() {
    var idCuestionario = $('#Id').val();   
    $("#listaPreguntas").load(urlObtenerPreguntas + "?idCuestionario=" + idCuestionario +"&agregarSubpreguntas=false", function (data) {     
        if (data.length > 0) {
            InicializaPreguntas();
        }
    });        
}
function cargaVistaPreguntasModal() {   
    var idCuestionario = $('#Id').val();   
    $("#listaPreguntasModal").load(urlMostrarPreguntas + "?idCuestionario=" + idCuestionario, function (data) {           
        if (data.length > 0) {
                $.LoadingOverlay("show");
                InicializaPreguntasModal();
                $.LoadingOverlay("hide");
            }
    });
}
function MostrarPreguntas() {
    $.LoadingOverlay("hide");
    $("#modalSeleccionaPreguntas").modal('show');
    cargaVistaPreguntasModal();    
}
function AgregarPreguntas (e) {
    var tablePreguntasModal = $('#tablaPreguntasModal').dataTable();
    var rowPregunta = tablePreguntasModal._fnGetDataMaster();
    $('#tablaPreguntasModal').DataTable().search(" ");
    var arrLista = [];
    for (var i = 0; i < rowPregunta.length; i++) {
        var id = rowPregunta[i][0];
        $('#tablaPreguntasModal').DataTable().search(" ");
        $('#tablaPreguntasModal').DataTable().column(2).search(rowPregunta[i][2]).draw();
        if ($("#pregunta_" + id).is(':checked')) {
            var idPregunta = id;
            if ($("#pregunta_" + id).attr('disabled') != "disabled") {
                arrLista.push(idPregunta);
            }
        }
        $('#tablaPreguntasModal').DataTable().search(" ");
    }
    if (arrLista.length == 0) {
        swal("Aviso", "Debe seleccionar al menos una pregunta!", "error");
        return false;
    }
    $.LoadingOverlay("show");
    var idCuestionario = $('#Id').val();
    $.ajax({
        url: urlAgregarPreguntas,
        type: 'post',
        dataType: "json",
        async: false,
        data: { idCuestionario: Number(idCuestionario), arrayPIds: arrLista },        
        success: function (resultado) {
            $.LoadingOverlay("hide");
            if (resultado.correcto == "true") {               
                ObtenerPreguntas();
                $("#modalSeleccionaPreguntas").modal('hide');                   
            }
            else
                swal("Agregar preguntas al cuestionario", "Ha fallado agregar las preguntas", "error");            
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $.LoadingOverlay("hide");
            if (thrownError == "Not Found")
                swal("Error al agregar las preguntas!", "No se ha encontrado el recurso", "error");
            else
                swal("Error al agregar las preguntas", "Ha ocurrido un error al intentar agregar las preguntas", "error");            
        }

    });//end ajax
}//end function
function deleteConfirmationCuestionario() {
    $.LoadingOverlay("hide");
    swal({
        title: "¿Está seguro de eliminar el registro?",
        text: "Esta acción eliminará de forma permanente el registro del cuestionario con las preguntas aplicables, por lo que será imposible su recuperación.",
        icon: "warning",
        buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, eliminarlo!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

    }).then(function (e) {
        if (e) {
            $.LoadingOverlay("show");
            $('#frmDelete').submit();
        }
        else {
            swal.close();
        }
    });
    $.LoadingOverlay("hide");
}
function confirmDeletePregunta(id) {
    if (id == "") {
        toastr['error']('Falta el id del registro a eliminar');
        return false;
    }
    $.LoadingOverlay("hide");
    var cp = $('#cP').val();
    var dp = $('#dP').val();
    swal({
        title: "Eliminar pregunta del cuestionario",
        text: "Esta acción eliminará la pregunta ["+cp + " - " + dp + "] del cuestionario\n¿Confirma que desea continuar?",
        icon: "warning",
        buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, eliminarlo!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

    }).then(function (e) {
        if (e) {
            $.ajax({
                url: urlEliminarPregunta,
                type: "GET",
                data: {
                    id: id
                },
                dataType: "json",
                contentType: "application/json",
                success: function (resultado) {
                    if (resultado.correcto == "true") {                       
                        ObtenerPreguntas();
                    }
                    else
                        swal("Eliminar pregunta", "Ha fallado la eliminación de la pregunta", "error");
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    if (thrownError == "Not Found")
                        swal("Error eliminando!", "No se ha encontrado el recurso", "error");
                    else
                        swal("Error eliminando!", "Ha ocurrido un error al intentar eliminar", "error");
                }
            });
        }            
    });
}
function Posicion(id) {
    var OrdenArray = [];
    var Array = [];
    $.each($('#tablaPreguntasPartial > tbody > tr'), function () {
        OrdenArray.push(Number($(this).find('td:first')[0].innerText));
        Array.push(Number($(this).find('td:nth-child(2)')[0].innerText));
    });
    Array = Array.sort();
    for (var i = 0; i < Array.length; i++) {
        if (OrdenArray[i] == id) {
            value = OrdenArray[i - 1];            
            return value;
        }
    }
};
function PosicionAbajo(id) {
    var OrdenArray = [];
    var Array = [];
    $.each($('#tablaPreguntasPartial > tbody > tr'), function () {
        OrdenArray.push(Number($(this).find('td:first')[0].innerText));
        Array.push(Number($(this).find('td:nth-child(2)')[0].innerText));
    });
    Array = Array.sort();
    for (var i = 0; i < Array.length; i++) {
        if (OrdenArray[i] == id) {
            value = OrdenArray[i + 1];            
            return value;
        }
    }
}
function arriba(idCuestionario, idPregunta) {
    if (estado == "P") {
        $.LoadingOverlay("hide");
        swal("Aviso", "El cuestionario no se puede editar porque ya está Publicado!", "error");
        return false;
    }
    var idCambio = Posicion(idPregunta);
    var idCuestionario = $("#Id").val();
    
    $.ajax({
        url: urlCambiarOrden,
        type: 'get',
        dataType: "json",
        async: false,
        data: { idCuestionario: Number(idCuestionario), idPregunta: Number(idPregunta), idCambio: Number(idCambio) },

        success: function (resultado) {
            if (resultado.correcto == "true") {
                ObtenerPreguntas();
            }
            else
                swal("Ordenar preguntas al cuestionario", "Ha fallado ordenar las preguntas", "error");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            if (thrownError == "Not Found")
                swal("Error al ordenar las preguntas!", "No se ha encontrado el recurso", "error");
            else
                swal("Error al ordenar las preguntas", "Ha ocurrido un error al intentar agregar las preguntas", "error");
        }

    });//end ajax
}
function abajo(idCuestionario, idPregunta) {
    if (estado == "P") {
        $.LoadingOverlay("hide");
        swal("Aviso", "El cuestionario no se puede editar porque ya está Publicado!", "error");
        return false;
    }
    var idCambio = PosicionAbajo(idPregunta);
    var idCuestionario = $("#Id").val();
    
    $.ajax({
        url: urlCambiarOrden,
        type: 'get',
        dataType: "json",
        async: false,
        data: { idCuestionario: Number(idCuestionario), idPregunta: Number(idPregunta), idCambio: Number(idCambio) },
        success: function (resultado) {
            if (resultado.correcto == "true") {
                ObtenerPreguntas();
            }
            else
                swal("Ordenar preguntas al cuestionario", "Ha fallado ordenar las preguntas", "error");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            if (thrownError == "Not Found")
                swal("Error al ordenar las preguntas!", "No se ha encontrado el recurso", "error");
            else
                swal("Error al ordenar las preguntas", "Ha ocurrido un error al intentar agregar las preguntas", "error");
        }
    });//end ajax
}
function ordenPregunta(nombre) {
    $.LoadingOverlay("hide");
    $('#lblPregunta').text(nombre);
    $("#modalOrdenPreguntas").modal('show');
}
function modalSubpreguntas(id, nombre) {    
    $.LoadingOverlay("hide");
    $('#etiquetaSubpregunta').text(nombre);
    ObtenerSubpreguntas(id);
    $("#modalSubpreguntas").modal('show');

}
function ObtenerSubpreguntas(id) {
    if ($.fn.DataTable.isDataTable('#tablaSubpreguntas')) {
        $('#tablaSubpreguntas').DataTable().destroy();
    }
    table = $('#tablaSubpreguntas').DataTable({
        "ajax": {
            "url": urlObtenerSubpreguntas,
            "type": "GET",
            "data":
                { idPregunta: Number(id) }
        },
        "filter": true,
        "bFilter": true,
        "bSort": false,
        "columns": [
            { "data": "clave", searchable: true, "name": "clave" },
            { "data": "descripcion", "width": "45%", searchable: true, "name": "descripcion" },

        ],
        lengthMenu: [[20, 50, -1], ['20', '50', 'Ver todo']],
        "bLengthChange": true,
        "bPaginate": true,
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.24/i18n/Spanish.json"
        },
        "stripeClasses": ['odd-row', 'even-row']
    });
}

function PublicarCuestionario() {
    var idCuestionario = $('#Id').val();
    $.LoadingOverlay("hide");
    swal({
        title: "Publicar cuestionario",
        text: "Esta acción publicará este cuestionario y cambiará a No publicado cualquier otro que haya sido Publicado previamente\n¿Confirma que desea continuar?",
        icon: "warning",
        buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, publicarlo!", value: !0, visible: !0, className: "bg-info", closeModal: true } }

    }).then(function (e) {
        if (e) {
            $.ajax({
            url: urlPublicar,
            type: 'post',
            dataType: "json",
            async: false,
            data: { id: Number(idCuestionario) },
            success: function (resultado) {
                if (resultado.correcto == "true") {
                    $.LoadingOverlay("show");
                   location.href = urlDetalles + "?id=" + idCuestionario;                       
                }
                else {
                    swal("Publicar cuestionario", resultado.mensaje, "error");
                }            
            },
            error: function (xhr, ajaxOptions, thrownError) {
                if (thrownError == "Not Found")
                    swal("Error!", "No se ha encontrado el recurso", "error");
                else
                    swal("Error!", "Ha ocurrido un error", "error");
            }

            });//end ajax
        }
        else {
            swal("Publicar cuestionario", "Se canceló la publicación", "warning");
        }  
        });
    $.LoadingOverlay("hide");
}
function DesPublicarCuestionario() {
    var idCuestionario = $('#Id').val();
    $.LoadingOverlay("hide");
    //pregunta si desea remplazar la publicación
    swal({
        title: "Despublicar cuestionario",
        text: "Esta acción despublicará este cuestionario y podrá ser editado\n¿Confirma que desea continuar?",
        icon: "warning",
        buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, despublicarlo!", value: !0, visible: !0, className: "bg-info", closeModal: true } }
    }).then(function (e) {
        if (e) {
            $.LoadingOverlay("show");
            $.ajax({
                url: urlDespublicar,
                type: "GET",
                data: {
                    id: idCuestionario
                },
                dataType: "json",
                contentType: "application/json",
                success: function (resultado) {
                    $.LoadingOverlay("hide");
                    if (resultado.correcto == "true") {                        
                        $.LoadingOverlay("show");
                        location.href = urlDetalles + "?id=" + idCuestionario;                        
                    }
                    else
                        swal("Despublicar cuestionario", "Ha fallado la despublicación del cuestionario", "error");
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    $.LoadingOverlay("hide");
                    if (thrownError == "Not Found")
                        swal("Error!", "No se ha encontrado el recurso", "error");
                    else
                        swal("Error!", "Ha ocurrido un error ", "error");
                }
            });
        }
        else {
            $.LoadingOverlay("hide");
            swal("Despublicar cuestionario", "Se canceló la despublicación", "warning");
        } 
    });    
}
$("#btnCancela").click(function (e) {
    $.LoadingOverlay("hide");
});
$("#btnCerrarPreguntas").click(function (e) {
    $.LoadingOverlay("hide");
});
$("#btnCerrarSubpreguntas").click(function (e) {
    $.LoadingOverlay("hide");
});