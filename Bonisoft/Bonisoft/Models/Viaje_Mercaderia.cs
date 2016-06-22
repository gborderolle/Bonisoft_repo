using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bonisoft.Models
{
    public class Viaje_Mercaderia
    {
        [Key]
        public int Viaje_ID{ get; set; }
        public int Mercaderia_ID { get; set; }
    }
}