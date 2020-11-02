using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FacturacionElectronica.Modelos
{
    public class Cierre
    {
        [Key]
        public int Numero { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage ="Este dato es obligatorio")]
        public double Monto { get; set; }
    }
}
