<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="ManageMakeupPage.aspx.cs" Inherits="MakeMeUpzz.Views.ManageMakeupPage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Makeup</h2>
    <asp:GridView ID="MakeupGridView" runat="server" AutoGenerateColumns="False" OnRowEditing="MakeupGridView_RowEditing" OnRowDeleting="MakeupGridView_RowDeleting">
        <Columns>
            <asp:BoundField DataField="MakeupID" HeaderText="ID" SortExpression="MakeupID" />
            <asp:BoundField DataField="MakeupName" HeaderText="Makeup Name" SortExpression="MakeupName" />
            <asp:BoundField DataField="MakeupPrice" HeaderText="Makeup Price" SortExpression="MakeupPrice" />
            <asp:BoundField DataField="MakeupWeight" HeaderText="Makeup Weight" SortExpression="MakeupWeight" />
            <asp:BoundField DataField="MakeupType.MakeupTypeName" HeaderText="Makeup Type" SortExpression="MakeupType.MakeupTypeName" />
            <asp:BoundField DataField="MakeupBrand.MakeupBrandName" HeaderText="Makeup Brand" SortExpression="MakeupBrand.MakeupBrandName" />
            <asp:BoundField DataField="MakeupBrand.MakeupBrandRating" HeaderText="Makeup Rating" SortExpression="MakeupBrand.MakeupBrandRating" />
            <asp:CommandField ButtonType="Button" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="ErrorLabel" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="InsertMakeupButton" runat="server" Text="Insert Makeup" OnClick="InsertMakeupButton_Click" />
    <br />

    <h2>Makeup Type</h2>
    <asp:GridView ID="MakeupTypeGridView" runat="server" AutoGenerateColumns="False" OnRowEditing="MakeupTypeGridView_RowEditing" OnRowDeleting="MakeupTypeGridView_RowDeleting">
        <Columns>
            <asp:BoundField DataField="MakeupTypeID" HeaderText="ID" SortExpression="MakeupTypeID" />
            <asp:BoundField DataField="MakeupTypeName" HeaderText="Makeup Type Name" SortExpression="MakeupTypeName" />
            <asp:CommandField ButtonType="Button" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="ErrorLabelType" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="InsertMakeupTypeButton" runat="server" Text="Insert MakeupType" OnClick="InsertMakeupTypeButton_Click" />
    <br />

    <h2>Makeup Brand</h2>
    <asp:GridView ID="MakeupBrandGridView" runat="server" AutoGenerateColumns="False" OnRowEditing="MakeupBrandGridView_RowEditing" OnRowDeleting="MakeupBrandGridView_RowDeleting">
        <Columns>
            <asp:BoundField DataField="MakeupBrandID" HeaderText="ID" SortExpression="MakeupBrandID" />
            <asp:BoundField DataField="MakeupBrandName" HeaderText="Makeup Brand Name" SortExpression="MakeupBrandName" />
            <asp:BoundField DataField="MakeupBrandRating" HeaderText="Rating" SortExpression="MakeupBrandRating" />
            <asp:CommandField ButtonType="Button" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="ErrorLabelBrand" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="InsertMakeupBrandButton" runat="server" Text="Insert MakeupBrand" OnClick="InsertMakeupBrandButton_Click" />
</asp:Content>
