using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Bonisoft.Models
{
    public class Proveedor_Carga
    {
        [Key]
        public int Proveedor_ID { get; set; }
        public int Carga_ID { get; set; }
    }
}