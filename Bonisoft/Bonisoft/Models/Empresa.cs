using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bonisoft.Models
{
    public class Empresa
    {
        [Key]
        public int Empresa_ID { get; set; }
        public int Contacto_medio_1_ID { get; set; }
        public int Contacto_medio_2_ID { get; set; }
        public int Contacto_persona_1_ID { get; set; }
        public int Contacto_persona_2_ID { get; set; }
        public int Banco_ID { get; set; }
        public string Nombre_fantasia { get; set; }
        public string Nombre_real{ get; set; }
        public string RUT{ get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public string Comentarios { get; set; }
    }
}