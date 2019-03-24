using TDD_Practices.Data.Repositories;
using TDD_Practices.Models;
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
      return _projectRepository.Get(request.Id);
    }

    private readonly IProjectRepository _projectRepository;
  }
}