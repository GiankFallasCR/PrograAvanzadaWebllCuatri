using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Categorium
    {
        public Categorium()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
