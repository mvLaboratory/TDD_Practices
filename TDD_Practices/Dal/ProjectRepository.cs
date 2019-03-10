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
      return GetAllQueriable().Where(proj => proj.Id == id).FirstOrDefault();
    }
  }
}