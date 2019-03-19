using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using MediatR;
using NUnit.Framework;
using StructureMap;
using TDD_Practices.Dal;
using TDD_Practices.Handlers;

namespace Integration.Tests.Base
{
  public class BaseIntegrationFixture
  {
    protected RdLabDbContext Context => SetUpFixture.Context;
    protected IMediator MediatorFake { get; }
    protected Container Container { get; }
    //protected Dictionary<IRequest, RequestHandlerBase<,>>
    protected BaseIntegrationFixture()
    {
      Container = new Container();
      MediatorFake = new MediatorFake();
    }

    protected void SetUpHandler<TR, TH>()
    {
      //Container.Configure(_ => _.For<TR>().Use<TH>());
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
