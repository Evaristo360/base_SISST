/*
 *
 * Datos Incidente con Lesion  Tab
 * Trabajadores presencia evento
 *
 * */


function ValidateHorasExtraInputs() {

    var IsHorasExtras = $('input[name="EnHorasExtras"]:checked').val();
    if (IsHorasExtras == "True") {
        //$('#HorasLaboradasAntesIncidente').removeClass("ignoreValidation");
        //$('#HorasLaboradasAntesIncidente').removeAttr('disabled');
    }
    else {
        //$('#HorasLaboradasAntesIncidente').addClass("ignoreValidation");
        //$('#HorasLaboradasAntesIncidente').attr('disabled', 'disabled');

    }
}

//callback for Buscador RPE and Trabajadores Presencia Evento 
function PrepareTrabajadorPresenciaEvento(data) {
    var id = data.id;//
    var rpe = data.rpe;//
    var nombre = data.text.replace(data.rpe + ' -- ', '');

    $('#IdTrabajadorPresencia').val(id);
    $('#RPETrabajadorPresencia').val(rpe);
    $('#NombreTrabajadorPresencia').val(nombre);
}

function AddTrabajadorPresenciaEvento() {
    var index = parseInt($('#tableTrabajadoresPresenciaEvento tr:last> td:first> input.rowIndex ').val()) + 1;
    index = isNaN(index) ? 0 : index;
    var id = $('#IdTrabajadorPresencia').val();
    var rpe = $('#RPETrabajadorPresencia').val();
    var nombre = $('#NombreTrabajadorPresencia').val();

    if (id.length == 0 || rpe.length == 0 || nombre.length == 0) return;

    //validate that there is no entry with same RPE
    var existsInTable = false;
    $("#tableTrabajadoresPresenciaEvento tr").each(function () {
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

    var tbody = document.getElementById('tableTrabajadoresPresenciaEvento').getElementsByTagName("tbody")[0];


    var newRow = tbody.insertRow();
    var firstCell = newRow.insertCell();

    //hiddens
    //index
    var idHidden = document.createElement("input");
    idHidden.setAttribute("type", "hidden");
    idHidden.setAttribute("class", "rowIndex");
    idHidden.setAttribute("value", index);
    firstCell.appendChild(idHidden);
    //id
    var idHidden = document.createElement("input");
    idHidden.setAttribute("type", "hidden");
    idHidden.setAttribute("class", "form-label");
    idHidden.setAttribute("id", "TrabajadoresPresenciaEvento_" + index + "__Id");
    idHidden.setAttribute("name", "TrabajadoresPresenciaEvento[" + index + "].Id");
    idHidden.setAttribute("value", id);
    firstCell.appendChild(idHidden);
    //rpe
    var rpeHidden = document.createElement("input");
    rpeHidden.setAttribute("type", "hidden");
    rpeHidden.setAttribute("class", "form-label rpeInput");
    rpeHidden.setAttribute("id", "TrabajadoresPresenciaEvento_" + index + "__RPE");
    rpeHidden.setAttribute("name", "TrabajadoresPresenciaEvento[" + index + "].RPE");
    rpeHidden.setAttribute("value", rpe);
    firstCell.appendChild(rpeHidden);
    //nombretrabajador
    var trabajadorHidden = document.createElement("input");
    trabajadorHidden.setAttribute("type", "hidden");
    trabajadorHidden.setAttribute("class", "form-label");
    trabajadorHidden.setAttribute("id", "TrabajadoresPresenciaEvento_" + index + "__NombreCompleto");
    trabajadorHidden.setAttribute("name", "TrabajadoresPresenciaEvento[" + index + "].NombreCompleto");
    trabajadorHidden.setAttribute("value", nombre);
    firstCell.appendChild(trabajadorHidden);
    //ToBeDeleted
    var deleteFlagHidden = document.createElement("input");
    deleteFlagHidden.setAttribute("type", "hidden");
    deleteFlagHidden.setAttribute("class", "form-label deleteFlag");
    deleteFlagHidden.setAttribute("id", "TrabajadoresPresenciaEvento_" + index + "__ToBeDeleted");
    deleteFlagHidden.setAttribute("name", "TrabajadoresPresenciaEvento[" + index + "].ToBeDeleted");
    deleteFlagHidden.setAttribute("value", false);
    firstCell.appendChild(deleteFlagHidden);

    //RPE label
    var rpeLabel = document.createElement("label");
    rpeLabel.setAttribute("readonly", "readonly");
    rpeLabel.setAttribute("name", "TrabajadoresPresenciaEvento_" + index + "__RPE");
    rpeLabel.setAttribute("name", "TrabajadoresPresenciaEvento[" + index + "].RPE");
    rpeLabel.setAttribute("id", "TrabajadoresPresenciaEvento_" + index + "__RPE");
    rpeLabel.innerHTML = rpe;
    rpeLabel.value = rpe;
    firstCell.appendChild(rpeLabel);


    //Nombre Trabajador
    var secondCell = newRow.insertCell();
    var nombreLabel = document.createElement("label");
    nombreLabel.setAttribute("readonly", "readonly");
    nombreLabel.setAttribute("class", "form-label");
    nombreLabel.setAttribute("for", "TrabajadoresPresenciaEvento_" + index + "__NombreCompleto");
    nombreLabel.setAttribute("name", "TrabajadoresPresenciaEvento[" + index + "].NombreCompleto");
    nombreLabel.setAttribute("id", "TrabajadoresPresenciaEvento_" + index + "__NombreCompleto");
    nombreLabel.innerHTML = nombre.split("-")[1];
    nombreLabel.value = nombre.split("-")[1];
    secondCell.appendChild(nombreLabel);


    //button Delete
    var thirdCell = newRow.insertCell();
    var buttonDelete = document.createElement("button");
    buttonDelete.setAttribute("type", "button");
    buttonDelete.setAttribute("class", "btn btn-link DeleteTrabajador");
    buttonDelete.innerHTML = "<i class='fas fa-trash-alt' style='font-size: 16px;color:#656565'></i>";
    thirdCell.appendChild(buttonDelete);

    //finally, clear buscador
    $('#TrabajadorPresenciaEventoSearcher').val('').trigger('change');
    $('#IdTrabajadorPresencia').val('');
    $('#RPETrabajadorPresencia').val('');
    $('#NombreTrabajadorPresencia').val('');
}

function DeleteTrabajadorPresenciaEvento() {

    $('#tableTrabajadoresPresenciaEvento').on('click', 'button.DeleteTrabajador', function () {
        var row = $(this).closest("tr");
        //toggleDeleteFlag
        row.find(".deleteFlag").val(true);
        row.hide();
    });
}
