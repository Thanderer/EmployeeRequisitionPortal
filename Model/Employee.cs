using Microsoft.AspNetCore.Identity;

namespace EmployeeRequisitionPortal.Model
{
    public class Employee:IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
