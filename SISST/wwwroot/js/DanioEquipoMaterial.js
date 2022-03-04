/*
 *
 * general Incidente Contratista functions
 *
 * */
var validateForm = false;

function IsGuardadoParcial() {
    $('.GuardarParcial').on('click', function (e) {
        CleanErrors('#formDanioEquipoMaterial');
        $('#GuardadoParcial').val(true);

        //partial save only requires Trabajador and Fecha Incidente
        $('#formDanioEquipoMaterial').data('validator').settings.ignore = ".guardadoTotal";
        validateForm = true;
        var validationModel = $("#formDanioEquipoMaterial").valid();
        if (!validationModel) {
            validateForm = false;
        }
    });
}
function IsGuardadoTotal() {
    $('.GuardarTotal').on('click', function (e) {
        verificaNumeroRowsCausas();
        verificaNumeroRowsNecesidades();
        CleanErrors('#formDanioEquipoMaterial');
        $('#GuardadoParcial').val(false);
        //check number of Turnos Inputs rendered
        ValidateInputsNumeroTrabajadoresPorTurno();
        //check Trabajo Horas Extra
        ValidateHorasExtraInputs();
        $('#formDanioEquipoMaterial').data('validator').settings.ignore = ".trabajadorSearchVC, .ignoreValidation";
        validateForm = true;
        var validationModel = $("#formDanioEquipoMaterial").valid();
        if (!validationModel) {
            validateForm = false;
        }
    });
}

/*
 *
 * init Incidente Contratista functions
 *
 * */

function InitSelect2() {
    $.fn.select2.defaults.set('language', 'es');
    $.fn.select2.defaults.set('allowClear', true);
    $.fn.select2.defaults.set('createTag', function () {
        // Disable tagging
        return null;
    });
    //datos trabajador tab
    $("#RamaActividad").select2({ width: '100%' });
    $("#IdDepartamento").select2({ width: '100%' });

    //descripcion tab
    $("#TiposContacto").select2({ tags: true, width: '100%' });
    $("#FuentesDanio").select2({ tags: true, width: '100%' });
    $("#SitioDelDanio").select2({ tags: true, width: '100%' });

    //used in IncidenteConLesionUpdate
    $('#CriteriosLesion').on("select2:close", function (e) {
        // the selected values
        var vals = $(this).select2("val");

        //no aplica value
        var noAplicaVal = "87";
        var disableAll = false;

        $.each(vals, function (index, value) {
            console.log(value);
            if (noAplicaVal == value && e.type == "select2:unselecting") {
                disableAll = false;
                $('#CriteriosLesion').val('');
            }
            else if (noAplicaVal == value) {
                disableAll = true;
                $('#CriteriosLesion').val(value);
            }
        });

        // loop trough all the values
        if (disableAll)
            $('#CriteriosLesion').find('option[value!=' + noAplicaVal + ']').attr('disabled', 'disabled');
        else
            $('#CriteriosLesion').find('option').removeAttr('disabled');

        //$(this).select2("destroy");
        $(this).select2({ tags: true, width: '100%' });
    });

    //used in IncidenteConLEsionCreate
    $('#CriteriosLesion').on('select2:select select2:unselecting', function (e) {
        // the selected values
        var vals = $(this).select2("val");

        //no aplica value
        var noAplicaVal = "87";
        var disableAll = false;

        $.each(vals, function (index, value) {
            console.log(value);
            if (noAplicaVal == value && e.type == "select2:unselecting") {
                disableAll = false;
                $('#CriteriosLesion').val('');
            }
            else if (noAplicaVal == value) {
                disableAll = true;
                $('#CriteriosLesion').val(value);
            }
        });

        // loop trough all the values
        if (disableAll)
            $('#CriteriosLesion').find('option[value!=' + noAplicaVal + ']').attr('disabled', 'disabled');
        else
            $('#CriteriosLesion').find('option').removeAttr('disabled');

        //$(this).select2("destroy");
        $(this).select2({ tags: true, width: '100%' });
    });

    //causas y necesidades
    $('#ListCausa').select2({ width: '100%' });
    $('#ListNecesidad').select2({ width: '100%' });
}

