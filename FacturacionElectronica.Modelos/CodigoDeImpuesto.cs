using System;
using System.Collections.Generic;
using System.Text;

namespace FacturacionElectronica.Modelos
{
    public enum CodigoDeImpuesto
    {
        Impuesto_Al_Valor_Agregado                      = 01,
        Impuesto_Selectivo_De_Consumo                   = 02,
        Impuesto_Unico_A_Los_Combustivos                = 03,
        Impuesto_Especifico_A_Las_Bebidas_Alcoholicas   = 04,
        Impuesto_Especifico_A_Los_Productos_Envasados   = 05,
        Impuesto_A_Los_Productos_Del_Tabaco             = 06,
        IVA                                             = 07,
        IVA_Bienes_Usados                               = 08,
        Otros                                           = 99,
    }
}
