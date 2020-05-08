using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompany.Core.Models.Entities
{
    public class DepartmentEmployee
    {
        public int EmployeeId { get; set; }
        public Employee Employees { get; set; }
        public int DepartmentId { get; set; }
        public Department Departments { get; set; }
    }
}
