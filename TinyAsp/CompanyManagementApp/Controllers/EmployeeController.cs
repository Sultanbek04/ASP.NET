using CompanyManagementApp.Models;

using System;
using System.Collections.Generic;

using TinyAsp.App;


namespace CompanyManagementApp.Controllers {
	[Route("api/employees")]
	public class EmployeeController : Controller {
		public List<CreateEmployeeRq> Employees = new();

		[HttpPost]
		public ActionResult CreateEmployee([FromBody] CreateEmployeeRq request) {
			var employee = new CreateEmployeeRq();
			employee.Email = request.Email;
			employee.FullName = request.FullName;
			employee.PhoneNumber = request.PhoneNumber;

			Employees.Add(employee);

			return Ok(employee);
		}
		/*
	*  { 
	*     "FullName" : "Askar Umiraliev",
	*     "Email" : "askar.u@nu.edu",
	*     "PhoneNumber" : ""
	*  }
	*  
	*  XML
	*  
	*  <Employee>
	*      <FullName>Askar Umiraliev</FullName>
	*      <Email>askar.u@nu.edu</Email>
	*  </Employee>
	* 
	*/

		// Model binding
	}
}
