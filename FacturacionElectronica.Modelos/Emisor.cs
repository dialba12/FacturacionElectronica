using System;
using System.Collections.Generic;
using System.Text;

namespace FacturacionElectronica.Modelos
{
    public class Emisor
    {
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int Id_Emisor { get; set; }
        public string Correo { get; set; }
        public int Id_Telefono { get; set; }
        public int Id_Fax { get; set; }
        public int Id_Ubicacion { get; set; }
    }
}
