class Actividad {
    esCatalogo = true;
    actividadDescripcion = "";
    id = 0;
    idActividad = 0;
    idElemento = 0;
    idPrograma = 0;
    idResponsable = 0;
    mesSemana = new Object();
    responsableNombre = "";
    responsableRPE = "";
    responsableRPENombre = "";
    ponderacion = 0;
    evaluacion = 0;//Catalogo de catalogos en Evaluación
    esGilSupervision = false;
    esGilHerramienta = false;

    constructor() {
        //this.nombre = n;
    }
    agregarActividad(objetoActividad) {

        this.esCatalogo = objetoActividad.esCatalogo != null ? objetoActividad.esCatalogo : true;

        if (objetoActividad.actividadDescripcion != null) this.actividadDescripcion = objetoActividad.actividadDescripcion;
        if (objetoActividad.id != null) this.id = objetoActividad.id;
        if (objetoActividad.idActividad != null) this.idActividad = objetoActividad.idActividad;
        if (objetoActividad.idElemento != null) this.idElemento = objetoActividad.idElemento;
        if (objetoActividad.idPrograma != null) this.idPrograma = objetoActividad.idPrograma;
        if (objetoActividad.idResponsable != null) this.idResponsable = objetoActividad.idResponsable;
        if (objetoActividad.mesSemana != null) this.mesSemana = objetoActividad.mesSemana;
        if (objetoActividad.responsableNombre != null) this.responsableNombre = objetoActividad.responsableNombre;
        if (objetoActividad.responsableRPE != null) this.responsableRPE = objetoActividad.responsableRPE;
        if (objetoActividad.responsableRPENombre != null) this.responsableRPENombre = objetoActividad.responsableRPENombre;
        if (objetoActividad.ponderacion != null) this.ponderacion = objetoActividad.ponderacion;
        if (objetoActividad.evaluacion != null) this.evaluacion = objetoActividad.evaluacion;
        if (objetoActividad.esGilSupervision != null) this.esGilSupervision = objetoActividad.esGilSupervision;
        if (objetoActividad.esGilHerramienta != null) this.esGilHerramienta = objetoActividad.esGilHerramienta;

        //Calculos de Mes Semana
        this.calculaMesSemana();

    }
    calculaMesSemana() {
        var mesSemanaGuardado = this.mesSemana;
        var IdActividad = this.id;
        //console.log(this.actividadDescripcion);
        //console.log(mesSemanaGuardado);

        var mesSemana = new Object();
        $.each(mesesCatalogo, function (itemMes, objetoMes) {
            $(semanaActividades).each(function (itemSemana, semanaVal) {
                var mes = objetoMes.id;
                var semana = semanaVal.id;
                var indiceCalculado = regresaIndiceCalculado(mes, semana);
                //objeto.mesSemana[indiceCalculado] = new Object();
                mesSemana[indiceCalculado] = new Object({
                    id: 0,
                    idActividad: IdActividad,
                    idElemento: regresaElementoId(),
                    mes: objetoMes.id,
                    semana: semanaVal.id,
                    valor: 0,
                    valorReal: 0
                });
            });
        });
        //Pendiente obtener los guardados
        //console.error("mesSemanaGuardado :: ", mesSemanaGuardado );

        
        $.each(mesSemanaGuardado, function (itemMes, objetoMesSemana) {
            var mes = objetoMesSemana.mes;
            var semana = objetoMesSemana.semana;
            var indiceCalculado = regresaIndiceCalculado(mes, semana);
            //console.warn("indiceCalculado :: ", indiceCalculado);
             mesSemana[indiceCalculado].id = objetoMesSemana.id;
             mesSemana[indiceCalculado].mes = objetoMesSemana.mes;
             mesSemana[indiceCalculado].semana = objetoMesSemana.semana;
             mesSemana[indiceCalculado].valor = objetoMesSemana.valor;
             mesSemana[indiceCalculado].valorReal = objetoMesSemana.valorReal;
             //mesSemana[indiceCalculado].idActividad = objetoMesSemana.idActividad;
             //mesSemana[indiceCalculado].idElemento = regresaElementoId();
        });
        //console.log("mesSemana :: ", mesSemana);
        
        this.mesSemana = mesSemana;
    }
    agregarActividadNueva(objetoActividad, indexActividad) {
        this.agregarActividad(objetoActividad);
        this.guardaActividad(indexActividad);
    }
    guardaActividad(indexActividad) {
        $.post(urlActividadPrograma, this.retornaObjeto(), function (data) {
            if (data.id > 0) {
                toastr.options.positionClass = 'toast-bottom-right';
                toastr['success']('Actividad Guardada');
                programaSST.Elementos[elementoSeleccionado].Actividades[indexActividad].id = data.id;
                //this.id = data.id;
                //actividadGuardar.actualizaId(data.id);
            }
        }, "json");
    }
    guardaMesSemana(indice, indexActividad) {
        //var mesSemanaObjeto = this.mesSemana[indice];
        try {
            
            
            if (this.mesSemana[indice].idActividad <= 0) {
                this.mesSemana[indice].idActividad = this.id;
            }

            //var objetoActual = this;
            $.post(urlMesSemanaPrograma, this.mesSemana[indice], function (data) {
                console.log(" MesSemanaGuardar :: ", data);
                if (data.id > 0) {
                    toastr.options.positionClass = 'toast-bottom-right';
                    toastr['success']('Guardado Mes Semana');
                    //this.id = data.id;
                    //generaTablaActividades();
                    //objetoActual.actualizaMesSemanaTabla(data, indice);
                    programaSST.Elementos[elementoSeleccionado].Actividades[indexActividad].actualizaMesSemanaTabla(data, indice);
                }
            }, "json");
        }
        catch (ex)
        {
            toastr.options.positionClass = 'toast-bottom-right';
            toastr['error']('Error al guardar Mes Semana');
        }
    }
    actualizaMesSemanaTabla(objetoNuevo, indice) {
        this.mesSemana[indice].id = objetoNuevo.id;
        var mes = this.mesSemana[indice].mes;

        try { actualizaAvanceMensual(mes); }
        catch (ex) { console.warn("No se encuentra la funcion :: actualizaAvanceMensual desde :: actualizaMesSemanaTabla") }

        generaTablaActividades();
    }
    actualizarActividad() {
        var actividadActual = this;
        noPeticionesActualiza++;
        $.post(urlActividadPrograma, this.retornaObjetoActualizar(), function (data) {
            if (actividadActual.id == 0 && data.id > 0)
            {
                actividadActual.id = data.id;
            }
        }, "json")
        .fail(function () {
            
            
        })
        .always(function () {
            noPeticionesActualiza--;
            if (noPeticionesActualiza <= 0) {
                toastr.options.positionClass = 'toast-bottom-right';
                toastr['success']('Actividad Guardada');
                noPeticionesActualiza = 0;
                inicializaGil();
            }
        });
    }
    retornaObjeto() {
        var idActividad = this.esCatalogo == true ? this.idActividad : 0;
        var idElemento = programaSST.Elementos[elementoSeleccionado].id;
        var objeto = new Object({
            id: this.id,
            actividadDescripcion: this.actividadDescripcion,
            idActividad: idActividad,
            //idElemento: this.idElemento,
            idElemento: programaSST.Elementos[this.idElemento].id,
            idPrograma: this.idPrograma,
            idResponsable: this.idResponsable,
            mesSemana: this.mesSemana,
            responsableNombre: this.responsableNombre,
            responsableRPE: this.responsableRPE,
            responsableRPENombre: this.responsableRPENombre,
            ponderacion: this.ponderacion,
            evaluacion: this.evaluacion,
            esGilSupervision: this.esGilSupervision,
            esGilHerramienta: this.esGilHerramienta
        });
        return objeto;
    }
    retornaObjetoActualizar() {
        var idActividad = this.esCatalogo == true ? this.idActividad : 0;
        var idElemento = programaSST.Elementos[elementoSeleccionado].id;
        var objeto = new Object({
            id: this.id,
            actividadDescripcion: this.actividadDescripcion,
            idActividad: idActividad,
            idElemento: idElemento,
            //idElemento: programaSST.Elementos[this.idElemento].id,
            idPrograma: this.idPrograma,
            idResponsable: this.idResponsable,
            responsableNombre: this.responsableNombre,
            responsableRPE: this.responsableRPE,
            responsableRPENombre: this.responsableRPENombre,
            ponderacion: this.ponderacion,
            evaluacion: this.evaluacion,
            esGilSupervision: this.esGilSupervision,
            esGilHerramienta: this.esGilHerramienta
        });
        return objeto;
    }
    eliminaActividad() {
        if (this.id > 0) {
            $.post(urlEliminaActividadPrograma, new Object({
                id: this.id,
                idPrograma: this.idPrograma,
                idElemento: this.idElemento,
                idActividad: this.idActividad
            }), function (data) {
                toastr.options.positionClass = 'toast-bottom-right';
                toastr['success']('Actividad Eliminado');
            }, "json");
            return true;
        }
        else {
            return true;
        }
    }
    actualizaGilSupervision(esGilSupervision) {
        if (esGilSupervision != null) this.esGilSupervision = esGilSupervision; else this.esGilSupervision = false;
    }
    actualizaGilHerramienta(esGilHerramienta) {
        if (esGilHerramienta != null) this.esGilHerramienta = esGilHerramienta; else  this.esGilHerramienta = false;
    }
}

