/* 
 * medidas.js
 * Funciones para la manipulación de los objetos DOM de la UI para 
 * la edición de nuevas correcciones SST en la ventana edición de actas de programas
 * 
 * Desarrollado por
 *  Juan Miguel González Castro
 *  Enero 2022
 * 
 * */


/* agregarEditarCorrecccion
 * Agerga la medida correctiva a una tabla, esto incluye la generación de los objetos ocultos para el 
 * modelo
 */
function agregarEditarCorrecccion(
    prefijoId = "Acta_MedidasActa",
    prefijoName = "Acta.MedidasActa",
    tabla = "tblMedidasVigentes"
) {
    var indice = parseInt($("#hdfIndiceMedidas").val());

    $("#hdfIndiceMedidas").val(indice + 1);

    var tbody = document.getElementById(tabla).getElementsByTagName("tbody")[0];
    var newRow = tbody.insertRow();
    newRow.setAttribute("id", "tr_n_" + indice);

    var descripcionCell = newRow.insertCell(),
        riesgoCell = newRow.insertCell(),
        responsableCell = newRow.insertCell(),
        //atencionCell = newRow.insertCell(),
        accionCell = newRow.insertCell()

    // hiddens en la columna descripción
    descripcionCell.innerText = getText("identificacion");
    descripcionCell.appendChild(createHidden(prefijoId, prefijoName, indice, "id"));
    descripcionCell.appendChild(createHidden(prefijoId, prefijoName, indice, "fechaIngreso"));
    descripcionCell.appendChild(createHidden(prefijoId, prefijoName, indice, "idCatalogoOrigen"));
    descripcionCell.appendChild(createHidden(prefijoId, prefijoName, indice, "ordenTrabajo"));
    descripcionCell.appendChild(createHidden(prefijoId, prefijoName, indice, "listaNivelAtencion"));
    descripcionCell.appendChild(createHidden(prefijoId, prefijoName, indice, "identificacion"));
    descripcionCell.appendChild(createHidden(prefijoId, prefijoName, indice, "listaImpacto"));
    descripcionCell.appendChild(createHidden(prefijoId, prefijoName, indice, "listaProbabilidad"));
    descripcionCell.appendChild(createHidden(prefijoId, prefijoName, indice, "listaRiesgoPotencial"));
    descripcionCell.appendChild(createHidden(prefijoId, prefijoName, indice, "correccion"));
    descripcionCell.appendChild(createHidden(prefijoId, prefijoName, indice, "idResponsableMedida"));
    //descripcionCell.appendChild(createHidden(prefijoId, prefijoName, indice, "fechaAtencion"));
    descripcionCell.appendChild(createHidden(prefijoId, prefijoName, indice, "agregarMedida", "deleteFlag"));

    riesgoCell.innerText = getText("listaRiesgoPotencial");
    responsableCell.innerText = getText("NombreResponsableMedida");
    //atencionCell.innerText = getText("fechaAtencion");

    accionCell.appendChild(createLink("javascript:removerMedida('tr_n_" + indice + "', 'Corrección de SST');", "far fa-trash-alt pr-2"));
    accionCell.setAttribute("class", "text-right");   

    eliminarMedida("tr_Vigente");

    $("#modalCorrecciones").modal("hide");
}

/**
 * eliminarMedida
 * Elimina, tras confirmación, la medida indicada
 * param trId
 * param titulo
 */
function eliminarMedida(trId, tabla = "tblMedidasVigentes") {
    var row = $("#" + trId);
    row.find(".deleteFlag").val(false);
    row.hide();

    // Pendiente, validar que se tengan medidas, caso contrario volver a 
    // pintar mensaje de no se tienen.
    // Platicar con Evaristo y Omar sobre alternativas
    var hay = false;
    $("#" + tabla + " tbody tr").each(function () {
        hay = hay || $(this).is(':visible');
    });

    if (!hay) {
        // mostrar  renglon faltante
        $("#" + tabla + " tbody tr").each(function () {
            if ($(this).hasClass("tr_Vigente")) {
                $(this).show();
            }
        });
    //    $("#" + tabla + " tbody ").append("<tr id=\"tr_Vigente\">" +
    //        "<td colspan=\"4\"><h4><span class=\"text-warning text-center\">No se tienen correcciones de SST.</span></h4></td>" +
    //        "</tr> ");
    }
}

