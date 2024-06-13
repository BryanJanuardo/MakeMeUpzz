<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="MakeMeUpzz.Views.TransactionDetail" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1> Transaction Detail Page</h1>
    <div id="TransactionDetail">
        <asp:GridView ID="TransactionDetailGV" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="TransactionId" HeaderText="Transaction ID" SortExpression="TransactionID"></asp:BoundField>
                <asp:BoundField DataField="MakeupID" HeaderText="Makeup ID" SortExpression="MakeupID"></asp:BoundField>
                <asp:BoundField DataField="MakeupName" HeaderText="Makeup Name" SortExpression="MakeupName"></asp:BoundField>
                <asp:BoundField DataField="MakeupPrice" HeaderText="Makeup Price" SortExpression="MakeupPrice"></asp:BoundField>
                <asp:BoundField DataField="MakeupWeight" HeaderText="Makeup Weight" SortExpression="MakeupWeight"></asp:BoundField>
                <asp:BoundField DataField="MakeupTypeName" HeaderText="Makeup Type Name" SortExpression="MakeupTypeName"></asp:BoundField>
                <asp:BoundField DataField="MakeupBrandName" HeaderText="Makeup Brand Name" SortExpression="MakeupBrandName"></asp:BoundField>
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"></asp:BoundField>
                <asp:BoundField DataField="Total" HeaderText="Total " SortExpression="Total"></asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
