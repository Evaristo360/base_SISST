using Microsoft.AspNetCore.Mvc.Rendering;
using SISST.ViewModels.Comunes.Areas;
using SISST.ViewModels.Comunes.Catalogos;
using SISST.ViewModels.Comunes.Departamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Extensions
{
    public static class ListOpcionesExtensions
    {
        public static List<SelectListItem> ToSelectionList(this IEnumerable<VMOpcionSelect> lista, int defaultValueSelected = 0, bool todos = false, bool textSameAsValue = false)
        {
            var result = new List<SelectListItem>();

            if (todos)
                result.Add(new SelectListItem("Todos", "0"));

            foreach (var l in lista)
            {
                var selected = lista.Any(x => x.IdCatalogo == defaultValueSelected);
                if (!textSameAsValue)
                    result.Add(new SelectListItem(l.Nombre, l.IdCatalogo.ToString(), selected));
                else
                    result.Add(new SelectListItem(l.Nombre, l.Nombre, selected));
            }
            return result;
        }
        public static List<SelectListItem> ToSelectionList(this IEnumerable<VMOpcion> lista, int defaultValueSelected = 0, bool todos = false, bool textSameAsValue = false)
        {
            var result = new List<SelectListItem>();

            if (todos)
                result.Add(new SelectListItem("Todos", "0"));

            foreach (var l in lista)
            {
                var selected = lista.Any(x => x.IdCatalogo == defaultValueSelected);
                if (!textSameAsValue)
                    result.Add(new SelectListItem(l.Nombre, l.IdCatalogo.ToString(), selected));
                else
                    result.Add(new SelectListItem(l.Nombre, l.Nombre, selected));
            }
            return result;
        }
        public static List<SelectListItem> ToSelectionList(this IEnumerable<VMAreaDetalle> lista, int defaultValueSelected = 0, bool todos = false, bool textSameAsValue = false)
        {
            var result = new List<SelectListItem>();

            if (todos)
                result.Add(new SelectListItem("Todos", "0"));

            foreach (var l in lista)
            {
                var selected = lista.Any(x => x.Id == defaultValueSelected);
                if (!textSameAsValue)
                    result.Add( new SelectListItem(l.Nombre, l.Id.ToString(), selected) );
                else
                    result.Add( new SelectListItem(l.Nombre, l.Nombre, selected) );

            }
            return result;
        }
        public static List<SelectListItem> ToSelectionList(this IEnumerable<VMDepartamento> lista, int defaultValueSelected = 0, bool todos = false, bool claveSameAsValue = false, bool claveInName = false)
        {
            var result = new List<SelectListItem>();

            if (todos)
                result.Add(new SelectListItem("Todos", "0"));

            foreach (var l in lista)
            {
                var selected = lista.Any(x => x.Id == defaultValueSelected);
                if (!claveSameAsValue && claveInName)
                    result.Add(new SelectListItem($"{l.Clave} {l.Descripcion}", l.Id.ToString(), selected));
                if (claveSameAsValue && claveInName)
                    result.Add(new SelectListItem($"{l.Clave} {l.Descripcion}", l.Clave, selected));
                
                if (claveSameAsValue && !claveInName)
                    result.Add(new SelectListItem($"{l.Descripcion}", l.Clave, selected));
                else // !claveSameAsValue && !claveInName
                    result.Add(new SelectListItem($"{l.Descripcion}", l.Id.ToString(), selected));
            }
            return result;
        }

        public static List<SelectListItem> ToSelectionList(this IEnumerable<VMOpcionSelect> lista, string valorSelected)
        {
            var result = new List<SelectListItem>();

            foreach (var l in lista)
            {                
                if (l.Nombre.Equals(valorSelected))
                    result.Add(new SelectListItem(l.Nombre, l.IdCatalogo.ToString(), true));
                else
                    result.Add(new SelectListItem(l.Nombre, l.IdCatalogo.ToString(), false));
            }
            return result;
        }

        public static List<SelectListItem> ToSelectionList(this IEnumerable<VMOpcion> lista, string valorSelected)
        {
            var result = new List<SelectListItem>();

            foreach (var l in lista)
            {
                if (l.Nombre.Equals(valorSelected))
                    result.Add(new SelectListItem(l.Nombre, l.IdCatalogo.ToString(), true));
                else
                    result.Add(new SelectListItem(l.Nombre, l.IdCatalogo.ToString(), false));
            }
            return result;
        }

        public static List<SelectListItem> ToSelectionList(this IEnumerable<VMOpcionSelect> lista, List<int> valores)
        {
            var result = new List<SelectListItem>();
            foreach (var l in lista)
            {
                var selected = lista.Any(x => valores.Contains(x.IdCatalogo));               
                result.Add(new SelectListItem(l.Nombre, l.IdCatalogo.ToString(), selected));               
            }
            return result;
        }
    }
}
