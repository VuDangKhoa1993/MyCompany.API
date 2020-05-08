using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompany.Core.Models.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<DepartmentEmployee> DepartmentEmployees { get; set; }
    }
}
