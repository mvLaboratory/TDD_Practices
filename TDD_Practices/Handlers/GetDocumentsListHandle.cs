using System.Collections.Generic;
using Tdd.Data.Repositories;
using Tdd.Models;
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