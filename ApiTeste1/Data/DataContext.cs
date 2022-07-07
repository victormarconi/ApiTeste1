using Microsoft.EntityFrameworkCore;

namespace ApiTeste1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Produtos> Produtos1 { get; set; }
    }
}
