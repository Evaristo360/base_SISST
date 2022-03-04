


//Validation configuration
$.validator.setDefaults({
    showErrors: function (errorMap, errorList) {
        $.LoadingOverlay("hide");
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
        $(element).addClass('is-invalid');
    },
    unhighlight: function (element) {
        $(element).removeClass('is-invalid');
    },
});

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