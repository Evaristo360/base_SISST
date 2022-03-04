class MesElemento {
    total = 0;
    totalReal = 0;
    avanceElementosProgramadas = 0;
    porcentajeElementosProgramadas = 0;
    PorcentajeAvance = 0;
    AvanceAcumuladoPeriodoAnterior = 0;
    AvanceAcumuladoPeriodoAnteriorAvanceReal = 0;
    AcumuladoPeriodoAnteriorPorcentajeAvance = 0;
}
class gilRpe
{
    id = 0;
    idPrograma = 0;
    idElemento = 0;
    rpe = "";
    rpeNombre = "";
    constructor() {
        this.id = 0;
        this.idPrograma = 0;
        this.idElemento = 0;
        this.rpe = "";
        this.rpeNombre = "";
    }
    agregar(objetogilRpe) {
        if (objetogilRpe.id != null) this.id = objetogilRpe.id;
        if (objetogilRpe.idPrograma != null) this.idPrograma = objetogilRpe.idPrograma;
        if (objetogilRpe.idElemento != null) this.idElemento = objetogilRpe.idElemento;
        if (objetogilRpe.rpe != null) this.rpe = objetogilRpe.rpe;
        if (objetogilRpe.rpeNombre != null) this.rpeNombre = objetogilRpe.rpeNombre;
        this.rpeNombre = this.rpeNombre.trim();
        if (this.rpeNombre == "") this.rpeNombre = "- RPE SIN EXISTIR EN SISST -";
    }
    elimina() {
        var idGilRpe = this.id;
        var rpeGilRpe = this.rpe;
        $.post(urlEliminaElementoGilRpe, new Object({ id: idGilRpe }), function (data) {
            if (data.message == "SuccessReturn") {
                toastr.options.positionClass = 'toast-bottom-right';
                toastr['success']('Trabajador desvinculado');
                delete programaSST.Elementos[elementoSeleccionado].gilRpe[rpeGilRpe];
                tablaTrabajadoresGil();
            }
        }, "json");

    }
    vincular(objetogilRpe) {
        //this.agregar(objetogilRpe);
        var elementoActualizar = this;
        $.post(urlElementoGilRpe, this.retornaObjeto(), function (data) {

            if (data.message == "SuccessReturn")
            {
                toastr.options.positionClass = 'toast-bottom-right';
                toastr['success']('Trabajador vinculado');
                elementoActualizar.id = data.resultado.id;
                tablaTrabajadoresGil();
            }
        }, "json");
    }
    retornaObjeto()
    {
        var objeto = new Object({
            id: this.id,
            idPrograma: this.idPrograma,
            idElemento: this.idElemento,
            rpe: this.rpe
        });
        return objeto;
    }

}
class Elemento {
    esCatalogo = true;
    id = 0;
    idPrograma = 0;
    idElemento = 0;
    elemento = "";
    ponderacion = 0;

    /* responsables */
    idResponsable = 0;
    responsableRPE = "";
    responsableNombre = "";
    responsableRPENombre = "";

    elaboraNombre = ""; 

    mes = new Object();
    recursos = new Object();
    Actividades = new Object();
    gilRpe = new Object();

