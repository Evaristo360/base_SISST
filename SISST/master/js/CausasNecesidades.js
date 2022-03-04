/*
 *
 * Causas & Necesidades Tabs
 *
 * */


function PopulateListCausa(url) {
    $(".modalCausaNecesidad.causas").click(function () {
        var btnTargetObj = $(this).attr("data-targetObject");
        var btnType = $(this).attr("data-type");
        var btnLabel = $(this).attr("data-label");
        var idLabel = "#LabelCausa";
        var idlist = "#ListCausa";
        var urlListCausasNecesidades = url + "?option=" + btnType;
        $('#modalType').val(btnTargetObj);
        $('#DataTypeCausa').val(btnType); //to get actual data Type (Necesidad ISO45001, Necesidad Accion Correctiva, etc)
        $('#DataLabelCausa').val(btnLabel); //to get actual data Type (Necesidad ISO45001, Necesidad Accion Correctiva, etc)
        PopulateList(idlist, idLabel, btnLabel, urlListCausasNecesidades);
    });
}
function PopulateListNecesidad(url) {
    $(".modalCausaNecesidad.necesidades").click(function () {
        var btnTargetObj = $(this).attr("data-targetObject");
        var btnType = $(this).attr("data-type");
        var btnLabel = $(this).attr("data-label");
        var idLabel = "#LabelNecesidad";
        var idlist = "#ListNecesidad";
        var urlListCausasNecesidades = url + "?option=" + btnType;
        $('#modalType').val(btnTargetObj);
        $('#DataTypeNecesidad').val(btnType); //to get actual data Type (Necesidad ISO45001, Necesidad Accion Correctiva, etc)
        $('#DataLabelNecesidad').val(btnLabel); //to get actual data Type (Necesidad ISO45001, Necesidad Accion Correctiva, etc)
        PopulateList(idlist, idLabel, btnLabel, urlListCausasNecesidades);
    });
}

function PopulateList(idList, idLabel, labelList, urlGetList) {
    return $.ajax({
        url: urlGetList,
        type: "Get",
        success: function (data) {
            console.log(data);
            //label cleanup
            $(idLabel).empty();
            $(idLabel).append(labelList);
            //select2
            $(idList).select2('destroy');
            $(idList).select2({ width: '100%' });
            //list cleanup
            $(idList).empty();
            $(idList).append(new Option("Seleccione", ""));
            //populate
            var elementGroup;
            for (var i = 0; i < data.length; i++) {
                if (data[i].esSeleccionable == 0) {
                    elementGroup = $(`<optgroup label='${data[i].nombre}'>`);
                    $(idList).append(elementGroup);
                }
                else {
                    if (elementGroup != null)
                        elementGroup.append(`<option value='${data[i].idCatalogo}' >${data[i].nombre}</option>`);
                    else
                        $(idList).append(`<option value='${data[i].idCatalogo}' >${data[i].nombre}</option>`);
                }
            }
        }
    });
}

/*
 *
 * Causas & Necesidades Table Fillup
 *
 * */
