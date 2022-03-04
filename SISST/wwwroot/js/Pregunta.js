function selecTodosRequisitos() {    
    $('#tablaRequisitosModal').LoadingOverlay("show");
    var rows = $('#tablaRequisitosModal').DataTable().rows({ search: 'applied' }).data();
    for (var i = 0; i < rows.length; i++) {
        $('#tablaRequisitosModal').DataTable().column(0).search("^" + rows[i][0] + "$", true, false).draw();
        if ($("#requisito_" + rows[i][0]).attr("disabled") != "disabled") {
            $("#requisito_" + rows[i][0]).prop("checked", true);
            $("#requisito_" + rows[i][0]).attr("checked", "checked");
        }
    }
    $('#tablaRequisitosModal').DataTable().column(0).search("").draw();
    $('#tablaRequisitosModal').LoadingOverlay("hide");
}
function deSelecTodosRequisitos()
{   
    $('#tablaRequisitosModal').LoadingOverlay("show");
    var rows = $('#tablaRequisitosModal').DataTable().rows({ search: 'applied' }).data();
    for (var i = 0; i < rows.length; i++) {
        $('#tablaRequisitosModal').DataTable().column(0).search("^" + rows[i][0] + "$", true, false).draw();
        if ($("#requisito_" + rows[i][0]).attr("disabled") != "disabled") {
            $("#requisito_" + rows[i][0]).prop("checked", false);
        }
    }
    $('#tablaRequisitosModal').DataTable().column(0).search("").draw();
    $('#tablaRequisitosModal').LoadingOverlay("hide");
}
function buttonValue(e) {
    console.log("Seleccionado=" + e.value)
    $("#IdValorTipoRespuestaLanzaSubPregunta").val(e.value);
}
function createRadioElement(name, checked, value, disabled) {
    var radioInput;
    try {
        var radioHtml = "<input type='radio' name='" + name + "' value='" + value + "' onclick='buttonValue(this)'";
        if (checked) {
            radioHtml += " checked='checked'";
        }
        if (disabled) {
            radioHtml += " disabled='disabled'";
        }
        radioHtml += '/>';
        radioInput = document.createElement(radioHtml);
    } catch (err) {
        radioInput = document.createElement('input');
        radioInput.setAttribute('type', 'radio');
        radioInput.setAttribute('name', name);
        radioInput.setAttribute('value', value);
        radioInput.setAttribute('onclick', 'buttonValue(this)');
        if (checked) {
            radioInput.setAttribute('checked', 'checked');
        }
        if (disabled) {
            radioInput.setAttribute('disabled', 'disabled');            
        }
    }
    return radioInput;
}
//CONFIRMA ELIMINAR ARCHIVO DE AYUDA
function confirmaEliminar(idArchivo, filaIdHtml) {
    swal({
        title: "¿Está seguro de eliminar el registro?",
        text: "Se eliminará el registro de manera permanente, por lo que será imposible su recuperación. \n ",
        icon: "warning",
        buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, eliminarlo!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

    }).then(function (e) {
        if (e) {
            //$('.sweet-alert').block({ message: "Por favor espere..." });
            /*-----*/
            $.ajax({
                url: urlEliminarArchivo,
                type: 'post',
                dataType: "json",
                async: false,
                data: { id: idArchivo },
                success: function (resultado) {
                    if (resultado.correcto == "true") {
                        $("#" + filaIdHtml).hide();                        
                    }
                    else {
                        if (resultado.correcto == "false") {
                            swal("Eliminar archivo", "Ha fallado la eliminación del archivo", "error");
                        }

                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    if (thrownError == "Not Found")
                        swal("Error al eliminar!", "No se ha encontrado el recurso", "error");
                    else
                        swal("Error al eliminar", "Ha ocurrido un error al intentar eliminar", "error");
                }
            });//end ajax
        }
        else {
            swal("Eliminar archivo", "El archivo no ha sido eliminado :)", "warning");
        }
        /*-----*/
    });
}
// CONFIRMA ELIMINAR PREGUNTA O SUBPREGUNTA
function deleteConfirmationPregunta() {
    $.LoadingOverlay("hide");
    swal({
        title: "Eliminar pregunta",
        text: "Esta acción eliminará de forma permanente el registro de la pregunta con sus posibles dependientes (subpreguntas, archivos de ayuda y requisitos aplicables), por lo que será imposible su recuperación.",
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
function confirmaEliminarSubpregunta(id, filaIdHtml) {
    swal({
        title: "¿Está seguro de eliminar el registro?",
        text: "Esta acción eliminará de forma permanente el registro de la pregunta con sus posibles dependientes (subpreguntas, archivos de ayuda y requisitos aplicables), por lo que será imposible su recuperación.",
        icon: "warning",
        buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, eliminarlo!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

    }).then(function (e) {
        if (e) {
            $.LoadingOverlay("show");
            /*-----*/
            $.ajax({
                url: urlEliminarSubpregunta,
                type: 'post',
                dataType: "json",
                async: false,
                data: { id: id },
                success: function (resultado) {
                    if (resultado.correcto == "true") {
                        $("#" + filaIdHtml).hide();                        
                    }
                    else {

                        if (resultado.correcto == "false") {
                            swal("Eliminar pregunta", "Ha fallado la eliminación de la pregunta", "error");
                        }
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    if (thrownError == "Not Found")
                        swal("Error al eliminar!", "No se ha encontrado el recurso", "error");
                    else
                        swal("Error al eliminar", "Ha ocurrido un error al intentar eliminar", "error");
                }
            });//end ajax
        }
        else {
            swal("Eliminar pregunta", "La pregunta no ha sido eliminada.)", "warning");
        }
    /*-----*/
        $.LoadingOverlay("hide");
    });
}



$(document).ready(function () {   

    $("#IdTipoRespuesta").change(function (e) {
        $("#requiereSubPreguntaFalse").prop("checked", true);
        $("#requiereSubPreguntaTrue").prop("checked", false);
        $("#divSubpregunta").hide();
    });

    $("#requiereSubPreguntaFalse").change(function (e) {
        $("#divSubpregunta").hide();
    });

    $("#requiereSubPreguntaTrue").change(function (e) {
        $('#mensajeRS').text("");
        $("#divSubpregunta").show();
        var tr = $("#IdTipoRespuesta").val();
        console.log("tr=" + tr)
        if (tr != "")
            getListaValores($("#IdTipoRespuesta").val());
        else
            $('#mensajeRS').text("Debe seleccionar el tipo de respuesta.");
    });    

    $('#comboNorma.normaSearch').select2();

    $('#comboNorma.normaSearch').on('select2:select', function (e) {       
        cargaVistaRequisitos($(this).val());
    });

    $('#comboNormaModal.normaSearchModal').select2();

    $('#comboNormaModal.normaSearchModal').on('select2:select', function (e) {        
        var idNorma = $(this).val();        
        cargaVistaRequisitosModal(idNorma);
    });


    //$("#comboNormaModal.normaSearchModal").select2({
    //    minimumInputLength: 4,
    //    placeholder: "Escribe la clave o nombre de la norma a buscar",
    //    language: {
    //        noResults: function () {
    //            return "No hay resultado";
    //        },
    //        errorLoading: function () {
    //            return "No se pudo realizar la consulta";
    //        },
    //        loadingMore: function () {
    //            return 'Cargando más resultados...';
    //        },
    //        searching: function () {

    //            return "Buscando..";
    //        },
    //        inputTooShort: function (e) {
    //            var falta = parseInt(e.minimum) - e.input.split("").length;
    //            return "Introduzca " + falta + " o más caracteres";
    //        }
    //    },
    //    ajax: {
    //        url: urlNormasSearch,
    //       // contentType: "application/json; charset=utf-8",
    //        type: "POST",
    //        dataType: "json",
    //        data: function (params) {               
    //            var query =
    //            {
    //                busqueda: params.term                    
    //            };
    //            return query;
    //        },
    //        processResults: function (result) {
    //            console.log("result="+result)
    //            return {
    //                results: $.map(result, function (item) {
    //                    return {
    //                        id: item.id,
    //                        text: item.clave,                          
    //                    };
    //                }),
    //            };
    //        }
    //    }
    //});
    
    //$('#comboNormaModal.normaSearchModal').on('select2:select', function (e) {
    //    LlenarDatosNormaModalSelect2(e);
    //});
    //a callback must be defined in the view that requires it
    //function LlenarDatosNormaModalSelect2(e) {
    //    var data = e.params.data;
    //    $('#idNormaModal').val(data.id);
    //    console.log("llenar" + data);
    //    cargaVistaRequisitosModal(data.id);
    //}

    

});
function InicializaRequisitosModal() {
    if ($('#tablaRequisitosModal').length > 0) {
        if ($.fn.DataTable.isDataTable('#tablaRequisitosModal')) {
            $('#tablaRequisitosModal').DataTable().destroy();
        }
        $('#tablaRequisitosModal').DataTable({
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