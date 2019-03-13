using System.Configuration;
using MediatR;
using System.Web.Mvc;
using TDD_Practices.Requests;

namespace TDD_Practices.Controllers
{
  [RoutePrefix("project")]
  public class ProjectController : Controller
  {
    public ProjectController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [Route("{id:int}")]
    [HttpGet]
    [ActionName("Project")]
    public ActionResult GetProject(int id)
    {
      var project = _mediator.Send(new GetProjectRequest { Id = id }).Result;
      if (project == null)
      {
        return HttpNotFound($"Project with ID {id} not found");
      }

      var test = ConfigurationManager.AppSettings.Get("Env");
      return View(project);
    }

    [Route("")]
    [HttpGet]
    [ActionName("ProjectsList")]
    public ActionResult GetProjectsList()
    {
      var projects = _mediator.Send(new GetProjectsListRequest()).Result;
      return View(projects);
    }

    private readonly IMediator _mediator;
  }
}