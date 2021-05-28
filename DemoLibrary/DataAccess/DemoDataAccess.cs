using System.Collections.Generic;
using System.Linq;
using DemoLibrary.Models;

namespace DemoLibrary.DataAccess
{
	public class DemoDataAccess : IDataAccess
	{
		private List<PersonModel> PersonModels { get; set; } = new();

		public DemoDataAccess()
		{
			PersonModels.Add(new PersonModel { Id = 1, FirstName = "Khalid", LastName = "BOURZAYQ" });
			PersonModels.Add(new PersonModel { Id = 2, FirstName = "Khalil", LastName = "BOURZAYQ" });
			PersonModels.Add(new PersonModel { Id = 3, FirstName = "Jalal", LastName = "BOURZAYQ" });
			PersonModels.Add(new PersonModel { Id = 4, FirstName = "Moataz", LastName = "BOURZAYQ" });
		}

		public List<PersonModel> GetAll()
		{
			return PersonModels;
		}

		public PersonModel Add(string firstName, string lastName)
		{
			PersonModel model = new() { Id = PersonModels.Max(x => x.Id) + 1,
										FirstName = firstName, LastName = lastName };
			PersonModels.Add(model);
			return model;
		}
	}
}