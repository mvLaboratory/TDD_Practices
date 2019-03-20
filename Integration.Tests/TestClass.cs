using System.Collections.Generic;
using System.Linq;
using Integration.Tests.Base;
using NUnit.Framework;
using TDD_Practices.Controllers;
using TDD_Practices.Dal;
using TDD_Practices.Dal.Factories;
using TDD_Practices.Handlers;
using TDD_Practices.Models;
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
      var controller = Container.GetInstance<ProjectController>();
      var actualResult = controller.GetProjectsList();

      Assert.IsTrue(((IEnumerable<Project>)actualResult.Model).Count() == 10);
    }

    //TODO:: Add test about ID. Use Hardcode :)
  }
}
