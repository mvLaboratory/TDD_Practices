using System.Collections.Generic;
using MediatR;
using TDD_Practices.Models;

namespace TDD_Practices.Requests
{
  public class GetProjectsListForPageRequest : IRequest<IEnumerable<Project>>
  {
    public int PageNumber { get; set; }
    public int? ItemsOnPage { get; set; }
  }
}