using System.Collections.Generic;
using Tdd.Data.Repositories;
using Tdd.Models;
using TDD_Practices.Requests;
using TDD_Practices.Utils;

namespace TDD_Practices.Handlers
{
  public class GetDocumentsListWithPaginationHandler : RequestHandlerBase<GetDocumentsListWithPaginationRequest, IEnumerable<Document>>
  {
    public GetDocumentsListWithPaginationHandler(IDocumentRepository documentRepository, AppSettingManagerImplementation settingsImpl)
    {
      _documentRepository = documentRepository;
      _settingsImpl = settingsImpl;
    }

    protected override IEnumerable<Document> Handle(GetDocumentsListWithPaginationRequest request)
    {
      var itemsOnPage = request.ItemsOnPage ?? GetDefaultItemPage(20);
      return _documentRepository.GetWithPagination(request.PageNumber, itemsOnPage);
    }

    public virtual int GetDefaultItemPage(int defaultValue)
    {
      var result = _settingsImpl.GetIntegerOrDefault("defaultItemsOnPage", defaultValue);
      if (result > 1000 || result <= 0)
      {
        return defaultValue;
      }

      return result;
    }

    private readonly IDocumentRepository _documentRepository;
    private readonly AppSettingManagerImplementation _settingsImpl;
  }
}