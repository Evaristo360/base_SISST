using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunes.Ayudas.Gestion.IP
{
  
        /// <summary>
        /// Identificación de peligros, módulo de Gestion-IP
        /// </summary>
        public enum enumAyudasIP : int
        {
            [Description("Por su origen el peligro se clasifica en interno y externo. Ejemplo: los criterios de esta clasificación se diferencian por el grado de control que el centro de trabajo pueda aplicar sobre las fuentes con potencial para causar lesiones y deterioro de la salud en el lugar de trabajo y en sus inmediaciones.")]
            txtOrigen = 1,
            [Description("No es responsabilidad del centro de trabajo y está fuera de su alcance y posibilidades establecer y aplicar controles. Ejemplos: inseguridad pública, delincuencia organizada, robos y asaltos en la vía pública, balaceras, secuestros, incidentes vehiculares provocados por terceros en la vía pública, epidemias, contingencias ambientales; efectos de fenómenos naturales en lugares fuera del control de la organización, incendios y explosiones en instalaciones fuera del control del centro de trabajo.")]
            txtExterno = 2,
            [Description("Es responsabilidad del centro de trabajo y está dentro de su alcance y posibilidades establecer y aplicar controles. Son todos los peligros relacionados con los procesos del centro de trabajo. Ejemplos: los peligros eléctricos y mecánicos son de origen interno asociados a los procesos de generación, transmisión y distribución de energía eléctrica.")]
            txtInterno = 3,
            [Description("Los registrados en el Directorio SIG-CFE (M-1020-004). Ejemplos: Zona de distribución, Central Generadora, Zona de transmisión, Zona de operación, Zona comercial, Residencia, Oficina administrativa, Edificio corporativo.")]
            txtCentroTrabajo = 4,
            [Description("Aplica para departamentos, oficinas o procesos. Ejemplos: distribución, subestaciones, equipo eléctrico, líneas de subtransmisión, conexiones, mecánico, eléctrico, instrumentación, químico, operación, civil, construcción, diseño, servicio al cliente, mantenimiento, centros de trabajo dentro de un edificio corporativo (nivel 3).")]
            txtDepartamento = 5,
            [Description("Es el nombre del puesto que desempeña un trabajador de acuerdo con un contrato o suplencia. Ejemplos: liniero línea viva, liniero encargado línea viva, sobrestante, mecánico, electricista, ayudante, operador, auxiliar de campo, supervisor, chofer, auxiliar de servicios. Estas categorías se capturan previamente por cada centro de trabajo de acuerdo con su estructura, en el menú de Identificación de peligros / Categorías.")]
            txtCategoria = 6,
            [Description("Se indica el nombre y firma del personal de supervisión y trabajadores de la categoría que participa en la identificación de peligros")]
            txtElaborador = 7,
            [Description("Se indica el nombre y firma del jefe del área o en su caso el jefe del centro de trabajo")]
            txtAprobador = 8,
            [Description("Conjunto de situaciones, sucesos, acontecimientos o circunstancias en que puede presentarse un peligro. Ejemplos: Cómo se organiza el trabajo, actividades rutinarias y no rutinarias, incidentes pasados, emergencias potenciales, personas, diseño, situaciones en las inmediaciones del lugar de trabajo, situaciones fuera del control del centro de trabajo, cambios reales o propuestos, cambios en el conocimiento e información sobre los peligros.")]
            txtCasosPeligro = 9,
            [Description("Describir lo más claro y detallado posible las circunstancias y el contexto (ambiente entorno) donde interactúan los siguientes elementos: tipo de peligro identificado, tipo de contacto de las diferentes formas de energía, vías de entrada de agentes ambientales al cuerpo humano, especificar la fuente de la lesión (nombre de: la sustancia, estructura, maquinaria, equipo), descripción de los pasos de las actividades donde pueden suscitarse daños y lesiones; además de los referidos, se deben tomar en cuenta todos los elementos que en su conjunto interviene en los mecanismos que pueden causar lesiones y deterioro de la salud. Ejemplos: Al realizar cambio de aislador tipo alfiler en línea desenergizada de media tensión el punto de trabajo se puede llegar a energizar.")]
            DescripcionPeligro = 10,
            [Description("Describir lo más detallado posible, partiendo del menú “Tipo de contacto” las características del tipo de contacto relacionado con la interacción identificada con el peligro y con la fuente de lesión referida en el campo anterior. Ejemplos: Contacto directo con electricidad, romper distancia de seguridad respecto a partes energizadas, relámpago de arco, el punto de trabajo se puede energizar por: retorno de la baja tensión, inducción de líneas adyacentes, descargas atmosféricas, cruces con otros circuitos.")]
            DescripcionContacto = 11,
            [Description("Describir y especificar los efectos adversos que resultan o pueden resultar en la condición de las personas, daños, lesiones y deterioro de la salud, derivado de los datos de los dos campos anteriores, priorizando las consecuencias por su mayor gravedad. Ejemplos: muerte provocada por contacto eléctrico, incapacidad permanente total o parcial, incapacidad temporal, quemaduras de tercer grado.")]
            DescripcionConsecuencia = 12,
            [Description("La evaluación de riesgos grupal se debe aplicar y documentar al menos para los peligros que han causado muertes o incapacidades permanentes a nivel nacional en los últimos 5 años, este criterio no es limitativo para que cada centro de trabajo lo aplique libremente donde lo considere de utilidad")]
            AplicaERG1 = 13,
            [Description("")]
            AplicaERG2 = 14,
            [Description("Detallar el nombre de la instalación, equipo, infraestructura. Ejemplos: Turbina, generador eléctrico, generador de vapor, sistema de lubricación, sistema de enfriamiento, líneas de transmisión, red de media tensión, red de baja tensión, subestación (especificar kV).")]
            Sistema = 15,
            [Description("Especificar el enfoque para evitar la tendencia a salirse del tema. Es útil hacerlo por partes, priorizando su importancia, definiendo lo que será o no será incluido en la evaluación. Si es necesario realice evaluaciones adicionales. Ejemplos: 1. para el sistema “generador eléctrico U1” el alcance puede ser “ingreso al foso del generador para inspección de gatos de frenado”, 2. para el sistema “red de media tensión” el alcance puede ser “circuito PAC 5080”.")]
            Alcance = 16,
            [Description("Puede ser el componente de un sistema, la posición en un circuito, un sitio geográfico, uno de los pasos de un procedimiento, una medida de tiempo o simplemente un número usado para denotar el orden. Ejemplos: Pasos para librar un equipo o un circuito, cambio de aislamiento en línea desenergizada, estructura No. 50 del circuito PAC 5080.")]
            Componente= 17,
            [Description("Puede ser un riesgo, una desviación o una preocupación específica, asociado con un componente, artículo o tema en particular. Se debe incluir una breve interpretación de lo que podría ocurrir. Esta opción permite acotar la preocupación relacionada con el peligro. Ejemplos: Si el componente es “aislador tipo alfiler para línea de media tensión” una preocupación puede ser “Que durante la ejecución las actividades de cambio de aislador en línea desenergizada, se pueda llegar a energizar el punto de trabajo  ya sea por media tensión, baja tensión, inducción de componentes adyacentes o descargas atmosféricas”.")]
            PreocupacionComponente = 18,
            [Description("Es la explicación sobre las pérdidas específicas que podrían ocurrir. Pueden resultar varios impactos de una preocupación, tales como lesiones, daños, incendios, explosiones, catástrofes. Ejemplos: Contacto eléctrico directo que puede ocasionar la muerte, incapacidad permanente, incapacidad temporal, quemaduras por radiación de calor, efectos del relámpago de arco, traumatismos por caída de diferente nivel.")]
            Impacto = 19,
            [Description("Es la explicación sobre la forma en que fue establecida la probabilidad o la razón por la que fue asumida como se indica. Se basa en los datos estadísticos disponibles y comparaciones referenciales. Ejemplos: Los contactos con electricidad al realizar actividades de mantenimiento programadas para ejecutarse con línea desenergizada, han ocurrido más de una vez al año en el ámbito nacional de la EPS (especificar) en los últimos 5 años.")]
            Probabilidad = 20,
            [Description("Son los planes o estrategias para reducir el riesgo hasta un nivel aceptable. Cuando se identifican riesgos medios o altos, es necesario establecer controles para minimizar o eliminar la preocupación.")]
            Control = 21,
            [Description("Es importante que todas las acciones para controlar los riesgos sean asignadas a individuos específicos, por ejemplo, ¿quién hará que? y ¿cuándo?")]
            Responsable = 22,
            [Description("Indicar con claridad el momento preciso en que deben aplicarse los controles, esta etapa más que a una fecha específica, se refiere al momento justo en que se deben realizar las acciones para controlar los riesgos ya sea en la secuencia de un procedimiento o bien durante la ejecución de una maniobra. Ejemplos: Contar con licencia autorizada para ingresar al foso del generador, verificar ausencia de potencial, instalar sistema de puesta a tierra en la red de media tensión lo más cerca posible del lugar de trabajo y en ambas partes del mismo.")]
            CuandoAplicaControl = 23,
            [Description("Es la explicación sobre las pérdidas específicas que podrían ocurrir considerando que los controles establecidos ya han sido aplicados de manera efectiva.")]
            ImpactoControles = 24,
            [Description("Es la explicación sobre la forma en que fue establecida la probabilidad considerando que los controles establecidos ya han sido aplicados de manera efectiva, se basa en los datos estadísticos disponibles y comparaciones referenciales.")]
            ProbabilidadControles = 25,

            //Tareas Criticas
            [Description("Se especifica el centro de trabajo y área correspondiente")]
            CentroTrabajo = 26,
            [Description("Se especifica el departamento correspondiente")]
            Departamento = 27,
            [Description("Se indica la categoría del trabajador para la identificación (Si la identificación es para infraestrcutra, este espacio se deja en blanco.)")]
            Categoria = 28,
            [Description("Se indica el nombre y firma del personal de supervisión y trabajadores de la categoría que participa en la identificación de peligros")]
            Elaborador = 29,
            [Description("Se indica el nombre y firma del responsable de SST del centro de trabajo")]
            Trabajador = 30,
            [Description("Se indica el nombre y firma del jefe del área o en su caso del jefe del centro de trabajo")]
            Aprobador = 31,
          




    }

    /// <summary>
    /// Identificadores de los modulos de IP,EGR y TC...(usados en reportes)
    /// </summary>
    public enum enumIdentificadoresGestion
    {
        [Description("P-1020-007-R02")]
        IP = 100,
        [Description("P-1020-007-R05")]
        EGR = 101,
        [Description("P-1020-007-R-03")]
        TC = 102,
        [Description("P-1020-006-R-01")]
        RL = 103,
        [Description("P-1020-010-R-03")]
        Simulacros = 104,

    }



}
