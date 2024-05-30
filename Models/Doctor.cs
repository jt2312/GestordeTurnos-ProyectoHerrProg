using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerramientasProgFinal.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }        
        public string Especialidad { get; set; }         
        public int? ConsultorioId { get; set; }
        public virtual Consultorio? Consultorio_ { get; set; }
        public virtual ICollection<Citacion> Citas { get; set; }


    }
}