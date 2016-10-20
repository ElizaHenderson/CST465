<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RequiredTextBox.ascx.cs" Inherits="Lab3.WebForms.RequiredTextBox" %>

<asp:Label runat="server" ID="uxLabel" AssociatedControlID="uxTextBox"></asp:Label>
<asp:TextBox runat="server" ID="uxTextBox"></asp:TextBox>
<asp:RequiredFieldValidator ControlToValidate="uxTextBox" runat="server"  ID="uxFieldValidator" ErrorMessage="This must not be blank"></asp:RequiredFieldValidator>