using Microsoft.EntityFrameworkCore;
using GeometriaAPI.Models;

namespace GeometriaAPI.Data
{
    public class GeometriaContext : DbContext
    {
        public GeometriaContext(DbContextOptions<GeometriaContext> options) : base(options) { }

        public DbSet<Triangulo> Triangulos { get; set; }
        public DbSet<Rectangulo> Rectangulos { get; set; }
        public DbSet<Cuadrado> Cuadrados { get; set; }
        public DbSet<Circulo> Circulos { get; set; }

        // 👇 Nueva tabla para usuarios (autenticación JWT)
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
