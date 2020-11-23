using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FacturacionElectronica.Modelos
{
    public class Cierre
    {
        [Key]
        [Display(Name = "Código:")]
        public int idCierre { get; set; }
        [Display(Name = "Id de Usuario:")]
        public string IdUsuario { get; set; }
        [Display(Name = "Fecha:")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage ="Este dato es obligatorio")]
        [Display(Name = "Monto:")]
        public double Monto { get; set; }
    }
}
