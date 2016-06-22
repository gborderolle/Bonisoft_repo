using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bonisoft.Models
{
    public class Lena_tipo
    {
        [Key]
        public int Lena_tipo_ID { get; set; }
        public string Tipo { get; set; }
        public string Comentarios { get; set; }
    }
}