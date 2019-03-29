using Tdd.Data.Repositories;
using Tdd.Models;
using TDD_Practices.Requests;

namespace TDD_Practices.Handlers
{
  public class GetProjectsHandler : RequestHandlerBase<GetProjectRequest, Project>
  {
    public GetProjectsHandler(IProjectRepository projectRepository)
    {
      _projectRepository = projectRepository;
    }

    protected override Project Handle(GetProjectRequest request)
    {
      return _projectRepository.Get(request.ProjectId);
    }

    private readonly IProjectRepository _projectRepository;
  }
}