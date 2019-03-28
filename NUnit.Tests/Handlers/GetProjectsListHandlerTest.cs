using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using Tdd.Data.Repositories;
using Tdd.Models;
using TDD_Practices.Handlers;
using TDD_Practices.Requests;

namespace NUnit.Tests.Handlers
{
  [TestFixture]
  public class GetProjectsListHandlerTest
  {
    [Test]
    public void Handle_HappyPath()
    {
      //Arrange
      var projectRepo = MockRepository.GenerateMock<IProjectRepository>();
      var handler = new GetProjectsListHandler(projectRepo);

      var request = new GetProjectsListRequest();

      projectRepo.Expect(repo => repo.GetAll())
        .Repeat.Once()
        .Return(new List<Project> { new Project { Id = 1, Name = "test", Sum = 10 } });

      //Act
      var result = handler.CreateResponse(request);

      //Assert
      Assert.IsNotNull(result);
    }
  }
}
