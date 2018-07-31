<%@ Page Title="Customers" Language="C#" EnableEventValidation="false" MasterPageFile="AdminMaster.master" AutoEventWireup="true" CodeFile="Customers.aspx.cs" Inherits="Webpages_Admin_Customers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin-left:30px;">
    <br /><br />
    <h1>View Customers</h1><br />

    <asp:GridView ID="GridView1" EmptyDataText="There are no Customers" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="Delete Customer">
                <ItemTemplate>
                    <asp:Button ID="btnDelete" OnClick="btnDelete_Click" runat="server" CommandArgument='<%#Eval("Customer_email_id") %>' CssClass="btn btn-primary" Text="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
        <br />
        <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" CssClass="btn btn-warning" Text="Show Deleted Customers" /><asp:Button ID="btnHide" OnClick="btnHide_Click" CssClass="btn btn-warning" runat="server" Text="Hide Deleted Customers" /><br />
    <br />
    <asp:GridView ID="GridView2" ShowHeaderWhenEmpty="true" EmptyDataText="There are no Deleted Customers" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="Add Deleted Customers">
                <ItemTemplate>
                    <asp:Button ID="btnAdd" OnClick="btnAdd_Click" CommandArgument='<%#Eval("Customer_email_id")%>' CssClass="btn btn-danger" runat="server" Text="Add" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
        </div>
</asp:Content>