<%@ Page Title="Approve Orders" Language="C#" MasterPageFile="~/Webpages/AdminMaster.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="ApprovalOrder.aspx.cs" Inherits="Webpages_ApprovalOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br />
    <h1>Approve Orders</h1>
    <br />
    <asp:GridView ID="GridView1" EmptyDataText="No Orders To Approve" ShowHeaderWhenEmpty="true" ShowHeader="true"  runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Bill No" DataField="Bill_Id" />
            <asp:BoundField HeaderText="Buyers Email" DataField="Customer_email" />
            <asp:BoundField HeaderText="Products Id" DataField="Product_Id" />
            <asp:BoundField HeaderText="Quantity" DataField="Product_Quantity" />
            <asp:BoundField HeaderText="Amount" DataField="Order_Amount" />
            <asp:TemplateField HeaderText="Approve Order">
                <ItemTemplate>
                    <asp:Button ID="btnApprove" runat="server" CssClass="btn btn-primary" CommandArgument='<%#Eval("Order_Id") %>' Text="Approve" OnClick="btnApprove_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>