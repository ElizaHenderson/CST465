<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Lab3.WebForms.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="Contact" runat="server">
    <div>
        <asp:Label AssociatedControlID="uxName" runat="server">Name</asp:Label>
        <asp:TextBox Label="Name" ID="uxName" runat="server">Text Go Here</asp:TextBox> 
        
        <asp:Label AssociatedControlID="uxPriority" runat="server">Priority</asp:Label>
        <asp:DropDownList label="Priority" ID="uxPriority" runat="server">
            <asp:ListItem Value="High" Text="High">High</asp:ListItem>
            <asp:ListItem Value="Medium" Text="Medium">Medium</asp:ListItem>
            <asp:ListItem Value="Low" Text="Low">Low</asp:ListItem>
        </asp:DropDownList>
        
        <asp:Label AssociatedControlID="uxSubject" runat="server">Subject</asp:Label>
        <asp:TextBox label="Subject" ID="uxSubject" runat="server">Text Goes Here</asp:TextBox>

        <asp:Label AssociatedControlID="uxDescription" runat="server">Description</asp:Label>
        <asp:TextBox TextMode="MultiLine" label="Description"  ID="uxDescription" runat="server">Text Goes Here</asp:TextBox>
        
        <asp:Label AssociatedControlID="uxSubmit" runat="server"></asp:Label>        
        <asp:Button runat="server" text="Submit" ID="uxSubmit" OnClick="uxSubmit_Click" />


        <asp:Literal ID="uxFormOutput" runat="server"></asp:Literal>
        <asp:Literal ID="uxEventOutput" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
