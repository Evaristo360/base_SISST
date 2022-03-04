var GilSuperviciones = new Object();
GilSuperviciones[3920] = 3920;
//GilSuperviciones[3923] = 3923;

var GilHerramientas = new Object();
GilHerramientas[3923] = 3923;

var GilHerramientasActividades = new Object();
GilHerramientasActividades[4082] = 4082;

var datosWebService = new Object();

//definition default
if (typeof banderasGil === 'undefined') {
    banderasGil = { supervicion: false, herramientas: false };
}

var leyendasGil = new Object();
leyendasGil.alertaSinActividad = '<div class="alert alert-primary">Sin Actividad Asignada</div>';
leyendasGil.alertaSinTrabajadores = '<div class="alert alert-primary">No existen trabajadores asociados</div>';

$(document).ready(function () {
    //alert("Hola");
    //inicializaGil();
});
function inicializaGil() {

    if (banderasGil.supervicion == true) {
        if (elementoSeleccionado == GilSuperviciones[elementoSeleccionado] || elementoSeleccionado == GilHerramientas[elementoSeleccionado]) {
            $("#EncabezadoGilSuperviciones").show();
            //Cambiar las leyendas dependiendo si es Supervisiones o Herramientas
            if (elementoSeleccionado == GilHerramientas[elementoSeleccionado]) {
                $(".LeyendaGilSH").html("Herramientas");
            }
            else {
                $(".LeyendaGilSH").html("Superviciones");
            }
        }
        else {
            $("#EncabezadoGilSuperviciones").hide();
        }
        $("#btnAddActividadGil").unbind("click");
        $("#btnAddActividadGil").bind("click", function () {
            $("#ModalActividadGil").modal("show");
            setTimeout(function () {
                $(".modal-backdrop").remove();
            }, 500);
            generaActividadesModal();
        });
        resumenListaActividadesGil();
        tablaTrabajadoresGil();
        busquedaGilTrabajadores();
    }
    else {
        $("#EncabezadoGilSuperviciones").hide();
    }
    
}

function generaActividadesModal() {
    var contenido = "";
    var Actividades = programaSST.Elementos[elementoSeleccionado].Actividades;
    contenido += '<div class="card card-default table-responsive">';
    contenido += '<table class="table table-striped">';
    contenido += '<tbody>';
    $.each(Actividades, function (itemActividad, objetoActividad) {
        contenido += '<tr>';
            contenido += '<td>';
            contenido += muestraListaActividadesGilFormulario(objetoActividad);
            contenido += '</td>';
            contenido += '<td>';
            contenido += objetoActividad.actividadDescripcion;
            contenido += '</td>';
        contenido += '</tr>';
    });
    contenido += '</tbody>';
    contenido += '</table>';
    contenido += '</div>';

    $("#ActividadGilForm").html(contenido);
    muestraListaActividadesGilFormularioFn();
}


function agregaNuevaActividadGilListadoFormulario(clave, checked) {
    var checkedActividad = "";
    if (checked == true) {
        checkedActividad = " checked='checked' ";
    }
    return "<div><label class='c-checkbox'> <input id='ActividadGil_" + clave + "' type='checkbox' name='actividadesGil[]' class='actividadesGil' value='" + clave + "' " + checkedActividad + "> <span class='fa fa-check'></div>";
}
function muestraListaActividadesGilFormulario(actividad) {
    //console.log(actividad);
    return agregaNuevaActividadGilListadoFormulario(actividad.idActividad, actividad.esGilSupervision);
    //
}
function muestraListaActividadesGilFormularioFn() {
    $("#aceptarActividadGil").unbind("click");
    $("#aceptarActividadGil").bind("click", function () { 
    
        var checkActividades = $(".actividadesGil");

        $(checkActividades).each(function (item, inputActividad) {
            //console.log(inputActividad);
            
            var actividadId = $(inputActividad).val();
            var seleccionado = $(inputActividad).prop("checked");
            if (programaSST.Elementos[elementoSeleccionado].Actividades[actividadId].esGilSupervision != seleccionado) {
                if (seleccionado) {
                    programaSST.Elementos[elementoSeleccionado].Actividades[actividadId].actualizaGilSupervision(true);
                }
                else {
                    programaSST.Elementos[elementoSeleccionado].Actividades[actividadId].actualizaGilSupervision(false);
                }
                programaSST.Elementos[elementoSeleccionado].Actividades[actividadId].actualizarActividad();
            }
        });
    
    });
}

