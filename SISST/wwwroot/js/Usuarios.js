function ActivaDataTable() {

    if ($('.dataTables-exampleb')[0]) {

        $('.dataTables-exampleb').DataTable({
            retrieve: true,
            dom: "Blrtip",//"Bfrtip",
            buttons: [
                { extend: "pdf", className: "'btn btn-outline-secondary", title: $("title").text() },
                { extend: "excel", className: "'btn btn-outline-secondary", title: "XLS-File" },
                { extend: "print", className: "'btn btn-outline-secondary" }],
            order: [],
            responsive: true,
            lengthMenu: [
                [10, 20, 50, -1],
                ['10', '20', '50', 'Ver todo']
            ],
            columns: [{ 'data': 'id' }, { 'data': 'rpe' },
            { 'data': 'nombreCompleto' }],
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
        });
    }
    if ($(".dataTables-exampleb").length > 0) {
        if (document.getElementsByClassName("dt-buttons").length > 0) {
            divButtonss = document.getElementsByClassName("dt-buttons");
            divButtonss[0].style.cssFloat = "right";
        }
    }

}

$(document).ready(function () {
    $("#selecTodosPrivilegios").click(function () {
        $('#tblPrivilegio').LoadingOverlay("show");//$('#tblPrivilegio').block({ message: "Por favor espere...", fadeIn: 0, fadeOut: 0, timeout: 0 });
        rows = $('#tblPrivilegio').DataTable().rows({ search: 'applied' }).data();
        for (var i = 0; i < rows.length; i++) {
            $('#tblPrivilegio').DataTable().column(0).search("^" + rows[i][0] + "$", true, false).draw();
            if ($("#privilegio_" + rows[i][0]).attr("disabled") != "disabled") {
                $("#privilegio_" + rows[i][0]).prop("checked", true);
                $("#privilegio_" + rows[i][0]).attr("checked", "checked");
            }
        }
        $('#tblPrivilegio').DataTable().column(0).search("").draw();
        $('#tblPrivilegio').LoadingOverlay("hide");//$('#tblPrivilegio').unblock();
    });

    $("#deSelecTodosPrivilegios").click(function () {
        $('#tblPrivilegio').LoadingOverlay("show");//$('#tblPrivilegio').block({ message: "Por favor espere...", fadeIn: 0, fadeOut: 0, timeout: 0 });
        rows = $('#tblPrivilegio').DataTable().rows({ search: 'applied' }).data();
        for (var i = 0; i < rows.length; i++) {
            $('#tblPrivilegio').DataTable().column(0).search("^" + rows[i][0] + "$", true, false).draw();
            if ($("#privilegio_" + rows[i][0]).attr("disabled") != "disabled") {
                $("#privilegio_" + rows[i][0]).prop("checked", false);
            }
        }
        $('#tblPrivilegio').DataTable().column(0).search("").draw();
        $('#tblPrivilegio').LoadingOverlay("hide");//$('#tblPrivilegio').unblock();
    });
    

    $("#btnAceptar").click(function () {

        var tablePrivilegio = $('#tblPrivilegio').dataTable();
        var rowPrivilegio = tablePrivilegio._fnGetDataMaster();
        $('#tblPrivilegio').DataTable().search(" ");
        for (var i = 0; i < rowPrivilegio.length; i++) {
            var id = rowPrivilegio[i][0];
            $('#tblPrivilegio').DataTable().search(" ");
            $('#tblPrivilegio').DataTable().column(2).search(rowPrivilegio[i][2]).draw();

            if ($("#privilegio_" + id).is(':checked')) {
                var idPrivilegio = id;
                if ($("#privilegio_" + id).attr('disabled') != "disabled") {
                    var str = '<input type="hidden" name="listaPrivilegios" value="' + idPrivilegio + '" />';
                    $("#divPrivilegioSeleccionado").append(str);
                }
            }
            $('#tblPrivilegio').DataTable().search(" ");
        }
    });  

    

    //if ($('.dataTables-exampleb')[0]) {

    //    $('.dataTables-exampleb').DataTable({
    //        retrieve: true,
    //        dom: "Blrtip",//"Bfrtip",
    //        buttons: [
    //            { extend: "pdf", className: "'btn btn-outline-secondary", title: $("title").text() },
    //            { extend: "excel", className: "'btn btn-outline-secondary", title: "XLS-File" },
    //            { extend: "print", className: "'btn btn-outline-secondary" }],
    //        order: [],
    //        responsive: true,
    //        lengthMenu: [
    //            [10, 20, 50, -1],
    //            ['10', '20', '50', 'Ver todo']
    //        ],
    //        columns: [{ 'data': 'id' },{ 'data': 'rpe' },
    //        { 'data': 'nombreCompleto' }],
    //        language: {
    //            buttons: {
    //                pageLength: "Mostrar _MENU_ registros",
    //                print: "Imprimir"
    //            },
    //            "sProcessing": "Procesando...",
    //            "sLengthMenu": "Mostrar _MENU_ registros por página",
    //            "sZeroRecords": "No se encontraron resultados",
    //            "sEmptyTable": "Ningún dato disponible en esta tabla",
    //            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
    //            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
    //            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
    //            "sInfoPostFix": "",
    //            "sSearch": "Buscar:",
    //            "sUrl": "",
    //            "sInfoThousands": ",",
    //            "sLoadingRecords": "Cargando...",
    //            "oPaginate": {
    //                "sFirst": "Primero",
    //                "sLast": "Último",
    //                "sNext": "Siguiente",
    //                "sPrevious": "Anterior"
    //            },
    //            "oAria": {
    //                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
    //                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
    //            }
    //        }
    //    });
    //}
    //if ($(".dataTables-exampleb").length > 0) {
    //    if (document.getElementsByClassName("dt-buttons").length > 0) {
    //        divButtonss = document.getElementsByClassName("dt-buttons");
    //        divButtonss[0].style.cssFloat = "right";
    //    }
    //}
    ActivaDataTable();
    $(".trabajadorSearch").select2({
        placeholder: "Escribe el RPE del trabajador a buscar",
        theme: "bootstrap4",
        language: {
            noResults: function () {

                return "No hay resultado";
            },
            errorLoading: function () {
                return "No se pudo realizar la consulta";
            },
            searching: function () {

                return "Buscando..";
            }
        },
        ajax: {
            url: urlTrabajadoresSearch,
            contentType: "application/json; charset=utf-8",
            data: function (params) {
                var query =
                {
                    busqueda: params.term,
                };
                return query;
            },
            processResults: function (result) {
                return {
                    results: $.map(result, function (item) {
                        return {
                            id: item.id,
                            text: item.claveNombre,
                            nombre: item.nombre,
                            apellidos: item.apellidos,
                            correo: item.correoElectronico,
                            area: item.area
                        };
                    }),
                };
            }
        }
    });

    $('.trabajadorSearch').on('select2:select', function (e) {
        var data = e.params.data;
        $('#txtNombre').val(data.nombre);
        $('#txtApellidos').val(data.apellidos);
        $('#txtArea').val(data.area);
        $('#txtCorreo').val(data.correo);
        $('#hdfRPE').val(data.text);
        //console.log(data);
    });
    /* Al seleccionar el Rol */
    $(".chkRol").click(function () {
        seleccionaRol(this);
    });
    /* Buscar los elementos seleccionados */
    setTimeout(function () {
        $(".chkRol:checked").each(function (i, ob) {
            seleccionaRol(this);
        });
    }, 1000);

});
function seleccionaRol(elemento) {
    $('#tblPrivilegio').DataTable().search('').columns().search('').draw();
    $('#tablaRol').LoadingOverlay("show");//$('#tablaRol').block({ message: "Por favor espere...", fadeIn: 0, fadeOut: 0, timeout: 0 });

    var id = $(elemento).attr("id");
    var name = $(elemento).attr("name");
    var arrayName = name.split(',');
    var table = $('#tblPrivilegio').dataTable();
    var rows = table._fnGetDataMaster();
    if ($(elemento).is(':checked')) {
        var str = '<input type="hidden" name="listaRol" value="' + id + '" />';
        $("#divRolSeleccionado").append(str);

        //Deshabilita los privilegios que contiene el Rol
        for (var x = 0; x < arrayName.length; x++) {

            for (var i = 0; i < rows.length; i++) {
                var idDataTable = rows[i][0];

                if (idDataTable == arrayName[x]) {
                    $('#tblPrivilegio').DataTable().column(2).search(rows[i][2]).draw();
                    var namePrivilegio = $("#privilegio_" + idDataTable).attr("name");
                    var idPrivilegio = "privilegio_" + idDataTable;

                    var arrayId = idPrivilegio.split('_');
                    idPrivilegio = arrayId[1];
                    if (namePrivilegio == "vacio")
                        namePrivilegio = id;
                    else {
                        namePrivilegio = namePrivilegio + "," + id;
                    }

                    $("#privilegio_" + idDataTable).attr("name", namePrivilegio);
                    $("#privilegio_" + idDataTable).prop("checked", true);
                    $("#privilegio_" + idDataTable).attr("disabled", "disabled");
                    $('#tblPrivilegio').DataTable().column(2).search("").draw();
                }
            };
        }
        $('#tblPrivilegio').DataTable().column(2).search("").draw();
    } else {
        $("#divRolSeleccionado").find("input").each(function (i, ob) {
            if (ob.value == id) {
                ob.remove();
            }
        });
        //Habilita los Privilegios del Rol
        for (var i = 0; i < rows.length; i++) {
            var idDataTable = rows[i][0];
            $('#tblPrivilegio').DataTable().column(2).search(rows[i][2]).draw();
            var namePrivilegio = "";
            var idPrivilegio = "";
            var nombreFinal = "";
            var listaNombreFinal;
            var listaName = [];
            var nomTemp = $("#privilegio_" + idDataTable).attr("name");
            if ((" " + nomTemp + " ").indexOf(" " + "," + " ") !== -1) {
                listaName = $("#privilegio_" + idDataTable).attr("name").split(',');
            } else {
                listaName.push(nomTemp);
            }


            for (var x = 0; x < listaName.length; x++) {
                if (listaName[x] == id) {
                    namePrivilegio = $("#privilegio_" + idDataTable).attr("name");
                    namePrivilegio = namePrivilegio.replace(listaName[x], "");
                    listaNombreFinal = namePrivilegio.split(',');
                    for (var y = 0; y < listaNombreFinal.length; y++) {
                        if (listaNombreFinal[y] != "")
                            nombreFinal += listaNombreFinal[y] + ',';
                    }
                    if (nombreFinal == "") {
                        $("#privilegio_" + idDataTable).attr("name", "vacio");
                        $("#privilegio_" + idDataTable).prop("checked", false);
                        $("#privilegio_" + idDataTable).attr("disabled", false);
                    } else
                        $("#privilegio_" + idDataTable).attr("name", nombreFinal);


                };
            };
            $('#tblPrivilegio').DataTable().column(2).search("").draw();

        };
    }

    $('#tablaRol').LoadingOverlay("hide");//$('#tablaRol').unblock();
}
function SeleccionaTrabajador(t, modal) {
    $('#txtNombre').val(t.nombre);
    $('#txtApellidos').val(t.apellidos);
    $('#txtArea').val(t.area);
    $('#txtCorreo').val(t.correoElectronico);
    $('#hdfRPE').val(t.rpe + " - " + t.nombreCompleto);
    var data = {
        id: t.id,
        text: t.rpe + " - " + t.nombreCompleto,
        nombre: t.nombre,
        apellidos: t.apellidos,
        correo: t.correoElectronico,
        area: t.area
    };

    var newOption = new Option(data.text, data.id, false, true);
    $('#txtRPE').append(newOption).trigger('change');

    if (modal) {
        $('#trabajadoresModal').modal('toggle');
    }
}

