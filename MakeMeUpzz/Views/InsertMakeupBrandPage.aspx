<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="InsertMakeupBrandPage.aspx.cs" Inherits="MakeMeUpzz.Views.InsertMakeupBrandPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <asp:Button ID="BackBtn" runat="server" Text="Back" OnClick="BackBtn_Click" />
        </div>
        <h2>Insert Makeup Brand</h2>
        <div>
            <asp:Label ID="MakeUpBrandLbl" Text="Makeup Brand" runat="server"></asp:Label>
            <asp:TextBox ID="MakeUpBrandTxt" runat="server" />
        </div>
        <div>
            <asp:Label ID="MakeUpRatingLbl" Text="Rating" runat="server" />
            <asp:TextBox ID="MakeUpRatingTxt" runat="server" />
        </div>
        <div>
            <asp:Label ID="FailLbl" runat="server" Text="" Style="color: Red"></asp:Label>
        </div>
        <asp:Button ID="InputButton" Text="Input" runat="server" OnClick="InputButton_Click" />
    </div>
</asp:Content>
