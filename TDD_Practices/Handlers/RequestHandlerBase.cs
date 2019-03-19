using MediatR;

namespace TDD_Practices.Handlers
{
  public abstract class RequestHandlerBase<T, TR> : RequestHandler<T, TR> where T : IRequest<TR>
  {
    protected abstract override TR Handle(T request);

    public TR CreateResponse(T request)
    {
      return Handle(request);
    }
  }
}