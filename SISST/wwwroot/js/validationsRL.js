let validateForm = false;

function sendForm(formulario = "#frmRL") {
    validateForm = true;
    var validationModel = $(formulario).valid();
    console.log(validationModel)
    if (!validationModel) {
        validateForm = false;
    } else {
        $(formulario).submit();
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