using System.Collections.Generic;
using System.Linq;
using TDD_Practices.Models;

namespace TDD_Practices.Data.Repositories
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

    public IEnumerable<Document> GetWithPagination(int pageNumber, int itemsOnPage)
    {
      return GetAllQueryable().Skip(pageNumber * itemsOnPage).Take(itemsOnPage).ToList();
    }
  }
}