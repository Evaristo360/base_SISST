/*
 *
 * Modal.js for custom modals inside the SISST project
 * 
 * 
 * */

//use it when an ajax post has been made
//E.g. <form ... data-ajax-failure="error" ... >
function error(xhr) {
    console.log(xhr)
    LaunchErrorModal(xhr.responseJSON.statusDescription);
}


//required for modals
function LaunchErrorModal(data) {
    console.log("data", data)
    swal({
        title: "Advertencia",
        text: data,
        icon: "warning",
        closeModal: true,
        closeOnClickOutside: true,
        dangerMode: true,
        buttons: [{
            text: "",
            value: false,
            visible: false,
            className: "",
            closeModal: true,
        }, {
            text: "Aceptar",
            value: true,
            visible: true,
            className: "",
            closeModal: true

        }],
    }).then(value => {

    });

}


/**
 * Loading Modal
 * */
function LoadingModal() {
    $('#modalLoad').modal('show');
}

function CloseLoadingModal() {
    $('#modalLoad').modal('hide');
}

/**
 * Success Modal
 * */

function SetAndLaunchModalSuccess(data,
    modalTitle = "Success", modalBody = "Success on request",
    hrefBtnSuccess = "#", txtBtnSuccess = "Aceptar",
    hrefBtnClose = "#", txtBtnClose = "Cerrar",
) {
    $('#modalSuccess').on('show.bs.modal', function (event) {
        var modal = $(this);
        modal.find('.modal-title').text("")
        modal.find('.modal-body').text("")
        modal.find('.modal-title').text(modalTitle)
        modal.find('.modal-body').text(modalBody)

        modal.find('#btnSuccess').attr("href", hrefBtnSuccess)
        modal.find('#btnSuccess').text(txtBtnSuccess)
        modal.find('#btnClose').attr("href", hrefBtnClose)
        modal.find('#btnClose').text(txtBtnClose)
    });
    $("#modalSuccess").modal({
        backdrop: 'static',   // This disable for click outside event
        keyboard: true        // This for keyboard event
    });
}
/**
 * Alert Modal
 * */

function SetAndLaunchModalAlert(data, modalTitle = "Alert", modalBody = "Something has happened") {

    $('#modalAlert').on('show.bs.modal', function (event) {
        var modal = $(this);
        modal.find('.modal-title').text("")
        modal.find('.modal-body').text("")
        modal.find('.modal-title').text(modalTitle)
        modal.find('.modal-body').text(modalBody)
    });
    $("#modalAlert").modal({
        backdrop: 'static',   // This disable for click outside event
        keyboard: true        // This for keyboard event
    });
}