using System.Collections.Generic;
using System.Linq;
using Integration.Tests.Base;
using NUnit.Framework;
using TDD_Practices.Controllers;
using TDD_Practices.Data.Factories;
using TDD_Practices.Models;

namespace Integration.Tests.Controller
{
  [TestFixture]
  public class ProjectControllerTest : BaseIntegrationFixture
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
    public void GetProjectsList_HappyPath()
    {
      var controller = Container.GetInstance<ProjectController>();
      var actualResult = controller.GetProjectsList();

      Assert.IsTrue(((IEnumerable<Project>)actualResult.Model).Count() == 10);
    }

    [Test]
    public void GetProjectById_HappyPath()
    {
      var controller = Container.GetInstance<ProjectController>();
      var actualResult = controller.GetProject(124);

      Assert.IsTrue(((IEnumerable<Project>)actualResult.Model).Count() == 10);
    }
  }
}
