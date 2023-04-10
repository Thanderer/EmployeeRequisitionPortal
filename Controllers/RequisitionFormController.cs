using EmployeeRequisitionPortal.Model;
using EmployeeRequisitionPortal.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRequisitionPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisitionFormController : ControllerBase
    {
        private readonly IRepository<RequisitionForm> _dbRequiitionForm;
        private readonly IRepository<RequisitionFormWorkflow> _dbRequisitionFormWorkflow;
        private readonly IRepository<Status> _dbStatus;

        public RequisitionFormController(IRepository<RequisitionForm> dbRequiitionForm, IRepository<Status> dbStatus, IRepository<RequisitionFormWorkflow> dbRequisitionFormWorkflow)
        {
            _dbRequiitionForm = dbRequiitionForm;
            _dbStatus = dbStatus;
            _dbRequisitionFormWorkflow = dbRequisitionFormWorkflow;
        }
        [HttpPost]
        public IActionResult RaieRequiition(RequisitionFormDto addedData)
        {
            // take email from payload store it in variable and from that find userId and add to requisition.UserId
            RequisitionForm requisition = new RequisitionForm
            {
                JobTitle = addedData.JobTitle,
                Description = addedData.Description,
                Department = addedData.Department,
                PrimarySkills = addedData.PrimarySkills,
                SecondarySkills = addedData.SecondarySkills,
                ExperienceNeeded = addedData.ExperienceNeeded,
                NumberOfEmployees = addedData.NumberOfEmployees,
                IsContract = addedData.IsContract,
                StatusId = 1,
                UserId = "BFB514E9-A8C3-4F99-B76D-99BC6FEEA118"
            };
            _dbRequiitionForm.Add(requisition);
            //Add requisitionWorkFlow here find using userId in requisitionForm
            //var formId = _dbRequiitionForm;

            return Ok();
        }
    }
}
