﻿namespace EmployeeRequisitionPortal.Model
{
    public class UpdateRequisitionFormDto
    {
        public long RequisitionFormId { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
        public string PrimarySkills { get; set; }
        public string SecondarySkills { get; set; }
        public short ExperienceNeeded { get; set; }
        public short NumberOfEmployees { get; set; }
        public bool IsContract { get; set; }
    }
}