    constructor() {
        //this.nombre = n;
    }
    actualizaCatalogoElementos(CatalogoElementos) {
        this.catalogoElementos = CatalogoElementos;

    }
    inicializaMes() {
        var Meses = new Object();
        $.each(mesesCatalogo, function (itemMes, objetoMes) {
            Meses[objetoMes.id] = new MesElemento();
        });
        this.mes = Meses;
    }
    inicializagilRpe(objetoElemento) {
        this.gilRpe = new Object();
        var gilRpeTmp = new Object();
        
        try {
            $.each(objetoElemento.gilRpe, function (itemgilRpe, objetogilRpe) {
                //console.log("agrega gilRpe ::", objetogilRpe);
                gilRpeTmp[objetogilRpe.rpe] = new gilRpe();
                gilRpeTmp[objetogilRpe.rpe].agregar(objetogilRpe);
            });
        }
        catch (ex) {
            console.warn("No se encuentra el objeto gilRpe dentro de Elemento :: " + this.elemento);
        }
        this.gilRpe = gilRpeTmp;
    }
    agregarElemento(objetoElemento) {
        if (objetoElemento.esCatalogo != null) this.esCatalogo = objetoElemento.esCatalogo;

        if (objetoElemento.id != null) this.id = objetoElemento.id;
        if (objetoElemento.idPrograma != null) this.idPrograma = objetoElemento.idPrograma;
        if (objetoElemento.idElemento != null) this.idElemento = objetoElemento.idElemento;
        if (objetoElemento.elemento != null) this.elemento = objetoElemento.elemento;
        if (objetoElemento.ponderacion != null) this.ponderacion = objetoElemento.ponderacion;

        /* responsables */
        if (objetoElemento.idResponsable != null) this.idResponsable = objetoElemento.idResponsable;
        if (objetoElemento.responsableRPE != null) this.responsableRPE = objetoElemento.responsableRPE;
        if (objetoElemento.responsableNombre != null) this.responsableNombre = objetoElemento.responsableNombre;
        if (objetoElemento.responsableRPENombre != null) this.responsableRPENombre = objetoElemento.responsableRPENombre;

        if (objetoElemento.elaboraNombre != null)  this.elaboraNombre = objetoElemento.elaboraNombre;

        if (objetoElemento.actividades != null) this.Actividades = objetoElemento.actividades;
        if (objetoElemento.recursos != null) this.recursos = objetoElemento.recursos;
        this.inicializaMes();
        this.inicializagilRpe(objetoElemento);
        //console.log(objetoElemento);
        
    }
    agregarElementoNuevo(objetoElemento, elementoIndex ) {
        this.agregarElemento(objetoElemento);
        this.guardaElemento(elementoIndex);
    }
    guardaElemento(elementoIndex) {
        //var elementoGuardar = this;
        $.post(urlElementoPrograma, this.retornaObjeto(), function (data) {
            if (data.id > 0) {
                toastr.options.positionClass = 'toast-bottom-right';
                toastr['success']('Elemento Guardado');
                //this.id = data.id;
                //elementoGuardar.actualizaId( data.id );
                programaSST.Elementos[elementoIndex].id = data.id;
            }
        }, "json");
    }
    actualizarElemento() {
        $.post(urlElementoPrograma, this.retornaObjetoActualizar(), function (data) {
            if (data.id > 0) {
                toastr.options.positionClass = 'toast-bottom-right';
                toastr['success']('Elemento Guardado');
                this.id = data.id;
            }
        }, "json");
    }
    eliminaElemento() {
        if (this.id > 0) {
            $.post(urlEliminaElementoPrograma, new Object({
                id: this.id,
                idPrograma: this.idPrograma,
                idElemento: this.idElemento
            }), function (data) {
                    toastr.options.positionClass = 'toast-bottom-right';
                    toastr['success']('Elemento Eliminado');
            }, "json");
            return true;
        }
        else {
            return true;
        }
    }
    retornaObjeto() {
        var idElemento = this.esCatalogo == true ? this.idElemento : 0;
        var objeto = new Object({
            id: this.id,
            idPrograma: this.idPrograma,
            idElemento: idElemento,
            elemento: this.elemento,
            ponderacion: this.ponderacion,
            /* responsables */
            idResponsable: this.idResponsable,
            responsableRPE: this.responsableRPE,
            elaboraNombre: this.elaboraNombre,
            recursos: this.recursos,
            Actividades: this.Actividades
            }
        );
        return objeto;
    }
    retornaObjetoActualizar() {
        var idElemento = this.esCatalogo == true ? this.idElemento : 0;
        var objeto = new Object({
            id: this.id,
            idPrograma: this.idPrograma,
            idElemento: idElemento,
            elemento: this.elemento,
            ponderacion: this.ponderacion,
            /* responsables */
            idResponsable: this.idResponsable,
            responsableRPE: this.responsableRPE,
            elaboraNombre: this.elaboraNombre
            //recursos: this.recursos
            //Actividades: this.Actividades
        }
        );
        return objeto;
    }
}
var responsableElementoHtml = "";
var elementoSeleccionado = 0;
var elementoObj = null;
var contenedorPrincipal = null;
var contenedor = "dvElementos";

var anchoPanelElementos = 425; //Define el ancho del panel izquierdo de los elementos
var anchoPanelElementosCentral = 650; //Define el ancho del panel central de los elementos
var anchoTotalPanel = 1257; //Define el tamaño total del Panel Principal
var anchoPanelElementosDerecho = anchoTotalPanel - anchoPanelElementosCentral - anchoPanelElementos; //Define el ancho del panel derecho de los elementos
var altoFila = 50;// Define el alto de los Elementos y del los encabezados

var ElementosObj = new Object();
var ActividadesObj = new Object();
//programaSST.Actividades = new Object();

//definition default
if (typeof banderasElementos === 'undefined') {
    banderasElementos = { editar: true, ponderacion: true, rpe: true, elimina: true, recursos: true, editaPonderacion:true};
}


var columnsElementos = [
    { name: "elemento", label: "Elemento", width: 170 },
    //{ name: "responsableRPE", label: "Responsable", width: 120 },
    { name: "recursos", label: "Recursos", width: 150 },
    { name: "ponderacion", label: "Ponderaci\u00f3n", width: 50 },
    { name: "buttons", label: "Opciones", width: 55 }
];

var columnsElementosDerecho = [
    { name: "responsableRPE", label: "Responsable", width: anchoPanelElementosDerecho },
];
var columnaResponsableRPE = { name: "responsableRPE", label: "Responsable", width: anchoPanelElementosDerecho };

var pieElementos = [
    { name: "avanceProgramado", label: "Avance de los elementos programado" },
    { name: "avanceReal", label: "Avance real" },
    { name: "avanceRealPorc", label: "Porcentaje de avance" },
    { name: "acumuladoPorc", label: "Avance acumulado al periodo" },
    /*
    { name: "avanceReal2", label: "Avance real" },
    { name: "porcentajeAvance2", label: "Porcentaje de avance" }
    */
];


