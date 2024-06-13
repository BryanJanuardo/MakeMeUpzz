<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="MakeMeUpzz.Views.HomePage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="roleLbl" Text="" runat="server" />
    <asp:GridView ID="customerData" runat="server" AutoGenerateColumns="False" Visible="false">
        <Columns>
            <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
            <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
            <asp:BoundField DataField="UserEmail" HeaderText="Email" SortExpression="UserEmail" />
            <asp:BoundField DataField="UserDOB" HeaderText="Date of Birth" SortExpression="UserDOB" />
            <asp:BoundField DataField="UserGender" HeaderText="Gender" SortExpression="UserGender" />
            <asp:BoundField DataField="UserRole" HeaderText="User Role" SortExpression="UserRole" />
            <asp:BoundField DataField="UserPassword" HeaderText="Password" SortExpression="UserPassword" />
        </Columns>
    </asp:GridView>
</asp:Content>
