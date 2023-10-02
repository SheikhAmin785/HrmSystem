using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrmSystem.Models
{
    public class Company
    {
        [key]
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }

    }
}
