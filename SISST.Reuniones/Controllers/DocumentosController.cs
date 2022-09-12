using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SISST.Reuniones.DataDto;
using SISST.Reuniones.DataDto.DTOsModels;
using SISST.Reuniones.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Reuniones.Controllers
{
    [ApiController]
    [Route("api/documentos")]
    public class DocumentosController : ControllerBase
    {
        private readonly ILogger<ReunionController> _logger;
        private readonly IDocumentosService _documentosService;

        public DocumentosController(ILogger<ReunionController> logger,
            IDocumentosService documentosService
            )
        {
            _logger = logger;
            _documentosService = documentosService;

        }

        [HttpGet]
        public async Task<ReunionesCollection<DocumentoDto>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            // se convierte el listado a enteros
            IEnumerable<int> reuniones = null;
            if (!string.IsNullOrEmpty(ids))
            {
                reuniones = ids.Split(',').Select(m => Convert.ToInt32(m));
            }
            return await _documentosService.GetAllAsync(page, take, reuniones);
        }

        //solo para traer uno/.
        [HttpGet("{id}")]
        public async Task<DocumentoDto> Get(int id)
        {
            return await _documentosService.GetAsync(id);
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<DocumentoCreate>> DocumentoCreate(DocumentoCreate documentoCreate, [FromForm] List<IFormFile> files)
        {
            return await _documentosService.DocumentoCreateAsync(documentoCreate,files);
        }

    }
}
