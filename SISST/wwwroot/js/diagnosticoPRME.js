
//https://www.youtube.com/watch?v=3r6RfShv8m8
//showInPopup = (Url, Title) => {
//    alert("showInPopup " + Url);
//    $.ajax({
//        type: "GET",
//        url: Url,
//        success: function(respuesta){
//            $("#form-modal .modal-body").html(respuesta);
//            $("#form-modal .modal-title").html(Title);
//            $("#form-modal").modal("show");
//        }
//    })
//}

showInPopup = (Accion, Controlador, param1, param2, Titulo) => {

    var parametros = param1;
    if (param2.length > 0)
        parametros = parametros & "," & param2;

    var urlAction = "@Url.Action('Accion','Controlador',new{parametros})";
    urlAction = urlAction.replace("parametros", parametros)
        .replace("Accion", Accion)
        .replace("Controlador", Controlador);
    urlActio = '@Url.Action'
    alert("showInPopup " + urlAction );
   
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
function updateUrl(Action, Controller, param1, param2, objeto) {
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

