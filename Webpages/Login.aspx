<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Webpages_Login" %>
<%@ MasterType VirtualPath="../Site.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <script type="text/javascript"> 
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 10);
        window.onunload = function () { null };
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <h1 class="Contact">Login</h1>
    <p></p>
    <p class="hello">
        &nbsp&nbsp&nbsp Email Id :&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEmail" placeholder="Enter Email" CssClass="input-sm"  AutoCompleteType="Disabled"  runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="UserName Required" SetFocusOnError="True" Display="Dynamic" Text="*" ControlToValidate="txtEmail" ForeColor="Red" ValidationGroup="validate" ToolTip="Please Enter UserName"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="revEmail" runat="server" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" ValidationGroup="validate" ControlToValidate="txtEmail" ErrorMessage="Incorrect Email Format" Text="*" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ToolTip="Please Enter Correct Format of Email"></asp:RegularExpressionValidator>
    </p>
    <p class="hello">
        &nbsp&nbsp&nbsp Password :
        <asp:TextBox ID="txtPassword" CssClass=" input-sm inputs" placeholder="Enter Password" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Password Required" SetFocusOnError="True" Display="Dynamic" Text="*" ControlToValidate="txtPassword" ForeColor="Red" ValidationGroup="validate" ToolTip="Please Enter Password"></asp:RequiredFieldValidator>
    </p>
    <p>
        &nbsp&nbsp&nbsp<asp:Button ID="btnLogin" CssClass="btn btn-default"  runat="server" Text="Login" OnClick="btnLogin_Click" ValidationGroup="validate" CausesValidation="true" />&nbsp&nbsp<asp:Button ID="btnAdmin" CssClass="btn btn-primary" runat="server" Text="Adminstrator Login" OnClick="btnAdmin_Click" ValidationGroup="validate" CausesValidation="true" />
    </p>
        <asp:ValidationSummary ID="ValidationSummary1" ForeColor="White" ShowSummary="false" style="margin-left:10px;float:left;" ShowMessageBox="true" CssClass="dang" runat="server" ValidationGroup="validate" />
     <p><a href="Forgot.aspx">Forgot Password</a></p>
    <p> Dont Have a Account ? <a href="Register.aspx">Sign Up</a></p><br />
</asp:Content>