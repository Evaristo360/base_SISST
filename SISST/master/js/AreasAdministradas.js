$(document).ready(function () {

    $('.select2').select2({
        placeholder: 'Seleccione una opción'
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
                var falta = parseInt(e.minimum) - e.input.split("").length;
                return "Escribe el nombre o clave del centro de trabajo a buscar";
            }
        },
        ajax: {
            url: urlAreaSearch,
            contentType: "application/json; charset=utf-8",
            data: function (params) {
                var query =
                {
                    busqueda: params.term
                };
                return query;
            },
            processResults: function (result) {
                console.log("Areasadministradas=>",result)
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
    $('#area').on('select2:select', function (e) {
        var data = e.params.data;
        $("#idAreaCreate").val(data.id);
        console.log($("#idAreaCreate").val());
    });

    
});
function AgregarArea() {
    if ($("#idAreaCreate").val() != "") {
        $.LoadingOverlay("show");
        $('#frmCreate').submit();
    }
}
// Modal for deleteConfirmation
function Eliminar(idArea) {
    $("#idAreaDelete").val(idArea);
    $.LoadingOverlay("hide");//$.unblockUI();
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
}