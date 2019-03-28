using System.Collections.Generic;
using MediatR;
using Tdd.Models;

namespace TDD_Practices.Requests
{
  public class SearchDocumentsRequest : IRequest<IEnumerable<Document>>
  {
    public string Text { get; set; }
  }
}