//definition default
if (typeof banderasActividad === 'undefined') {
    banderasActividad = { editar: true, ponderacion: true, rpe: false, elimina: true, editarPeriodicidad: true, mesInactivo: true, editaPonderacion: true, subirEvidencia: true};
}

var responsableActividadHtml = "";
var semanaActividades = [
    { id: 1, valor: 0, real: 0 },
    { id: 2, valor: 0, real: 0 },
    { id: 3, valor: 0, real: 0 },
    { id: 4, valor: 0, real: 0 }
];
var semanaActividadActividad = { id: null, descripcion: "", archivoId:null };

var columnsActividades = [
    { name: "actividad", label: "Actividad", width: banderasActividad.rpe == true ? 325 : 445 },
    { name: "responsableRPE", label: "Responsable", width: 120 },
    { name: "ponderacion", label: "Ponderacion", width: 50 },
    { name: "buttons", label: "", width: 55 }
];

var pieActividades = [
    { name: "numeroActividadesProgramadas", label: "Número de actividades programadas" },
    { name: "avanceRealActividades", label: "Avance real de actividades" },
    { name: "porcentajeAvance", label: "Porcentaje de avance" }
];

var catalogoEvaluacion = new Object();

if (typeof EvaluacionObj === 'undefined' || EvaluacionObj.length <= 0) {
    var catalogoEvaluacion = [
        { id: 4002, descripcion: "Cumple / No Cumple" },
        { id: 4001, descripcion: "Programado / Realizado" }
    ];
}
else {
    catalogoEvaluacion = EvaluacionObj;
}


var mesSemanaGuardar = new Object({
    id: 0,
    idActividad: 0,
    idElemento:0,
    mes: 0,
    semana: 0,
    valor: 0,
    valorReal: 0
});

var objetoMesSemanaEnviado = new Object();
var actividadEvidencia = 0;
var nuevaActividadSinCatalogo = 0;//

