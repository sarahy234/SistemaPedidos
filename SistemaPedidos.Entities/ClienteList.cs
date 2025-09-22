using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPedidos.Entities
{
    public class ClienteList
    {
        public int cod_cli { get; set; }
        public string nombre_cli { get; set; } = null!;
        public string nombretiporepresentante { get; set; } = string.Empty;
        public int limiteCredi{ get; set; }
    }
}