/* Funciones */
function generaColumnasElementos() {
    var anchoResponsable = 0;
    /*
    $(columnsElementos).each(function (item, valor) {
        if (valor.name == "responsableRPE" && banderasElementos.rpe != true) {
            anchoResponsable = valor.width;
        }
    });
    */
    $(columnsElementos).each(function (item, valor) {
        var anchoColumna = valor.width;
        var columnaMostrar = true;
        /*
        if (valor.name == "responsableRPE" && banderasElementos.rpe != true ) {
            columnaMostrar = false;
        }
        */
        if (valor.name == "elemento" && banderasElementos.rpe != true)
        {
            anchoColumna += anchoPanelElementosDerecho;
        }
        if (columnaMostrar) {
            $("#dvElementosEncabezado").append('<div class="gantt_grid_head_cell gantt_grid_head_owner" style="width:' + anchoColumna + 'px;" role="columnheader" aria-label="' + valor.label + '" data-column-id="' + valor.name + '" column_id="' + valor.name + '" data-column-name="' + valor.name + '" data-column-index="0">' + valor.label + '</div>');
        }
    });

    if (banderasElementos.rpe == true) {
        $(columnsElementosDerecho).each(function (item, valor) {
            var anchoColumna = valor.width;
            $("#PanelElementosDerechoEncabezado").append('<div class="gantt_grid_head_cell gantt_grid_head_owner" style="width:' + anchoColumna + 'px;" role="columnheader" aria-label="' + valor.label + '" data-column-id="' + valor.name + '" column_id="' + valor.name + '" data-column-name="' + valor.name + '" data-column-index="0">' + valor.label + '</div>');
        });
    }
}

