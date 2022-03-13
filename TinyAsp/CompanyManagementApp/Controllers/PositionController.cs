using TinyAsp.App;

namespace CompanyManagementApp.Controllers
{
    public class PositionDto
    {
        public string Name { get; set; }
    }

    [Route("api/employees/positions")]
    public class PositionController : Controller
    {
        [HttpGet]
        public ActionResult GetEmployeePositions()
        {
            var positions = new PositionDto[]
            {
                new PositionDto{ Name = "Developer I"},
                new PositionDto{Name = "Developer II"},
                new PositionDto{Name = "Head of Department"},
                new PositionDto{Name = "Chief Technical Officer"}
            };

            return Ok(positions);
        }
    }
}
