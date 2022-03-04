var validateForm = false;

$(document).ready(function () {
    $(".trabajadorSearchMet").select2({
        minimumInputLength: 4,
        placeholder: "Escribe el RPE/Nombre del trabajador a buscar",
        language: {
            noResults: function () {

                return "No hay resultado";
            },
            errorLoading: function () {
                return "No se pudo realizar la consulta";
            },
            loadingMore: function () {
                return 'Cargando más resultados...';
            },
            searching: function () {

                return "Buscando..";
            },
            inputTooShort: function (e) {
                var falta = parseInt(e.minimum) - e.input.split("").length;
                return "Introduzca " + falta + " o más caracteres";
            }
        },
        ajax: {
            url: urlUsuariosSearch,
            type: "POST",
            dataType: "json",
            data: function (params) {
                var query =
                {
                    search: params.term
                };
                console.log(query)
                return query;
            },
            processResults: function (result) {
                console.log('info recibida');
                //console.log(result);
                return {
                    results: $.map(result, function (item) {
                        console.log(item)
                        return {
                            id: item.idTrabajador,
                            rpe: item.rpe,
                            text: item.rpe + ' - ' + item.nombre + ' ' + item.apellidos ,
                            nombre: item.nombre,
                            apellidos: item.apellidos,
                            correo: item.correoElectronico,
                            //area: item.area,
                            //activo: item.activo
                        };
                    })
                };
            }
        }
    });

    $(".trabajadorSearchUE").select2({
        minimumInputLength: 4,
        placeholder: "Escribe el RPE/Nombre del trabajador a buscar",
        language: {
            noResults: function () {

                return "No hay resultado";
            },
            errorLoading: function () {
                return "No se pudo realizar la consulta";
            },
            loadingMore: function () {
                return 'Cargando más resultados...';
            },
            searching: function () {

                return "Buscando..";
            },
            inputTooShort: function (e) {
                var falta = parseInt(e.minimum) - e.input.split("").length;
                return "Introduzca " + falta + " o más caracteres";
            }
        },
        ajax: {
            url: urlTrabajadoresSearch,
            type: "POST",
            dataType: "json",
            data: function (params) {
                //console.log(params)
                var page = params.page || 1;
                var tam = 10;
                var skip = page == 1 ? 0 : (page - 1) * tam;
                var query =
                {
                    search: { Value: params.term },
                    draw: page,
                    length: tam,
                    start: skip,
                };
                return query;
            },
            processResults: function (result) {
                console.log('info recibida');
                //console.log(result);
                return {
                    results: $.map(result.data, function (item) {
                        return {
                            id: item.id,
                            rpe: item.rpe,
                            text: item.rpe + ' - ' + item.nombreCompleto,
                            nombre: item.nombre,
                            apellidos: item.apellidos,
                            correo: item.correoElectronico,
                            area: item.area,
                            activo: item.activo
                        };
                    }),
                    pagination: {
                        more: result.recordsFiltered < result.recordsTotal
                    }
                };
            }
        }
    });

    $("#areaSearch").select2({
        minimumInputLength: 1,
        placeholder: "Escribe el nombre o clave del centro de trabajo a buscar",
        language: {
            noResults: function () {

                return "No hay resultado";
            },
            errorLoading: function () {
                return "No se pudo realizar la consulta";
            },
            loadingMore: function () {
                return 'Cargando más resultados...';
            },
            searching: function () {

                return "Buscando..";
            },
            inputTooShort: function (e) {
                return "Escribe el nombre o clave del centro de trabajo a buscar";
            }
        },
        ajax: {
            url: urlAreaSearch,
            contentType: "application/json; charset=utf-8",
            data: function (params) {
                var idProceso = 0;
                var query =
                {
                    busqueda: params.term,
                    id: idProceso
                };
                return query;
            },
            processResults: function (result) {
                return {
                    results: $.map(result, function (item) {
                        return {
                            id: item.id,
                            text: item.claveNombre
                        };
                    }),
                };
            }
        }
    });

    $('#comboIdResponsable.trabajadorSearchMet').on('select2:select', function (e) {
        var trabajadorCallback = FillResponsable;
        LlenarDatosTrabajadorSelect2(e, true, trabajadorCallback);
    });

    $('#comboIdUsuarioEnlace.trabajadorSearchUE').on('select2:select', function (e) {
        var trabajadorCallback = FillUsuarioEnlace;
        LlenarDatosTrabajadorSelect2(e, true, trabajadorCallback);
    });
});

