using System.Collections.Generic;
using MediatR;
using Tdd.Models;

namespace TDD_Practices.Requests
{
  public class GetDocumentsListRequest : IRequest<IEnumerable<Document>>
  {
  }
}