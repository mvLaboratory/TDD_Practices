using System.Data.Entity;
using NUnit.Framework;
using TDD_Practices.Data;

namespace Integration.Tests.Base
{
  [SetUpFixture]
  internal sealed class SetUpFixture
  {
    internal static RdLabDbContext Context = new RdLabDbContext("testRdLabDb");

    [OneTimeSetUp]
    public void Initialize()
    {
      Database.SetInitializer(new DropCreateDatabaseAlwaysAndSeed());
      Context.Database.Initialize(false);
    }
  }
}
