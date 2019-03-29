using System.Collections.Generic;
using Tdd.Data.Repositories;
using Tdd.Models;
using TDD_Practices.Commands;

namespace TDD_Practices.Handlers
{
  public class TrackDocumentsListHandler : RequestHandlerBase<TrackDocumentsListCommand, IEnumerable<Document>>
  {
    public TrackDocumentsListHandler(IDocumentRepository documentRepository)
    {
      _documentRepository = documentRepository;
    }

    protected override IEnumerable<Document> Handle(TrackDocumentsListCommand request)
    {
      var documentsToTrack = _documentRepository.GetProjectDocumentsByDocIds(request.ProjectId, request.DocumentIds);

      //Some cool logic for tracking documents
      //...
      //
      return documentsToTrack;
    }

    private readonly IDocumentRepository _documentRepository;
  }
}