<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="InsertMakeupTypePage.aspx.cs" Inherits="MakeMeUpzz.Views.InsertMakeupTypePage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Button ID="BackBtn" runat="server" Text="Back" OnClick="BackBtn_Click" />
    </div>
    <div>
        <asp:Label ID="MakeupTypeNameLabel" runat="server" Text="MakeupType Name:"></asp:Label>
        <asp:TextBox ID="MakeupTypeNameInput" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="ErrorValidationLabel" runat="server" Text=""></asp:Label>
    </div>
    <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
    <asp:Label ID="ErrorLabel" runat="server" Text="Label"></asp:Label>
</asp:Content>
