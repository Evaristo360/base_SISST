function Agregar() {
    if ($("#txtRegistroPatronal").val() != "") {
        $.LoadingOverlay("show");
        $("#registroPatronal").val($("#txtRegistroPatronal").val());
        $('#frmCreate').submit();
    }
}

function AgregarCT() {
    if ($("#idCT").val() != "") {
        $.LoadingOverlay("show");
        $('#frmCrearRelacion').submit();
    }
}

$(document).ready(function () {
    $("#btnAceptar").click(function () {

        var tableCT = $('#centrosTrabajo').dataTable();
        var rowsCT = tableCT._fnGetDataMaster();
        $('#centrosTrabajo').DataTable().search("");

        console.log({ rowsCT })
        for (var i = 0; i < rowsCT.length; i++) {

            $('#centrosTrabajo').DataTable().search("");
            var id = rowsCT[i][0];
            $('#centrosTrabajo').DataTable().search("").draw();
            if ($("#ct_" + id).is(':checked')) {
                var idPrivilegio = id;
                if ($("#ct_" + id).attr('disabled') != "disabled") {
                    var str = '<input type="hidden" name="listaCentrosSelected" value="' + idPrivilegio + '" />';
                    $("#divCTsSeleccionados").append(str);
                }
            }
            $('#centrosTrabajo').DataTable().search("");
        }

        var numberOfChecked = $('.check:checked').length;
        console.log(numberOfChecked)
        $("#nCTs").val(numberOfChecked);
        validateForm = true;
        var validationModel = $("#frmRL").valid();
        if (!validationModel) {
            validateForm = false;
        } else {
            $("#frmRL").submit();
        }

    });

    $("#selecTodosCT").click(function () {
        $('#centrosTrabajo').LoadingOverlay("show");
        rows = $('#centrosTrabajo').DataTable().rows({ search: 'applied' }).data();
        for (var i = 0; i < rows.length; i++) {
            $('#centrosTrabajo').DataTable().column(0).search("^" + rows[i][0] + "$", true, false).draw();
            if ($("#ct_" + rows[i][0]).attr("disabled") != "disabled") {
                $("#ct_" + rows[i][0]).prop("checked", true);
                $("#ct_" + rows[i][0]).attr("checked", "checked");
            }
        }
        $('#centrosTrabajo').DataTable().column(0).search("").draw();
        $('#centrosTrabajo').LoadingOverlay("hide");
    });

    $("#deSelecTodosCT").click(function () {
        $('#centrosTrabajo').LoadingOverlay("show");
        rows = $('#centrosTrabajo').DataTable().rows({ search: 'applied' }).data();
        for (var i = 0; i < rows.length; i++) {
            $('#centrosTrabajo').DataTable().column(0).search("^" + rows[i][0] + "$", true, false).draw();
            if ($("#ct_" + rows[i][0]).attr("disabled") != "disabled") {
                $("#ct_" + rows[i][0]).prop("checked", false);
            }
        }
        $('#centrosTrabajo').DataTable().column(0).search("").draw();
        $('#centrosTrabajo').LoadingOverlay("hide");
    });
});

$.validator.addMethod("validaCTs", function (value, element) {
    try {
        if (value > 0) {
            return true;
        }
        else {
            return false
        };
    }
    catch (err) {
        return false;
    }
}, "Seleccionar al menos un centro de trabajo.");

function showError(element, message) {
    $(`span[data-valmsg-for="${element}"`).html(`${message}`);
    $(`span[data-valmsg-for="${element}"`).addClass('field-validation-error');
}
function showProps(obj) {
    for (var i in obj) {
        // obj.hasOwnProperty() se usa para filtrar propiedades de la cadena de prototipos del objeto
        if (obj.hasOwnProperty(i)) {
            showError(i, obj[i])
        }
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
    showErrors: function (errorMap, errorList) {
        console.log(errorMap)
        showProps(errorMap);
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