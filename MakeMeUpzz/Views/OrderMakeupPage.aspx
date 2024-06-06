<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="OrderMakeupPage.aspx.cs" Inherits="MakeMeUpzz.Views.OrderMakeupPage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="MakeupGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="MakeupGridView_RowCommand">
        <Columns>
            <asp:BoundField DataField="MakeupID" HeaderText="ID" SortExpression="MakeupName" />
            <asp:BoundField DataField="MakeupName" HeaderText="Makeup Name" SortExpression="MakeupName" />
            <asp:BoundField DataField="MakeupPrice" HeaderText="Makeup Price" SortExpression="MakeupPrice" />
            <asp:BoundField DataField="MakeupWeight" HeaderText="Makeup Weight" SortExpression="MakeupWeight" />
            <asp:BoundField DataField="MakeupType.MakeupTypeName" HeaderText="Makeup Type" SortExpression="MakeupType.MakeupTypeName" />
            <asp:BoundField DataField="MakeupBrand.MakeupBrandName" HeaderText="Makeup Brand" SortExpression="MakeupBrand.MakeupBrandName" />
            <asp:BoundField DataField="MakeupBrand.MakeupBrandRating" HeaderText="Makeup Rating" SortExpression="MakeupBrand.MakeupBrandRating" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                <div>
                    <asp:TextBox ID="MakeupQuantityInput" runat="server"></asp:TextBox>
                    <asp:Button ID="OrderButton" runat="server" Text="Order" CommandName="Order" />
                </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