function PrepareRow(tableId, formularioTipo, modalId, datatype, dataLabel, item, index = 0, isFirstRow = true) {
    //init row
    var newRow = document.createElement('tr');

    //get next Index
    if (index == 0 && isFirstRow) {
        var tableTextLastEntry = $("#tabla" + formularioTipo + " tbody>tr:last").text();
        if (!tableTextLastEntry.includes('No se ha asignado ninguna entrada'))
            index = parseInt($("#tabla" + formularioTipo + " tbody>tr:last input.rowIndex").val()) + 1;
    }

    //first TD
    var tdData = document.createElement('td');
    tdData.setAttribute("class", "align-top");
    var IndexHidden = CreateHiddenIndex("rowIndex", index);
    //data
    var IdHidden = CreateHidden(tableId, index, "Id", item.Id);
    var IdIncidenteHidden = CreateHidden(tableId, index, "IdIncidente", item.IdIncidente);
    //trabajador
    var IdTrabajadorResponsableHidden = CreateHidden(tableId, index, "IdTrabajadorResponsable", item.IdTrabajador);
    var RPETrabajadorResponsableHidden = CreateHidden(tableId, index, "RPETrabajadorResponsable", item.RPE);
    var NombreTrabajadorResponsableHidden = CreateHidden(tableId, index, "TrabajadorResponsable", item.NombreTrabajador);
    //causa
    var IdCausaNecesidadHidden = CreateHidden(tableId, index, "IdCausaNecesidad", item.IdCausaNecesidad);
    //descripcion & accion correctiva
    var DescripcionHidden = CreateHidden(tableId, index, "Descripcion", item.Descripcion);
    var AccionCorrectivaHidden = CreateHidden(tableId, index, "AccionCorrectiva", item.AccionCorrectiva);
    //impacto proba riesgo
    var IdImpactoPotencialHidden = CreateHidden(tableId, index, "IdImpactoPotencial", item.IdImpacto);
    var IdProbabilidadPotencialHidden = CreateHidden(tableId, index, "IdProbabilidadPotencial", item.IdProbabilidad);
    var IdRiesgoPotencialHidden = CreateHidden(tableId, index, "IdRiesgoPotencial", item.IdRiesgo);
    var ImpactoPotencialHidden = CreateHidden(tableId, index, "ImpactoPotencial", item.Impacto);
    var ProbabilidadPotencialHidden = CreateHidden(tableId, index, "ProbabilidadPotencial", item.Probabilidad);
    var RiesgoPotencialHidden = CreateHidden(tableId, index, "RiesgoPotencial", item.Riesgo);
    //tipo necesidad
    var IdTipoNecesidadHidden = null;
    if (item.IdTipoNecesidad != 0) {
        IdTipoNecesidadHidden = CreateHidden(tableId, index, "IdTipoNecesidad", item.IdTipoNecesidad);
    }
    var IdNivelAtencionCorreccionHidden = CreateHidden(tableId, index, "NivelAtencionCorreccion", item.IdNivelAtencion);
    var ToBeDeletedHidden = CreateHidden(tableId, index, "ToBeDeleted", false, "deleteFlag");
    var EstadoCorreccionSSTHidden = CreateHidden(tableId, index, "EstadoCorreccionSST", item.EstadoCorreccionSST);

    var CausaNecesidadLabel = CreateLabel(tableId, index, "CausaNecesidad", item.CausaNecesidad);

    tdData.appendChild(IndexHidden);
    tdData.appendChild(IdHidden);
    tdData.appendChild(IdIncidenteHidden);

    tdData.appendChild(IdTrabajadorResponsableHidden);
    tdData.appendChild(RPETrabajadorResponsableHidden);
    tdData.appendChild(NombreTrabajadorResponsableHidden);

    tdData.appendChild(IdCausaNecesidadHidden);

    tdData.appendChild(DescripcionHidden);
    tdData.appendChild(AccionCorrectivaHidden);

    tdData.appendChild(IdImpactoPotencialHidden);
    tdData.appendChild(IdProbabilidadPotencialHidden);
    tdData.appendChild(IdRiesgoPotencialHidden);
    tdData.appendChild(ImpactoPotencialHidden);
    tdData.appendChild(ProbabilidadPotencialHidden);
    tdData.appendChild(RiesgoPotencialHidden);

    if (IdTipoNecesidadHidden != null) {
        tdData.appendChild(IdTipoNecesidadHidden);
    }
    tdData.appendChild(IdNivelAtencionCorreccionHidden);
    tdData.appendChild(ToBeDeletedHidden);
    tdData.appendChild(EstadoCorreccionSSTHidden);
    tdData.appendChild(CausaNecesidadLabel);

    //insert
    newRow.appendChild(tdData);

    //-----------------------------------//-----------------------------------//-----------------------------------//-----------------------------------
    //labels
    //-----------------------------------//-----------------------------------//-----------------------------------//-----------------------------------

    //TipoNecesidad TD
    if (item.TipoNecesidad != "") {
        var tdTipoNecesidad = CreateGenericTd(tableId, index, "TipoNecesidad", item.TipoNecesidad);
        newRow.appendChild(tdTipoNecesidad);
    }

    //Descripcion TD
    var tdDescripcion = CreateGenericTd(tableId, index, "Descripcion", item.Descripcion);
    newRow.appendChild(tdDescripcion);

    //RiesgoPotencial TD
    var tdRiesgoPotencial = CreateGenericTd(tableId, index, "RiesgoPotencial", item.Riesgo);
    newRow.appendChild(tdRiesgoPotencial);

    //AccionCorrectiva TD
    var tdAccionCorrectiva = CreateGenericTd(tableId, index, "AccionCorrectiva", item.AccionCorrectiva);
    newRow.appendChild(tdAccionCorrectiva);

    //TrabajadorResponsable TD
    var tdTrabajadorResponsable = CreateGenericTd(tableId, index, "TrabajadorResponsable", item.NombreTrabajador);
    newRow.appendChild(tdTrabajadorResponsable);

    //NivelAccionCorrectiva TD
    var tdNivelAccionCorrectiva = CreateGenericTd(tableId, index, "NivelAtencionCorreccionText", item.IdNivelAtencion);
    newRow.appendChild(tdNivelAccionCorrectiva);

    //Buttons
    var tdButtons = document.createElement('td');
    var editBtn = CreateButton("EditCausaNecesidad btn-link", "fa-edit", tableId, modalId, datatype, dataLabel,"#298CB6","Editar");
    var delBtn = CreateButton("DeleteCausaNecesidad btn-link", "fas fa-trash-alt", tableId, modalId, datatype, dataLabel,"#656565","Eliminar");
    tdButtons.appendChild(editBtn);
    tdButtons.appendChild(delBtn);
    //insert
    newRow.appendChild(tdButtons);

    return newRow;
}

function CreateGenericTd(tableId, index, id, data) {
    var td = document.createElement('td');
    td.setAttribute("class", "align-top");
    var label = CreateLabel(tableId, index, id, data);
    td.appendChild(label);
    return td;
}

function CreateLabel(tableId, index, dataId, value) {
    var theLabel = document.createElement("label");
    theLabel.setAttribute("readonly", "readonly");
    theLabel.setAttribute("class", "align-top");
    theLabel.setAttribute("style", "white-space: pre-line");
    theLabel.setAttribute("for", tableId + index + "__" + dataId);
    theLabel.innerHTML = value;
    theLabel.value = value;
    return theLabel;
}