/* Funciones */
function generaColumnasActividades() {
    $(columnsActividades).each(function (item, valor) {
        if (valor.name == "responsableRPE" && banderasActividad.rpe == false) {

        }
        else {
            $("#dvActividadesEncabezado").append('<div class="gantt_grid_head_cell gantt_grid_head_owner" style="width:' + valor.width + 'px;" role="columnheader" aria-label="' + valor.label + '" data-column-id="' + valor.name + '" column_id="' + valor.name + '" data-column-name="' + valor.name + '" data-column-index="0">' + valor.label + '</div>');
        }
    });
}
function generaTablaActividades() {

    //Establece el anio de la tabla
    $("#EncabezadoTablaActividadesAnio").html(programaSST.anioElaboracion);
    $("#PieTablaActividadesAnio").html(programaSST.anioElaboracion);

    var contenido = "";
    var altoFila = 50;
    contenido += '<div class="gantt_row summary-bar gantt_row_project project_selected" style="height: 25px; line-height: 25px;" data-task-id="1" task_id="1" aria-label="" aria-selected="true" role="row" aria-level="0" aria-expanded="false">';

    var IndiceActividadSeleccionado = 0;

    $.each(ElementosObj, function (itemElemento, objetoElementoTmp) {
        if (objetoElementoTmp.clave == elementoSeleccionado) {
            contenido += '<div class="gantt_cell gantt_cell_tree" data-column-index="-1" data-column-name="text" role="gridcell" aria-label="' + objetoElementoTmp.descripcion + '" aria-readonly="true"> <div class="gantt_tree_icon gantt_close"></div><div class="gantt_tree_icon gantt_folder_open"></div><div class="gantt_tree_content">' + objetoElementoTmp.descripcion + '</div></div>';

        }

    });
    contenido += '</div>';

    $.each(programaSST.Elementos[elementoSeleccionado].Actividades, function (itemActividad, objetoActividadTmp) {
        var objetoActividad = objetoActividadTmp;
        
        if (objetoActividadTmp) {
            //console.log("objetoActividadTmp :: ", objetoActividadTmp);
            contenido += '<div class="gantt_row gantt_row_task" style="height: ' + altoFila + 'px; line-height: ' + altoFila + 'px;" data-task-id="1" task_id="1" aria-label="" aria-selected="true" role="row" aria-level="0" aria-expanded="false">';
            contenido += '<div class="gantt_cell gantt_cell_tree" data-column-index="-1" data-column-name="espaciado" style="width:25px;" role="gridcell" aria-label="" aria-readonly="true"></div > ';
            $(columnsActividades).each(function (item, valor) {
                if (valor.name == "responsableRPE") {
                    if (banderasActividad.rpe == true) {
                        var responsable = objetoActividad.responsableRPENombre;
                        if (responsableActividadHtml != "") {
                            responsable = responsableActividadHtml;
                        }
                        contenido += '<div class="gantt_cell borde_derecho" data-column-index="' + item + '" data-column-name="owner" style="width:' + valor.width + 'px;" role="gridcell" aria-label="" aria-readonly="true"> <div class="gantt_tree_content dvResponsableActividad">' + responsable + '</div ></div > ';
                    }
                    else {
                        /*
                      contenido += '<div class="gantt_cell borde_derecho" data-column-index="' + item + '" data-column-name="owner" style="width:' + valor.width + 'px;" role="gridcell" aria-label="" aria-readonly="true"> <div class="gantt_tree_content"></div ></div > ';
                      */
                    }
                } else if (valor.name == "actividad") {
                    contenido += '<div class="gantt_cell borde_derecho" data-column-index="' + item + '" data-column-name="text" style="width:' + valor.width + 'px;" role="gridcell" aria-label="' + objetoActividad.actividadDescripcion + '" aria-readonly="true"> <div class="gantt_tree_content">' + objetoActividad.actividadDescripcion + '</div></div>';
                } else if (valor.name == "ponderacion")
                {

                    var classPonderacionEditar = "";
                    if (banderasElementos.editaPonderacion == true) {
                        classPonderacionEditar = " list_ponderacion_actividad";
                    }
                    var ponderacion = 0;
                    try {
                        ponderacion = numeral(objetoActividad.ponderacion).value();
                    } catch (ex) { ponderacion = 0; }
                    if (ponderacion == null) {
                        ponderacion = 0;
                    }
                    contenido += '<div id="EncabezadoTablaPoderacion" class="gantt_cell borde_derecho texto_centrado' + classPonderacionEditar+'" data-column-index="' + item + '" data-column-name="text" style="width:' + valor.width + 'px;" role="gridcell" aria-readonly="true"> <div class="gantt_tree_content">' +ponderacion+'</div></div>';
                } else if (valor.name == "buttons") {
                    var iconos = '';
                    /*
                    iconos = '<i class="fa fa-pen iconosActividades editaActividad" elementoId="' + objetoActividad.idActividad + '" data-placement="top" title="Edita Actividad"></i>';
                    
                    iconos += '<i class="fa fa-user-cog iconosActividades recursosActividad" elementoId="' + objetoActividad.idActividad + '" data-placement="top" title="Asignar Recursos a esta elemento"></i>';
                    */
                    if (banderasActividad.elimina == true) {
                        iconos += '<i class="fa fa-trash iconosActividades eliminaActividad" elementoId="' + objetoActividad.idActividad + '" data-placement="top" title="Eliminar esta Actividad"></i>';
                    }

                    contenido += '<div class="gantt_cell gantt_last_cell" data-column-index="' + item + '" data-column-name="buttons" style="width:' + valor.width + 'px;" role="gridcell" aria-label=" " aria-readonly="true"> <div class="gantt_tree_content">' + iconos + '</div></div>';
                }
            });
            contenido += '</div>';
        }
    });
    // Meses Encabezado
    var contenidoMesesEncabezado = "";
    contenidoMesesEncabezado += '<div class="gantt_scale_cell"></div>';
    $.each(mesesCatalogo, function (itemMes, objetoMes) {
        contenidoMesesEncabezado += '<div class="gantt_scale_cell mes_' + objetoMes.id + '" aria-label="' + objetoMes.corto + '">' + objetoMes.corto + '</div>';
    });
    $("#EncabezadoTablaActividadesMeses").html(contenidoMesesEncabezado);
    $("#EncabezadoTablaActividadesMesesPie").html(contenidoMesesEncabezado);


    //Tabla de Datos
    $("#dvActividadesEncabezadoFila").html(contenido);
    $("#dvActividadesEncabezadoFilaData").html("");
    var contenidoActividades = "";
    $.each(programaSST.Elementos[elementoSeleccionado].Actividades, function (itemActividad, objetoActividadTmp) {
        //console.warn("itemActividad :: " + itemActividad);
        if (typeof objetoActividadTmp === 'undefined' || objetoActividadTmp === null) {
        }
        else {
            contenidoActividades += '<div class="MesProgramado gantt_task_bg" data-layer="true">';
            contenidoActividades += '<div class="tablaMesesTask gantt_task_row summary-bar programado gantt_resource_task gantt_resource_' + objetoActividadTmp.idActividad + '" data-ActividadId="' + objetoActividadTmp.idActividad + '" ActividadId="' + objetoActividadTmp.idActividad + '">';
            contenidoActividades += '<div class="gantt_task_cell leyendaP">P</div>';
            $.each(mesesCatalogo, function (itemMes, objetoMes) {
                //contenidoActividades += '<div class="gantt_task_cell"></div>';
                //$.each(semanaActividades, function (itemSemana, semana) {

                $(semanaActividades).each(function (itemSemana, semanaVal) {
                    var actividad = objetoActividadTmp.idActividad;
                    var mes = objetoMes.id;
                    var semana = semanaVal.id;
                    //var indiceCalculado = regresaIndiceCalculado( mes, semana, true );
                    var classSeleccionado = "";
                    var classMesActivo = " mesActivo";
                    var valor = 0;
                    var valorSemana = regresaMesSemanaValor(actividad, mes, semana);
                    //console.log("valorSemana :: ", valorSemana);
                    if (valorSemana != false) 
                    {
                        valor = valorSemana.valor;
                        if (valorSemana.id > 0) {
                            classSeleccionado = " seleccionarTarea";
                        }
                    }
                    if (banderasActividad.editarPeriodicidad == false) {
                        classMesActivo = " mesInactivo";
                    }
                    else {
                        if (objetoMes.id < mesActual) {//mesActual => variable en programasSST obtiene el mes actual
                            if (banderasActividad.mesInactivo == true) {
                                classMesActivo = " mesInactivo";
                            }
                            //classMesActivo = "";
                        }
                    }
                    
                    contenidoActividades += '<div class="gantt_task_cell mes_P_' + objetoMes.id + classMesActivo + classSeleccionado + '" Elemento="' + elementoSeleccionado + '" actividad="' + objetoActividadTmp.idActividad + '" mes="' + objetoMes.id + '" semana="' + semanaVal.id + '">' + valor + '</div>';
                });


            });
            contenidoActividades += '</div>';
            contenidoActividades += '</div>';

            contenidoActividades += '<div class="MesReal gantt_task_bg" data-layer="true">';
            contenidoActividades += '<div class="tablaMesesTask gantt_task_row summary-bar real gantt_resource_task gantt_resource_' + objetoActividadTmp.idActividades + '" data-elementoId="' + objetoActividadTmp.idActividades + '" elemento_id="' + objetoActividadTmp.idActividades + '">';
            contenidoActividades += '<div class="gantt_task_cell leyendaR">R</div>';
            $.each(mesesCatalogo, function (itemMes, objetoMes) {
                $(semanaActividades).each(function (itemSemana, semanaVal) {
                    /*
                    var actividad = objetoActividadTmp.idActividad;
                    var mes = objetoMes.id;
                    var semana = semanaVal.id;

                    var valorSemana = regresaMesSemanaValor(actividad, mes, semana);
                    contenidoActividades += '<div class="gantt_task_cell mes_R_' + objetoMes.id + ' mesActivo" Elemento="' + elementoSeleccionado + '" actividad="' + objetoActividadTmp.idActividad + '" mes="' + objetoMes.id + '" semana="' + semanaVal.id + '">' + valorSemana + '</div>';
                    //contenidoActividades += '<div class="gantt_task_cell mes_R_' + objetoMes.id +'"></div>';
                    */
                    var actividad = objetoActividadTmp.idActividad;
                    var mes = objetoMes.id;
                    var semana = semanaVal.id;
                    var indiceCalculado = regresaIndiceCalculado(mes, semana);;
                    var classSeleccionado = "";
                    var classMesActivo = "";
                    var valor = 0;
                    var valorSemana = regresaMesSemanaValor(actividad, mes, semana);
                    //console.log("valorSemana :: ", valorSemana);
                    if (valorSemana != false) {
                        valor = valorSemana.valorReal;
                        if (valorSemana.id > 0) {
                            if (banderasActividad.subirEvidencia == true) {
                                classMesActivo = " mesActivo";
                                classSeleccionado = " subirEvidencia";
                            }
                        }
                    }
                    if (objetoMes.id < mesActual) {//mesActual => variable en programasSST obtiene el mes actual
                        //classMesActivo = " mesInactivo";
                    }
                    contenidoActividades += '<div class="gantt_task_cell mes_R_' + objetoMes.id + classMesActivo + classSeleccionado + '" Elemento="' + elementoSeleccionado + '" actividad="' + objetoActividadTmp.idActividad + '" mes="' + objetoMes.id + '" semana="' + semanaVal.id + '">' + valor + '</div>';
                });
            });
            contenidoActividades += '</div>';
            contenidoActividades += '</div>';
        }
    });
    $("#dvActividadesEncabezadoFilaData").html(contenidoActividades);
    // Pie de Tabla de Actividades
    $("#dvActividadesPieFilaData").html("");
    var contenidoActividadesPie = "";
    var calculosPieActividades = new Object();

    $.each(pieActividades, function (itemPieActividad, pieActividad) {
        /* Realizando Calculos */

        calculosPieActividades[pieActividad.name] = new Object();
        $.each(mesesCatalogo, function (itemMes, objetoMes) {
            calculosPieActividades[pieActividad.name][objetoMes.id] = new Object();
            $.each(semanaActividades, function (itemSemana, semanaVal) {
                calculosPieActividades[pieActividad.name][objetoMes.id][semanaVal.id] = 0;
            });
        });
        //console.log(calculosPieActividades);

        $.each(programaSST.Elementos[elementoSeleccionado].Actividades, function (itemActividad, objetoActividad) {
            $.each(objetoActividad.mesSemana, function (itemMesSemana, objetoMesSemana) {
                if (pieActividad.name == "numeroActividadesProgramadas") {
                    calculosPieActividades[pieActividad.name][objetoMesSemana.mes][objetoMesSemana.semana] += objetoMesSemana.valor;
                }
                if (pieActividad.name == "avanceRealActividades") {
                    calculosPieActividades[pieActividad.name][objetoMesSemana.mes][objetoMesSemana.semana] += objetoMesSemana.valorReal;
                }
                if (pieActividad.name == "porcentajeAvance") {
                    if (calculosPieActividades["numeroActividadesProgramadas"][objetoMesSemana.mes][objetoMesSemana.semana] <= 0) {
                        calculosPieActividades["porcentajeAvance"][objetoMesSemana.mes][objetoMesSemana.semana] = 0;
                    }
                    else {
                        var nAP = calculosPieActividades["numeroActividadesProgramadas"][objetoMesSemana.mes][objetoMesSemana.semana];
                        var aRA = calculosPieActividades["avanceRealActividades"][objetoMesSemana.mes][objetoMesSemana.semana];

                        var pAvance = (aRA / nAP) * 100;
                        if (pAvance > 100) {
                            pAvance = 100;
                        }

                        calculosPieActividades["porcentajeAvance"][objetoMesSemana.mes][objetoMesSemana.semana] = pAvance;
                    }
                }
            });
        });
        
    });
    //console.log(calculosPieActividades);
    $.each(pieActividades, function (itemPieActividad, pieActividad) {
        contenidoActividadesPie += '<div id="' + pieActividad.name + '" class="gantt_task_bg" data-layer="true">';
        contenidoActividadesPie += '<div mes="" class="tablaMesesTask gantt_task_row summary-bar gantt_resource_task gantt_resource_' + pieActividad.name + '" data-pieActividadName="' + pieActividad.name + '" pieActividadName="' + pieActividad.name + '">';
            contenidoActividadesPie += '<div class="gantt_task_cell"> </div>';
            $.each(mesesCatalogo, function (itemMes, objetoMes) {
                $(semanaActividades).each(function (itemSemana, semanaVal) {

                    try {
                        contenidoActividadesPie += '<div pieActividadName="' + pieActividad.name + '" mes="' + objetoMes.id + '" semana="' + semanaVal.id + '" class="gantt_task_cell infoPie">' + calculosPieActividades[pieActividad.name][objetoMes.id][semanaVal.id] + '</div>';
                    }
                    catch (ex) {
                        contenidoActividadesPie += '<div pieActividadName="' + pieActividad.name + '" mes="' + objetoMes.id + '" semana="' + semanaVal.id + '" class="gantt_task_cell infoPie">0</div>';
                        console.error(ex);
                    }
                });
            });
            contenidoActividadesPie += '</div>';
            contenidoActividadesPie += '</div>';
        
    });

    $("#dvActividadesPieFilaData").html(contenidoActividadesPie);
    generaTablaActividadesFn();
    generaPonderacionActividades();
    //ToolTip
    //$(".iconosActividades").tooltip();
}
function regresaIndiceCalculado(mes, semana, imprimir = false) {
    var total = ((mes - 1) * 4) + (semana - 1);
    if (imprimir == true) {
        console.log("mes :: " + mes + " semana :: " + semana + " total :: " + total);
    }
    return total;
}
function generaTablaActividadesFn() {
    $(".eliminaActividad").unbind("click");
    $(".eliminaActividad").bind("click", function () {
        var elementoId = $(this).attr("elementoId");
        if (programaSST.Elementos[elementoSeleccionado].Actividades[elementoId] != null) {
            var thisObjeto = this;
            swal({
                title: "Eliminar Actividad",
                text: "¿Está seguro que quiere eliminar el registro? \n ",
                icon: "warning",
                buttons: { cancel: { text: "Cancelar", value: null, visible: !0, className: "", closeModal: true }, confirm: { text: "¡Sí, eliminarlo!", value: !0, visible: !0, className: "bg-danger", closeModal: true } }

            }).then(function (e) {
                if (e) {
                    $(thisObjeto).prop("checked", false);
                    if (programaSST.Elementos[elementoSeleccionado].Actividades[elementoId].eliminaActividad()) {
                        delete programaSST.Elementos[elementoSeleccionado].Actividades[elementoId];
                    }
                    generaTablaActividades();
                }
                else {
                    swal.close();
                }
            });
        }
    });
    $("#dvActividades .gantt_close").unbind("click");
    $("#dvActividades .gantt_close").bind("click", function () {
        //var elementoId = $(this).attr("elementoId");
        $("#dvActividades").hide();
        $("#dvElementos").show();
        generaTablaActividades();
        generaTablaElementos();
    });
    mesSemanaEventos();
    
}
function mesSemanaEventos() {
    $("#dvActividadesEncabezadoFilaData .MesProgramado .mesActivo").unbind("click");
    $("#dvActividadesEncabezadoFilaData .MesProgramado .mesActivo").bind("click", function () {
        guardaMesSemana($(this));
    });
    $("#dvActividadesEncabezadoFilaData .MesReal .mesActivo").unbind("click");
    $("#dvActividadesEncabezadoFilaData .MesReal .mesActivo").bind("click", function () {
        var elemento = $(this).attr("elemento");
        var actividad = $(this).attr("actividad");
        var mes = $(this).attr("mes");
        var semana = $(this).attr("semana");
        var indiceCalculado = regresaIndiceCalculado(mes, semana);
        var actividadObj = programaSST.Elementos[elemento].Actividades[actividad];
        var mesSemana = programaSST.Elementos[elemento].Actividades[actividad].mesSemana[indiceCalculado];

        if ((actividadObj.esGilSupervision == 1 || actividadObj.esGilHerramienta == 1))
        {
            if (actividad == GilHerramientasActividades[actividad] ) {//Es la actividad relacionada con Gil Herramientas
                programaSST.Elementos[elemento].Actividades[actividad]
            }
            try {
                ModalEvidenciaGilSupervicion( mes );
            }
            catch (ex) {
                console.warn("No se encuentra el archivo de gil.js");
            }
        }
        else {
            subirEvidenciaEvento(mesSemana, actividad);

            if (mes >= mesActual - 1 && diaActual <= programaSST.diaCorte) {
                //alert(mes);
                $("#GuardarEvidenciaFromList").show();
            }
            else if (mes >= mesActual) {
                //alert( mes );
                $("#GuardarEvidenciaFromList").show();
            }
            else {
                $("#GuardarEvidenciaFromList").hide();
            }
        }

    });
}
function regresaMesSemanaValor(actividad, mes, semana)
{
    var indiceCalculado = regresaIndiceCalculado(mes, semana, false);
    try {
        var objeto = programaSST.Elementos[elementoSeleccionado].Actividades[actividad].mesSemana[indiceCalculado];
        //console.log("");
        //if (objeto.id > 0) {
            //console.log( objeto );
        //}
        return objeto;
    }
    catch(ex)
    {
        return false;
    }


    
    if (campo == "valor") {
        if (programaSST.Elementos[elementoSeleccionado].Actividades[actividad].mesSemana[indiceCalculado].valor >= 0) {
            return programaSST.Elementos[elementoSeleccionado].Actividades[actividad].mesSemana[indiceCalculado].valor;
        }
        else {
            return 0;
        }
    }
    else if (campo == "real") {
        if (programaSST.Elementos[elementoSeleccionado].Actividades[actividad].mesSemana[indiceCalculado].valorReal >= 0) {
            return programaSST.Elementos[elementoSeleccionado].Actividades[actividad].mesSemana[indiceCalculado].valorReal;
        }
        else {
            return 0;
        }
    }
    return "";
}
function regresaElementoId( ) {
    return programaSST.Elementos[elementoSeleccionado].id;
}
function nuevaActividadFormulario() {

    $('#ActividadesFormCatalogo').validate();
    $('#ActividadesFormCatalogo').removeAttr('novalidate');
    if (!$("#NuevaActividad").valid()) {
        return false;
    }
    var textoNuevaActividad = $("#NuevaActividad").val();

    //if (textoNuevaActividad == "") {
    //    alert("Escribir el nombre de la nueva elemento");
    //    return false;
    //}
    //var currentDate = new Date();
    //var timestamp = currentDate.getTime();
    var timestamp = 1000 + nuevaActividadSinCatalogo;
    nuevaActividad(textoNuevaActividad, timestamp, elementoSeleccionado);
    nuevaActividadSinCatalogo++;
    $("#NuevaActividad").val("");
}
function nuevaActividad(textoNuevaActividad, timestamp, claveElemento) {

    ActividadesObj.push({ "clave": timestamp, "claveElemento": claveElemento, "descripcion": textoNuevaActividad, "Nueva": true });

    var NuevaItem = ActividadesObj.length - 1;
    agregaNuevaActividadListadoFormulario(NuevaItem, timestamp, textoNuevaActividad, true);
    muestraListaActividadesFormularioFn();
}

