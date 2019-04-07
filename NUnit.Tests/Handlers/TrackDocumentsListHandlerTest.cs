using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using Tdd.Data.Repositories;
using Tdd.Models;
using TDD_Practices.Commands;
using TDD_Practices.Handlers;

namespace NUnit.Tests.Handlers
{
  [TestFixture]
  public class TrackDocumentsListHandlerTest
  {
    [SetUp]
    public void SetUp()
    {
      _docRepo = MockRepository.GenerateMock<IDocumentRepository>();
      _handler = new TrackDocumentsListHandler(_docRepo);
    }

    [Test]
    public void Handle_HappyPath()
    {
      //Arrange
      var projectId = 1;
      var expectedResult = new List<Document>
      {
        new Document { ProjectId = 1, Id = 1},
        new Document {ProjectId = 1, Id = 2},
        new Document {ProjectId = 1, Id = 3}
      };
      var requestedDocs = expectedResult.Select(docList => docList.Id).ToList();
      var command = new TrackDocumentsListCommand(projectId, requestedDocs);
      _docRepo.Expect(repo =>
          repo.GetProjectDocumentsByDocIds(Arg<int>.Is.Equal(projectId), Arg<List<int>>.Is.Equal(requestedDocs)))
        .Repeat.Once()
        .Return(expectedResult);


      //Act
      var actualResult = _handler.CreateResponse(command);

      //Assert
      CollectionAssert.AreEquivalent(expectedResult, actualResult);
      _docRepo.VerifyAllExpectations();
    }

    [Test]
    public void Handle_EmptyDocumentsIds_ConstructorInit_EmptyResult()
    {
      //Arrange
      var projectId = 1;
      var expectedResult = new List<Document>();
      var command = new TrackDocumentsListCommand(projectId);
      _docRepo.Expect(repo =>
          repo.GetProjectDocumentsByDocIds(Arg<int>.Is.Equal(projectId), Arg<List<int>>.Is.Equal(new List<int>())))
        .Repeat.Once()
        .Return(expectedResult);

      //Act
      var actualResult = _handler.CreateResponse(command);

      //Assert
      CollectionAssert.AreEquivalent(expectedResult, actualResult);
      _docRepo.VerifyAllExpectations();
    }

    [Test]
    public void Handle_EmptyDocumentsIds_BodyInit_ArgumentException()
    {
      //Arrange
      var projectId = 1;
      var expectedResult = new List<Document>();
      var command = new TrackDocumentsListCommand()
      {
        ProjectId = projectId
      };
      _docRepo.Expect(repo =>
          repo.GetProjectDocumentsByDocIds(Arg<int>.Is.Equal(projectId), Arg<List<int>>.Is.Equal(new List<int>())))
        .Repeat.Never();

      //Act //Assert
      //Assert.Throws<Exception>(() => _handler.CreateResponse(command));

      Assert.Catch<Exception>(() => _handler.CreateResponse(command));
    }

    [TearDown]
    public void TearDown()
    {
      _handler = null;
      _docRepo = null;
    }

    private IDocumentRepository _docRepo;
    private TrackDocumentsListHandler _handler;
  }
}
