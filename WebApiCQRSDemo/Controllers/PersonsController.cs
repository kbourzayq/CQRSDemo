using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoLibrary.Commands;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiCQRSDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public PersonsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		// GET: api/<PersonsController>
		[HttpGet]
		public async Task<IEnumerable<PersonModel>> Get()
		{
			return await _mediator.Send(new GetPersonListQuery());
		}

		// GET api/<PersonsController>/5
		[HttpGet("{id}")]
		public async Task<PersonModel> Get(int id)
		{
			return await _mediator.Send(new GetPersonByIdQuery(id));
		}

		// POST api/<PersonsController>
		[HttpPost]
		public async Task<PersonModel> Post([FromBody] PersonModel person)
		{
			return await _mediator.Send(new InsertPersonCommand(person.FirstName, person.LastName));
		}
	}
}
