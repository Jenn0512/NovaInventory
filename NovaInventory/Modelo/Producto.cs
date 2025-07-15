namespace NovaInventory.Modelo
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProdcuto { get; set; }

        public decimal Precio { get; set; }

        public int IdEsPro {  get; set; }

        public EstadoProducto EstadoProducto { get; set; }

    }
}
