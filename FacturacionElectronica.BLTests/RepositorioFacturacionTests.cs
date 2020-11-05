using Microsoft.VisualStudio.TestTools.UnitTesting;
using FacturacionElectronica.BL;
using System;
using System.Collections.Generic;
using System.Text;
using FacturacionElectronica.Modelos;
using Moq;
using FacturacionElectronica.DA;
using System.Linq;

namespace FacturacionElectronica.BL.Tests
{
    [TestClass()]
    public class RepositorioFacturacionTests
    {
        [TestMethod()]
        public void ObtenerClientesTest()
        {
            Cliente cliente = new Cliente();
            cliente.Nombre = "Jeff";
            cliente.PrimerApellido = "Acosta";
            cliente.SegundoApellido = "Obando";
            cliente.Telefono = 12345;
            cliente.Identificacion = 1234;
            cliente.TipoIdentificacion = TipoDeIdentificacion.Fisica;
            cliente.idCliente = 1;
            cliente.Correo = "jeff@gmail.com";
            cliente.Provincia = "Guanacaste";
            cliente.Canton = "Abangares";
            cliente.Distrito = "Colorado";
            cliente.OtrasSenas = "Negro";


            var mockcontexto = new Mock<ContextoDeBaseDeDatos>();
            var mockrepositorio = new Mock<IRepositorioFacturacion>();
            mockrepositorio.Setup(a => a.AgregarCliente(cliente));
            mockrepositorio.Setup(x => x.ObtenerClientes()).Returns(new List<Cliente>() { new Cliente() });

            RepositorioFacturacion repo = new RepositorioFacturacion(mockcontexto.Object);

            var resultado = mockrepositorio.Object.ObtenerClientes();

            Assert.IsTrue(resultado.Count() == 1);
        }

        [TestMethod()]
        public void AgregarCierreTest()
        {
            Cierre cierre = new Cierre();
            cierre.Fecha = DateTime.Now;
            cierre.Monto = 1000;
            cierre.IdUsuario = "Edgar";
            cierre.idCierre = 12;


            var mockcontexto = new Mock<ContextoDeBaseDeDatos>();
            var mockrepositorio = new Mock<IRepositorioFacturacion>();
            mockrepositorio.Setup(a => a.AgregarCierre(cierre));
            mockrepositorio.Setup(x => x.ObtenerCierre()).Returns(new List<Cierre>() { new Cierre() });

            RepositorioFacturacion repo = new RepositorioFacturacion(mockcontexto.Object);

            var resultado = mockrepositorio.Object.ObtenerCierre();

            Assert.IsNotNull(resultado);
        }

        [TestMethod()]
        public void ModificarCierreTest()
        {
            Cierre cierre = new Cierre();

            cierre.Fecha = DateTime.Now;
            cierre.Monto = 1000;
            cierre.IdUsuario = "Edgar";
            cierre.idCierre = 12;


            var mockcontexto = new Mock<ContextoDeBaseDeDatos>();
            var mockrepositorio = new Mock<IRepositorioFacturacion>();
            mockrepositorio.Setup(a => a.AgregarCierre(cierre));
            mockrepositorio.Setup(r => r.ModificarCierre(13, cierre));
            mockrepositorio.Setup(x => x.ObtenerCierre()).Returns(new List<Cierre>() { new Cierre() });

            RepositorioFacturacion repo = new RepositorioFacturacion(mockcontexto.Object);
            var resultado = mockrepositorio.Object.ObtenerCierre();

            Assert.IsNotNull(resultado);
        }

        [TestMethod()]
        public void EliminarCierreTest()
        {
            Cierre cierre = new Cierre();
            cierre.Fecha = DateTime.Now;
            cierre.Monto = 1000;
            cierre.IdUsuario = "Edgar";
            cierre.idCierre = 12;


            var mockcontexto = new Mock<ContextoDeBaseDeDatos>();
            var mockrepositorio = new Mock<IRepositorioFacturacion>();
            mockrepositorio.Setup(a => a.AgregarCierre(cierre));
            mockrepositorio.Setup(r => r.EliminarCierre(cierre));
            mockrepositorio.Setup(x => x.ObtenerCierre()).Returns(new List<Cierre>() { new Cierre() });

            RepositorioFacturacion repo = new RepositorioFacturacion(mockcontexto.Object);
            var resultado = mockrepositorio.Object.ObtenerCierre();

            Assert.IsFalse(resultado == null);
        }

        [TestMethod()]
        public void AgregarInventarioTest()
        {
            Inventario inventario = new Inventario();
            inventario.Codigo = 1234;
            inventario.Descripcion = "Manguera";
            inventario.Existencia = 2;
            inventario.idInventario = 1;
            inventario.PrecioCosto = 100;
            inventario.PrecioVenta = 90;

            var mockcontexto = new Mock<ContextoDeBaseDeDatos>();
            var mockrepositorio = new Mock<IRepositorioFacturacion>();
            mockrepositorio.Setup(a => a.AgregarInventario(inventario));

            mockrepositorio.Setup(x => x.ObtenerInventario()).Returns(new List<Inventario>() { new Inventario() });

            RepositorioFacturacion repo = new RepositorioFacturacion(mockcontexto.Object);
            var resultado = mockrepositorio.Object.ObtenerInventario();

            Assert.IsNotNull(resultado);

        }

        [TestMethod()]
        public void ModificarInventarioTest()
        {
            Inventario inventario = new Inventario();
            inventario.Codigo = 1234;
            inventario.Descripcion = "Manguera";
            inventario.Existencia = 2;
            inventario.idInventario = 1;
            inventario.PrecioCosto = 100;
            inventario.PrecioVenta = 90;

            var mockcontexto = new Mock<ContextoDeBaseDeDatos>();
            var mockrepositorio = new Mock<IRepositorioFacturacion>();
            mockrepositorio.Setup(a => a.AgregarInventario(inventario));
            mockrepositorio.Setup(a => a.ModificarInventario(2, inventario));
            mockrepositorio.Setup(x => x.ObtenerInventario()).Returns(new List<Inventario>() { new Inventario() });

            RepositorioFacturacion repo = new RepositorioFacturacion(mockcontexto.Object);
            var resultado = mockrepositorio.Object.ObtenerInventario();

            Assert.IsTrue(resultado.Count() == 1);
        }

        [TestMethod()]
        public void EliminarInventarioTest()
        {
            Inventario inventario = new Inventario();
            inventario.Codigo = 1234;
            inventario.Descripcion = "Manguera";
            inventario.Existencia = 2;
            inventario.idInventario = 1;
            inventario.PrecioCosto = 100;
            inventario.PrecioVenta = 90;

            var mockcontexto = new Mock<ContextoDeBaseDeDatos>();
            var mockrepositorio = new Mock<IRepositorioFacturacion>();
            mockrepositorio.Setup(a => a.AgregarInventario(inventario));
            mockrepositorio.Setup(a => a.EliminarInventario(inventario));
            mockrepositorio.Setup(x => x.ObtenerInventario()).Returns(new List<Inventario>() { new Inventario() });

            RepositorioFacturacion repo = new RepositorioFacturacion(mockcontexto.Object);
            var resultado = mockrepositorio.Object.ObtenerInventario();

            Assert.IsFalse(resultado.Count() == null);
        }
    }


}