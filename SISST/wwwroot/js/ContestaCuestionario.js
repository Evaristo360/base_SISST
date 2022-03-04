function confirmaTerminar(param, mensaje) {
    //validar
    if (prohibeGuardar()) {
        $.unblockUI();
        return false;
    }
    swal({
        title: "¿Está seguro de terminar el cuestionario?",
        text:  mensaje + "\nEsta acción cambiará el cuestionario a estado Terminado y no podrá ser editado.\nConfirma que desea continuar?",
        icon: "warning",
        buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, terminarlo!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

    }).then(function (e) {
        if (e) {
            $.LoadingOverlay("show");
            swal.close();
            guardaCuestionario(param);            
        }
        else {
            swal.close();
        }
    });
    $.LoadingOverlay("hide");
}

function prohibeGuardar() {
    var impideGuardar = false;
    //validar que haya seleccionado un valor para pregunta
    var selPregunta = document.querySelector('input[class^="rg_"]:checked') != null ?
        document.querySelector('input[class^="rg_"]:checked').value : "";
    if (selPregunta == '') {
        $("#val_pregunta").text("Seleccione una respuesta");
        $.unblockUI();
        return true;
    }
    else
        $("#val_pregunta").text("");

    //checar por subpreguntas
    if (validaSP == true) {
        var elements = $("[class^=rgs_]");
        var checado = false;
        var cuenta = 0;
        elements.each(function (index) {
            $("#val_rs_" + this.name).text("");
        });
        elements.each(function (index) {
            cuenta++;
            if (this.checked == true) {
                checado = true;
            }
            else {
                if (checado == true) {
                }
                else {
                    checado = false;
                }
            }
            if (cuenta % 2 == 0 && checado == false) {
                $("#val_rs_" + this.name).text("Seleccione una respuesta");
                impideGuardar = true;
            } else if (cuenta % 2 == 0 && checado)
                checado = false;
        });
    }
    //checar por sub subpreguntas
    if (validaSSP) {
        var elements = $("[class^=rgss_]");
        var checado = false;
        var cuenta = 0;
        elements.each(function (index) {
            $("#val_rss_" + this.name).text("");
        });
        elements.each(function (index) {
            cuenta++;
            if (this.checked == true) {
                checado = true;
            }
            else {
                if (checado == true) {
                }
                else {
                    checado = false;
                }
            }
            if (cuenta % 2 == 0 && checado == false) {
                $("#val_rss_" + this.name).text("Seleccione una respuesta");
                impideGuardar = true;
            } else if (cuenta % 2 == 0 && checado)
                checado = false;
        });
    }
    return impideGuardar;
}