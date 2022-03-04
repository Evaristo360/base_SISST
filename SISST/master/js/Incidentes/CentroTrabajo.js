/*
 * 
 * Centro Trabajo Tab
 * 
 * */

function HideTurnos() {
    $('#NumeroTrabajadoresTurno1').val('');//.hide(); //show it by default
    $('#NumeroTrabajadoresTurno2').val('').hide();
    $('#NumeroTrabajadoresTurno3').val('').hide();
}
function ShowTurnosGivenList() {
    $('#NumeroTurnos').bind('change', function () {
        var numTurnos = $('#NumeroTurnos').val();
        $('#NumeroTrabajadoresTurno1').show();

        if (numTurnos == 2) {
            $('#NumeroTrabajadoresTurno2').show();
            $('#NumeroTrabajadoresTurno3').val('').hide();
        }
        else if (numTurnos == 3) {
            $('#NumeroTrabajadoresTurno2').show();
            $('#NumeroTrabajadoresTurno3').show();
        }
        else {
            $('#NumeroTrabajadoresTurno2').val('').hide();
            $('#NumeroTrabajadoresTurno3').val('').hide();
        }
    });

}

function ShowTurnosGivenListUpdate() {

    var numTurnos = $('#NumeroTurnos').val();
    $('#NumeroTrabajadoresTurno1').show();

    if (numTurnos == 2) {
        $('#NumeroTrabajadoresTurno2').show();
        $('#NumeroTrabajadoresTurno3').val('').hide();
    }
    else if (numTurnos == 3) {
        $('#NumeroTrabajadoresTurno2').show();
        $('#NumeroTrabajadoresTurno3').show();
    }
    else {
        $('#NumeroTrabajadoresTurno2').val('').hide();
        $('#NumeroTrabajadoresTurno3').val('').hide();
    }


}


function ValidateInputsNumeroTrabajadoresPorTurno() {

    var turnos = $('#NumeroTurnos').val();
    if (turnos == 0) {
        $('#NumeroTrabajadoresTurno1').addClass("ignoreValidation");
        $('#NumeroTrabajadoresTurno2').addClass("ignoreValidation");
        $('#NumeroTrabajadoresTurno3').addClass("ignoreValidation");
    }
    else if (turnos == 1) {
        $('#NumeroTrabajadoresTurno1').removeClass("ignoreValidation");
        $('#NumeroTrabajadoresTurno2').addClass("ignoreValidation");
        $('#NumeroTrabajadoresTurno3').addClass("ignoreValidation");
    }
    else if (turnos == 2) {
        $('#NumeroTrabajadoresTurno1').removeClass("ignoreValidation");
        $('#NumeroTrabajadoresTurno2').removeClass("ignoreValidation");
        $('#NumeroTrabajadoresTurno3').addClass("ignoreValidation");
    }
    else if (turnos >= 3) {
        $('#NumeroTrabajadoresTurno1').removeClass("ignoreValidation");
        $('#NumeroTrabajadoresTurno2').removeClass("ignoreValidation");
        $('#NumeroTrabajadoresTurno3').removeClass("ignoreValidation");
    }
}