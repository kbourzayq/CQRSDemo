using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;
using System.Linq;
namespace DemoLibrary.Handlers
{
	public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery,PersonModel>
	{
		private readonly IMediator _mediator;

		public GetPersonByIdHandler(IMediator mediator)
		{
			_mediator = mediator;
		}
		public async Task<PersonModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
		{
			List<PersonModel> results = await _mediator.Send(new GetPersonListQuery(), cancellationToken);
			return results.FirstOrDefault(x => x.Id == request.Id);
		}
	}
}