function CommonDanioEquipoMaterialSetup() {
    //datos trabajador tab
    //callback for Datos Trabajador searcher
    $('#DatosTrabajadorSearcher.trabajadorSearchVC').on('select2:select', function (e) {
        var trabajadorCallback = GetFullTrabajadorByRPE;
        LlenarDatosTrabajadorSelect2(e, true, trabajadorCallback);
    });
    //callback for Causas Necesidades Modal
    $('#CausaNecesidadSearcher.trabajadorSearchVC').on('select2:select', function (e) {
        var trabajadorCallback = FillTrabajadorResponsable;
        LlenarDatosTrabajadorSelect2(e, true, trabajadorCallback);
    });
    //callback for Necesidades Modal
    $('#NecesidadSearcher.trabajadorSearchVC').on('select2:select', function (e) {
        var trabajadorCallback = FillTrabajadorResponsableNecesidad;
        LlenarDatosTrabajadorSelect2(e, true, trabajadorCallback);
    });

    //centro trabajo tab
    $('#CentroTrabajo').val($('#IDCentroTrabajo option:selected').text()); //comes from the user who is registering it
    ShowTurnosGivenList();

    //datos Incidente Tab
    // Hora timepicker init
    $(function () {
        $('.bs-timepicker').timepicker();
    });

    $("#btnAddTrabajador").click(function () {
        AddTrabajadorPresenciaEvento()
    });
    DeleteTrabajadorPresenciaEvento();

    //for evaluacion tab
    ImpactoProbabilidadRiesgo("", RiesgoSuffix = "List");
    ImpactoProbabilidadRiesgoCalcula("", RiesgoSuffix = "List");

    //for causas & evaluacion
    if (urlCausaNecesidad.length == 0)
        throw "URL para obtener Lista de Causas/Necesidades no está definida."
    PopulateListCausa(urlCausaNecesidad);
    PopulateListNecesidad(urlCausaNecesidad);
    /* Inicializa el calculo de Select de Causas y Necesidades */
    $("#RiesgoPotencialList").bind("change", function () {
        $('#RiesgoPotencial').val($("#RiesgoPotencialList").val());
    });

    ImpactoProbabilidadRiesgo("Causas");
    ImpactoProbabilidadRiesgo("Necesidades");
    CausasDevuelveFormularioInicializa();
    NecesidadesDevuelveFormularioInicializa();

    //resizing when creating new
    $('#causasIncidentesModal').on('shown.bs.modal', function (e) {
        ResizeTextArea();
    })
    $('#necesidadesIncidentesModal').on('shown.bs.modal', function (e) {
        ResizeTextArea();
    })

    //edit causas
    $('.tablaCausas').on('click', 'button.EditCausaNecesidad', function () {

        var row = $(this).closest("tr");
        var tableId = $(this).attr('data-targetobject');
        var modalId = $(this).attr('data-target');
        var btnType = $(this).attr("data-type");
        var btnLabel = $(this).attr("data-label");
        var idLabel = "#LabelCausa";
        var idlist = "#ListCausa";

        //toggle buttons
        $(".btnGuardarCausa").hide();
        $(".btnEditarCausa").show();
        $('#DataTypeCausa').val(btnType);

        //Boton cerrar valida las causas
        enModalCausasNecesidades = true;
        $(".validation-summary-errors-modal-causas").html("");
        $("#causasIncidentesModalForm .field-validation-error").html("");

        $(".desbloquearFormulario").bind("click", function () {
            enModalCausasNecesidades = false;
            verificaNumeroRowsCausas();
        });

        changeTitleModalNecesidades(btnLabel, 1);

        EditModalCausasNecesidades(row, tableId, modalId, btnType, btnLabel, idLabel, idlist, urlCausaNecesidad,
            EditCausas
        );

    });
    //edit necesidades
    $('.tablaNecesidades').on('click', 'button.EditCausaNecesidad', function () {
        var row = $(this).closest("tr");
        //$(".validation-summary-errors-modal-causas").html("");
        var tableId = $(this).attr('data-targetobject');
        var modalId = $(this).attr('data-target');
        var btnType = $(this).attr("data-type");
        var btnLabel = $(this).attr("data-label");
        var idLabel = "#LabelNecesidad";
        var idlist = "#ListNecesidad";

        //toggle buttons
        $(".btnGuardarNecesidad").hide();
        $(".btnEditarNecesidad").show();
        $('#DataTypeNecesidad').val(btnType);


        //Boton cerrar valida necesidades
        enModalCausasNecesidades = true;
        $(".validation-summary-errors-modal-causas").html("");
        $("#causasIncidentesModalForm .field-validation-error").html("");

        $(".desbloquearFormulario").bind("click", function () {
            enModalCausasNecesidades = false;
            verificaNumeroRowsNecesidades();
        });

        changeTitleModalNecesidades(btnLabel, 0);

        EditModalCausasNecesidades(row, tableId, modalId, btnType, btnLabel, idLabel, idlist, urlCausaNecesidad,
            EditNecesidades
        );
    });

    //delete causas
    $('.tablaCausas').on('click', 'button.DeleteCausaNecesidad ', function () {
        var row = $(this).closest("tr");
        //toggleDeleteFlag
        row.find(".deleteFlag").val(true);
        row.hide();
        verificaNumeroRowsCausas();
    });

    //delete necesidades
    $('.tablaNecesidades').on('click', 'button.DeleteCausaNecesidad ', function () {
        var row = $(this).closest("tr");
        //toggleDeleteFlag
        row.find(".deleteFlag").val(true);
        row.hide();
        verificaNumeroRowsNecesidades();
    });
}
/*
 *
 * validation Incidente Contratista functions
 *
 * */


