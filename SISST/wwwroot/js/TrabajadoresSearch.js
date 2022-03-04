
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