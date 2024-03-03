using Microsoft.EntityFrameworkCore;

namespace Chassi.API.Projeto.Model.Context
{
    public class MySqlContext: DbContext
    {
        public MySqlContext()
        {
                
        }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
