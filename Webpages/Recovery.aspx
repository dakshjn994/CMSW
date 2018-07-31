<%@ Page Title="Recovery" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Recovery.aspx.cs" Inherits="Webpages_Recovery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 10);
        window.onunload = function () { null };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server"> 
        <ContentTemplate>
    <br /><br /><br />
    <h1 class="Contact">Recovery</h1>
    <p>Security Question : 
        <asp:DropDownList ID="ddlRQuestion" CssClass="dropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Value="null" Selected="True">...</asp:ListItem>
        <asp:ListItem Value="Birth">What is your Birth Place ?</asp:ListItem>
        <asp:ListItem Value="Pet">What is your Pets Name ?</asp:ListItem>
        <asp:ListItem Value="Brother">What is your Brothers Name ?</asp:ListItem>
                           </asp:DropDownList></p>
    <p>Answer : <asp:TextBox ID="txtAnswer" placeholder="Answer" CssClass="input-sm" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rfvAnser" runat="server" ErrorMessage="Please Enter Answer" Display="Dynamic" Text="*" ControlToValidate="txtAnswer" ValidationGroup="ans"></asp:RequiredFieldValidator></p>
    <asp:Button ID="btnRecovery" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="btnRecovery_Click" ValidationGroup="ans" />&nbsp&nbsp&nbsp
    <asp:Button ID="btnrClear" CssClass="btn btn-default" runat="server" Text="Clear" OnClick="btnrClear_Click" />
            </ContentTemplate>
         </asp:UpdatePanel>
</asp:Content>