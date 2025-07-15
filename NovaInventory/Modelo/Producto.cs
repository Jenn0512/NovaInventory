using System.ComponentModel.DataAnnotations;

namespace NovaInventory.Modelo
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }

        public decimal Precio { get; set; }

        public int IdEsPro {  get; set; }

        public EstadoProducto EstadoProducto { get; set; }

        public ICollection<Orden> Ordenes { get; set; }


    }
}
