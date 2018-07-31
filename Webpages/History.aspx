<%@ Page Title="History" Language="C#" MasterPageFile="~/Webpages/AdminMaster.master" AutoEventWireup="true" CodeFile="History.aspx.cs" Inherits="Webpages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Login History</h1>
    <br />
    <h2 style="margin-left:75px">Customer Login Records</h2>
    <div style="margin-left:100px">
    
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    <br /><br />
        </div>
    <h2 style="margin-left:75px">Admin Login Records</h2>
    <div style="margin-left:100px">
    
    <asp:GridView ID="GridView2" runat="server"></asp:GridView>
        </div>
</asp:Content>