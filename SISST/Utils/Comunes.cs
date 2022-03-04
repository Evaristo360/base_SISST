
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;


namespace SISST.Utils
{
    public class Comunes
    {
        /***********************************************************************Titulos**************************************************************************************/
        public static String tituloSistema = "SISSTv2";
        public static String tituloRegistrar = "Nueva";
        public static String tituloModificar = "Actualización de";
        public static String tituloConsultar = "Consulta de";
        public static String tituloLista = "Lista de";
        public static String tituloDatos = "Datos de";

        /***********************************************************************Mensajes**************************************************************************************/
        public static String mensajeGuardado = "El registro se guardó con éxito...";
        public static String mensajeEliminado = "El registro se eliminó con éxito...";
        public static String mensajeModificado = "El registro se modificó con éxito...";
        public static String mensajeMetodoAANoEncontrado = "El método de acción automática especificado no existe en el sistema";
        public static String mensajeNoEncontrado = "El elemento no se encuentra registrado en el sistema...";
        public static String mensajeNulo = "El elemento requiere de un id...";
        
        public static String mensajeEliminar = "¿Esta seguro que desea 'Eliminar' el registro?";
        public static String mensajeNoAutorizado = "No cuentas con los permisos necesarios para eliminar este tipo de registros";
        public static String mensajeNoEliminado = "El registro no se eliminó";
        public static String mensajeSinRegistros = "No seleccionó registro";
        public static String mensajeNoDesarchivado = "El registro no se desarchivó";

        /***********************************************************************Botones**************************************************************************************/
        public static String botonRegresar = "Regresar a";
        public static String botonRegistrar = "Nueva";
        public static String botonRegistrarNuevo = "Nuevo";

        
    }

	//public enum enumCatalogos : int
	//{
	//	ActoSubestandar = 1, // Acto subestándar
	//	AreasdeAcionCorrectiva = 2, // Áreas de acción correctiva
	//	CategoriadelAccidentado = 3, // Categoría del accidentado
	//	CondiciondelProceso = 4, // Condición del proceso
	//	Condicinnsubestandar = 5, // Condición subestándar
	//	Contrato = 6, // Contrato

 //       Costosfinancieros = 7, // Costos financieros
 //       Criteriodelesiondealtoimpacto = 8, // Criterio de lesión de alto impacto
 //       Danio = 9, // Daño
 //       Modulos = 10, // Módulos: opciones del menu de primer nivel
 //       Subtipodeinstalación = 11, // Subtipo de instalación
 //       Tipodeinstalación = 12, // Tipo de instalación
 //       Entidadesfederativas = 13, // Entidades federativas
 //       Escolaridadterminada = 14, // Escolaridad terminada
 //       Factordetrabajo = 15, // Factor de trabajo
 //       Factorpersonal = 16, // Factor personal
 //       Formulas = 17, // Fórmulas
 //       Impactopotencial = 18, // Impacto potencial
 //       ISO45001 = 19, // ISO 45001
 //       Magnitudpotencial = 20, // Magnitud potencial
 //       Municipios = 21, // Municipios
 //       Naturalezadelpuesto = 22, // Naturaleza del puesto
 //       Niveldeexposicion = 23, // Nivel de exposición
 //       Partedelcuerpoafectada = 24, // Parte del cuerpo afectada
 //       Probabilidadpotencial = 25, // Probabilidad potencial
 //       Procesos = 26, // Procesos
 //       Ramaactividad = 27, // Rama actividad
 //       Sitiodelaccidente = 28, // Sitio del accidente
 //       Situaciónlaboral = 29, // Situación laboral
 //       Tipodeaccidente = 30, // Tipo de accidente
 //       Tipodeincapacidad = 31, // Tipo de incapacidad
 //       Tipodelesion = 32, // Tipo de lesión
 //       Tipodenecesidad = 33, // Tipo de necesidad
 //       Riesgopotencial = 34, // Riesgo potencial
 //       ModulosPortal = 35,
	//	AreasPortal = 36,


        //ModulosPortal = 35,
		//AreasPortal = 36,



        //ModulosPortal = 799,
		//AreasPortal = 798,
        //NivelJerarquico = 783,


 //       Niveljerarquico= 37,


 //   }

}
