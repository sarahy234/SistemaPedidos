using SistemaPedidos.Entities;
using SistemaPedidos.Pages;

namespace SistemaPedidos.Services
{
    public class PedidosService
    {
        private List<PedidoList> lista;
        private TipoPedidoService tipoPedidoService;
        public PedidosService(TipoPedidoService _tipopedidoservice)
        {
            tipoPedidoService = _tipopedidoservice;
            lista = new List<PedidoList>();
            lista.Add(new PedidoList { num_Empl = 1, nombre = "Natalia", edad = 19, cargo = "Empleada",nombretiposucursal="La Paz", nombretipodirector="Sarahy", cuota = 20, ventas = 100 });
            lista.Add(new PedidoList { num_Empl = 2, nombre = "Ana", edad = 40, cargo = "Empleada", nombretiposucursal = "Cochabamba", nombretipodirector = "Jhosep",cuota = 50, ventas = 10 });
        }
        public List<PedidoList> listarPedidos()
        {
            return lista;
        }
        public void eliminarPedido(int num_empl)
        {
            var listaQueda = lista.Where(p => p.num_Empl != num_empl).ToList();
            lista = listaQueda;
        }
        public RegistroVentasCLS recuperarPedidoPorId(int num_empl)
        {
            var obj=lista.Where(p=>p.num_Empl==num_empl).FirstOrDefault();
            if (obj != null)
            {
                return new RegistroVentasCLS
                {
                    Num_Empl = obj.num_Empl,
                    Nombre = obj.nombre,
                    Edad = obj.edad,
                    Cargo = obj.cargo,
                    Cuota = obj.cuota,
                    idSucursal = tipoPedidoService.obtenerIdTipoSucursal(obj.nombretiposucursal),
                    Director = tipoPedidoService.obtenerIdTipoDirector(obj.nombretipodirector),
                    Ventas = obj.ventas,
                    FechaDeContrato = obj.fechaDContrato
                };
            }
            else
            {
                return new RegistroVentasCLS();
            }
        }
        public void guardarPedido(RegistroVentasCLS oRegistroVentasCLS)
        {
            int num_Empl = lista.Select(p => p.num_Empl).Max()+1;

            lista.Add(new PedidoList
            {
                num_Empl = num_Empl,
                nombre = oRegistroVentasCLS.Nombre,
                edad = oRegistroVentasCLS.Edad,
                cargo = oRegistroVentasCLS.Cargo,
                fechaDContrato = oRegistroVentasCLS.FechaDeContrato,
                nombretiposucursal = tipoPedidoService.obtenerNombreSucursalPorId(oRegistroVentasCLS.idSucursal),
                nombretipodirector = tipoPedidoService.obtenerNombreDirectorPorId(oRegistroVentasCLS.Director),
                cuota = oRegistroVentasCLS.Cuota,
                ventas = oRegistroVentasCLS.Ventas
            });
        }
        public List<PedidoList> filtrarEmpleados(string nombreempleado)
        {
            List<PedidoList> l = listarPedidos();
            if (nombreempleado == "")
            {
                return l;
            }
            else
            {
                List<PedidoList> listafiltrada = l.Where(p => p.nombre.ToUpper().Contains(nombreempleado.ToUpper())).ToList();
                return listafiltrada;
            }
        }
        public event Func<string, Task> OnSearch = delegate { return Task.CompletedTask; };
        public async Task notificarBusqueda(string nombre)
        {
            if (OnSearch != null)
            {
                await OnSearch.Invoke(nombre);
            }
        }
    }
}
