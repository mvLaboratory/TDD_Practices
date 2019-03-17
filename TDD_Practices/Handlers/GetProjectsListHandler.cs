using System.Collections.Generic;
using MediatR;
using TDD_Practices.Dal;
using TDD_Practices.Models;
using TDD_Practices.Requests;

namespace TDD_Practices.Handlers
{
  public class GetProjectsListHandler : RequestHandler<GetProjectsListRequest, IEnumerable<Project>>
  {
    public GetProjectsListHandler(IProjectRepository projectRepository)
    {
      _projectRepository = projectRepository;
    }

    public IEnumerable<Project> CreateResponse(GetProjectsListRequest request)
    {
      return Handle(request);
    }

    protected override IEnumerable<Project> Handle(GetProjectsListRequest request)
    {
      return _projectRepository.GetAll();
    }

    private readonly IProjectRepository _projectRepository;
  }
}