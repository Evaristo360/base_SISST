using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SISST.Reuniones.Data;
using SISST.Reuniones.DataDto;
using SISST.Reuniones.DataDto.DTOsModels;
using SISST.Reuniones.Helpers.Exceptions;
using SISST.Reuniones.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Reuniones.Services
{
    public interface IDocumentosService
    {
        Task<ReunionesCollection<DocumentoDto>> GetAllAsync(int page, int take, IEnumerable<int> documento = null);
        Task<DocumentoDto> GetAsync(int id);

        Task<DocumentoCreate> DocumentoCreateAsync(DocumentoCreate documentoCreate, [FromForm] List<IFormFile> files);
    }
    public class DocumentosService: IDocumentosService
    {
        private readonly ApplicationDbContext _context;
        public DocumentosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ReunionesCollection<DocumentoDto>> GetAllAsync(int page, int take, IEnumerable<int> documento = null)
        {
            var coleccion = await _context.TDocumentos
                .Where(m => documento == null || documento.Contains(m.DocumentoId))
                .OrderByDescending(m => m.DocumentoId)
                .GetPagedAsync(page, take);

            return coleccion.MapTo<ReunionesCollection<DocumentoDto>>();
        }

        //metodo para que se aplique de uno solo
        public async Task<DocumentoDto> GetAsync(int id)
        {
            return (await _context.TDocumentos.SingleAsync(m => m.DocumentoId == id)).MapTo<DocumentoDto>();
        }

        //metodo post
        public async Task<DocumentoCreate> DocumentoCreateAsync(DocumentoCreate documentoCreate, [FromForm] List<IFormFile> files)
        {

            List<Documento> documento = new List<Documento>();
            { 

            if (files.Count > 0)
            {
                foreach (var file in files)
                {
                    var filepath = "D:\\INEEL\\PruebaArchivos\\" + file.FileName;//ruta del archivo
                                                                                 //guardamos en el carpeta
                    using (var stream = System.IO.File.Create(filepath))
                    {
                        await file.CopyToAsync(stream);
                    }
                    //guardamos los datos en base de datos
                    Documento doc = new Documento();
                    doc.Nombre = Path.GetFileNameWithoutExtension(file.FileName);
                    doc.Ruta = filepath;
                    documento.Add(doc);
                }
            };
            await _context.AddAsync(documento);
                await _context.SaveChangesAsync();
                // EN PROCESO: Si regreso el mismo de nada sirve, debo regresar el recien registrado, 
                // que ya tiene ID
                return documentoCreate;

                //await _context.AddAsync(reu);
                //await _context.SaveChangesAsync();
                //// EN PROCESO: Si regreso el mismo de nada sirve, debo regresar el recien registrado, 
                //// que ya tiene ID
                //return reunionDto;
            }
        }


        //metoodo updfate

    }
}
