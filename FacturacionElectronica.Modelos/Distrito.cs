using System;
using System.Collections.Generic;
using System.Text;

namespace FacturacionElectronica.Modelos
{
    class Distrito
    {
        public int Id { get; set; }
        public int IdCanton { get; set; }
        public int IdProvincia { get; set; }
        public string Nombre { get; set; }
    }
}
