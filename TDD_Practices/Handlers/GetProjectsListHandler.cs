using System.Collections.Generic;
using MediatR;
using TDD_Practices.Data.Repositories;
using TDD_Practices.Models;
using TDD_Practices.Requests;

namespace TDD_Practices.Handlers
{
  public class GetProjectsListHandler : RequestHandlerBase<GetProjectsListRequest, IEnumerable<Project>>
  {
    public GetProjectsListHandler(IProjectRepository projectRepository)
    {
      _projectRepository = projectRepository;
    }

    protected override IEnumerable<Project> Handle(GetProjectsListRequest request)
    {
      return _projectRepository.GetAll();
    }

    private readonly IProjectRepository _projectRepository;
  }
}