function marcaRolesDeUsuario(listaUsuarioRol, lstRolSinPrivilegios) {

    var listaRol = jQuery.parseJSON(listaUsuarioRol);
    var listaRolSinPrivilegio = jQuery.parseJSON(lstRolSinPrivilegios);


    for (var x = 0; x < listaRolSinPrivilegio.length; x++) {

        $(".chkRol").each(function (index) {
            if ($(this).attr("id") == listaRolSinPrivilegio[x].Id) {
                $(this).attr("checked", "checked");
                var str = '<input type="hidden" name="listaRol" value="' + $("#" + listaRolSinPrivilegio[x].Id).attr("id") + '" />';
                $("#divRolSeleccionado").append(str);
            }
        });
    }
    for (var x = 0; x < listaRol.length; x++) {

        $(".chkRol").each(function (index) {
            if ($(this).attr("id") == listaRol[x].rolId) {
                $(this).attr("checked", "checked");
                var str = '<input type="hidden" name="listaRol" value="' + $("#" + listaRol[x].rolId).attr("id") + '" />';
                $("#divRolSeleccionado").append(str);
                marcaPrivilegioEnRol(listaRol[x]);
            }
        });

    }
};

function marcaPrivilegioEnRol(listaRol) {

    $(".ckPrivilegio").each(function (index) {
        if ($(this).attr("id") == ("privilegio_" + listaRol.privilegioId)) {
            var namePrivilegio = $(this).attr("name");
            var idPrivilegio = $(this).attr("id");
            if (namePrivilegio == "vacio")
                namePrivilegio = listaRol.rolId;
            else {
                namePrivilegio = namePrivilegio + "," + listaRol.rolId;
            }

            $(this).attr("name", namePrivilegio);
            $(this).prop("checked", true);
            $(this).attr("disabled", "disabled");
        }
    });
};
function buscar() {
    var valor = $('#busqueda').val();
    $(".ball-pulse").show();
    $.get(urlTrabajadorSearch + "?busqueda=" + valor).always(function (data) {
        //console.log(data);
        $('#target').load(urlTrabajadorSearch + "?busqueda=" + valor, function () {
            $(".ball-pulse").hide();
            ActivaDataTable();
        });
    });
}

