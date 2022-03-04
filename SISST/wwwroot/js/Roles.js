$(document).ready(function () {
    $("#btnAceptar").click(function () {

        var tablePrivilegio = $('#tblPrivilegio').dataTable();
        var rowPrivilegio = tablePrivilegio._fnGetDataMaster();
        $('#tblPrivilegio').DataTable().search(" ");
        for (var i = 0; i < rowPrivilegio.length; i++) {

            $('#tblPrivilegio').DataTable().search(" ");
            var id = rowPrivilegio[i][0];
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
});
