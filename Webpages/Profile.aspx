<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Webpages_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin-left:35px";>
    <h2>User Profile</h2><br />
        <div>Email: <div runat="server" id="email"></div></div><br />
        <div>Name: <div runat="server" id="name"></div></div><br />
        <div>Contact No. : <div runat="server" id="number"></div></div><br />
        <div>Address: <div runat="server" id="address"></div></div><br />
        Your Login Time:<br />
        <div>
        <asp:DataList ID="DataList1" runat="server">
            <ItemTemplate>
                 <%#Eval("Time")%>
            </ItemTemplate>
        </asp:DataList>
            </div><br />
        <div><a href="Approval.aspx">Product History</a></div>
        </div>
</asp:Content>