<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRegistration.aspx.cs" Inherits="Students.StudentRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student registration form</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Student registration form</h2>
            <div>
                <asp:Label runat="server" AssociatedControlID="firstName" Text="First name:  "></asp:Label>
                <asp:TextBox ID="firstName" runat="server"></asp:TextBox>
                <br />
                <br />
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="lastName" Text="Last name:  "></asp:Label>
                <asp:TextBox ID="lastName" runat="server"></asp:TextBox>
                <br />
                <br />
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="facultyNumber" Text="Faculty number:  "></asp:Label>
                <asp:TextBox ID="facultyNumber" runat="server"></asp:TextBox>
                <br />
                <br />
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="university" Text="University:  "></asp:Label>
                <asp:DropDownList runat="server" ID="university">
                </asp:DropDownList>
                <br />
                <br />
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="speciality" Text="Speciality:  "></asp:Label>
                <asp:DropDownList runat="server" ID="speciality">
                </asp:DropDownList>
                <br />
                <br />
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="course" Text="Courses:  "></asp:Label>
                <asp:ListBox runat="server" ID="course" SelectionMode="Multiple">
                </asp:ListBox>
                <br />
                <br />
            </div>
            <div>
                <asp:Button Text="Submit" runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" />
                <br />
                <br />
            </div>
        </div>
        <asp:Panel runat="server" Visible="false" ID="submittedInfo">
            <h2>Your submited information is:</h2>
            <span>First name: </span>
            <asp:Label Text="" runat="server" ID="firstNameResult" />
            <br />
            <span>Second name: </span>
            <asp:Label Text="" runat="server" ID="lastNameResult" />
            <br />
            <span>Faculty number: </span>
            <asp:Label Text="" runat="server" ID="facultyNumberResult" />
            <br />
            <span>University: </span>
            <asp:Label Text="" runat="server" ID="universityResult" />
            <br />
            <span>Specialty: </span>
            <asp:Label Text="" runat="server" ID="specialtyResult" />
            <br />
            <span>Courses: </span>
            <asp:BulletedList ID="coursesResult" runat="server"></asp:BulletedList>
        </asp:Panel>
    </form>
</body>
</html>
