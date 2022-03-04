using Comunes.DTOs;
using Comunes.Enumerables;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace SISST.Comunes.Funciones
{
    public static class FuncionesCompartidas
    {

        /*
            Riesgo potencial	Impacto	Probabilidad
            Alto	        =	Alto	Alto
            Alto        	=	Alto	Medio
            Alto        	=	Medio	Alto
            Medio       	=	Alto	Bajo
            Medio       	=	Medio	Bajo
            Medio	        =	Medio	Medio
            Medio	        =	Bajo	Alto
            Bajo        	=	Bajo	Bajo
            Bajo	        =  	Bajo	Medio
         */
        /// <summary>
        /// Calcula el nivel de riesgo con base a la tabla superior
        /// </summary>
        /// <param name="impacto"></param>
        /// <param name="probabilidad"></param>
        /// <returns></returns>
        public static string NivelDeRiesgo(string impacto, string probabilidad)
        {
            if (impacto == "Alto" && probabilidad == "Alto")
                return "Alto";
            else if (impacto == "Alto" && probabilidad == "Medio")
                return "Alto";
            else if (impacto == "Medio" && probabilidad == "Alto")
                return "Alto";
            else if (impacto == "Alto" && probabilidad == "Bajo")
                return "Medio";
            else if (impacto == "Medio" && probabilidad == "Bajo")
                return "Medio";
            else if (impacto == "Medio" && probabilidad == "Medio")
                return "Medio";
            else if (impacto == "Bajo" && probabilidad == "Alto")
                return "Medio";
            else if (impacto == "Bajo" && probabilidad == "Bajo")
                return "Bajo";
            else if (impacto == "Bajo" && probabilidad == "Medio")
                return "Bajo";
            else return "";
        }

        #region ->      Relativo a los enum con StringValue         <--

        public static string GetEnumDescription(Enum e)
        {
            FieldInfo fieldInfo = e.GetType().GetField(e.ToString());

            DescriptionAttribute[] enumAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (enumAttributes.Length > 0)
            {
                return enumAttributes[0].Description;
            }
            return e.ToString();
        }

        #endregion

        /// <summary>
        /// Obtiene el nombre de la opción de un catálogo.
        /// en función de su identificador
        /// </summary>
        /// <param name="opciones">Lista de opciones del catálogo</param>
        /// <param name="idOpcion">Identificador de la opción, de la cual se requiere el nombre</param>
        /// <returns>Nombre de la opción de catálogo</returns>
        public static string LeyendaOpcion(List<OpcionesDTO> opciones, int idOpcion)
        {
            OpcionesDTO opcion = opciones.Find(x => x.IdCatalogo.Equals(idOpcion));
            return (opcion == null) ? "" : opcion.Nombre;
        }

        public static string LimpiaCadena(string cadena)
        {
            return cadena.Replace("á", "a").Replace("à", "a")
                .Replace("â", "a")
                .Replace("ä", "a")
                .Replace("ç", "c")
                .Replace("é", "e")
                .Replace("è", "e")
                .Replace("ê", "e")
                .Replace("ë", "e")
                .Replace("í", "i")
                .Replace("ì", "i")
                .Replace("î", "i")
                .Replace("ï", "i")
                .Replace("ó", "o")
                .Replace("ò", "o")
                .Replace("ö", "o")
                .Replace("ô", "o")
                .Replace("ú", "u")
                .Replace("ù", "u")
                .Replace("û", "u")
                .Replace("ü", "u").Replace("Á", "A").Replace("À", "A")
                .Replace("Â", "A")
                .Replace("Ä", "A")
                .Replace("Ç", "C")
                .Replace("É", "E")
                .Replace("È", "E")
                .Replace("Ê", "E")
                .Replace("Ë", "E")
                .Replace("Í", "I")
                .Replace("Ì", "I")
                .Replace("Î", "I")
                .Replace("Ï", "I")
                .Replace("Ó", "O")
                .Replace("Ò", "O")
                .Replace("Ö", "O")
                .Replace("Ô", "O")
                .Replace("Ú", "U")
                .Replace("Ù", "U")
                .Replace("Û", "U")
                .Replace("Ü", "U"); ;

        }


        /// <summary>
        /// Usada en PCI para convertir cadenas al formato XXX
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //https://www.codegrepper.com/code-examples/csharp/how+to+generate+md5+hash+c%23
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }


        /// <summary>
        /// Genera lista de meses a partir del enumMeses.
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Dearrollado por 
        ///     Juan Miguel González Castro
        ///     Diciembre 2021
        ///     
        /// 20220216 PRME
        ///     Se incluyó como función compartida, para uso general.
        ///     Se debe sustituir las que existen en el front o las APIs 
        /// </remarks>
        public static List<SelectListItem> ObtenerListaMeses()
        {
            List<SelectListItem> listaMeses = new List<SelectListItem>();

            foreach (enumMeses mes in (enumMeses[])Enum.GetValues(typeof(enumMeses)))
                listaMeses.Add(new SelectListItem() { Text = mes.ToString(), Value = ((int)mes).ToString() });

            return listaMeses;
        }
        //https://revistadigital.inesem.es/informatica-y-tics/seguridad-en-c-encriptar-y-desencriptar-datos/
        /// Encripta una cadena
        public static string Encriptar(this string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string DesEncriptar(this string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            if (StringIsBase64(_cadenaAdesencriptar))
            {
                byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
                //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
                result = System.Text.Encoding.Unicode.GetString(decryted);
                return result;
            }
            else
            {
                return result;
            }

        }

        public static bool StringIsBase64(string myString)
        {
            Span<byte> buffer = new Span<byte>(new byte[myString.Length]);
            return Convert.TryFromBase64String(myString, buffer, out int bytesParsed);
        }

        /// <summary>
        /// Función que obtiene el número de evaluaciones mínimas requeridas 
        /// en función del número de programas vigentes para el módulo de 
        /// Medición y Vigilancia
        /// </summary>
        /// <param name="programasVigentes"></param>
        /// <returns>
        /// 20220218 PRME
        /// 
        /// Se incluyó en esta sección por ser la única en la que se tienen
        /// funciones estáticas, y considerando que si se hace una modificación 
        /// solo tiene que actualizarce este proyecto
        /// </returns>
        public static int NumeroMinimoEvaluaciones(int programasVigentes)
        {
            int minimo = 1;
            // item1 Programas vigentes, Item2 evaluaciones requeridas
            List<Tuple<int, int>> ProgramasvsRequeridas= new List<Tuple<int, int>> 
            {
                Tuple.Create(1,1),
                Tuple.Create(2,2),
                Tuple.Create(3,2),
                Tuple.Create(4,3),
                Tuple.Create(5,3),
                Tuple.Create(6,4),
                Tuple.Create(7,4),
                Tuple.Create(8,4),
                Tuple.Create(9,4),
                Tuple.Create(10,5),
                Tuple.Create(11,5),
                Tuple.Create(12,5),
                Tuple.Create(13,5),
                Tuple.Create(14,5),
                Tuple.Create(15,5),
                Tuple.Create(16,5),
                Tuple.Create(17,5),
                Tuple.Create(18,6),
            };

            minimo = ProgramasvsRequeridas.Find(x => x.Item1.Equals(programasVigentes)).Item2;

            return minimo;
        }
    }
}
