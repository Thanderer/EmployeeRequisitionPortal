namespace EmployeeRequisitionPortal.Model
{
    public class RQFormWorkFlowDto
    {
        public long? RequisitionFormId { get; set; }
        public int StatusId { get; set; }
        public string UserId { get; set; }
        public DateTime AssignedDate { get; set; } 
        public bool IsCurrent { get; set; }
    }
}
