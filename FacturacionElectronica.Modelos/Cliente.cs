using System;
using System.Collections.Generic;
using System.Text;

namespace FacturacionElectronica.Modelos
{
    public class Cliente
    {

        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int idCliente { get; set; }
        public int Identificacion { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }

        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Barrio { get; set; }
        public string OtrasSenas { get; set; }
        public TipoDeIdentificacion TipoIdenticacion { get; set; }

    }
}
