<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="MakeMeUpzz.Views.ProfilePage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Profile</h2>
        <div>
            <div>
                <asp:Label ID="usernameLbl" Text="Username" runat="server" />
                <asp:TextBox ID="usernameTxt" runat="server" />
            </div>
            <div>
                <asp:Label ID="emailLbl" Text="Email" runat="server" />
                <asp:TextBox ID="emailTxt" runat="server" />
            </div>
            <div>
                <asp:Label ID="GenderLbl" runat="server" Text="Gender"></asp:Label>
                <div>
                    <asp:RadioButtonList ID="rblGender" runat="server">
                        <asp:ListItem ID="RadioMale" Text="Male" />
                        <asp:ListItem ID="RadioFemale" Text="Female" />
                    </asp:RadioButtonList>
                </div>
            </div>
            <div>
                <asp:Label ID="DOBLbl" runat="server" Text="Date of Birth"></asp:Label>
                <asp:TextBox ID="DOBDate" runat="server" Type="date"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="FailLbl" runat="server" Text="" Style="color: Red"></asp:Label>
                <asp:Label ID="statusLbl" runat="server" Text="" Style="color: Red"></asp:Label>
            </div>
            <asp:Button ID="updateProfileBtn" Text="Update Profile" runat="server" OnClick="updateProfileBtn_Click" />
        </div>
    </div>


    <h2>Update password</h2>
    <div>
        <asp:Label ID="PasswordLbl" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="PasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="newPasswordLbl" runat="server" Text="New Password"></asp:Label>
        <asp:TextBox ID="newPasswordTxt" runat="server" TextMode="Password" ></asp:TextBox>
    </div>
    <asp:Button ID="updatePasswordBtn" Text="Update Password" runat="server" OnClick="updatePasswordBtn_Click" />
    <div>
        <asp:Label ID="ErrorLabel" runat="server" Text="Label"></asp:Label>
    </div>
</asp:Content>
