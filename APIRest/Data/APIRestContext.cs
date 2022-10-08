using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIRest.Models;

namespace APIRest.Data
{
    public class APIRestContext : DbContext
    {
        public APIRestContext (DbContextOptions<APIRestContext> options)
            : base(options)
        {
        }

        public DbSet<APIRest.Models.Persona> Persona { get; set; } = default!;
        public DbSet<APIRest.Models.Equipo> Equipo { get; set; } = default;
    }
}
