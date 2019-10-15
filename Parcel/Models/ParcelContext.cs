using Microsoft.EntityFrameworkCore;

namespace Parcel.Models
{
  public class ParcelContext : DbContext
  {
    public DbSet<ParcelVariable> ParcelTable { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public ParcelContext(DbContextOptions options) : base(options) { }
  }
}