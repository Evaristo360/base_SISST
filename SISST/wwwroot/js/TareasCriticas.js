$(document).ready(function () {
    $("#IdTipoAccidente").select2({
        placeholder: {
            id: '', // the value of the option
            text: ' Selecione ... '
        },
        "language": {
            "noResults": function () {
                return "No se encotraron resultados";
            }
        },
        tags: false, width: '100%'
    });
});

function ImpactoProbabilidadRiesgo() {
    //alert("entré");
    $("#ImpactoPotencial").unbind("change");
    $("#ImpactoPotencial").bind("change", function () {
        ImpactoProbabilidadRiesgoCalcula();
    });
    $("#ProbabilidadPotencial").unbind("change");
    $("#ProbabilidadPotencial").bind("change", function () {
        ImpactoProbabilidadRiesgoCalcula();
    });

}
function ImpactoProbabilidadRiesgoCalcula() {

    var impacto = $("#ImpactoPotencial").val();
    var probabilidad = $("#ProbabilidadPotencial").val();
    var riesgo = $("#RiesgoPotencial");

    if (impacto == "55" && probabilidad == "58") {
        riesgo.val("3327").change();
    }
    else if (impacto == "55" && probabilidad == "59") {
        riesgo.val("3327").change();
    }
    else if (impacto == "55" && probabilidad == "60") {
        riesgo.val("3326").change();
    }
    else if (impacto == "56" && probabilidad == "58") {
        riesgo.val("3327").change();
    }
    else if (impacto == "56" && probabilidad == "59") {
        riesgo.val("3326").change();
    }
    else if (impacto == "56" && probabilidad == "60") {
        riesgo.val("3326").change();
    }
    else if (impacto == "57" && probabilidad == "58") {
        riesgo.val("3326").change();
    }
    else if (impacto == "57" && probabilidad == "59") {
        riesgo.val("3325").change();
    }
    else if (impacto == "57" && probabilidad == "60") {
        riesgo.val("3325").change();
    }
    else {
        riesgo.val("").change();
    }
}

function sendForm() {
    validateForm = true;
    var validationModel = $("#frmUpload").valid();
    //    var validationModel = $("#frmUpload").valid();
    if (!validationModel) {
        validateForm = false;
        $.LoadingOverlay("hide");
    } else {
        $("#frmUpload").submit();
        $.LoadingOverlay("show");
    }
}

function sendFormSugerencia() {
   // alert("entré a validar sug")
    validateForm = true;
    var validationModel = $("#frmSug").valid();
    //    var validationModel = $("#frmUpload").valid();
    if (!validationModel) {
        validateForm = false;
    } else {
        $("#frmSug").submit();
    }
}


var validateForm = false;
//Validation configuration
$.validator.setDefaults({
    ignore: '.trabajadorSearchVC',
    showErrors: function (errorMap, errorList) {
        //var message = "Se generaron " + this.numberOfInvalids() + " errores. Verificar los campos.";
        //var mensaje_dv = '<div id="errorAlert" class="alert alert-danger"><a class="close" data-dismiss="alert">×</a><span>' + message + '</span></div>';
        //if (this.numberOfInvalids() > 0) {
        //    $(".validation-summary-errors").html(mensaje_dv);
        //    timerRedMessage();
        //}
        //else {
        //    $(".validation-summary-errors").html("");
        //}
        //this.defaultShowErrors(); //uncomment to see all errors
        //alert("validateform "+validateForm);
        if (validateForm) {
            var message = "Se generaron " + this.numberOfInvalids() + " errores. Verificar los campos.";
            var mensaje_dv = '<div id="errorAlert" class="alert alert-danger"><a class="close" data-dismiss="alert">×</a><span>' + message + '</span></div>';

            if (this.numberOfInvalids() > 0) {
                $(".validation-summary-errors").html(mensaje_dv);
                timerRedMessage();
            }
            else {
                $(".validation-summary-errors").html("");
            }
            this.defaultShowErrors(); //uncomment to see all errors
        } else {
            this.defaultShowErrors(); //uncomment to see all errors
        }

    },
    highlight: function (element) {
        $(element).addClass('has-error');
    },
    unhighlight: function (element) {
        $(element).removeClass('has-error');
    },
});


function confirmaEliminar(idArchivo, filaIdHtml) {
    //alert("idArch: " + idArchivo);
    //alert("fila: " + filaIdHtml);
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

                    console.log("res2=" + resultado.correcto)
                    if (resultado.correcto == "true") {
                        $("#" + filaIdHtml).hide();
                        swal("Registro eliminado", "El registro ha sido eliminado exitosamente", "success");
                    }
                    else {

                        if (resultado.correcto == "false") {
                            swal("Registro no eliminado", "Ha fallado la eliminación del registro", "error");
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

        }
        /*-----*/
    });
}

