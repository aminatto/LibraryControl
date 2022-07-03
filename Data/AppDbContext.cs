using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Livro> Livros { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)

            => optionsBuilder.UseNpgsql(connectionString: 
                "User ID=postgres;Password=admin;Server=localhost;Port=5432;Database=ControleLivraria;Integrated Security=true;Pooling=true;");
    }
}
