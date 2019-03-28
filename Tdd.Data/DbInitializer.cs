using System.Collections.Generic;
using System.Linq;
using Tdd.Data.Factories;
using Tdd.Models;
using TDD_Practices.Data.Factories;

namespace Tdd.Data
{
  public class DbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RdLabDbContext>
  {
    public DbInitializer()
    {
      _factory = new EntityFactory();
    }

    protected override void Seed(RdLabDbContext context)
    {
      var projects = new List<Project>();
      for (int i = 0; i < 15; i++)
      {
        var proj = _factory.GetProject();
        context.Projects.Add(proj);
        projects.Add(proj);
      }

      context.SaveChanges();
      projects.ForEach(proj => proj.Documents.ToList().ForEach(doc => context.DocumentIndex.Add(_factory.GetDocIndex(doc.Id))));
      context.SaveChanges();
    }

    private readonly IEntityFactory _factory;
  }
}