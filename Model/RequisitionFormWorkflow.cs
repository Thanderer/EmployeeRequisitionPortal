using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRequisitionPortal.Model
{
    public class RequisitionFormWorkflow
    {
        public long RequisitionFormWorkflowId { get; set; }
        [Display(Name ="FormId")]
        public long? RequisitionFormId { get; set; }//reference requisition table
        public RequisitionForm RequisitionForm { get; set; }
        [Display(Name ="Status")]
        public int StatusId { get; set; }
        public Status status { get; set; }
        [Display(Name ="AssignedTo")]
        public string UserId { get; set; }//reference employee table
        [ForeignKey("UserId")]
        public Employee Employee { get; set; }
        public DateTime AssignedDate { get; set; }
        public string StatusComment { get; set; }
        public bool IsCurrent { get; set; }
    }
}