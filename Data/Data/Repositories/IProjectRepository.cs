using System.Collections.Generic;
using TDD_Practices.Models;

namespace TDD_Practices.Data.Repositories
{
  public interface IProjectRepository
  {
    Project Get(int id);
    IEnumerable<Project> GetAll();
    IEnumerable<Project> GetAllProjectsOnPage(int pageNumber, int itemsOnPage);
  }
}
