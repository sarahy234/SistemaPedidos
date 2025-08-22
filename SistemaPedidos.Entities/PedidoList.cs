using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPedidos.Entities
{
    public class PedidoList
    {
        public int num_Empl { get; set; }
        public string? nombre { get; set; }
        public int edad { get; set; }
        public string? cargo { get; set; }
        public DateOnly fechaDContrato { get; set; }
        public int couta { get; set; }
        public int ventas { get; set; }
    }
}
