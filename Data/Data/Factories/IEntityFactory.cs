using TDD_Practices.Models;

namespace TDD_Practices.Data.Factories
{
  public interface IEntityFactory
  {
    Project GetProject();
    DocumentIndex GetDocIndex(int documentId);
  }
}