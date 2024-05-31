<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="ManageMakeupPage.aspx.cs" Inherits="MakeMeUpzz.Views.ManageMakeupPage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="MakeupGridView" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="MakeupID" HeaderText="ID" SortExpression="MakeupName" />
            <asp:BoundField DataField="MakeupName" HeaderText="Makeup Name" SortExpression="MakeupName" />
            <asp:BoundField DataField="MakeupPrice" HeaderText="Makeup Price" SortExpression="MakeupPrice" />
            <asp:BoundField DataField="MakeupWeight" HeaderText="Makeup Weight" SortExpression="MakeupWeight" />
            <asp:BoundField DataField="MakeupType.MakeupTypeName" HeaderText="Makeup Type" SortExpression="MakeupType.MakeupTypeName" />
            <asp:BoundField DataField="MakeupBrand.MakeupBrandName" HeaderText="Makeup Brand" SortExpression="MakeupBrand.MakeupBrandName" />
            <asp:BoundField DataField="MakeupBrand.MakeupBrandRating" HeaderText="Makeup Rating" SortExpression="MakeupBrand.MakeupBrandRating" />
            <asp:CommandField ButtonType="Button" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="InsertMakeupButton" runat="server" Text="Insert Makeup" OnClick="InsertMakeupButton_Click" />
    <asp:Button ID="InsertMakeupTypeButton" runat="server" Text="Insert MakeupType" OnClick="InsertMakeupTypeButton_Click" />
    <asp:Button ID="InsertMakeupBrandButton" runat="server" Text="Insert MakeupBrand" OnClick="InsertMakeupBrandButton_Click" />
</asp:Content>
