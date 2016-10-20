<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/thispage.Master" AutoEventWireup="true" CodeBehind="ValidatedFormOutput.aspx.cs" Inherits="Lab3.WebForms.ValidatedFormOutput" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>ValidatedFormOutput</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <asp:PlaceHolder runat="server" id="uxInvalidDataArea" Visible="False">
        This form did not receive the parameters expected
    </asp:PlaceHolder>
	<asp:PlaceHolder runat="server" ID="uxValidDataArea" Visible="False">
		<div>
            Name: <asp:Literal runat="server" ID="uxName"></asp:Literal>
        </div>
        <div>
		    Favorite Color: <asp:Literal runat="server" ID="uxFavoriteColor"></asp:Literal>
        </div>
        <div>
		    City: <asp:Literal runat="server" ID="uxCity"></asp:Literal>
        </div>
	</asp:PlaceHolder>
</asp:Content>
