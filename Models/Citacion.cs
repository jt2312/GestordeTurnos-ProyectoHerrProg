using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerramientasProgFinal.Models
{
    public class Citacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        
        public int PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }        
    }
}