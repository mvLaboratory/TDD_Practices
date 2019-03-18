﻿using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using TDD_Practices.Dal;
using TDD_Practices.Handlers;
using TDD_Practices.Models;
using TDD_Practices.Requests;

namespace NUnit.Tests
{
  [TestFixture]
  public class GetProjectsListHandlerTest
  {
    [Test]
    public void TestsMethod()
    {
      //Arrange
      var projectRepo = MockRepository.GenerateMock<IProjectRepository>();
      var handler = new GetProjectsListHandler(projectRepo);

      var request = new GetProjectsListRequest();

      projectRepo.Expect(repo => repo.GetAll())
        .Repeat.Once()
        .Return(new List<Project> {new Project {Id = 1, Name = "test", Summ = 10}});

      //Act
      var result = handler.CreateResponse(request);

      //Assert
      Assert.IsNotNull(result);
    }
  }
}
