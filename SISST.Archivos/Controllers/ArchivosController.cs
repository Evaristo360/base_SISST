using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SISST.Archivos.Context;
using SISST.Archivos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Archivos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArchivosController : ControllerBase
    {
        public readonly AppDbContext context;
        public  ArchivosController(AppDbContext context)
        {
            this.context = context;
        }

    //peticion get
    [HttpGet]
    public ActionResult Get()
        {
            try
            {
                return Ok(context.ReunionesDocumentos.ToList());
            } catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    //peticion post
    [HttpPost]
        public ActionResult PostArchivos(Archivo arch,[FromForm] List<IFormFile> files)
        {
           

            List<Archivo> archivos = new List<Archivo>();
            try
            {
                if (files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        var filepath = "D:\\INEEL\\PruebaArchivos\\" + file.FileName;//ruta del archivo
                       //guardamos en el carpeta
                       using (var stream = System.IO.File.Create(filepath))
                        {
                            file.CopyToAsync(stream);
                        }
                        
                        //guardamos los datos en base de datos
                        Archivo archivo = new Archivo();
                       
                        archivo.nombre = Path.GetFileNameWithoutExtension(file.FileName);
                        archivo.ubicacion = filepath;
                        archivo.reunionforanea = archivo.reunionforanea;
                        archivos.Add(archivo);
                      
                    }

                 
                    //guardar eb bvase con entityframewor
                    context.ReunionesDocumentos.AddRange(archivos);
                    context.SaveChanges();
                }


            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(archivos);
        }

       

    }
}
