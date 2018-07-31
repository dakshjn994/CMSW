<%@ Page Title="Address" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Shipping.aspx.cs" Inherits="Webpages_Shipping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Shipping Address</h1><br />
    <asp:RadioButton ID="RadioButton1" style="margin-left:25px" Text="Use Existing Address" AutoPostBack="true" CssClass="radio" GroupName="val" OnCheckedChanged="RadioButton1_CheckedChanged" runat="server" /><br />
    <asp:RadioButton ID="RadioButton2" style="margin-left:25px" Text="Use Another Address" AutoPostBack="true" CssClass="radio" GroupName="val" OnCheckedChanged="RadioButton2_CheckedChanged" runat="server" /><br />
    <asp:TextBox ID="TextBox1" runat="server" placeholder="Delivery Address" Enabled="false" CssClass="input-sm" Rows="3"></asp:TextBox><br /><br />
    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" CssClass="btn btn-danger" /><br /><br />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</asp:Content>