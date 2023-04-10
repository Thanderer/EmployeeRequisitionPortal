using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRequisitionPortal.Model
{
    public class Employee:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool IsHead { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; }
        public ICollection<RequisitionForm> RequisitionForms { get; set; }
        //public ICollection<RequisitionForm> RequisitionFormUB { get; set; }
        public ICollection<RequisitionFormWorkflow> AssignedTo { get; set; }
    }
}
