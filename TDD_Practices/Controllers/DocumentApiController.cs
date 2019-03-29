using System.Collections.Generic;
using System.Web.Http;
using MediatR;
using Tdd.Models;
using Tdd.Models.Dto;
using TDD_Practices.Commands;
using TDD_Practices.Requests;

namespace TDD_Practices.Controllers
{
  public class DocumentApiController : ApiController
  {
    public DocumentApiController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    [Route("api/{projectId:int}/documents")]
    public IEnumerable<Document>GetAllDocuments(int projectId)
    {
      var result = _mediator.Send(new GetDocumentsListRequest {ProjectId = projectId}).Result;
      return result;
    }

    [HttpPost]
    [Route("api/{projectId:int}/documents/tracked")]
    public IEnumerable<Document> TrackDocuments(int projectId, [FromBody]IdListDto docIds)
    {
      var result = _mediator.Send(new TrackDocumentsListCommand { ProjectId = projectId, DocumentIds = docIds.Ids }).Result;
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
