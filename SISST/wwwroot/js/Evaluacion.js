
$(document).ready(function () {
    $("form").submit(function (event) {
        $.LoadingOverlay("show");
    });
});
function confirmTerminar(existente, generarNuevaVersion, generarCorrecciones) {
    $.LoadingOverlay("hide");
    if ($("#Comentarios").val() == "") {
        swal("Aviso", "Debe registrar algún comentario global para la evaluación!", "error");
        return false;
    }
    var aviso = "";
    if (existente == '1' && generarNuevaVersion=='1') {
        aviso = " En virtud de que existe al menos un requisito identificado como SI APLICA al centro de trabajo, se generará una versión del expediente en estado Borrador, si ya existe, sólo se integrarán los nuevos requisitos. "
    }
    else if (generarNuevaVersion == '1') {
        aviso += " En virtud de que existe al menos un requisito identificado como SI APLICA al centro de trabajo, se generará una nueva versión del expediente en estado Borrador.\n";
    }
    if (generarCorrecciones == '1') {
        aviso +="\nSe generará una corrección SST para cada requisito evaluado\ncon un valor menor a 5 y será actualizado el número de requisitos cumplidos en la versión Vigente.\n"
    }
    swal({
        title: "Terminar evaluación",
        text: "Esta acción concluirá la evaluación del expediente\nde cumplimiento de los requisitos legales\naplicables a este centro de trabajo."+aviso+"\n¿Confirma que desea continuar?",
        icon: "warning",
        buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, terminar!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

    }).then(function (e) {
        if (e) {
            $.LoadingOverlay("show");            
            location.href = urlTerminarEvaluacion;
        }
        else {
            swal.close();
        }
    });
    $.LoadingOverlay("hide");
}

