using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bonisoft_1.Models
{
    public class _Persona
    {
        public int Persona_ID { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public System.DateTime Fecha_nacimiento { get; set; }
        public string CI { get; set; }
        public string Contacto_medio_1_ID { get; set; }
        public string Contacto_medio_2_ID { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public string Comentarios { get; set; }
    }
}