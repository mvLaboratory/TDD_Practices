﻿using System.Configuration;
using System.Web;
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
    public ViewResult GetProject(int id)
    {
      var project = _mediator.Send(new GetProjectRequest { Id = id }).Result;
      if (project == null)
      {
        return View("~/Views/Errors/NotFindView.cshtml");
        //throw new HttpException
        //return HttpNotFound($"Project with ID {id} not found");
      }

      return View(project);
    }

    [Route("")]
    [HttpGet]
    [ActionName("ProjectsList")]
    public ViewResult GetProjectsList()
    {
      var projects = _mediator.Send(new GetProjectsListRequest()).Result;
      return View(projects);
    }

    private readonly IMediator _mediator;
  }
}