function CreateHidden(tableId, index, dataId, value, classHidden = "") {
    var theHidden = document.createElement("input");
    theHidden.setAttribute("type", "hidden");
    theHidden.setAttribute("class", classHidden);
    theHidden.setAttribute("id", tableId + "_" + index + "__" + dataId);
    theHidden.setAttribute("name", tableId + "[" + index + "]." + dataId);
    theHidden.setAttribute("value", value);
    return theHidden;
}

function CreateHiddenIndex(classHidden, value) {
    var theHidden = document.createElement("input");
    theHidden.setAttribute("type", "hidden");
    theHidden.setAttribute("class", classHidden);
    theHidden.setAttribute("value", value);
    return theHidden;
}

function CreateButton(classBtn, icon, tableId = "", modalTarget = "", datatype = "", datalabel = "",iconColor = "",title = "") {
    var theButton = document.createElement("button");
    theButton.setAttribute("data-targetObject", tableId);
    theButton.setAttribute("data-type", datatype);
    theButton.setAttribute("data-label", datalabel);
    theButton.setAttribute("data-target", modalTarget);
    theButton.setAttribute("type", "button");
    theButton.setAttribute("title", title);
    theButton.setAttribute("class", "align-top btn " + classBtn);
    theButton.innerHTML = "<i class='fa " + icon + "'  style='font-size: 16px;color:" + iconColor + "'></i>";
    return theButton;
}

/*
 *
 * Causas & Necesidades Modal Edit
 *
 * */

function EditModalCausasNecesidades(row, tableId, modalId, btnType, btnLabel, idLabel, idlist, url, EditSpecific) {
    var index = row.find('.rowIndex').val();
    var idTpl = tableId + "_" + index + "__";
    ///Según yo con estas líneas se corrige el error entre modales. habrá que checarlo mejor
    $(".btnEditarCausa").unbind("click");
    $(".btnEditarCausa").bind("click", function () {
        console.log('editing causa');
        $('#causasIncidentesModalForm').data('validator').settings.ignore = "";
        if ($("#causasIncidentesModalForm").valid()) {
            CausasRemplazaHilera(tableId, "causasIncidentesModal");
            //ui changes
            $('#causasIncidentesModal').modal('toggle');
            $(".btnGuardarCausa").show();
            $(".btnEditarCausa").hide();
            //valida causas
            enModalCausasNecesidades = false;
            verificaNumeroRowsCausas();
        }
    });
    $(".btnEditarNecesidad").unbind("click");
    $(".btnEditarNecesidad").bind("click", function () {
        console.log('editing Necesidades');
        $('#necesidadesIncidentesModalForm').data('validator').settings.ignore = "";
        if ($("#necesidadesIncidentesModalForm").valid()) {
            NecesidadesRemplazaHilera(tableId, "necesidadesIncidentesModal");
            //ui changes
            $('#necesidadesIncidentesModal').modal('toggle');
            $(".btnGuardarNecesidad").show();
            $(".btnEditarNecesidad").hide();
            //valida necesidades
            enModalCausasNecesidades = false;
            verificaNumeroRowsNecesidades();
        }
    });
    //building Ids
    var Idid = idTpl + "Id";
    var IdIncidente = idTpl + "IdIncidente";
    var IdTrabajadorResponsable = idTpl + "IdTrabajadorResponsable";
    var IdCausaNecesidad = idTpl + "IdCausaNecesidad";
    var IdTipoNecesidad = idTpl + "IdTipoNecesidad";
    var TipoNecesidad = idTpl + "TipoNecesidad";
    var ToBeDeleted = idTpl + "ToBeDeleted";
    var CausaNecesidad = idTpl + "CausaNecesidad";
    var Descripcion = idTpl + "Descripcion";
    var ImpactoPotencial = idTpl + "IdImpactoPotencial";
    var ProbabilidadPotencial = idTpl + "IdProbabilidadPotencial";
    var RiesgoPotencial = idTpl + "IdRiesgoPotencial";
    var AccionCorrectiva = idTpl + "AccionCorrectiva";
    var TrabajadorResponsable = idTpl + "TrabajadorResponsable";
    var RPETrabajadorResponsable = idTpl + "RPETrabajadorResponsable";
    var NivelAtencionCorrecion = idTpl + "NivelAtencionCorreccion";
    var EstadoCorreccionSST = idTpl + "EstadoCorreccionSST";

    //actual data
    var item = {
        Index: index,
        DataLabel: btnLabel,
        Id: $('#' + Idid).val(),
        IdIncidente: $('#' + IdIncidente).val(),
        IdTrabajadorResponsable: $('#' + IdTrabajadorResponsable).val(),
        IdCausaNecesidad: $('#' + IdCausaNecesidad).val(),
        IdTipoNecesidad: $('#' + IdTipoNecesidad).val(),
        TipoNecesidad: $('#' + TipoNecesidad).val(),

        NivelAtencionCorrecion: $('#' + NivelAtencionCorrecion).val(),
        ToBeDeleted: $('#' + ToBeDeleted).val(),
        Descripcion: $('#' + Descripcion).val(),
        ImpactoPotencial: $('#' + ImpactoPotencial).val(),
        ProbabilidadPotencial: $('#' + ProbabilidadPotencial).val(),
        RiesgoPotencial: $('#' + RiesgoPotencial).val(),
        AccionCorrectiva: $('#' + AccionCorrectiva).val(),
        TrabajadorResponsable: $('#' + TrabajadorResponsable).val(),
        RPETrabajadorResponsable: $('#' + RPETrabajadorResponsable).val(),

        NivelAtencionCorrecionText: $('#' + NivelAtencionCorrecion).text(),
        EstadoCorreccionSST: $('#' + EstadoCorreccionSST).val()
    };

    //init and show modal
    var urlListCausasNecesidades = url + "?option=" + btnType;
    $('#modalType').val(tableId);
    PopulateList(idlist, idLabel, btnLabel, urlListCausasNecesidades).then(function () {
        console.log("all done");
        EditSpecific(modalId, item);
    });

}

