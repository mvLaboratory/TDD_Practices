using System.Collections.Generic;
using System.Web.Http;
using MediatR;
using TDD_Practices.Models;
using TDD_Practices.Requests;

namespace TDD_Practices.Controllers
{
  [Route("api/documents")]
  public class DocumentController : ApiController
  {
    public DocumentController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    [Route("")]
    public IEnumerable<Document>GetAllDocuments()
    {
      var result = _mediator.Send(new GetDocumentsListRequest()).Result;
      return result;
    }

    [HttpGet]
    [Route("page/{pageNumber:int}")]
    public IEnumerable<Document> GetAllForPage(int pageNumber)
    {
      var result = _mediator.Send(new GetDocumentsListWithPaginationRequest {PageNumber = pageNumber}).Result;
      return result;
    }

    private readonly IMediator _mediator;
  }
}
