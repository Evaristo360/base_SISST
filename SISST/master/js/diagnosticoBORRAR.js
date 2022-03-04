showInPopupBORRAR = (Accion, Controlador, param1, param2, Titulo) => {

    var parametros = param1;
    if (param2.length > 0)
        parametros = parametros & "," & param2;
    var seccion = 1; // Fuente de abastecimiento

    var urlAction = "";
    if (seccion == 1) {
       urlAction = '@Url.A'
    }

    var urlAction = '@Url.Action("Accion","Controlador" ,new{parametros})';
    urlAction = urlAction.replace("parametros", parametros)
        .replace("Accion", Accion)
        .replace("Controlador", Controlador);
   
    alert("showInPopup js " + urlAction );
   
    $.ajax({
        type: "GET",
        url: urlAction,
        success: function (respuesta) {
            $("#form-modal .modal-body").html(respuesta);
            $("#form-modal .modal-title").html(Titulo);
            $("#form-modal").modal("show");
        }
    })
}

//https://www.variablenotfound.com/2012/02/pasar-variables-de-script-un-urlaction.html
function updateUrlBORRAR(Action, Controller, param1, param2, objeto) {
    var parametros = param1;
    if (param2.length > 0)
        parametros = parametros & "," & param2;
    parametros = parametros & "}";
    var url = "@Url.Action('Action', 'Controller', new { parametros })";
    url = url.replace("parametros", parametros)
        .replace("Action", Action)
        .replace("Controller", Controller);
    $(objeto).load(url);
}

function EliminarBORRAR(idArea) {
    $("#idAreaDelete").val(idArea);
    $.LoadingOverlay("hide");
    swal({
        title: "¿Está seguro de eliminar el registro?",
        text: "Se eliminará el registro de manera permanente, por lo que será imposible su recuperación. \n ",
        icon: "warning",
        buttons: {
            cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true },
            confirm: { text: "¡Sí, eliminarlo!", value: !0, visible: !0, className: "bg-danger", closeModal: true }
        }

    }).then(function (e) {
        if (e) {
            $.LoadingOverlay("show");
            $('#frmDelete').submit();
        }
        else {
            swal.close();
        }
    });

    $.LoadingOverlay("hide");
}