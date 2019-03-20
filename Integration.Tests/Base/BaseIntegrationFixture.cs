using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using MediatR;
using NUnit.Framework;
using StructureMap;
using StructureMap.Pipeline;
using TDD_Practices.Dal;
using TDD_Practices.Dal.Factories;
using TDD_Practices.DependencyResolution;

namespace Integration.Tests.Base
{
  public class BaseIntegrationFixture
  {
    protected RdLabDbContext Context => SetUpFixture.Context;
    protected Container Container { get; }
    protected BaseIntegrationFixture()
    {
      Container = new Container(cfg =>
      {
        cfg.For<RdLabDbContext>().Use(Context);
        cfg.For<IEntityFactory>().Use<EntityFactory>().SetLifecycleTo(new SingletonLifecycle());
        cfg.For<IProjectRepository>().Use<ProjectRepository>().SetLifecycleTo(new SingletonLifecycle());
        cfg.AddRegistry<DefaultRegistry>();
        cfg.Scan(scanner =>
        {
          scanner.Assembly(Assembly.Load("TDD_Practices"));
          scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
          scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
        });
        cfg.For<ServiceFactory>().Use<ServiceFactory>(ctx => ctx.GetInstance);
        cfg.For<IMediator>().Use<Mediator>();
      });
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
