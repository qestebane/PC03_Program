using Microsoft.EntityFrameworkCore;
using PC03_Program.Models;

namespace PC03_Program.Data
{
    public class WebAppContext : DbContext
    {
       public DbSet<Producto> Productos { get; private set; }
       public WebAppContext(DbContextOptions dco) : base(dco) {

       } 
    }
}