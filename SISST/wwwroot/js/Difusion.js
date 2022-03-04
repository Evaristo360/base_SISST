var validateForm = false;
var listaTrabajadoresSeleccionados = [];
$(document).ready(function () {
    $('#comboIdCoordinador.trabajadorSearchCoord').on('select2:select', function (e) {
        var trabajadorCallback = FillCoordinador;
        LlenarDatosTrabajadorSelect2(e, true, trabajadorCallback);
    });

    $('#comboIdVoBo.trabajadorSearchVoBo').on('select2:select', function (e) {
        var trabajadorCallback = FillVoBo;
        LlenarDatosTrabajadorSelect2(e, true, trabajadorCallback);
    });

    $('#comboIdRevisor.trabajadorSearchRevisor').on('select2:select', function (e) {
        var trabajadorCallback = FillRevisor;
        LlenarDatosTrabajadorSelect2(e, true, trabajadorCallback);
    });

   
    $('#allTrabajadores tbody').on('click', 'tr', function () {
        var trabajadorData = tableAllTrabajadores.row(this).data();

        if (listaTrabajadoresSeleccionados.find(id => id == trabajadorData.id)){
            swal({
                icon: 'warning',
                title: "Agregar participante",
                text: "El participante ya ha sido agregado.",
                buttons: { cancel: { text: "", value: null, visible: false, className: "", closeModal: true }, confirm: { text: "Aceptar", value: true, visible: true, className: "btn btn_sistema", closeModal: true } }
            });
        } else {

            tableSelectedTrabajadores.row.add([
                trabajadorData.rpe,
                trabajadorData.nombreCompleto,
                `<button type="button" title="Eliminar"  data-rowId="${trabajadorData.id}" class="btn btn-link removeParticipante" style='font-size: 16px; color:red;'><i class="fas fa-minus-circle"></i></button>`
            ]).draw(false);

            listaTrabajadoresSeleccionados.push(parseInt(trabajadorData.id));
        }
    });
    $('#selectedTrabajadores').on('click', 'button.removeParticipante', function () {

        var idTrabajador = $(this).attr('data-rowId');
        var i = listaTrabajadoresSeleccionados.indexOf(parseInt(idTrabajador));


        console.log(i, idTrabajador,listaTrabajadoresSeleccionados)
        listaTrabajadoresSeleccionados.splice(i, 1);

        console.log(listaTrabajadoresSeleccionados)
        tableSelectedTrabajadores
            .row($(this).parents('tr'))
            .remove()
            .draw();
    });

    $('#allTrabajadores_filter input').unbind();
    $('#allTrabajadores_filter input').bind('keyup', function (e) {
        if (e.keyCode == 13) {
            tableAllTrabajadores.search(this.value).draw();
        }
    });

    if (document.getElementsByClassName("dt-buttons").length > 0) {
        divButtonss = document.getElementsByClassName("dt-buttons");
        divButtonss[0].style.cssFloat = "right";
    }
});

function FillCoordinador(data) {
    var id = data.id;
    var nombre = data.text;
    //asignar valores a los campos
    $('#idCoordinador').val(id);
    $('#nombreCoordinador').val(nombre);
}

function FillVoBo(data) {
    var id = data.id;
    var nombre = data.text;
    //asignar valores a los campos
    $('#idVoBo').val(id);
    $('#nombreVoBo').val(nombre);
}

function FillRevisor(data) {
    var id = data.id;
    var nombre = data.text;
    //asignar valores a los campos
    $('#idRevisor').val(id);
    $('#nombreRevisor').val(nombre);
}

function sendForm() {
    validateForm = true;
    var validationModel = $("#frmReunion").valid();
    if (!validationModel) {
        validateForm = false;
    } else {
        listaTrabajadoresSeleccionados.map((id) => {
            let inputHidden = `<input type = "hidden" name = "participantes" value = "${id}" ></ input >`;
            $('#frmReunion').append(inputHidden);
        });
        $("#frmReunion").submit();
    }
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