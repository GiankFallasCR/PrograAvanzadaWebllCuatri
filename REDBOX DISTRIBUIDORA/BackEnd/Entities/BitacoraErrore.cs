using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class BitacoraErrore
    {
        public int IdError { get; set; }
        public string Detalle { get; set; } = null!;
        public string? UsuarioAfectado { get; set; }
        public DateTime FechaError { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
