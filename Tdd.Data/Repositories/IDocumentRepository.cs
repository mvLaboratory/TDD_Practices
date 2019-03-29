using System.Collections.Generic;
using Tdd.Models;

namespace Tdd.Data.Repositories
{
  public interface IDocumentRepository
  {
    IEnumerable<Document> GetAll();
    IEnumerable<Document> Get(List<int> ids);
    IEnumerable<Document> GetProjectDocuments(int projectId);
    IEnumerable<Document> GetProjectDocumentsByDocIds(int projectId, List<int> ids);
    IEnumerable<Document> GetWithPagination(int pageNumber, int itemsOnPage);
  }
}
