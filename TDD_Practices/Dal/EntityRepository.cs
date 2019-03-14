using System;
using System.Linq;

namespace TDD_Practices.Dal
{
  public abstract class EntityRepository<T> where T : Entity
  {
    public EntityRepository(RdLabDbContext context)
    {
      _context = context;
    }

    public IQueryable<T> GetAllQueriable()
    {
      return _context.Set<T>().AsNoTracking().AsQueryable();
    }

    protected readonly RdLabDbContext _context;
  }
}