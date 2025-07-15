using Microsoft.EntityFrameworkCore;
namespace NovaInventory.Modelo
{
    public class NovaContext : DbContext

    {
        public NovaContext(DbContextOptions<NovaContext> options) : base(options) { }

        public DbSet<Cliente> Clientes {get; set;}

        public DbSet<EstadoCliente> EstadoCliente {get;set;}

        public DbSet<Producto> Productos {get; set;}

        public DbSet<EstadoProducto> EstadoProducto  { get; set;}

        public DbSet<Orden> Ordenes {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
             .HasOne(c => c.EstadoCliente)
             .WithMany(c => c.Clientes)
             .HasForeignKey(c => c.IdEsCli);

            modelBuilder.Entity<Producto>()
             .HasOne(p => p.EstadoProducto)
             .WithMany(e => e.Productos)
             .HasForeignKey(p => p.IdEsPro);

            modelBuilder.Entity<Orden>()
             .HasOne (o => o.Cliente)
             .WithMany(e => e.Ordenes)
             .HasForeignKey(o => o.IdCliente);

            modelBuilder.Entity<Orden>()
             .HasOne (o => o.Producto)
             .WithMany (p => p.Ordenes)
             .HasForeignKey (o => o.IdProducto);

            base.OnModelCreating(modelBuilder);

        }

      

    }
}
