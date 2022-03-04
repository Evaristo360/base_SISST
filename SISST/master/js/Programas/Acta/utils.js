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
