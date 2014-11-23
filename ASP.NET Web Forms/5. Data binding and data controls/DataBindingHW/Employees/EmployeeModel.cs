using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employees
{
    public class EmployeeModel
    {
        public EmployeeModel(int id, string fullName)
        {
            this.EmployeeID = id;
            this.FullName = fullName;
        }

        public int EmployeeID { get; set; }
        public string FullName { get; set; }
    }
}