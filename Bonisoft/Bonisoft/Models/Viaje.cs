using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Bonisoft.Models
{
    public class Viaje
    {
        [Key]
        public int Viaje_ID { get; set; }
        public int Forma_de_pago_ID { get; set; }
        public int Carga_ID { get; set; }
        public int Descarga_ID { get; set; }
        public int Pesada_origen_ID { get; set; }
        public int Pesada_destino_ID { get; set; }
        public int Empresa_de_carga_ID { get; set; }
        public int Camion_ID { get; set; }
        public int Chofer_ID { get; set; }
        public decimal Precio_compra_por_tonelada{ get; set; }
        public decimal Precio_valor_total { get; set; }
        public decimal Importe_viaje { get; set; }
        public decimal Saldo { get; set; }
        public DateTime Fecha_partida{ get; set; }
        public DateTime Fecha_llegada{ get; set; }
        public string Comentarios { get; set; }
    }
}