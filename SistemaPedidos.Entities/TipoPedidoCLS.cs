using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPedidos.Entities
{
    public class TipoPedidoCLS
    {
        public int idtiposucursal { get; set; }
        public string nombretiposucursal { get; set; } = string.Empty;
        public int idtipodirector { get; set; }
        public string nombretipodirector { get; set; } = string.Empty;
    }
}
