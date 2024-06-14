<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionHistoryPage.aspx.cs" Inherits="MakeMeUpzz.Views.TransactionHistory" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <h1> Transaction History </h1>
    <asp:Label ID="StatusLbl" runat="server" Text="There is no transaction made yet!" Visible="false"></asp:Label>
    </div>
    <div> 
    <asp:GridView ID="TransactionHistoryGV" runat="server" AutoGenerateColumns="False" DataKeyNames="TransactionID" OnSelectedIndexChanging="TransactionHistoryGV_SelectedIndexChanging">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" DataFormatString="{0:d}"/>
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:CommandField HeaderText="Transaction Details" ShowHeader="True" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
