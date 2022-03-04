/*
 * vocales.js
 * Funciones para la manipulación de los objetos DOM de la UI para
 * la edición de los vocales en la ventana edición de actas de programas
 *
 * Desarrollado por
 *  Juan Miguel González Castro
 *  Enero 2022
 *
 * */


/* eliminarVocal
 * elimina el vocal de la tabla correspondiente
 *
 * */
function eliminarVocal(idRenglonVocal, tipoVocal) {
    var idTabla = "#tbl" + tipoVocal
    var numeroVocales = 0;
    var tr = $("#" + idRenglonVocal);

    tr.find(".deleteFlag").val(true);
    tr.removeClass("activo");
    tr.hide();

    // Se actualiza el tota de vocales en función del tipo de
    if (tipoVocal == "CFE") {
        var numeroVocales = $(".tipo-CFE").length;
        $("#numeroVocalesCFE").focus();
        $("#numeroVocalesCFE").val(numeroVocales);
        $("#numeroVocalesSuterm").focus();
    }
    else {
        var numeroVocales = $(".tipo-SUTERM").length;
        $("#numeroVocalesSuterm").focus();
        $("#numeroVocalesSuterm").val(numeroVocales);
        $("#numeroVocalesCFE").focus();
    }

    if (numeroVocales == 0) {
        // agregar primer renglon vacío
        $(idTabla + " tbody").append("<tr id=\"0_" + tipoVocal + "\">" +
            "<td colspan=\"2\"><h4><span class=\"text-warning text-center\">No se han registrado vocales.</span></h4></td>" +
            "</tr> ");
    }
}

/**
 * Confirma la eliminación del renglon correspondiente a un vocal.
 * param idRenglonVocal
 */
function removerVocal(idRenglonVocal, tipoVocal) {
    var idRenglon = idRenglonVocal.split("_")[0]; // $("#" + idRenglonVocal);

    if (idRenglon == 0) {
        // Renglón con mensaje de datos vacíos, por ello no requiere confirmación
        eliminarVocal(idRenglonVocal, tipoVocal);
    }
    else {
        swal({
            title: "Vocales del acta de la CSH",
            text: "¿Desea continuar con la eliminación del vocal?",
            icon: "success",
            buttons: {
                cancel: { text: "No", value: 0, visible: !0, className: "", closeModal: true },
                confirm: { text: "¡Sí, eliminar vocal!", value: !0, visible: !0, className: "bg-azul", closeModal: true }
            }
        }).then(function (e) {
            eliminarVocal(idRenglonVocal, tipoVocal);
            swal.close();
        });
    }
}

/**
 * Agrega el peersonal seleccionado a la lista tipoVocal
 * param tipoVocal
 */
function agregarVocal(tipoVocal) {
    var idTabla = "#tbl" + tipoVocal;
    var idPersonal = $("#idVocal" + tipoVocal).val();
    var nombreCompleto = $("#NombreVocal" + tipoVocal).val();
    var idRenglon = tipoVocal + "_" + idPersonal;
    var existe = false;

    if (idPersonal.length > 0) {
        $(".vocales tbody tr").each(function () {
            var activo = $(this).hasClass("activo");

            var id = "_" + $(this).attr("id").split("_")[1];
            if ("_" + idPersonal == id && activo) {
                existe = true;
                $(this).addClass("text-danger");
            }
        });
        if (existe) {
            LaunchErrorModal("El vocal " + nombreCompleto + " ya ha sido agregado previamente");
            $(".vocales tbody tr").removeClass("text-danger");
        }
        else {
            addVocal(idTabla, idPersonal, nombreCompleto, nombreCompleto, idRenglon, tipoVocal);
            removerVocal("0_" + tipoVocal, tipoVocal); // Para el renglón "No se tiene vocales"
        }
    }
    else {
        LaunchErrorModal("Falta seleccionar personal para agregar como vocal");
    }
}

/* 
 * addVocal
 * Agrega vocales a la lista repectiva (tipoVocal) 
 *
 * Desarrollado por
 *  Juan Miguel González Castro
 *  Enero 2022
 * */
function addVocal(idTabla, id, rpe, nombre, idRenglon, tipoVocal) {
    var indice = parseInt($("#lastIndex" + tipoVocal).val());
    indice = isNaN(indice) ? 0 : indice;

    if (id.length == 0 || rpe.length == 0 || nombre.length == 0) return;

    //validate that there is no entry with same RPE
    var existsInTable = false;
    $(idTabla + " tr").each(function () {
        console.log($(this));
        var deleteFlag = $(this).find("input.deleteFlag").val();
        var existingRpe = $(this).find("input.rpeInput").val()

        if (existingRpe == undefined || deleteFlag == undefined)
            return;

        //if False, then returns true. And then, negate it to have the actual flag value
        var toBeDeleted = !(deleteFlag.toLowerCase() == "false");

        if (existingRpe == rpe && !toBeDeleted) {
            existsInTable = true;
        }
    });

    if (existsInTable) {
        toastr.error('El trabajador ya se encuentra dentro de la tabla.');
        return;
    }

    idTabla = idTabla.substring(1);
    var prefijoId = "Acta_Vocales" + tipoVocal,
        prefijoName = "Acta.Vocales" + tipoVocal;
    var tbody = document.getElementById(idTabla).getElementsByTagName("tbody")[0];
    var newRow = tbody.insertRow();
    newRow.setAttribute("id", idRenglon);
    newRow.setAttribute("class", "activo tipo-" + tipoVocal);

    var nameCell = newRow.insertCell(),
        buttonCell = newRow.insertCell();

    // RPE - Nombre
    nameCell.innerText = nombre
    nameCell.appendChild(createHiddenText(prefijoId, prefijoName, indice, "Id", id));
    nameCell.appendChild(createHiddenText(prefijoId, prefijoName, indice, "ToBeDeleted", false, "deleteFlag"));

    //button Delete
    buttonCell.setAttribute("class", "text-right");
    buttonCell.appendChild(createLink("javascript:removerVocal('" + idRenglon + "', '" + tipoVocal + "');", "far fa-trash-alt pr-2"));

    $("#lastIndex" + tipoVocal).val(indice + 1);

    //finally, clear buscador
    $('#searchVocal' + tipoVocal).val('').trigger('change');
}

/**
 * Actualiza los datos del vocal CFE
 * param data
 */
function FillVocalCFE(data) {
    //asignar valores a los campos
    $('#idVocalCFE').val(data.id);
    $("#RPEVocalCFE").val(data.rpe);
    $("#NombreVocalCFE").val(data.text);
}

/**
 * Actualiza los datos del vocal SUTERM
 * param data
 */
function FillVocalSUTERM(data) {
    $('#idVocalSUTERM').val(data.id);
    $("#RPEVocalSUTERM").val(data.rpe);
    $("#NombreVocalSUTERM").val(data.text);
}
