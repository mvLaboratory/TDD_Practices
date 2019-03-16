using System;
using System.Data.Entity;
using TDD_Practices.Models;

namespace TDD_Practices.Dal
{
  public class RdLabDbContext : DbContext
  {
    public RdLabDbContext(string connectionStringName) : base(connectionStringName)
    {
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Document> Documents { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      // configures one-to-many relationship
      modelBuilder.Entity<Project>().HasMany(x => x.Documents);
    }
}
}