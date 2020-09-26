using System;
using System.Collections.Generic;
using System.Text;

namespace FacturacionElectronica.Modelos
{
    public enum MedioDePago
    {
        Efectivo                            = 01,
        Tarjeta                             = 02,
        Cheque                              = 03,
        Transferencia_Deposito_Bancario     = 04,
        Recaudado_Por_Terceros              = 05,
        Otros                               = 99,
    }
}
