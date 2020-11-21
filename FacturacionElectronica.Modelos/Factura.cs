using System;
using System.ComponentModel.DataAnnotations;

namespace FacturacionElectronica.Modelos
{
    public class Factura
    {
        [Key]
        public int Clave { get; set; }

        public int idFactura { get; set; }
        
        public int NumeroConsecutivo { get; set; }
        public DateTime FechaEmision { get; set; }
        public int idUsuario { get; set; }
        public int idCliente { get; set; }
        public string CondicionVenta { get; set; }
        public string MedioPago { get; set; }
        public int idResumen { get; set; }

    }
}
