$(document).ajaxStart(function () {
    $.LoadingOverlay("show");
});
$(document).ajaxStop(function () {
    $.LoadingOverlay("hide");
});

$(document).ready(function () {
    

    if ($("#areasAdministradas").length) {
        $('#areasAdministradas').select2({
            placeholder: 'Seleccione una opción',
            language: {
                noResults: function () {

                    return "No hay resultado";
                },
                searching: function () {

                    return "Buscando..";
                }
            }
        });
    }

    $(".desbloquearFormulario").click(function () {
        $.LoadingOverlay("hide");//$.unblockUI();
    });

    $(".espereGuardar").click(function () {
        $.LoadingOverlay("show");//$.blockUI();
    });

    $('.noCopiarPegar').bind("cut copy paste", function (e) {
        e.preventDefault();
    });

    $('.noCopiarPegar').bind("contextmenu", function (e) {
        e.preventDefault();
    });

    //Inicialización de un datatable

    if ($('.dataTables-example')[0]) {

        $('.dataTables-example').DataTable({

            dom: "Blfrtip",//"Bfrtip",
            buttons: [
                //{ extend: "copy", className: "btn-info" },
                { extend: "pdf", className: "'btn btn-outline-secondary", title: $("title").text() },                
                //{ extend: "csv", className: "btn-info" },
                { extend: "excel", className: "'btn btn-outline-secondary", title: "XLS-File" },
                { extend: "print", className: "'btn btn-outline-secondary" }],
            order: [],
            responsive: true,
            lengthMenu: [
                [20, 50, -1],
                ['20', '50', 'Ver todo']
            ],
            language: {
                buttons: {
                    pageLength: "Mostrar _MENU_ registros",
                    print: "Imprimir"                    
                },
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ registros por página",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }
              }
                //,

            //initComplete: function (settings, json) {
            //    dataTable.buttons().container().appendTo($('.table-tools-col:eq(0)', dataTable.table().container()));
            //}
        });
    }
    if ($(".dataTables-example").length > 0) {
        if (document.getElementsByClassName("dt-buttons").length > 0) {
            divButtonss = document.getElementsByClassName("dt-buttons");
            divButtonss[0].style.cssFloat = "right";
        }
    }



    //Inicialización de un datatable

    if ($('.dataTables-simple')[0]) {

        $('.dataTables-simple').DataTable({ 
            dom: "lrtip",//"Bfrtip",Blfrtip
                "paging": true,
                "ordering": false,
                "info": false,
            "searching": false,
            language: {
                buttons: {
                    pageLength: "Mostrar _MENU_ registros"                    
                },
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ registros por página",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }
            }
        });
        if ($(".dataTables-simple").length > 0) {
            if (document.getElementsByClassName("dt-buttons").length > 0) {
                divButtonss = document.getElementsByClassName("dt-buttons");
                divButtonss[0].style.display = "none";                
            }
        }
    }


    if ($('.dataTables-basic')[0]) {
        $('.dataTables-basic').DataTable({
            dom: "lrtip",//"Bfrtip",Blfrtip
            "paging": false,
            "ordering": false,
            "info": false,
            "searching": false,  
            language: {
                buttons: {
                    pageLength: "Mostrar _MENU_ registros"
                },
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ registros por página",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }
            }
        });
        if ($(".dataTables-basic").length > 0) {
            if (document.getElementsByClassName("dt-buttons").length > 0) {
                divButtonss = document.getElementsByClassName("dt-buttons");
                divButtonss[0].style.display = "none";
            }
        }
    }



    //Inicialización de la notificación
    //console.log("Toastr options");
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "progressBar": true,
        "positionClass": "toast-bottom-right",
        "showDuration": "1000",
        "hideDuration": "1000",
        "timeOut": "7000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    toastr.options.positionClass = 'toast-bottom-right';

    // Modal for deleteConfirmation
    $('.deleteConfirmation').click(function () {
        $.LoadingOverlay("hide");//$.unblockUI();
        //var mensaje = ""
        //if ($("#mensajeEliminar").length > 0) {
        //    mensaje = $("#mensajeEliminar").val();
        //}

        swal({
            title: "¿Está seguro de eliminar el registro?",
            text: "Se eliminará el registro de manera permanente, por lo que será imposible su recuperación. \n ",
            icon: "warning",
            buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, eliminarlo!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

        }).then(function (e) {
            if (e) {
                $.LoadingOverlay("show");//$('.sweet-alert').block({ message: "Por favor espere..." });
                $('#frmDelete').submit();
            }
            else {
                swal.close();
            }
        });

        $.LoadingOverlay("hide");//$.unblockUI();
    });

    // Modal for deactivateConfirmation
    $('.deactivateConfirmation').click(function () {
        $.LoadingOverlay("hide");// $.unblockUI();

        swal({
            title: "¿Está seguro de desactivar el usuario?",
            text: "Se desactivará el usuario. No podrá tener acceso al sistema. \n ",
            icon: "warning",
            buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, desactivarlo!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

        }).then(function (e) {
            if (e) {
                $.LoadingOverlay("show");//$('.sweet-alert').block({ message: "Por favor espere..." });
                $('#frmDeactivate').submit();
            }
            else {
                swal.close();
            }
        });

        $.LoadingOverlay("hide");//$.unblockUI();
    });

    // Modal for activateConfirmation
    $('.activateConfirmation').click(function () {
        $.LoadingOverlay("hide");//$.unblockUI();

        swal({
            title: "¿Está seguro de activar el usuario?",
            text: "Se activará el usuario. Podrá tener acceso al sistema. \n ",
            icon: "warning",
            buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, activarlo!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

        }).then(function (e) {
            if (e) {
                $.LoadingOverlay("show");//$('.sweet-alert').block({ message: "Por favor espere..." });
                $('#frmDeactivate').submit();
            }
            else {
                swal.close();
            }
        });

        $.LoadingOverlay("hide");//$.unblockUI();
    });

    // Modal for deactivateConfirmation
    $('.resetPasswordConfirmation').click(function () {
        $.LoadingOverlay("hide");//$.unblockUI();

        swal({
            title: "¿Está seguro resetear el password?",
            text: "Se actualizará el password por el inicial. \n ",
            icon: "warning",
            buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, actualizar el password!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

        }).then(function (e) {
            if (e) {
                $.LoadingOverlay("show");//$('.sweet-alert').block({ message: "Por favor espere..." });
                $('#frmResetPassword').submit();
            }
            else {
                swal.close();
            }
        });

        $.LoadingOverlay("hide");//$.unblockUI();
    });

    // Modal for Service activation Confirmation
    $('.activateServicioConfirmation').click(function () {
        $.LoadingOverlay("hide");
        swal({
            title: "Acuse de recibo de servicio de evaluación UI",
            text: "Esta acción generará los expedientes de cada componente especificado en la solicitud e iniciará la atención del servicio.\n\n¿Confirma que desea continuar?\n ",
            icon: "warning",
            buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "Enviar acuse", value: !0, visible: !0, className: "btn-defaul", closeModal: true } }

        }).then(function (e) {
            if (e) {
                $.LoadingOverlay("show");
                $('#frmIniciarServicio').submit();
            }
            else {
                swal.close();
            }
        });
        $.LoadingOverlay("hide");
    });

});


