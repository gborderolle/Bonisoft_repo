using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bonisoft.Models
{
    public class Contacto_medio
    {
        [Key]
        public int Contacto_medio_ID { get; set; }
        public string Direccion { get; set; }
        public string Telefono_1{ get; set; }
        public string Telefono_2 { get; set; }
        public string Telefono_interno { get; set; }
        public string Email { get; set; }
        public string Comentarios { get; set; }
    }
}