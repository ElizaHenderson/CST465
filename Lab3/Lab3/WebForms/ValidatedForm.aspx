<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/thispage.Master" AutoEventWireup="true" CodeBehind="ValidatedForm.aspx.cs" Inherits="Lab3.WebForms.ValidatedForm" %>
<%@ Register TagPrefix="CST" TagName="RequiredTextBox" src="RequiredTextBox.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <asp:Panel runat="server">
        <CST:RequiredTextBox ID="uxName" runat="server" TextBoxText="Name" LabelText="Name"></CST:RequiredTextBox>
        <CST:RequiredTextBox ID="uxColor" runat="server" Text="Favorite Color" LabelText="Favorite Color"></CST:RequiredTextBox>
        <CST:RequiredTextBox ID="uxCity" runat="server" Text="City" LabelText="City"></CST:RequiredTextBox>

        <asp:button OnClick="SubmitForm" runat="server" Text="Submit"/>
    </asp:Panel>
</asp:Content>
