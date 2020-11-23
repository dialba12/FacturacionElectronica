using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FacturacionElectronica.Modelos;
using Microsoft.AspNetCore.Identity;

namespace FacturacionElectronica.UI.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the Usuario class
    public class Usuario : IdentityUser
    {
        [Required(ErrorMessage = "Ingrese un nombre")]
        [RegularExpression(@"^\w+$", ErrorMessage = "No se permiten espacios en blanco")]
        [Display(Name = "Nombre:")]
       
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Ingrese su primer apellido")]
        [RegularExpression(@"^\w+$", ErrorMessage = "No se permiten espacios en blanco")]
        [Display(Name = "Primer Apellido:")]
      
        public string PrimerApellido { get; set; }
        [Required(ErrorMessage = "Ingrese su segundo apellido")]
        [RegularExpression(@"^\w+$", ErrorMessage = "No se permiten espacios en blanco")]
        [Display(Name = "Segundo Apellido:")]
     
        public string SegundoApellido { get; set; }
        
        [Display(Name = "Identificacion:")]

        public int Identificacion { get; set; }
        [Display(Name = "Tipo de Identificacion:")]
        public TipoDeIdentificacion TipoDeIdentificacion { get; set; }
        
        [Display(Name = "Provincia:")]
        public string Provincia { get; set; }
       
        [Display(Name = "Canton:")]
        public string Canton { get; set; }
        
        [Display(Name = "Distrito:")]
        public string Distrito { get; set; }
       
        [Display(Name = "Otras Señas:")]
        public string OtrasSenas { get; set; }
    }
}