function generaTablaElementos() {
    if (banderasElementos.rpe != true)
    {
        $(".panelElementos").width(anchoPanelElementos + anchoPanelElementosDerecho);
        $(".panelElementosDerecho").hide();
    }
    else
    {
        $(".panelElementos").width(anchoPanelElementos);
        $(".panelElementosDerecho").show();
    }

    $(".panelElementosCentral").width(anchoPanelElementosCentral);
    $(".panelElementosDerecho").width(anchoPanelElementosDerecho);
    $("#EncabezadoTablaElementosAnio").html(programaSST.anioElaboracion);
    $("#PieTablaElementosAnio").html(programaSST.anioElaboracion);

    generaTablaElementosPanelIzquierdo();
    generaTablaElementosPanelDerecho();

    // Meses Encabezado
    var contenidoMesesEncabezado = "";
    contenidoMesesEncabezado += '<div class="gantt_scale_cell"></div>';
    $.each(mesesCatalogo, function (itemMes, objetoMes) {
        contenidoMesesEncabezado += '<div class="gantt_scale_cell" aria-label="' + objetoMes.corto + '">' + objetoMes.corto + '</div>';
    });
    $("#EncabezadoTablaElementosMeses").html(contenidoMesesEncabezado);
    $("#EncabezadoTablaElementosMesesPie").html(contenidoMesesEncabezado);


    // Panel Central
    $("#dvElementosEncabezadoFilaData").html("");
    var contenidoElementos = "";
    $.each(programaSST.Elementos, function (itemElemento, objetoElementoTmp) {
        contenidoElementos += '<div class="MesProgramado gantt_task_bg" data-layer="true">';
        contenidoElementos += '<div class="tablaMesesTask gantt_task_row summary-bar programado gantt_resource_task gantt_resource_' + objetoElementoTmp.idElemento + '" data-elementoId="' + objetoElementoTmp.idElemento + '" elemento_id="' + objetoElementoTmp.idElemento + '">';
        contenidoElementos += '<div class="gantt_task_cell leyendaP">P</div>';
        $.each(mesesCatalogo, function (itemMes, objetoMes) {
            if (objetoElementoTmp.mes[objetoMes.id].total > 0) {
                contenidoElementos += '<div class="gantt_task_cell seleccionarElemento"></div>';
            }
            else {
                contenidoElementos += '<div class="gantt_task_cell"></div>';
            }
        });
        contenidoElementos += '</div>';
        contenidoElementos += '</div>';

        contenidoElementos += '<div class="MesReal gantt_task_bg" data-layer="true">';
        contenidoElementos += '<div class="tablaMesesTask gantt_task_row summary-bar real gantt_resource_task gantt_resource_' + objetoElementoTmp.idElemento + '" data-elementoId="' + objetoElementoTmp.idElemento + '" elemento_id="' + objetoElementoTmp.idElemento + '">';
        contenidoElementos += '<div class="gantt_task_cell leyendaR">R</div>';
        $.each(mesesCatalogo, function (itemMes, objetoMes) {
            //contenidoElementos += '<div class="gantt_task_cell"></div>';
            if (objetoElementoTmp.mes[objetoMes.id].totalReal > 0) {
                contenidoElementos += '<div class="gantt_task_cell seleccionarElementoReal"></div>';
            }
            else {
                contenidoElementos += '<div class="gantt_task_cell"></div>';
            }
        });
        contenidoElementos += '</div>';
        contenidoElementos += '</div>';
    });
    $("#dvElementosEncabezadoFilaData").html(contenidoElementos);
    // Pie de Tabla de Elementos
    $("#dvElementosPieFilaData").html("");
    var contenidoElementosPie = "";

    $.each(pieElementos, function (itemPieElemento, pieElemento) {
        contenidoElementosPie += '<div id="' + pieElemento.name + '" class="gantt_task_bg" data-layer="true">';
        contenidoElementosPie += '<div class="tablaMesesTask gantt_task_row summary-bar gantt_resource_task gantt_resource_' + pieElemento.name + '" data-elementoId="' + pieElemento.name + '" elemento_id="' + pieElemento.name + '">';
        contenidoElementosPie += '<div class="gantt_task_cell"> </div>';
        $.each(mesesCatalogo, function (itemMes, objetoMes)
        {
            try {
                var temp = 0;
                var avanceMensual = programaSST.AvanceMensual[objetoMes.id].retornaObjeto();
                if (pieElemento.name == "avanceProgramado") temp = avanceMensual.avanceProgramado;
                if (pieElemento.name == "avanceReal") temp = avanceMensual.avanceReal;
                if (pieElemento.name == "avanceRealPorc") temp = avanceMensual.avanceRealPorc;
                if (pieElemento.name == "acumuladoPorc") temp = (avanceMensual.acumuladoPorc).toFixed(2);

                //if (pieElemento.name == "avanceProgramado") temp = avanceMensual.avanceProgramado;

                contenidoElementosPie += '<div class="gantt_task_cell infoPie">' + temp + '</div>';
            } catch (ex) {
                contenidoElementosPie += '<div class="gantt_task_cell infoPie">0</div>';
            }
        });
        contenidoElementosPie += '</div>';
        contenidoElementosPie += '</div>';
    });

    $("#dvElementosPieFilaData").html(contenidoElementosPie);
    generaTablaElementosFn();
    generaPonderacionElementos();
    //ToolTip
    //$(".iconosElementos").tooltip();
    //$('.iconosElementos').tooltip({ container: 'body' });
}
function generaTablaElementosPanelIzquierdo() {
    var contenido = "";
    var anchoResponsable = 0;
    var anchoDescrpcionElemento = 0;
    calculaElementoResumen();
    programaSST.sumaPonderacion = 0;

    // Contenido Panel Izquierdo
    $.each(programaSST.Elementos, function (itemElemento, objetoElementoTmp) {
        var objetoElemento = objetoElementoTmp;
        contenido += '<div class="gantt_row summary-bar gantt_resource_task gantt_resource_0 gantt_row_project" style="height: ' + altoFila + 'px; line-height: ' + altoFila + 'px;" data-task-id="' + objetoElementoTmp.idElemento + '" task_id="' + objetoElementoTmp.idElemento + '" aria-label="" aria-selected="true" role="row" aria-level="0" aria-expanded="false">';
        $(columnsElementos).each(function (item, valor) {
            if (valor.name == "responsableRPE" && banderasElementos.rpe != true) {
                anchoResponsable = valor.width;
            }
        });
        $(columnsElementos).each(function (item, valor) {
            anchoDescrpcionElemento = valor.width;
            if (valor.name == "elemento" && banderasElementos.rpe != true) {
                anchoDescrpcionElemento += anchoPanelElementosDerecho;
            }
            if (valor.name == "elemento") {

                if (objetoElemento.elemento != "") {
                    contenido += '<div class="gantt_cell borde_derecho gantt_cell_tree" data-column-index="' + item + '" data-column-name="text" style="width:' + anchoDescrpcionElemento + 'px;" role="gridcell" aria-label="' + objetoElemento.elemento + '" aria-readonly="true"> <div elementoId="' + objetoElemento.idElemento + '" class="gantt_tree_icon gantt_open"></div><div class="gantt_tree_icon gantt_folder_closed"></div><div class="gantt_content">' + objetoElemento.elemento + '</div></div>';
                }
                else {
                    $.each(ElementosObj, function (itemElemento, objetoElementoTmp) {
                        if (objetoElementoTmp.clave == objetoElemento.idElemento) {
                            contenido += '<div class="gantt_cell borde_derecho gantt_cell_tree" data-column-index="' + item + '" data-column-name="text" style="width:' + anchoDescrpcionElemento + 'px;" role="gridcell" aria-label="' + objetoElementoTmp.descripcion + '" aria-readonly="true"> <div elementoId="' + objetoElemento.idElemento + '" class="gantt_tree_icon gantt_open"></div><div class="gantt_tree_icon gantt_folder_closed"></div><div class="gantt_content">' + objetoElementoTmp.descripcion + '</div></div>';
                        }

                    });

                }
            } else if (valor.name == "recursos") {
                contenido += '<div class="gantt_cell borde_derecho" data-column-index="' + item + '" data-column-name="resources" style="width:' + anchoDescrpcionElemento + 'px;" role="gridcell" aria-label="" aria-readonly="true"> <div class="gantt_content">' + regresaRecursosElemento(objetoElemento.idElemento) + '</div></div>';
            } else if (valor.name == "ponderacion") {
                var classPonderacionEditar = "";
                if (banderasElementos.editaPonderacion == true) {
                    classPonderacionEditar = " list_ponderacion";
                }
                contenido += '<div class="gantt_cell borde_derecho texto_centrado' + classPonderacionEditar+'" data-column-index="' + item + '" data-column-name="ponderacion" style="width:' + anchoDescrpcionElemento + 'px;" role="gridcell" aria-label="" aria-readonly="true"> <div class="gantt_content">' + objetoElemento.ponderacion + '</div></div>';
            } else if (valor.name == "buttons") {
                var iconos = '';
                if (banderasElementos.editar == true) {
                    /*
                     iconos = '<i class="fa fa-pen iconosElementos editaElemento" elementoId="' + objetoElemento.idElemento + '" data-placement="top" title="Edita Elemento"></i>';*/
                }
                if (banderasElementos.recursos == true) {
                    iconos += '<i class="fa fa-user-cog iconosElementos recursosElemento" elementoId="' + objetoElemento.idElemento + '" data-placement="top" title="Asignar Recursos a este elemento"></i>';
                }
                if (banderasElementos.elimina == true) {
                    iconos += '<i class="fa fa-trash iconosElementos eliminaElemento" elementoId="' + objetoElemento.idElemento + '" data-placement="top" title="Eliminar este elemento"></i>';
                }

                contenido += '<div class="gantt_cell gantt_last_cell" data-column-index="' + item + '" data-column-name="buttons" style="width:' + anchoDescrpcionElemento + 'px;" role="gridcell" aria-label=" " aria-readonly="true"> <div class="gantt_content">' + iconos + '</div></div>';
            }
        });
        contenido += '</div>';
        //Sumando ponderacion 
        programaSST.sumaPonderacion += objetoElementoTmp.ponderacion;
    });
    $("#dvElementosEncabezadoFila").html(contenido);
}
function generaTablaElementosPanelDerecho() {
    var contenido = "";
    var anchoResponsable = 0;
    var anchoDescrpcionElemento = 0;
    calculaElementoResumen();
    programaSST.sumaPonderacion = 0;

    // Contenido Panel Derecho
    $("#PanelElementosDerechoFilas").html("");
    $.each(programaSST.Elementos, function (itemElemento, objetoElementoTmp) {
        var objetoElemento = objetoElementoTmp;
        contenido += '<div class="gantt_row summary-bar gantt_resource_task gantt_resource_0 gantt_row_project" style="height: ' + altoFila + 'px; line-height: ' + altoFila + 'px;" data-task-id="' + objetoElementoTmp.idElemento + '" task_id="' + objetoElementoTmp.idElemento + '" aria-label="" aria-selected="true" role="row" aria-level="0" aria-expanded="false">';
        $(columnsElementosDerecho).each(function (item, valor) {
            anchoDescrpcionElemento = valor.width;
            
            if (valor.name == "responsableRPE") {
                contenido += '<div class="gantt_cell borde_derecho" data-column-index="' + item + '" data-column-name="resources" style="width:' + anchoDescrpcionElemento + 'px;" role="gridcell" aria-label="" aria-readonly="true"> <div class="gantt_content">' + objetoElementoTmp.responsableRPENombre + '</div></div>';
            }
        });
        contenido += '</div>';
        //Sumando ponderacion 
        programaSST.sumaPonderacion += objetoElementoTmp.ponderacion;
    });
    $("#PanelElementosDerechoFilas").html(contenido);
}
function generaTablaElementosFn() {
    $(".eliminaElemento").unbind("click");
    $(".eliminaElemento").bind("click", function () {
        var elementoId = $(this).attr("elementoId");
        if (programaSST.Elementos[elementoId] != null) {

            var thisObjeto = this;
            swal({
                title: "Eliminar Elemento",
                text: "Se eliminará el elemento con todas sus actividades.\n ¿Está seguro que quiere eliminar el registro? \n ",
                icon: "warning",
                buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, eliminarlo!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

            }).then(function (e) {
                if (e) {
                    //$.LoadingOverlay("show");//
                    $(thisObjeto).prop("checked", false);
                    //eliminaElemento
                    if (programaSST.Elementos[elementoId].eliminaElemento()) {
                        delete programaSST.Elementos[elementoId];
                    }
                    generaTablaElementos();
                }
                else {
                    swal.close();
                }
            });

           // $.LoadingOverlay("hide");//$.unblockUI();
        }
    });
    $("#dvElementos .gantt_open").unbind("click");
    $("#dvElementos .gantt_open").bind("click", function () {
        elementoSeleccionado = $(this).attr("elementoId");
        $("#dvActividades").show();
        $("#dvElementos").hide();
        generaColumnasActividades();
        generaTablaActividades();
        inicializaActividades();
        try { inicializaGil(); } catch (ex) { console.warn("No se encuentra Gil:: inicializaGil()"); }
    });
    inicializaRecurso();
    
}
/* Seleccionar Recursos */
function regresaRecursosElemento(ElementoIdTmp) {
    
    if (Object.keys(programaSST.Elementos[ElementoIdTmp].recursos).length > 0) {
        var recursosArr = new Array();
        $.each(programaSST.Elementos[ElementoIdTmp].recursos, function (itemRecurso, recursoTmp) {
            $.each(RecursosObj, function (itemRecursoTmp, recurso) {
                if (recurso.id == recursoTmp.idRecurso) {
                    recursosArr.push(recurso.descripcion);
                }   
            });
        });
        return recursosArr.join()
    }
    else {
        return "";
    }
}
function agregaNuevaRecursoListadoFormulario(item, id, descripcion, checked) {
    var checkedRecurso = "";
    if (checked == true) {
        checkedRecurso = " checked='checked' ";
    }
    $("#RecursosList").append("<div><label class='c-checkbox'> <input id='Recurso_" + id + "' type='checkbox' name='recursos[]' class='recursos' indice='" + item + "' value='" + id + "' " + checkedRecurso + "> <span class='fa fa-check'></span>" + descripcion + " </label></div>");
}
function inicializaRecurso() {
    //Muestra Listado Formulario de recursos
    //muestraListaRecursosFormulario();

    //Muestra Modal de Recursos
    $("#dvElementos .recursosElemento").unbind("click");
    $("#dvElementos .recursosElemento").bind("click", function () {

        

        setTimeout(function () {
            $(".modal-backdrop").remove();
        }, 500);

        elementoSeleccionado = $(this).attr("elementoId");
        //alert(elementoSeleccionado);
        $('#ModalRecurso').modal('show');
        muestraListaRecursosFormulario();

        // Verificar si estan checados las recursos
        $(".recursos").prop("checked", false);
        $.each(programaSST.Elementos[elementoSeleccionado].recursos, function (itemRecurso, recurso) {
            $("#Recurso_" + recurso.idRecurso).prop("checked", true);
        });

    });
    //Guardar o Aceptar Recursos
    $("#aceptarRecursos").unbind("click");
    $("#aceptarRecursos").bind("click", function () {
        var totalRecursos = $(".recursos").length;
        delete programaSST.Elementos[elementoSeleccionado].recursos;
        programaSST.Elementos[elementoSeleccionado].recursos = new Object();
        var id = programaSST.Elementos[elementoSeleccionado].id;
        if (totalRecursos > 0) {
            $(".recursos").each(function (index) {
                var seleccionado = $(this).prop("checked");
                var IdRecursoTmp = $(this).val();
                if (seleccionado)
                {
                    if (!programaSST.Elementos[elementoSeleccionado].recursos[IdRecursoTmp])
                    {
                        programaSST.Elementos[elementoSeleccionado].recursos[IdRecursoTmp] = new Object({ idElemento: id, idRecurso: IdRecursoTmp });
                    }
                }
            });
            guardaRecursos();
        }
        generaTablaElementos();
    });
}
function guardaRecursos() {
    //Mandar eliminar los recursos de un elemento
    
    $.post(urlEliminaElementoRecursos, new Object({ id: programaSST.Elementos[elementoSeleccionado].id }), function (data) {
        var recursosObj = programaSST.Elementos[elementoSeleccionado].recursos;
        //Guardando los recursos
        $.each(recursosObj, function (itemRecurso, recursoTmp) {
            $.post(urlElementoRecursos, recursoTmp, function (data) {

                //if (data.id > 0) {
                //    toastr.options.positionClass = 'toast-bottom-right';
                //    toastr['success']('Elemento Guardado');
                //    //this.id = data.id;
                //    //elementoGuardar.actualizaId( data.id );
                //    programaSST.Elementos[elementoIndex].id = data.id;
                //}

            }, "json");
        });
    }, "json");
}
function muestraListaRecursosFormulario() {

    $("#RecursosList").html("");
    $(RecursosObj).each(function (item, recursoItem) {
        var checkedRecurso = false;
        if (programaSST.Elementos[elementoSeleccionado].recursos[recursoItem.id] != null) {
            checkedRecurso = true;
        }
        agregaNuevaRecursoListadoFormulario(item, recursoItem.id, recursoItem.descripcion, checkedRecurso);
    });
    //muestraListaRecursosFormularioFn();
}


