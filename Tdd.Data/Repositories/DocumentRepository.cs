using System.Collections.Generic;
using System.Linq;
using Tdd.Models;

namespace Tdd.Data.Repositories
{
  public class DocumentRepository : EntityRepository<Document>, IDocumentRepository
  {
    public DocumentRepository(RdLabDbContext context) : base(context)
    {
    }

    public IEnumerable<Document> GetAll()
    {
      return GetAllQueryable().ToList();
    }

    public IEnumerable<Document> GetProjectDocuments(int projectId)
    {
      return GetAllQueryable().Where(doc => doc.Project.Id == projectId).ToList();
    }

    public IEnumerable<Document> GetProjectDocumentsByDocIds(int projectId, List<int> ids)
    {
      return GetAllQueryable().Where(doc => doc.Project.Id == projectId && ids.Contains(doc.Id)).ToList();
    }
    
    public IEnumerable<Document> Get(List<int> ids)
    {
      return GetAllQueryable().Where(doc => ids.Contains(doc.Id)).ToList();
    }

    public IEnumerable<Document> GetWithPagination(int pageNumber, int itemsOnPage)
    {
      return GetAllQueryable()
        .OrderByDescending(doc => doc.UpdateDate)
        .Skip(pageNumber * itemsOnPage)
        .Take(itemsOnPage)
        .ToList();
    }
  }
}