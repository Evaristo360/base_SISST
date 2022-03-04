using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Comunes.Extensions
{
    public static class StringExtensions
    {
        public static string ToJson<T>(this T instance) => JsonConvert.SerializeObject(instance, Formatting.Indented);

        /// <summary>
        /// Convierte solo el primer caracter del texto a mayúscula.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <remarks>PRME</remarks>
        public static string FirtsLetterUpper(this string text)
        {
            return text.Substring(0, 1).ToUpper() + text.Substring(1);
        }

        /// <summary>
        /// Se quitan los acentos para efectos de búsqueda en las consultas ejecutivas
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <remarks>FEG/PRME</remarks>
        public static string RemoveAccents(this string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }
        
    }

    public static class EnumerableExtensions
    {
        //https://www.javaer101.com/en/article/15976436.html
        public static IEnumerable<T> SelectRecursive<T>(this IEnumerable<T> source, 
                                                        Func<T, IEnumerable<T>> selector)
        {
            foreach (var parent in source)
            {                           
                yield return parent;

                var children = selector(parent);
                foreach (var child in SelectRecursive(children, selector))
                    yield return child;
            }
        }

        public static IEnumerable<T> SelectRecursive<T>(this IEnumerable<T> source,
                                                       Func<T, IEnumerable<T>> selector, int Nivel)
        {
            foreach (var parent in source)
            {       
                yield return parent;

                var children = selector(parent);
                foreach (var child in SelectRecursive(children, selector, Nivel++))
                    yield return child;
            }
        }
    }

    /// <summary>
    /// 
    /// https://ole.michelsen.dk/blog/grouping-data-with-linq-and-mvc/
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="T"></typeparam>
    //public class Group<K, T>
    //{
    //    public K Key;
    //    public IEnumerable<T> Values;
    //}
}
