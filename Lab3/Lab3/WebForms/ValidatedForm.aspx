<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/thispage.Master" AutoEventWireup="true" CodeBehind="ValidatedForm.aspx.cs" Inherits="Lab3.WebForms.ValidatedForm" %>
<%@ Register TagPrefix="CST" Namespace="Lab3.WebForms" Assembly="Lab3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <asp:Panel runat="server">
        <CST:RequiredTextBox runat="server" TextBoxText="Name" LabelText="uxName"></CST:RequiredTextBox>
        <CST:RequiredTextBox runat="server" Text="Favorite Color"></CST:RequiredTextBox>
        <CST:RequiredTextBox runat="server" Text="City"></CST:RequiredTextBox>
    </asp:Panel>
</asp:Content>
