class AvanceMensual {
    id = 0;
    idPrograma = 0;
    mes = 0;
    avanceProgramado = 0;
    avanceReal = 0;
    avanceRealPorc = 0;
    acumuladoPorc = 0;
    ponderacionProgramada = 0;

    constructor() {
        this.id = 0;
        this.idPrograma = 0;
        this.mes = 0;
        this.avanceProgramado = 0;
        this.avanceReal = 0;
        this.avanceRealPorc = 0;
        this.acumuladoPorc = 0;
        this.ponderacionProgramada = 0;
    }
    agregarAvanceMensualGantt(objetoAvanceMensual) {
        if (objetoAvanceMensual.id != null) this.id = objetoAvanceMensual.id;
        //if (objetoAvanceMensual.idPrograma != null) this.idPrograma = objetoAvanceMensual.idPrograma;
        this.idPrograma = programaSST.id;
        if (objetoAvanceMensual.mes != null) this.mes = objetoAvanceMensual.mes;
        if (objetoAvanceMensual.avanceProgramado != null) this.avanceProgramado = objetoAvanceMensual.avanceProgramado;
        if (objetoAvanceMensual.avanceReal != null) this.avanceReal = objetoAvanceMensual.avanceReal;
        if (objetoAvanceMensual.avanceRealPorc != null) this.avanceRealPorc = objetoAvanceMensual.avanceRealPorc;
        if (objetoAvanceMensual.acumuladoPorc != null) this.acumuladoPorc = objetoAvanceMensual.acumuladoPorc;
        if (objetoAvanceMensual.ponderacionProgramada != null) this.ponderacionProgramada = objetoAvanceMensual.ponderacionProgramada;
    }
    agregarAvanceMensualCreateGet(objetoAvanceMensual) {
        if (objetoAvanceMensual.Id != null) this.id = objetoAvanceMensual.Id;
        //if (objetoAvanceMensual.IdPrograma != null) this.idPrograma = objetoAvanceMensual.IdPrograma;
        this.idPrograma = programaSST.id;
        if (objetoAvanceMensual.Mes != null) this.mes = objetoAvanceMensual.Mes;
        if (objetoAvanceMensual.AvanceProgramado != null) this.avanceProgramado = objetoAvanceMensual.AvanceProgramado;
        if (objetoAvanceMensual.AvanceReal != null) this.avanceReal = objetoAvanceMensual.AvanceReal;
        if (objetoAvanceMensual.AvanceRealPorc != null) this.avanceRealPorc = objetoAvanceMensual.AvanceRealPorc;
        if (objetoAvanceMensual.AcumuladoPorc != null) this.acumuladoPorc = objetoAvanceMensual.AcumuladoPorc;
        if (objetoAvanceMensual.PonderacionProgramada != null) this.ponderacionProgramada = objetoAvanceMensual.PonderacionProgramada;
    }
    actualizarAvanceMensual() {

        if (urlAvanceMensualPrograma != "") {
            $.post(urlAvanceMensualPrograma, this.retornaObjetoActualizar(), function (data) {
                if (data.id > 0) {
                    toastr.options.positionClass = 'toast-bottom-right';
                    toastr['success']('AvanceMensual Guardado');
                    this.id = data.id;
                }
            }, "json");
        }

    }
    createAvanceMensual() {
        if (obtieneCreateAvanceMensual != "") {
            $.LoadingOverlay("show");
            totalPeticionesAvanceMensual++;
            var avanceMensualActual = this;
            if (obtieneCreateAvanceMensual) {
                var url = obtieneCreateAvanceMensual + "?idPrograma=" + programaSST.id + "&anio=" + programaSST.anioElaboracion + "&mes=" + avanceMensualActual.mes;
                //console.log( url );

                $.ajax({
                    type: "GET",
                    url: url,
                    //-data: "{}",
                    dataType: "json",
                    success: function (data) {
                        //alert(data[1]);
                        avanceMensualActual.agregarAvanceMensualCreateGet(data);
                        totalPeticionesAvanceMensual--;
                        $.LoadingOverlay("hide");//$.unblockUI();
                    },
                    error: function (data) {
                        //alert("fail");
                        console.warn("No se pudo crear el avance Mensual Obteniendo el Avance Mensual");
                        avanceMensualActual.getAvanceMensual();
                        totalPeticionesAvanceMensual--;
                        $.LoadingOverlay("hide");//$.unblockUI();

                    }
                });
            }
        }
    }
    getAvanceMensual() {
        if (obtieneGetAvanceMensual) {
            $.LoadingOverlay("show");
            totalPeticionesAvanceMensual++;
            var avanceMensualActual = this;
            if (obtieneGetAvanceMensual != "") {
                var url = obtieneGetAvanceMensual + "?idPrograma=" + programaSST.id + "&anio=" + programaSST.anioElaboracion + "&mes=" + avanceMensualActual.mes;
                //console.log(url);
                $.ajax({
                    type: "GET",
                    url: url,
                    //-data: "{}",
                    dataType: "json",
                    success: function (data) {
                        //alert(data[1]);
                        totalPeticionesAvanceMensual--;
                        avanceMensualActual.agregarAvanceMensualCreateGet(data);
                        $.LoadingOverlay("hide");//$.unblockUI();
                    },
                    error: function (data) {
                        //alert("fail");
                        totalPeticionesAvanceMensual--;
                        $.LoadingOverlay("hide");//$.unblockUI();
                        console.warn("No se pudo obtener el avance Mensual");
                        //avanceMensualActual.createAvanceMensual();
                    }
                });
            }
        }
    }
    retornaObjeto() {
        var avanceMensualActual = this;
        var objeto = new Object({
            id: avanceMensualActual.id,
            idPrograma: avanceMensualActual.idPrograma,
            mes: avanceMensualActual.mes,
            avanceProgramado: avanceMensualActual.avanceProgramado,
            avanceReal: avanceMensualActual.avanceReal,
            avanceRealPorc: avanceMensualActual.avanceRealPorc,
            acumuladoPorc: avanceMensualActual.acumuladoPorc,
            ponderacionProgramada: avanceMensualActual.ponderacionProgramada,
        });
        return objeto;
    }
}

function actualizaAvanceMensual( mes ) {
    //Url para obtener los datos del Avance Mensual
    if (urlGetAvanceMensualAnio != "") {
        $.get(urlGetAvanceMensualAnio + "?idPrograma=" + programaSST.id + "&anio=" + programaSST.anioElaboracion + "&mes=" + mes, function (datosAvanceMensual) {
            programaSST.AvanceMensual = new Object();
            $.each(mesesCatalogo, function (itemMes, objetoMes) {
                programaSST.AvanceMensual[objetoMes.id] = new AvanceMensual();
                programaSST.AvanceMensual[objetoMes.id].idPrograma = programaSST.id;
                programaSST.AvanceMensual[objetoMes.id].mes = objetoMes.id;
            });
            $.each(datosAvanceMensual, function (itemAvanceMensual, objetoAvanceMensual) {
                //programaSST.AvanceMensual[objetoMes.id] = new AvanceMensual();
                //console.log(objetoAvanceMensual);
                var mes = objetoAvanceMensual.mes
                programaSST.AvanceMensual[mes].agregarAvanceMensualGantt(objetoAvanceMensual);
            });
            inicializaElementos();
        });
    }
}