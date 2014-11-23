using NorthwindData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpInfoRepeater
{
    public partial class EmployeesInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NorthwindEntities db = new NorthwindEntities();

            List<Employee> employees = db.Employees.ToList();

            this.RepeaterEmployees.DataSource = employees;
            this.RepeaterEmployees.DataBind();
        }
    }
}