function agregaNuevaActividadListadoFormulario(item, clave, descripcion, checked) {
    var checkedActividad = "";
    if (checked == true) {
        checkedActividad = " checked='checked' ";
    }
    $("#ActividadesList").append("<div><label class='c-checkbox'> <input id='Actividad_" + clave+"' type='checkbox' name='actividades[]' class='actividades' indice='" + item + "' value='" + clave + "' " + checkedActividad + "> <span class='fa fa-check'></span>" + descripcion + " </label></div>");
}
function muestraListaActividadesFormulario() {
    $("#ActividadesList").html("");
    $(ActividadesObj).each(function (item, actividad) {
        if (actividad.claveElemento == elementoSeleccionado) {
            var checkedActividad = false;
            if (programaSST.Elementos[elementoSeleccionado].Actividades[actividad.idActividad]) {
                checkedActividad = true;
            }
            agregaNuevaActividadListadoFormulario(item, actividad.clave, actividad.descripcion, checkedActividad);
        }
    });
    muestraListaActividadesFormularioFn();
}
function muestraListaActividadesFormularioFn() {
    $(".actividades").unbind("click");
    $(".actividades").bind("click", function () {
        var elementoId = $(this).val();
        var seleccionado = $(this).prop("checked");
        if (!seleccionado) {
            if (programaSST.Elementos[elementoSeleccionado].Actividades[elementoId] != null) {
                if (!confirm("¿Está seguro que quiere eliminar el registro?")) {
                    $("#Actividad_" + elementoId).prop("checked", true);
                }
            }

        }

    });
}
function inicializaActividades() {
    var alto_ventana = top.window.innerHeight - 250;
    $("#ActividadesList").css("height", alto_ventana+"px");
    //Agregar nueva elemento
    $("#agregaActividad").unbind("click");
    $("#agregaActividad").bind("click", function () {
        nuevaActividadFormulario();
    });
    //Muestra Listado Formulario de actividades
    muestraListaActividadesFormulario();
    //Muestra Modal de Actividades
    $("#btnActividadAgrega").unbind("click");
    $("#btnActividadAgrega").bind("click", function () {
        $("#ModalActividades").modal("show");
        //Actualizar tamaño
        $("#NuevaActividad").height( 72 );
        setTimeout(function () {
            $(".modal-backdrop").remove();
        }, 500);
        $(".actividades").prop("checked", false);
        $.each(programaSST.Elementos[elementoSeleccionado].Actividades, function (itemActividad, objetoActividadTmp) {
            if (typeof objetoActividadTmp === 'undefined' || objetoActividadTmp === null) {
            }
            else {
                var idActividadTmp = objetoActividadTmp.idActividad;
                $("#Actividad_" + idActividadTmp).prop("checked", true);
            }
        });

    });
    //Guardar o Aceptar Actividades
    $("#aceptarActividades").bind("click", function () {
        var totalActividades = $(".actividades").length;
        if (totalActividades > 0) {
            $(".actividades").each(function (index) {
                var seleccionado = $(this).prop("checked");
                var indiceActividad = $(this).attr("indice");
                var catalogo = ActividadesObj[indiceActividad];
                var elementoTmp = programaSST.Elementos[elementoSeleccionado];
                if (seleccionado) {
                    if (!programaSST.Elementos[elementoSeleccionado].Actividades[catalogo.clave]) {
                        var esCatalogo = true;
                        try {
                            if (catalogo.Nueva == true) {
                                esCatalogo = false;
                            }
                        } catch (ex) {
                            //esCatalogo = false;
                        }

                        var objeto = new Object();
                        objeto.actividadDescripcion = catalogo.descripcion;
                        objeto.id = 0;
                        objeto.esCatalogo = esCatalogo;
                        objeto.idActividad = catalogo.clave;
                        objeto.idElemento = elementoSeleccionado;
                        objeto.idPrograma = programaId;
                        objeto.idResponsable = elementoTmp.idResponsable;
                        objeto.mesSemana = new Object();
                        objeto.responsableNombre = elementoTmp.responsableNombre;
                        objeto.responsableRPE = elementoTmp.responsableRPE;
                        objeto.responsableRPENombre = elementoTmp.responsableRPENombre;
                        objeto.ponderacion = 0;

                        programaSST.Elementos[elementoSeleccionado].Actividades[objeto.idActividad] = new Actividad();
                        programaSST.Elementos[elementoSeleccionado].Actividades[objeto.idActividad].agregarActividadNueva(objeto, objeto.idActividad);
                    }
                }
                else {
                    if (programaSST.Elementos[elementoSeleccionado].Actividades[catalogo.clave])
                    {
                        delete programaSST.Elementos[elementoSeleccionado].Actividades[catalogo.clave];
                        muestraListaActividadesFormulario();
                    }
                }
            });
        }
        generaTablaActividades();
    });
}
var anchoActividades = 0;
var panelActividadesSecundario = 0;
var espacioPanel = 50;
var limitePanel = 5;
var totalTareas = 5;
var anchoPanelActividades = 555;

