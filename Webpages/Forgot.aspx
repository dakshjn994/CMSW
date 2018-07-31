<%@ Page Title="Forgot Password" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Forgot.aspx.cs" Inherits="Webpages_Forgot" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br />
    <h1 class="Contact">Forgot Password</h1><br />
<div id="email" runat="server">Email : <asp:TextBox ID="txtEmail" CssClass="input-sm" placeholder="Enter Email Here" AutoPostBack="true" runat="server"></asp:TextBox></div>
    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Submit Email" OnClick="Button1_Click" /><br /><br />
<div runat="server" id="question">Security Question : <asp:TextBox ID="txtQuestion" Enabled="false" runat="server"></asp:TextBox><br /><br /></div>
<div runat="server" id="answer1">Answer : <asp:TextBox CssClass="input-sm" ID="txtForgot" runat="server"></asp:TextBox><br /><br /></div>
    <asp:Button ID="btnSubmit" CssClass="btn btn-default" runat="server" OnClick="btnSubmit_Click" Text="Reset Password" />&nbsp;&nbsp;&nbsp; <asp:Button CssClass="btn btn-primary" ID="btnclear" runat="server" Text="Clear" OnClick="btnclear_Click" />
    <asp:Label ID="lblError" ForeColor="Red" runat="server" Text=""></asp:Label>
    
</asp:Content>