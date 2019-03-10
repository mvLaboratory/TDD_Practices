using MediatR;
using System.Web.Mvc;
using TDD_Practices.Dal;
using TDD_Practices.Models;

namespace TDD_Practices.Controllers
{
  [RoutePrefix("project")]
  public class ProjectController : Controller
  {
    public ProjectController(IMediator mediator, IProjectRepository repo)
    {
      _repo = repo;
      _mediator = new Mediator();
    }

    [Route("{id:int}")]
    public Project Get(int id)
    {
      //_mediator.Send()
      return _repo.Get(id);
    }

    private readonly IProjectRepository _repo;
    private readonly IMediator _mediator;
  }
}