$(document).ready(function () {
    anchoActividades = $("#contenedorProgramas").width() - espacioPanel;
    panelActividadesSecundario = anchoActividades - anchoPanelActividades - limitePanel;
    $("#dvActividadesPrincipal").width(anchoActividades);
    $("#dvActividadesPrincipal > div").width(anchoActividades);
    $(".panelActividadesSecundario").width(panelActividadesSecundario);
    scrollActividadesResumen();
});

function scrollActividadesResumen() {
    $("#panelActividadesSecundarioTareas").scroll(function () {
        var currPos = $(this).scrollLeft();
        $("#dvActividadesPieFilaData").css("margin-left", "-" + currPos + "px");
        $("#EncabezadoTablaActividadesMesesPie").css("margin-left", "-" + currPos + "px");
    });
}

//Funcion guardaMesSemana

function guardaMesSemana(mesSemanaSeleccionado) {
    var elemento = $(mesSemanaSeleccionado).attr("elemento");
    var actividad = $(mesSemanaSeleccionado).attr("actividad");
    var mes = $(mesSemanaSeleccionado).attr("mes");
    var semana = $(mesSemanaSeleccionado).attr("semana");
    var indiceCalculado = regresaIndiceCalculado(mes, semana);
    var mesSemana = programaSST.Elementos[elemento].Actividades[actividad].mesSemana[indiceCalculado];

    if (programaSST.Elementos[elemento].Actividades[actividad].mesSemana[indiceCalculado] != null) {
        programaSST.Elementos[elemento].Actividades[actividad].mesSemana[indiceCalculado].valor++;
        $(mesSemanaSeleccionado).addClass("seleccionarTarea");

        if (programaSST.Elementos[elemento].Actividades[actividad].mesSemana[indiceCalculado].valor >= (totalTareas + 1)) {
            programaSST.Elementos[elemento].Actividades[actividad].mesSemana[indiceCalculado].valor = 0;
            $(mesSemanaSeleccionado).removeClass("seleccionarTarea");
        }
        programaSST.Elementos[elemento].Actividades[actividad].guardaMesSemana(indiceCalculado, actividad);
        $(mesSemanaSeleccionado).html(programaSST.Elementos[elemento].Actividades[actividad].mesSemana[indiceCalculado].valor);

    }
    
}

