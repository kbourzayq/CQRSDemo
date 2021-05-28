using System.Collections.Generic;
using DemoLibrary.Models;

namespace DemoLibrary.DataAccess
{
	public interface IDataAccess
	{
		List<PersonModel> GetAll();
		PersonModel Add(string firstName, string lastName);
	}
}