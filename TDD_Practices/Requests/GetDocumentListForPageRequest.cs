using System.Collections.Generic;
using MediatR;
using Tdd.Models;

namespace TDD_Practices.Requests
{
  public class GetDocumentsListWithPaginationRequest : IRequest<IEnumerable<Document>>
  {
    public int PageNumber { get; set; }
    public int? ItemsOnPage { get; set; }
  }
}