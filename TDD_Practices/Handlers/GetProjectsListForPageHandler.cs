using System.Collections.Generic;
using TDD_Practices.Dal;
using TDD_Practices.Models;
using TDD_Practices.Requests;
using TDD_Practices.Utils;

namespace TDD_Practices.Handlers
{
  public class GetProjectsListForPageHandler : RequestHandlerBase<GetProjectsListForPageRequest, IEnumerable<Project>>
  {
    public GetProjectsListForPageHandler(IProjectRepository projectRepository)
    {
      _projectRepository = projectRepository;
    }

    protected override IEnumerable<Project> Handle(GetProjectsListForPageRequest request)
    {
      var itemsOnPage = request.ItemsOnPage ?? AppSettingsManager.GetIntegerOrDefault("defaultItemsOnPage", 20);
      return _projectRepository.GetAllProjectsOnPage(request.PageNumber, itemsOnPage);
    }

    private readonly IProjectRepository _projectRepository;
  }
}