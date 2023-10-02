using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrmSystem.Models
{
    public class Department
    {
        [key]
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }

      
    }
}
