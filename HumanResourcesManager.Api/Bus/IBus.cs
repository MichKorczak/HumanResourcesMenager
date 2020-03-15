using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanResourcesManager.Api.Bus
{
	public interface IBus
	{
		Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
	}
}
