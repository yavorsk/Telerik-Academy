<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="RegisterForm.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Username:
        <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername"
            ControlToValidate="TextBoxUsername"
            runat="server" Display="Dynamic"
            Text="Required Field" ErrorMessage="Username field is required!"
            ForeColor="Red" EnableClientScript="False" />
        <br />
        <br />

        Password:
        <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword"
            ControlToValidate="TextBoxPassword" runat="server"
            Display="Dynamic" Text="Required Field"
            ErrorMessage="Password field is required!"
            ForeColor="Red" EnableClientScript="False" />
        <br />
        <br />

        Confirm Password:
       
        <asp:TextBox ID="TextBoxConfirmPassword" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPassword"
            ControlToValidate="TextBoxConfirmPassword" runat="server"
            Display="Dynamic" Text="Required Field"
            ErrorMessage="Confirm Password field is required!"
            ForeColor="Red" EnableClientScript="False" />
        <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
            ControlToCompare="TextBoxPassword"
            ControlToValidate="TextBoxConfirmPassword" Display="Dynamic"
            ErrorMessage="Passwords doesn't match!"
            ForeColor="Red" EnableClientScript="False">
        </asp:CompareValidator>
        <br />
        <br />

        First name: 
        <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldFirstName"
            ControlToValidate="TextBoxFirstName" runat="server"
            Display="Dynamic" Text="Required Field"
            ErrorMessage="First name field is required!"
            ForeColor="Red" EnableClientScript="False" />
        <br />
        <br />

        Last name: 
        <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldLastName"
            ControlToValidate="TextBoxLastName" runat="server"
            Display="Dynamic" Text="Required Field"
            ErrorMessage="Last name field is required!"
            ForeColor="Red" EnableClientScript="False" />
        <br />
        <br />

        Age: 
        <asp:TextBox ID="TextBoxAge" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldAge"
            ControlToValidate="TextBoxAge" runat="server"
            Display="Dynamic" Text="Required Field"
            ErrorMessage="Age field is required!"
            ForeColor="Red" EnableClientScript="False" />
        <asp:RangeValidator ID="RangeValidatorAge"
            ControlToValidate="TextBoxAge" runat="server"
            Display="Dynamic" Text="Between 18 and 81 years"
            ErrorMessage="Age must be between 18 and 81 years!"
            Type="Integer" MaximumValue="81" MinimumValue="18"
            ForeColor="Red" EnableClientScript="False" />
        <br />
        <br />

        <asp:TextBox ID="TextBoxEmail" runat="server" />
        <asp:RequiredFieldValidator
            ID="RequiredFieldValidatorEmail"
            runat="server" ForeColor="Red" Display="Dynamic"
            ErrorMessage="An email address is required!"
            ControlToValidate="TextBoxEmail" EnableClientScript="false">
            </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator
            ID="RegularExpressionValidatorEmail"
            runat="server" ForeColor="Red" Display="Dynamic"
            ErrorMessage="Email address is incorrect!"
            ControlToValidate="TextBoxEmail" EnableClientScript="False"
            ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}">
            </asp:RegularExpressionValidator>
        <br />
        <br />

        Local address: 
        <asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress"
            ControlToValidate="TextBoxAddress" runat="server"
            Display="Dynamic" Text="Required Field"
            ErrorMessage="Address field is required!"
            ForeColor="Red" EnableClientScript="False" />
        <br />
        <br />

        Phone number:
        <asp:TextBox ID="TextBoxPhoneNumber" runat="server" />
        <asp:RequiredFieldValidator
            ID="RequiredFieldValidatorPhoneNumber"
            runat="server" ForeColor="Red" Display="Dynamic"
            ErrorMessage="Phone number is required!"
            ControlToValidate="TextBoxPhoneNumber" EnableClientScript="false">
            </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator
            ID="RegularExpressionValidatorPhoneNumber"
            runat="server" ForeColor="Red" Display="Dynamic"
            ErrorMessage="Phone number is incorrect!"
            ControlToValidate="TextBoxPhoneNumber" EnableClientScript="False"
            ValidationExpression="^(?:(?:\+?1\s*(?:[.-]\s*)?)?(?:\(\s*([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9])\s*\)|([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9]))\s*(?:[.-]\s*)?)?([2-9]1[02-9]|[2-9][02-9]1|[2-9][02-9]{2})\s*(?:[.-]\s*)?([0-9]{4})(?:\s*(?:#|x\.?|ext\.?|extension)\s*(\d+))?$">
            </asp:RegularExpressionValidator>
        <br />
        <br />

        Do you accept the terms and conditions?
        <asp:CheckBox Text="" runat="server" ID="CheckBoxAccept" />
        <asp:CustomValidator runat="server" ID="ValidatorCheckBox" EnableClientScript="false"
            OnServerValidate="ValidatorCheckBox_ServerValidate"
            ErrorMessage="The terms and conditions were not accepted!"
            Text="You must accept the terms and conditions."
            ForeColor="Red"
            ></asp:CustomValidator>
        <br />
        <br />

        <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" />
        <br />
        <asp:ValidationSummary runat="server" ForeColor="Red" />
    </form>
</body>
</html>
