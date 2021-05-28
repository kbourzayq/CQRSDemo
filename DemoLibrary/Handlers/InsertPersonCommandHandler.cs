using System.Threading;
using System.Threading.Tasks;
using DemoLibrary.Commands;
using DemoLibrary.DataAccess;
using DemoLibrary.Models;
using MediatR;

namespace DemoLibrary.Handlers
{
	public class InsertPersonCommandHandler : IRequestHandler<InsertPersonCommand,PersonModel>
	{
		private readonly IDataAccess _data;

		public InsertPersonCommandHandler(IDataAccess data)
		{
			_data = data;
		}
		public Task<PersonModel> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
		{
			PersonModel person = _data.Add(request.FirstName, request.LastName);
			return Task.FromResult(person);
		}
	}
}