/**
 * removerMedida
 * Elimina, tras confirmación, la medida indicada
 * param trId
 * param titulo
 */
function removerMedida(trId, titulo, tabla = "tblMedidasVigentes") {
    if (trId.includes("Pendiente") | trId.includes("Vigente"))
        eliminarMedida(trId);
    else {
        swal({
            title: "¿Está seguro de eliminar la corrección de SST?",
            text: "Se eliminará la corrección de SST " + titulo + " de manera permanente, por lo que será imposible su recuperación. \n ",
            icon: "warning",
            buttons: {
                cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true },
                confirm: { text: "¡Sí, eliminarla!", value: !0, visible: !0, className: "bg-danger", closeModal: true }
            }
        }).then(function (e) {
            if (e) {
                eliminarMedida(trId, tabla);
            }
            swal.close();
        });
    }
}

/**
 * setFechaReprogramacion
 * Actualiza la fecha de reprogramación para una medida pendiente de atención
 * param {any} trId
 */
function setFechaReprogramacion(trId, fecha) {
    var row = $("#" + trId);

    row.find(".fechaReprogamacionFlag").val(fecha);
    row.find(".fechaReprogramacion-sst").text(fecha)
    row.find(".deleteFlag").val(true);

    $("#modalReprogramacion").modal("hide");
}


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

/* 
 * utils.js
 * Funciones de apoyo para la edición de correcciones y vocales 
 * la edición de la ventana actas de programas
 * 
 * Desarrollado por
 *  Juan Miguel González Castro
 *  Enero 2022
 * 
 * */


/**
 * createHidden 
 * genera objeto de tipo oculto (<hidden>)
 * param prefijoID
 * param indici
 * param objeto
 */
function createHidden(prefijoId, prefijoName, indice, objeto, clase = "") {
    var hidden = document.createElement("input"),
        objName = $("#" + objeto).attr("Name");

    hidden.setAttribute("id", prefijoId + "_" + indice + "__" + objName);
    hidden.setAttribute("name", prefijoName + "[" + indice + "]." + objName);
    hidden.setAttribute("type", "hidden");
    hidden.setAttribute("value", $("#" + objeto).val());

    if (clase.length > 0) hidden.setAttribute("class", clase);

    return hidden;
}

/**
 * createHidden 
 * genera objeto de tipo oculto (<hidden>)
 * param prefijoID
 * param indici
 * param objeto
 */
function createHiddenText(prefijoId, prefijoName, indice, objeto, valor, clase = "") {
    var hidden = document.createElement("input");

    hidden.setAttribute("id", prefijoId + "_" + indice + "__" + objeto);
    hidden.setAttribute("name", prefijoName + "[" + indice + "]." + objeto);
    hidden.setAttribute("type", "hidden");
    hidden.setAttribute("value", valor);

    if (clase.length > 0) hidden.setAttribute("class", clase);

    return hidden;
}

/**
 * createLabel 
 * genera objeto de tipo etiqueta (<label>)
 * param prefijoID
 * param indici
 * param objeto
 */
function createLabel(prefijoId, indice, objeto) {
    var label = document.createElement("label"),
        texto = getText(objeto);

    label.setAttribute("for", prefijoId + "_" + indice + "__" + objeto);
    label.setAttribute("name", prefijoId + "[" + indice + "]." + objeto);
    label.setAttribute("id", prefijoId + "_" + indice + "__" + objeto);

    label.setAttribute("class", "form-label");
    label.setAttribute("readonly", "readonly");

    label.innerHTML = texto;
    label.value = texto;

    return label;
}

/**
 * getText
 * obtiene el contenido texto de objeto
 * param objeto
 */
function getText(objeto) {
    var obj = $("#" + objeto),
        texto = "";

    if (obj[0].tagName == "SELECT")
        texto = $("#" + objeto + " option:selected").text();
    else
        texto = $("#" + objeto).val();

    return texto;
}

/**
 * createLink
 * genera objeto de tipo liga (<a>)
 * param href
 * param icono
 */
function createLink(href, icono) {
    var link = document.createElement("a");
    link.setAttribute("href", href);
    link.innerHTML = "<i class=\"" + icono + "\"></i>";

    return link;
}
