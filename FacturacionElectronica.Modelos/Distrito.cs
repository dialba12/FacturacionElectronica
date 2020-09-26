using System;
using System.Collections.Generic;
using System.Text;

namespace FacturacionElectronica.Modelos
{
    public class Distrito
    {
        public int Id_Distrito { get; set; }
        public int Id_Canton { get; set; }
        public int Id_Provincia { get; set; }
        public string NombreDistrito { get; set; }
    }
}
