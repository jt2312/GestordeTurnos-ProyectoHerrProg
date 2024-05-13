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
            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            modelBuilder.Entity<Citacion>()
                .HasOne(x => x.Doctor)
                .WithMany(c => c.Citas)
                .HasForeignKey(x => x.DoctorId);

            modelBuilder.Entity<Citacion>()
                .HasOne(a => a.Paciente)
                .WithMany(c => c.Citas)
                .HasForeignKey(a => a.PacienteId);

            modelBuilder.Entity<Consultorio>()
                .HasMany(d=> d.Doctores)
                .WithOne(p=> p.Consultorio_)
                .HasForeignKey(p => p.ConsultorioId)
                .OnDelete(DeleteBehavior.Cascade);
            
            base.OnModelCreating(modelBuilder);
        }

    }
}
