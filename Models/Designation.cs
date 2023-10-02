using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrmSystem.Models
{
    public class Designation
    {
        [key]
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
    }
}