/* Seleccionar Elementos  */

function nuevaElementoFormulario() {
    /*
    if (textoNuevaElemento == "") {

        //alert("Escribir el nombre de la nueva elemento");
        
        return false;
    }
    */
    
    $('#ElementosFormCatalogo').validate();
    $('#ElementosFormCatalogo').removeAttr('novalidate');
    if (!$("#NuevaElemento").valid()) {
        return false;
    }

    var textoNuevaElemento = $("#NuevaElemento").val();
    $("#NuevaElemento").val("");

    var currentDate = new Date();
    var timestamp = currentDate.getTime();
    nuevaElemento(textoNuevaElemento, timestamp);
}
function nuevaElemento(textoNuevaElemento, timestamp) {
    //ElementosObj[timestamp] = new Object({ "clave": ""+timestamp, "descripcion": textoNuevaElemento, "Nueva": true })
    ElementosObj.push({ "clave": + timestamp, "descripcion": textoNuevaElemento, "Nueva": true });

    var elementoNuevaItem = ElementosObj.length - 1;
    agregaNuevaElementoListadoFormulario(elementoNuevaItem, timestamp, textoNuevaElemento, true);
    muestraListaElementosFormularioFn();
}

function agregaNuevaElementoListadoFormulario(item, clave, descripcion, checked) {
    var checkedElemento = "";
    if (checked == true) {
        checkedElemento = " checked='checked' ";
    }
    $("#ElementosList").append("<div><label class='c-checkbox'> <input id='Elemento_" + clave+"' type='checkbox' name='elementos[]' class='elementos' indice='" + item + "' value='" + clave + "' " + checkedElemento + "> <span class='fa fa-check'></span>" + descripcion + " </label></div>");
}
function muestraListaElementosFormulario() {
    $("#ElementosList").html("");
    $(ElementosObj).each(function (item, tareaGeneral) {
        var checkedElemento = false;
        if (programaSST.Elementos[tareaGeneral.idElemento] != null) {
            checkedElemento = true;
        }
        agregaNuevaElementoListadoFormulario(item, tareaGeneral.clave, tareaGeneral.descripcion, checkedElemento);
    });
    muestraListaElementosFormularioFn();
}
function muestraListaElementosFormularioFn() {
    $(".elementos").unbind("click");
    $(".elementos").bind("click", function () {
        var elementoId = $(this).val();
        var seleccionado = $(this).prop("checked");
        //alert(elementoId);
        //alert(seleccionado);

        if (!seleccionado) {
            if ( programaSST.Elementos[elementoId] ) {
                if (!confirm("Se eliminara el elemento con todas sus actividades.\n ¿Está seguro que quiere eliminar el registro?")) {
                    $("#Elemento_" + elementoId).prop("checked", true);
                }
            }

        }

    });
}
function inicializaElementos() {
    var alto_ventana = screen.height - 600;
    if (top.window.innerHeight > 600) {
        top.window.innerHeight - 250;
    }
    //var alto_ventana = top.window.innerHeight - 250;
    
    $("#ElementosList").css("height", alto_ventana+"px");
    //Agregar nueva elemento
    $("#agregaElemento").unbind("click");
    $("#agregaElemento").bind("click", function () {
        nuevaElementoFormulario();
    });
    //Muestra Listado Formulario de elementos
    muestraListaElementosFormulario();
    //Muestra Modal de Elementos
    $("#btnElementoAgrega").unbind("click");
    $("#btnElementoAgrega").bind("click", function () {
        $("#ModalElementos").modal("show");
        $("#ModalElementos").css("margin-top", 100);
        $("#NuevaElemento").height( 72 );
        setTimeout(function () {
            $(".modal-backdrop").remove();
        }, 500);

        // Verificar si estan checados las elementos
        $.each(programaSST.Elementos, function (itemElemento, objetoElementoTmp) {
            var idElementoTmp = objetoElementoTmp.idElemento;
            $("#Elemento_" + idElementoTmp).prop("checked", true);
        });

    });
    //Guardar o Aceptar Elementos
    $("#aceptarElementos").bind("click", function () {
        var totalElementos = $(".elementos").length;
        if (totalElementos > 0) {
            $(".elementos").each(function (index) {
                var seleccionado = $(this).prop("checked");
                var indiceElemento = $(this).attr("indice");
                var elementoGeneral = ElementosObj[indiceElemento];
                var idElementoTmp = $(this).val();

                if (seleccionado) {
                    if (!programaSST.Elementos[elementoGeneral.clave]) {
                        var esCatalogo = true;
                        try { esCatalogo = elementoGeneral.Nueva; }catch ( ex ) {}

                        var objeto = new Object({
                            id: 0,
                            esCatalogo: esCatalogo,
                            idPrograma: programaId,
                            idElemento: elementoGeneral.clave,
                            elemento: elementoGeneral.descripcion,
                            ponderacion: 0,
                            /* responsables */
                            idResponsable: programaSST.idResponsable,
                            responsableRPE: programaSST.responsableRPE,
                            responsableNombre: programaSST.responsableNombre,
                            responsableRPENombre: programaSST.responsableRPE + " - " + programaSST.responsableNombre,

                            elaboraNombre: "",
                            //mes,
                            recursos: new Object(),
                            Actividades: new Object()
                        });
                        //guardaElemento(objeto);
                        programaSST.Elementos[objeto.idElemento] = new Elemento();
                        programaSST.Elementos[objeto.idElemento].agregarElementoNuevo(objeto, objeto.idElemento);
                        
                    }
                }
                else {
                    if (!programaSST.Elementos[idElementoTmp]) {

                    }
                    else {
                        delete programaSST.Elementos[idElementoTmp];
                    }
                }
            });
        }
        generaTablaElementos();
    });
}
function calculaElementoResumen() {
/* Revisa todas las actividades */
    
    $.each(programaSST.Elementos, function (itemElemento, objetoElementoTmp) {

        $.each(mesesCatalogo, function (itemMes, objetoMes) {
            programaSST.Elementos[itemElemento].mes[objetoMes.id].total = 0;
            programaSST.Elementos[itemElemento].mes[objetoMes.id].totalReal = 0;
        });
        $.each(objetoElementoTmp.Actividades, function (itemActividad, objetoActividadTmp) {
            if (typeof objetoActividadTmp === 'undefined' || objetoActividadTmp === null) {

            } else {
                $.each(objetoActividadTmp.mesSemana, function (itemMesSemana, ActividadMesSemanaTmp) {
                    var mes = programaSST.Elementos[itemElemento].Actividades[itemActividad].mesSemana[itemMesSemana].mes;
                    programaSST.Elementos[itemElemento].mes[mes].total += ActividadMesSemanaTmp.valor;
                    programaSST.Elementos[itemElemento].mes[mes].totalReal += ActividadMesSemanaTmp.valorReal;

                });
            }

        });
    });

}

