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

