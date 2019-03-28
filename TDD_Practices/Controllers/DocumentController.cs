using System.Collections.Generic;
using System.Web.Http;
using MediatR;
using Tdd.Models;
using TDD_Practices.Requests;

namespace TDD_Practices.Controllers
{
  public class DocumentController : ApiController
  {
    public DocumentController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    [Route("api/documents")]
    public IEnumerable<Document>GetAllDocuments()
    {
      var result = _mediator.Send(new GetDocumentsListRequest()).Result;
      return result;
    }

    [HttpGet]
    [Route("api/documents/page/{pageNumber:int}")]
    public IEnumerable<Document> GetAllForPage(int pageNumber)
    {
      var result = _mediator.Send(new GetDocumentsListWithPaginationRequest {PageNumber = pageNumber}).Result;
      return result;
    }

    [HttpGet]
    [Route("api/documents/search/{text}")]
    public IEnumerable<Document> Search(string text)
    {
      var result = _mediator.Send(new SearchDocumentsRequest { Text = text }).Result;
      return result;
    }

    private readonly IMediator _mediator;
  }
}
