
using System;
using System.Collections.Generic;

using System.Text;
using FacturacionElectronica.Modelos;
using Microsoft.EntityFrameworkCore;

namespace FacturacionElectronica.DA
{
    public class ContextoDeBaseDeDatos : DbContext
    {
        public ContextoDeBaseDeDatos() { }
        public ContextoDeBaseDeDatos(DbContextOptions<ContextoDeBaseDeDatos> opciones) : base(opciones)
        { }
        
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Cierre> Cierre { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<Emisor> Emisor { get; set; }
        public DbSet<LineaDetalle> LineaDetalle { get; set; }


    }
    }


