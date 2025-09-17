

using System.ComponentModel.DataAnnotations;

namespace SistemaPedidos.Entities
{
    public class RegistroVentasCLS
    {
        [Required(ErrorMessage = "El Numero del empleado es requerido")]
        [Range (0 ,int.MaxValue, ErrorMessage = "El Numero del empleado debe ser mayor a 0")]
        public int Num_Empl { get; set; }
        [Required(ErrorMessage = "El Nombre del empleado es requerido")]
        public string ?Nombre { get; set; } = null!;
        [Required(ErrorMessage = "El Cargo del empleado es requerido")]
        public int Edad {get; set;}
        [Required(ErrorMessage = "La edad debe ser igual o mayor a 18")]
        public string?  Cargo { get; set; }=null!;
        [Required(ErrorMessage = "La fecha de cntrato del empleado es requerido")]
        public DateOnly FechaDeContrato { get; set; }
        [Required(ErrorMessage = "La cuota del empleado es requerido")]
        public int Cuota { get; set; }
        [Required(ErrorMessage = "las ventas del empleado es requerido")]
        public int Ventas { get; set; }
        [Required(ErrorMessage = "Debe seleccionar una sucursal")]
        public int idSucursal{ get; set; }
        [Required(ErrorMessage = "Debe selecccionar un director")]
        public int Director { get; set; }
    }
}
