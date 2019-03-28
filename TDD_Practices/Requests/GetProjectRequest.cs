using MediatR;
using Tdd.Models;

namespace TDD_Practices.Requests
{
  public class GetProjectRequest: IRequest<Project>
  {
    public int Id { get; set; }
  }
}