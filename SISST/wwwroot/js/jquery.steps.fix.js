/**
 * Ajusta el tamano del wizard, en base al contenido,
 * Tambin se debe ajustar el CCS para eliminar min height
 */
function resizeJquerySteps() {

    $('.wizard .content').animate({ height: $('.body.current').outerHeight() }, 'slow');
}


$(window).resize(debounce(resizeJquerySteps, 250));

/**
 * Retrasa la ejecuion de una funcion 
 */
function debounce(func, timeout = 300) {
    var timer;
    return (...args) => {
        clearTimeout(timer);
        timer = setTimeout(() => { func.apply(this, args); }, timeout);
    };
}