// https://stackoverflow.com/questions/2808184/restricting-input-to-textbox-allowing-only-numbers-and-decimal-point
// THE SCRIPT THAT CHECKS IF THE KEY PRESSED IS A NUMERIC OR DECIMAL VALUE.
function isNumber(evt, element) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (
        (charCode != 45 || $(element).val().indexOf('-') != -1) &&      // “-” CHECK MINUS, AND ONLY ONE.
        (charCode != 46 || $(element).val().indexOf('.') != -1) &&      // “.” CHECK DOT, AND ONLY ONE.
        (charCode < 48 || charCode > 57) &&
        (charCode != 08))
        return false;

    return true;
}
//ES  NUMERO ENTERO SOLAMENTE
function isNumberInteger(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if ((charCode < 48 || charCode > 57) &&
        (charCode != 08))
        return false;

    return true;
}

function isUrl(s) {
    var regexp = /(ftp|http|https):\/\/(\w+:{0,1}\w*@)?(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%@!\-\/]))?/
    return regexp.test(s);
}


var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : sParameterName[1];
        }
    }
};

//Funcion que solo permite introducir letras o numeros (en el control html (input) solo le debes de agregar 
//la clase "soloNumeroLetra" y ya hace la validación en automatico)
$(document).on('keypress', '.soloNumeroLetra', function (e) {
    var tecla = (document.all) ? e.keyCode : e.which;
    if (tecla != 8 && tecla != 0) {
        var regex = new RegExp("^[a-zA-Z0-9ñÑóúíáéÁÉÍÓÚ \s]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            e.preventDefault();
            return false;
        }
    }
});

