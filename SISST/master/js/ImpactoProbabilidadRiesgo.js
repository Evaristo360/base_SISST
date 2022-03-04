
/*
 *
 * For Impacto, Probabilidad & Riesgo list calculation
 *
 * */
function ImpactoProbabilidadRiesgo(formulario, RiesgoSuffix = "") {
    $("#ImpactoPotencial" + formulario).unbind("change");
    $("#ImpactoPotencial" + formulario).bind("change", function () {
        ImpactoProbabilidadRiesgoCalcula(formulario, RiesgoSuffix);
    });
    $("#ProbabilidadPotencial" + formulario).unbind("change");
    $("#ProbabilidadPotencial" + formulario).bind("change", function () {
        ImpactoProbabilidadRiesgoCalcula(formulario, RiesgoSuffix);
    });

}
function ImpactoProbabilidadRiesgoCalcula(formulario, RiesgoSuffix = "") {

    var impacto = $("#ImpactoPotencial" + formulario).val();
    var probabilidad = $("#ProbabilidadPotencial" + formulario).val();
    var riesgo = $("#RiesgoPotencial" + formulario + RiesgoSuffix);

    if (impacto == "55" && probabilidad == "58") {
        riesgo.val("3327").change();
    }
    else if (impacto == "55" && probabilidad == "59") {
        riesgo.val("3327").change();
    }
    else if (impacto == "55" && probabilidad == "60") {
        riesgo.val("3326").change();
    }
    else if (impacto == "56" && probabilidad == "58") {
        riesgo.val("3327").change();
    }
    else if (impacto == "56" && probabilidad == "59") {
        riesgo.val("3326").change();
    }
    else if (impacto == "56" && probabilidad == "60") {
        riesgo.val("3326").change();
    }
    else if (impacto == "57" && probabilidad == "58") {
        riesgo.val("3326").change();
    }
    else if (impacto == "57" && probabilidad == "59") {
        riesgo.val("3325").change();
    }
    else if (impacto == "57" && probabilidad == "60") {
        riesgo.val("3325").change();
    }
    else {
        riesgo.val("").change();
    }
}