using System.Data.Entity;
using TDD_Practices.Models;

namespace TDD_Practices.Data
{
  public class RdLabDbContext : DbContext
  {
    public RdLabDbContext(string connectionStringName) : base(connectionStringName)
    {
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<DocumentIndex> DocumentIndex { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Project>().HasMany(x => x.Documents);
      modelBuilder.Entity<Document>()
        .Property(f => f.UpdateDate)
        .HasColumnType("datetime2")
        .HasPrecision(0);
    }
}
}