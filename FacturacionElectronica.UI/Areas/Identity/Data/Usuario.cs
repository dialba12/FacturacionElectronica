using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FacturacionElectronica.UI.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the Usuario class
    public class Usuario : IdentityUser
    {
        [PersonalData]
        public string Nombre { get; set; }
        [PersonalData]
        public string PrimerApellido { get; set; }
        [PersonalData]
        public string SegundoApellido { get; set; }
    }
}
