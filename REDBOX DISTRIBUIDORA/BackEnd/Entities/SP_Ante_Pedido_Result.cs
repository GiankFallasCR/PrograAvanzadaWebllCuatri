using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    [Keyless]
    public class SP_Ante_Pedido_Result
    {
        public int resultado { get; set; }
    }
}
