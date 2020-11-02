
using System;
using System.Collections.Generic;

using System.Text;
using FacturacionElectronica.Modelos;
using Microsoft.EntityFrameworkCore;

namespace FacturacionElectronica.DA
{
    public class ContextoDeBaseDeDatos : DbContext
    {
        public ContextoDeBaseDeDatos(DbContextOptions<ContextoDeBaseDeDatos> opciones) : base(opciones)
        { }
        
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Cierre> Cierre { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
    }
    }


