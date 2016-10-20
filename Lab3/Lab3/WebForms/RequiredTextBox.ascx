<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RequiredTextBox.ascx.cs" Inherits="Lab3.WebForms.RequiredTextBox" %>

<asp:Label runat="server" ID="uxLabel"></asp:Label>
<asp:TextBox runat="server" ID="uxTextBox">Text Goes Here</asp:TextBox>
<asp:RequiredFieldValidator runat="server"  ID="uxFieldValidator"></asp:RequiredFieldValidator>