function cambiaAcentos(r) {
    r = r.replace(new RegExp(/&#193;/gi), "Á");
    r = r.replace(new RegExp(/&#201;/gi), "É");
    r = r.replace(new RegExp(/&#205;/gi), "Í");
    r = r.replace(new RegExp(/&#211;/gi), "Ó");
    r = r.replace(new RegExp(/&#218;/gi), "Ú");
    r = r.replace(new RegExp(/&#225;/gi), "á");
    r = r.replace(new RegExp(/&#233;/gi), "é");
    r = r.replace(new RegExp(/&#237;/gi), "í");
    r = r.replace(new RegExp(/&#243;/g), "ó");
    r = r.replace(new RegExp(/&#250;/g), "ú");
    return r;
}
(function ($) {
    $.fn.textAreaLimit = function (limit, element) {
        return this.each(function () {
            var $this = $(this);            
            var displayCharactersLeft = function (charactersLeft) {
                if (element) {
                    $(element).html((charactersLeft <= 0) ? '0' : charactersLeft);
                }
            };
            $this.bind('keyup', function (evt) {                
                var val = $this.val().trim();
                var val2 = $this.val();
                numberOfLineBreaks = (val2.match(/\n/g) || []).length;//al usar trim omite la cuenta de breaklines por eso se busca en val2
                var length = val.length + numberOfLineBreaks; 
                
                if (length > limit) {
                    $this.val($this.val().substring(0, limit));
                    displayCharactersLeft(limit - length);                    
                    var charCode = (evt.which) ? evt.which : event.keyCode;
                    if (charCode == 13)
                        return false;
                }
                else
                    displayCharactersLeft(limit - length);
            });           
            var valor = $this.val();
            numberLB = (valor.match(/\n/g) || []).length;
            var len = valor.length + numberLB;
            displayCharactersLeft(limit - len);
        });
    };
})(jQuery);
/* Ajax funciones peticion por GET, POST, json, html */
var servidor = window.location.hostname;
var protocolo = window.location.protocol;
var host_jq = "";
var url_jq = "";
var url_jq_js = "";//"" + protocolo + "//" + servidor;
var url_jq_css = "";//"" + protocolo + "//" + servidor;
var base_directorio = "";
var imagen_loading = "/images/loaders/ripple.gif";
var contenedor_actual = "";

function envia_peticion(urlmvc, string_query, funcion_call, tipo_dato) {
    if (typeof (urlmvc) == "undefined") {
        alert("Es necesario definir la url MVC.");
        return false;
    }
    if (typeof (tipo_dato) == "undefined")
        tipo_dato = "text";
    if (typeof (funcion_call) == "undefined")
        funcion_call = "";
    $.ajax({
        url: urlmvc,
        global: false,
        type: "POST",
        data: string_query,
        dataType: tipo_dato,
        success: funcion_call,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("\n" + textStatus + "\n" + errorThrown);
        }
    });
}
function ve_por_peticion(parametros) {
    ajax_error = false;
    if (typeof (parametros.ruta) == "undefined" || parametros.ruta == "") {
        alert("Falta definir la url de peticion");
        return false;
    } else {
        parametros.ruta = base_directorio + parametros.ruta;
    }
    if (typeof (parametros.type) == "undefined" || parametros.type == "") {
        parametros.type = "text";
    }
    if (typeof (parametros.query) == "undefined") {
        parametros.query = "";
    }
    if (typeof (parametros.method) == "undefined") {
        parametros.method = "POST";
    }
    if (typeof (parametros.contentType) == "undefined" || parametros.contentType == "") {
        parametros.contentType = "application/x-www-form-urlencoded;charset=utf-8";
    }
    if (typeof (parametros.funcion_call) == "undefined") {
        parametros.funcion_call = "";
    }
    //alert(parametros.type);
    //alert(parametros.contentType);
    $.ajax({
        url: parametros.ruta,
        global: false,
        type: parametros.method,
        data: parametros.query,
        dataType: parametros.type,
        contentType: parametros.contentType,
        success: parametros.funcion_call,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajax_error = true;
            try {
                swal("Petición", XMLHttpRequest.status + "<br />" + parametros.ruta + "<br />" + textStatus + "<br />" + errorThrown, "error")
            }
            catch (errorPeticion) {
                alert(XMLHttpRequest.status + "\n" + parametros.ruta + "\n" + textStatus + "\n" + errorThrown);
            }
            try {
                $.LoadingOverlay("hide");//$.unblockUI();
            }
            catch (errorBlok) {

            }
            //alert(XMLHttpRequest.responseText);
            //
        }
    });
}


function peticion_rsv(url, query, contenedor, anade, callback, oculta) {
    $(contenedor).show();
    if (typeof (anade) == "undefined" || anade == '')
        anade = "establece";

    if (anade == "establece") {
        //parametros.ruta = "/"+base_directorio+parametros.ruta;
        $(contenedor).html("<center><img src='" + url_jq_js + "/" + base_directorio + "" + imagen_loading + "' border='0' title='' alt='' /></center>");
    }
    parametros = new Object();
    parametros.ruta = url;
    parametros.query = query;
    parametros.type = "jsonp";
    //parametros.contentType = "application/json; charset=ISO-8859-1";
    parametros.funcion_call = function (data) {
        datos = data;
        //data = JSON.parse(data); 
        //alert(data);
        //return;
        if (data.error > 0) {
            trae_elemento(data.respuesta, "anadir", contenedor);
        } else if (data.error == 0) {
            trae_elemento(data.respuesta, anade, contenedor);
            if (oculta == 1) {
                setTimeout("peticion_rsv_oculta('" + contenedor + "')", 3000);
            }
        }
        if (typeof (callback) != "undefined" && callback != '') {
            setTimeout(function () {
                callback(data);
                try { $.LoadingOverlay("hide");/*$.unblockUI();*/ } catch (errorBlok) { console.log("No se encontro el plugin unBlockUI");}
            }, 200);
        }
    };

    ve_por_peticion(parametros);
    return false;
}
function vista_mvc(url, query, contenedor, anade, callback, oculta) {
    $(contenedor).show();
    if (typeof (anade) == "undefined" || anade == '')
        anade = "establece";

    if (anade == "establece") {
        //parametros.ruta = "/"+base_directorio+parametros.ruta;
        $(contenedor).html("<center><img src='" + url_jq_js + "/" + base_directorio + "" + imagen_loading + "' border='0' title='' alt='' /></center>");
    }
    parametros = new Object();
    parametros.ruta = url;
    parametros.query = query;
    parametros.type = "html";
    parametros.funcion_call = function (data) {
        datos = data;
        //data = JSON.parse(data); 
        //alert(data);
        //return;
        if (data.error > 0) {
            trae_elemento(data.respuesta, "anadir", contenedor);
        } else if (data.error == 0) {
            trae_elemento(data.respuesta, anade, contenedor);
            if (oculta == 1) {
                setTimeout("peticion_rsv_oculta('" + contenedor + "')", 3000);
            }
        }
        if (typeof (callback) != "undefined" && callback != '') {
            setTimeout(function () {
                callback(data);
                try { $.LoadingOverlay("hide");/*$.unblockUI();*/ } catch (errorBlok) { console.log("No se encontro el plugin unBlockUI"); }
            }, 200);
        }
    };

    ve_por_peticion(parametros);
    return false;
}
function vista_mvc_get(url, query, contenedor, anade, callback, oculta) {
    $(contenedor).show();
    if (typeof (anade) == "undefined" || anade == '')
        anade = "establece";

    if (anade == "establece") {
        //parametros.ruta = "/"+base_directorio+parametros.ruta;
        $(contenedor).html("<center><img src='" + url_jq_js + "/" + base_directorio + "" + imagen_loading + "' border='0' title='' alt='' /></center>");
    }
    parametros = new Object();
    parametros.ruta = url;
    parametros.query = query;
    parametros.method = "GET";
    parametros.type = "html";
    parametros.funcion_call = function (data) {
        datos = data;
        //data = JSON.parse(data); 
        //alert(data);
        //return;
        if (data.error > 0) {
            trae_elemento(data.respuesta, "anadir", contenedor);
        } else if (data.error == 0) {
            trae_elemento(data.respuesta, anade, contenedor);
            if (oculta == 1) {
                setTimeout("peticion_rsv_oculta('" + contenedor + "')", 3000);
            }
        }
        if (typeof (callback) != "undefined" && callback != '') {
            setTimeout(function () {
                callback(data);
                try { $.LoadingOverlay("hide");/*$.unblockUI();*/ } catch (errorBlok) { console.log("No se encontro el plugin unBlockUI"); }
            }, 200);
        }
    };

    ve_por_peticion(parametros);
    return false;
}

/**
 * Funcion que se utiliza para mandar por AJAX por metodo de GET, POST y obtiene el json del controller
 * ya tiene validación en caso tenga un error el controller
 * Antes de la llamada podemos usar el BlockUI y ya la funcion trata de desactivarlo ya sea en el caso de una peticion valida
 * como de una peticíon con error.
 * 
 * @param url es la URL de la petición, es necesaria, en caso de que no lleve manda una alerta de error
 * @param query es opcional, es para mandar los datos que envia el formulario ya sea por POST o GET
 * @param method es opcional, por default es POST, sus parametros pueden ser POST, GET
 * @param callback es opcional, Se manda una funcion para cuando la peticion tiene el codigo 200
 * 
 Ejemplo 
        var url = "/Comunes/Usuarios/ReiniciaPassword/?UsuarioId=1"
        json_mvc(url,
                 "", 
                 "GET", 
                 function (datos) {
                    //datos es el json que recibe de la peticion de ajax ya convertido en objeto
                    alert( datos.nombreEmpleado );
                 }
            });
 */
function json_mvc(url, query, method, callback) {
    
    if (typeof (method) == "undefined" || method == '') {
        method = "GET";
    }
    parametros = new Object();
    parametros.ruta = url;
    parametros.method = method;
    parametros.query = query;
    parametros.type = "json";
    parametros.funcion_call = function (data) {
        datos = data;
        if (typeof (callback) != "undefined" && callback != '') {
            setTimeout(function () {
                callback(data);
                try { $.LoadingOverlay("hide");/*$.unblockUI();*/ } catch (errorBlok) { console.log("No se encontro el plugin unBlockUI"); }
            }, 200);
        }
    };

    ve_por_peticion(parametros);
    return false;
}

function vista_mvc_post(url, query, contenedor, anade, callback, oculta) {
    $(contenedor).show();
    if (typeof (anade) == "undefined" || anade == '')
        anade = "establece";

    if (anade == "establece") {
        //parametros.ruta = "/"+base_directorio+parametros.ruta;
        $(contenedor).html("<center><img src='" + url_jq_js + "/" + base_directorio + "" + imagen_loading + "' border='0' title='' alt='' /></center>");
    }
    parametros = new Object();
    parametros.ruta = url;
    parametros.query = query;
    parametros.method = "POST";
    parametros.type = "html";
    parametros.funcion_call = function (data) {
        datos = data;
        //data = JSON.parse(data); 
        //alert(data);
        //return;
        if (data.error > 0) {
            trae_elemento(data.respuesta, "anadir", contenedor);
        } else if (data.error == 0) {
            trae_elemento(data.respuesta, anade, contenedor);
            if (oculta == 1) {
                setTimeout("peticion_rsv_oculta('" + contenedor + "')", 3000);
            }
        }
        if (typeof (callback) != "undefined" && callback != '') {
            setTimeout(function () {
                callback(data);
                try { $.LoadingOverlay("hide");/*$.unblockUI();*/ } catch (errorBlok) { console.log("No se encontro el plugin unBlockUI"); }
            }, 200);
        }
    };

    ve_por_peticion(parametros);
    return false;
}
function peticion_rsv_oculta(contenedor) {
    $(contenedor).hide("slow");
}

function trae_elemento(data, anade, contenedor) {
    //alert(contenedor);
    if (typeof (anade) == "undefined") {
        anade = "establece";
    } else {
        if (anade == "") {
            anade = "establece";
        }
    }
    if (contenedor != "") {
        if (anade == "establece") {
            $(contenedor).html(data);
        }
        if (anade == "anadir") {
            $(contenedor).append(data);
        }
    }
    else {
        //createGrowl(data, "Verificando...", false);
    }
}

function elimina_entidad(entidad) {
    //alert(entidad);
    $(entidad).remove();
}

function initLoading() {
    $('#modalLoading').modal('show');
    $('#modalLoading').modal({ backdrop: 'static', keyboard: false });
}

function cancelLoading() {
    $('#modalLoading').modal('hide');
}

//no permite espacio
function pulsar(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 32) return false;
} 

//for automatic textarea resize
$(document).ready(function () {
    ResizeTextArea();
});

function ResizeTextArea(customInitHeight = 0) {
    $("textarea.autoResize").each(function () {
        var theHeight = customInitHeight == 0 ? this.scrollHeight : customInitHeight;
        this.setAttribute("style", "height:" + (theHeight) + "px;overflow-y:hidden;");
    }).on("input", function () {
        this.style.height = "auto";
        this.style.height = (this.scrollHeight) + "px";
    });

}