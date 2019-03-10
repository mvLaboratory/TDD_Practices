using System;
using TDD_Practices.Models;

namespace TDD_Practices.Dal.Factories
{
  public class EntityFactory : IEntityFactory
  {
    public Project GetProject()
    {
      var id = _randomizer.Next(2000000, 5000000);
      return new Project
      {
        Id = id,
        Name = $"Project {Guid.NewGuid()}",
        Summ = _randomizer.Next(1, 1000) * 10000
      };
    }

    private Random _randomizer = new Random();
  }
}