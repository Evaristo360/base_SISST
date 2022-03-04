$(document).ready(function () {
    $('.select2').select2({
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

    if ($("#hdfId"))
    var id = $("#hdfId").val();


    $(".areaSearch").select2({
        minimumInputLength: 1,
        placeholder: "Escribe el nombre o clave del centro de trabajo a buscar",
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
                return "Escribe el nombre o clave del centro de trabajo a buscar";
            }
        },
        ajax: {
            url: urlAreasSearch,
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
                            text: item.claveNombre
                        };
                    }),
                };
            }
        }
    });

    $(".areaSearchEdit").select2({
        minimumInputLength: 1,
        placeholder: "Escribe el nombre o clave del centro de trabajo a buscar",
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
                return "Escribe el nombre o clave del centro de trabajo a buscar";
            }
        },
        ajax: {
            url: urlAreasSearch,
            contentType: "application/json; charset=utf-8",
            data: function (params) {
                var query =
                {
                    busqueda: params.term,
                    id: id
                };
                return query;
            },
            processResults: function (result) {
                return {
                    results: $.map(result, function (item) {
                        return {
                            id: item.id,
                            text: item.claveNombre
                        };
                    }),
                };
            }
        }
    });

});
function seleccionar(identificador, nombre) {
    var idHdf = $("#hdfSeleccionado").val();
    $("#" + idHdf).empty();
    var data = {
        id: identificador,
        text: nombre
    };
    var newOption = new Option(data.text, data.id, true, true);
    $("#" + idHdf).append(newOption).trigger('change');

    $('#mdlAreas').modal('toggle');
}