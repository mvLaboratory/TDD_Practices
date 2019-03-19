using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Integration.Tests.Base
{
  class MediatorFake : IMediator
  {
    public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = new CancellationToken())
    {
      throw new NotImplementedException();
    }

    public Task Publish(object notification, CancellationToken cancellationToken = new CancellationToken())
    {
      throw new NotImplementedException();
    }

    public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = new CancellationToken()) where TNotification : INotification
    {
      throw new NotImplementedException();
    }
  }
}
