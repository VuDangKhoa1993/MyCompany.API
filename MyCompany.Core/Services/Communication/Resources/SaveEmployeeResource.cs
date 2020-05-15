using MyCompany.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompany.Core.Services.Communication.Resources
{
    public class SaveEmployeeResource
    {
        public DateTime Birthday { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime HiredDate { get; set; }
        public ICollection<SaveTitleResource> Titles { get; set; }
        public ICollection<SaveSalariesResource> Salaries { get; set; }
    }
}