/* Ponderacion */
function generaPonderacionElementos() {
    var contenidoPonderacion = "";
    if (banderasElementos.editaPonderacion == true) {
        contenidoPonderacion += "<div id='SumaPonderacionElementosCk'>";
    }
    else {
        contenidoPonderacion += "<div>";
    }
    contenidoPonderacion += "<strong>Suma de Ponderaci\u00f3n de Elementos es: " + programaSST.sumaPonderacion + "</strong>";
    if (banderasElementos.editaPonderacion == true) {
        contenidoPonderacion += '<i id="editaPonderacionElemento" class="fa fa-tasks iconosElementos" data-placement="top" title="Edita Ponderaci\u00f3n de Elementos"></i>';
    }
    contenidoPonderacion += "</div>";
    $("#SumaPonderacion").html(contenidoPonderacion);
    generaPonderacionElementoFn();
}
function generaPonderacionElementoFn() {
    $(".list_ponderacion").unbind("click");
    $(".list_ponderacion").bind("click", function () {
        $("#SumaPonderacionElementosCk").click();
    });

    $("#SumaPonderacionElementosCk").unbind("click");
    $("#SumaPonderacionElementosCk").bind("click", function () {
        $("#ModalElementoPonderacion").modal("show");
        generaPonderacionTablaContenido();
        setTimeout(function () {
            $(".modal-backdrop").remove();
        }, 500);
    });
    $("#aceptarElementoPonderacion").unbind("click");
    $("#aceptarElementoPonderacion").bind("click", function (event) {

        $('#ElementoPonderacionForm').validate();
        $('#ElementoPonderacionForm').removeAttr('novalidate');
    /* Revisando si hay un elemento invalido */

        if (!$(".inputPonderacion").valid()) {
            event.preventDefault();
            return false;
        }

        var valor = 0;
        $.each($(".inputPonderacion"), function (itemInputPonderacion, inputPonderacion) {
            valor += numeral($(this).val()).value();
        });
        if (valor > 100) {
            swal("Ponderaci\u00f3n Elementos", "La suma de la ponderaci\u00f3n en los elementos sobrepasa 100", "info");
            return false;
        }

        $.each($(".inputPonderacion"), function (itemInputPonderacion, inputPonderacion) {
            var itemElemento = $(this).attr("itemElemento");
            var valorNuevoPonderacion = numeral($(this).val()).value()
            if (programaSST.Elementos[itemElemento].ponderacion != valorNuevoPonderacion) {
                programaSST.Elementos[itemElemento].ponderacion = valorNuevoPonderacion;
                programaSST.Elementos[itemElemento].actualizarElemento();
            }
            //return false;
        });
        //actualizar tabla
        generaTablaElementos();
    });
}
function generaPonderacionTablaContenido() {
    var contenido = "";
    contenido += '<table class="table table-striped table-bordered">';
    contenido += '<thead><tr class="table-info">';
    contenido += '<th>Elemento</th>';
    contenido += '<th>' + toUnicode("Ponderación")+'</th>';
    contenido += '</tr></thead>';
    contenido += '<tbody>';
    $.each(programaSST.Elementos, function (itemElemento, objetoElementoTmp) {
        var objetoElemento = objetoElementoTmp;
        //console.log(objetoElemento);
        contenido += '<tr class="form-group">';
        contenido += '<td><label class="col-form-label" for="inputponderacion' + itemElemento + '">' + toUnicode(objetoElemento.elemento) +'</label></td>';
        contenido += '<td><div> <input name="inputponderacion' + itemElemento + '" id="inputponderacion' + itemElemento + '" itemElemento="' + itemElemento + '" type="number" class="form-control inputPonderacion required number" value="' + objetoElemento.ponderacion + '" data-msg-required="' + toUnicode("Es necesaría la ponderación") + '" data-val="true" data-msg-number="' + toUnicode("La ponderación debe de ser número") + '" data-msg-min="' + toUnicode("La ponderación debe estar entre 0 a 100") + '" data-msg-max="' + toUnicode("La ponderación debe estar entre 0 a 100") +'" max="100" min="0"/><span class="field-validation-valid text-danger" data-valmsg-for="inputponderacion' + itemElemento + '" data-valmsg-replace="true"></span></div></td>';
        contenido += '</tr>';

    });
    //' + tildes_unicode("")+'
    contenido += '</tbody>';
    contenido += '</tfooter>';
    contenido += '<tr class="table-primary">';
        contenido += '<td>Total:</td>';
    contenido += '<td id="sumaPonderacionTd">' + programaSST.sumaPonderacion+'</td>';
    contenido += '</tr>';
    contenido += '</tfooter>';
    contenido += '</table>';
    $("#ElementoPonderacionForm").html(contenido);
    $(".inputPonderacion").unbind("change");
    $(".inputPonderacion").bind("change", function () {
        //console.log("Valor :: " + $(this).val());
        var valor = 0;
        $.each($(".inputPonderacion"), function (itemInputPonderacion, inputPonderacion) {

            valor += numeral($(this).val()).value();

        });
        //console.log("Suma:: " + valor);

        $("#sumaPonderacionTd").html(valor);
        $("#sumaPonderacionTd").removeClass("sobrePasoPonderacion");
        if (valor > 100) {
            $("#sumaPonderacionTd").addClass("sobrePasoPonderacion");
        }
    });
}