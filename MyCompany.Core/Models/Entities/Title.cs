using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompany.Core.Models.Entities
{
    public class Title
    {
        public string Titles { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
