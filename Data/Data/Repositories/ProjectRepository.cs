using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TDD_Practices.Models;

namespace TDD_Practices.Data.Repositories
{
  public class ProjectRepository : EntityRepository<Project>, IProjectRepository
  {
    public ProjectRepository(RdLabDbContext context) : base(context)
    {
    }

    public Project Get(int id)
    {
      return GetAllQueryable().Include("Documents").FirstOrDefault(proj => proj.Id == id);
    }

    public IEnumerable<Project> GetAll()
    {
      return GetAllQueryable().ToList();
    }

    public IEnumerable<Project> GetAllProjectsOnPage(int pageNumber, int itemsOnPage)
    {
      return GetAllQueryable().Skip(pageNumber * itemsOnPage).Take(itemsOnPage).ToList();
    }
  }
}