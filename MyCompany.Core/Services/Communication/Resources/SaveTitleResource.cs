using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompany.Core.Services.Communication.Resources
{
    public class SaveTitleResource
    {
        public string Titles { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
