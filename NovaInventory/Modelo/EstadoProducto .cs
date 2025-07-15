using System.ComponentModel.DataAnnotations;

namespace NovaInventory.Modelo
{
    public class EstadoProducto
    {

        [Key]
        public int IdEsPro { get; set; }

        public string NombreEstado { get; set; }
            
        public ICollection<Producto> Productos { get; set; }

    }

}
