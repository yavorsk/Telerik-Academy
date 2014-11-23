using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NorthwindData;

namespace Employees
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["id"] == null)
            {
                Response.Redirect("Employees.aspx");
            }

            int employeeId = int.Parse(Request.Params["id"]);

            NorthwindEntities db = new NorthwindEntities();

            var currentEmpoloyee = new List<Employee>()
            {
                db.Employees.FirstOrDefault(emp => emp.EmployeeID == employeeId)
            };

            this.EmployeeDetailsView.DataSource = currentEmpoloyee;
            this.EmployeeDetailsView.DataBind();
        }

        protected void backLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employees.aspx");
        }
    }
}