function tablaTrabajadoresGil() {
    var contenido = "";
    var gilRpe = programaSST.Elementos[elementoSeleccionado].gilRpe;
    
    var totalGilRpe = $(gilRpe).length;
    //console.log("totalGilRpe :: ", totalGilRpe );
    if (totalGilRpe > 0) {
        contenido += '<div class="card card-default table-responsive">';
        contenido += '<table class="table table-striped">';
        contenido += '<tbody>';
        $.each(gilRpe, function (itemgilRpe, objetogilRpe) {
            contenido += '<tr>';
            contenido += '<td>';
            contenido += objetogilRpe.rpe;
            contenido += '</td>';
            contenido += '<td>';
            contenido += objetogilRpe.rpeNombre;
            contenido += '</td>';
            contenido += '<td>';
            //contenido += objetoActividad.actividadDescripcion;
            contenido += '<button gilRpeId="' + objetogilRpe.id + '" rpe="' + objetogilRpe.rpe + '" class="btn btn-outline-danger btn-circle eliminaTrabajadorGil" type="button"><i class="fa fa-trash"></i></button>';
            contenido += '</td>';

            contenido += '</tr>';
        });
        contenido += '</tbody>';
        contenido += '</table>';
        contenido += '</div>';
    }
    else {
        contenido = leyendasGil.alertaSinTrabajadores;
    }
    $("#RpeGilSuperviciones").html(contenido);
    tablaTrabajadoresGilFn();
}
function tablaTrabajadoresGilFn() {
    $(".eliminaTrabajadorGil").unbind("click");
    $(".eliminaTrabajadorGil").bind("click", function () {
        var rpe = $(this).attr("rpe");

        swal({
            title: "Desvincular trabajador",
            text: "¿Está seguro quiere desvincular este trabajador? \n ",
            icon: "warning",
            buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, desvincular!", value: !0, visible: !0, className: "bg-warning", closeModal: true } }

        }).then(function (e) {
            if (e) {
                programaSST.Elementos[elementoSeleccionado].gilRpe[rpe].elimina();
            }
            else {
                swal.close();
            }
        });
    });
}

function resumenListaActividadesGil() {
    var contenido = "";
    var totalActividadesGil = 0;
    var Actividades = programaSST.Elementos[elementoSeleccionado].Actividades;

    $.each(Actividades, function (itemActividad, objetoActividad) {
        if (objetoActividad.esGilSupervision == true) {
            totalActividadesGil++;
        }
    });
    if (totalActividadesGil > 0) {
        contenido += '<div class="card card-default table-responsive">';
        contenido += '<table class="table table-striped">';
        contenido += '<tbody>';
        $.each(Actividades, function (itemActividad, objetoActividad) {
            if (objetoActividad.esGilSupervision == true) {
                contenido += '<tr>';
                contenido += '<td>';
                contenido += objetoActividad.actividadDescripcion;
                contenido += '</td>';
                contenido += '<td>';
                //contenido += objetoActividad.actividadDescripcion;
                contenido += '<button actividadId="' + objetoActividad.idActividad+'" class="btn btn-outline-danger btn-circle eliminaActividadGil" type="button"><i class="fa fa-trash"></i></button>';
                contenido += '</td>';
                
                contenido += '</tr>';
            }
        });
        contenido += '</tbody>';
        contenido += '</table>';
        contenido += '</div>';
    }
    else {
        contenido = leyendasGil.alertaSinActividad;
    }

    $("#ResultadosGilSuperviciones").html(contenido);
    resumenListaActividadesGilFn();
}
function resumenListaActividadesGilFn() {
    $(".eliminaActividadGil").unbind("click");
    $(".eliminaActividadGil").bind("click", function () {
        var actividadId = numeral($(this).attr("actividadId")).value();
        programaSST.Elementos[elementoSeleccionado].Actividades[actividadId].actualizaGilSupervision(false);
        programaSST.Elementos[elementoSeleccionado].Actividades[actividadId].actualizarActividad();
    });
    
}