function FillResponsable(data) {
    var id = data.id;
    var nombre = data.text;
    //asignar valores a los campos
    $('#idResponsable').val(id);
}

function FillUsuarioEnlace(data) {
    var id = data.id;
    var correo = data.correo;
    console.log(data)
    //asignar valores a los campos
    $('#idUsuarioEnlace').val(id);
    if (correo != null) {
        $('#correo').val(correo);
    } else {
        $('#correo').val('');
    }
}

//----------------------COPY FRONT TRABAJADORESSEARCH
//a callback must be defined in the view that requires it, see IncidenteConLesionCreate.cshtml, Scripts section
function LlenarDatosTrabajadorSelect2(e, NombreApellidoJunto = true, trabajadorCallback = null) {

    var data = e.params.data;
    if (NombreApellidoJunto) {
        $('.modalTxtNombre').val(data.nombre + " " + data.apellidos);
    }
    else {
        $('.modalTxtNombre').val(data.nombre);
        $('.modalTxtApellidos').val(data.apellidos);
    }
    $('.modalTxtId').val(data.id);
    $('.modalTxtArea').val(data.area);
    $('.modalTxtCorreo').val(data.correo);
    $('.modalHdfRPE').val(data.text);
    //console.log(data);

    if (trabajadorCallback != null) {
        trabajadorCallback(data);
    }
}
function SeleccionaTrabajadorVC(t, modal, NombreApellidoJunto = true) {
    //if no callback, then standard process
    if (NombreApellidoJunto) {
        $('.modalTxtNombre').val(t.nombreCompleto);
    }
    else {
        $('.modalTxtNombre').val(t.nombre);
        $('.modalTxtApellidos').val(t.apellidos);
    }
    $('.modalTxtId').val(t.id);
    $('.modalTxtArea').val(t.area);
    $('.modalTxtCorreo').val(t.correoElectronico);
    $('.modalHdfRPE').val(t.rpe);
    var data = {
        id: t.id,
        text: t.rpe + " - " + t.nombreCompleto,
        nombre: t.nombre,
        apellidos: t.apellidos,
        correo: t.correoElectronico,
        area: t.area
    };

    var newOption = new Option(data.text, data.id, false, true);
    $('#txtRPE').append(newOption).trigger('change');

    if (modal) {
        $('#trabajadoresModal').modal('toggle');
    }
}
//-------------------
function sendForm() {
    validateForm = true;
    var validationModel = $("#frmServicio").valid();
    if (!validationModel) {
        validateForm = false;
    } else {
        $("#frmServicio").submit();
    }
}

function sendFormAvanzarEnProceso() {
    $("#sendFormAvanzarEnProceso").submit();
}


function sendFormAddEstudio() {
    $("#frmAddArchivoEstudio").submit();
}

function sendFormCloseServicio() {
    $("#frmCloseServicio").submit();
}

function sendFormCancelarServicio() {
    $("#sendFormCancelarServicio").submit();
}

function sendReenviarEncuesta() {
    $("#frmReenviar").submit();
}

function quitRedMessage() {
    console.log("Ejecuta fucnion del tmer")
    $(".validation-summary-errors").html("");
}

jQuery.extend(jQuery.validator.messages, {
    required: "Campo requerido",
    number: "Por favor, ingrese un número válido.",
    rangelength: jQuery.validator.format("Por favor ingrese un valor de tamaño entre {0} y {1}."),
    range: jQuery.validator.format("Por favor ingrese un valor entre {0} y {1}."),
    maxlength: jQuery.validator.format("Por favor ingrese máximo {0} caracteres."),
    minlength: jQuery.validator.format("Por favor ingrese mínimo {0} caracteres"),
    max: jQuery.validator.format("Por favor ingrese un valor menor o igual a {0}."),
    min: jQuery.validator.format("Por favor ingrese un valor mayor o igual a {0}.")
});

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