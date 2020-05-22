using MyCompany.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompany.Core.Services.Communication.Resources
{
    public class EmployeeResource
    {
        public int EmployeeId { get; set; }
        public DateTime Birthday { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime HiredDate { get; set; }
        public ICollection<string> Titles { get; set; }
        public ICollection<int> Salaries { get; set; } 
        public ICollection<string> DepartmentId { get; set; }
    }
}
