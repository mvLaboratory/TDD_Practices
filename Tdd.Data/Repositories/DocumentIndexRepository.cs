using System.Collections.Generic;
using System.Linq;
using Tdd.Models;

namespace Tdd.Data.Repositories
{
  public class DocumentIndexRepository : EntityRepository<DocumentIndex>, IDocumentIndexRepository
  {
    public DocumentIndexRepository(RdLabDbContext context) : base(context)
    {
    }

    public IEnumerable<DocumentIndex> Search(string text)
    {
      return GetAllQueryable().Where(index => index.DocText.Contains(text)).ToList();
    }
  }
}