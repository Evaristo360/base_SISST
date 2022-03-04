/* 
 * correccionesSST
 * Funciones para la manipulación de los objetos DOM de la UI para 
 * la edición de nuevas Correcciones SST (Formato 13)
 * 
 * Desarrollado por
 *  Juan Miguel González Castro
 *  Enero 2022
 * 
 * */

/* Modal trigger */

showInPopup = (ventana, trId, titulo) => {

    if (ventana == "Agregar") {
        $("#modalCorrecciones .modal-title").html(titulo);

        // limpiar objetos
        $("#ordenTrabajo").val("");
        $("#listaNivelAtencion").val("");
        $("#identificacion").val("");
        $("#listaImpacto").val("");
        $("#listaProbabilidad").val("");
        $("#listaRiesgoPotencial").val("");
        $("#correccion").val("");
        $("#searchResponsableMedida").val("").trigger("change");

        $("#modalCorrecciones").modal("show");
    }
    else {
        let row = $("#" + trId);
        let fecha = row.find(".fechaReprogramacion-sst").text(), // row.find("td:eq(4)").text()
            identificacion = row.find(".identificacion-sst").text(),
            responsable = row.find(".nombreCompleto-sst").text();

        if (fecha == "") {
            let hoy = new Date();
            let dia = hoy.getDate(),
                mes = hoy.getMonth() + 1,
                anio = hoy.getFullYear();

            fecha = (mes < 10) ? (dia + "-0" + mes + "-" + anio) : (dia + "-" + mes + "-" + anio);
        }

        $("#hdtrId").val(trId);

        $("#modalReprogramacion .modal-title").html(titulo);
        $("#reprogramacion_identificacion").val(identificacion);
        $("#reprogramacion_responsable").val(responsable);

        let fechaArr = fecha.split("/");
        //$('#reprogramacion_fechaReprogramacion').val(fecha);  se sutituye por:A
        $('#reprogramacion_fechaReprogramacion').datepicker("setDate", new Date(fechaArr[2], parseInt(fechaArr[1]) - 1, fechaArr[0]));

        $("#modalReprogramacion").modal("show");
    }
}

/* funcion master */
var correccionesSST = (function ($) {
    var tipoMedida,
        mostrarEdicion,
        claseOrigen,
        idResponsable,
        nombreCompletoResponsable;

    /**
        * actualizaResponsables
        *
        * */
    function actualizaResponsables() {
        if (idResponsable != "") {
            var newOption = new Option(nombreCompletoResponsable, idResponsable, false, true);
            $('#searchResponsableMedida.classResponsableMedida').append(newOption).trigger('change');
        }
    }

    /**
        * Actualiza los datos del responsable de la medida
        * param data
        */
    function FillResponsableMedida(data) {
        $('#idResponsableMedida').val(data.id);
        $("#RPEResponsableMedida").val(data.rpe);
        $("#NombreResponsableMedida").val(data.text);
    }

    function init(valores) {
        // urlTrabajadoresSearch = valores.urlTrabajadoresSearch;
        tipoMedida = valores.tipoMedida;
        mostrarEdicion = valores.mostrarEdicion;
        claseOrigen = valores.claseOrigen;
        idResponsable = valores.idResponsable;
        nombreCompletoResponsable = valores.nombreCompletoResponsable;

        /* Para la edición de fechas de reprogramación en medidas pendientes de atención */
        //$('#btnFechaReprogramacion').click(function () {
        //    $('#reprogramacion_fechaReprogramacion').datepicker("show");
        //});


        // Para las listas desplegables del responsable (elaborador no aplica)
        $("#searchResponsableMedida.classResponsableMedida").on("select2:select", function (e) {
            var trabajadorCallback = FillResponsableMedida;
            LlenarDatosTrabajadorSelect2(e, true, trabajadorCallback);
        });

        /* Para la edición evaluacion de la desviación */
        setEvaluacionDesviacion("listaImpacto", "listaProbabilidad", "listaRiesgoPotencial");

        if(mostrarEdicion.Length > 0)
        {
            $(".editar-medida").prop("disabled", true);
            $("#searchResponsableMedida.classResponsableMedida").prop("disabled", true);
        }

        if (claseOrigen.Length > 0) 
            $("#listaOrigen").prop("disabled", true);

    }

    return {
        inicializar: init
    }
})(jQuery);

/* 
 * utilsCorreccionesSST
 * Funciones auxiliares para el manejo de las corrrecciones SST 
  * 
 * Desarrollado por
 *  Juan Miguel González Castro
 *  Enero 2022
 * 
 * */


/**
 * setEvluacionDesviacion
 * Asigana función a evento change de las listas asociadas a la desviación
 * */
function setEvaluacionDesviacion(listaImpacto = "listaImpacto", listaProbabilidad = "listaProbabilidad",
    listaRiesgoPotencial = "listaRiesgoPotencial") {
    getRiesgoPotencial(listaImpacto, listaProbabilidad, listaRiesgoPotencial);

    $("#" + listaImpacto).unbind("change");
    $("#" + listaImpacto).bind("change", function () {
        getRiesgoPotencial(listaImpacto, listaProbabilidad, listaRiesgoPotencial);
    });
    $("#" + listaProbabilidad).unbind("change");
    $("#" + listaProbabilidad).bind("change", function () {
        getRiesgoPotencial(listaImpacto, listaProbabilidad, listaRiesgoPotencial);
    });
}

/**
 * getRiesgoPotencial
 * Obtiene (calcula) el valor de desviación (riesgo potencial)
 * en función de los valores seleccionados en las listas
 * asociadas a la desviación
 * */
function getRiesgoPotencial(listaImpacto, listaProbabilidad, listaRiesgoPotencial) {
    var impacto = $("#" + listaImpacto).val();
    var probabilidad = $("#" + listaProbabilidad).val();
    var riesgoPotencial = $("#" + listaRiesgoPotencial);

    if (impacto == "55" && probabilidad == "58") {
        riesgoPotencial.val("3327").change();
    }
    else if (impacto == "55" && probabilidad == "59") {
        riesgoPotencial.val("3327").change();
    }
    else if (impacto == "55" && probabilidad == "60") {
        riesgoPotencial.val("3326").change();
    }
    else if (impacto == "56" && probabilidad == "58") {
        riesgoPotencial.val("3327").change();
    }
    else if (impacto == "56" && probabilidad == "59") {
        riesgoPotencial.val("3326").change();
    }
    else if (impacto == "56" && probabilidad == "60") {
        riesgoPotencial.val("3326").change();
    }
    else if (impacto == "57" && probabilidad == "58") {
        riesgoPotencial.val("3326").change();
    }
    else if (impacto == "57" && probabilidad == "59") {
        riesgoPotencial.val("3325").change();
    }
    else if (impacto == "57" && probabilidad == "60") {
        riesgoPotencial.val("3325").change();
    }
    else {
        riesgoPotencial.val("").change();
    }
}

