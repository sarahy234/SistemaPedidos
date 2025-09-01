using SistemaPedidos.Entities;
using SistemaPedidos.Pages;

namespace SistemaPedidos.Services
{
    public class PedidosService
    {
        private List<PedidoList> lista;
        public PedidosService()
        {
            lista = new List<PedidoList>();
            lista.Add(new PedidoList { num_Empl = 1, nombre = "Natalia", edad = 19, cargo = "Empleada", cuota = 20, ventas = 100 });
            lista.Add(new PedidoList { num_Empl = 2, nombre = "Ana", edad = 40, cargo = "Empleada", cuota = 50, ventas = 10 });
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
                    Edad=obj.edad,
                    Cargo = obj.cargo,
                    Cuota = obj.cuota,
                    Ventas = obj.ventas,
                    FechaDeContrato = DateOnly.FromDateTime(DateTime.Now) 
                };
            }
            else
            {
                return new RegistroVentasCLS();
            }
        }
        public void guardarPedido(RegistroVentasCLS oRegistroVentasCLS)
        {
            lista.Add(new PedidoList { num_Empl = oRegistroVentasCLS.Num_Empl, nombre = oRegistroVentasCLS.Nombre, edad = oRegistroVentasCLS.Edad, cargo = oRegistroVentasCLS.Cargo, fechaDContrato = oRegistroVentasCLS.FechaDeContrato, cuota = oRegistroVentasCLS.Cuota, ventas = oRegistroVentasCLS.Ventas });
        }
    }
}
