﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System.Collections.Generic;

namespace TPFinalProgIII.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Cliente = new HashSet<Cliente>();
            Direccion = new HashSet<Direccion>();
            Proveedor = new HashSet<Proveedor>();
        }

        public long IdCuitDni { get; set; }
        public string NombreCompleto { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Direccion> Direccion { get; set; }
        public virtual ICollection<Proveedor> Proveedor { get; set; }
    }
}