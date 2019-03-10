using TDD_Practices.Models;

namespace TDD_Practices.Dal
{
  public interface IProjectRepository
  {
    Project Get(int id);
  }
}
