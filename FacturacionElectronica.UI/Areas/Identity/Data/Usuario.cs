using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FacturacionElectronica.UI.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the Usuario class
    public class Usuario : IdentityUser
    {
        [Required(ErrorMessage = "Ingrese un Nombre")]
        [RegularExpression(@"^\w+$", ErrorMessage = "No se permiten espacios en blanco")]
        [Display(Name = "Nombre")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Ingrese su primer apellido")]
        [RegularExpression(@"^\w+$", ErrorMessage = "No se permiten espacios en blanco")]
        [Display(Name = "PrimerApellido")]
        [DataType(DataType.Text)]
        public string PrimerApellido { get; set; }
        [Required(ErrorMessage = "Ingrese su segundo apellido")]
        [RegularExpression(@"^\w+$", ErrorMessage = "No se permiten espacios en blanco")]
        [Display(Name = "SegundoApellido")]
        [DataType(DataType.Text)]
        public string SegundoApellido { get; set; }
    }
}
