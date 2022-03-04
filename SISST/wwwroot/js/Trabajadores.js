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

    $("#area").select2({
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
            url: urlAreaSearch,
            contentType: "application/json; charset=utf-8",
            data: function (params) {
                var idProceso=$('#idProceso').find("option:selected").val()
                var query =
                {
                    busqueda: params.term,
                    id:idProceso
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
    var today = new Date();
    var mStartDate = new Date(today.getFullYear(), today.getMonth(), today.getDate() - 1);

    $('.date-picker').datepicker({
        todayBtn: false,
        defaultDate: mStartDate,
        format: "dd/mm/yyyy",
        starView: "days",
        minViewMode: "days",
        endDate: mStartDate
    }).on("hide", function (e) {
        var date_check = $(this).datepicker("getDate");
        var true_false_date = moment(date_check).isValid();
        if (true_false_date == false) {
            $(this).datepicker('setDate', $('#from_date_hidden').val());
        }
        $('#from_date_hidden').val(moment($(this).datepicker("getDate")).format("DD/MM/YYYY"));
    });

    $('#btnFechaNacimiento').click(function () {
        $('#fechaNacimiento').datepicker("show");
    });

    $('#btnFechaIngresoCFE').click(function () {
        $('#fechaIngresoCFE').datepicker("show");
    });

    $('#btnFechaIngresoPuesto').click(function () {
        $('#fechaIngresoPuesto').datepicker("show");
    });

    $("#idProceso").on('change', function (e) {
        $("#area").empty();       
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

function saveChangesEdit() {
    var rpe = $("#rpeTextBox").val();
    if (rpeInitial != rpe) {
        swal({
            title: "¿Está seguro de cambiar el RPE del trabajador?",
            text: "Se actualizará el RPE del trabajador",
            icon: "warning",
            closeModal: false,
            closeOnClickOutside: false,
            buttons: [{
                text: "No",
                value: false,
                visible: true,
                className: "btn btn-outline-dark btn-default",
                closeModal: true,
            },{
                    text: "Sí, deseo camiar el RPE del trabajador",
                    value: true,
                    visible: true,
                    className: "btn btn-info",
                    closeModal: true

                }]

        }).then(value => {
            if (value) {
                $("#saveChanges").submit();
            }
        });
    } else {
        $("#saveChanges").submit();
    }
}