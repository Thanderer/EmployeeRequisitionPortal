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
        public IActionResult AddDepartment(AddDepartmentDto departmentDto)
        {
            Department department = new Department()
            {
                DepartmentName = departmentDto.DepartmentName
            };
            _dbDepartment.Add(department);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateDepartment(AddDepartmentDto departmentDto)
        {
            var data = _dbDepartment.FindById(departmentDto.Id);
            if (data == null)
            {
                return NotFound();
            }

            data.DepartmentName = departmentDto.DepartmentName;
            _dbDepartment.UpdateData(data);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllDepartment()
        {
            return Ok(_dbDepartment.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetDataById(int id)
        {
            var department = _dbDepartment.FindById(id);
            if (department == null)
                return NotFound();
            
            return Ok(department);
        }
        [HttpDelete]
        public IActionResult DeleteDepartment(int id)
        {
            if (_dbDepartment.FindById(id) == null)
            {
                return NotFound();
            }
            _dbDepartment.Delete(id);
            return Ok();
        }

    }
}
