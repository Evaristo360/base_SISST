using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SISST.Autenticacion.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SISST.Autenticacion.Models
{
    public class ApplicationDbContextFactory : DesignTimeDbContextFactoryBase<ApplicationDbContext>
    {
        protected override ApplicationDbContext CreateNewInstance(DbContextOptions<ApplicationDbContext> options)
        {
            return new ApplicationDbContext(options);
        }
    }
}