//Funciones Evidencias
/**
 * /
 * @param {any} mesSemanaObj
 * mesSemana = new Object({
        id: //Id identidad de la tabla en la BD,
        idActividad: //Id de la Actividad,
        idElemento: //Id del Elemento
        mes: //Mes 1-12
        semana: //Semana 1-4
        valor: 0, //El número de actividades
        valorReal: //Total de evidencias que se han subido
    });
 */

function subirEvidenciaEvento(mesSemanaObj, actividadSeleccionada) {
    objetoMesSemanaEnviado = mesSemanaObj;
    actividadEvidencia = actividadSeleccionada;
    //console.log(mesSemanaObj);
    //get the actual Id of ActividadMesSemana for VerEvidencias modal
    var list_idMesSemana = mesSemanaObj.id;

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
}

function incrementaValorReal(objetoSemanaTmp, actividadTmp) {
    //console.log("incrementaValorReal");
    var mes = objetoSemanaTmp.mes;
    var semana = objetoSemanaTmp.semana;
    var indiceCalculado = regresaIndiceCalculado(mes, semana);
    try {
        programaSST.Elementos[elementoSeleccionado].Actividades[actividadTmp].mesSemana[indiceCalculado].valorReal++;
    }
    catch (ex) {
        //console.error("Error al asignar el valor de la evidencia");
        //console.log("elementoSeleccionado :: " + elementoSeleccionado + " actividadTmp :: " + " indiceCalculado :: " + indiceCalculado);
        //console.log("valorReal :: " + programaSST.Elementos[elementoSeleccionado].Actividades[actividadTmp].mesSemana[indiceCalculado].valorReal );
        //alert("Error al asignar el valor de la evidencia");

    }
    try { actualizaAvanceMensual(mes); }
    catch (ex) { console.warn("No se encuentra la funcion :: actualizaAvanceMensual desde :: incrementaValorReal") }

}

