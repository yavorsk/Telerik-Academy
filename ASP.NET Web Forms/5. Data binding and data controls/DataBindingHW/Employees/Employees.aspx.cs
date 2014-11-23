using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NorthwindData;

namespace Employees
{
    public partial class Employees : System.Web.UI.Page
    {
        private List<EmployeeModel> employees = new List<EmployeeModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            NorthwindEntities db = new NorthwindEntities();

            var emps = db.Employees.ToList();

            foreach (var emp in emps)
            {
                this.employees.Add(new EmployeeModel(emp.EmployeeID, emp.FirstName + " " + emp.LastName));
            }

            if (!IsPostBack)
            {
                this.GridViewEmployees.DataSource = employees;
                this.GridViewEmployees.DataBind();
            }
        }

        protected void GridViewEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewEmployees.PageIndex = e.NewPageIndex;
            this.GridViewEmployees.DataSource = this.employees;
            this.GridViewEmployees.DataBind();
        }
    }
}