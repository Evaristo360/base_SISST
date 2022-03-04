$(document).ready(function () {
    
    $("form").submit(function (event) {
        $.LoadingOverlay("show");
    });   
});

function confirmEnviarARevision() {
    $.LoadingOverlay("hide");
    if ($("#NombreAprobador").val()=="" ) {
        swal("Debe seleccionar el aprobador del expediente!","", "warning"); 
        return false;
    }
    swal({
        title: "Enviar expediente a revisión",
        text: "Esta acción enviará el expediente a revisión y no se podrán hacer modificaciones hasta que termine este proceso.\n¿Confirma que desea continuar?",
        icon: "warning",
        buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, enviarlo!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

    }).then(function (e) {
        if (e) {
            $.LoadingOverlay("show");
            $('#frmEnviar').submit();
        }
        else {
            swal.close();
        }
    });
    $.LoadingOverlay("hide");
}

function confirmAprobar() {
    $.LoadingOverlay("hide");   
    swal({
        title: "Aprobar expediente",
        text: "Esta acción aprobará el expediente de cumplimiento\nde los requisitos legales aplicables a este centro de trabajo\n¿Confirma que desea continuar?",
        icon: "warning",
        buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, aprobarlo!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

    }).then(function (e) {
        if (e) {
            $.LoadingOverlay("show");
            $('#frmAprobar').submit();
        }
        else {
            swal.close();
        }
    });
    $.LoadingOverlay("hide");
}

function confirmRechazar1() {
    $.LoadingOverlay("hide");   
    swal({
        title: "Rechazar expediente",
        text: "Esta acción rechazará el expediente de cumplimiento\nde los requisitos legales aplicables a este centro de trabajo\n y lo regresará al estado de elaboración.\n¿Confirma que desea continuar?",
        icon: "warning",
        buttons: {
            cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true },
            confirm: { text: "¡Sí, rechazarlo!", value: !0, visible: !0, className: "bg-danger", closeModal: true }
        }

    }).then(function (e) {
        if (e) {
            $.LoadingOverlay("show");
            $('#frmRechazar').submit();
        }
        else {
            swal.close();
        }
    });
    $.LoadingOverlay("hide");
}

function confirmRechazar() {
    $.LoadingOverlay("hide");
    swal({
        content: {
            element: "input",
            attributes: {
                placeholder: "Motivo del rechazo",
                type: "text"
            },
        },
        title: "Rechazar expediente",
        text: "Esta acción rechazará el expediente de cumplimiento\nde los requisitos legales aplicables a este centro de trabajo\n y lo regresará al estado de elaboración.\n¿Confirma que desea continuar?",
        icon: "warning",
        buttons: {
            cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true },
            confirm: { text: "¡Sí, rechazarlo!", value: !0, visible: !0, className: "bg-danger", closeModal: true }
        },
        inputValidator: (value) => {
            if (!value) return value;
            else return null
        }
    })
        .then(function (isConfirm) {
            if (isConfirm) {
                var motivo = isConfirm;

                $("#Comentarios").val(motivo); 
                let accion = $('#frmRechazar').action +"?motivo=motivo";
                console.log(accion)

                $('#frmRechazar').action = accion ;

                $('#frmRechazar').submit();

            }
            else if (isConfirm == "") {
                swal({
                    title: "Rechazar expediente",
                    text: "Debe de proporcionar la razón del rechazo.",
                    icon: "warning",
                    buttons: {
                        confirm: { text: "Aceptar", value: !0, visible: !0, className: "bg-info", closeModal: true }
                    }
                });
            }
        });
}