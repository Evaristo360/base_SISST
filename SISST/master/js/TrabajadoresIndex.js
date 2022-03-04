function buscar() {
    var valor = $('#busqueda').val();
    $(".ball-pulse").show();
    $.get(urlTrabajadorSearch + "?busqueda=" + valor).always(function (data) {
        
        $('#target').html(data);
        $(".ball-pulse").hide();
        ActivaDataTable();
    });
}

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