function EditCausas(modalId, item) {
    //invoke modal
    $('#' + modalId).modal();

    //assign data
    $("#" + modalId + " #IndexCausa").val(item.Index);
    $("#" + modalId + " #DataLabelCausa").val(item.DataLabel);
    $("#" + modalId + " #EstadoCorreccionSSTCausa").val(item.EstadoCorreccionSST);
    $("#" + modalId + " #IdCausaNecesidadModal").val(item.Id);
    $("#" + modalId + " #IdIncidenteCausaNecesidadModal").val(item.IdIncidente);
    //lists
    $("#" + modalId + " #ListCausa").val(item.IdCausaNecesidad).trigger('change');

    $("#" + modalId + " #ImpactoPotencialCausas").val(item.ImpactoPotencial).trigger('change');
    $("#" + modalId + " #ProbabilidadPotencialCausas").val(item.ProbabilidadPotencial).trigger('change');
    $("#" + modalId + " #RiesgoPotencialCausas").val(item.RiesgoPotencial).trigger('change');

    $("#" + modalId + " #NivelAtencionCausas").val(item.NivelAtencionCorrecion).change();

    $("#" + modalId + " #CausaDescripcion").val(item.Descripcion);
    $("#" + modalId + " #CausaAccionCorrectiva").val(item.AccionCorrectiva);


    //trabajador responsable
    $("#CausaNecesidadSearcher.trabajadorSearchVC").empty();
    //add entry in searchTrabajadores input
    var trabajadorText = item.TrabajadorResponsable;
    var trabajadorOpcion = new Option(trabajadorText, item.IdTrabajadorResponsable);
    $("#CausaNecesidadSearcher.trabajadorSearchVC").append(trabajadorOpcion);

    $("#" + modalId + " #IdTrabajadorResponsable").val(item.IdTrabajadorResponsable);
    $("#" + modalId + " #RPETrabajadorResponsable").val(item.RPETrabajadorResponsable);
    $("#" + modalId + " #NombreTrabajadorResponsable").val(item.TrabajadorResponsable);

    ResizeTextArea();
}


function EditNecesidades(modalId, item) {
    //invoke modal
    $('#' + modalId).modal();

    //assign data
    $("#" + modalId + " #IndexNecesidad").val(item.Index);
    $("#" + modalId + " #DataLabelNecesidad").val(item.DataLabel);
    $("#" + modalId + " #EstadoCorreccionSSTNecesidad").val(item.EstadoCorreccionSST);
    $("#" + modalId + " #IdNecesidadModal").val(item.Id);
    $("#" + modalId + " #IdIncidenteNecesidadModal").val(item.IdIncidente);
    //lists
    $("#" + modalId + " #ListNecesidad").val(item.IdCausaNecesidad).trigger('change');
    $("#" + modalId + " #TipoNecesidad").val(item.IdTipoNecesidad).trigger('change');

    $("#" + modalId + " #ImpactoPotencialNecesidades").val(item.ImpactoPotencial).trigger('change');
    $("#" + modalId + " #ProbabilidadPotencialNecesidades").val(item.ProbabilidadPotencial).trigger('change');
    $("#" + modalId + " #RiesgoPotencialNecesidades").val(item.RiesgoPotencial).trigger('change');

    $("#" + modalId + " #NivelAtencionNecesidades").val(item.NivelAtencionCorrecion).change();

    $("#" + modalId + " #NecesidadDescripcion").val(item.Descripcion);
    $("#" + modalId + " #NecesidadAccionCorrectiva").val(item.AccionCorrectiva);

    //trabajador responsable
    $("#NecesidadSearcher.trabajadorSearchVC").empty();
    //add entry in searchTrabajadores input
    var trabajadorText = item.TrabajadorResponsable;
    var trabajadorOpcion = new Option(trabajadorText, item.IdTrabajadorResponsable);
    $("#NecesidadSearcher.trabajadorSearchVC").append(trabajadorOpcion);

    $("#" + modalId + " #IdTrabajadorResponsableNecesidad").val(item.IdTrabajadorResponsable);
    $("#" + modalId + " #RPETrabajadorResponsableNecesidad").val(item.RPETrabajadorResponsable);
    $("#" + modalId + " #NombreTrabajadorResponsableNecesidad").val(item.TrabajadorResponsable);

    ResizeTextArea();
}
/*
 *
 * Causas & Necesidades Trabajadores Search callbacks
 * 
 * */
