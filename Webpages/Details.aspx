<%@ Page Title="Details" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="Webpages_Details" EnableEventValidation="False" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server"> 
        <ContentTemplate>
    <br /><br />
    <div style="width:100%;height:100%">
    <h1 runat="server" class="text-center" id="h1"></h1>
    <br />
        <h4 runat="server" id="p1" style="float:right;width:300px;margin-right:100px"></h4>&nbsp&nbsp&nbsp
    <a id="a1" runat="server"><asp:Image ID="Image1" Height="400" Width="400" CssClass="img-circle" style="margin-left:10px" runat="server" /></a>
    <br /><br /><h3 runat="server" style="margin-left:10px;" id="p2"></h3>
        <asp:Button ID="Button1" runat="server" style="float:right;margin-right:100px" Text="Add To Cart" CssClass="btn btn-info" OnClick="Button1_Click" /><br /></div>
            </ContentTemplate>
         </asp:UpdatePanel>
</asp:Content>