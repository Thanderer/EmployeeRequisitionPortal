using EmployeeRequisitionPortal.Model;
using EmployeeRequisitionPortal.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRequisitionPortal.Controllers
{
    [EnableCors("MyPolicy")]
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
        public IActionResult AddDepartment(DepartmentDto departmentDto)
        {
            Department department = new Department()
            {
                DepartmentName = departmentDto.DepartmentName
            };
            _dbDepartment.Add(department);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateDepartment(DepartmentDto departmentDto)
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
            var Data = _dbDepartment.FindAll();
            var DepartmentDtoData = Data.Select(x => new DepartmentDto
            {
                Id = x.DepartmentId,
                DepartmentName= x.DepartmentName
            }) ;
            return Ok(DepartmentDtoData);
        }
        [HttpGet("{id}")]
        public IActionResult GetDataById(int id)
        {
            var department = _dbDepartment.FindById(id);
            if (department == null)
                return NotFound();
            var DepartmentDtoData = new DepartmentDto
            {
                Id= department.DepartmentId,
                DepartmentName = department.DepartmentName
            };
            return Ok(DepartmentDtoData);
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
