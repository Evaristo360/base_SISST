

$(function ($) {
    /*
    Fecha No Mayor Unobstrusive registration
    */

    $.validator.addMethod("fechanomayor", function (value, element, params) {

        var format = "DD/MM/YYYY";
        var theDate = moment(value, format);
        var compareDate = moment($(params).val(), format);
        var result = theDate.toDate() >= compareDate.toDate();
        return result;
    });

    $.validator.unobtrusive.adapters.add("fechanomayor", ["fechacomparar"], function (options) {
    options.rules["fechanomayor"] = "#" + options.params.fechacomparar;
        options.messages["fechanomayor"] = options.message;
    });

    /*
    END Fecha No Mayor Unobstrusive registration
    */

    /*
    Nullable Fecha No Mayor Unobstrusive registration
    */

    $.validator.addMethod("nullablefechanomayor", function (value, element, params) {
        if (value == '')
            return true;

        var format = "DD/MM/YYYY";
        var theDate = moment(value, format);
        var compareDate = moment($(params).val(), format);
        var result = theDate.toDate() >= compareDate.toDate();

        return result;
    });

    $.validator.unobtrusive.adapters.add("nullablefechanomayor", ["fechacomparar"], function (options) {
    options.rules["nullablefechanomayor"] = "#" + options.params.fechacomparar;
        options.messages["nullablefechanomayor"] = options.message;
    });

    /*
    END Nullable Fecha No Mayor Unobstrusive registration
    */

    /*
    Fecha No Mayor IGUAL Unobstrusive registration
    */

    $.validator.addMethod("fechanomayorigual", function (value, element, params) {
        var format = "DD/MM/YYYY";
        var theDate = moment(value, format);
        var compareDate = moment($(params).val(), format);
        var result = theDate.toDate() > compareDate.toDate();

        return result;
    });

    $.validator.unobtrusive.adapters.add("fechanomayorigual", ["fechacomparar"], function (options) {
        options.rules["fechanomayorigual"] = "#" + options.params.fechacomparar;
        options.messages["fechanomayorigual"] = options.message;
    });

    /*
     END Fecha No Mayor IGUAL Unobstrusive registration
    */

    /*
    * comparetwoproperties addMethod
    * Comapración de genérica de propiedades
    * Juan Miguel González Castro
    * Septiembre 2021
    */
    $.validator.addMethod("comparetwoproperties", function (value, element, param) {
        var otherPropId = $(element).data('val-other');
        var operName = $(element).data('val-compareoperator');

        if (otherPropId) {
            var otherProp = $(otherPropId);
            if (otherProp) {
                var otherVal = otherProp.val();

                var valueProperty = (isNaN(value) ? Date.parse(value) : eval(value));
                var valueOther = (isNaN(otherVal) ? Date.parse(valueOther) : eval(otherVal));

                if (operName == "GreaterThan")
                    return valueProperty > valueOther;
                if (operName == "LessThan")
                    return valueProperty < valueOther;
                if (operName == "GreaterThanOrEqual")
                    return valueProperty >= valueOther;
                if (operName == "LessThanOrEqual")
                    return valueProperty <= valueOther;
            }
        }

        return true;
    });

    /*
    * comparetwoproperties add adapters
    * Inicicia la comparación, por lo pronto no me esta funcioando pues no recupero params
    * Juan Miguel González Castro
    * Septiembre 2021
    */
    $.validator.unobtrusive.adapters.add("comparetwoproperties",
        ["other", "compareoperator"], function (options) {
            options.rules['comparetwoproperties'] = options.params;
            options.messages['comparetwoproperties'] = options.message;
    });


    /*
    * tipoevaluacionsci addMethod
    * Evalua segú el tipo de evaluación los datos requeridos
    * Juan Miguel González Castro
    * Septiembre 2021
    */
    $.validator.addMethod("tipoevaluacionsci", function (value, element, param) {
        var id = $(element).attr("id").split("_")[2];
        var otherPropId = $("#ddl_tipoSCI_" + id);  // $(element).data("#ddl_tipoSCI_" + id);
        var operName = $(element).data('val-typecompare');

        if (otherPropId) {
            var otherProp = $(otherPropId);
            if (otherProp) {
                var otherVal = otherProp.val();

                var valueProperty = (isNaN(value) ? 0 : eval(value));
                var valueOther = (isNaN(otherVal) ? 0 : eval(otherVal));

                if (operName == "Ponderacion")
                    return valueProperty > 0 && valueProperty <= 100;
                else {
                    if (valueOther != 0) {
                        if (operName == "Exacto")
                            return valueProperty > 0;
                        else if (operName == "CualquieraSeleccion")
                            return valueProperty > 1;
                        else if (operName == "CualquieraLista")
                            return true;                        
                    }
                }
            }
        }
        return true;
    });


    /*
    * tipoevaluacionsci add adapters
    * Inicicia la comparación, por lo pronto no me esta funcioando pues no recupero params
    * Juan Miguel González Castro
    * Septiembre 2021
    */
    $.validator.unobtrusive.adapters.add("tipoevaluacionsci",
        ["other", "typecompare"], function (options) {
            options.rules['tipoevaluacionsci'] = options.params;
            options.messages['tipoevaluacionsci'] = options.message;
    });


    /*
    * mayorthan0if addMethod
    * Evalua según el tipo de evaluación los datos requeridos
    * Juan Miguel González Castro
    * Septiembre 2021
    */
    $.validator.addMethod("mayorthan0if", function (value, element, param) {
        var propertyValue = value;
        var dependPropertyValue = $(param).val();
        var result = true;

        if (dependPropertyValue == "true") 
            result = propertyValue > 0;

        return result;
    });


    /*
    * mayorthan0if add adapters
    * Inicia la comparación, por lo pronto no me esta funcioando pues no recupero params
    * Juan Miguel González Castro
    * Septiembre 2021
    */
    $.validator.unobtrusive.adapters.add("mayorthan0if",
        ["other", "datovalidador"], function (options) {
            options.rules['mayorthan0if'] = "#" + options.params.datovalidador;
            options.messages['mayorthan0if'] = options.message;
    });


    /*
    * proteccionpasiva addMethod
    * Evalua según el tipo de evaluación los datos requeridos
    * Juan Miguel González Castro
    * Octubre 2021
    */
    $.validator.addMethod("proteccionpasiva", function (value, element, param) {
        var propertyValue = value;
        var dependPropertyValue = parseInt($(param).val());
        var result = true;
        var proteccionPasiva = {
            // valores tomados de enumProteccionPasiva
            cablesdematerialretardantealfuego: 3592, // Cables de material retardante al fuego
            charolasdecableadoconbarreraantiflama: 3594, // Charolas de cableado con barrera antiflama
            diquedecontencion: 3588, // Dique de contención
            extractoresdeAire: 3595, // Extractores de Aire
            fosacaptadoradehidrocarburo: 3589, // Fosa captadora de hidrocarburo
            mamparaMuroseparador: 3590, // Mampara/Muro separador
            selladodepasamurosconmaterialcontrafuego: 3593, // Sellado de pasamuros con material contrafuego
            trincheraconbarreraantiflama: 3591, // Trinchera con barrera antiflama
        };

        if (isNaN(dependPropertyValue))
            result = true;

        else {
            switch (dependPropertyValue) {
                case proteccionPasiva.diquedecontencion:
                case proteccionPasiva.fosacaptadoradehidrocarburo:
                case proteccionPasiva.mamparaMuroseparador:
                    if (propertyValue == null)
                        result = false;
                    else if (propertyValue == "")
                        result = false;
                    break;

                case proteccionPasiva.extractoresdeAire:
                    if (isNaN(propertyValue))
                        result = false;
                    else {
                        propertyValue = parseInt(value);
                        if (propertyValue == -1)
                            result = false;
                    }
                    break;
                case proteccionPasiva.trincheraconbarreraantiflama:
                case proteccionPasiva.cablesdematerialretardantealfuego:
                case proteccionPasiva.selladodepasamurosconmaterialcontrafuego:
                case proteccionPasiva.charolasdecableadoconbarreraantiflama:
                    if (isNaN(propertyValue))
                        result = false;
                    else {
                        propertyValue = parseInt(value);
                        if (propertyValue < 0 || propertyValue > 100)
                            result = false;
                    }
                    break;
            }
        }
        return result
    });


    /*
    * proteccionpasiva add adapters
    * Inicia la comparación, por lo pronto no me esta funcioando pues no recupero params
    * Juan Miguel González Castro
    * Octubre 2021
    */
    $.validator.unobtrusive.adapters.add("proteccionpasiva",
        ["other", "datovalidador"], function (options) {
            options.rules['proteccionpasiva'] = "#" + options.params.datovalidador;
            options.messages['proteccionpasiva'] = options.message;
    });

    /*
    * proteccionpasiva addMethod
    * Evalua según el tipo de evaluación los datos requeridos
    * Juan Miguel González Castro
    * Octubre 2021
    */
    $.validator.addMethod("requiredif", function (value, element, param) {
        var valueProperty = value,
            valueDependProperty = $(param.split(",")[0]).val(),
            valueToMatchDependProperty = param.split(",")[1],
            result = true;

        if (valueDependProperty) {
            if (valueDependProperty == valueToMatchDependProperty) {
                if (valueProperty) {
                    if (valueProperty == "")
                        result = false;
                }
                else 
                    result = false;
            }
        }
        return result
    });


    /*
    * proteccionpasiva add adapters
    * Inicia la comparación, por lo pronto no me esta funcioando pues no recupero params
    * Juan Miguel González Castro
    * Octubre 2021
    */
    $.validator.unobtrusive.adapters.add("requiredif",
        ["valordatovalidador", "datovalidador"], function (options) {
            options.rules['requiredif'] = "#" + options.params.datovalidador + "," + options.params.valordatovalidador;
            options.messages['requiredif'] = options.message;
    });


}(jQuery));
