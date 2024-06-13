<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdateMakeupBrandPage.aspx.cs" Inherits="MakeMeUpzz.Views.UpdateMakeupBrandPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Button ID="BackBtn" runat="server" Text="Back" OnClick="BackBtn_Click" />
    </div>
    <h2>Update Makeup Brand</h2>
    <div>
        <asp:Label ID="MakeUpBrandLbl" Text="Makeup Brand" runat="server"></asp:Label>
        <asp:TextBox ID="MakeUpBrandTxt" runat="server" />
    </div>
    <div>
        <asp:Label ID="MakeUpBrandRatingLbl" Text="Rating" runat="server" />
        <asp:TextBox ID="MakeUpBrandRatingTxt" runat="server" />
    </div>
    <div>
        <asp:Label ID="ErrorValidationLabel" runat="server" Text=""></asp:Label>
    </div>
    <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
</asp:Content>
