<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdateMakeupPage.aspx.cs" Inherits="MakeMeUpzz.Views.UpdateMakeupPage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="MakeupNameLabel" runat="server" Text="Makeup Name:"></asp:Label>
        <asp:TextBox ID="MakeupNameInput" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="MakeupPriceLabel" runat="server" Text="Makeup Price:"></asp:Label>
        <asp:TextBox ID="MakeupPriceInput" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="MakeupWeightLabel" runat="server" Text="Makeup Weight:"></asp:Label>
        <asp:TextBox ID="MakeupWeightInput" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="MakeupTypeLabel" runat="server" Text="Makeup Type:"></asp:Label>
        <asp:DropDownList ID="MakeupTypeDropDownList" runat="server"></asp:DropDownList>
    </div>
    <div>
        <asp:Label ID="MakeupBrandLabel" runat="server" Text="Makeup Brand:"></asp:Label>
        <asp:DropDownList ID="MakeupBrandDropDownList" runat="server"></asp:DropDownList>
    </div>
    <div>
        <asp:Label ID="ErrorValidationLabel" runat="server" Text=""></asp:Label>
    </div>
    <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
</asp:Content>
