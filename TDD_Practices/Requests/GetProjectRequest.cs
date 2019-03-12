using MediatR;
using TDD_Practices.Models;

namespace TDD_Practices.Requests
{
  public class GetProjectRequest: IRequest<Project>
  {
    public int Id { get; set; }
  }
}