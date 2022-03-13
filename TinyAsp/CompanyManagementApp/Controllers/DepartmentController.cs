using CompanyManagementApp.Models;
using System;
using System.Collections.Generic;

using TinyAsp.App;

namespace CompanyManagementApp.Controllers
{
    [Route("api/departments")]
    public class DepartmentController : Controller
    {
        [HttpGet]
        public ActionResult GetAllDepartments()
        {
            var departments = new List<DepartmentDto>
            {
                new DepartmentDto
                {
                    Id = Guid.NewGuid(),
                    Name = "IT Department",
                    Description = "IT Department"
                }
            };

            return Ok(departments);
        }
    }
}