jQuery.extend(jQuery.validator.messages, {
    required: "Campo requerido",
    number: "Por favor, ingrese un número válido.",
    rangelength: jQuery.validator.format("Por favor ingrese un valor de tamaño entre {0} y {1}."),
    range: jQuery.validator.format("Por favor ingrese un valor entre {0} y {1}."),
    maxlength: jQuery.validator.format("Por favor ingrese máximo {0} caracteres."),
    minlength: jQuery.validator.format("Por favor ingrese mínimo {0} caracteres"),
    max: jQuery.validator.format("Por favor ingrese un valor menor o igual a {0}."),
    min: jQuery.validator.format("Por favor ingrese un valor mayor o igual a {0}.")
});

//Validation configuration
$.validator.setDefaults({
    ignore: '.trabajadorSearchVC',
    showErrors: function (errorMap, errorList) {
        if (validateForm) {
            console.log("=>", errorMap, errorList);
            var message = "Se generaron " + this.numberOfInvalids() + " errores. Verificar los campos.";
            var mensaje_dv = '<div id="errorAlert" class="alert alert-danger"><a class="close" data-dismiss="alert">×</a><span>' + message + '</span></div>';
            //alert(enModalCausasNecesidades );
            if (enModalCausasNecesidades == false) {
                console.log("PRIMER IF")
                if (this.numberOfInvalids() > 0) {
                    $(".validation-summary-errors").html(mensaje_dv);
                    timerRedMessage();
                }
                else {
                    $(".validation-summary-errors-modal-causas").html("");
                }
            } else {
                console.log("entra al else")
                if (this.numberOfInvalids() > 0) {
                    $(".validation-summary-errors-modal-causas").html(mensaje_dv);
                    timerRedMessage();
                }
                else {
                    $(".validation-summary-errors-modal-causas").html("");
                }
            }
            this.defaultShowErrors(); //uncomment to see all errors
            if (enModalCausasNecesidades == false) {
                VerificaNumeroErroresPestania();
            }
        } else {
            console.log("validate no fue activado por button")
            this.defaultShowErrors(); //uncomment to see all errors
            if (enModalCausasNecesidades == false) {
                VerificaNumeroErroresPestania();
            }
        }
    },
    highlight: function (element) {
        $(element).addClass('has-error');
    },
    unhighlight: function (element) {
        $(element).removeClass('has-error');
    },
});

//document ready for cleaning any errors
$(document).ready(function () {


    //clear validation errors
    $('#formDanioEquipoMaterial').find("[data-valmsg-summary=true]")
        .removeClass("validation-summary-errors")
        .addClass("validation-summary-valid")
        .find("ul").empty();
    verificaNumeroRowsCausas();
    verificaNumeroRowsNecesidades();

    $("#CostosFinanciero").on('change', function (e) {
        var optionSelected = $(this).find("option:selected");
        var idSelected = optionSelected.val();
        console.log("seleccionado", idSelected);

        if (idSelected == 416) {
            $("#option_yes").prop("checked", true);
            $("#option_no").prop("checked", false);
            $("#DanioAltoImpacto").val(true);

        } else {
            $("#option_yes").prop("checked", false);
            $("#option_no").prop("checked", true);
            $("#DanioAltoImpacto").val(false);
        }
    });

});

function CleanErrors(formId) {
    //clean all span errors
    $('.field-validation-error').each(function (i, obj) {
        $(this).find('span').remove();
    });
    //clear validation errors
    $('#formDanioEquipoMaterial').find("[data-valmsg-summary=true]")
        .find("ul").empty()
}

