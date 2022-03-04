$(document).ready(function () {


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
});


//-------------------
function sendForm() {
    //alert("entré e mandar fomrulario");
    validateForm = true;
    var validationModel = $("#frmSimulacro").valid();
    if (!validationModel) {
        validateForm = false;
    } else {
        $("#frmSimulacro").submit();
    }
}

function quitRedMessage() {
    //console.log("Ejecuta fucnion del tmer")
    $(".validation-summary-errors").html("");
}

var timer;
function timerRedMessage() {
    //console.log("Entra ala funcion");
    clearTimeout(timer);
    //console.log("Limpia timer");
    setTimeout(quitRedMessage, 3000);
}

var validateForm = false;

//Validation configuration
$.validator.setDefaults({
    ignore: '.trabajadorSearchVC',
    showErrors: function (errorMap, errorList) {
       // console.log(errorMap, errorList)
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