function GetTrabajadoresGil() {
    var rpe = $("#txtRPEGil").val();
    if (!(rpe.length > 3 && rpe.length < 6)) {
        return false;
    }
    $("#txtRPEGil").val("");
    if (!verificaExisteTrabajador(rpe)) {
        return false;
    }
    var urlAction = urlGetTrabajadoresByRPE + rpe;
    $.ajax({
        type: 'GET',
        url: urlAction,
        dataType: 'json',
        success: function (dataTrabajador) {
            //console.log(dataTrabajador);
            vincularTrabajadorGil(rpe, dataTrabajador.nombreCompleto, 1);
            //AssignTrabajadorData(dataTrabajador);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            vincularTrabajadorGil(rpe, "", 0);
        }
    });
}
function verificaExisteTrabajador( rpe ) {
    //console.log(dataTrabajador);
    //Verificar si existe ese RPE
    var id = 0;
    try {
        id = programaSST.Elementos[elementoSeleccionado].gilRpe[rpe].id
    }
    catch( ex )
    {
        id = 0;
    }
    if (id > 0) {
        swal({
            title: "Trabajador Repetido",
            text: "El trabajador con rpe("+rpe+") ya se encuentra vinculado.",
            icon: "warning",
            buttons: { confirm: { text: "Aceptar", value: !0, visible: !0, className: "bg-success", closeModal: true } }

        }).then(function (e) {
            swal.close();
        });
        return false;
    }
    else {
        return true;
    }
}
function vincularTrabajadorGil(rpe, nombreTrabajador, encontroTrabajador = 0) {
    if (encontroTrabajador == 0) {
        swal({
            title: "Trabajador no encontrado",
            text: "No se encontro el trabajador en el sistema. \n ¿Está seguro quiere vincular este Rpe al registro? \n ",
            icon: "warning",
            buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, agregarlo!", value: !0, visible: !0, className: "bg-warning", closeModal: true } }

        }).then(function (e) {
            if (e) {
                guardaTrabajadorGil(rpe, nombreTrabajador);
            }
            else {
                swal.close();
            }
        });
    }
    else {
        guardaTrabajadorGil(rpe, nombreTrabajador)
    }
}
function guardaTrabajadorGil(rpe, nombreTrabajador) {
    var objetoGilRpe = new Object({
        id: 0,
        idPrograma: programaSST.id,
        idElemento: programaSST.Elementos[elementoSeleccionado].id,
        rpe: rpe,
        rpeNombre: nombreTrabajador,
    });
    programaSST.Elementos[elementoSeleccionado].gilRpe[rpe] = new gilRpe();
    programaSST.Elementos[elementoSeleccionado].gilRpe[rpe].agregar(objetoGilRpe);
    programaSST.Elementos[elementoSeleccionado].gilRpe[rpe].vincular();
    
}
function busquedaGilTrabajadores() {
    $("#btnGilBuscarRPETrabajador").unbind("click");
    $("#btnGilBuscarRPETrabajador").bind("click", function () {
        GetTrabajadoresGil();
    });
    $("#txtRPEGil").unbind("keypress");
    $("#txtRPEGil").bind("keypress", function (e) {
        if (e.keyCode == 13)
        {
            e.preventDefault();
            GetTrabajadoresGil();
        }
    });

}
function ModalEvidenciaGilSupervicion( mes ) {
    if (mes >= mesActual - 1 && diaActual <= programaSST.diaCorte) {
        ModalEvidenciaGilSupervicionFn( mes );
    }
    else if (mes >= mesActual) {
        ModalEvidenciaGilSupervicionFn( mes );
    }
    else {
        //$("#ModalActividadGilEvidencias").hide();
    }
}
function ModalEvidenciaGilSupervicionFn(mes) {
    if (Object.keys(programaSST.Elementos[elementoSeleccionado].gilRpe).length > 0) {
        var gilRpe = programaSST.Elementos[elementoSeleccionado].gilRpe;

        var rpeArr = new Array();
        $.each(gilRpe, function (itemgilRpe, objetogilRpe) {
            rpeArr.push(objetogilRpe.rpe);
        });

        //var objetoEnvia = { rpes: rpeArr.join(), anio: programaSST.anio, mes: mes };
        var objetoEnvia = new Object({ rpes: rpeArr.join(), anio: programaSST.anioElaboracion, mes: mes });
        //objetoEnvia.rpes = rpeArr.join();
        //objetoEnvia.anio = programaSST.anio;
        //objetoEnvia.mes = mes;
        console.log(objetoEnvia );

        $.post(urlGilSupervicionWebService, objetoEnvia, function (data) {
            if (data.message == "SuccessReturn")
            {
                toastr.options.positionClass = 'toast-bottom-right';
                toastr['success']('WebService ejecutado');
                console.log( data );
                ModalEvidenciaGilSupervicionOpen(data.respuesta);

            }
        }, "json");
    }
    else {
        swal({
            title: "Falta Supervisores",
            text: "No se pueden obtener las evidencias de los supervisores porque no hay trabajadores asignados.",
            icon: "warning",
            buttons: { confirm: { text: "Aceptar", value: !0, visible: !0, className: "bg-success", closeModal: true } }

        }).then(function (e) {
            swal.close();
        });
    }
}
function ModalEvidenciaGilSupervicionOpen(respuesta) {
    datosWebService = respuesta;
    if (datosWebService.mes > 0) {
        $('#ModalActividadGilEvidencias').on('show.bs.modal', function (event) {
            var MesNombre = mesesCatalogo[respuesta.mes - 1].mes;
            $(".ModalActividadGilEvidenciasMes").html(MesNombre + " " + programaSST.anioElaboracion);
            $("#ModalActividadGilEvidenciasCompromisos").html(datosWebService.valor);
            $("#ModalActividadGilEvidenciasSuperviciones").html(datosWebService.valorReal);
            tablaSupervisionesGILEvidencia();
        });
        $('#ModalActividadGilEvidencias').modal('show');
        setTimeout(function () {
            $(".modal-backdrop").remove();
        }, 500);
    }
    else {
        toastr.options.positionClass = 'toast-bottom-right';
        toastr['warning']('No se pudo completar el webService de Gil Supervisiones');
    }
}
function tablaSupervisionesGILEvidencia() {
    var contenido = "";
    var gilRpe = programaSST.Elementos[elementoSeleccionado].gilRpe;

    var totalGilRpe = $(gilRpe).length;
    //console.log("totalGilRpe :: ", totalGilRpe );
    if (totalGilRpe > 0) {
        contenido += '<div class="card card-default table-responsive">';
        contenido += '<table class="table table-striped">';
        contenido += '<thead>';
        contenido += '<tr>';
        contenido += '<td>';
        contenido += "RPE";
        contenido += '</td>';
        contenido += '<td>';
        contenido += "Nombre";
        contenido += '</td>';
        contenido += '</tr>';
        contenido += '</thead>';
        contenido += '<tbody>';
        $.each(gilRpe, function (itemgilRpe, objetogilRpe) {
            contenido += '<tr>';
            contenido += '<td>';
            contenido += objetogilRpe.rpe;
            contenido += '</td>';
            contenido += '<td>';
            contenido += objetogilRpe.rpeNombre;
            contenido += '</td>';
            contenido += '</tr>';
        });
        contenido += '</tbody>';
        contenido += '</table>';
        contenido += '</div>';
    }
    else {
        contenido = leyendasGil.alertaSinTrabajadores;
    }
    $("#ActividadGilEvidenciasForm").html(contenido);
}