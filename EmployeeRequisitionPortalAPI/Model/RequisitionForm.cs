using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeRequisitionPortal.Model
{
    public class RequisitionForm
    {
        public long RequisitionFormId { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
        public string PrimarySkills { get; set; }
        public string SecondarySkills { get; set; }
        [AllowNull]
        public double BudgetLowerRange { get; set; }
        [AllowNull]
        public double BudgetUpperRange { get; set; }
        public short ExperienceNeeded { get; set; }
        public short NumberOfEmployees { get; set; }
        public bool IsContract { get; set; }
        public int StatusId { get; set; }//reference Status table
        public Status Status { get; set; }
        [Display(Name = "CreatedBy")]
        public string UserId { get; set; } // reference Employee
        [ForeignKey("UserId")]
        public Employee Employees { get; set; }
        public DateTime CreatedDate { get; set; }
        //public string UserId { get; set; }// reference Employee
        //public Employee EmployeeUpdated { get; set; }
        //public DateTime UpdatedDate { get; set; }
        public ICollection<RequisitionFormWorkflow> RequisitionFormWorkflows { get; set; }
    }
}