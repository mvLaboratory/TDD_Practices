using MediatR;

namespace TDD_Practices.Handlers
{
  public abstract class RequestHandlerBase<TRequest, TResponse> : RequestHandler<TRequest, TResponse>, IRequestHandler where TRequest : IRequest<TResponse>
  {
    protected abstract override TResponse Handle(TRequest request);

    public TResponse CreateResponse(TRequest request)
    {
      return Handle(request);
    }
  }
}