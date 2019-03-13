using System.Data.Entity;
using TDD_Practices.Models;

namespace TDD_Practices.Dal
{
  public class RdLabDbContext : DbContext
  {
    public RdLabDbContext() : base("rdLabDb")
    {
      
    }

    public DbSet<Project> Projects { get; set; }
  }
}