using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TDD_Practices.Models;

namespace TDD_Practices.Dal
{
  public class ProjectRepository : EntityRepository<Project>, IProjectRepository
  {
    public ProjectRepository(RdLabDbContext context) : base(context)
    {
    }

    public Project Get(int id)
    {
      return GetAllQueriable().Include("Documents").FirstOrDefault(proj => proj.Id == id);
    }

    public IEnumerable<Project> GetAll()
    {
      return GetAllQueriable().ToList();
    }

    public IEnumerable<Project> GetAllProjectsOnPage(int pageNumber, int itemsOnPage)
    {
      return GetAllQueriable().Skip(pageNumber * itemsOnPage).Take(itemsOnPage).ToList();
    }
  }
}