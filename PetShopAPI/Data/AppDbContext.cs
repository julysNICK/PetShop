using Microsoft.EntityFrameworkCore;

public class AppDBContext : DbContext
{
  public AppDBContext(DbContextOptions<AppDBContext> option) : base(option)
  {

  }

  public DbSet<Animal> Animals { get; set; }

}