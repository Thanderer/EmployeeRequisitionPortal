using EmployeeRequisitionPortal.Model;
using EmployeeRequisitionPortal.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRequisitionPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IRepository<Status> _dbStatus;

        public StatusController(IRepository<Status> dbStatus)
        {
            _dbStatus = dbStatus;
        }
        [HttpPost]
        public IActionResult AddStatus(Status status)
        {
            _dbStatus.Add(status);
            return Ok();    
        }
        [HttpGet("{id}")]
        public IActionResult GetStatusById(int id)
        {
            var status = _dbStatus.FindById(id);
            if (status == null)
            {
                return NotFound();
            }
            return Ok(status);
        }

        [HttpGet]
        public IActionResult GetAllStatus()
        {
            return Ok(_dbStatus.FindAll());
        }
    }
}
