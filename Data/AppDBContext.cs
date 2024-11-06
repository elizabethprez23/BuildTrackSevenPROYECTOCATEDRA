using Microsoft.EntityFrameworkCore;
using BuildTrackSeven.Models;

namespace BuildTrackSeven.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        //pasando opciones a DbContext
        public AppDBContext(DbContextOptions<AppDBContext> options) : base (options)
        {
            
        }


    }
}
