using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrmSystem.Models
{
    public class Employee
    {
        

        [key]
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }



        [Foreignkey("Company")]
        public int CompanyID { get; set; }
        public virtual Company Companies { get; set; }


        [Foreignkey("Department")]
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }

        [Foreignkey("Designation")]
        public int DesignationID { get; set; }
        public virtual Designation Designation { get; set; }

        public decimal Salary { get; set; }


        [DataType(DataType.Date)]

        public DateTime JoiningDate { get; set; }
        public object Company { get; internal set; }
    }
}
