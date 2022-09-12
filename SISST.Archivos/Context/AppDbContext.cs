using Microsoft.EntityFrameworkCore;
using SISST.Archivos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Archivos.Context
{
    public class AppDbContext : DbContext
    {
        //se establece la tabla de la base de datos 
        //constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //Hacemos referencia a la tabla que se ocupara (archivos) y el modelo que tenemos (Archivo) 
        public DbSet<Archivo> ReunionesDocumentos { get; set; }


    }
}
