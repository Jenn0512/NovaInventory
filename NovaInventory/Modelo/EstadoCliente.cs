using System.ComponentModel.DataAnnotations;

namespace NovaInventory.Modelo
{
    public class EstadoCliente
    {
        [Key]
        public int IdEsCli{  get; set; }

        public String NombreEstado { get; set; }

        public ICollection<Cliente> Clientes { get; set; }
    }
}
