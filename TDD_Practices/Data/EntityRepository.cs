using System.Linq;

namespace TDD_Practices.Data
{
  public abstract class EntityRepository<T> where T : Entity
  {
    protected EntityRepository(RdLabDbContext context)
    {
      _context = context;
    }

    public IQueryable<T> GetAllQueryable()
    {
      return _context.Set<T>().AsNoTracking().AsQueryable();
    }

    protected readonly RdLabDbContext _context;
  }
}