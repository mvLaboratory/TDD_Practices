using System.Data.Entity;
using Tdd.Data;
using TDD_Practices.Data.Factories;

namespace Integration.Tests.Base
{
  internal sealed class DropCreateDatabaseAlwaysAndSeed : DropCreateDatabaseAlways<RdLabDbContext>
  {
    public override void InitializeDatabase(RdLabDbContext context)
    {
      if (context.Database.Exists())
      {
        context.Database.ExecuteSqlCommand(
          TransactionalBehavior.DoNotEnsureTransaction,
          $"ALTER DATABASE [{context.Database.Connection.Database}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
      }

      base.InitializeDatabase(context);
    }

    protected override void Seed(RdLabDbContext context)
    {
      var factory = new EntityFactory();
      for (int i = 0; i < 10; i++)
      {
        context.Projects.Add(factory.GetProject());
      }

      context.SaveChanges();
    }
  }
}
