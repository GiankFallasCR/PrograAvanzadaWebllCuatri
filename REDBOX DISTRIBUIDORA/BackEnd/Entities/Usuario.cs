using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            BitacoraErrores = new HashSet<BitacoraErrore>();
            Pedidos = new HashSet<Pedido>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string NombreUsuario { get; set; } = null!;
        public string ContraseniaUsuario { get; set; } = null!;
        public int IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; } = null!;
        public virtual ICollection<BitacoraErrore> BitacoraErrores { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
