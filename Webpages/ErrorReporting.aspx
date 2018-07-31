<%@ Page Title="Report Bug" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ErrorReporting.aspx.cs" Inherits="Webpages_ErrorReporting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Report Error</h1>
    <div class="text-center" style="margin-left:25px">Error Description: </div>
    <div class="text-center" style="margin-left:25px"><asp:TextBox ID="TextBox1" runat="server" Width="250px" placeholder="Please Write about the error you faced"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" ToolTip="Please Enter Some Data" Display="Dynamic" SetFocusOnError="true" ControlToValidate="TextBox1" ErrorMessage="Cannot Be Empty" ForeColor="Red"></asp:RequiredFieldValidator></div><br />
    <div class="text-center">Screenshot: <asp:FileUpload ID="FileImage" runat="server" CssClass="center-block" /></div><br />
    <div class="text-center"><asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" /></div><br />
    <div class="text-center"><asp:Image ID="imgProduct" Height="100" Width="100" runat="server" Visible="false" /></div><br />
    <div class="text-center"><asp:Label ID="lblStatus" ForeColor="Red" Visible="false" runat="server" Text=""></asp:Label></div><br />
</asp:Content>