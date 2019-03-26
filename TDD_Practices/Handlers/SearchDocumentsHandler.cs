using System.Collections.Generic;
using System.Linq;
using TDD_Practices.Data.Repositories;
using TDD_Practices.Models;
using TDD_Practices.Requests;

namespace TDD_Practices.Handlers
{
  public class SearchDocumentsHandler : RequestHandlerBase<SearchDocumentsRequest, IEnumerable<Document>>
  {
    public SearchDocumentsHandler(IDocumentIndexRepository docIndexRepo, IDocumentRepository documentRepository)
    {
      _documentRepository = documentRepository;
      _docIndexRepo = docIndexRepo;
    }

    protected override IEnumerable<Document> Handle(SearchDocumentsRequest request)
    {
      var ids = _docIndexRepo.Search(request.Text).Select(index => index.DocumentId).ToList();
      return _documentRepository.Get(ids);
    }

    private readonly IDocumentRepository _documentRepository;
    private readonly IDocumentIndexRepository _docIndexRepo;
  }
}