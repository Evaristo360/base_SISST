var validateForm = false;
$(document).ready(function () {

    function FillTrabajadorResponsableF13(data) {
        var id = data.id;       
        var nombre = data.text;        
        console.log("nombre=" + nombre)
        //asignar valores a los campos
        $('#idRE').val(id);        
        $('#txtNombre').val("");
        $('#txtNombre').val(nombre);
    }
    function FillTrabajadorElaboraF13(data) {
        var id = data.id;
        var nombre = data.text;
        console.log("nombre=" + nombre)
        //asignar valores a los campos
        $('#idUE').val(id);
        $('#txtNombreUE').val("");
        $('#txtNombreUE').val(nombre);
    }

    $('#comboIdUsuarioResponsableEjecucion.trabajadorSearch').on('select2:select', function (e) {
        var trabajadorCallback = FillTrabajadorResponsableF13;
        LlenarDatosTrabajadorSelect2(e, true, trabajadorCallback);
    });

    $('#comboUE.trabajadorSearchUE').on('select2:select', function (e) {
        var trabajadorCallback = FillTrabajadorElaboraF13;
        LlenarDatosTrabajadorSelect2(e, true, trabajadorCallback);
    });

   


});


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
                    
                    console.log("res2=" + resultado.correcto)
                    if (resultado.correcto == "true") {                      
                        $("#" + filaIdHtml).hide();
                        swal("Eliminar archivo", "El archivo ha sido eliminado exitosamente", "success");   
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
                        swal("Eliminar archivo", "El archivo ha sido eliminado exitosamente", "success");
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


function sendForm() {
    validateForm = true;
    var validationModel = $("#frmUpload").valid();
    if (!validationModel) {
        validateForm = false;
    } else {
        $("#frmUpload").submit();
    }
}

function quitRedMessage() {
    console.log("Ejecuta fucnion del tmer")
    $(".validation-summary-errors").html("");
}

var timer;
function timerRedMessage() {
    console.log("Entra ala funcion");
    clearTimeout(timer);
    console.log("Limpia timer");
    setTimeout(quitRedMessage, 3000);
}

//Validation configuration
$.validator.setDefaults({
    ignore: '.trabajadorSearchVC',
    showErrors: function (errorMap, errorList) {
        console.log(errorMap, errorList)
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

function getNivelRiesgo() {
    var impacto = $("#Impacto").children("option:selected").text();
    var probabilidad = $("#Probabilidad").children("option:selected").text();
    var res = "";
    if (impacto == "Alto" && probabilidad == "Alto")
        res = "Alto";
    else if (impacto == "Alto" && probabilidad == "Medio")
        res = "Alto";
    else if (impacto == "Medio" && probabilidad == "Alto")
        res = "Alto";
    else if (impacto == "Alto" && probabilidad == "Bajo")
        res = "Medio";
    else if (impacto == "Medio" && probabilidad == "Bajo")
        res = "Medio";
    else if (impacto == "Medio" && probabilidad == "Medio")
        res = "Medio";
    else if (impacto == "Bajo" && probabilidad == "Alto")
        res = "Medio";
    else if (impacto == "Bajo" && probabilidad == "Bajo")
        res = "Bajo";
    else if (impacto == "Bajo" && probabilidad == "Medio")
        res = "Bajo";
    else res = "";

    $('#NivelRiesgo').val(res);
    $('#NivelRiesgoTMP').val(res);
}