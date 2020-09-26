using System;
using FacturacionElectronica.UI.Areas.Identity.Data;
using FacturacionElectronica.UI.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FacturacionElectronica.UI.Areas.Identity.IdentityHostingStartup))]
namespace FacturacionElectronica.UI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ContextoBaseDeDatos>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ContextoBaseDeDatosConnection")));

                services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ContextoBaseDeDatos>();
            });
        }
    }
}