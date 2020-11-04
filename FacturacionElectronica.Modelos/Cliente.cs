using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FacturacionElectronica.Modelos
{
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }

        [Required(ErrorMessage ="Este dato es obligatorio")]
        [Display(Name ="Identificación")]
        public int Identificacion { get; set; }

        [Required(ErrorMessage = "Este dato es obligatorio")]
        [Display(Name = "Tipo de identificación")]
        public TipoDeIdentificacion TipoIdentificacion { get; set; }

        [Required(ErrorMessage = "Este dato es obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Segundo Nombre")]
        public string? SegundoNombre { get; set; }

        [Required(ErrorMessage = "Este dato es obligatorio")]
        [Display(Name ="Primer Apellido")]
        public string PrimerApellido { get; set; }
        [Required(ErrorMessage = "Este dato es obligatorio")]
        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }
        [Required(ErrorMessage = "Este dato es obligatorio.")]
        [Display(Name = "Correo Electrónico")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Este dato es obligatorio")]
        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }
        [Required(ErrorMessage = "Este dato es obligatorio")]
        public string Provincia { get; set; }
        [Required(ErrorMessage = "Este dato es obligatorio")]
        [Display(Name = "Cantón")]
        public string Canton { get; set; }
        [Required(ErrorMessage = "Este dato es obligatorio")]
        [Display(Name = "Distrito")]
        public string Distrito { get; set; }
        [Required(ErrorMessage = "Este dato es obligatorio")]
        [Display(Name = "Barrio")]
        public string Barrio { get; set; }
        [Required(ErrorMessage = "Este dato es obligatorio")]
        [Display(Name = "Otras Señas")]
        public string OtrasSenas { get; set; }

    }
}
