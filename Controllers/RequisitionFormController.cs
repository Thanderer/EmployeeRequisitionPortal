﻿using EmployeeRequisitionPortal.Model;
using EmployeeRequisitionPortal.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
                UserId = "8097E610-3EE2-47A1-9F3C-D61D1962C588"
            };
            _dbRequiitionForm.Add(requisition);
            //Add requisitionWorkFlow here find using userId in requisitionForm
            //var formId = _dbRequiitionForm;

            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllRequisitionForm()
        {
            var data = _dbRequiitionForm.FindAll();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult GetRequisitionFormById(long id)
        {
            var data = _dbRequiitionForm.FindById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);// pass dto insted data
        }
        [HttpPut]
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
            if(FormData == null)
            {
                return NotFound();
            }

            FormData.StatusId = updateStatusRQFormDto.StatusId;
            _dbRequiitionForm.UpdateData(FormData);
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
