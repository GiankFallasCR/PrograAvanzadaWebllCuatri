using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Estado
    {
        public Estado()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdEstado { get; set; }
        public string DescripcionEstado { get; set; } = null!;

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
