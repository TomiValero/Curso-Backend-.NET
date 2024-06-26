using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{   //Representa la base de datos y sus entidades
    public class StoreContext : DbContext//entre las clases y la bd
    {
        public StoreContext(DbContextOptions<StoreContext> options)//recibe la conexion de program.cs y se la pasa al padre
            : base(options)//les pasa options a la clase padre
        { } 

        //Context representa el nucleo, estas son las entidades(tablas) de la bd:
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brand> Brands { get; set; }

    }
}
