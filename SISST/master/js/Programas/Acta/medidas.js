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

