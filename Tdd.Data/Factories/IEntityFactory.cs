using Tdd.Models;

namespace Tdd.Data.Factories
{
  public interface IEntityFactory
  {
    Project GetProject();
    DocumentIndex GetDocIndex(int documentId);
  }
}