using System.Collections.Generic;
using MediatR;
using Tdd.Models;

namespace TDD_Practices.Requests
{
  public class TrackDocumentsListRequest : ProjectBaseRequest<IEnumerable<Document>>
  {
    public TrackDocumentsListRequest() { }

    public TrackDocumentsListRequest(int projectId, List<int> documentIds)
    {
      DocumentIds = documentIds ?? new List<int>();
    }

    public List<int> DocumentIds { get; set; }
  }
}