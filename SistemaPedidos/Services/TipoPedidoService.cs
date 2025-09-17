using SistemaPedidos.Entities;

namespace SistemaPedidos.Services
{
    public class TipoPedidoService
    {
        private List<TipoPedidoCLS> lista;
        public TipoPedidoService()
        {
            lista = new List<TipoPedidoCLS>();
            lista.Add(new TipoPedidoCLS { idtiposucursal = 1, nombretiposucursal = "La Paz" , idtipodirector=1,nombretipodirector="Sarahy"});
            lista.Add(new TipoPedidoCLS { idtiposucursal = 2, nombretiposucursal = "Cochabamba", idtipodirector=2,nombretipodirector="Jhosep" });
            
        }
        public List<TipoPedidoCLS> listarTipoPedidos()
        {
            return lista;
        }
        public int obtenerIdTipoSucursal(string nombreSucursal)
        {
            var obj = lista.FirstOrDefault(p => p.nombretiposucursal == nombreSucursal);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return obj.idtiposucursal;
            }
        }

        public int obtenerIdTipoDirector(string nombreDirector)
        {
            var obj = lista.FirstOrDefault(p => p.nombretipodirector == nombreDirector);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return obj.idtipodirector;
            }
        }
        public string obtenerNombreSucursalPorId(int idSucursal)
        {
            var obj = lista.FirstOrDefault(p => p.idtiposucursal == idSucursal);
            return obj?.nombretiposucursal ?? "";
        }

        public string obtenerNombreDirectorPorId(int idDirector)
        {
            var obj = lista.FirstOrDefault(p => p.idtipodirector == idDirector);
            return obj?.nombretipodirector ?? "";
        }
    }
}
