using System.Linq;
using Tdd.Models;

namespace Tdd.Data
{
  public abstract class EntityRepository<T> where T : Entity
  {
    protected EntityRepository(RdLabDbContext context)
    {
      Context = context;
    }

    public IQueryable<T> GetAllQueryable()
    {
      return Context.Set<T>().AsNoTracking().AsQueryable();
    }

    protected readonly RdLabDbContext Context;
  }
}