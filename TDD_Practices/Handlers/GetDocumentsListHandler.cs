using System.Collections.Generic;
using System.Linq;
using Tdd.Data.Repositories;
using Tdd.Models;
using TDD_Practices.Commands;
using TDD_Practices.Requests;

namespace TDD_Practices.Handlers
{
  public class GetDocumentsListHandler : RequestHandlerBase<GetDocumentsListRequest, IEnumerable<Document>>
  {
    public GetDocumentsListHandler(IDocumentRepository documentRepository)
    {
      _documentRepository = documentRepository;
    }

    protected override IEnumerable<Document> Handle(GetDocumentsListRequest request)
    {
      return _documentRepository.GetProjectDocuments(request.ProjectId);
    }

    private readonly IDocumentRepository _documentRepository;
  }
}