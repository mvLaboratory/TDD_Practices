using TDD_Practices.Dal.Factories;

namespace TDD_Practices.Dal
{
  public class DbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RdLabDbContext>
  {
    public DbInitializer()
    {
      _factory = new EntityFactory();
    }

    protected override void Seed(RdLabDbContext context)
    {
      for (int i = 0; i < 500; i++)
      {
        context.Projects.Add(_factory.GetProject());
      }

      context.SaveChanges();
    }

    private readonly IEntityFactory _factory;
  }
}