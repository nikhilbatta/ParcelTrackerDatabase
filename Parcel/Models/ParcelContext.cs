using Microsoft.EntityFrameworkCore;

namespace Parcel.Models
{
  public class ParcelContext : DbContext
  {
    public DbSet<ParcelVariable> Parcels { get; set; }

    public ParcelContext(DbContextOptions options) : base(options) { }
  }
}