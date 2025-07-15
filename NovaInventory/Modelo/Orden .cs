using System.ComponentModel.DataAnnotations;

namespace NovaInventory.Modelo
{
    public class Orden
    {
        [Key]
        public int IdOrden {  get; set; }

        public int IdCliente { get; set; }

        public int IdProducto { get; set; }

        public int Cantidad { get; set; }

        public DateTime FechaOrden { get; set; } = DateTime.Now;

        public Cliente Cliente { get; set; }

        public Producto Producto{ get; set; }
    }
}
