﻿<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Webpages_Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <script>
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 10);
        window.onunload = function () { null };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br />
    <h1>Cart</h1>
    <br />
     <div class="container">
         
       <asp:GridView ID="gvCart" runat="server" Width="800" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" EnableModelValidation="True"
                            CssClass="mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" EmptyDataText="There are no items in cart."  DataKeyNames="Id">
                            <AlternatingRowStyle CssClass="alt" />
           <Columns>
               <asp:BoundField DataField="SrNo" HeaderText="SrNo" />
               <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True"/>
               <asp:BoundField DataField="Name" HeaderText="Name"/>
               <asp:TemplateField HeaderText="Image">
                   <ItemTemplate>
                       <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" ImageUrl='<%# Bind("Image")%>'></asp:Image>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="Description" HeaderText="Description"/>
               <asp:BoundField DataField="Money" HeaderText="Money"/>
               <asp:TemplateField HeaderText="Quantity">
                   <ItemTemplate>
                       <asp:DropDownList ID="ddlQuantity" runat="server" OnSelectedIndexChanged="ddlQuantity_SelectedIndexChanged" AutoPostBack="true" SelectedValue='<%# Bind("quantity")%>'>
                           <asp:ListItem Value="1" Text="1"></asp:ListItem>
                           <asp:ListItem Value="2" Text="2"></asp:ListItem>
                           <asp:ListItem Value="3" Text="3"></asp:ListItem>
                           <asp:ListItem Value="4" Text="4"></asp:ListItem>
                           <asp:ListItem Value="5" Text="5"></asp:ListItem>
                           <asp:ListItem Value="6" Text="6"></asp:ListItem>
                           <asp:ListItem Value="7" Text="7"></asp:ListItem>
                           <asp:ListItem Value="8" Text="8"></asp:ListItem>
                           <asp:ListItem Value="9" Text="9"></asp:ListItem>
                           <asp:ListItem Value="10" Text="10"></asp:ListItem>
                           <asp:ListItem Value="11" Text="11"></asp:ListItem>
                           <asp:ListItem Value="12" Text="12"></asp:ListItem>
                       </asp:DropDownList>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="total" HeaderText="total" SortExpression="total" />
               <asp:TemplateField HeaderText="Delete">
                   <ItemTemplate>
                       <asp:ImageButton ID="imgDeleteProduct" CommandArgument='<%# Eval("SrNo") %>'
                           OnClientClick="return confirm('Are you sure you want to remove this product?');" CausesValidation="False"
                           OnClick="imgDeleteProduct_Click" AlternateText="X"
                           runat="server" />
                   </ItemTemplate>
               </asp:TemplateField>
           </Columns>
         </asp:GridView>
             
       </div><br /><br />
    <div style="margin-left:25px">
    <asp:Button ID="Checkout" CssClass="btn btn-primary" runat="server" Text="Checkout" OnClick="Checkout_Click" />
    <asp:Button ID="Main" CssClass="btn btn-success" OnClick="Main_Click" runat="server" Text="Shop More" /></div>
    <asp:Label ID="lblError" CssClass="text-capitalize" runat="server" Text=""></asp:Label>
</asp:Content>