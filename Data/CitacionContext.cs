using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HerramientasProgFinal.Models;

namespace HerramientasProgFinal.Data
{
    public class CitacionContext : DbContext
    {
        public CitacionContext (DbContextOptions<CitacionContext> options)
            : base(options)
        {
        }

        public DbSet<HerramientasProgFinal.Models.Citacion> Citacion { get; set; } = default!;
        public DbSet<HerramientasProgFinal.Models.Doctor> Doctor { get; set; } = default!;
        public DbSet<HerramientasProgFinal.Models.Consultorio> Consultorio { get; set; } = default!;
        public DbSet<HerramientasProgFinal.Models.Paciente> Paciente { get; set; } = default!;
    }
}
