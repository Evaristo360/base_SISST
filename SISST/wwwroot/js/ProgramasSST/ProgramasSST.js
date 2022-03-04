var programaId = 0;
var urlPrograma = "";
var datosProgramaActual = new Object();
//Programa
let urlGuardaPrograma = "";

// Ligas para guardar
let urlElementoPrograma = "";
let urlActividadPrograma = "";
let urlMesSemanaPrograma = "";
let urlElementoRecursos = "";
let urlElementoGilRpe = "";

// Ligas para eliminar
let urlEliminaElementoPrograma = "";
let urlEliminaActividadPrograma = "";
let urlEliminaElementoRecurso = "";
let urlEliminaElementoGilRpe = "";
//Ligas para evidencia
let urlListEvidencia = "";
let theUrlDownloadEvidencia = "";

//Ligas para AvanceMensual
let obtieneCreateAvanceMensual = "";
let obtieneGetAvanceMensual = "";
let urlGetAvanceMensualAnio = "";

//Ligas para Gil Supervicion
let guardaGilSupervisionRpe = "";
let urlGilSupervicionWebService = "";

//Peticiones
let noPeticionesActualiza = 0;

const fecha = new Date();
const anioActual = fecha.getFullYear();
const mesActual = fecha.getMonth() + 1;
const diaActual = fecha.getDate();
//alert(diaActual);

let totalPeticionesAvanceMensual = 0;

/* Configuracion de Programas SST */
var programaSST = new Object();
programaSST.Elementos = new Object();
programaSST.id = 0;
programaSST.sumaPonderacion = 0;
programaSST.diaCorte = 9;
programaSST.anioElaboracion = 0;

programaSST.idResponsable = 0;
programaSST.responsableRPE = '';
programaSST.responsableNombre = '';
programaSST.responsableRPENombre = '';

programaSST.idRevisa = 0;
programaSST.revisaRPE = '';
programaSST.revisaNombre = '';
programaSST.revisaRPENombre = '';

programaSST.IdAprueba = 0;
programaSST.apruebaRPE = '';
programaSST.apruebaNombre = '';
programaSST.apruebaRPENombre = '';

programaSST.AvanceMensual = new Object();

$(document).ready(function () {
    $("#dvActividades").hide();
    /* Catalogos de Elementos y Actividades */
    ElementosObj = CatalogoElementos["Elementos"];
    ActividadesObj = CatalogoElementos["Actividades"];
    programaSST.id = programaId;
    /* Iniciando Programas SST */
    if (programaId == 0) {
        /* Generando Tabla de Elementos*/
        generaColumnasElementos();
        generaTablaElementos();
        inicializaElementos();
    }
    $("#GuardarPrograma").unbind("click");
    $("#GuardarPrograma").bind("click", function () {
        $.post(urlGuardaPrograma, datosProgramaActual);
    });
});
function guardaElemento(objetoGuardar) {
    $.post(urlElementoPrograma, objetoGuardar);
}

function ResponsableColumna(list, id) {
    for (var i = 0; i < list.length; i++) {
        if (list[i].key == id)
            return list[i].key + " - " + list[i].label || "";
    }
    return "";
}
function inicializaPrograma() {
    $.LoadingOverlay("show");
    json_mvc(urlPrograma, "", "", function (datosPrograma) {
        $.LoadingOverlay("hide");
        datosProgramaActual = datosPrograma.elementos;
        if (datosPrograma.elementos != null) {

            programaSST.id = programaId;
            programaSST.anioElaboracion = anioActual;
            /* Configuración del Gantt */
            $.each(datosPrograma.elementos, function (itemElemento, objetoElemento) {
                //console.log("objetoElemento :: ", objetoElemento);
                /* Obtener las actividades */
                var elemento = objetoElemento;
                //console.log("Elemento",  elemento );
                var actividades = elemento.actividades;
                //Borrar las actividades 

                //Verificar si es de catalogo o es personalizado
                elemento.esCatalogo = true;
                if (elemento.idElemento == 0) {
                    elemento.esCatalogo = false;
                    var currentDate = new Date();
                    var timestamp = currentDate.getTime()+elemento.id;
                    nuevaElemento(elemento.elemento, timestamp);
                    elemento.idElemento = timestamp;
                }

                delete elemento.actividades;
                programaSST.Elementos[elemento.idElemento] = new Elemento();
                
                programaSST.Elementos[elemento.idElemento].agregarElemento(elemento);
                programaSST.Elementos[elemento.idElemento].inicializaMes();

                elementoSeleccionado = elemento.idElemento;

                programaSST.Elementos[objetoElemento.idElemento].Actividades = new Object();
                $.each(actividades, function (itemActividad, objetoActividad) {
                    objetoActividad.esCatalogo = true;
                    if (objetoActividad.idActividad == 0) {
                        //console.log("Actividad no Catalogo ");
                        

                        objetoActividad.esCatalogo = false;
                        //var currentDate = new Date();
                        //var timestamp = currentDate.getTime() + objetoActividad.id;
                        var timestamp = 4500 + objetoActividad.id;
                        nuevaActividad(objetoActividad.actividadDescripcion, timestamp, elemento.idElemento);
                        objetoActividad.idActividad = timestamp;

                        //console.log(objetoActividad);
                    }
                    //console.log("Actividad", objetoActividad);
                    programaSST.Elementos[elemento.idElemento].Actividades[objetoActividad.idActividad] = new Actividad();
                    programaSST.Elementos[elemento.idElemento].Actividades[objetoActividad.idActividad].agregarActividad(objetoActividad);

                });
            });
            /* Configuracion de avance Mensual */
            generaAvanceMensual(datosPrograma.avancePorMes);
            /* Genera Avance Mensual */
            temporalizadorAvanceMensual();
            
        }
    });
}
function temporalizadorAvanceMensual() {
    generaColumnasElementos();
    generaTablaElementos();
    inicializaElementos();
}
function generaAvanceMensual(datosAvanceMensual) {
    programaSST.AvanceMensual = new Object();
    $.each(mesesCatalogo, function (itemMes, objetoMes) {
        programaSST.AvanceMensual[objetoMes.id] = new AvanceMensual();
        programaSST.AvanceMensual[objetoMes.id].idPrograma = programaSST.id;
        programaSST.AvanceMensual[objetoMes.id].mes = objetoMes.id;
    });
    
    $.each(datosAvanceMensual, function (itemAvanceMensual, objetoAvanceMensual) {
        var mes = objetoAvanceMensual.mes
        programaSST.AvanceMensual[mes].agregarAvanceMensualGantt(objetoAvanceMensual);
    });

    /*
    $.each(programaSST.AvanceMensual, function (itemAvanceMensual, objetoAvanceMensual) {
        if (objetoAvanceMensual.id == 0) {
            //var mes = objetoAvanceMensual.mes
            objetoAvanceMensual.createAvanceMensual();
        }
    });
    */
    //console.log(programaSST.AvanceMensual);
}
function toUnicode(str) {
    //str.normalize();
    return str;
}