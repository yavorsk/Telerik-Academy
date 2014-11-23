using NorthwindData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpInfoListView
{
    public partial class EmpInfoListView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NorthwindEntities db = new NorthwindEntities();

            List<Employee> employees = db.Employees.ToList();

            this.ListViewEmployees.DataSource = employees;
            this.ListViewEmployees.DataBind();
        }
    }
}