using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bonisoft.Models
{
    public class Persona
    {
        [Key]
        public int PersonaID { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public string CI { get; set; }
        public int Contacto_medio_1_ID { get; set; }
        public int Contacto_medio_2_ID { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public string Comentarios { get; set; }

    }
}