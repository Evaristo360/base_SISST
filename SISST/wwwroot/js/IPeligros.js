$(document).ready(function () {
           
   
    
    $("#IDC").select2({
        placeholder: {
            id: '', // the value of the option
            text: ' Selecione ... '
        },
        "language": {
            "noResults": function () {
                return "No se encotraron resultados";
            }
        },
        allowClear: true,
        tags: false, width: '100%'
    });  

    $("#IDDEPTO").select2({
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
        
    
    $("#IDCon").select2({
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
    $("#IDP").select2({
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
    $("#IDL").select2({
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


    $('#area').on('select2:select', function (e) {
        var data = e.params.data;
        $('#idDP').val(data.id);
        
        console.log(data);
    });

    



    var today = new Date();
    var mStartDate = new Date(today.getFullYear(), today.getMonth(), today.getDate() - 1);

    $('.date-picker').datepicker({
        todayBtn: false,
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

    $('#btnFechaElaboracion').click(function () {
        $('#FechaElaboracion').datepicker("show");
    });

    $('#btnFechaIngresoCFE').click(function () {
        $('#fechaIngresoCFE').datepicker("show");
    });

    $('#btnFechaIngresoPuesto').click(function () {
        $('#fechaIngresoPuesto').datepicker("show");
    });
});

function ImpactoProbabilidadRiesgo() {   
    ImpactoProbabilidadRiesgoCalcula();
    $("#IndiceImpacto").unbind("change");    
    $("#IndiceImpacto").bind("change", function () {        
        ImpactoProbabilidadRiesgoCalcula();
    });
    $("#IndiceProbabilidad").unbind("change");
    $("#IndiceProbabilidad").bind("change", function () {
        ImpactoProbabilidadRiesgoCalcula();
    });

}

function ImpactoProbabilidadRiesgoCalcula() {

    var impacto = $("#IndiceImpacto" ).val();
    var probabilidad = $("#IndiceProbabilidad").val();
    var riesgo = $("#nivelRiesgoList");
    var nivelRiesgo = $("#NivelRiesgo");

    if (impacto == "55" && probabilidad == "58") {
        riesgo.val("3327").change();
        nivelRiesgo.val("3327").change();
    }
    else if (impacto == "55" && probabilidad == "59") {
        riesgo.val("3327").change();
        nivelRiesgo.val("3327").change();
    }
    else if (impacto == "55" && probabilidad == "60") {
        riesgo.val("3326").change();
        nivelRiesgo.val("3326").change();
    }
    else if (impacto == "56" && probabilidad == "58") {
        riesgo.val("3327").change();
        nivelRiesgo.val("3327").change();
    }
    else if (impacto == "56" && probabilidad == "59") {
        riesgo.val("3326").change();
        nivelRiesgo.val("3326").change();
    }
    else if (impacto == "56" && probabilidad == "60") {
        riesgo.val("3326").change();
    }
    else if (impacto == "57" && probabilidad == "58") {
        riesgo.val("3326").change();
        nivelRiesgo.val("3326").change();
    }
    else if (impacto == "57" && probabilidad == "59") {
        riesgo.val("3325").change();
        nivelRiesgo.val("3325").change();
    }
    else if (impacto == "57" && probabilidad == "60") {
        riesgo.val("3325").change();
        nivelRiesgo.val("3325").change();
    }
    else {
        riesgo.val("").change();
    }
}

function ImpactoProbabilidadControlRiesgo() {    
    ImpactoProbabilidadControlRiesgoCalcula();
    $("#IndiceImpactoControles").unbind("change");
    $("#IndiceImpactoControles").bind("change", function () {        
        ImpactoProbabilidadControlRiesgoCalcula();
    });
    $("#IndiceProbabilidadControles").unbind("change");
    $("#IndiceProbabilidadControles").bind("change", function () {
        ImpactoProbabilidadControlRiesgoCalcula();
    });

}

function ImpactoProbabilidadControlRiesgoCalcula() {

    var impacto = $("#IndiceImpactoControles").val();
    var probabilidad = $("#IndiceProbabilidadControles").val();
    var riesgo = $("#riesgoResidualList");
    var riesgoResidual = $("#RiesgoResidual");
   

    if (impacto == "55" && probabilidad == "58") {
        riesgo.val("3327").change();
        riesgoResidual.val("3327").change();
    }
    else if (impacto == "55" && probabilidad == "59") {
        riesgo.val("3327").change();
        riesgoResidual.val("3327").change();
    }
    else if (impacto == "55" && probabilidad == "60") {
        riesgo.val("3326").change();
        riesgoResidual.val("3326").change();
    }
    else if (impacto == "56" && probabilidad == "58") {
        riesgo.val("3327").change();
        riesgoResidual.val("3327").change();
    }
    else if (impacto == "56" && probabilidad == "59") {
        riesgo.val("3326").change();
        riesgoResidual.val("3326").change();
    }
    else if (impacto == "56" && probabilidad == "60") {
        riesgo.val("3326").change();
        riesgoResidual.val("3326").change();
    }
    else if (impacto == "57" && probabilidad == "58") {
        riesgo.val("3326").change();
        riesgoResidual.val("3326").change();
    }
    else if (impacto == "57" && probabilidad == "59") {
        riesgo.val("3325").change();
        riesgoResidual.val("3325").change();
    }
    else if (impacto == "57" && probabilidad == "60") {
        riesgo.val("3325").change();
        riesgoResidual.val("3325").change();
    }
    else {
        riesgo.val("").change();
    }
}




function seleccionar(identificador, nombre) {
    //alert("entré: " + identificador + "-" + nombre);
    $('#idDP').val(identificador);
    var idHdf = $("#hdfSeleccionado").val();
    $("#" + idHdf).empty();
    var data = {
        id: identificador,
        text: nombre
    };
    var newOption = new Option(data.text, data.id, true, true);
    $("#" + idHdf).append(newOption).trigger('change');

    $('#mdlAreas').modal('toggle');
}

function SeleccionaTrabajador(nombre, apellidos, area, correo, rpe, idTrabajador) {
    
    $('#idRE').val(idTrabajador);
    var data = {
        id: idTrabajador,
        text: rpe + " " + nombre + " " + apellidos,
        nombre: nombre,
        apellidos: apellidos,
        correo: correo,
        area: area
    };

    var newOption = new Option(data.text, data.id, false, true);
    $('#txtRPE').append(newOption).trigger('change');

    $('#mdlTrabajadores').modal('toggle');
}


function SeleccionaCoordinador(nombre, apellidos, area, correo, rpe, idTrabajador) {
    //alert("entré");
    $('#idEGR').val(idTrabajador);
    var data = {
        id: idTrabajador,
        text: rpe + " " + nombre + " " + apellidos,
        nombre: nombre,
        apellidos: apellidos,
        correo: correo,
        area: area
    };

    var newOption = new Option(data.text, data.id, false, true);
    $('#txtEGR').append(newOption).trigger('change');

    $('#mdlTrabajadores').modal('toggle');
}


function confirmaEliminar(idArchivo, filaIdHtml) {    
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
                url: urlEliminarEGR,
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
   /* alert("entré a eliminar IM");*/
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

                    //console.log("res2=" + resultado.correcto)
                    //console.log("Fila=" + filaIdHtml)
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


function confirmaEliminarCtrl(idArchivo, filaIdHtml) {
    /* alert("entré a eliminar IM");*/
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

                    //console.log("res2=" + resultado.correcto)
                    //console.log("Fila=" + filaIdHtml)
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


function eliminarParticipante(id) {
    /*alert("entré a eliminar generico" + id+"--"+modelo);*/
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
                url: eliminarParticipante,
                type: 'post',
                dataType: "json",
                async: false,
                data: { id: idArchivo },
                success: function (resultado) {

                    //console.log("res2=" + resultado.correcto)
                    //console.log("Fila=" + filaIdHtml)
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

function validaExisteComponente(Id, IdIP, status) {    
    _Status = status;
    _Id = Id;
    _IdIP = IdIP;    
    
    $.ajax({
        type: "Get",
        url: validaComponente,
        data: { IdIPD: _IdIP },
        success: function (data) {
            //console.log(data.length);
            //console.log(data);            
            if (data == "null") {                
                swal({
                    title: "Ningun componente ha sido registrado",
                    text: "Para poder enviar a revisión la evaluación de riesgo grupal, debe registrar al menos un componente. \n ",
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
                            url: cambiaEstado,
                            type: "Get",
                            dataType: "json",
                            async: false,
                            data: { status: _Status, IdIP: _IdIP },
                            success: function (resultado) {
                                if (resultado.correcto == "true") {
                                    swal("Cambio de estado", "El estado ha sido cambiado exitosamente", "success").then(function () {

                                        //window.location.href = '@Url.Action("Index", "IdenPeligros", new { id = _IdIP })';
                                        location.href = index;
                                    })


                                }
                                else {

                                    if (resultado.correcto == "false") {
                                        swal("Cambio de estado", "Ha fallado el cambio de estado", "error");
                                    }

                                }
                            },
                            error: function (xhr, ajaxOptions, thrownError) {
                                if (thrownError == "Not Found")
                                    swal("Error al cambiar estado!", "No se ha encontrado el recurso", "error");
                                else
                                    swal("Error al cambiar estado", "Ha ocurrido un error al cambiar el estado", "error");
                            }
                        });//end ajax
                    }
                    else {
                       
                    }
                    /*-----*/
                });

            }
        }
    })
}

function validaExisteControle(IMR) {
        
    _IMR = IMR;
    /*_IdIP = IdIP;*/
    $.ajax({
        type: "Get",
        url: validaControl,
        data: { IMR: _IMR },
        success: function (data) {
            console.log(data);
            if (data.correcto == "false") {
                console.log("Subject:" + data);
                swal({
                    title: "Ningun control ha sido registrado",
                    text: "Para poder registrar el componente, debe registrar al menos un control. \n ",
                    icon: "warning",
                    buttons: { cancel: { text: "Aceptar", value: null, visible: !0, className: "", closeModal: true } }

                })
            } else {

                swal({
                    title: '¿Esta seguro de registrar el componente?',
                    text: "Se guardará el componente y sus controles correspondientes. \n ",
                    icon: "warning",
                    buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, de acuerdo!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

                }).then(function (e) {
                    if (e) {
                        $.ajax({
                            type: 'POST',
                            url: $(this).attr('action'),
                            enctype: 'multipart/form-data',
                            data: new FormData(this),
                            processData: false,
                            contentType: false,
                            success: function (data) {
                                //alert(data["id"]);
                                $("#btnGuardar").hide();
                                $.unblockUI();
                                swal("Cambio de estado", "El estado ha sido cambiado exitosamente", "success").then(function () {

                                        //window.location.href = '@Url.Action("Index", "IdenPeligros", new { id = _IdIP })';
                                        location.href = index;
                                    })

                            },
                            error: function (xhr, ajaxOptions, thrownError) {
                                if (thrownError == "Not Found")
                                    swal("Crear identificación de peligros", "No se ha encontrado el recurso", "error");
                                else
                                    swal("Crear identificación de peligros", "Ha ocurrido un error al intentar agregar un nuevo registro", "error");
                                $.unblockUI();
                            }
                        }
                        );
                    }
                    else {
                        
                    }
                    /*-----*/
                });

            }
        }
        });
}

function sendForm() {    
    validateForm = true;
    var validationModel = $("#frmUpload").valid();
    //    var validationModel = $("#frmUpload").valid();
    if (!validationModel) {
        validateForm = false;
    } else {
        $("#frmUpload").submit();
    }
}

var validateForm = false;
//Validation configuration
$.validator.setDefaults({
    ignore: '.trabajadorSearchVC',
    showErrors: function (errorMap, errorList) {        
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



