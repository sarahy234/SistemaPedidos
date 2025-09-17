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
        public string nombre { get; set; } = null!;
        public int edad { get; set; }
        public string? cargo { get; set; }
        public DateOnly fechaDContrato { get; set; }
        public int cuota { get; set; }
        public int ventas { get; set; }
        public string nombretiposucursal { get; set; }= string.Empty;
        public string nombretipodirector { get; set; }=string.Empty;
    }
}
