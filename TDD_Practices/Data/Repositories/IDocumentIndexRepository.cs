using System.Collections.Generic;
using TDD_Practices.Models;

namespace TDD_Practices.Data.Repositories
{
  public interface IDocumentIndexRepository
  {
    IEnumerable<DocumentIndex> Search(string text);
  }
}
