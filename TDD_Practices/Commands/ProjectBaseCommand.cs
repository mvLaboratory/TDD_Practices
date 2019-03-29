using MediatR;

namespace TDD_Practices.Commands
{
  public class ProjectBaseCommand<T> : IRequest<T>
  {
    public ProjectBaseCommand()
    {
        
    }
    public ProjectBaseCommand(int id)
    {
      ProjectId = id;
    }

    public int ProjectId { get; set; }
  }
}