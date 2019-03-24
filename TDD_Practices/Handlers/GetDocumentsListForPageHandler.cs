using System.Collections.Generic;
using TDD_Practices.Data.Repositories;
using TDD_Practices.Models;
using TDD_Practices.Requests;
using TDD_Practices.Utils;

namespace TDD_Practices.Handlers
{
  public class GetDocumentsListWithPaginationHandler : RequestHandlerBase<GetDocumentsListWithPaginationRequest, IEnumerable<Document>>
  {
    public GetDocumentsListWithPaginationHandler(IDocumentRepository documentRepository)
    {
      _documentRepository = documentRepository;
    }

    protected override IEnumerable<Document> Handle(GetDocumentsListWithPaginationRequest request)
    {
      var itemsOnPage = request.ItemsOnPage ?? AppSettingsManager.GetIntegerOrDefault("defaultItemsOnPage", 20);
      return _documentRepository.GetWithPagination(request.PageNumber, itemsOnPage);
    }

    private readonly IDocumentRepository _documentRepository;
  }
}