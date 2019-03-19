using System.Linq;
using Integration.Tests.Base;
using NUnit.Framework;
using TDD_Practices.Dal;
using TDD_Practices.Dal.Factories;
using TDD_Practices.Handlers;
using TDD_Practices.Requests;

namespace Integration.Tests
{
  [TestFixture]
  public class TestClass : BaseIntegrationFixture
  {
    [OneTimeSetUp]
    public void SetUp()
    {
      var factory = new EntityFactory();
      for (int i = 0; i < 10; i++)
      {
        Context.Projects.Add(factory.GetProject());
      }

      Context.SaveChanges();
    }

    [Test]
    public void TestMethod()
    {
      var projRepo = new ProjectRepository(Context);
      var handler = new GetProjectsListHandler(projRepo);

      var request = new GetProjectsListRequest();

      var actualResult = handler.CreateResponse(request);

      Assert.True(actualResult.Any());
      Assert.True(actualResult.Count() == 10);
    }

    //TODO:: Add test about ID. Use Hardcode :)
  }
}