/* Ponderación */
function RegresaSumaPonderacionActividades() {
    var ActividadesTmp = programaSST.Elementos[elementoSeleccionado].Actividades;
    var valor = 0;
    $.each(ActividadesTmp, function (ActividadesTmpItem, ActividadesObj) {
        valor += numeral(ActividadesObj.ponderacion).value();
    });
    return valor;
}
function generaPonderacionActividades() {
    var contenidoPonderacion = "";
    var totalElementoPonderacion = programaSST.Elementos[elementoSeleccionado].ponderacion;
    var sumaElementoPonderacion = RegresaSumaPonderacionActividades();

    if (banderasActividad.editaPonderacion == true) {
        contenidoPonderacion += "<div id='SumaPonderacionActividadesCk'>";
    }
    else {
        contenidoPonderacion += "<div>";
    }
    contenidoPonderacion += "<strong>Suma de Ponderaci\u00f3n de las actividades es: " + sumaElementoPonderacion + " de un total de " + totalElementoPonderacion + "</strong>";
    if (banderasActividad.editaPonderacion == true) {
        contenidoPonderacion += '<i id="editaPonderacionActividad" class="fa fa-tasks iconosActividades" data-placement="top" title="Edita Ponderaci\u00f3n de Actividades"></i>';
    }
    contenidoPonderacion += "</div>";
    $("#SumaPonderacionActividades").html(contenidoPonderacion);
    generaPonderacionActividadFn();
}
function generaPonderacionActividadFn() {
    //Boton modal Ponderacion
    $(".list_ponderacion_actividad").unbind("click");
    $(".list_ponderacion_actividad").bind("click", function () {
        $("#SumaPonderacionActividadesCk").click();
    });

    $("#SumaPonderacionActividadesCk").unbind("click");
    $("#SumaPonderacionActividadesCk").bind("click", function () {
        $("#ModalActividadPonderacion").modal("show");
        generaPonderacionActividadTablaContenido();
        setTimeout(function () {
            $(".modal-backdrop").remove();
        }, 500);
    });
    //Boton Guardar Ponderación
    $("#aceptarActividadPonderacion").unbind("click");
    $("#aceptarActividadPonderacion").bind("click", function (event) {
        //Verifica Ponderacion
        $('#ActividadPonderacionForm').validate();
        $('#ActividadPonderacionForm').removeAttr('novalidate');
        /* Revisando si hay un elemento invalido */

        if (!$(".inputPonderacionActividad").valid()) {
            event.preventDefault();
            return false;
        }

        var totalElementoPonderacion = programaSST.Elementos[elementoSeleccionado].ponderacion;
        var valor = 0;
        $.each($(".inputPonderacionActividad"), function (itemInputPonderacion, inputPonderacion) {
            valor += numeral($(this).val()).value();
        });
        if (valor > totalElementoPonderacion) {
            swal("Ponderaci\u00f3n Actividades", "La suma de la ponderaci\u00f3n en los actividades sobrepasa " + totalElementoPonderacion, "info");
            return false;
        }
        var actividadGuardar = new Object();
        $.each($(".inputPonderacionActividad"), function (itemInputPonderacion, inputPonderacion) {
            var itemActividad = $(this).attr("itemActividad");
            var ponderacion = numeral($(this).val()).value();

            if (programaSST.Elementos[elementoSeleccionado].Actividades[itemActividad].ponderacion != ponderacion) {
                programaSST.Elementos[elementoSeleccionado].Actividades[itemActividad].ponderacion = ponderacion;
                actividadGuardar[itemActividad] = programaSST.Elementos[elementoSeleccionado].Actividades[itemActividad];
            }
        });
        $.each($(".selectEvaluacionActividad"), function (itemInputPonderacion, inputPonderacion) {
            var itemActividad = $(this).attr("itemActividad");
            var evaluacion = numeral($(this).val()).value();

            if (programaSST.Elementos[elementoSeleccionado].Actividades[itemActividad].evaluacion != evaluacion) {
                programaSST.Elementos[elementoSeleccionado].Actividades[itemActividad].evaluacion = evaluacion;
                actividadGuardar[itemActividad] = programaSST.Elementos[elementoSeleccionado].Actividades[itemActividad];
            }
        });
        $.each(actividadGuardar, function (itemActividad, objetoActividad) {
            objetoActividad.actualizarActividad();
        });
        //Actualizar Panel
        generaTablaActividades();
    });

}