function FillTrabajadorResponsable(data) {
    var id = data.id;//
    var rpe = data.rpe;//
    var nombre = data.text.replace(data.rpe + ' -- ', '');

    $('#IdTrabajadorResponsable').val(id);
    $('#RPETrabajadorResponsable').val(rpe);
    $('#NombreTrabajadorResponsable').val(nombre);
}
function FillTrabajadorResponsableNecesidad(data) {
    var id = data.id;//
    var rpe = data.rpe;//
    var nombre = data.text.replace(data.rpe + ' -- ', '');

    $('#IdTrabajadorResponsableNecesidad').val(id);
    $('#RPETrabajadorResponsableNecesidad').val(rpe);
    $('#NombreTrabajadorResponsableNecesidad').val(nombre);
}

/*
 *
 * Causas Specific
 *
 * */
function CausasDevuelveFormularioInicializa() {
    $("#causas .modalCausaNecesidad").bind("click", function () {
        $(".validation-summary-errors-modal-causas").html("");
        $("#causasIncidentesModalForm .field-validation-error").html("");
        enModalCausasNecesidades = true;
        //alert(enModalCausasNecesidades );
        var formularioTipo = $(this).attr("data-type");
        CausasFormularioLimpia(formularioTipo, "causasIncidentesModal");
        $(".btnGuardarCausa").unbind("click");
        $(".btnGuardarCausa").bind("click", function () {
            //alert(enModalCausasNecesidades);
            $('#causasIncidentesModalForm').data('validator').settings.ignore = "";
            if ($("#causasIncidentesModalForm").valid()) {
                CausasDevuelveFormulario(formularioTipo, "causasIncidentesModal");
                $('#causasIncidentesModal').modal('toggle');
                enModalCausasNecesidades = false;
                verificaNumeroRowsCausas();
            }
        });
        $(".desbloquearFormulario").bind("click", function () {
            enModalCausasNecesidades = false;
            verificaNumeroRowsCausas();
        });
        $(".btnEditarCausa").unbind("click");
        $(".btnEditarCausa").bind("click", function () {
            console.log('editing causa');
            $('#causasIncidentesModalForm').data('validator').settings.ignore = "";
            if ($("#causasIncidentesModalForm").valid()) {
                CausasRemplazaHilera(formularioTipo, "causasIncidentesModal");
                //ui changes
                $('#causasIncidentesModal').modal('toggle');
                $(".btnGuardarCausa").show();
                $(".btnEditarCausa").hide();
                enModalCausasNecesidades = false;
                verificaNumeroRowsCausas();
            }
        });
    });    
}
function CausasDevuelveFormulario(formularioTipo, modalId) {
    var tablaContenido = $("#tabla" + formularioTipo + " tbody");

    //get parent label if its an optgroup
    var causaNecesidadPadreLabel = "";
    var causaNecesidadPadre = $("#" + modalId + " #ListCausa option:selected").parent();
    if (causaNecesidadPadre.is('optgroup')) {
        causaNecesidadPadreLabel = causaNecesidadPadre.attr('label').trimEnd().trimEnd('.')  + ". ";
    }
    //get actual selected opcion in CausaNecesidad List
    var causaNecesidadOpcionLabel = $("#" + modalId + " #ListCausa option:selected").text();
    var CausaNecesidadText = causaNecesidadPadreLabel + causaNecesidadOpcionLabel;

    var item = {
        //general
        Id: $("#" + modalId + " #IdCausaNecesidadModal").val(),
        IdIncidente: $("#" + modalId + " #IdIncidenteCausaNecesidadModal").val(),
        //list causa necesidad
        IdCausaNecesidad: $("#" + modalId + " #ListCausa option:selected").val(),
        CausaNecesidad: CausaNecesidadText,
        //impacto list
        IdImpacto: $("#" + modalId + " #ImpactoPotencialCausas option:selected").val(),
        Impacto: $("#" + modalId + " #ImpactoPotencialCausas option:selected").text(),
        //proba list
        IdProbabilidad: $("#" + modalId + " #ProbabilidadPotencialCausas option:selected").val(),
        Probabilidad: $("#" + modalId + " #ProbabilidadPotencialCausas option:selected").text(),
        //riesgo list
        IdRiesgo: $("#" + modalId + " #RiesgoPotencialCausas option:selected").val(),
        Riesgo: $("#" + modalId + " #RiesgoPotencialCausas option:selected").text(),
        //nivel list
        IdNivelAtencion: $("#" + modalId + " #NivelAtencionCausas option:selected").val(),
        //textareas
        Descripcion: $("#" + modalId + " #CausaDescripcion").val(),
        AccionCorrectiva: $("#" + modalId + " #CausaAccionCorrectiva").val(),
        //trabajador data
        IdTrabajador: $("#" + modalId + " #IdTrabajadorResponsable").val(),
        RPE: $("#" + modalId + " #RPETrabajadorResponsable").val(),
        NombreTrabajador: $("#" + modalId + " #NombreTrabajadorResponsable").val(),
        //for necesidades exclusively
        IdTipoNecesidad: 0,
        TipoNecesidad: ""
    };

    //prepare row with given data
    var hilera = PrepareRow(
        tableId = $('#modalType').val(),
        formularioTipo = formularioTipo,
        modalId = modalId,
        datatype = $('#DataTypeCausa').val(),
        dataLabel = $('#DataLabelCausa').val(),
        item);

    /* Verifica total de causas */
    var tableTextLastEntry = $("#tabla" + formularioTipo + " tbody>tr:last").text();
    if (tableTextLastEntry.includes('No se ha asignado ninguna entrada')) {
        $(tablaContenido).find("tr:first-child").remove();
    }

    $(hilera).appendTo(tablaContenido);

}

