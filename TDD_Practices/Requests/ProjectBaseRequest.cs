using MediatR;

namespace TDD_Practices.Requests
{
  public class ProjectBaseRequest<T> : IRequest<T>
  {
    public int ProjectId { get; set; }
  }
}