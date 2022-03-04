function confirmaEliminar(idArchivo, filaIdHtml) {
    swal({
        title: "Eliminar archivo",
        text: "Se eliminará el registro de forma definitiva. ¿Desea continuar? \n ",
        icon: "warning",
        buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, eliminarlo!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

    }).then(function (e) {
        if (e) {           
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


function deleteConfirmationPuntoNorma(id) {
    $.LoadingOverlay("hide");
    swal({
        title: "Eliminar requisito ["+id+"]",
        text: "Esta acción eliminará de forma permanente el requisito de la norma y no podrá recuperarse.\n¿Confirma que desea continuar?",
        icon: "warning",
        buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, eliminarlo!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

    }).then(function (e) {
        if (e) {
            $.LoadingOverlay("show");
            $('#frmDeleteLogic').submit();
        }
        else {
            swal.close();
        }

    });
    $.LoadingOverlay("hide");//$.unblockUI();
}

