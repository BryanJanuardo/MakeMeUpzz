<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="MakeMeUpzz.Views.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Login</h1>
            <div>
                <asp:Label ID="EmailLbl" runat="server" Text="Email Address"></asp:Label>
                <asp:TextBox ID="EmailTxt" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="PasswordLbl" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="PasswordTxt" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:CheckBox ID ="RememberMeBox" runat = "server" Text="Remember Me" />
            </div>
            <div>
                <asp:Label ID="FailLbl" runat="server" Text="" Style="Color: Red"></asp:Label>
            </div>
            <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" />
            <div>
                <p>Don't have an account? <a href="RegisterPage.aspx">Register Here.</a></p>
            </div>
        </div>
    </form>
</body>
</html>
