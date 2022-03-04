// Modal for deleteConfirmationNorma
function deleteConfirmationNorma(id) {
    $.LoadingOverlay("hide");
    swal({
        title: "Eliminar norma ["+id+"]",
        text: "Esta acción eliminará de forma permanente el registro de la norma con sus posibles dependientes (requisitos de la norma y archivos de documentos oficiales), por lo que será imposible su recuperación.\n¿Confirma que desea continuar?",
        icon: "warning",
        buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, eliminarlo!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

    }).then(function (e) {
        if (e) {
            $.LoadingOverlay("show");//$('.sweet-alert').block({ message: "Por favor espere..." });
            $('#frmDelete').submit();
        }
        else {
            swal.close();
        }
    });
    $.LoadingOverlay("hide");//$.unblockUI();
}

function deleteLogicConfirmationNorma()
{
    $.LoadingOverlay("hide");//$.unblockUI();

    swal({
        title: "Eliminado lógico",
        text: "Esta acción eliminará de forma lógica el registro de la norma y no podrá utilizarla en los distintos procesos del sistema.",
        icon: "warning",
        buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, eliminarlo!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

    }).then(function (e) {
        if (e) {
            $.LoadingOverlay("show");//$('.sweet-alert').block({ message: "Por favor espere..." });
            $('#frmDeleteLogic').submit();
        }
        else {
            swal.close();
        }

    });
    $.LoadingOverlay("hide");//$.unblockUI();
}

function undoDeleteLogicConfirmationNorma() {
    $.LoadingOverlay("hide");//$.unblockUI();
    swal({
        title: "Revertir eliminado lógico",
        text: "Esta acción revertirá la eliminación lógica de la norma y sus puntos dependientes. No restaurará asociaciones previas a cuestionarios y/o expedientes de cumplimiento.",
        icon: "warning",
        buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, revertir!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

    }).then(function (e) {
        if (e) {
            $.LoadingOverlay("show");
            $('#frmUndoDeleteLogic').submit();
        }
        else {
            swal.close();
        }
    });
    $.LoadingOverlay("hide");//$.unblockUI();
}

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
        /*-----*/
    });
}

$(document).ready(function () {
    var today = new Date();
    var mStartDate = new Date(today.getFullYear(), today.getMonth(), today.getDate());

    $('.date-picker').datepicker({
        todayBtn: true,
        defaultDate: mStartDate,
        format: "dd/mm/yyyy",
        starView: "days",
        minViewMode: "days",
        endDate: mStartDate
    }).on("hide", function (e) {
        var date_check = $(this).datepicker("getDate");
        var true_false_date = moment(date_check).isValid();
        if (true_false_date == false) {
            $(this).datepicker('setDate', $('#from_date_hidden').val());
        }
        $('#from_date_hidden').val(moment($(this).datepicker("getDate")).format("DD/MM/YYYY"));
    });

    $('#FechaPublicacion').datepicker();
});