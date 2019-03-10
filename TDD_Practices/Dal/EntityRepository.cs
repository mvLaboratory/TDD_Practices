using System.Collections.Generic;
using System.Linq;
using Antlr.Runtime.Misc;

namespace TDD_Practices.Dal
{
  public abstract class EntityRepository<T> where T : Entity
  {
    public IQueryable<T> GetAllQueriable()
    {
      return db.AsQueryable();
    }

    protected void Initialize(Func<Entity> entityCreator, int count)
    {
      for (int i = 0; i < count; i++)
      {
        db.Add((T)entityCreator());
      }
    }

    protected List<T> db = new List<T>();
  }
}