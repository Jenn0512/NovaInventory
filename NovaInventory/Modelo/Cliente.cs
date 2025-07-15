using System.ComponentModel.DataAnnotations;

namespace NovaInventory.Modelo
{
    public class Cliente 

    {
        [Key]
        public int IdCliente { get; set; }
        public String Nombre { get; set; }
        public int IdEsCli {  get; set; }

        public EstadoCliente EstadoCliente { get; set; }    

        public ICollection<Orden> Ordenes { get; set; }
    }
}
