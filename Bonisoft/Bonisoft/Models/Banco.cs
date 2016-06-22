using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Bonisoft.Models
{
    public class Banco
    {
        [Key]
        public int Banco_ID { get; set; }
        public string Nombre { get; set; }
        public string Cuenta { get; set; }
        public string Comentarios { get; set; }
    }
}