using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Rol
    {
        public Rol()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdRol { get; set; }
        public string DescRol { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
