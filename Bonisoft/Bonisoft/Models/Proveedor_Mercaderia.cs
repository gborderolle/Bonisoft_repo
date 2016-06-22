using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Bonisoft.Models
{
    public class Proveedor_Mercaderia
    {
        [Key]
        public int Proveedor_ID { get; set; }
        public int Mercaderia_ID { get; set; }
    }
}