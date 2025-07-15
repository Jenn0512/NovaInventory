namespace NovaInventory.Modelo
{
    public class Cliente 

    {
        public int IdCliente { get; set; }
        public String Nombre { get; set; }
        public int IdEsCli {  get; set; }

        public EstadoCliente EstadoCliente { get; set; }    
    }
}
