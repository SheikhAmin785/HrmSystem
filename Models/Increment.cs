using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrmSystem.Models
{
    public class Increment
    {
        [key]
        public int IncrementID { get; set; }

        [Foreignkey("Employee")]
        public int EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }
        public decimal IncrementAmount { get; set; }


        [DataType(DataType.Date)]
        public DateTime IncrementDate { get; set; }
    }
}
