using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace HumanResourcesManager.Api.Bus
{
	public class MediatrBus : IBus
	{
		private readonly IMediator mediator;

		public MediatrBus(IMediator mediator)
		{
			this.mediator = mediator;
		}

		public Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
		{
			return mediator.Send(request, cancellationToken);
		}
	}
}
