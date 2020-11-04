using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FacturacionElectronica.Modelos
{
    public class Cierre
    {
        [Key]
        public int idCierre { get; set; }
        public string IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage ="Este dato es obligatorio")]
        public double Monto { get; set; }
    }
}
