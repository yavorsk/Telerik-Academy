using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Students
{
    public partial class StudentRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            string[] universities = new string[] 
            {
                "UACEG",
                "UNWE",
                "SU",
                "TU",
                "AU"
            };

            this.university.DataSource = universities;
            this.university.DataBind();

            string[] specialities = new string[]
            {
                "Architecture",
                "Structural engineering",
                "Finance",
                "International relations",
                "Computer science",
                "Physics",
                "History",
                "Tourism",
                "Business administration"
            };

            this.speciality.DataSource = specialities;
            this.speciality.DataBind();

            string[] courses = new string[]
            {
                "Urban planning",
                "Residential buildings",
                "Industrial buildings",
                "Steel structures design",
                "Concrete structures design",
                "Steel bridges",
                "Anti-seismic design",
                "Economics",
                "Auditing",
                "Quantum physics",
                "Theory of relativity",
                "Medieval history",
                "Balcan history",
                "Europe history",
                "Geography"
            };

            this.course.DataSource = courses;
            this.course.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.firstNameResult.Text = this.firstName.Text;
            this.lastNameResult.Text = this.lastName.Text;
            this.facultyNumberResult.Text = this.facultyNumber.Text;
            this.universityResult.Text = this.university.SelectedValue;
            this.specialtyResult.Text = this.speciality.SelectedValue;

            int[] selectedCourseIndexes = this.course.GetSelectedIndices();

            foreach (var index in selectedCourseIndexes)
            {
                this.coursesResult.Items.Add(this.speciality.Items[index] as ListItem);
            }

            this.submittedInfo.Visible = true;
        }
    }
}