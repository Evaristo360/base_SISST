
$(document).ready(function () {

    /* POC Evidencias */
    //open the nueva evidencia modal 
    $("#GuardarEvidencia").click(function () {
        //TODO: get the actual Id of idActividad & idActividadMesSemana

        $('#evidenciaModal').on('show.bs.modal', function (event) {
            var modal = $(this);

            modal.find('#IdActividad').val(new_idActividad);
            modal.find('#IdActividadMesSemana').val(new_idActividadMesSemana);
        })
        $('#evidenciaModal').modal('show');
        setTimeout(function () {
            $(".modal-backdrop").remove();
        }, 500);
    });

    //saving nueva evidencia and submitting form
    $("#btnGuardarEvidencia").click(function () {
        //var validationModel = $("#evidenciaModalForm").valid();
        //Mandar formulario por Ajax
        //clean all span errors
        $('#evidenciaModalForm').find('span').text('');
        $('.field-validation-error').each(function (i, obj) {
            $(this).find('span').remove();
        });
        //clear validation errors
        $('#evidenciaModalForm').find("[data-valmsg-summary=true]")
            .find("ul").empty()

        $('#evidenciaModalForm').find("[data-valmsg-summary=true]")
            .removeClass("validation-summary-errors")
            .addClass("validation-summary-valid")
            .find("ul").empty();
    });

    $('#evidenciaModal').on('hidden.bs.modal', function () {
        $('#evidenciaModalForm').find('span').text('');
        $('.field-validation-error').each(function (i, obj) {
            $(this).find('span').remove();
        });
        //clear validation errors
        $('#evidenciaModalForm').find("[data-valmsg-summary=true]")
            .find("ul").empty()

        $('#evidenciaModalForm').find("[data-valmsg-summary=true]")
            .removeClass("validation-summary-errors")
            .addClass("validation-summary-valid")
            .find("ul").empty();
    })

    //open evidencia list modal
    $("#VerEvidencias").click(function () {
        //TODO: get the actual Id of ActividadMesSemana

        //get list in html from viewComponent
        var url = urlListEvidencia + list_idMesSemana;
        $.ajax({
            type: "GET",
            url: url,
            success: function (result) {

                $('#evidenciaListModal').on('show.bs.modal', function (event) {
                    var modal = $(this);

                    var documentos = result.model.documentos;
                    var htmlDocumentos = AddRecords(documentos)

                    $('#cardContainer').replaceWith(htmlDocumentos);
                    modal.find('#IdActividad').val(result.model.idActividad);
                    modal.find('#IdActividadMesSemana').val(result.model.idMesSemana);
                })
                $('#evidenciaListModal').modal('show');
                setTimeout(function () {
                    $(".modal-backdrop").remove();
                }, 500);
            },
            error: function (xhr) {
                $.LoadingOverlay("hide");
                toastr["warning"](xhr.responseJSON.statusDescription);
            }
        });
    });
    /* / POC Evidencias */

    //opening nueva evidencia modal from evidencia list modal
    $("#GuardarEvidenciaFromList").click(function () {
        var modal = $(this).parents("div#evidenciaListModal");

        var idActividad = modal.find('#IdActividad').val(); //id from Actividad
        var idActividadMesSemana = modal.find('#IdActividadMesSemana').val(); //id from ActividadMesSemana

        $('#evidenciaListModal').modal('hide');
        $('#evidenciaModal').on('show.bs.modal', function (event) {
            var modal = $(this);

            modal.find('#IdActividad').val(idActividad);
            modal.find('#Descripcion').val("");
            modal.find('#IdActividadMesSemana').val(idActividadMesSemana);
        })
        $('#evidenciaModal').modal('show');
        setTimeout(function () {
            $(".modal-backdrop").remove();
        }, 500);
    });

    // click on delete button
    $('.evidenciaTable').on('click', 'button.deleteEvidencia', function () {
        var row = $(this).closest("tr");
        var theBtn = $(this);
        var flagDelete = true;
        var Id = parseInt(theBtn.data("id"));

        //getting data
        var urlerino = urlToDelete + Id

        swal({
            title: "¿Está seguro de eliminar la evidencia?",
            text: "El registro no podrá recuperarse.",
            icon: "warning",
            closeModal: false,
            closeOnClickOutside: false,
            buttons: [{
                text: "No",
                value: false,
                visible: true,
                className: "btn btn-outline-dark btn-default",
                closeModal: true,

            }, {
                text: "Sí, eliminar",
                value: true,
                visible: true,
                className: "btn btn-info",
                closeModal: true
            }]
        }).then(value => {
            if (value) {
                AjaxDeleteEvidencia(urlerino, row, flagDelete, theBtn);
            }
        });


    });

});

