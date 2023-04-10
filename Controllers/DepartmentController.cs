using EmployeeRequisitionPortal.Model;
using EmployeeRequisitionPortal.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRequisitionPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IRepository<Department> _dbDepartment;

        public DepartmentController(IRepository<Department> dbDepartment)
        {
            _dbDepartment = dbDepartment;
        }
        [HttpPost]
        public IActionResult AddDepartment(Department department)
        {
            _dbDepartment.Add(department);
            return Ok();
        }

    }
}
