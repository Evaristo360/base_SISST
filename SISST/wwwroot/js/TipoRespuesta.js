

$(document).ready(function () {
    
    $('.deleteItemListConfirmation').click(function (event) {
        event.preventDefault();
        event.stopPropagation();
        var form = this.closest('form');
        $.LoadingOverlay("hide");
        swal({
            title: "¿Está seguro de eliminar el registro?",
            text: "Se eliminará el registro de manera permanente, por lo que será imposible su recuperación. \n ",
            icon: "warning",
            buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, eliminarlo!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

        }).then(function (e) {
            if (e) {               
                $.LoadingOverlay("show");
                form.submit();
            }
            else {
                swal.close();
            }
        });       
    });

  
});// Modal for deleteItemListConfirmation
