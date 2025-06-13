using Aprendizado.Domains;
using Microsoft.EntityFrameworkCore;

namespace Aprendizado.Persistence
{
    public class OracleDbContext : DbContext
    {
        public DbSet<Cantor> Cantores { get; set; }
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options) { }
        //O construtor do OracleDbContext, ou de qualquer classe que herde de DbContext no Entity Framework Core, é essencial para configurar como sua aplicação interage com o banco de dados.
    }
}
