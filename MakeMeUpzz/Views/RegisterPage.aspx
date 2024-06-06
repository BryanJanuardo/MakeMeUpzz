<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="MakeMeUpzz.Views.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Register</h1>
            <div>
                <asp:Label ID="EmailLbl" runat="server" Text="Email Address"></asp:Label>
                <asp:TextBox ID="EmailTxt" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="UsernameLbl" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="UsernameTxt" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="PasswordLbl" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="PasswordTxt" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="ConfirmLbl" runat="server" Text="Confirmation Password"></asp:Label>
                <asp:TextBox ID="ConfirmTxt" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="DOBLbl" runat="server" Text="Date of Birth"></asp:Label>
                <asp:TextBox ID="DOBDate" runat="server" Type="date"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="GenderLbl" runat="server" Text="Gender"></asp:Label>
                <div>
                    <asp:RadioButton id="RadioNone" Text="None" Checked="True" GroupName="GenderRadio" runat="server"/>
                    <asp:RadioButton id="RadioMale" Text="Male" GroupName="GenderRadio" runat="server"/>
                    <asp:RadioButton id="RadioFemale" runat="server" Text="Female" GroupName="GenderRadio"/>
                </div>
            </div>
            <div>
                <asp:Label ID="FailLbl" runat="server" Text="" Style="Color: Red"></asp:Label>
            </div>
            <asp:Button ID="RegistBtn" runat="server" Text="Sign Up" OnClick="RegistBtn_Click" />
        </div>
    </form>
</body>
</html>
