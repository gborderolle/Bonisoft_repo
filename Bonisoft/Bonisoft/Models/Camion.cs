using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bonisoft.Models
{
    public class Camion
    {
        [Key]
        public int Camion_ID { get; set; }
        public string Matricula_camion { get; set; }
        public string Matricula_zorra { get; set; }
        public int Numero_ejes { get; set; }
        public decimal Peso_Tara_origen { get; set; }
        public decimal Peso_Tara_destino { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal Peso_Neto { get; set; }
        public string Comentarios { get; set; }
    }
}