using App.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace App.Dominio
{
  public class BancoDeDados : DbContext
  {
    public BancoDeDados(DbContextOptions options) : base(options) { }

    public DbSet<Vistoria> Vistorias { get; set; }
  }
}