function DeleteEvidencia(theClickedBtn) {
    var theBtn = $(theClickedBtn);
    var row = theBtn.closest("tr");
    var flagDelete = true;
    var Id = parseInt(theBtn.data("id"));

    //getting data
    var urlerino = urlToDelete + Id

    swal({
        title: "¿Está seguro de eliminar la evidencia?",
        text: "El registro no podrá recuperarse.",
        icon: "warning",
        closeModal: false,
        closeOnClickOutside: false,
        buttons: [{
            text: "No",
            value: false,
            visible: true,
            className: "btn btn-outline-dark btn-default",
            closeModal: true,

        }, {
            text: "Sí, eliminar",
            value: true,
            visible: true,
            className: "btn btn-info",
            closeModal: true
        }]
    }).then(value => {
        if (value) {
            AjaxDeleteEvidencia(urlerino, row, flagDelete, theBtn);
        }
    });
}
//ajax and post behaviors if ok or error
function AjaxDeleteEvidencia(url, row, flagDelete, theBtn) {
    //flag to avoid multiple AJAX Request
    if (flagDelete) {
        theBtn.prop("disabled", true);

        $.ajax({
            type: "GET",
            url: url,
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                //location.reload();
                toastr[result.tipoMensaje](result.mensaje);
                row.hide();
            },
            error: function (xhr) {
                swal({
                    title: "Error al borrar la evidencia. ",
                    text: xhr.responseJSON.statusDescription,
                    icon: "warning",
                    closeModal: false,
                    closeOnClickOutside: false,
                    buttons: "Cerrar"
                });
                theBtn.prop("disabled", false);
            }
        });
    }
}

//create table for modal Evidencia List
function AddRecords(records) {
    var cardContainer = document.createElement("div");
    cardContainer.setAttribute("class", "card card-default");
    cardContainer.setAttribute("id", "cardContainer");

    //no records, show message
    if (records.length == 0) {
        var theCardBody = document.createElement("div");
        theCardBody.setAttribute("class", "card-body");

        var theText = document.createElement("h4");
        theText.setAttribute("class", "card-header text-center");
        theText.innerHTML = "No existen evidencias";

        theCardBody.appendChild(theText);
        cardContainer.appendChild(theCardBody);
        return cardContainer;
    }

    //create table if records is populated
    var theTable = document.createElement("table");
    theTable.setAttribute("class", "table table-striped my-4 w-100 border-gray border evidenciaTable");

    //header
    var theTHead = document.createElement("thead");
    var newRowHeader = document.createElement('tr');
    newRowHeader.appendChild(CreateTHeader("Id"));
    newRowHeader.appendChild(CreateTHeader("Descripción"));
    newRowHeader.appendChild(CreateTHeader("Archivo"));
    newRowHeader.appendChild(CreateTHeader("Eliminar"));
    theTHead.appendChild(newRowHeader);
    theTable.appendChild(theTHead); //to table

    //body
    var theTBody = document.createElement("tbody");
    for (var r of records) {
        var newRow = document.createElement('tr');
        var theUrl = theUrlDownloadEvidencia + r.id

        //id
        var idData = CreateItemWithHref("", r.id);
        newRow.appendChild(idData);

        //descripcion
        var descData = CreateItemWithHref(theUrl, r.descripcion);
        newRow.appendChild(descData);

        //nombre
        var nombreData = CreateItemWithHref(theUrl, r.nombreArchivo);
        newRow.appendChild(nombreData);

        //eliminar
        var buttonData = CreateButton(r.id, "Eliminar", "btn-link deleteEvidencia");
        newRow.appendChild(buttonData);

        theTBody.appendChild(newRow);
    }
    theTable.appendChild(theTBody);

    //to card container
    cardContainer.appendChild(theTable);

    return cardContainer;
}

function CreateTHeader(label) {
    var header = document.createElement('th');
    header.innerHTML = label;

    return header;
}

function CreateItemWithHref(link, value) {
    var theData = document.createElement("td");

    var theLink = document.createElement("a");
    theLink.setAttribute("href", link);
    theLink.innerHTML = value;

    theData.appendChild(theLink);
    return theData;
}

function CreateButton(idValue, title, classBtn) {
    var theData = document.createElement("td");

    var theButton = document.createElement("button");
    theButton.setAttribute("style", 'font-size: 16px;color:#298CB6');
    theButton.setAttribute("data-id", idValue);
    theButton.setAttribute("type", "button");
    theButton.setAttribute("title", title);
    theButton.setAttribute("onclick", "DeleteEvidencia(this)");
    theButton.setAttribute("class", "btn " + classBtn);
    theButton.innerHTML = "<i class='fa far fa-trash-alt'  style='font-size: 16px;color:#298CB6'></i>";

    theData.appendChild(theButton);
    return theData;
}

//success when new evidencia is saved OK
function LaunchSuccessModalEvidencia(data) {
    if (data.message == "Success") {

        incrementaValorReal(objetoMesSemanaEnviado, actividadEvidencia);
        $('#evidenciaModal').modal('hide');
        generaTablaActividades();
        $.LoadingOverlay("hide");
        toastr[data.tipoMensaje](data.mensaje);
        $('#evidenciaModalForm')[0].reset();
        return;
    }

}