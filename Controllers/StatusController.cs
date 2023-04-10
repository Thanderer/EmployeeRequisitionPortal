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
    }
}
