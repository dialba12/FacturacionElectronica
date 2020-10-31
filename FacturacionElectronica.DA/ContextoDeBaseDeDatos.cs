
using System;
using System.Collections.Generic;

using System.Text;
using FacturacionElectronica.Modelos;
using Microsoft.EntityFrameworkCore;

namespace FacturacionElectronica.DA
{
   public class ContextoDeBaseDeDatos: DbContext
    {
        public ContextoDeBaseDeDatos(DbContextOptions<ContextoDeBaseDeDatos> opciones) : base(opciones)
        {

        }
    }
}
