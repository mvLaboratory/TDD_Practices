using System.Collections.Generic;
using TDD_Practices.Data.Factories;
using TDD_Practices.Models;
using WebGrease.Css.Extensions;

namespace TDD_Practices.Data
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
      projects.ForEach(proj => proj.Documents.ForEach(doc => context.DocumentIndex.Add(_factory.GetDocIndex(doc.Id))));
      context.SaveChanges();
    }

    private readonly IEntityFactory _factory;
  }
}