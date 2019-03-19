using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using NUnit.Framework;
using TDD_Practices.Dal;

namespace Integration.Tests.Base
{
  public class BaseIntegrationFixture
  {
    protected RdLabDbContext Context => SetUpFixture.Context;
    protected BaseIntegrationFixture()
    {
    }

    [TearDown]
    public void ResetChangeTracker()
    {
      IEnumerable<DbEntityEntry> changedEntriesCopy = Context.ChangeTracker.Entries()
        .Where(e => e.State == EntityState.Added ||
                    e.State == EntityState.Modified ||
                    e.State == EntityState.Deleted
        );
      foreach (DbEntityEntry entity in changedEntriesCopy)
      {
        Context.Entry(entity.Entity).State = EntityState.Detached;
      }
    }
  }
}
