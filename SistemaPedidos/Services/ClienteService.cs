using SistemaPedidos.Entities;
using SistemaPedidos.Pages;

namespace SistemaPedidos.Services
{
    public class ClienteService
    {
        private List<ClienteList> lista;
        private TipoClienteService tipoClienteService;
        public ClienteService(TipoClienteService _tipoclienteservice)
        {
            tipoClienteService = _tipoclienteservice;
            lista = new List<ClienteList>();
            lista.Add(new ClienteList { cod_cli = 1, nombre_cli = "Eithan", nombretiporepresentante = "Nombre1",limiteCredi=1200});
            lista.Add(new ClienteList { cod_cli = 2, nombre_cli = "Fernanda", nombretiporepresentante = "Nombre2",limiteCredi=2000});
        }
        public List<ClienteList> listarClientes()
        {
            return lista;
        }
        public void eliminarCliente(int cod_cli)
        {
            var listaQueda = lista.Where(p => p.cod_cli != cod_cli).ToList();
            lista = listaQueda;
        }
        public RegistroCliente recuperarClientePorId(int cod_cliente)
        {
            var obj = lista.Where(p => p.cod_cli == cod_cliente).FirstOrDefault();
            if (obj != null)
            {
                return new RegistroCliente
                {
                    cod_cli = obj.cod_cli,
                    nombre_cli = obj.nombre_cli,
                    representante = tipoClienteService.obtenerIdRepresentante(obj.nombretiporepresentante),
                    limiteCredi = obj.limiteCredi
                };
            }
            else
            {
                return new RegistroCliente();
            }
        }
        public void guardarCliente(RegistroCliente oRegistroClienteCLS)
        {
            int cod_cli = lista.Select(p => p.cod_cli).Max() + 1;

            lista.Add(new ClienteList
            {
                cod_cli = cod_cli,
                nombre_cli = oRegistroClienteCLS.nombre_cli,
                nombretiporepresentante = tipoClienteService.obtenerNombreRepresentantePorId(oRegistroClienteCLS.representante),
                limiteCredi= oRegistroClienteCLS.limiteCredi,

            });
        }
        public List<ClienteList> filtrarCliente(string nombrecliente)
        {
            List<ClienteList> l = listarClientes();
            if (nombrecliente == "")
            {
                return l;
            }
            else
            {
                List<ClienteList> listafiltrada = l.Where(p => p.nombre_cli.ToUpper().Contains(nombrecliente.ToUpper())).ToList();
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
