using System.Collections.Generic;
using MediatR;
using TDD_Practices.Models;

namespace TDD_Practices.Requests
{
  public class GetDocumentsListRequest : IRequest<IEnumerable<Document>>
  {
  }
}