using Microsoft.EntityFrameworkCore;

namespace AplicacaoWebCRUD.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Carro> Carro { get; set; }
    }
}
