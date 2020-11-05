using Microsoft.EntityFrameworkCore;
using ProvaConceito.Domain.Models;

namespace AspnetCore_EFCoreInMemory.Models
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options)
          : base(options)
        { }
        public DbSet<ItemPedidoModel> ItemPedido { get; set; }
        public DbSet<VendedorModel> Vendedor { get; set; }
        public DbSet<VendaModel> Venda { get; set; }
    }

    //TODO: Falta criar os mapeamentos do entinty

}