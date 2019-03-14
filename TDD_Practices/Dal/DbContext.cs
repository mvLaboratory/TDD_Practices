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
  }
}