function CausasRemplazaHilera(formularioTipo, modalId) {
    var tablaContenido = $("#tabla" + formularioTipo + " tbody");
    var index = $("#" + modalId + " #IndexCausa").val();

    //get parent label if its an optgroup
    var causaNecesidadPadreLabel = "";
    var causaNecesidadPadre = $("#" + modalId + " #ListCausa option:selected").parent();
    if (causaNecesidadPadre.is('optgroup')) {
        causaNecesidadPadreLabel = causaNecesidadPadre.attr('label').trimEnd() + ". ";
    }
    //get actual selected opcion in CausaNecesidad List
    var causaNecesidadOpcionLabel = $("#" + modalId + " #ListCausa option:selected").text();
    var CausaNecesidadText = causaNecesidadPadreLabel + causaNecesidadOpcionLabel;


    var item = {
        //general
        Id: $("#" + modalId + " #IdCausaNecesidadModal").val(),
        EstadoCorreccionSST: $("#" + modalId + " #EstadoCorreccionSSTCausa").val(),
        IdIncidente: $("#" + modalId + " #IdIncidenteCausaNecesidadModal").val(),
        //list causa necesidad
        IdCausaNecesidad: $("#" + modalId + " #ListCausa option:selected").val(),
        CausaNecesidad: CausaNecesidadText,
        //impacto list
        IdImpacto: $("#" + modalId + " #ImpactoPotencialCausas option:selected").val(),
        Impacto: $("#" + modalId + " #ImpactoPotencialCausas option:selected").text(),
        //proba list
        IdProbabilidad: $("#" + modalId + " #ProbabilidadPotencialCausas option:selected").val(),
        Probabilidad: $("#" + modalId + " #ProbabilidadPotencialCausas option:selected").text(),
        //riesgo list
        IdRiesgo: $("#" + modalId + " #RiesgoPotencialCausas option:selected").val(),
        Riesgo: $("#" + modalId + " #RiesgoPotencialCausas option:selected").text(),
        //nivel list
        IdNivelAtencion: $("#" + modalId + " #NivelAtencionCausas option:selected").val(),
        //textareas
        Descripcion: $("#" + modalId + " #CausaDescripcion").val(),
        AccionCorrectiva: $("#" + modalId + " #CausaAccionCorrectiva").val(),
        //trabajador data
        IdTrabajador: $("#" + modalId + " #IdTrabajadorResponsable").val(),
        RPE: $("#" + modalId + " #RPETrabajadorResponsable").val(),
        NombreTrabajador: $("#" + modalId + " #NombreTrabajadorResponsable").val(),
        //for necesidades exclusively
        IdTipoNecesidad: 0,
        TipoNecesidad: ""
    };

    //prepare row with given data
    var hilera = PrepareRow(
        tableId = $('#modalType').val(),
        formularioTipo = formularioTipo,
        modalId = modalId,
        datatype = $('#DataTypeCausa').val(),
        dataLabel = $('#DataLabelCausa').val(),
        item,
        index,
        isFirstRow = false
    );

    //iterate and replace row with the updated row
    var tableIterator = "#tabla" + $('#DataTypeCausa').val() + " tbody > tr"
    $(tableIterator).each(function (indexTr, tr) {
        console.log(index);
        if (indexTr == index) {
            console.log('replacing');
            $(this).replaceWith(hilera);
        }
        console.log(tr);
    });

}
function CausasFormularioLimpia(formularioTipo, modalId) {
    $("#" + modalId + " #IdCausaNecesidadModal").val(0);
    $("#" + modalId + " #EstadoCorreccionSSTCausa").val("");
    $("#" + modalId + " #IdIncidenteCausaNecesidadModal").val(0);

    $("#" + modalId + " #CausaDescripcion").val("");

    $("#" + modalId + " #ImpactoPotencialCausas").val("").change();
    $("#" + modalId + " #ProbabilidadPotencialCausas").val("").change();
    $("#" + modalId + " #RiesgoPotencialCausas").val("").change();

    $("#" + modalId + " #CausaAccionCorrectiva").val("");
    $("#" + modalId + " #NivelAtencionCausas").val("");
    //trabajador responsable
    $("#" + modalId + " #hdfRPE").val("");
    //kill and re init trabajadores search
    //$("#CausaNecesidadSearcher.trabajadorSearchVC").select2('destroy');
    //$("#CausaNecesidadSearcher.trabajadorSearchVC").select2({ width: '100%' });
    $("#CausaNecesidadSearcher.trabajadorSearchVC").empty();
    $("#" + modalId + " #IdTrabajadorResponsable").val("");
    $("#" + modalId + " #RPETrabajadorResponsable").val("");
    $("#" + modalId + " #NombreTrabajadorResponsable").val("");

    //buttons management
    $(".btnGuardarCausa").show();
    $(".btnEditarCausa").hide();
}

/*
 *
 * Necesidades Specific
 *
 * */
