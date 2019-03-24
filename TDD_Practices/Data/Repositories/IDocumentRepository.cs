using System.Collections.Generic;
using TDD_Practices.Models;

namespace TDD_Practices.Data.Repositories
{
  public interface IDocumentRepository
  {
    IEnumerable<Document> GetAll();
  }
}
