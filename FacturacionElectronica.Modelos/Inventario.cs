using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FacturacionElectronica.Modelos
{
    public class Inventario
    {
        [Key]
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public double PrecioCosto { get; set; }
        public double PrecioVenta { get; set; }
        public int Existencia { get; set; }
    }
}
