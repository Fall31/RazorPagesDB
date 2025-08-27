using WARazorDB.Models;
using Microsoft.EntityFrameworkCore;

namespace WARazorDB.Data
{
    public class TareaDBContext : DbContext
    {
        public TareaDBContext(DbContextOptions<TareaDBContext> options): base(options) 
        {

        }
        public DbSet<Tarea> Tareas { get; set; }
        protected TareaDBContext() 
        {
                    }
    }
}
