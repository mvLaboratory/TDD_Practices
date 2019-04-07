using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;
using Tdd.Data.Repositories;
using Tdd.Models;
using TDD_Practices.Handlers;
using TDD_Practices.Requests;
using TDD_Practices.Utils;

namespace NUnit.Tests.Handlers
{
  [TestFixture]
  class GetDocumentsListWithPaginationHandlerTest
  {
    [SetUp]
    public void SetUp()
    {
      _repo = MockRepository.GenerateMock<IDocumentRepository>();
      _settingsManager = MockRepository.GenerateMock<AppSettingManagerImplementation>();

      _handler = new GetDocumentsListWithPaginationHandler(_repo, _settingsManager);
    }

    [Test]
    public void Handle_HappyPath()
    {
      //Arrange
      var expectedResult = new List<Document>
      {
        new Document(), new Document()
      };

      var request = new GetDocumentsListWithPaginationRequest
      {
        PageNumber = 5,
        ItemsOnPage = 10
      };
      _repo.Expect(repo => 
          repo.GetWithPagination(
            Arg<int>.Matches((par) => CheckItemsOnPage(par)), 
          Arg<int>.Is.Equal(request.ItemsOnPage)))
        .Repeat.Once()
        .Return(expectedResult);

      //Act
       _handler.CreateResponse(request);

      //Assert
      _repo.VerifyAllExpectations();
    }

   private bool CheckItemsOnPage(int parameter)
    {
      return parameter == 5;
    }

    [Test]
    [TestCase(10)]
    [TestCase(20)]
    public void GetDefaultItemPage_Success(int itemsCountToReturn)
    {
      //Arrange
      var expectedResult = itemsCountToReturn;
      _settingsManager.Stub(manager =>
          manager.GetIntegerOrDefault(Arg<string>.Is.Equal("defaultItemsOnPage"), Arg<int>.Is.Anything))
        .Repeat.Once()
        .Return(itemsCountToReturn);

      //Act
      var actualResult = _handler.GetDefaultItemPage(20);

      //Assert
      Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    [TestCase(-1, 20)]
    [TestCase(0, 10)]
    [TestCase(10000000, 10)]
    public void GetDefaultItemPage_Fail(int itemsCountToReturn, int defaultValue)
    {
      var expectedResult = defaultValue;
      _settingsManager.Stub(manager =>
          manager.GetIntegerOrDefault(Arg<string>.Is.Equal("defaultItemsOnPage"), Arg<int>.Is.Equal(defaultValue)))
        .Repeat.Once()
        .Return(defaultValue);

      //Act
      var actualResult = _handler.GetDefaultItemPage(defaultValue);

      //Assert
      Assert.AreEqual(expectedResult, actualResult);
    }

    private IDocumentRepository _repo;
    private AppSettingManagerImplementation _settingsManager;
    private GetDocumentsListWithPaginationHandler _handler;
  }
}
