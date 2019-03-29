using System.Collections.Generic;
using MediatR;
using Tdd.Models;
using TDD_Practices.Commands;

namespace TDD_Practices.Requests
{
  public class GetDocumentsListRequest : ProjectBaseRequest<IEnumerable<Document>>
  {
    public GetDocumentsListRequest() { }
  }
}