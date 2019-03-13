using System.Collections.Generic;
using System.Linq;
using TDD_Practices.Dal.Factories;
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
      return _context.Projects.FirstOrDefault(proj => proj.Id == id);
    }

    public IEnumerable<Project> GetAll()
    {
      return _context.Projects.ToList();
    }
  }
}