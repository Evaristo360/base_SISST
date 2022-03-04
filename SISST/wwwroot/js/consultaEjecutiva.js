function loadConsulta() {
   
    $("#F_idDireccion").val($(".idDireccion").val())
    $("#F_idSubdireccion").val($(".idSubdireccion").val())
    $("#F_idGerencia").val($(".idGerencia").val())
    $("#F_idSubgerencia").val($(".idSubgerencia").val())
    $("#F_idCT").val($(".idCT").val())
    $("#F_listaCTsConsultas").val($("#ListaCTsConsulta").val())

    $("#F_idEvento").val($("#idEvento").val())
    $("#F_anios").val($("#Anio").val());
    $("#F_location").val($("#location").val())
    $("#F_showTable").val(1)

    var mostrarSustituidas = false;
    if ($('.valueSustituidas').is(":checked")) {
        mostrarSustituidas = true;
    }

    $("#F_valueSustituidas").val(mostrarSustituidas)

    //F13 Filters
    $("#F_idEstado").val($("#idEstado").val())
    $("#F_idOrigen").val($("#idOrigen").val())
    $("#F_idEjecutor").val($("#idEjecutor").val());
    $("#F_idElaborador").val($("#idElaborador").val())
    var mostrarCerradas= false
    if ($('.onlyClose').is(":checked")) {
        mostrarCerradas = true;
    }
    $("#F_onlyClose").val(mostrarCerradas)

    var mostrarEnProceso = false;
    if ($('.MostrarProcesoNoTrabajo').is(":checked")) {
        mostrarEnProceso = true;
    }
    $("#F_MostrarProcesoNoTrabajo").val(mostrarEnProceso)


    //RL Filters
    $("#F_idPeriodo").val($("#idPeriodo").val())
    $("#F_fechaInicio").val($("#fechaInicio").val())
    $("#F_fechaFin").val($("#fechaFin").val())
    $("#F_idEstado").val($("#idEstadoRL").val())
    $("#F_idTipo").val($("#idTipoRL").val())
    $("#F_idEvidencia").val($("#idEvidenciaRL").val())
    $("#F_idObligacion").val($("#idObligacionRL").val());
    $("#F_idVerificacion").val($("#idVerificacionRL").val())
    $("#F_idImportancia").val($("#idImportanciaRL").val())

    $.LoadingOverlay("show");
    $("#formCunsulta").submit();
}
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
});
// Nueva función para separa la lista de CTs y la lista de filtros
// en el viewComponent ConsultaEjecutiva
// FEG - JMGC - PRME
function submitConsulta() {

    $("#F_idDireccion").val($(".idDireccion").val())
    $("#F_idSubdireccion").val($(".idSubdireccion").val())
    $("#F_idGerencia").val($(".idGerencia").val())
    $("#F_idSubgerencia").val($(".idSubgerencia").val())
    $("#F_idCT").val($(".idCT").val())
    $("#F_listaCTsConsultas").val($("#ListaCTsConsulta").val())

    //$("#F_idEstado").val($(".idEstado").val())
    //$("#F_idNivelPrioridad").val($(".idNivelPrioridad").val())

    $.LoadingOverlay("show");
    $("#submitConsulta").submit();
}