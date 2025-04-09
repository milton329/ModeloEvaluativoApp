using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back
{
    public class AplicationDbContext: DbContext
    {
        public DbSet<Comentario> Comentario { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {

        }
    }
}
