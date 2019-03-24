using System.Collections.Generic;
using TDD_Practices.Data.Repositories;
using TDD_Practices.Models;
using TDD_Practices.Requests;

namespace TDD_Practices.Handlers
{
  public class GetDocumentsListHandle : RequestHandlerBase<GetDocumentsListRequest, IEnumerable<Document>>
  {
    public GetDocumentsListHandle(IDocumentRepository documentRepository)
    {
      _documentRepository = documentRepository;
    }

    protected override IEnumerable<Document> Handle(GetDocumentsListRequest request)
    {
      return _documentRepository.GetAll();
    }

    private readonly IDocumentRepository _documentRepository;
  }
}