
var confirmarAplicabilidad = false,
    aplica, cuantos, idASE; // Estas variables se llenan al tiempo de cargar la página (document).ready

/*
 * inicializarNoAplica
 * Habilita/deshabilita los objetos asociados a la aplicabilidad o no
 * aplicabilidad de los sistemas contra incendio, en función de los 
 * datos del modelo
 */
function inicializarNoAplica() {
    if (aplica === "False") {
        $(".dv-items").css("display", "none");
        $(".dv-NoAplica").css("display", "flex");
    }
    else {
        if (idASE > 0)
            $(".dv-items").css("display", "flex");
        $(".dv-NoAplica").css("display", "none");
    }
}

/**
 * cambiarNoAplica
 * Habilita/deshabilita los objetos asociados a la aplicabilidad o no
 * aplicabilidad de los sistemas contra incendio, en función de los 
 * eventos de la UI
 * */
function cambiarNoAplica() {
    /*
     * input[type=radio]").change
     * Hablita/deshabiilita los objetos en función de la aplicabilidad
     */
    $("input[type=radio]").change(function () {
        var obj = $(this);
        var id = obj.attr("id");
        var clase = id.substring(2);
        confirmarAplicabilidad = false;

        if (clase.substring(0, 2) == "No") {
            if (aplica && cuantos > 0) {
                // Deshabilitar
                $(".dv-items :input").addClass("disabled");
                $(".dv-items .linkAction").addClass("isDisabled");
                confirmarAplicabilidad = true;
            }
            else
                $(".dv-items").css("display", "none");

            $(".dv-NoAplica").css("display", "flex");
        }
        else {
            if (idASE > 0 && cuantos > 0) {
                $(".dv-items").css("display", "flex");
                // habilitar objetos
                $(".dv-items :input").removeClass("disabled")
                $(".dv-items .linkAction").removeClass("isDisabled");
            }

            $(".dv-NoAplica").css("display", "none");
        }
    });
}


/**
  * confirmarNoAplica
  * Previo a guardar el cambio de aplicabilidad confirma dado el potencial borrado de datos
  * */
function confirmarNoAplica(formSubmit, texto) {
    if (confirmarAplicabilidad) {
        $.LoadingOverlay("hide");

        swal({
            title: "¿Está seguro de cambiar la existencia en el área, sistema, equipo?",
            text: texto,
            icon: "warning",
            buttons: {
                cancel: { text: "Cancelar", value: 0, visible: !0, className: "", closeModal: true },
                confirm: { text: "¡Sí, cambiarla!", value: !0, visible: !0, className: "bg-danger", closeModal: true }
            }
        }).then(function (e) {
            if (e) {
                $(formSubmit).submit();
            }
            swal.close();
            $.LoadingOverlay("hide");
        });
    }
    else {
        $(formSubmit).submit();
    }
}

