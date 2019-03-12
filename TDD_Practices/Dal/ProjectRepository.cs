using System.Collections.Generic;
using System.Linq;
using TDD_Practices.Dal.Factories;
using TDD_Practices.Models;

namespace TDD_Practices.Dal
{
  public class ProjectRepository : EntityRepository<Project>, IProjectRepository
  {
    public ProjectRepository(IEntityFactory factory)
    {
      Initialize(factory.GetProject, 50);
    }

    public Project Get(int id)
    {
      return GetAllQueriable().FirstOrDefault(proj => proj.Id == id);
    }

    public IEnumerable<Project> GetAll()
    {
      return GetAllQueriable().ToList();
    }
  }
}