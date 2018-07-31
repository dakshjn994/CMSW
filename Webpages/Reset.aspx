<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Reset.aspx.cs" Inherits="Webpages_Reset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="text-center">
    <h1>Reset Password</h1><br /><br />
    New Password<asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" Text="*" ToolTip="Enter Password" runat="server" ControlToValidate="TextBox1" ErrorMessage="Enter Password"></asp:RequiredFieldValidator> :
    <asp:TextBox ID="TextBox1" placeholder="New Password" CssClass="input-group-sm" TextMode="Password" runat="server"></asp:TextBox><br /><br />
    <asp:Button ID="Button1" runat="server" CausesValidation="true" CssClass="btn btn-success" OnClick="Button1_Click" Text="Submit" /><br />
        </div>
</asp:Content>