function confirmaEliminarIM(idArchivo, filaIdHtml) {    
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
                url: urlEliminarArchivoIM,
                type: 'post',
                dataType: "json",
                async: false,
                data: { id: idArchivo },
                success: function (resultado) {

                    console.log("res2=" + resultado.correcto)
                    console.log("Fila=" + filaIdHtml)
                    if (resultado.correcto == "true") {
                        $("#" + filaIdHtml).hide();
                        swal("Registro eliminado", "El registro ha sido eliminado exitosamente", "success");
                    }
                    else {

                        if (resultado.correcto == "false") {
                            swal("Registro no eliminado", "Ha fallado la eliminación del registro", "error");
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

        }
        /*-----*/
    });
}

function confirmaEliminarSug(idSug, filaIdHtml) {    
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
                data: { id: idSug },
                success: function (resultado) {

                    console.log("res2=" + resultado.correcto)
                    console.log("Fila=" + filaIdHtml)
                    if (resultado.correcto == "true") {
                        $("#" + filaIdHtml).hide();
                        swal("Registro eliminado", "El registro ha sido eliminado exitosamente", "success");
                    }
                    else {

                        if (resultado.correcto == "false") {
                            swal("Registro no eliminado", "Ha fallado la eliminación del registro", "error");
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

        }
        /*-----*/
    });
}

function validaExisteSugerencia(IMR) {

    _IMR = IMR;




    /*_IdIP = IdIP;*/
    //$.ajax({
    //    type: "Get",
    //    url: validaSugerencia,
    //    data: { IMR: _IMR },
    //    success: function (data) {
    //        console.log(data);
    //        if (data.correcto == "false") {
    //            console.log("Subject:" + data);
    //            swal({
    //                title: "Ninguna Sugerencia ha sido registrada",
    //                text: "Para poder registrar la tarea, debe registrar al menos una sugerencia. \n ",
    //                icon: "warning",
    //                buttons: { cancel: { text: "Aceptar", value: null, visible: !0, className: "", closeModal: true } }

    //            })
    //        } else {

    //            swal({
    //                title: '¿Esta seguro de registrar la sugerencia?',
    //                text: "Se guardará la sugerencia. \n ",
    //                icon: "warning",
    //                buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, de acuerdo!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

    //            }).then(function (e) {
    //                if (e) {
    //                    var validationModel = $("#frmUpload").valid();
    //                    if (validationModel) {
    //                        $("#frmUpload").submit();
    //                    }

    //                }
    //                else {
    //                    swal("Registrar sugerencia", "La sugerencia no fue registrada.", "warning");
    //                }
    //                /*-----*/
    //            });

    //        }
    //    }
    //});
}

function validaDatosFormulario(etiqueta) {   
    validateForm = true;  
    var validationModel = $("#frmUpload").valid();
    //    var validationModel = $("#frmUpload").valid();
    if (!validationModel) {
        validateForm = false;
        $.LoadingOverlay("hide");
    } else {
        $("#frmUpload").submit();
        $.LoadingOverlay("show");
    }
            
}

function validaExisteActividad(Id, estatus) {
    //alert("entré a validar preocupación")
    _Id = Id;   
    $.ajax({
        type: "Get",
        url: '@Url.Action("validaExisteActividad", "TareasCriticas")',
        data: { Id: _Id },
        success: function (data) {
            //console.log(data.length);
            //console.log(data);
            //console.log($.isEmptyObject(data));
            if (data.correcto == "false") {
                console.log("Subject:" + data);
                swal({
                    title: "No ha sido registrada ninguna preocupación/peligro",
                    text: "Para poder enviar a revisión la identificación de peligro, debe registrar al menos una preocupación/peligro. \n ",
                    icon: "warning",
                    buttons: { cancel: { text: "Aceptar", value: null, visible: !0, className: "", closeModal: true } }

                })
            } else {

                swal({
                    title: '¿Esta seguro que desea cambiar de estado?',
                    text: "Al cambiar el estado ya no podrá hacer ninguna modificación. \n ",
                    icon: "warning",
                    buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, de acuerdo!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

                }).then(function (e) {
                    if (e) {
                        $.ajax({
                            url: '@Url.Action("CambiaEstadoActividad", "TareasCriticas")',
                            type: "Get",
                            dataType: "json",
                            async: false,
                            data: { status: estatus, Id: _Id },
                            success: function (resultado) {
                                if (resultado.correcto == "true") {
                                    swal("Cambio de estado", "El estado ha sido cambiado exitosamente.", "success").then(function () {                                                                                
                                        location.href = "@Url.Action('Index', 'IdenPeligros', new {})?";
                                    })
                                }
                                else {
                                    if (resultado.correcto == "false") {
                                        swal("Cambio de estado", "Ha fallado el cambio de estado.", "error");
                                    }
                                }
                            },
                            error: function (xhr, ajaxOptions, thrownError) {
                                if (thrownError == "Not Found")
                                    swal("Error al cambiar estado!", "No se ha encontrado el recurso.", "error");
                                else
                                    swal("Error al cambiar estado", "Ha ocurrido un error al cambiar el estado.", "error");
                            }
                        });//end ajax
                    }
                    else {

                    }
                    /*-----*/
                });

                /*$('#mdlEdoRevision').modal('show');*/
            }

        }
    })


}
