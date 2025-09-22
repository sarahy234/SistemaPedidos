using SistemaPedidos.Entities;

namespace SistemaPedidos.Services
{
    public class TipoClienteService
    {
        private List<TipoClienteCLS> lista;
        public TipoClienteService()
        {
            lista = new List<TipoClienteCLS>();
            lista.Add(new TipoClienteCLS { idrepresentante = 1, nombrerepresentante = "Sarahy" });
            lista.Add(new TipoClienteCLS { idrepresentante = 2, nombrerepresentante = "Franco" });

        }
        public List<TipoClienteCLS> listarTipoCliente()
        {
            return lista;
        }
        public int obtenerIdRepresentante(string nombreRepresentante)
        {
            var obj = lista.FirstOrDefault(p => p.nombrerepresentante == nombreRepresentante);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return obj.idrepresentante;
            }
        }

        public string obtenerNombreRepresentantePorId(int idRepresentante)
        {
            var obj = lista.FirstOrDefault(p => p.idrepresentante == idRepresentante);
            return obj?.nombrerepresentante ?? "";
        }

    }
}