function generaPonderacionActividadTablaContenido() {
    var contenido = "";
    contenido += '<table class="table table-striped table-bordered">';
    contenido += '<thead><tr class="table-info">';
    contenido += '<th>Actividad</th>';
    contenido += '<th>' + toUnicode("Ponderación") + '</th>';
    contenido += '<th>' + toUnicode("Evaluación") + '</th>';
    contenido += '</tr></thead>';
    contenido += '<tbody>';
    var ActividadesTmp = programaSST.Elementos[elementoSeleccionado].Actividades;
    var totalElementoPonderacion = programaSST.Elementos[elementoSeleccionado].ponderacion;

    $.each(ActividadesTmp, function (itemActividad, objetoActividadTmp) {
        var objetoActividad = objetoActividadTmp;

        //console.log(objetoActividad);

        //contenido += '<tr>';
        //contenido += '<td>' + objetoActividad.actividadDescripcion + '</td>';
        //contenido += '<td><div> <input min="0" max="100" itemActividad="' + itemActividad + '" type="number" class="form-control inputPonderacionActividad" value="' + objetoActividad.ponderacion + '" /> </div></td>';


        contenido += '<tr class="form-group">';
        contenido += '<td><label class="col-form-label" for="inputponderacionactividad' + itemActividad + '">' + toUnicode(objetoActividad.actividadDescripcion) + '</label></td>';
        contenido += '<td><div> <input name="inputponderacionactividad' + itemActividad + '" id="inputponderacionactividad' + itemActividad + '" itemActividad="' + itemActividad + '" type="number" class="form-control inputPonderacionActividad required number" value="' + objetoActividad.ponderacion + '" data-msg-required="' + toUnicode("Es necesaría la ponderación") + '" data-val="true" data-msg-number="' + toUnicode("La ponderación debe de ser número") + '" data-msg-min="' + toUnicode("La ponderación debe estar entre 0 a " + totalElementoPonderacion) + '" data-msg-max="' + toUnicode("La ponderación debe estar entre 0 a " + totalElementoPonderacion) + '" max="' + totalElementoPonderacion+'" min="0"/><span class="field-validation-valid text-danger" data-valmsg-for="inputponderacionactividad' + itemActividad + '" data-valmsg-replace="true"></span></div></td>';



        contenido += '<td><div> <select itemActividad="' + itemActividad + '" class="form-control selectEvaluacionActividad">';

        $.each(catalogoEvaluacion, function (id, valor) {
            if (valor.id == objetoActividad.evaluacion) {
                contenido += '<option value="' + valor.id + '" selected>' + valor.descripcion + '</option>';
            }
            else {
                contenido += '<option value="' + valor.id + '">' + valor.descripcion + '</option>';
            }

        });

        contenido += '</select></div></td>';

        //catalogoEvaluacion

        contenido += '</tr>';

    });
    contenido += '</tbody>';
    
    var sumaElementoPonderacion = RegresaSumaPonderacionActividades();

    contenido += '</tfooter>';
    contenido += '<tr class="table-primary">';
    contenido += '<td>Total:</td>';
    contenido += '<td id="sumaActividadPonderacionTd">' + sumaElementoPonderacion + '</td>';
    contenido += '<td></td>';
    contenido += '</tr>';

    contenido += '<tr class="table-primary">';
    contenido += '<td>Ponderaci\u00f3n Elemento:</td>';
    contenido += '<td id="ElementoPonderacionTd">' + totalElementoPonderacion + '</td>';
    contenido += '<td></td>';
    contenido += '</tr>';

    contenido += '</tfooter>';
    contenido += '</table>';
    $("#ActividadPonderacionForm").html(contenido);
    $(".inputPonderacionActividad").unbind("change");
    $(".inputPonderacionActividad").bind("change", function () {
        //console.log("Valor :: " + $(this).val());

        $('#ActividadPonderacionForm').validate();
        $('#ActividadPonderacionForm').removeAttr('novalidate');
        /* Revisando si hay un elemento invalido */

        if (!$(".inputPonderacionActividad").valid()) {
            event.preventDefault();
            return false;
        }


        var valor = 0;
        $.each($(".inputPonderacionActividad"), function (itemInputPonderacion, inputPonderacion) {

            valor += numeral($(this).val()).value();

        });
        //console.log("Suma:: " + valor);

        $("#sumaActividadPonderacionTd").html(valor);
        $("#sumaActividadPonderacionTd").removeClass("sobrePasoPonderacion");
        if (valor > totalElementoPonderacion) {
            $("#sumaActividadPonderacionTd").addClass("sobrePasoPonderacion");
        }
    });
}

