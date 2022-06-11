using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string CedulaJuridica { get; set; } = null!;
        public string? Direccion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