function NecesidadesDevuelveFormularioInicializa() {
    $("#necesidades .modalCausaNecesidad").bind("click", function () {
        var formularioTipo = $(this).attr("data-type");
        NecesidadesFormularioLimpia(formularioTipo, "necesidadesIncidentesModal");
        $(".btnGuardarNecesidad").unbind("click");
        $(".btnGuardarNecesidad").bind("click", function () {
            $('#necesidadesIncidentesModalForm').data('validator').settings.ignore = "";
            if ($("#necesidadesIncidentesModalForm").valid()) {
                NecesidadesDevuelveFormulario(formularioTipo, "necesidadesIncidentesModal");
                $('#necesidadesIncidentesModal').modal('toggle');
            }
        });
        $(".btnEditarNecesidad").unbind("click");
        $(".btnEditarNecesidad").bind("click", function () {
            //console.log('editing Necesidades');
            $('#necesidadesIncidentesModalForm').data('validator').settings.ignore = "";
            if ($("#necesidadesIncidentesModalForm").valid()) {
                NecesidadesRemplazaHilera(formularioTipo, "necesidadesIncidentesModal");
                //ui changes
                $('#necesidadesIncidentesModal').modal('toggle');
                $(".btnGuardarNecesidad").show();
                $(".btnEditarNecesidad").hide();
            }
        });
    });
}
function NecesidadesDevuelveFormulario(formularioTipo, modalId) {
    var tablaContenido = $("#tabla" + formularioTipo + " tbody");

    //get parent label if its an optgroup
    var necesidadPadreLabel = "";
    var necesidadPadre = $("#" + modalId + " #ListNecesidad option:selected").parent();
    if (necesidadPadre.is('optgroup')) {
        necesidadPadreLabel = necesidadPadre.attr('label').trimEnd().trimEnd('.') + ". ";
    }
    //get actual selected opcion in CausaNecesidad List
    var necesidadOpcionLabel = $("#" + modalId + " #ListNecesidad option:selected").text();
    var necesidadText = necesidadPadreLabel + necesidadOpcionLabel;

    var item = {
        //general
        Id: $("#" + modalId + " #IdNecesidadModal").val(),
        IdIncidente: $("#" + modalId + " #IdIncidenteNecesidadModal").val(),
        //list causa necesidad
        IdCausaNecesidad: $("#" + modalId + " #ListNecesidad option:selected").val(),
        CausaNecesidad: necesidadText,
        //impacto list
        IdImpacto: $("#" + modalId + " #ImpactoPotencialNecesidades option:selected").val(),
        Impacto: $("#" + modalId + " #ImpactoPotencialNecesidades option:selected").text(),
        //proba list
        IdProbabilidad: $("#" + modalId + " #ProbabilidadPotencialNecesidades option:selected").val(),
        Probabilidad: $("#" + modalId + " #ProbabilidadPotencialNecesidades option:selected").text(),
        //riesgo list
        IdRiesgo: $("#" + modalId + " #RiesgoPotencialNecesidades option:selected").val(),
        Riesgo: $("#" + modalId + " #RiesgoPotencialNecesidades option:selected").text(),
        //nivel list
        IdNivelAtencion: $("#" + modalId + " #NivelAtencionNecesidades option:selected").val(),
        //textareas
        Descripcion: $("#" + modalId + " #NecesidadDescripcion").val(),
        AccionCorrectiva: $("#" + modalId + " #NecesidadAccionCorrectiva").val(),
        //trabajador data
        IdTrabajador: $("#" + modalId + " #IdTrabajadorResponsableNecesidad").val(),
        RPE: $("#" + modalId + " #RPETrabajadorResponsableNecesidad").val(),
        NombreTrabajador: $("#" + modalId + " #NombreTrabajadorResponsableNecesidad").val(),
        //for necesidades exclusively
        IdTipoNecesidad: $("#" + modalId + " #TipoNecesidad option:selected").val(),
        TipoNecesidad: $("#" + modalId + " #TipoNecesidad option:selected").text()
    };

    //prepare row with given data
    var hilera = PrepareRow(
        tableId = $('#modalType').val(),
        formularioTipo = formularioTipo,
        modalId = modalId,
        datatype = $('#DataTypeNecesidad').val(),
        dataLabel = $('#DataLabelNecesidad').val(),
        item
    );

    /* Verifica total de causas */
    var tableTextLastEntry = $("#tabla" + formularioTipo + " tbody>tr:last").text();
    if (tableTextLastEntry.includes('No se ha asignado ninguna entrada')) {
        $(tablaContenido).find("tr:first-child").remove();
    }

    $(hilera).appendTo(tablaContenido);

}
function NecesidadesRemplazaHilera(formularioTipo, modalId) {
    var tablaContenido = $("#tabla" + formularioTipo + " tbody");
    var index = $("#" + modalId + " #IndexNecesidad").val();

    //get parent label if its an optgroup
    var necesidadPadreLabel = "";
    var necesidadPadre = $("#" + modalId + " #ListNecesidad option:selected").parent();
    if (necesidadPadre.is('optgroup')) {
        necesidadPadreLabel = necesidadPadre.attr('label').trimEnd() + ". ";
    }
    //get actual selected opcion in CausaNecesidad List
    var necesidadOpcionLabel = $("#" + modalId + " #ListNecesidad option:selected").text();
    var necesidadText = necesidadPadreLabel + necesidadOpcionLabel;

    var item = {
        //general
        Id: $("#" + modalId + " #IdNecesidadModal").val(),
        EstadoCorreccionSST: $("#" + modalId + " #EstadoCorreccionSSTNecesidad").val(),
        IdIncidente: $("#" + modalId + " #IdIncidenteNecesidadModal").val(),
        //list causa necesidad
        IdCausaNecesidad: $("#" + modalId + " #ListNecesidad option:selected").val(),
        CausaNecesidad: necesidadText,
        //impacto list
        IdImpacto: $("#" + modalId + " #ImpactoPotencialNecesidades option:selected").val(),
        Impacto: $("#" + modalId + " #ImpactoPotencialNecesidades option:selected").text(),
        //proba list
        IdProbabilidad: $("#" + modalId + " #ProbabilidadPotencialNecesidades option:selected").val(),
        Probabilidad: $("#" + modalId + " #ProbabilidadPotencialNecesidades option:selected").text(),
        //riesgo list
        IdRiesgo: $("#" + modalId + " #RiesgoPotencialNecesidades option:selected").val(),
        Riesgo: $("#" + modalId + " #RiesgoPotencialNecesidades option:selected").text(),
        //nivel list
        IdNivelAtencion: $("#" + modalId + " #NivelAtencionNecesidades option:selected").val(),
        //textareas
        Descripcion: $("#" + modalId + " #NecesidadDescripcion").val(),
        AccionCorrectiva: $("#" + modalId + " #NecesidadAccionCorrectiva").val(),
        //trabajador data
        IdTrabajador: $("#" + modalId + " #IdTrabajadorResponsableNecesidad").val(),
        RPE: $("#" + modalId + " #RPETrabajadorResponsableNecesidad").val(),
        NombreTrabajador: $("#" + modalId + " #NombreTrabajadorResponsableNecesidad").val(),
        //for necesidades exclusively
        IdTipoNecesidad: $("#" + modalId + " #TipoNecesidad option:selected").val(),
        TipoNecesidad: $("#" + modalId + " #TipoNecesidad option:selected").text()
    };


    //prepare row with given data
    var hilera = PrepareRow(
        tableId = $('#modalType').val(),
        formularioTipo = formularioTipo,
        modalId = modalId,
        datatype = $('#DataTypeNecesidad').val(),
        dataLabel = $('#DataLabelNecesidad').val(),
        item,
        index,
        isFirstRow = false
    );

    //iterate and replace row with the updated row
    var tableIterator = "#tabla" + $('#DataTypeNecesidad').val() + " tbody > tr"
    $(tableIterator).each(function (indexTr, tr) {
        console.log(index);
        if (indexTr == index) {
            console.log('replacing');
            $(this).replaceWith(hilera);
        }
        console.log(tr);
    });

}
function NecesidadesFormularioLimpia(formularioTipo, modalId) {
    $("#" + modalId + " #IdNecesidadModal").val(0);
    $("#" + modalId + " #EstadoCorreccionSSTNecesidad").val("");
    $("#" + modalId + " #IdIncidenteNecesidadModal").val(0);

    $("#" + modalId + " #TipoNecesidad").val("").change();
    $("#" + modalId + " #NecesidadDescripcion").val("");

    $("#" + modalId + " #ImpactoPotencialNecesidades").val("").change();
    $("#" + modalId + " #ProbabilidadPotencialNecesidades").val("").change();
    $("#" + modalId + " #RiesgoPotencialNecesidades").val("").change();

    $("#" + modalId + " #NecesidadAccionCorrectiva").val("");
    $("#" + modalId + " #NivelAtencionNecesidades").val("");
    //trabajador responsable
    $("#" + modalId + " #hdfRPE").val("");
    //kill and re init trabajadores search
    //$("#NecesidadSearcher.trabajadorSearchVC").select2('destroy');
    //$("#NecesidadSearcher.trabajadorSearchVC").select2({ width: '100%' });
    $("#NecesidadSearcher.trabajadorSearchVC").empty();
    $("#" + modalId + " #IdTrabajadorResponsableNecesidad").val("");
    $("#" + modalId + " #RPETrabajadorResponsableNecesidad").val("");
    $("#" + modalId + " #NombreTrabajadorResponsableNecesidad").val("");

    //buttons management
    $(".btnGuardarNecesidad").show();
    $(".btnEditarNecesidad").hide();

}
function VerificaNumeroErroresPestania() {
    MuestraNumeroErroresPestania("#datosTrabajador");
    MuestraNumeroErroresPestania("#datosCentroTrabajo");
    MuestraNumeroErroresPestania("#datosIncidenteConLesion");
    MuestraNumeroErroresPestania("#descripcionIncidente");
    MuestraNumeroErroresPestania("#evaluacionIncidente");
}
function MuestraNumeroErroresPestania(nombrePestania) {
    var totalErrores = $(nombrePestania).find(".field-validation-error > span").length;
    if (totalErrores > 0) {
        $(nombrePestania + "Error").html("<span class='badge badge-danger ml-auto'>" + totalErrores + "</span>");
    }
    else {
        $(nombrePestania + "Error").html("");
    }
}