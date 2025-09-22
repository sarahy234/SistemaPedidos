using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaPedidos.Entities
{
    public class RegistroCliente
    {
        [Required(ErrorMessage = "El codigo del cliente es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "El Numero del empleado debe ser mayor a 0")]
        public int cod_cli { get; set; }
        [Required(ErrorMessage = "El Nombre del cliente es requerido")]
        public string? nombre_cli { get; set; } = null!;
        [Required(ErrorMessage = "Debe selecccionar un representante")]
        public int representante { get; set; }
        [Required(ErrorMessage = "La edad debe ser igual o mayor a 18")]
        public int limiteCredi { get; set; }
    }
}
