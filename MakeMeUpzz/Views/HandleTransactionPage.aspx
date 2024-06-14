<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="HandleTransactionPage.aspx.cs" Inherits="MakeMeUpzz.Views.HandleTransactionPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Handle Transaction </h1>

    <asp:GridView ID="HandleTransactionGV" runat="server" AutoGenerateColumns="false" OnRowDataBound="HandleTransactionGV_RowDataBound" OnRowEditing="HandleTransactionGV_RowEditing" OnSelectedIndexChanged="HandleTransactionGV_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" ReadOnly="True" SortExpression="TransactionID"></asp:BoundField>
            <asp:BoundField DataField="UserID" HeaderText="User ID" ReadOnly="True" SortExpression="UserID"></asp:BoundField>
            <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" ReadOnly="True" SortExpression="TransactionDate"></asp:BoundField>
            <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Status"></asp:BoundField>
            <asp:CommandField ShowEditButton="True" EditText="Handle Transaction" ButtonType="Button" ShowHeader="True" HeaderText="Action"></asp:CommandField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="ErrorLabel" runat="server" Text="Label"></asp:Label>
</asp:Content>
