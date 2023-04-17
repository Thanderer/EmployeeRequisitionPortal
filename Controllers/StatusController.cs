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
        [HttpPut]
        public IActionResult UpdateStatus(Status status) 
        {
            Status statusData = _dbStatus.FindById(status.StatusId);
            if(statusData == null)
            {
                return NotFound();
            }
            statusData.StatusName = status.StatusName;
            _dbStatus.UpdateData(statusData);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteStatus(int statusId)
        {
            if(_dbStatus.FindById(statusId) == null)
            {
                return NotFound();
            }
            _dbStatus.Delete(statusId);
            return Ok();
        }
    }
}
