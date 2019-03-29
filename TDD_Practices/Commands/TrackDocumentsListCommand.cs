using System.Collections.Generic;
using Tdd.Models;

namespace TDD_Practices.Commands
{
  public class TrackDocumentsListCommand : ProjectBaseCommand<IEnumerable<Document>>
  {
    public TrackDocumentsListCommand() { }

    public TrackDocumentsListCommand(int projectId, List<int> documentIds = null) : base(projectId)
    {
      DocumentIds = documentIds ?? new List<int>();
    }

    public List<int> DocumentIds { get; set; }
  }
}