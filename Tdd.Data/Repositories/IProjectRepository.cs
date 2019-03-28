using System.Collections.Generic;
using Tdd.Models;

namespace Tdd.Data.Repositories
{
  public interface IProjectRepository
  {
    Project Get(int id);
    IEnumerable<Project> GetAll();
    IEnumerable<Project> GetAllProjectsOnPage(int pageNumber, int itemsOnPage);
  }
}
