
function countChecks() {
    var count = $('.dataTable-Movimientos :checkbox:checked').length;
    return count;
}

function confirmaEliminar() {    
    var cuenta = countChecks();
    if (cuenta <= 0) {
        swal("Aviso", "Debe seleccionar al menos un registro de la bitácora!", "error");
        return false;
    }
    var arrLista = [];
    $('.dataTable-Movimientos :checkbox:checked').each(function () {
        arrLista.push(this.value);
    });
    $.LoadingOverlay("hide");
    swal({
        title: "Eliminar registros de la bitácora",
        text: "Los registros seleccionados serán eliminados de forma permanente. ¿Desea continuar? \n ",
        icon: "warning",
        buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, eliminarlos!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

    }).then(function (e) {
        if (e) {            
            /*-----*/
            $.ajax({
                url: urlEliminar,
                type: 'post',
                dataType: "json",
                async: false,
                data: { ids: arrLista },
                success: function (resultado) {
                    if (resultado.correcto == "true") {
                        swal({
                            title: "Eliminar registros de la bitácora",
                            text: "Los registros fueron eliminados exitosamente",
                            icon: "warning",
                            buttons: {  confirm: { text: "Aceptar", value: !0, visible: !0, className: "bg-danger", closeModal: true } }
                        }).then(function (e) {
                            location.href = urlIndexBitacora;
                        });
                    }
                    else {
                            swal("Eliminar registros de la bitácora", "Ha fallado la eliminación de registros", "error");
                         }                    
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    if (thrownError == "Not Found")
                        swal("Eliminar registros de la bitácora", "No se ha encontrado el recurso", "error");
                    else
                        swal("Eliminar registros de la bitácora", "Ha ocurrido un error al intentar eliminar", "error");
                }
            });//end ajax
        }
        else {
            swal("Eliminar registros de la bitácora", "Se ha cancelado la eliminación :)", "warning");
        }
        /*-----*/
    });
}
$(document).ready(function () {
    $('#select_all').change(function () {
        var checkboxes = $(this).closest('form').find(':checkbox');       
        checkboxes.prop('checked', $(this).is(':checked'));
    });

    var today = new Date();
    var mStartDate = new Date(today.getFullYear(), today.getMonth(), today.getDate());
    $('.date-picker').datepicker({
        todayBtn: true,
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
       
    $('#comboIdUsuario.trabajadorSearch').on('select2:select', function (e) {
        var trabajadorCallback = FillTrabajador;
        LlenarDatosTrabajadorSelect2(e, true, trabajadorCallback);
    });
    function FillTrabajador(data) {
        var id = data.id;
        var nombre = data.text;        
        //asignar valores a los campos
        $('#idUsuario').val(id);
        $('#txtNombre').val("");
        $('#txtNombre').val(nombre);
    }
});