<%@ Page Title="Order" Language="C#" MasterPageFile="~/Site.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Webpages_Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <script>
    function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 10);
        window.onunload = function () { null };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin-left:50px">
    <br /><div><h1>Order</h1><br /><br /></div><br />
    <div >To Mr.<asp:Label ID="lblName" CssClass="text-capitalize" runat="server" Text="Label"></asp:Label></div>
    <div >Email : <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label></div>
    <div >Deliver To : <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label></div><br /><br />
    <div class="container">
    <asp:GridView ID="GridView1" runat="server" Width="500px" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                            CssClass="mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" EmptyDataText="There are no items in cart." CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle CssClass="alt" BackColor="White" ForeColor="#284775" />
         <Columns>
               <asp:BoundField DataField="SrNo" HeaderText="SrNo" />
               <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True"/>
               <asp:BoundField DataField="Name" HeaderText="Name"/>
               <asp:TemplateField HeaderText="Image">
                   <ItemTemplate>
                       <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" ImageUrl='<%# Bind("Image")%>'></asp:Image>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="Money" HeaderText="Money"/>
               <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
               <asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" />
           </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

<HeaderStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<PagerStyle CssClass="pgr" BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<RowStyle HorizontalAlign="Center" BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView></div>
    <br />
    <div style="float:left;margin-left:15px">
        &nbsp;Total:<asp:Label ID="Label2" style="margin-left:375px" runat="server" Text=""></asp:Label><asp:Label ID="Label1" style="margin-left:15px" runat="server" Text="" ></asp:Label></div>
    <br /><br />
    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="btn btn-warning" runat="server" Text="Confirm" />
    <br /><br />
        </div>
</asp:Content>