function MuestraNumeroErroresPestania(nombrePestania) {
    var totalErrores = $(nombrePestania).find(".field-validation-error").length;
    if (totalErrores > 0) {
        $(nombrePestania + "Error").html("<span class='badge badge-danger ml-auto'>" + totalErrores + "</span>");
    }
    else {
        $(nombrePestania + "Error").html("");
    }
}

function VerificaNumeroErroresPestania() {
    MuestraNumeroErroresPestania("#roles");
    MuestraNumeroErroresPestania("#usuario");
}



function sendForm() {
    var numberOfChecked = $('.chkRol:checked').length;
    $("#nRoles").val(numberOfChecked);
    var validationModel = $("#userData").valid();
    if (validationModel) {
        $("#userData").submit();
    }
}

$.validator.addMethod("validaRoles", function (value, element) {
    try {
        if (value > 0) {
            return true;
        }
        else {
            return false
        };
    }
    catch (err) {
        return false;
    }
}, "Seleccionar al menos un rol.");

function showError(element, message) {
    $(`span[data-valmsg-for="${element}"`).html(`${message}`);
    $(`span[data-valmsg-for="${element}"`).addClass('field-validation-error');
}
function showProps(obj) {
    for (var i in obj) {
        // obj.hasOwnProperty() se usa para filtrar propiedades de la cadena de prototipos del objeto
        if (obj.hasOwnProperty(i)) {
            showError(i, obj[i])
        }
    }
} 

