using System;

namespace FacturacionElectronica.Modelos
{
    public class Factura
    {

        public int Clave { get; set; }
        public int idDetalleServicio { get; set; }
        public int NumeroConsecutivo { get; set; }
        public DateTime FechaEmision { get; set; }
        public int idUsuario { get; set; }
        public int idCliente { get; set; }
        public string CondicionVenta { get; set; }
        public string MedioPago { get; set; }
        public int idResumen { get; set; }

    }
}
