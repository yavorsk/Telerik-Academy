using Employees;
using NorthwindData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeesSP
{
    public partial class EmployeesSP : System.Web.UI.Page
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

        protected void GridViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedUserId = (int)this.GridViewEmployees.SelectedDataKey.Value;

            NorthwindEntities db = new NorthwindEntities();

            var currentEmpoloyee = new List<Employee>()
            {
                db.Employees.FirstOrDefault(emp => emp.EmployeeID == selectedUserId)
            };
            
            this.FormViewEmployee.DataSource = currentEmpoloyee;
            this.FormViewEmployee.DataBind();
        }
    }
}