$.validator.setDefaults({
    ignore:"",
    showErrors: function (errorList, errorMap) {
        console.log(errorList)
        showProps(errorList);
        var message = "Se generaron " + this.numberOfInvalids() + " errores. Verificar los campos.";
        var mensaje_dv = '<div id="errorAlert" class="alert alert-danger"><a class="close" data-dismiss="alert">×</a><span>' + message + '</span></div>';
        if (this.numberOfInvalids() > 0) {
            $(".validation-summary-errors").html(mensaje_dv);
            timerRedMessage();
        }
        else {
            $(".validation-summary-errors").html("");
        } 
        VerificaNumeroErroresPestania();
    }
});




$(document).ready(function () {
    //generic Searcher
    $(".trabajadorSearchVC").select2({
        minimumInputLength: 4,
        placeholder: "Escribe el RPE/Nombre del trabajador a buscar",
        language: {
            noResults: function () {

                return "No hay resultado";
            },
            errorLoading: function () {
                return "No se pudo realizar la consulta";
            },
            loadingMore: function () {
                return 'Cargando más resultados...';
            },
            searching: function () {

                return "Buscando..";
            },
            inputTooShort: function (e) {
                var falta = parseInt(e.minimum) - e.input.split("").length;
                return "Introduzca " + falta + " o más caracteres";
            }
        },
        ajax: {
            url: urlTrabajadoresSearch,
            type: "POST",
            dataType: "json",
            data: function (params) {
                //console.log(params)
                var page = params.page || 1;
                var tam = 10;
                var skip = page == 1 ? 0 : (page - 1) * tam;
                var query =
                {
                    search: { Value: params.term },
                    draw: page,
                    length: tam,
                    start: skip,
                };
                return query;
            },
            processResults: function (result) {
                console.log('info recibida');
                //console.log(result);
                return {
                    results: $.map(result.data, function (item) {
                        return {
                            id: item.id,
                            rpe: item.rpe,
                            text: item.rpe + ' - ' + item.nombreCompleto,
                            nombre: item.nombre,
                            apellidos: item.apellidos,
                            correo: item.correoElectronico,
                            area: item.area,
                            activo: item.activo
                        };
                    }),
                    pagination: {
                        more: result.recordsFiltered < result.recordsTotal
                    }
                };
            }
        }
    });

});
//----------------------
//a callback must be defined in the view that requires it, see IncidenteConLesionCreate.cshtml, Scripts section
function LlenarDatosTrabajadorSelect2(e, NombreApellidoJunto = true, trabajadorCallback = null) {

    var data = e.params.data;
    if (NombreApellidoJunto) {
        $('.modalTxtNombre').val(data.nombre + " " + data.apellidos);
    }
    else {
        $('.modalTxtNombre').val(data.nombre);
        $('.modalTxtApellidos').val(data.apellidos);
    }
    $('.modalTxtId').val(data.id);
    $('.modalTxtArea').val(data.area);
    $('.modalTxtCorreo').val(data.correo);
    $('.modalHdfRPE').val(data.text);
    //console.log(data);

    if (trabajadorCallback != null) {
        trabajadorCallback(data);
    }
}
function SeleccionaTrabajadorVC(t, modal, NombreApellidoJunto = true) {
    //if no callback, then standard process
    if (NombreApellidoJunto) {
        $('.modalTxtNombre').val(t.nombreCompleto);
    }
    else {
        $('.modalTxtNombre').val(t.nombre);
        $('.modalTxtApellidos').val(t.apellidos);
    }
    $('.modalTxtId').val(t.id);
    $('.modalTxtArea').val(t.area);
    $('.modalTxtCorreo').val(t.correoElectronico);
    $('.modalHdfRPE').val(t.rpe);
    var data = {
        id: t.id,
        text: t.rpe + " - " + t.nombreCompleto,
        nombre: t.nombre,
        apellidos: t.apellidos,
        correo: t.correoElectronico,
        area: t.area
    };

    var newOption = new Option(data.text, data.id, false, true);
    $('#txtRPE').append(newOption).trigger('change');

    if (modal) {
        $('#trabajadoresModal').modal('toggle');
    }
}

function GetTrabajadores(e, urlAction) {
    if (e.which == 9) { //when tab is pressed
        //console.log("entra")
        $.ajax({
            type: 'GET',
            url: urlAction + this.value,
            dataType: 'json',
            success: function (data) {

                data.apellidos = data.apellidoPaterno + " " + data.apellidoMaterno;
                SeleccionaTrabajadorVC(data, false);
                //$("#nombreCompleto").val(data.nombreCompleto)
            }
        });
    }
}
//----------------------