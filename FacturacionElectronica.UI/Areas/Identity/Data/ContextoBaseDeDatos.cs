using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacturacionElectronica.UI.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FacturacionElectronica.UI.Data
{
    public class ContextoBaseDeDatos : IdentityDbContext<Usuario>
    {
        public ContextoBaseDeDatos(DbContextOptions<ContextoBaseDeDatos> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
