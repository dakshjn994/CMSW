<%@ Page Title="Approved" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Approval.aspx.cs" Inherits="Webpages_Approval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Approved Orders</h2><br />
    <asp:GridView ID="GridView1" ShowHeaderWhenEmpty="true" EmptyDataText="No Approved Order" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                   Approved&nbsp;
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView><br />
    <h2>Processing Orders</h2><br />
    <asp:GridView ID="GridView2" ShowHeaderWhenEmpty="true" EmptyDataText="No Processing Order" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    Processing&nbsp;
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>