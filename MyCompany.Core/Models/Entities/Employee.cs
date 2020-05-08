using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompany.Core.Models.Entities
{
    public enum Gender
    {
        Male = 1,
        Female = 2
    }
    public class Employee
    {
        public int EmployeeId { get; set; }
        public DateTime Birthday { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime HiredDate { get; set; }
        public ICollection<Title> Titles { get; set; }
        public ICollection<Salaries> Salaries { get; set; }
        public ICollection<DepartmentEmployee> DepartmentEmployees { get; set; }
    }
}
