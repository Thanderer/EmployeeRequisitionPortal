using EmployeeRequisitionPortal.Model;
using EmployeeRequisitionPortal.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EmployeeRequisitionPortal.Controllers
{
    [EnableCors("MyPolicy")]
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
                UserId = "8097E610-3EE2-47A1-9F3C-D61D1962C588"
            };
            _dbRequiitionForm.Add(requisition);
            var formId = requisition.RequisitionFormId;
            RequisitionFormWorkflow requisitionFormWorkflow = new RequisitionFormWorkflow
            {
                RequisitionFormId = formId,
                StatusId = 1,
                UserId = "8097E610-3EE2-47A1-9F3C-D61D1962C588",
                AssignedDate = DateTime.Now,
                IsCurrent = true,
                StatusComment = string.Empty
            };
            //Add requisitionWorkFlow here find using userId in requisitionForm
            //var formId = _dbRequiitionForm;
            _dbRequisitionFormWorkflow.Add(requisitionFormWorkflow);
            return Ok();
        }
        [HttpGet("GetAllForm")]
        public IActionResult GetAllRequisitionForm()
        {
            var data = _dbRequiitionForm.FindAll();
            var RequitionFormDtoData= data.Select(x => new RequiitionFormGetByIDto()
            {
                JobTitle = x.JobTitle,
                Description = x.Description,
                Department = x.Department,
                PrimarySkills = x.PrimarySkills,
                SecondarySkills = x.SecondarySkills,
                ExperienceNeeded = x.ExperienceNeeded,
                NumberOfEmployees = x.NumberOfEmployees,
                IsContract = x.IsContract,
                StatusId = x.StatusId
            });

            return Ok(RequitionFormDtoData);
        }
        [HttpGet("{id}")]
        public IActionResult GetRequisitionFormById(long id)
        {
            var data = _dbRequiitionForm.FindById(id);
            if (data == null)
            {
                return NotFound();
            }
            var REFormDtoData = new RequiitionFormGetByIDto
            {
                RequisitionFormId = data.RequisitionFormId,
                JobTitle = data.JobTitle,
                Description = data.Description,
                Department = data.Department,
                PrimarySkills = data.PrimarySkills,
                SecondarySkills = data.SecondarySkills,
                ExperienceNeeded = data.ExperienceNeeded,
                NumberOfEmployees = data.NumberOfEmployees,
                IsContract = data.IsContract,  
                StatusId = data.StatusId
            };
            return Ok(REFormDtoData);// pass dto insted data done
        }
        [HttpPut("updateRequisitionForm")]
        public IActionResult UpdateRequisitionForm(UpdateRequisitionFormDto updatedData)
        {
            var FormData = _dbRequiitionForm.FindById(updatedData.RequisitionFormId);
            if (FormData == null)
            {
                return NotFound();
            }
            FormData.JobTitle = updatedData.JobTitle;
            FormData.Description = updatedData.Description;
            FormData.Department = updatedData.Department;
            FormData.NumberOfEmployees = updatedData.NumberOfEmployees;
            FormData.IsContract = updatedData.IsContract;
            FormData.PrimarySkills = updatedData.PrimarySkills;
            FormData.SecondarySkills = updatedData.SecondarySkills;
            FormData.ExperienceNeeded = updatedData.ExperienceNeeded;
            FormData.StatusId = 1002;
            _dbRequiitionForm.UpdateData(FormData);
            return Ok();
        }
        [HttpPut("updateStatus")]
        public IActionResult UpdateRQFormStatus(UpdateStatusRQFormDto updateStatusRQFormDto)
        {
            //form UI name of status should be returned so from status name find id and then update requisitionform
            var FormData = _dbRequiitionForm.FindById(updateStatusRQFormDto.Id);
            if (FormData == null)
            {
                return NotFound();
            }

            FormData.StatusId = updateStatusRQFormDto.StatusId;
            _dbRequiitionForm.UpdateData(FormData);
            RequisitionFormWorkflow requisitionFormWorkflow = new RequisitionFormWorkflow
            {

            };
            return Ok();
        }

        [HttpPut("addBudget")]
        public IActionResult AddRQFormBudget(AddBudgetRQFormDto addedBudget)
        {
            var FormData = _dbRequiitionForm.FindById(addedBudget.Id);
            if (FormData == null)
            {
                return NotFound();
            }

            FormData.BudgetLowerRange = addedBudget.BudgetLowerRange;
            FormData.BudgetUpperRange = addedBudget.BudgetUpperRange;
            _dbRequiitionForm.UpdateData(FormData);
            return Ok();
        }
    }
}
