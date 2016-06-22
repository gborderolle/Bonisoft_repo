using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bonisoft.Models
{
    public class Carga_descarga
    {
        [Key]
        public int Carga_descarga_ID { get; set; }
        public string Lugar { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentarios { get; set; }
    }
}