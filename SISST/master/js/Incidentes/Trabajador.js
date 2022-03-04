/*
 *
 * Datos Trabajador Tab
 *
 * */

//BuscadorTrabajadoresRPE , Trabajadores Tab -> callback functions
function GetFullTrabajadorByRPE(data) {
    if (urlGetTrabajadoresByRPE.length == 0) {
        throw "La URL de GetTrabajadoresByRPE no está definida en los scripts."
    }

    var urlAction = urlGetTrabajadoresByRPE + "?rpe=" + data.rpe;
    $.ajax({
        type: 'GET',
        url: urlAction,
        dataType: 'json',
        success: function (dataTrabajador) {
            AssignTrabajadorData(dataTrabajador);
        }
    });
}

//BuscadorTrabajadoresRPE , Trabajadores Tab -> callback functions FOR INCIDENTES SIN LESION
function GetFullTrabajadorByRPESinLesion(data) {
    if (urlGetTrabajadoresByRPE.length == 0) {
        throw "La URL de GetTrabajadoresByRPE no está definida en los scripts."
    }

    var urlAction = urlGetTrabajadoresByRPE + "?rpe=" + data.rpe;
    $.ajax({
        type: 'GET',
        url: urlAction,
        dataType: 'json',
        success: function (dataTrabajador) {
            AssignTrabajadorDataSinLesion(dataTrabajador);
        }
    });
}

//callback function 
function AssignTrabajadorData(data) {
    if (dateMinValue.length == 0) {
        throw "El valor de fecha mínima (DateMinValue) no está definida."
    }

    console.log('data.fechaIngresoPuestoActual');
    document.getElementById('IdTrabajador').value = data.id;
    document.getElementById('RPE').value = data.rpe;
    document.getElementById('NombreCompleto').value = data.nombreCompleto;
    document.getElementById('AfiliacionIMSS').value = data.afiliacionIMSS;

    console.log(data.FechaNacimiento);
    var fechaNacimiento = moment(data.fechaNacimiento, "YYYY-MM-DDThh:mm:ss").format("DD/MM/YYYY");
    document.getElementById('Edad').value = (fechaNacimiento == dateMinValue) ? 0 : CalcularEdad(data.fechaNacimiento);

    $('#Genero').val(data.sexo);
    $('#IdDepartamento').val(data.idArea).trigger('change');;
    $('#IdTipoContrato').val(data.idContrato);

    //FechaIngresoPuesto
    var fechaIngresoPuestoData = moment(data.fechaIngresoPuestoActual, "YYYY-MM-DDThh:mm:ss").format("DD/MM/YYYY");
    if (fechaIngresoPuestoData == dateMinValue) {
        $('#FechaIngresoPuesto').val('');
    }
    else {
        $('#FechaIngresoPuesto').val(fechaIngresoPuestoData);
        CalcularAntiguedadPuesto();
    }

    //FechaIngresoCT
    var fechaIngresoCTData = moment(data.fechaIngresoCFE, "YYYY-MM-DDThh:mm:ss").format("DD/MM/YYYY");
    if (fechaIngresoCTData == dateMinValue) {
        if (fechaIngresoPuestoData == dateMinValue) {
            $('#FechaIngresoCT').val('');
        } else {
            $('#FechaIngresoCT').val(fechaIngresoPuestoData);
            CalcularAntiguedadCT();
        }
    }
    else {
        $('#FechaIngresoCT').val(fechaIngresoCTData);
        CalcularAntiguedadCT();
    }

    var salario = data.salarioDiarioActual;
    document.getElementById('SalarioDiarioTabulado').value = (salario > 0) ? salario : 0;
}

//callback function 
function AssignTrabajadorDataSinLesion(data) {
    if (dateMinValue.length == 0) {
        throw "El valor de fecha mínima (DateMinValue) no está definida."
    }

    console.log('data.fechaIngresoPuestoActual');
    document.getElementById('IdTrabajador').value = data.id;
    document.getElementById('RPE').value = data.rpe;
    document.getElementById('NombreCompleto').value = data.nombreCompleto;
    //document.getElementById('AfiliacionIMSS').value = data.afiliacionIMSS;

    console.log(data.FechaNacimiento);
    //var fechaNacimiento = moment(data.fechaNacimiento, "YYYY-MM-DDThh:mm:ss").format("DD/MM/YYYY");
    //document.getElementById('Edad').value = (fechaNacimiento == dateMinValue) ? 0 : CalcularEdad(data.fechaNacimiento);

    //$('#Genero').val(data.sexo);
    console.log(data.idArea);
    //$('#IdDepartamento').val(data.idArea).trigger('change');;
    //$('#IdTipoContrato').val(data.idContrato);

    //FechaIngresoPuesto
    //var fechaIngresoPuestoData = moment(data.fechaIngresoPuestoActual, "YYYY-MM-DDThh:mm:ss").format("DD/MM/YYYY");
    //if (fechaIngresoPuestoData == dateMinValue) {
    //    $('#FechaIngresoPuesto').val('');
    //}
    //else {
    //    $('#FechaIngresoPuesto').val(fechaIngresoPuestoData);
    //    CalcularAntiguedadPuesto();
    //}

    ////FechaIngresoCT
    //var fechaIngresoCTData = moment(data.fechaIngresoCFE, "YYYY-MM-DDThh:mm:ss").format("DD/MM/YYYY");
    //if (fechaIngresoCTData == dateMinValue) {
    //    $('#FechaIngresoCT').val('');
    //}
    //else {
    //    $('#FechaIngresoCT').val(fechaIngresoCTData);
    //    CalcularAntiguedadCT();
    //}

    //document.getElementById('SalarioDiarioTabulado').value = data.salarioDiarioActual;
}

//miscelaneous functions
function CalcularAntiguedadPuesto() {
    console.log("entra a la funcion")
    var strDate = $('#FechaIngresoPuesto').val();

    var diffDuration = CalculateTimeDiff(strDate);
    if (diffDuration == "") return;
    var years = diffDuration.years();
    var months = diffDuration.months();
    var days = diffDuration.days();

    $('#AntiguedadPuesto').val(years + " años y " + months + " meses.");
    //hidden inputs
    $('#AntiguedadPuestoAnios').val(years);
    $('#AntiguedadPuestoMeses').val(months);
    $('#AntiguedadPuestoDias').val(days);
}
function CalcularAntiguedadCT() {
    var strDate = $('#FechaIngresoCT').val();

    var diffDuration = CalculateTimeDiff(strDate);
    if (diffDuration == "") return;
    var years = diffDuration.years();
    var months = diffDuration.months();
    var days = diffDuration.days();

    $('#AntiguedadCT').val(years + " años y " + months + " meses.");
    //hidden inputs
    $('#AntiguedadCTAnios').val(years);
    $('#AntiguedadCTMeses').val(months);
    $('#AntiguedadCTDias').val(days);
}
