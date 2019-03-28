using System.Collections.Generic;
using Tdd.Models;

namespace Tdd.Data.Repositories
{
  public interface IDocumentIndexRepository
  {
    IEnumerable<DocumentIndex> Search(string text);
  }
}
