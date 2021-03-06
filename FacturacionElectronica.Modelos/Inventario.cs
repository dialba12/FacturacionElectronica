﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FacturacionElectronica.Modelos
{
    public class Inventario
    {
        [Key]
        public int idInventario { get; set; }
        [Required(ErrorMessage = "Este dato es obligatorio")]
        [Display(Name = "Código:")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Este dato es obligatorio")]
        [Display(Name = "Descripción:")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Este dato es obligatorio")]
        [Display(Name = "Precio costo:")]
        public double PrecioCosto { get; set; }

        [Required(ErrorMessage = "Este dato es obligatorio")]
        [Display(Name = "Precio venta:")]
        public double PrecioVenta { get; set; }

        [Required(ErrorMessage = "Este dato es obligatorio")]
        [Display(Name = "Cant.")]
        public int Existencia { get; set; }
    }
}
