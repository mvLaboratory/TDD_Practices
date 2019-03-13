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
      throw new NotImplementedException();
      //return db.AsQueryable();
    }

    protected readonly RdLabDbContext _context;
  }
}